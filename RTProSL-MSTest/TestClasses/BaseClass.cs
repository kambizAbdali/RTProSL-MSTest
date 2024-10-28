using MSTestProject.ComponentHelper;
using NLog.Filters;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
using System.Reflection;
using DataType = RTProSL_MSTest.ComponentHelper.DataType;

namespace RTProSL_MSTest.TestClasses;

public class BaseClass
{
    public string[] MultiLocationUrls = new string[]
    {
        "http://192.168.1.153:8088",
        "http://rtprosl.npgnasr.com:8088",
        "http://192.168.1.153:8040",
        "http://rtprosl.2022.npgnasr.com:8040",
        "http://local.npgnasr.com:8050", //rentex local
        "http://192.168.1.54:8050",//rentex local
                                       //"http://rtprosl.2022.npgnasr.com:8040"  --Rentex global
                                       //http://192.168.1.153:8040/login   --Rentex global
    };

    public bool CurrentUrlIsMultiLocation()
    {
        // Check if the MultiLocationUrls array contains the specified website
        return MultiLocationUrls.Contains(AppConfigKeys.Website);
    }

    public enum IgnoreType
    {
        Add,
        Validation,
        AddAndValidation,
        ValidationInRightSideForm
    }

    public static System.Diagnostics.Stopwatch stopwatch;
    public int testMethodCount = 0;
    public static int maxRetries = 2;
    public static int retryCount;
    private static readonly HashSet<Type> ExcludedTypes = new() { typeof(string), typeof(DateTime), typeof(bool) };
    public static WebElementAction webElementAction;
    public string dialogBoxMessage;
    public bool hasDialogBox;
    public bool hasError;
    public const int MaximumExecutionTime = 600000;  // 600000 milisecond ~ 10 min 
    public List<string> IsElementPresentList = new();
    public bool isSubMenuExist = true; //On some pages, the submenu may not exist or the checkbox related to displaying it may have been unckecked from the system setup.
    public bool testPassed;

    public BaseClass()
    {
        retryCount = 0;
        testPassed = false;
    }

    public void AppConfigIntialize()
    {
        var options = new ChromeOptions();
        options.AddArgument("no-sandbox");
        if (ObjectRepository.Driver == null)
        {
            Thread.Sleep(100);
            ObjectRepository.Driver = new EdgeDriver();
            ObjectRepository.Driver.Manage().Window.Maximize();
        }
    }

    public void Login(string username = null, string password = null)
    {
        AppConfigIntialize();
        webElementAction = new WebElementAction();
        NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

        //AppConfigKeys.DatabaseName = webElementAction.GetElementByCssSelector(".col-01 .wrap-content").Text;
        try
        {
            var userNameElement = webElementAction.GetElementById("input-one");
            var passwordElement = webElementAction.GetElementById("input-two");

            if (username == null) username = ObjectRepository.Config.GetUsername();
            userNameElement.SendKeys(username);

            if (password == null) password = ObjectRepository.Config.GetPassword();
            passwordElement.SendKeys(password);
            //click on loginBtn
            webElementAction.Click(By.CssSelector(".dir-row > span"));
        }
        catch (Exception e)
        {
            throw new Exception("redirect from login page to dashboard page failed" + e.Message);
        }
        WaitForLoadingSpiner();
    }

    public void Delete(string code, string gridId)
    {
        if (testPassed) return; // After save and close, Wa may have handled error; So in such conditions, we test passed and se exit from test

        try //try to click on codeElement
        {
            Thread.Sleep(500);
            WaitForLoadingSpiner();
            SearchTextInMainGrid(code);
            WaitForLoadingSpiner();
            Thread.Sleep(200);
            var codeElement = webElementAction.GetElementById(gridId).
 FindElements(By.TagName("div")).First(o => o.GetAttribute("innerText") == code);
            codeElement.Click();
        }
        catch
        {
            // ignored
        }

        var deleteBtn_By = By.Id("TOOL_BOX_DELETE_BUTTON_ID");
        webElementAction.Click(deleteBtn_By);
        Thread.Sleep(500);

        var confirmDialogContext = webElementAction.GetElementBySpecificAttribute("data-section", "confirmDialog");

        var confirmUserDeleteBtn =
            webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", confirmDialogContext);
        confirmUserDeleteBtn.Click();
        WaitForLoadingSpiner();
        Thread.Sleep(1000);
        var isPresentDeletedItem = webElementAction.IsDivPresentBySpecificText(code, By.Id(gridId));
        if (isPresentDeletedItem) throw new Exception("Error:__Delete operation failed...");
    }

    public void ClickOnFirstRowInGrid()
    {
        if (webElementAction.IsElementPresent(By.CssSelector(".ag-pinned-left-cols-container > .ag-row-first > .indicator-column")))
        {
            var cell = webElementAction.GetElementByCssSelector(".ag-pinned-left-cols-container > .ag-row-first > .indicator-column");
            cell.Click();
        }
    }
    public void ArrowNextBtn()
    {
        // Sometimes the focus may not be on any line and you may need to click on a line first.
        ClickOnFirstRowInGrid();

        Thread.Sleep(2000);
        if (webElementAction.IsElementPresent(By.CssSelector(".left-buttons-icon.icon-grid")))
        {
            var listViewBtn = webElementAction.GetElementByCssSelector(".left-buttons-icon.icon-grid");
            listViewBtn.Click();
        }

        Thread.Sleep(2000);

        var gridContent = webElementAction.GetElementByCssSelector(".ag-body-viewport");
        var rowIndexCount = gridContent
            .FindElements(By.TagName("div")).Count(o => o.GetAttribute("row-index") != null) - 2 /* first row= header,last row = footer*/;
        if (rowIndexCount > 1)
        {
            Thread.Sleep(2000);
            var defaultSelectItem = ObjectRepository.Driver.FindElement(By.ClassName("ag-cell-focus"));
            var oldClassName = defaultSelectItem.GetAttribute("class");

            webElementAction.GetElementBySpecificAttribute("data-icon-name", "arrow-next").Click();
            var newClassName = defaultSelectItem.GetAttribute("class");
            if (HasRowCheck())
                if (oldClassName == newClassName) throw new Exception("arrow-next Btn does not worked.");
        }
    }

    public void ArrowPreviousBtn()
    {
        // Sometimes the focus may not be on any line and you may need to click on a line first.
        ClickOnFirstRowInGrid();
        WaitForLoadingSpiner();
        Thread.Sleep(1000);
        if (webElementAction.IsElementPresent(By.CssSelector(".left-buttons-icon.icon-grid")))
        {
            var listViewBtn = webElementAction.GetElementByCssSelector(".left-buttons-icon.icon-grid");
            listViewBtn.Click();
        }

        var gridContent = webElementAction.GetElementByCssSelector(".ag-body-viewport");


        var rowIndexCount = gridContent
            .FindElements(By.TagName("div")).Count(o => o.GetAttribute("row-index") != null) - 2 /* first row= header,last row = footer*/;
        if (rowIndexCount > 1)
        {
            WaitForLoadingSpiner();
            Thread.Sleep(500);
            var defaultSelectItem = ObjectRepository.Driver.FindElement(By.ClassName("ag-cell-focus"));

            webElementAction.GetElementBySpecificAttribute("data-icon-name", "arrow-next").Click();
            var oldClassName = defaultSelectItem.GetAttribute("class");
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "arrow-previous").Click();

            var newClassName = defaultSelectItem.GetAttribute("class");

            if (oldClassName == newClassName) throw new Exception("arrow-Previous Btn does not worked.");
        }
    }

    public void ArrowLastBtn()
    {
        // Sometimes the focus may not be on any line and you may need to click on a line first.
        ClickOnFirstRowInGrid();
        WaitForLoadingSpiner();
        Thread.Sleep(1000);
        if (webElementAction.IsElementPresent(By.CssSelector(".left-buttons-icon.icon-grid")))
        {
            var listViewBtn = webElementAction.GetElementByCssSelector(".left-buttons-icon.icon-grid");
            listViewBtn.Click();
        }

        Thread.Sleep(1000);

        var gridContent = webElementAction.GetElementByCssSelector(".ag-body-viewport");
        var rowIndexCount = gridContent
            .FindElements(By.TagName("div")).Count(o => o.GetAttribute("row-index") != null) - 2 /* first row= header,last row = footer*/;

        if (rowIndexCount > 1)
        {
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "arrow-last").Click();

            var defaultSelectItem = ObjectRepository.Driver.FindElement(By.ClassName("ag-cell-focus"));

            var oldClassName = defaultSelectItem.GetAttribute("class");
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "arrow-previous").Click();

            var newClassName = defaultSelectItem.GetAttribute("class");

            if (oldClassName == newClassName) throw new Exception("arrow-Last Btn does not worked.");
        }
    }

    public void ListViewBtnValidate()
    {
        WaitForLoadingSpiner();
        Thread.Sleep(1000);

        if (webElementAction.IsElementPresent(By.CssSelector(".left-buttons-icon.icon-grid")))
        {
            var listViewBtn = webElementAction.GetElementByCssSelector(".left-buttons-icon.icon-grid");
            listViewBtn.Click();
        }

        var itemsCountInThumbnailMode = webElementAction
            .GetAllElementBySpecificAttribute("class", "grid-image-placeholder image-placeholder").Count;
        var itemsCountInCardViewMode = webElementAction
            .GetAllElementBySpecificAttribute("class", "image-style image-placeholder").Count;

        if (itemsCountInThumbnailMode > 0 || itemsCountInThumbnailMode > 0)
            throw new Exception("ListViewBtn View Button validation is incorrect.");

        //Sometimes, by clicking on the "ListView" button, its icon appears and prevents clicking on the "add" button.
        if (webElementAction.IsElementPresent(By.CssSelector("[placeholder='Search']")))
            webElementAction.Click(By.CssSelector("[placeholder='Search']"));
    }

    public void ListViewtBtnClick()
    {
        WaitForLoadingSpiner();
        Thread.Sleep(200);

        if (webElementAction.IsElementPresent(By.CssSelector(".left-buttons-icon.icon-grid")))
        {
            var listViewBtn = webElementAction.GetElementByCssSelector(".left-buttons-icon.icon-grid");
            try
            {
                listViewBtn.Click();
            }
            catch // If the listViewBtn is under a modal diologbox, it is not clickable
            {
                //ignored
            }
        }
        //Sometimes, by clicking on the "ListView" button, its icon appears and prevents clicking on the "add" button.
        if (webElementAction.IsElementPresent(By.CssSelector("[placeholder='Search...']")))
            webElementAction.Click(By.CssSelector("[placeholder='Search...']"));
    }

    public void ThumbnailViewBtn()
    {
        WaitForLoadingSpiner();
        Thread.Sleep(1000);
        var thumbViewBtn = webElementAction.GetElementByCssSelector(".icon-grid-picture");
        thumbViewBtn.Click();

        var itemsCountInThumbnailMode = webElementAction
            .GetAllElementBySpecificAttribute("class", "grid-image-placeholder image-placeholder").Count;
        WaitForLoadingSpiner();
        Thread.Sleep(1000);

        var gridContent = webElementAction.GetElementByCssSelector(".ag-body-viewport");
        var rowIndexCount = gridContent
            .FindElements(By.TagName("div")).Count(o => o.GetAttribute("row-index") != null);
        WaitForLoadingSpiner();
        Thread.Sleep(1000);
        //row-index
        if (itemsCountInThumbnailMode == 0 && rowIndexCount > 0)
            throw new Exception("Thumbnail View Button validation is incorrect.");
    }

    public void CardViewBtn()
    {
        WaitForLoadingSpiner();
        Thread.Sleep(1000);
        var cardView = webElementAction.GetElementByCssSelector(".icon-card-view");
        cardView.Click();

        var itemsCountInCardViewMode =
            webElementAction.GetAllElementBySpecificAttribute("class", "gird-card-wrapper").Count;

        var gridContent = webElementAction.GetElementByCssSelector(".ag-body-viewport");
        var rowIndexCount = gridContent
            .FindElements(By.TagName("div")).Count(o => o.GetAttribute("row-index") != null);
        if (rowIndexCount > 0)
            if (itemsCountInCardViewMode == 0)
                throw new Exception("Card View Button validation is incorrect.");
    }

    public void ClearInputValuesInContext(IWebElement context)
    {
        var inputElements = context.FindElements(By.TagName("input"))
            .Where(o => o.GetAttribute("type") != "checkbox" && o.GetAttribute("type") != "search");
        foreach (var element in inputElements)
            try
            {
                element.Clear();
            }
            catch
            {
                //ignorre
            }
    }

    public void ChangeScreenPageSize(int size)
    {
        var jsExecutor = (IJavaScriptExecutor)ObjectRepository.Driver;
        jsExecutor.ExecuteScript("document.body.style.zoom = '" + size + "%'");

        Thread.Sleep(2000);
    }

    public void ArrowFirstBtn()
    {
        // Sometimes the focus may not be on any line and you may need to click on a line first.
        ClickOnFirstRowInGrid();

        Thread.Sleep(2000);

        if (webElementAction.IsElementPresent(By.CssSelector(".left-buttons-icon.icon-grid")))
        {
            var listViewBtn = webElementAction.GetElementByCssSelector(".left-buttons-icon.icon-grid");
            listViewBtn.Click();
        }

        var gridContent = webElementAction.GetElementByCssSelector(".ag-body-viewport");
        var rowIndexCount = gridContent
            .FindElements(By.TagName("div")).Count(o => o.GetAttribute("row-index") != null) - 2 /* first row= header,last row = footer*/;

        if (rowIndexCount > 2)
        {
            WaitForLoadingSpiner();
            Thread.Sleep(1000);
            // click on btn arrow-first
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "arrow-first").Click();
            WaitForLoadingSpiner();
            Thread.Sleep(1000);
            var defaultSelectItem = ObjectRepository.Driver.FindElement(By.ClassName("ag-cell-focus"));

            var oldClassName = defaultSelectItem.GetAttribute("class");
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "arrow-next").Click();

            var newClassName = defaultSelectItem.GetAttribute("class");

            if (oldClassName == newClassName) throw new Exception("arrow-First Btn does not worked.");
        }
    }

    public void ShowAllRedord()
    {
        if (webElementAction.IsElementPresent(By.XPath("//span[.='Show All']")))
        {
            CloseFilterWindow();

            var showAllBtn = webElementAction.GetElementBySpecificAttribute("data-legend-name", "SHOW_ALL");
            if (!showAllBtn.GetAttribute("class").Contains("is-checked"))
                showAllBtn.Click();
        }
    }

    public void CloseFilterWindow()
    {
        // For some scenarios, the filter window may be open, and this window may overlap the showAll button.
        if (webElementAction.IsElementPresent(By.CssSelector(".body-filter-button-container.down-area")) == true)
            webElementAction.GetElementBySpecificAttribute("data-button-type", "filter").Click();
    }
    public void OpenFilterWindow()
    {
        // For some scenarios, the filter window may be open, and this window may overlap the showAll button.
        if (webElementAction.IsElementPresent(By.CssSelector(".body-filter-button-container.down-area")) == false)
            webElementAction.GetElementBySpecificAttribute("data-button-type", "filter").Click();
    }

    public void SearchAndEditClick(string code)
    {
        CloseFilterWindow();

        Thread.Sleep(700);
        ShowAllRedord();

        // Clear the search textbox if it's not empty
        if (webElementAction.IsElementPresent(By.CssSelector("[data-icon-name='clear-text']")) == true)
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();

        // Clear the search textbox if it's not empty
        if (webElementAction.IsElementPresent(By.CssSelector(".left-buttons-icon.icon-grid")) == true)
        {
            var listViewBtn = webElementAction.GetElementByCssSelector(".left-buttons-icon.icon-grid");
            listViewBtn.Click();
        }
        ClearAllTagList();
        SearchTextInMainGrid(code);

        WaitForLoadingSpiner();

        Thread.Sleep(1000);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == code.Trim());

        webElementAction.DoubleClick(selectRow);

        WaitForLoadingSpiner();
        ClickOnEditBtn();
    }

    public void ClickOnEditBtn()
    {
        Thread.Sleep(200);
        IWebElement editBtn;
        try
        {
            editBtn = webElementAction.GetElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID");
            //click on edit btn
            editBtn.Click();
        }// It is possible for two IDs to be the same TOOL_BOX_EDIT_BUTTON_ID."
        catch
        {
            editBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
            //click on edit btn
            editBtn.Click();
        }
    }

    public static void SearchTextInMainGrid(string code)
    {
        Thread.Sleep(500);
        var searchInput = webElementAction.GetElementBySpecificAttribute("class", "grid-search-input-container")
            .FindElement(By.TagName("input")); //grid-search-input-container
        searchInput.Clear();
        searchInput.SendKeys(code.Trim());
        Thread.Sleep(700);
    }

    public void CheckErrorDialogBox()
    {
        var errorMessage = string.Empty;
        var errorDialogPresent = webElementAction.IsElementPresent(By.CssSelector("[data-section='errorDialog']"));

        if (errorDialogPresent)
        {
            var errorDialogContext = webElementAction.GetElementBySpecificAttribute("data-section", "errorDialog");
            try
            {
                if (!webElementAction.IsElementPresent(By.CssSelector(".icon-polygon-up")))
                {
                    var moreDetailBtn =
                    webElementAction.GetElementBySpecificAttribute("data-button-type", "no-frame", errorDialogContext);
                    moreDetailBtn.Click();
                }
            }
            catch
            {
                //ignore   // dosent exist moreDetailBtn
            }
            errorMessage = webElementAction.GetElementBySpecificAttribute("class", "error-message-dialog")
                .GetAttribute("innerText");
        }
        if (errorMessage != string.Empty)
        {
            hasDialogBox = true;
            dialogBoxMessage = errorMessage;
            if (!errorMessage.Contains("Error:"))
            {
                hasError = true;
                GenericHelper.TakeScreenShot(TestName);
                Assert.Fail("------- UnHandled Error------: " + dialogBoxMessage);
            }
            else
            {
                testPassed = true; // Handled Error
            }
        }
    }

    private bool CheckPropertyIsClass<T>(PropertyInfo propertyInfo, T obj, IgnoreType ignoreType,
        ref IWebElement? context)
    {
        if (propertyInfo.GetIndexParameters().Length != 0) return false;

        var pt = propertyInfo.PropertyType;
        var value = propertyInfo.GetValue(obj, null);
        if (value != null && !ExcludedTypes.Contains(pt))
        {
            ClickTab(propertyInfo, ignoreType, ref context);

            if (ignoreType == IgnoreType.Validation)
                CreateValidation(value, context);
            else
                CreateAdd(value, context);
            return true;
        }
        return false;
    }

    private void ClickTab(PropertyInfo propertyInfo, IgnoreType ignoreType, ref IWebElement? context)
    {
        string validationTabClickProperty;
        var validationTabClickAttributeData = propertyInfo.CustomAttributes.SingleOrDefault(x =>
            x.AttributeType.Name == nameof(ValidationTabClickAttribute));
        //If Existed validationTabClickAttributeData
        if (validationTabClickAttributeData != null)
        {
            var value = validationTabClickAttributeData.ConstructorArguments.First().Value;
            validationTabClickProperty = value != null ? (string)value : propertyInfo.Name;
            var tabBtn = webElementAction
                .GetAllElementBySpecificAttribute("type", "button").FirstOrDefault(o =>
                    o.GetAttribute("data-tab-name") == validationTabClickProperty);
            tabBtn?.Click();
            webElementAction = new WebElementAction();
            context = webElementAction
                   .GetAllElementBySpecificAttribute("data-section", "tabContent").FirstOrDefault(o =>
                       o.GetAttribute("data-tab-name") == validationTabClickProperty);
            if (ignoreType == IgnoreType.Add)
            {
                new WebElementDataGenerator(context);
            }
        }
    }

    public void CreateAdd<T>(T entity, IWebElement? context = null)
    {
        var t = entity.GetType();

        var props = t.GetProperties();
        foreach (var propertyInfo in props)
        {
            var isIgnored = false;
            var ignoreType = IgnoreType.Validation;
            var validationIgnoredTabAttribute =
                propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationIgnoreAttribute));
            if (validationIgnoredTabAttribute != null)
            {
                isIgnored = (bool)(validationIgnoredTabAttribute.ConstructorArguments.First().Value ??
                                   false);
                ignoreType = (IgnoreType)(validationIgnoredTabAttribute.ConstructorArguments[1].Value ??
                                                  IgnoreType.Validation);
                if (ignoreType == IgnoreType.Validation)
                    isIgnored = false;
            }

            if (isIgnored) continue;
            if (!CheckPropertyIsClass(propertyInfo, entity, IgnoreType.Add, ref context))
            {
                DataType dataType;
                var validationDataTypeAttribute =
                    propertyInfo.CustomAttributes.SingleOrDefault(x =>
                        x.AttributeType.Name == nameof(ValidationDataTypeAttribute));
                //If Existed validationDataType
                if (validationDataTypeAttribute != null)
                    dataType = (DataType)(validationDataTypeAttribute.ConstructorArguments.First().Value ??
                                          DataType.Text);
                else
                    dataType = propertyInfo.PropertyType == typeof(bool) ? DataType.CheckBox : DataType.Text;

                LocatorType locatorType;
                var validationLocatorTypeAttribute = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationLocatorTypeAttribute));
                //If Existed validationLocatorType
                if (validationLocatorTypeAttribute != null)
                    locatorType =
                        (LocatorType)(validationLocatorTypeAttribute.ConstructorArguments.First().Value ??
                                      LocatorType.DataFormItemName);
                else
                    locatorType = LocatorType.DataFormItemName;

                string validationElementName;
                var validationElementNameAttributeData = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationElementNameAttribute));
                //If Existed ValidationElementNameAttribute
                if (validationElementNameAttributeData != null)
                {
                    var value = validationElementNameAttributeData.ConstructorArguments.First().Value;
                    validationElementName = value != null ? (string)value : propertyInfo.Name;
                }
                else
                {
                    validationElementName = propertyInfo.Name;
                }

                string validationElementProperty;
                var validationElementPropertyAttributeData = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationElementPropertyAttribute));
                //If Existed ValidationElementPropertyAttribute
                if (validationElementPropertyAttributeData != null)
                {
                    var value = validationElementPropertyAttributeData.ConstructorArguments.First().Value;
                    validationElementProperty = value != null ? (string)value : propertyInfo.Name;
                }
                else
                {
                    // convert first char of property from upper to lower char
                    validationElementProperty = char.ToLower(propertyInfo.Name[0]) + propertyInfo.Name.Substring(1);
                }

                string valueAsString;
                try
                {
                    switch (dataType)
                    {
                        case DataType.Text:
                            valueAsString = webElementAction
                                .GetInputElementByDataFormItemNameInDiv(validationElementProperty, context)
                                .GetAttribute("value");
                            break;

                        case DataType.CheckBox:
                            valueAsString = webElementAction
                                .GetInputElementByDataFormItemNameInDiv(validationElementProperty, context).Selected.ToString();
                            break;

                        case DataType.TextArea:
                            valueAsString =
                                webElementAction.GetTextAreaValueElementByDataFormItemNameInDiv(
                                    validationElementProperty);
                            break;

                        case DataType.Span:
                            valueAsString = webElementAction
                                .GetSpanElementByDataFormItemNameInDiv(validationElementProperty, context).GetAttribute("value");
                            break;

                        case DataType.Div:
                            valueAsString = webElementAction
                                .GetElementBySpecificAttribute(validationElementProperty, "div value")
                                .GetAttribute("value");
                            break;

                        case DataType.DropDown:
                            valueAsString = webElementAction
                                .GetDropdownElementValueByDataFormItemNameInDiv(validationElementProperty, context).Text;
                            break;

                        case DataType.Color:
                            var SpaceColorElement =
                                webElementAction.GetElementBySpecificAttribute("data-form-item-name",
                                    validationElementProperty, context);
                            valueAsString = webElementAction.GetAdvanceColorPickerStyle(SpaceColorElement);
                            break;


                        default:
                            throw new NotImplementedException("Unknown DataType " + dataType);
                    }
                }
                catch (NotImplementedException ex)
                {
                    throw ex;
                }
                catch
                {
                    IsElementPresentList.Add(propertyInfo.Name);
                    Console.WriteLine("Warning: " + propertyInfo.Name + " field does not exist in page.");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(valueAsString))
                {
                    propertyInfo.SetValue(entity, string.Empty);
                    continue;
                }

                object? parsedValue = null;
                if (propertyInfo.PropertyType.IsGenericType &&
                    propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    var underlyingType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
                    if (underlyingType == null) continue;
                    try
                    {
                        parsedValue = Convert.ChangeType(valueAsString, underlyingType);
                    }
                    catch
                    {
                        // ignored
                    }

                    propertyInfo.SetValue(entity, parsedValue);
                }
                else
                {
                    try
                    {
                        parsedValue = Convert.ChangeType(valueAsString, propertyInfo.PropertyType);
                    }
                    catch
                    {
                        // ignored
                    }

                    propertyInfo.SetValue(entity, parsedValue);
                }
            }
        }
    }

    public bool HasRowCheck()
    {
        while (!webElementAction.IsElementPresent(By.CssSelector(".ag-body-viewport")))
        {
            Thread.Sleep(100);
        }

        Thread.Sleep(500);
        var gridContent = webElementAction.GetElementByCssSelector(".ag-body-viewport");
        var rowIndexCount = gridContent.FindElements(By.TagName("div")).Count(o => o.GetAttribute("row-index") != null);
        if (rowIndexCount == 0) return false;
        return true;
    }

    public bool GridHasRow()
    {
        while (!webElementAction.IsElementPresent(By.CssSelector(".ag-body-viewport")))
        {
            Thread.Sleep(100);
        }
        var gridContent = webElementAction.GetElementByCssSelector(".ag-body-viewport");
        var rowIndexCount = gridContent.FindElements(By.TagName("div")).Count(o => o.GetAttribute("row-index") != null);
        if (rowIndexCount > 1) return true;
        return false;
    }

    public void CreateAddInGrid<T>(T tab, IWebElement context = null)
    {
        var t = tab.GetType();

        var props = t.GetProperties();
        foreach (var propertyInfo in props)
        {
            var isIgnored = false;
            var validationIgnoredTabAttribute =
                propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationIgnoreInGridAttribute));
            if (validationIgnoredTabAttribute != null)
            {
                isIgnored = (bool)(validationIgnoredTabAttribute.ConstructorArguments.First().Value ??
                                   false);
                var ignoreType = IgnoreType.Validation;
                ignoreType = (IgnoreType)(validationIgnoredTabAttribute.ConstructorArguments[1].Value ??
                                                  IgnoreType.Validation);
                if (ignoreType == IgnoreType.Validation)
                    isIgnored = false;
            }

            if (isIgnored) continue;

            string validationColId = default;
            var ValidationColIDAttributeData =
                propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationColID));
            if (ValidationColIDAttributeData != null)
            {
                var value = ValidationColIDAttributeData.ConstructorArguments.First().Value;
                validationColId = value != null ? (string)value : propertyInfo.Name;
            }
            else
            {
                validationColId = char.ToLower(propertyInfo.Name[0]) + propertyInfo.Name.Substring(1);
            }

            DataType dataType;
            var validationDataTypeAttribute =
                propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationDataTypeAttribute));
            //If Existed validationDataType
            if (validationDataTypeAttribute != null)
                dataType = (DataType)(validationDataTypeAttribute.ConstructorArguments.First().Value ??
                                      DataType.Text);
            else
                dataType = propertyInfo.PropertyType == typeof(bool) ? DataType.CheckBox : DataType.Text;

            switch (dataType)
            {
                case DataType.CheckBox:
                    {
                        try
                        {
                            var checkBoxContextCount = webElementAction
                                .GetAllElementBySpecificAttribute("col-id", validationColId, context).Count();
                            var checkBoxContext =
                                webElementAction.GetElementBySpecificAttribute("col-id", validationColId, context);

                            try
                            {
                                checkBoxContext.FindElements(By.TagName("i")).First(o =>
                                    o.GetAttribute("data-icon-name") == "tick-blue");
                                propertyInfo.SetValue(tab, true);
                            }
                            catch
                            {
                                propertyInfo.SetValue(tab, false);
                            }
                        }
                        catch
                        {
                            IsElementPresentList.Add(propertyInfo.Name);
                            Console.WriteLine("Warning: " + propertyInfo.Name + " field does not exist in page.");
                        }
                    }
                    break;

                case DataType.Color:
                    {
                        try
                        {
                            var SpaceColorElement =
                                webElementAction.GetElementBySpecificAttribute("col-id", validationColId, context);
                            var colValue = webElementAction.GetAdvanceColorPickerStyle(SpaceColorElement);
                            propertyInfo.SetValue(tab, colValue);
                        }
                        catch
                        {
                            IsElementPresentList.Add(propertyInfo.Name);
                            Console.WriteLine("Warning: " + propertyInfo.Name + " field does not exist in page.");
                        }
                    }
                    break;

                default:
                    {
                        try
                        {
                            var colValue = webElementAction
                                .GetElementByCssSelector(
                                    ".ag-row[row-index='0'] .ag-cell[col-id='" + validationColId + "']", context).Text;
                            propertyInfo.SetValue(tab, colValue);
                        }
                        catch
                        {
                            IsElementPresentList.Add(propertyInfo.Name);
                            Console.WriteLine("Warning: " + propertyInfo.Name + " field does not exist in page.");
                        }
                    }
                    break;
            }
        }
    }

    public void CreateAddInGrid<T>(T tab, ReadOnlyCollection<IWebElement> colIdList = null, bool CheckBoxIsInputType = false)
    {
        var t = tab.GetType();

        var props = t.GetProperties();
        foreach (var propertyInfo in props)
        {
            var isIgnored = false;
            var validationIgnoredTabAttribute =
                propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationIgnoreAttribute));
            if (validationIgnoredTabAttribute != null)
            {
                isIgnored = (bool)(validationIgnoredTabAttribute.ConstructorArguments.First().Value ??
                                   false);
                var ignoreType = IgnoreType.Validation;
                ignoreType = (IgnoreType)(validationIgnoredTabAttribute.ConstructorArguments[1].Value ??
                                                  IgnoreType.Validation);
                if (ignoreType == IgnoreType.Validation)
                    isIgnored = false;
            }

            if (isIgnored) continue;

            string validationColId = default;
            var ValidationColIDAttributeData =
                propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationColID));
            if (ValidationColIDAttributeData != null)
            {
                var value = ValidationColIDAttributeData.ConstructorArguments.First().Value;
                validationColId = value != null ? (string)value : propertyInfo.Name;
            }
            else
            {
                validationColId = char.ToLower(propertyInfo.Name[0]) + propertyInfo.Name.Substring(1);
            }

            DataType dataType;
            var validationDataTypeAttribute =
                propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationDataTypeAttribute));
            //If Existed validationDataType
            if (validationDataTypeAttribute != null)
                dataType = (DataType)(validationDataTypeAttribute.ConstructorArguments.First().Value ??
                                      DataType.Text);
            else
                dataType = propertyInfo.PropertyType == typeof(bool) ? DataType.CheckBox : DataType.Text;

            switch (dataType)
            {
                case DataType.CheckBox:
                    {
                        try
                        {
                            // Find the checkbox element based on its col-id attribute
                            var checkBoxContext = colIdList.FirstOrDefault(o => o.GetAttribute("col-id") == validationColId);

                            if (checkBoxContext != null)
                            {
                                // Determine the checkbox type and set the property value accordingly
                                try
                                {
                                    // Check for tick-type checkbox
                                    checkBoxContext.FindElements(By.TagName("i")).First(o => o.GetAttribute("data-icon-name") == "tick-blue");
                                    propertyInfo.SetValue(tab, true);
                                }
                                catch
                                {
                                    // Assume input-type checkbox if tick-type fails
                                    propertyInfo.SetValue(tab, checkBoxContext.FindElement(By.TagName("input")).Selected);
                                }
                            }
                            else
                            {
                                // Handle missing checkbox
                                IsElementPresentList.Add(propertyInfo.Name);
                                Console.WriteLine("Warning: " + propertyInfo.Name + " field does not exist in page.");
                            }
                        }
                        catch (Exception ex)
                        {
                            // Log any unexpected errors
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                    break;

                case DataType.Color:
                    {
                        try
                        {
                            var SpaceColorElement = colIdList.FirstOrDefault(o => o.GetAttribute("col-id") == validationColId);
                            var colValue = webElementAction.GetAdvanceColorPickerStyle(SpaceColorElement);
                            propertyInfo.SetValue(tab, colValue);
                        }
                        catch
                        {
                            IsElementPresentList.Add(propertyInfo.Name);
                            Console.WriteLine("Warning: " + propertyInfo.Name + " field does not exist in page.");
                        }
                    }
                    break;

                default:
                    {
                        try
                        {
                            var colValue = colIdList.FirstOrDefault(o => o.GetAttribute("col-id") == validationColId).Text;
                            propertyInfo.SetValue(tab, colValue);
                        }
                        catch
                        {
                            IsElementPresentList.Add(propertyInfo.Name);
                            Console.WriteLine("Warning: " + propertyInfo.Name + " field does not exist in page.");
                        }
                    }
                    break;
            }
        }
    }

    public void SetAllGridDataToEntity<T>(T entity, IWebElement firstRow)
    {
        var t = entity.GetType();

        var props = t.GetProperties();

        foreach (var propertyInfo in props)
        {
            var validationIgnored =
                propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationIgnoreInGridAttribute));
            if (validationIgnored != null)
            {
                var isIgnored = (bool)(validationIgnored.ConstructorArguments.First().Value ??
                                       false);
                if (isIgnored) continue;
            }

            if (!CheckPropertyIsClassInGrid(propertyInfo, entity, firstRow))
            {
                Thread.Sleep(2000);

                string validationColId = default;
                var ValidationColIDAttributeData =
                    propertyInfo.CustomAttributes.SingleOrDefault(x =>
                        x.AttributeType.Name == nameof(ValidationColID));
                if (ValidationColIDAttributeData != null)
                {
                    var value = ValidationColIDAttributeData.ConstructorArguments.First().Value;
                    validationColId = value != null ? (string)value : propertyInfo.Name;
                }
                else
                {
                    string validationElementProperty;
                    var validationElementPropertyAttributeData = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                        x.AttributeType.Name == nameof(ValidationElementPropertyAttribute));
                    //If Existed ValidationElementPropertyAttribute
                    if (validationElementPropertyAttributeData != null)
                    {
                        var value = validationElementPropertyAttributeData.ConstructorArguments.First().Value;
                        validationColId = value != null ? (string)value : propertyInfo.Name;
                    }
                    else
                    {
                        // convert first char of property from upper to lower char
                        validationColId = char.ToLower(propertyInfo.Name[0]) + propertyInfo.Name.Substring(1);
                    }
                }

                var ValidationTabClickAttributeData =
                    propertyInfo.CustomAttributes.SingleOrDefault(x =>
                        x.AttributeType.Name == nameof(ValidationTabClickAttribute));
                if (ValidationTabClickAttributeData != null) SetAllGridDataToEntity(propertyInfo, firstRow);

                DataType dataType;
                var validationDataTypeAttribute =
                    propertyInfo.CustomAttributes.SingleOrDefault(x =>
                        x.AttributeType.Name == nameof(ValidationDataTypeAttribute));
                //If Existed validationDataType
                if (validationDataTypeAttribute != null)
                    dataType = (DataType)(validationDataTypeAttribute.ConstructorArguments.First().Value ??
                                          DataType.Text);
                else
                    dataType = propertyInfo.PropertyType == typeof(bool) ? DataType.CheckBox : DataType.Text;

                switch (dataType)
                {
                    case DataType.CheckBox:
                        {
                            try
                            {
                                var checkBoxContext =
                                    webElementAction.GetElementBySpecificAttribute("col-id", validationColId, firstRow);

                                try
                                {
                                    var checkBoxStatus =
                                        webElementAction.GetElementBySpecificAttribute("data-icon-name", "tick-blue",
                                            checkBoxContext);
                                    if (checkBoxStatus != null) propertyInfo.SetValue(entity, true);
                                    else propertyInfo.SetValue(entity, false);
                                }
                                catch
                                {
                                    propertyInfo.SetValue(entity, false);
                                }
                            }
                            catch
                            {
                                IsElementPresentList.Add(propertyInfo.Name);
                                Console.WriteLine("Warning: " + propertyInfo.Name + " field does not exist in page.");
                            }
                        }
                        break;

                    case DataType.Color:
                        {
                            try
                            {
                                var SpaceColorElement =
                                    webElementAction.GetElementBySpecificAttribute("col-id", validationColId, firstRow);
                                var colValue = webElementAction.GetAdvanceColorPickerStyle(SpaceColorElement);
                                propertyInfo.SetValue(entity, colValue);
                            }
                            catch
                            {
                                IsElementPresentList.Add(propertyInfo.Name);
                                Console.WriteLine("Warning: " + propertyInfo.Name + " field does not exist in page.");
                            }
                        }
                        break;

                    default:
                        {
                            try
                            {
                                var colValue = webElementAction
                                    .GetElementBySpecificAttribute("col-id", validationColId, firstRow).Text;
                                propertyInfo.SetValue(entity, colValue);
                            }
                            catch
                            {
                                IsElementPresentList.Add(propertyInfo.Name);
                                Console.WriteLine("Warning: " + propertyInfo.Name + " field does not exist in page.");
                            }
                        }
                        break;
                }
            }
        }
    }

    private bool CheckPropertyIsClassInGrid<T>(PropertyInfo propertyInfo, T obj, IWebElement firstRow)
    {
        if (propertyInfo.GetIndexParameters().Length != 0) return false;

        var pt = propertyInfo.PropertyType;
        var propertyValue = propertyInfo.GetValue(obj, null);
        if (propertyValue != null && !ExcludedTypes.Contains(pt))
        {
            string validationTabClickProperty;
            var validationTabClickAttributeData = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                x.AttributeType.Name == nameof(ValidationTabClickAttribute));
            //If Existed validationTabClickAttributeData
            if (validationTabClickAttributeData != null) SetAllGridDataToEntity(propertyValue, firstRow);

            return true;
        }

        return false;
    }

    private bool CheckPropertyIsClassInGridDetailValidate<T>(PropertyInfo propertyInfo, T obj, IReadOnlyCollection<IWebElement> colIdElements)
    {
        if (propertyInfo.GetIndexParameters().Length > 0) return false;

        var propertyType = propertyInfo.PropertyType;
        var propertyValue = propertyInfo.GetValue(obj, null);
        if (propertyValue != null && !ExcludedTypes.Contains(propertyType))
        {
            string validationTabClickProperty;
            var validationTabClickAttributeData = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                x.AttributeType.Name == nameof(ValidationTabClickAttribute));
            //If Existed validationTabClickAttributeData
            if (validationTabClickAttributeData != null) CreateValidationInGrid(colIdElements, propertyValue);

            return true;
        }
        return false;
    }


    public void ConfirmBtnCheck(bool confirm = true, string dataSection = "confirmDialog")
    {
        IWebElement dialogContext = null;
        if (webElementAction.IsElementPresent(By.CssSelector("[data-section='" + dataSection + "']")))
            dialogContext = webElementAction.GetElementBySpecificAttribute("data-section", dataSection);

        // dataSection=[alertDialog, infoDialog, errorDialog, modal, confirmDialog]

        if (dialogContext != null)
        {
            string buttonType = !confirm ? "cancel" : "confirm";
            webElementAction.GetElementBySpecificAttribute("data-button-type", buttonType, dialogContext).Click();
        }
        WaitForLoadingSpiner();
    }

    public void SaveAndConfirmCheck()
    {
        Thread.Sleep(800);
        //click on saveAndCloseBtn
        webElementAction.Click(By.Id("TOOL_BOX_SAVE_AND_CLOSE_BUTTON_ID"));
        WaitForLoadingSpiner();
        Thread.Sleep(500);
        CheckErrorDialogBox();
        WaitForLoadingSpiner();
        ConfirmBtnCheck();
        WaitForLoadingSpiner();
        Thread.Sleep(500);
        CheckErrorDialogBox();
    }

    // This method runs before each test method.
    public static string TestName = default;
    public void TestInitialize(string testName)
    {
        TestName = testName;
        stopwatch = new System.Diagnostics.Stopwatch();
        // شروع شمارش زمان
        stopwatch.Start();

        DateTime currentTime = DateTime.Now;
        Console.Write("Test method of " + testName + " started at " + currentTime.ToString("HH:mm:ss") + ". ");
        GenericHelper.WriteTestMethodSatusToLogFile(TestName, GenericHelper.TestMethodStatus.Started);
    }

    // This method runs after each test method.
    [TestCleanup]
    public void TestCleanup()
    {
        if (!isSubMenuExist)
            testPassed = true;

        stopwatch.Stop();

        // Calculate the elapsed time in minutes and seconds.
        TimeSpan elapsed = stopwatch.Elapsed;

        if (testPassed)
        {
            GenericHelper.DeleteScreenShotFile(TestName);
            GenericHelper.WriteTestMethodSatusToLogFile(TestName, GenericHelper.TestMethodStatus.Passed);
        }
        else
        {
            if (elapsed.TotalSeconds > 1)
                GenericHelper.WriteTestMethodSatusToLogFile(TestName, GenericHelper.TestMethodStatus.Failed);
        }
        // Display elapsed in minutes and seconds format."
        string elapsedTime = string.Format("{0:D2} min and {1:D2} sec", elapsed.Minutes, elapsed.Seconds);
        Console.WriteLine("Response Time: " + elapsedTime);

        if (ObjectRepository.Driver != null)
        {
            ObjectRepository.Driver.Close();
            try
            {
            }
            catch
            {
                //If the user intends to close the browser, they enter this cache section.
                //Implementing try-cache allows the remaining tests to create a new driver if the browser closes for any reason and not fail.
            }
            ObjectRepository.Driver.Dispose();
            ObjectRepository.Driver.Quit();
            ObjectRepository.Driver = null;
        }
    }

    public void Logout()
    {
        GenericHelper.WaitForWebElement(By.CssSelector("[alt='Avatar']"), TimeSpan.FromSeconds(60));
        var AvatarImg = ObjectRepository.Driver.FindElement(By.CssSelector("[alt='Avatar']"));
        AvatarImg.Click();

        GenericHelper.WaitForWebElement(By.CssSelector("[data-icon-name='logout']"), TimeSpan.FromSeconds(60));
        var logoutBtn = ObjectRepository.Driver.FindElement(By.CssSelector("[data-icon-name='logout']"));
        logoutBtn.Click();
    }

    public void CreateValidationInGrid<T>(IReadOnlyCollection<IWebElement> colIdElements, T entity)
    {
        var t = entity.GetType();

        var props = t.GetProperties();
        foreach (var propertyInfo in props)
        {
            var isIgnored = false;
            var ignoreType = IgnoreType.Validation;
            var validationIgnoredTabAttribute =
                propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationIgnoreAttribute));
            if (validationIgnoredTabAttribute != null)
            {
                isIgnored = (bool)(validationIgnoredTabAttribute.ConstructorArguments.First().Value ??
                                   false);
                ignoreType = (IgnoreType)(validationIgnoredTabAttribute.ConstructorArguments[1].Value ??
                                                  IgnoreType.Validation);
                if (ignoreType == IgnoreType.Add)
                    isIgnored = false;
            }

            if (isIgnored) continue;

            var validationIgnoredInGridAttribute =
    propertyInfo.CustomAttributes.SingleOrDefault(x =>
        x.AttributeType.Name == nameof(ValidationIgnoreInGridAttribute));
            if (validationIgnoredInGridAttribute != null)
            {
                isIgnored = (bool)(validationIgnoredInGridAttribute.ConstructorArguments.First().Value ??
                                   false);
            }

            if (isIgnored) continue;

            IWebElement? context = null;
            if (!CheckPropertyIsClassInGridDetailValidate(propertyInfo, entity, colIdElements))
            {
                if (IsElementPresentList.Any(x => x == propertyInfo.Name))
                    continue;

                DataType dataType;
                var validationDataTypeAttribute =
                    propertyInfo.CustomAttributes.SingleOrDefault(x =>
                        x.AttributeType.Name == nameof(ValidationDataTypeAttribute));
                //If Existed validationDataType
                if (validationDataTypeAttribute != null)
                    dataType = (DataType)(validationDataTypeAttribute.ConstructorArguments.First().Value ??
                                          DataType.Text);
                else
                    dataType = propertyInfo.PropertyType == typeof(bool) ? DataType.CheckBox : DataType.Text;

                LocatorType locatorType;
                var validationLocatorTypeAttribute = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationLocatorTypeAttribute));
                //If Existed validationLocatorType
                if (validationLocatorTypeAttribute != null)
                    locatorType =
                        (LocatorType)(validationLocatorTypeAttribute.ConstructorArguments.First().Value ??
                                      LocatorType.DataFormItemName);
                else
                    locatorType = LocatorType.DataFormItemName;

                string validationElementName;
                var validationElementNameAttributeData = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationElementNameAttribute));
                //If Existed ValidationElementNameAttribute
                if (validationElementNameAttributeData != null)
                {
                    var value = validationElementNameAttributeData.ConstructorArguments.First().Value;
                    validationElementName = value != null ? (string)value : propertyInfo.Name;
                }
                else
                {
                    validationElementName = propertyInfo.Name;
                }

                string validationColId = default;
                var ValidationColIDAttributeData =
                    propertyInfo.CustomAttributes.SingleOrDefault(x =>
                        x.AttributeType.Name == nameof(ValidationColID));
                if (ValidationColIDAttributeData != null)
                {
                    var value = ValidationColIDAttributeData.ConstructorArguments.First().Value;
                    validationColId = value != null ? (string)value : propertyInfo.Name;
                }
                else
                {
                    var validationElementPropertyAttributeData = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                        x.AttributeType.Name == nameof(ValidationElementPropertyAttribute));
                    //If Existed ValidationElementPropertyAttribute
                    if (validationElementPropertyAttributeData != null)
                    {
                        var value = validationElementPropertyAttributeData.ConstructorArguments.First().Value;
                        validationColId = value != null ? (string)value : propertyInfo.Name;
                    }
                    else
                    {
                        // convert first char of property from upper to lower char
                        validationColId = char.ToLower(propertyInfo.Name[0]) + propertyInfo.Name.Substring(1);
                    }
                }
                var cell = colIdElements.FirstOrDefault(o => o.GetAttribute("col-id") == validationColId);

                if (cell == null)
                {
                    Console.WriteLine("Error:__Does not find col-id = " + validationColId + " in the Grid.");
                    continue;
                }
                // added 7/14/2024

                switch (dataType)
                {
                    case DataType.CheckBox:
                        {//We have two types of checkboxes: one type is non-input, and the other type is input.
                            bool checkboxValue = false;

                            if (cell.FindElements(By.TagName("input")).Count == 0)// checkbox type == non-input(tick-blue)
                            {
                                try
                                {
                                    var checkBoxStatus =
                                        webElementAction.GetElementBySpecificAttribute("data-icon-name", "tick-blue",
                                            cell);
                                    if (checkBoxStatus != null) checkboxValue = true;
                                    else
                                    {
                                        checkboxValue = false;
                                    }
                                }
                                catch
                                {
                                    checkboxValue = false;
                                }
                            }
                            else// checkbox type == input
                            {
                                if (cell.FindElement(By.TagName("input")).GetAttribute("checked") != null)
                                {
                                    checkboxValue = true;
                                }
                            }

                            bool insertedCheckbox = default;
                            bool.TryParse(propertyInfo.GetValue(entity).ToString(), out insertedCheckbox);

                            if (checkboxValue != insertedCheckbox)
                            {
                                throw new Exception("Error:__Doesn't match inserted " + validationElementName + " ='" + ((bool)propertyInfo.GetValue(entity)).ToString() + "' with saved " + validationElementName + " ='" + checkboxValue.ToString() + "'");
                            }
                        }
                        break;

                    case DataType.Color:
                        {
                            var colorValue = webElementAction.GetAdvanceColorPickerStyle(cell);
                            if (colorValue.ToString().Trim() != propertyInfo.GetValue(entity).ToString().Trim())
                            {
                                throw new Exception("Error:__Doesn't match inserted " + validationElementName + " ='" + propertyInfo.GetValue(entity).ToString() + "' with saved " + validationElementName + " ='" + colorValue + "'");
                            }
                        }
                        break;

                    case DataType.DropDown:
                        {
                            var colValue = cell.Text;
                            var insertedValue = propertyInfo.GetValue(entity).ToString().Trim();

                            if (insertedValue == "None" && colValue.Trim() == string.Empty) break;

                            if (colValue.Trim() != insertedValue)
                                throw new Exception("Error:__Doesn't match inserted " + validationElementName + " ='"
                                    + propertyInfo.GetValue(entity).ToString() + "' with saved " + validationElementName + " ='" + colValue + "'");
                        }
                        break;

                    default:// DataType.Text
                        {
                            {
                                var colValue = cell.Text.Trim();
                                var insertedValue = propertyInfo.GetValue(entity).ToString().Trim();
                                var isDecimalInserted = decimal.TryParse(insertedValue, out decimal decimalValueInserted);

                                var isDecimalColValue = decimal.TryParse(colValue, out decimal decimalColValue);
                                if (isDecimalColValue && isDecimalInserted)
                                {
                                    if (decimalColValue != decimalValueInserted)
                                        throw new Exception("Error:__Doesn't match inserted " + validationElementName + " ='" + propertyInfo.GetValue(entity).ToString() + "' with saved " + validationElementName + " ='" + colValue + "'");
                                }
                                else if (colValue != insertedValue)
                                {
                                    throw new Exception("Error:__Doesn't match inserted " + validationElementName + " ='" + propertyInfo.GetValue(entity).ToString() + "' with saved " + validationElementName + " ='" + colValue + "'");
                                }
                            }
                            break;
                        }
                }
            }
        }
    }


    public List<string> GetDifferentFields(object obj1, object obj2)
    {
        List<string> differentFields = new List<string>();

        var properties = obj1.GetType().GetProperties();

        foreach (var property in properties)
        {
            var value1 = property.GetValue(obj1);
            var value2 = property.GetValue(obj2);

            if (!Equals(value1, value2))
            {
                differentFields.Add(property.Name);
            }
        }
        return differentFields;
    }

    public void ValidateEntityFieldDifferences(object InsertedEntity, object currentEntity)
    {
        Console.WriteLine("Validate tab:" + nameof(InsertedEntity));
        List<string> differentFields = new List<string>();
        var properties = InsertedEntity.GetType().GetProperties();
        var msg = string.Empty;
        foreach (var property in properties)
        {
            var validationIgnoreInGrid =
                property.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationIgnoreInGridAttribute));

            if (validationIgnoreInGrid != null)
                continue;

            var value1 = property.GetValue(InsertedEntity);
            var value2 = property.GetValue(currentEntity);
            if (!Equals(value1, value2))
            {
                msg += "Doesn't match inserted " + property.Name + " filed ='" + value1 + "' with saved " + property.Name + " ='" + value2 + "'\n ";
            }
        }
        if (msg != string.Empty)
        {
            throw new Exception(msg);
        }
    }
    public void RefreshAllRows(string filterId = default)
    {
        if (webElementAction.IsElementPresent(By.CssSelector(".body-filter-button-container.down-area")) == false)
            if (!webElementAction.IsElementPresent(By.CssSelector("[data-button-type='filter']")))
            {
                return; // in some pages, maby filter button does not exist. for example single location databases (page truck price list).
            }
            else
            {
                webElementAction.GetElementBySpecificAttribute("data-button-type", "filter").Click();
            }

        Thread.Sleep(500);
        webElementAction.GetElementByCssSelector("[data-icon-name='eraser']").Click();

        if (!string.IsNullOrEmpty(filterId) &&
            webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='" + filterId + "']")))
            new WebElementDataGenerator(webElementAction.GetElementBySpecificAttribute("data-form-item-name", filterId));

        Thread.Sleep(500);
        webElementAction.GetElementBySpecificAttribute("id", "body-filter-refresh-btn").Click();
        WaitForLoadingSpiner();
    }

    public void WaitForLoadingSpiner()
    {
        while (webElementAction.IsElementPresent(By.CssSelector(".loading-parent")))
        {
            Thread.Sleep(200);
        }
    }

    public void GoToUrl(string menuName, string subMenuName, bool gotoLogin = true)
    {
        if (gotoLogin)
            Login();
        Thread.Sleep(200);
        webElementAction.GetElementBySpecificAttribute("data-menu-name", menuName).Click();

        if (!webElementAction.IsElementPresent(By.CssSelector("[data-menu-name='" + subMenuName + "']")))
            isSubMenuExist = false;

        webElementAction.GetElementBySpecificAttribute("data-menu-name", subMenuName).FindElement(By.TagName("a"))
            .Click();
        WaitForLoadingSpiner();
        ClickOnMainHeader();

        //click on listViewBtn
        ListViewtBtnClick();
    }

    private static void ClickOnMainHeader()
    {
        webElementAction.GetElementByCssSelector(".more-items-parent").Click();
    }

    public void ClickTab(string tabName)
    {
        WaitForLoadingSpiner();
        var tabElement = webElementAction
    .GetAllElementBySpecificAttribute("type", "button")
    .FirstOrDefault(o => o.GetAttribute("data-tab-name") == tabName);
        tabElement.Click();
    }

    public IWebElement GetTabContext(string tabName)
    {
        return webElementAction
          .GetAllElementBySpecificAttribute("data-section", "tabContent")
          .FirstOrDefault(o => o.GetAttribute("data-tab-name") == tabName);
    }

    public void ClearAllTagList()
    {
        if (webElementAction.IsElementPresent(By.CssSelector("[class='tag-list-wrapper']")))
        {
            var tagListWrapper = webElementAction.GetElementByCssSelector("[class='tag-list-wrapper']");
            var closeTagBtns = webElementAction.GetAllElementBySpecificAttribute("data-icon-name", "close", tagListWrapper);
            foreach (var item in closeTagBtns)
            {
                WaitForLoadingSpiner();
                webElementAction.GetAllElementBySpecificAttribute("data-icon-name", "close", tagListWrapper).First().Click();
            }
        }
        WaitForLoadingSpiner();
    }

    public void SetInputValueInActiveRowOfGrid(IWebElement rowContext, string colId, string Value)
    {
        var colIdContext = webElementAction.GetElementByCssSelector("[col-id= '" + colId + "'][role= 'gridcell'].ag-cell-focus");
        var Input = colIdContext.FindElement(By.TagName("input"));
        Input.Clear();
        Input.SendKeys(Value);
        Thread.Sleep(1000);
    }

    public void GoToSubMenu(string menu, string subMenu, string secondSubMenu = null)
    {
        WaitForLoadingSpiner();
        var menuElement = webElementAction.GetElementById(menu);
        menuElement.Click();

        if (secondSubMenu != null)
        {
            webElementAction.GetElementByCssSelector("div[data-menu-id*='" + subMenu + "']").Click();
            WaitForLoadingSpiner();
            webElementAction.GetElementByCssSelector("li[data-menu-id*='" + secondSubMenu + "']").Click();
        }
        else
        {
            webElementAction.Click(By.CssSelector("li[data-menu-id*='" + subMenu + "']"));
        }
        WaitForLoadingSpiner();
    }

    public void UncheckShowAllRecord()
    {
        ShowAllRedord();
        if (webElementAction.IsElementPresent(By.XPath("//span[.='Show All']")))
        {
            var showAllBtn = webElementAction.GetElementBySpecificAttribute("data-legend-name", "SHOW_ALL");
            if (showAllBtn.GetAttribute("class").Contains("is-checked"))
                showAllBtn.Click();
        }
    }

    public void SetCustomShowAll(string filterName)
    {
        UncheckShowAllRecord();
        var cssSelector = ".legends-container > .more-items-visible-children-wrapper [data-legend-name='" + filterName + "']";
        webElementAction.GetElementByCssSelector(cssSelector).Click();
    }

    public void DeleteAllRowsInMinGrid(IWebElement tabContaxt, string dataHeaderName)
    {
        while (!webElementAction.IsElementPresent(By.CssSelector("#MINI_GRID_DELETE_BUTTON[disabled] .icon-delete"), tabContaxt))
        {
            webElementAction.GetElementByCssSelector("[data-header-name='" + dataHeaderName + "'] .icon-delete").Click();
            ConfirmBtnCheck(dataSection: "confirmDialog");
        }
    }
    public void DataLegendNameFilter(string filterName)
    {
        ShowAllRedord();
        var allDataLegendNames = webElementAction.GetAllElementsByXPath("//*[@data-legend-name]");
        foreach (var item in allDataLegendNames)
        {
            try
            {
                var value = item.GetAttribute("data-legend-name");

                if (value != filterName && value != "SHOW_ALL")
                {
                    item.Click();
                }
            }
            catch
            {
                // ignore: element not interactable
            }
        }
    }

    public void GridSortDescendingByColId(string colId)
    {
        var filterElement = webElementAction.GetElementByCssSelector("[col-id='" + colId + "'][role='columnheader']")
            .FindElement(By.CssSelector(".ag-header-cell-menu-button"));
        filterElement.Click();

        var sortDescendingElement = webElementAction.GetElementByCssSelector(".ag-menu-list > div:nth-of-type(3)");
        sortDescendingElement.Click();
        WaitForLoadingSpiner();
        Thread.Sleep(1000);
    }
    public void GridSortAcendingByColId(string colId)
    {
        var filterElement = webElementAction.GetElementByCssSelector("[col-id='" + colId + "'][role='columnheader']")
            .FindElement(By.CssSelector(".ag-header-cell-menu-button"));
        filterElement.Click();

        var sortAcendingElement = webElementAction.GetElementByCssSelector(".ag-menu-list > div:nth-of-type(2)");
        sortAcendingElement.Click();
        WaitForLoadingSpiner();
        Thread.Sleep(1000);
    }

    public void HandleTestFailure(string message)
    {
        if (!isSubMenuExist)
        {
            Console.WriteLine("test is sub menu exist");
            retryCount++;
        }
        else
        {
            retryCount++;

            if (retryCount == maxRetries)
            {
                CheckErrorDialogBox();
                GenericHelper.TakeScreenShot(TestName);

                if (hasError)
                {
                    Assert.Fail("Test failed: " + dialogBoxMessage);
                }
                else if (!testPassed)
                {
                    Assert.Fail("Test failed: " + message);
                }
            }
        }
    }

    public void NavigateToHomePage()
    {
        var homePageElement = webElementAction.GetElementBySpecificAttribute("href", "/home");
        homePageElement.Click();
    }

    public bool FindColumnInMainGrid(string ColumnValue, string gridId = default)
    {
        try
        {
            ClearAllTagList();
            WaitForLoadingSpiner();
            Thread.Sleep(1000);
            IWebElement eMenuElement;

            if (gridId != null)
            {
                var gridElement = webElementAction.GetElementById(gridId);
                eMenuElement = webElementAction.GetAllElementsByCssSelector("[col-id='indicator']", gridElement).First()
                 .FindElement(By.CssSelector("[data-ref=eMenu]"));
            }

            else
            {
                eMenuElement = webElementAction.GetAllElementsByCssSelector("[col-id='indicator']").First()
                                .FindElement(By.CssSelector("[data-ref=eMenu]"));
            }

            eMenuElement.Click();
            //ref="eMenu"
            var findColElement = webElementAction.GetElementByXPath("//span[.='Find Column']");
            findColElement.Click();

            var searchColumnElement = webElementAction.GetElementByCssSelector("[placeholder='Search Columns']");
            searchColumnElement.SendKeys(ColumnValue);

            WaitForLoadingSpiner();
            Thread.Sleep(2000);

            var colValueOption = webElementAction.GetElementByCssSelector(".find-column-dialog-body")
                .FindElements(By.TagName("div")).Last(o => o.Text == ColumnValue);
            colValueOption.Click();
            var iconClose = webElementAction.GetElementByCssSelector(".icon-close");
            iconClose.Click();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void InActiveBtnCheck()
    {
        ShowAllRedord();

        DeSelectShowAllRecord();

        webElementAction.GetAllElementsByCssSelector("[data-legend-name='INACTIVE']")[1].Click();

        var inactiveColIds = webElementAction.GetAllElementsByCssSelector("[col-id='inactive']");
        var inActiveColIds = inactiveColIds.Skip(1) // Skip the first element (it is hidden in page)
    .Take(inactiveColIds.Count - 2) // Skip the last element(it is hidden in page) 
    .ToList(); // Take all elements except the first and the last
        foreach (var item in inActiveColIds)
        {
            if (!webElementAction.IsElementPresent(By.CssSelector(".icon-tick-blue"), item))
                throw new Exception("Error: Active button validate incorrected.");
        };
    }

    public void ActiveBtnCheck()
    {
        ShowAllRedord();

        DeSelectShowAllRecord();

        webElementAction.GetAllElementsByCssSelector("[data-legend-name='ACTIVE']")[1].Click();

        var inActiveColIds = webElementAction.GetAllElementsByCssSelector("[col-id='inactive']");
        foreach (var item in inActiveColIds)
        {
            if (webElementAction.IsElementPresent(By.CssSelector(".icon-tick-blue"), item))
                throw new Exception("Error: Active button validate incorrected.");
        };
    }

    public void DeSelectShowAllRecord()
    {
        if (webElementAction.IsElementPresent(By.XPath("//span[.='Show All']")))
        {
            CloseFilterWindow();

            var showAllBtn = webElementAction.GetElementBySpecificAttribute("data-legend-name", "SHOW_ALL");
            if (showAllBtn.GetAttribute("class").Contains("is-checked"))
                showAllBtn.Click();
        }
    }

    public IWebElement GetFormLeftSideContext(bool isNested = false)
    {
        if (isNested)
            return webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide")
                    .FindElements(By.TagName("div")).FirstOrDefault();
        return webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");
    }

    public void ClickOnIconBackOnHistory()
    {
        try
        {
            webElementAction.GetAllElementsByCssSelector(".icon-back-history")[0].Click();
        }
        catch
        {
            webElementAction.GetAllElementsByCssSelector(".icon-back-history")[1].Click();
        }
    }

    public void ClickOnFirstBackOnHistory()
    {
        ClickOnIconBackOnHistory();
        webElementAction.GetElementByCssSelector(".recent-screens-content > div:nth-of-type(1) > .link").Click(); ;
    }
    public void ClickOnSecondBackOnHistory()
    {
        ClickOnIconBackOnHistory();
        webElementAction.GetElementByCssSelector(".recent-screens-content > div:nth-of-type(1) > .link").Click();
    }

    public void ClickOnDetailEntryScreen()
    {
        webElementAction.GetElementById("TOOL_BOX_DETAIL_BUTTON_ID").Click();
    }

    public void SignOut()
    {
        Thread.Sleep(1000);
        var profileBtn = webElementAction.GetElementByCssSelector("[alt='Avatar']");
        profileBtn.Click();
        Thread.Sleep(1000);
        var signOutBtn = webElementAction.GetElementByCssSelector(".icon-logout");
        signOutBtn.Click();
    }

    public int GetRowCountFromGridPinnedFooter(string gridId)
    {
        string pinnedFooterSelector = "#" + gridId + " .pinned-footer:has(.icon-count)";
        string pinnedFooterText = webElementAction.GetElementByCssSelector(pinnedFooterSelector).Text.Replace(",", "");  //May string count has ',' character
        return Convert.ToInt32(pinnedFooterText);
    }

    public void CreateValidation<T>(T entity, IWebElement frameContext = null)
    {
        var t = entity.GetType();

        var props = t.GetProperties();
        foreach (var propertyInfo in props)
        {

            var isIgnored = false;
            var ignoreType = IgnoreType.Validation;
            var validationIgnoredTabAttribute =
                propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationIgnoreAttribute));
            if (validationIgnoredTabAttribute != null)
            {
                isIgnored = (bool)(validationIgnoredTabAttribute.ConstructorArguments.First().Value ??
                                   false);
                ignoreType = (IgnoreType)(validationIgnoredTabAttribute.ConstructorArguments[1].Value ??
                                                  IgnoreType.Validation);
                if (ignoreType == IgnoreType.Add)
                    isIgnored = false;
            }

            if (isIgnored) continue;
            IWebElement? context = null;
            if (!CheckPropertyIsClass(propertyInfo, entity, IgnoreType.Validation, ref context))
            {
                if (IsElementPresentList.Any(x => x == propertyInfo.Name))
                    continue;

                DataType dataType;
                var validationDataTypeAttribute =
                    propertyInfo.CustomAttributes.SingleOrDefault(x =>
                        x.AttributeType.Name == nameof(ValidationDataTypeAttribute));
                //If Existed validationDataType
                if (validationDataTypeAttribute != null)
                    dataType = (DataType)(validationDataTypeAttribute.ConstructorArguments.First().Value ??
                                          DataType.Text);
                else
                    dataType = propertyInfo.PropertyType == typeof(bool) ? DataType.CheckBox : DataType.Text;

                LocatorType locatorType;
                var validationLocatorTypeAttribute = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationLocatorTypeAttribute));
                //If Existed validationLocatorType
                if (validationLocatorTypeAttribute != null)
                    locatorType =
                        (LocatorType)(validationLocatorTypeAttribute.ConstructorArguments.First().Value ??
                                      LocatorType.DataFormItemName);
                else
                    locatorType = LocatorType.DataFormItemName;

                string validationElementName;
                var validationElementNameAttributeData = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationElementNameAttribute));
                //If Existed ValidationElementNameAttribute
                if (validationElementNameAttributeData != null)
                {
                    var value = validationElementNameAttributeData.ConstructorArguments.First().Value;
                    validationElementName = value != null ? (string)value : propertyInfo.Name;
                }
                else
                {
                    validationElementName = propertyInfo.Name;
                }

                string validationElementProperty;
                var validationElementPropertyAttributeData = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationElementPropertyAttribute));
                //If Existed ValidationElementPropertyAttribute
                if (validationElementPropertyAttributeData != null)
                {
                    var value = validationElementPropertyAttributeData.ConstructorArguments.First().Value;
                    validationElementProperty = value != null ? (string)value : propertyInfo.Name;
                }
                else
                {
                    // convert first char of property from upper to lower char
                    validationElementProperty = char.ToLower(propertyInfo.Name[0]) + propertyInfo.Name.Substring(1);
                }

                webElementAction.ValueValidatation(dataType, locatorType, frameContext, validationElementProperty,
                    validationElementName, propertyInfo.GetValue(entity), "");
            }
        }
    }

    public enum CRUD
    {
        Create,
        Read,
        Update,
        Delete,
    }
    public void CreateValidationInInformationBox<T>(T entity, IWebElement? context = null)
    {
        var t = entity.GetType();

        var props = t.GetProperties();
        foreach (var propertyInfo in props)
        {
            var isIgnored = false;
            var ignoreType = IgnoreType.Validation;
            var validationIgnoredTabAttribute =
                propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationIgnoreAttribute));
            if (validationIgnoredTabAttribute != null)
            {
                isIgnored = (bool)(validationIgnoredTabAttribute.ConstructorArguments.First().Value ??
                                   false);
                ignoreType = (IgnoreType)(validationIgnoredTabAttribute.ConstructorArguments[1].Value ??
                                                  IgnoreType.ValidationInRightSideForm);
                if (ignoreType == IgnoreType.ValidationInRightSideForm)
                    isIgnored = true;
            }

            if (isIgnored) continue;


            if (!CheckPropertyIsClass(propertyInfo, entity, IgnoreType.ValidationInRightSideForm, ref context))
            {
                if (IsElementPresentList.Any(x => x == propertyInfo.Name))
                    continue;

                //DataTypeInInfoForm dataType;
                //var validationDataTypeAttribute =
                //    propertyInfo.CustomAttributes.SingleOrDefault(x =>
                //        x.AttributeType.Name == nameof(ValidationDataTypeAttribute));
                ////If Existed validationDataType
                //if (validationDataTypeAttribute != null)
                //    dataType = (DataTypeInInfoForm)(validationDataTypeAttribute.ConstructorArguments.First().Value ??
                //                          DataTypeInInfoForm.Text);
                //else
                //    dataType = propertyInfo.PropertyType == typeof(string) ? DataTypeInInfoForm.Link : DataTypeInInfoForm.Text;


                string dataFormName;
                var validationDataFormNameAttributeData = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationDataFormName));
                //If Existed ValidationElementPropertyAttribute
                if (validationDataFormNameAttributeData != null)
                {
                    var value = validationDataFormNameAttributeData.ConstructorArguments.First().Value;
                    dataFormName = value != null ? (string)value : propertyInfo.Name;
                }
                else
                {
                    continue;
                }

                string validationElementName;
                var validationElementNameAttributeData = propertyInfo.CustomAttributes.SingleOrDefault(x =>
                    x.AttributeType.Name == nameof(ValidationElementNameAttribute));
                //If Existed ValidationElementNameAttribute
                if (validationElementNameAttributeData != null)
                {
                    var value = validationElementNameAttributeData.ConstructorArguments.First().Value;
                    validationElementName = value != null ? (string)value : propertyInfo.Name;
                }
                else
                {
                    validationElementName = propertyInfo.Name;
                }
                webElementAction.ValueValidatationInInfoBox(DataTypeInInfoForm.Text, dataFormName,
                    validationElementName, propertyInfo.GetValue(entity));
            }
        }
    }

    ImageDetector imageDetector;
    public void EditPictureValidate()
    {
        RefreshAllRows();
        ClickOnDetailEntryScreen();
        Thread.Sleep(1000);
        ClickOnEditBtn();

        imageDetector = new ImageDetector();
        imageDetector.RemoveAllPicturesIfExist();

        imageDetector.AddPicture();

        imageDetector.EditPicture();
        WaitForLoadingSpiner();
        if (!webElementAction.IsElementPresent(By.CssSelector(".custom-imageEditor-container")))
            throw new Exception("Error ______ The image editing operation is not functioning correctly.");
    }

    public string GetCurrentLocation()
    {
        return webElementAction.GetElementByCssSelector(".header-location-name").Text;
    }

    public void OpenDetailDialogInRightSide()
    {
        var openDetailRightSideClass = webElementAction.GetElementByCssSelector(".vertical.Resizer").GetAttribute("class");
        if (openDetailRightSideClass.Contains("disabled"))
            webElementAction.GetElementByCssSelector(".detail-sidebar-icons").Click();
    }

    public void SetFilterToColumn(string colId)
    {
        var filterElement = webElementAction.GetElementByCssSelector("[col-id='" + colId + "'][role='columnheader']")
            .FindElement(By.CssSelector(".ag-header-cell-menu-button"));
        filterElement.Click();

        if (!webElementAction.IsElementPresent(By.CssSelector(".ag-text-field-input")))
            webElementAction.Click(By.CssSelector("[aria-label='filter'] > .icon-medium-font"));

        var filterCheckBoxItems = webElementAction.GetElementByCssSelector(".ag-virtual-list-container").FindElements(By.TagName("input"));
        filterCheckBoxItems[0].Click();

        string secondValueInFilterList = webElementAction.GetElementByCssSelector("[aria-posinset='3'] .ag-input-field-label").Text;
        webElementAction.GetElementByCssSelector(".ag-text-field-input").SendKeys(secondValueInFilterList);

        filterCheckBoxItems = webElementAction.GetElementByCssSelector(".ag-virtual-list-container").FindElements(By.TagName("input"));
        filterCheckBoxItems[1].Click();
    }

    public void ClearAllColumnsFilter(string gridId, string FindColumnTxt, string colId)
    {
        RefreshAllRows();
        int allRowCount = GetRowCountFromGridPinnedFooter(gridId);

        FindColumnInMainGrid(FindColumnTxt);

        SetFilterToColumn(colId);

        WaitForLoadingSpiner();

        int rowCountAfterFilter = GetRowCountFromGridPinnedFooter(gridId);

        Assert.IsTrue(allRowCount > rowCountAfterFilter, "Error:  ____ Clear all columns filter doesn't work correctly.");

        ClickOnClearFilterInGrid(gridId);

        int rowCountAfterClearFilter = GetRowCountFromGridPinnedFooter(gridId);
        Assert.IsTrue(allRowCount == rowCountAfterClearFilter, "Filter");

        static void ClickOnClearFilterInGrid(string gridId)
        {
            var gridElement = webElementAction.GetElementById(gridId);
            var eMenuElement = webElementAction.GetAllElementsByCssSelector("[col-id='indicator']", gridElement).First()
             .FindElement(By.CssSelector("[data-ref=eMenu]"));
            eMenuElement.Click();

            webElementAction.Click(By.CssSelector(".icon-clear-filter"));
        }
    }

    public List<IWebElement> RetrieveVisibleColumnIdsInMainGrid(string columnId, bool pageRefresh = true)
    {
        if (pageRefresh)
            RefreshAllRows();
        var visibleColumnElements = webElementAction.GetAllElementsByCssSelector($"[col-id='{columnId}']");
        var displayedElements = visibleColumnElements.Skip(1) // Skip the first element (it is hidden on the page)
                                                    .Take(visibleColumnElements.Count - 2) // Skip the last element (it is hidden on the page)
                                                    .ToList();
        return displayedElements;
    }

    public void RefreshPage()
    {
        string currentUrl = ObjectRepository.Driver.Url;
        NavigationHelper.NavigateToUrl(currentUrl);
    }

    public bool IsValuePresentInGrid(string gridId, string targetValue)
    {
        var grid = webElementAction.GetElementById(gridId);

        var valuesInGrid = ObjectRepository.Driver.FindElements(By.CssSelector(".ag-body-viewport [col-id]"));

        return valuesInGrid.Any(cell => cell.Text.Equals(targetValue, StringComparison.OrdinalIgnoreCase));
    }

    public static void SwitchDriverToNewWindow(string originalWindow)
    {
        // Wait for the new tab to open  
        System.Threading.Thread.Sleep(2000); // or use WebDriverWait for better practice  
                                             // Switch to the new tab  
        foreach (string window in ObjectRepository.Driver.WindowHandles)
        {
            if (window != originalWindow)
            {
                ObjectRepository.Driver.SwitchTo().Window(window);
                break;
            }
        }
        /* Optionally, switch back to the original tab  
           driver.SwitchTo().Window(originalWindow);
        */
    }

    public void ClickOnIconMenuKebab()
    {
        webElementAction.Click(By.CssSelector(".icon-large-font.icon-menu-kebab"));
    }

    public void ClickOnEditAddedRecentllyRowInMinGrid()
    {
        Thread.Sleep(500);
        webElementAction.Click(By.CssSelector(".amber-color"));
    }


    public void RefreshRecordDataInGrid(string gridId, string columnId, string filterId = null)
    {
        int oldRowCount, newRowCount;
        if (webElementAction.IsElementPresent(By.CssSelector(".body-filter-button-container")))
            RefreshAllRows(filterId: filterId);

        var colIdUserKey = webElementAction.GetColumnInDefaultGridRow(gridId: gridId, columnId: columnId);

        if (colIdUserKey.Text != "Favorites")
        {
            /* Step 1: Search Text In Main Grid*/
            {
                Thread.Sleep(500);
                SearchTextInMainGrid(colIdUserKey.Text);
            }
            /* Step 2: Get the current row count before refresh */
            {
                Thread.Sleep(500);
                oldRowCount = GetRowCountFromGridPinnedFooter(gridId);
            }
            /* Step 3: Refresh the grid */
            {
                Thread.Sleep(500);
                webElementAction.Click(By.CssSelector(".icon-refresh"));
            }
            /* Step 4: Get the new row count after refresh */
            {
                Thread.Sleep(500);
                newRowCount = GetRowCountFromGridPinnedFooter(gridId);
            }
            /* Step 5: Validate that the row count remains the same */
            {
                Thread.Sleep(500);
                if (oldRowCount < newRowCount && oldRowCount > 1)
                    Assert.Fail($"Error: The entered note '{newRowCount}' does not match the original note '{oldRowCount}'.");
            }
        }

    }
    public void GenerateDataToRequiredElements(IWebElement context)
    {
        if (webElementAction.IsElementPresent(By.CssSelector(".required-star")))
            webElementAction.GenerateDataToRequiredFields(idIcons: ".required-star", context: context);
    }

    public void NavigateGridSelection(DirectionArrow direction)
    {
        // Create an instance of Actions to perform keyboard interactions.  
        Actions actions = new Actions(ObjectRepository.Driver);

        // Simulate pressing Space key before changing selection for focus.  
        actions.SendKeys(Keys.Space).Perform();

        // Perform the action based on the specified direction.  
        switch (direction)
        {
            case DirectionArrow.Down:
                actions.SendKeys(Keys.ArrowDown).Perform(); // Move down in the grid.  
                break;

            case DirectionArrow.Up:
                actions.SendKeys(Keys.ArrowUp).Perform(); // Move up in the grid.  
                break;

            case DirectionArrow.Left:
                actions.SendKeys(Keys.ArrowLeft).Perform(); // Move left in the grid (if applicable).  
                break;

            case DirectionArrow.Right:
                actions.SendKeys(Keys.ArrowRight).Perform(); // Move right in the grid (if applicable).  
                break;

            default:
                throw new ArgumentException("Invalid direction specified. Use 'Up', 'Down', 'Left', or 'Right'.");
        }

        // Simulate pressing Space key again to confirm the selection change.  
        actions.SendKeys(Keys.Space).Perform();
    }

    public enum DirectionArrow
    {
        Up,
        Left,
        Right,
        Down
    }

    public void RefreshAllRowsBySpecificAutoComboGrid(string filterId, string filterValue)
    {
        if (webElementAction.IsElementPresent(By.CssSelector(".body-filter-button-container.down-area")) == false)
            if (!webElementAction.IsElementPresent(By.CssSelector("[data-button-type='filter']")))
            {
                return; // in some pages, maby filter button does not exist. for example single location databases (page truck price list).
            }
            else
            {
                webElementAction.GetElementBySpecificAttribute("data-button-type", "filter").Click();
            }
        var context = webElementAction.GetAllElementsByCssSelector($"[data-form-item-name='{filterId}']");
        new WebElementDataGenerator().ComboAutoCompleteGenerator(context, filterValue);

        Thread.Sleep(500);
        webElementAction.GetElementBySpecificAttribute("id", "body-filter-refresh-btn").Click();
        WaitForLoadingSpiner();
    }
}