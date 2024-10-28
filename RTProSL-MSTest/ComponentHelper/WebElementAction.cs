using AventStack.ExtentReports.Utils;
using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace RTProSL_MSTest.ComponentHelper;

public enum DataType
{
    Text,     //   webElementAction.GetInputElementByDataFormItemNameInDiv("productionTitle").GetAttribute("value");    for AutocomboGrid and  textBoxs
    CheckBox, //   webElementAction.GetCheckBoxStatusInDataFormContext("certificateOfIns");    or  GetInputElementByDataFormItemNameInDiv("creditApproved").Selected;
    TextArea, //   webElementAction.GetTextAreaValueElementByDataFormItemNameInDiv("notes"); //** read from page **//   
    Span,     //   webElementAction.GetSpanElementByDataFormItemNameInDiv()
    Div,      //   webElementAction.GetElementBySpecificAttribute("divID", "div value");
    DropDown, //   webElementAction.GetDropdownElementValueByDataFormItemNameInDiv("productionStatus").Text 
    Color,    //   var SpaceColorElement = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "spaceColor");
              //  _productionEntity.GeneralTab.SpaceColor = webElementAction.GetAdvanceColorPickerStyle(SpaceColorElement); //** read from page **/
    RedioButton
}

public enum DataTypeInInfoForm //for right side information boxes such as Payment List page
{
    Text, // 
    Link, // 
}
public enum LocatorType
{
    ID,
    Name,
    CssSelector,
    SpecificAtttribute,
    DataFormItemName,
    Default
}


public class WebElementAction
{
    private readonly IWebDriver driver;

    public static TimeSpan MaxElementWaitTime = TimeSpan.FromSeconds(12);

    public WebElementAction()
    {
        driver = ObjectRepository.Driver;
    }

    public void Click(By location, IWebElement context = null)
    {
        if (context == null)
        {
            GenericHelper.WaitForWebElement(location, MaxElementWaitTime);
            driver.FindElement(location).Click();
        }
        else
        {
            context.FindElement(location).Click();
        }
    }

    public void DoubleClick(By location)
    {
        var act = new Actions(driver);
        Thread.Sleep(500);
        act.DoubleClick(driver.FindElement(location)).Perform();
    }

    public void DoubleClick(IWebElement element)
    {
        var act = new Actions(driver);
        Thread.Sleep(500);
        act.DoubleClick(element).Perform();
    }

    public void SendKeys(By location, string value)
    {
        GenericHelper.WaitForWebElement(location, MaxElementWaitTime);
        driver.FindElement(location).SendKeys(value);
    }

    public void Clear(By location)
    {
        GenericHelper.WaitForWebElement(location, MaxElementWaitTime);
        driver.FindElement(location).Clear();
    }

    public string GetText(By location)
    {
        GenericHelper.WaitForWebElement(location, MaxElementWaitTime);

        return driver.FindElement(location).Text != string.Empty
            ? driver.FindElement(location).Text
            : driver.FindElement(location).GetAttribute("value");
    }

    public bool GetCheckBoxStatus(By location)
    {
        return driver.FindElement(location).Selected;
    }

    public IWebElement GetInputElementByDataFormItemNameInDiv(string dataFormItemName, IWebElement context = null)
    {
        var byCssSelector = By.CssSelector($"[data-form-item-name='{dataFormItemName}']");

        // Wait for the element to be present  
        if (context == null)
        {
            GenericHelper.WaitForWebElement(byCssSelector, TimeSpan.FromSeconds(10));
        }

        // Determine the tag name based on dataFormItemName  
        string tagName = dataFormItemName == "notes" ? "textarea" : "input";

        // Find the element based on the context  

        if (context != null)
            return context.FindElement(byCssSelector).FindElement(By.TagName(tagName));
        return driver.FindElement(byCssSelector).FindElement(By.TagName(tagName));
    }

    public IWebElement GetSpanElementByDataFormItemNameInDiv(string dataFormItemName, IWebElement context = null)
    {
        var byCssSelector = By.CssSelector("[data-form-item-name='" + dataFormItemName + "']");
        if (context == null)
            return driver.FindElement(byCssSelector)
            .FindElement(By.TagName("span"));
        return context.FindElement(byCssSelector)
            .FindElement(By.TagName("span"));
    }

    public IWebElement GetElementByName(string name, IWebElement context = null)
    {
        GenericHelper.WaitForWebElement(By.Name(name), MaxElementWaitTime);
        return context == null ? driver.FindElement(By.Name(name)) : context.FindElement(By.Name(name));
    }

    public IWebElement GetElementByXPath(string xPath)
    {
        GenericHelper.WaitForWebElement(By.XPath(xPath), MaxElementWaitTime);
        return driver.FindElement(By.XPath(xPath));
    }

    public IWebElement GetElementBySpecificAttribute(string attribute, string value, IWebElement context = null)
    {
        var byCssSelector = By.CssSelector("[" + attribute + "='" + value + "']");

        if (context == null)
        {
            GenericHelper.WaitForWebElement(byCssSelector,
    MaxElementWaitTime);
            return driver.FindElement(byCssSelector);
        }
        return context.FindElement(byCssSelector);
    }

    public ReadOnlyCollection<IWebElement> GetAllElementBySpecificAttribute(string attribute, string value,
        IWebElement context = null)
    {
        var byCssSelector = By.CssSelector("[" + attribute + "='" + value + "']");
        Thread.Sleep(1000);

        return context == null
            ? driver.FindElements(byCssSelector)
            : context.FindElements(byCssSelector);
    }

    public ReadOnlyCollection<IWebElement> GetAllElementsByCssSelector(string cssSelector, IWebElement context = default)
    {
        Thread.Sleep(500);
        return context == null
           ? driver.FindElements(By.CssSelector(cssSelector))
           : context.FindElements(By.CssSelector(cssSelector));
    }

    public bool GetCheckBoxStatusInDataFormContext(string dataFormItemName)
    {
        var byCssSelector = By.CssSelector("[data-form-item-name='" + dataFormItemName + "']");

        GenericHelper.WaitForWebElement(byCssSelector,
            MaxElementWaitTime);
        return driver.FindElement(byCssSelector)
            .FindElement(By.TagName("input")).Selected;
    }

    public bool IsElementPresent(By by, IWebElement context = null)
    {
        try
        {
            // Use context if provided, otherwise use the driver
            var element = context?.FindElement(by) ?? driver.FindElement(by);
            return true; // Element found
        }
        catch (NoSuchElementException)
        {
            return false; // Element not found
        }
    }

    public bool IsDivPresentBySpecificText(string text, By contextBy = null)
    {
        try
        {
            var elements = contextBy != null
                ? driver.FindElement(contextBy).FindElements(By.TagName("div"))
                : driver.FindElements(By.TagName("div"));

            return elements.Any(o => o.Text.Contains(text));
        }
        catch
        {
            return false;
        }
    }


    public IWebElement GetElementById(string Id)
    {
        GenericHelper.WaitForWebElement(By.Id(Id), MaxElementWaitTime);
        return driver.FindElement(By.Id(Id));
    }

    public string GetDropDownValueByDataFormItemName(string dataFormItemName)
    {
        string value = string.Empty;
        var byCssSelector = By.CssSelector("[data-form-item-name='" + dataFormItemName + "']");
        GenericHelper.WaitForWebElement(byCssSelector,
            MaxElementWaitTime);
        var dropDownContext = driver.FindElement(byCssSelector);
        try
        {
            value = dropDownContext.FindElement(By.ClassName("ant-select-selection-item")).Text;
        }
        catch
        {
            Console.WriteLine($"No selection item found for '{dataFormItemName}'.");
        }

        return value;
    }

    public string GetTextAreaValueElementByDataFormItemNameInDiv(string dataFormItemName)
    {
        var byCssSelector = By.CssSelector("[data-form-item-name='" + dataFormItemName + "']");
        GenericHelper.WaitForWebElement(byCssSelector,
            MaxElementWaitTime);
        return driver.FindElement(byCssSelector)
            .FindElement(By.TagName("textarea")).GetAttribute("value");
    }

    public ReadOnlyCollection<IWebElement> GetElementsByTagName(string Tagname)
    {
        return driver.FindElements(By.TagName(Tagname));
    }

    public IWebElement GetElementByCssSelector(string value, IWebElement context = null)
    {
        if (context == null)
        {
            GenericHelper.WaitForWebElement(By.CssSelector(value),
            MaxElementWaitTime);
        }
        return context != null ? context.FindElement(By.CssSelector(value)) : driver.FindElement(By.CssSelector(value));
    }

    public IWebElement GetElementByCssSelector(By value, IWebElement context = null)
    {
        if (context == null)
        {
            GenericHelper.WaitForWebElement(value,
            MaxElementWaitTime);
        }
        return context != null ? context.FindElement(value) : driver.FindElement(value);
    }

    public void ClearInputValuesInContext(IWebElement context)
    {
        var inputElements = context.FindElements(By.TagName("input")).Where(o => o.GetAttribute("type") != "checkbox");
        foreach (var element in inputElements)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].value='';", element);
            }
            catch
            {
                //ignored
            }
        }
    }

    public string ConvertCssClassToCssSelector(string value)
    {
        var cssSelector = "." + value.Replace(" ", ".");
        return cssSelector;
    }

    public void ValueValidatation<T, M>(DataType dataType, LocatorType locator, IWebElement context,
        string elementProperty, string elementName, M insertedValue, T property1)
    {
        string currentValue = string.Empty;
        switch (dataType)
        {
            case DataType.Text:
            case DataType.Div:
                switch (locator)
                {
                    case LocatorType.ID:
                        currentValue = GetElementById(elementName).GetAttribute("value").Trim();
                        if ((string)(object)insertedValue.ToString().Trim() != currentValue)
                            throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                        break;

                    case LocatorType.Name:
                        currentValue = GetElementByName(elementProperty).GetAttribute("value").Trim();
                        if ((string)(object)insertedValue.ToString().Trim() != currentValue)
                            throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                        break;

                    case LocatorType.CssSelector:
                        currentValue = GetElementByCssSelector(elementProperty).GetAttribute("value").Trim();
                        if ((string)(object)insertedValue.ToString().Trim() != currentValue)
                            throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                        break;

                    case LocatorType.DataFormItemName:
                        currentValue = GetElementBySpecificAttribute("data-form-item-name", (string)elementProperty, context)
                                .FindElements(By.TagName("input")).FirstOrDefault().GetAttribute("value").Trim();
                        if ((string)insertedValue.ToString().Trim() != currentValue)
                            throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                        break;
                }

                break;

            case DataType.CheckBox:
                if ((bool)(object)insertedValue != GetCheckBoxStatusInDataFormContext((string)elementProperty))
                    throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                break;

            case DataType.TextArea:
                currentValue = GetElementBySpecificAttribute("data-form-item-name", (string)elementProperty, context)
                        .FindElements(By.TagName("textArea")).FirstOrDefault().GetAttribute("value").Trim();
                if ((string)(object)insertedValue.ToString().Trim() != currentValue)

                    throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                break;

            case DataType.Span:

                switch (locator)
                {
                    case LocatorType.ID:
                        currentValue = GetElementById(elementProperty).GetAttribute("value").Trim();
                        if ((string)(object)insertedValue != currentValue)
                            throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                        break;
                    case LocatorType.Name:
                        currentValue = GetElementByName(elementProperty).GetAttribute("value").Trim();
                        if ((string)(object)insertedValue != currentValue)
                            throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                        break;
                    case LocatorType.CssSelector:
                        currentValue = GetElementByCssSelector(elementProperty).GetAttribute("value").Trim();
                        if ((string)(object)insertedValue != currentValue)
                            throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                        break;
                    case LocatorType.SpecificAtttribute:
                        currentValue =
                            GetElementBySpecificAttribute(elementProperty, (string)(object)property1, context)
                                .FindElements(By.TagName("span")).FirstOrDefault().GetAttribute("value").Trim();
                        if ((string)(object)insertedValue != currentValue)
                            throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                        break;
                }

                break;

            case DataType.DropDown:
                currentValue = GetDropDownValueByDataFormItemName(elementProperty).Trim();
                if ((string)(object)insertedValue != currentValue)
                    throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                break;

            case DataType.Color:
                {
                    switch (locator)
                    {
                        case LocatorType.DataFormItemName:
                            var SpaceColorElement = GetElementBySpecificAttribute("data-form-item-name", elementProperty);
                            currentValue = GetAdvanceColorPickerStyle(SpaceColorElement);

                            if ((string)(object)insertedValue != currentValue)
                                throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                            break;
                    }
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
        }
    }

    public void ValidateDefaultSelectedValueInGrid(string expectedValue, string fieldName, string gridName, string idValue)
    {
        try
        {
            var defaultSelectedElement = driver.FindElement(By.Id(idValue));
            var matchingElement = defaultSelectedElement
                .FindElements(By.TagName("div"))
                .FirstOrDefault(element => element.Text == expectedValue);

            if (matchingElement != null)
            {
                return; // The expected value matches the found element  
            }

            throw new InvalidOperationException($"The inserted value for {fieldName} does not match the saved value.");
        }
        catch (NoSuchElementException)
        {
            throw new InvalidOperationException($"Unable to find default department in the {gridName} list.");
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while validating the selected value in the grid: {ex.Message}", ex);
        }
    }

    public IWebElement GetDropdownElementValueByDataFormItemNameInDiv(string dataFormItemName, IWebElement context = null)
    {
        var byCssSelector = By.CssSelector("[data-form-item-name='" + dataFormItemName + "']");
        if (context == null)
        {
            GenericHelper.WaitForWebElement(byCssSelector,
            MaxElementWaitTime);
        }

        return context == null
            ? driver.FindElement(byCssSelector)
            .FindElements(By.TagName("span"))
            .FirstOrDefault(o => o.GetAttribute("class") == "ant-select-selection-item")
            : context.FindElement(byCssSelector)
            .FindElements(By.TagName("span"))
            .FirstOrDefault(o => o.GetAttribute("class") == "ant-select-selection-item");
    }

    public string GetAdvanceColorPickerStyle(IWebElement advanceColorPicker)
    {
        // Find the first element with class 'main-color-picker-square' or 'color-cell-style'  
        var colorPickerElement = advanceColorPicker.FindElements(By.TagName("span"))
            .FirstOrDefault(element =>
                element.GetAttribute("class").Equals("main-color-picker-square") ||
                element.GetAttribute("class").Equals("color-cell-style"));

        // If the element is not found, return null or an appropriate default value  
        return colorPickerElement?.GetAttribute("style");
    }

    public string FormatNumberWithCommas(string numberString)
    {
        string formattedString = "";

        for (int i = numberString.Length - 1, j = 0; i >= 0; i--, j++)
        {
            if (j != 0 && j % 3 == 0)
            {
                formattedString = "," + formattedString;
            }

            formattedString = numberString[i] + formattedString;
        }
        return formattedString;
    }

    public IWebElement GetInputElementByColIdInDiv(string colId, IWebElement context = null)
    {
        var columnSelector = By.CssSelector($"[col-id='{colId}']");

        if (context == null)
        {
            GenericHelper.WaitForWebElement(columnSelector,
                TimeSpan.FromSeconds(6));

            return driver.FindElement(columnSelector)
                .FindElement(By.TagName("input"));
        }
        return context.FindElement(columnSelector)
            .FindElement(By.TagName("input"));
    }

    public IWebElement GetInputElementByDataInputNameInDiv(string dataFormItemName, IWebElement context = null)
    {
        var dataInputSelector = By.CssSelector($"[data-input-name='{dataFormItemName}']");

        if (context == null)
        {
            GenericHelper.WaitForWebElement(dataInputSelector,
               TimeSpan.FromSeconds(6));

            return driver.FindElement(dataInputSelector)
                .FindElement(By.TagName("input"));
        }
        return context.FindElement(dataInputSelector)
            .FindElement(By.TagName("input"));
    }

    public void ClickOnPostBtnInMinGrid(string gridId = default)
    {
        if (!string.IsNullOrEmpty(gridId))
            EnablePostBtnIfDisable(gridId);
        var postBtn = GetElementByCssSelector(".green-color");
        postBtn.Click();
    }

    private void EnablePostBtnIfDisable(string gridId)
    {
        if (!IsElementPresent(By.CssSelector(".green-color")))
        {
            Thread.Sleep(2000);
            IWebElement eMenuElement;

            var gridElement = GetElementById(gridId);
            eMenuElement = GetAllElementsByCssSelector("[col-id='indicator']", gridElement).First()
                .FindElement(By.CssSelector("[data-ref=eMenu]"));

            eMenuElement.Click();

            Click(By.CssSelector(".icon-indicator")); // click on show actions buttons
            Click(By.CssSelector(".ag-cell-inline-editing.ag-cell-last-left-pinned"), context: GetElementById(gridId)); //click on pinned icon for showing post btn
        }
    }
    public void EnableEditBtnInMinGridIfDisable(string gridId)
    {
        if (!IsElementPresent(By.CssSelector(".ag-pinned-left-cols-container > .ag-row-first .icon-edit-fill")))
        {
            Thread.Sleep(2000);
            IWebElement eMenuElement;

            var gridElement = GetElementById(gridId);
            eMenuElement = GetAllElementsByCssSelector("[col-id='indicator']", gridElement).First()
                .FindElement(By.CssSelector("[data-ref=eMenu]"));

            eMenuElement.Click();

            Click(By.CssSelector(".icon-indicator")); // click on show actions buttons


        }
        Click(By.CssSelector(".ag-pinned-left-cols-container > .ag-row-first .icon-edit-fill")); // click on icon edit
    }

    public void GenerateAutoCompleteComboWithSpecificValue(string dataFormItemName, string value)
    {
        var existingVendorContext = GetElementBySpecificAttribute("data-form-item-name", dataFormItemName);
        var comboAutoCompleteExistingVendor = existingVendorContext.FindElements(By.CssSelector(".combo-auto-complete"));
        new WebElementDataGenerator().ComboAutoCompleteGenerator(comboAutoCompleteExistingVendor, value);
    }

    public void SetValueToAutoComboCellGrid(string colId, string value)
    {
        var newRowColIdsContext = GetElementByCssSelector(".ag-center-cols-container .new-added-row");
        var colIdContext = GetElementBySpecificAttribute("col-id", colId, newRowColIdsContext);
        var ComboAutoComplete = colIdContext.FindElements(By.CssSelector(".icon-medium-font.icon-grid"));
        new WebElementDataGenerator().ComboAutoCompleteGeneratorInGrid(ComboAutoComplete, value);
    }

    public void GenerateDataToDataFormItemNameContext(string dataFormItemName)
    {
        var context = GetElementByCssSelector("[data-form-item-name= '" + dataFormItemName + "']");
        new WebElementDataGenerator(context);
    }

    public bool DeSelectingCheckbox(string dataFormItemName, IWebElement context = null)
    {
        var approvedCheckbox = context == null ? GetInputElementByDataFormItemNameInDiv(dataFormItemName) :
            GetInputElementByDataFormItemNameInDiv(dataFormItemName, context);

        if (approvedCheckbox.Selected)
            approvedCheckbox.Click();

        return approvedCheckbox.Selected;
    }

    public bool SelectingCheckbox(string dataFormItemName, IWebElement context = null)
    {
        var approvedCheckbox = context == null ? GetInputElementByDataFormItemNameInDiv(dataFormItemName) :
            GetInputElementByDataFormItemNameInDiv(dataFormItemName, context);

        if (!approvedCheckbox.Selected)
            approvedCheckbox.Click();

        return approvedCheckbox.Selected;
    }

    public void ClickOnAddNewRowInMinGrid(string dataHeaderName)
    {
        var addRecord = GetElementByCssSelector("[data-header-name='" + dataHeaderName + "'] .icon-add");
        addRecord.Click();
    }

    public void GenerateDataToGridColId(string gridId, string colId)
    {
        var gridElement = GetElementById(gridId);
        var allColIds = gridElement.FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
        var col = allColIds.FirstOrDefault(o => o.GetAttribute("col-id") == colId);
        new WebElementDataGenerator(col, IsContextGrid: true);
    }

    public void RighClick(IWebElement element)
    {
        Actions actions = new Actions(ObjectRepository.Driver);
        actions.ContextClick(element).Build().Perform();
    }

    public ReadOnlyCollection<IWebElement> GetAllElementsByXPath(string xpath, IWebElement context = null)
    {
        return context == null
            ? driver.FindElements(By.XPath(xpath))
            : context.FindElements(By.XPath(xpath));
    }

    public ReadOnlyCollection<IWebElement> GetAllCellsInMinGridBySpecificColId(string gridId, string colId)
    {
        var gridElement = GetElementById(gridId);

        var allSpecificColIds = gridElement.FindElements(By.CssSelector("[col-id='" + colId + "']"))
            .ToList();

        allSpecificColIds = allSpecificColIds
            .Skip(1) // Skip the first element (it is columns title)
            .Take(allSpecificColIds.Count - 2) // Skip the last element(it is extra (empty)) // Take all elements except the first and the last
            .ToList();

        return allSpecificColIds.AsReadOnly();
    }

    public ReadOnlyCollection<IWebElement> GetAllElementsByTagName(string tagName, IWebElement context = null)
    {
        Thread.Sleep(1000);

        return context == null
            ? driver.FindElements(By.TagName(tagName))
            : context.FindElements(By.TagName(tagName));
    }

    public IWebElement GetColumnInDefaultGridRow(string columnId, string gridId = null)
    {
        IWebElement column;
        string columnSelector = $".ag-row.ag-row-focus [col-id='{columnId}']";
        if (IsElementPresent(By.CssSelector(columnSelector)))
        {
            if (string.IsNullOrEmpty(gridId))
            {
                column = GetElementByCssSelector(columnSelector);
            }
            else
            {
                IWebElement grid = GetElementById(gridId);
                column = GetElementByCssSelector(columnSelector, grid);
            }

            return column;
        }
        return GetElementByCssSelector("[href='/home#menu--3--Favorites'] > .sidebar-content");
    }
    public void GenerateDataToRequiredFields(string idIcons = ".icon-error", IWebElement context = null)
    {
        ReadOnlyCollection<IWebElement> requiredIcons;

        requiredIcons = GetAllElementsByCssSelector(idIcons, context);

        foreach (var icon in requiredIcons)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)ObjectRepository.Driver;
            IWebElement parentNode = (IWebElement)jsExecutor.ExecuteScript("return arguments[0].parentNode;", icon);

            while (parentNode.GetAttribute("data-form-item-name") == null)
                parentNode = (IWebElement)jsExecutor.ExecuteScript("return arguments[0].parentNode;", parentNode);

            if (GetInputElementByDataFormItemNameInDiv(parentNode.GetAttribute("data-form-item-name"), context).GetAttribute("value").IsNullOrEmpty())   //only generate data to empty fields
                new WebElementDataGenerator(parentNode);
        }
    }

    public void ClickOnPostChanges()
    {
        GetElementByCssSelector(".icon-tick").Click();
    }

    public void MoveMouseToElement(IWebElement element)
    {
        Actions actions = new Actions(ObjectRepository.Driver);
        actions.MoveToElement(element).Perform();
    }

    public IWebElement GetInputElementByDataFormItemTypeInDiv(string dataFormItemType, IWebElement context = null)
    {
        var byCssSelector = By.CssSelector("[data-form-item-type='" + dataFormItemType + "']");
        if (context == null)
        {
            GenericHelper.WaitForWebElement(byCssSelector,
                TimeSpan.FromSeconds(10));

            return driver.FindElement(byCssSelector)
                .FindElement(By.TagName("input"));
        }
        return context.FindElement(byCssSelector)
            .FindElement(By.TagName("input"));
    }

    public void ClickOnAddNewRecord()
    {
        GetElementById("TOOL_BOX_ADD_BUTTON_ID").Click();
    }

    public void ValueValidatationInInfoBox<M>(DataTypeInInfoForm dataType, string dataInfoName, string elementName, M insertedValue)
    {
        string currentValue = string.Empty;
        switch (dataType)
        {
            case DataTypeInInfoForm.Text:
                {
                    currentValue = GetElementBySpecificAttribute("data-info-name", dataInfoName).FindElement(By.ClassName("value-wrapper")).Text.Trim();
                    if (((string)(object)insertedValue).Trim() != currentValue)
                        throw new Exception("Doesn't match inserted " + elementName + " ='" + insertedValue + "' with saved " + elementName + " ='" + currentValue + "'\n");
                    break;
                }
                break;

            //case DataTypeInInfoForm.Link:
            //    {

            //    }
            default:

                throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
        }
    }

    public ReadOnlyCollection<IWebElement> GetAllElementsByClass(string cssSelector, IWebElement context = default)
    {
        Thread.Sleep(500);
        return context == null
           ? driver.FindElements(By.ClassName(cssSelector))
           : context.FindElements(By.ClassName(cssSelector));
    }

    public ReadOnlyCollection<IWebElement> FindElementsContainingText(string searchText)
    {
        var elements = GetAllElementsByXPath("//*[contains(text(), '" + searchText + "')]");
        return elements;
    }

    public void ScrolToRight(string cssSelector)
    {
        MoveMouseToElement(GetInputElementByDataFormItemTypeInDiv(cssSelector));
        IJavaScriptExecutor jsvertical = (IJavaScriptExecutor)ObjectRepository.Driver;
        jsvertical.ExecuteScript("document.querySelector(`" + cssSelector + "`).scrollTo({top:0,left:0})");
    }

    public void ScrolToLeft(string cssSelector)
    {
        IJavaScriptExecutor jsvertical = (IJavaScriptExecutor)ObjectRepository.Driver;
        jsvertical.ExecuteScript("document.querySelector(`" + cssSelector + "`).scrollTo({top:0,left:-5000})");
    }

    public void ScrollUp(string cssSelector)
    {
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)ObjectRepository.Driver;
        jsExecutor.ExecuteScript("document.querySelector(`" + cssSelector + "`).scrollTo({top:-5000,left:0})");
    }

    public void ScrollDown(string cssSelector)
    {
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)ObjectRepository.Driver;
        jsExecutor.ExecuteScript("document.querySelector(`" + cssSelector + "`).scrollTo({top:5000,left:0})");
    }

    public void AddNewRowToMinGrid(string DataHeaderName, string GridId, bool clickOnPostBtn = true)
    {
        ClickOnAddNewRowInMinGrid(dataHeaderName: DataHeaderName);
        Thread.Sleep(1000);
        var newRowColsContext = GetElementByCssSelector(".ag-center-cols-container .new-added-row");
        new WebElementDataGenerator(newRowColsContext, IsContextGrid: true);
        //add RCD values 
        if (clickOnPostBtn)
            ClickOnPostBtnInMinGrid(gridId: GridId);
    }

    public void SetValueToInputCellGrid(string gridId, string colId, string value)
    {
        IWebElement inputElement = GetElementByCssSelector("#" + gridId + " .ag-body-viewport .ag-row-focus [col-id='" + colId + "'] input");
        DoubleClick(inputElement);
        inputElement.SendKeys(Keys.Backspace);
        inputElement.SendKeys(value);
    }
    public ReadOnlyCollection<IWebElement> GetDivElementsByContainText(string text, By contextBy = null)
    {
        try
        {
            var elements = contextBy != null
                ? driver.FindElement(contextBy).FindElements(By.TagName("div"))
                : driver.FindElements(By.TagName("div"));

            return elements.Where(o => o.Text.Contains(text)).ToList().AsReadOnly();
        }
        catch
        {
            return null;
        }
    }

    public void ClearValueInAutoComboGrid(string dataFormItemName)
    {
        if (IsElementPresent(By.CssSelector("[data-form-item-name='" + dataFormItemName + "']")))
        {
            var currencyContext = GetElementByCssSelector("[data-form-item-name='" + dataFormItemName + "'] .information-container");
            DoubleClick(currencyContext);
            GetInputElementByDataFormItemNameInDiv(dataFormItemName).SendKeys(Keys.Backspace);
        }
    }
}