using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses;
using RTProSL_MSTest.TestClasses.FileMaintenance.Dispatch;
using SeleniumWebdriver.Settings;
using System.Xml.Linq;

namespace RTProSL_MSTest.ComponentHelper;

public class WebElementDataGenerator : BaseClass
{
    public IWebElement Context;

    public WebElementDataGenerator()
    {

    }

    public WebElementDataGenerator(IWebElement context, bool IsContextGrid = false)
    {
        Context = context;
        var inputElements = context.FindElements(By.TagName("input")).Where(o =>
        !o.GetAttribute("class").Contains("main-input-read-only")
        && !o.GetAttribute("class").Contains("custom-disabled-checkbox")
        && o.GetAttribute("disabled") == null);

        var textboxElements = inputElements.Where(element => element.GetAttribute("type") == "text")
            .Where(o => o.GetAttribute("placeholder") != "Search Code" && o.GetAttribute("name") != "upload" && o.GetAttribute("type") != "file").ToList();
        if (textboxElements.Any())
            TextboxGenerator(textboxElements);

        var emailElements = inputElements.Where(element => element.GetAttribute("type") == "email").ToList();
        if (inputElements.Any())
            EmailGenerator(emailElements);

        var passwordElements = inputElements.Where(element => element.GetAttribute("type") == "password").ToList();
        if (passwordElements.Any())
            PasswordGenerator(passwordElements);

        var datePickerElements = inputElements.Where(element => element.GetAttribute("class").Contains("date-picker"))
            .ToList();
        if (datePickerElements.Any())
            DatePickerGenerator(datePickerElements);

        //    var dropDownListElements =
        //context.FindElements(By.CssSelector("[data-form-item-type='select'][data-section='formItem']"))
        //.Where(o => (o.GetAttribute("data-form-item-required") == "true")).AsQueryable();

        var dropDownListElements =
            context.FindElements(By.CssSelector("[data-form-item-type='select'][data-section='formItem']")).AsQueryable();
        if (dropDownListElements.Count() > 0)
            DropDownListGenerator(dropDownListElements);

        var tellElements = inputElements.Where(element => element.GetAttribute("type") == "tel");
        if (tellElements != null)
            TellGenerator(tellElements.ToList());

        var urlElements = inputElements.Where(element =>
            element.GetAttribute("type") == "url" || element.GetAttribute("name") == "website" || element.GetAttribute("name").Contains("url", StringComparison.OrdinalIgnoreCase)).ToList();
        if (urlElements.Any())
            UrlGenerator(urlElements);

        var textAreaElements = context.FindElements(By.TagName("textarea"));
        if (textAreaElements.Any())
            TextAreaGenerator(textAreaElements);

        var ColorPickerDropDowns =
            webElementAction.GetAllElementBySpecificAttribute("data-form-item-type", "advanceColorPicker", Context);
        if (ColorPickerDropDowns.Any())
            ColorPickerDropDownGenerator(ColorPickerDropDowns);

        var rangeInputElements = inputElements.Where(element => element.GetAttribute("type") == "range").ToList();
        if (rangeInputElements.Any())
            RangeInputGenerator(rangeInputElements);


        var checkboxElements = inputElements.Where(element => element.GetAttribute("type") == "checkbox").ToList();
        if (checkboxElements.Any())
            CheckboxGenerator(checkboxElements);

        if (IsContextGrid)
        {
            var comboAutoCompletesInGrid = webElementAction.GetAllElementsByCssSelector(".icon-medium-font.icon-grid", context);
            if (comboAutoCompletesInGrid.Any())
                ComboAutoCompleteGeneratorInGrid(comboAutoCompletesInGrid);
        }
        else
        {
            var comboAutoCompleteElements = context.FindElements(By.CssSelector(".combo-auto-complete"));
            if (comboAutoCompleteElements.Any())
                ComboAutoCompleteGenerator(comboAutoCompleteElements);
        }
    }


    private void DatePickerGenerator(List<IWebElement> datePickerElements)
    {
        var currentDateAndTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
        var currentDate = DateTime.Now.ToString("MM/dd/yyyy");

        foreach (var element in datePickerElements)
        {
            if (webElementAction.IsElementPresent(By.CssSelector(".date-picker-input-style .customInput_textStyle .date-time-picker-input-style")))
            {

                element.Clear();
                element.SendKeys(currentDateAndTime);
            }
            else
            {
                element.Clear();
                webElementAction.DoubleClick(element);
                element.SendKeys(currentDate);
            }
        }
    }

    public void TextboxGenerator(ICollection<IWebElement> inputElements)
    {
        foreach (var item in inputElements)
        {
            string value = default;
            switch (item.GetAttribute("inputmode"))
            {
                case "numeric":
                case "decimal":
                    {
                        var maxlength = Convert.ToInt32(item.GetAttribute("maxlength"));
                        if (item.GetAttribute("min") != string.Empty && item.GetAttribute("max") != string.Empty)
                        {
                            try
                            {
                                var min = (int)Convert.ToDecimal(item.GetAttribute("min"));

                                // var max = Convert.ToInt32(item.GetAttribute("max"));  //TODO
                                int max = default;
                                try
                                {
                                    max = (int)Convert.ToDecimal(item.GetAttribute("max"));
                                }
                                catch
                                {
                                    max = 999;
                                }

                                if (max > 1000) max = 1000;
                                if (min < -1000) min = -1000;

                                value = RandomValueGenerator.GenerateRandomInt(min, max);
                            }
                            catch
                            {
                                //igrored
                            }
                        }
                        else if (item.GetAttribute("maxlength") != null)
                        {

                            if (maxlength > 3)
                            {
                                maxlength = 3;
                            }
                            value = RandomValueGenerator.GenerateRandomInt(maxlength);
                        }
                        IJavaScriptExecutor js = (IJavaScriptExecutor)ObjectRepository.Driver;
                        js.ExecuteScript("arguments[0].value='';", item);
                        try
                        {
                            item.Clear();
                        }
                        catch
                        {
                            //ignored
                        }
                        item.Click();
                        item.SendKeys(value);
                    }
                    break;

                case "text":
                    {
                        item.Clear();
                        value = RandomValueGenerator.GenerateRandomString(10);
                        item.SendKeys(value);
                    }
                    break;
            }
        }
    }

    public void CheckboxGenerator(ICollection<IWebElement> checkboxElement)
    {
        foreach (var item in checkboxElement)
            try
            {
                Thread.Sleep(100);
                item.Click();
            }
            catch
            {
                break;
            }
    }


    public void EmailGenerator(ICollection<IWebElement> emailElements)
    {
        foreach (var item in emailElements)
        {
            item.Clear();
            var value = RandomValueGenerator.GenerateGmail();
            item.SendKeys(value);
        }
    }

    public void PasswordGenerator(ICollection<IWebElement> passwordElements)
    {
        foreach (var item in passwordElements)
        {
            var maxlength = Convert.ToInt32(item.GetAttribute("maxlength"));
            if (maxlength > 15) maxlength = 15;
            var value = RandomValueGenerator.GenerateRandomString(maxlength);
            IJavaScriptExecutor js = (IJavaScriptExecutor)ObjectRepository.Driver;
            js.ExecuteScript("arguments[0].value='';", item);
            item.SendKeys(value);
        }
    }
    /*



     *  */
    //combo-auto-complete
    public void ComboAutoCompleteGenerator(ICollection<IWebElement> comboAutoCompleteElements, string searchFiter = null)
    {
        foreach (var item in comboAutoCompleteElements)
        {
            var iElements = item.FindElements(By.TagName("i"));
            foreach (var iElement in iElements)
            {
                byte tryToClicklCount = 0;
            strartClick:
                try
                {
                    if (tryToClicklCount == 2) continue;
                    tryToClicklCount++;
                    iElement.Click();
                }
                catch
                {
                    try
                    {
                        IJavaScriptExecutor jsvertical = (IJavaScriptExecutor)ObjectRepository.Driver;
                        jsvertical.ExecuteScript("document.querySelector(`.tab-content[data-tab-active='true']`).scrollTo({top:0,left:0})");
                        goto strartClick;
                    }
                    catch
                    {
                        continue; //Go to the next comboAutoComplete element
                    }
                }

                while (webElementAction.IsElementPresent(By.CssSelector(".loading-parent")))
                {
                    Thread.Sleep(200);
                }

                try
                {
                    if (!webElementAction.IsElementPresent(By.ClassName("rnd-wrapper")))
                        break;

                    var comboAutoCompleteContext = ObjectRepository.Driver.FindElement(By.ClassName("rnd-wrapper"))
                    .FindElement(
                        By.CssSelector(".ag-body-viewport.ag-row-animation.ag-layout-normal"));

                    if (searchFiter != null)
                    {
                        var comboContainer = webElementAction.GetElementByCssSelector(".combo-drag-container");
                        var searchElement = webElementAction.GetElementByCssSelector("[placeholder='Search']", comboContainer);
                        searchElement.SendKeys(searchFiter);
                        Thread.Sleep(1000);
                    }

                    var options = comboAutoCompleteContext.FindElements(By.CssSelector(
                        ".ag-cell.ag-cell-not-inline-editing.ag-cell-normal-height.indicator-column.ag-cell-range-left.ag-cell-value"));

                    Thread.Sleep(500);
                    int randomOptionNumber = default;

                    if (options.Count == 0)
                    {
                        var rndWrapper = webElementAction.GetElementBySpecificAttribute("class", "rnd-wrapper");
                        var closeBtn =
                            webElementAction.GetElementBySpecificAttribute("data-icon-name", "close", rndWrapper);
                        closeBtn.Click();
                    }
                    else if (options.Count < 7)
                    {
                        randomOptionNumber = Convert.ToInt16(RandomValueGenerator.GenerateRandomInt(0, options.Count - 1));
                    }
                    else
                    {
                        randomOptionNumber = Convert.ToInt16(RandomValueGenerator.GenerateRandomInt(0, 7));
                    }
                    var act = new Actions(ObjectRepository.Driver);

                    if (options.Any())
                        act.DoubleClick(options[randomOptionNumber]).Perform();

                    if (webElementAction.IsElementPresent(By.CssSelector("[data-section='confirmDialog']")))
                    {
                        var confirmDialogBox = webElementAction.GetElementBySpecificAttribute("data-section", "confirmDialog");
                        webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", confirmDialogBox).Click();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Exception error:" + e.Message);
                }

            }
        }
    }

    public void DropDownListGeneratorWithFilter(string dataFormaItemName, string filter = null)
    {
        Thread.Sleep(100);
        var dropDownListElement = webElementAction.GetElementByCssSelector("[data-form-item-name='" + dataFormaItemName + "']");
        dropDownListElement.Click();
        Thread.Sleep(200);
        var options =
            ObjectRepository.Driver.FindElements(By.CssSelector(".ant-select-item.ant-select-item-option"));
        webElementAction.GetElementByCssSelector("[title='" + filter + "'] > .ant-select-item-option-content").Click();
    }

    public void DropDownListGenerator(IQueryable<IWebElement> dropDownListElements)
    {
        foreach (var item in dropDownListElements)
        {
        tryToClickOption:
            item.Click();
            var options =
                ObjectRepository.Driver.FindElements(By.CssSelector(".ant-select-item.ant-select-item-option"));
            try
            {
                int index = Convert.ToInt16(RandomValueGenerator.GenerateRandomInt(1, options.Count - 1));
                options[index].Click();
            }
            catch
            {
                goto tryToClickOption;
            }
        }
    }


    public void TellGenerator(ICollection<IWebElement> telElements)
    {
        foreach (var item in telElements)
        {
            var maxlength = Convert.ToInt32(item.GetAttribute("maxlength"));
            var value = "09" + RandomValueGenerator.GenerateRandomInt(maxlength - 2);
            IJavaScriptExecutor js = (IJavaScriptExecutor)ObjectRepository.Driver;
            js.ExecuteScript("arguments[0].value='';", item);
            item.SendKeys(value);
        }
    }


    public void UrlGenerator(ICollection<IWebElement> urlElements)
    {
        foreach (var item in urlElements)
        {
            var value = "https://" + RandomValueGenerator.GenerateRandomString(14) + ".com";
            item.Clear();
            item.SendKeys(value);
        }
    }


    public void TextAreaGenerator(ICollection<IWebElement> textAreaElements)
    {
        foreach (var item in textAreaElements)
        {
            var value = RandomValueGenerator.GenerateTextArea(14);
            IJavaScriptExecutor js = (IJavaScriptExecutor)ObjectRepository.Driver;
            js.ExecuteScript("arguments[0].value='';", item);
            item.SendKeys(value);
        }
    }

    public void ColorPickerDropDownGenerator(ICollection<IWebElement> ColorPickerDropDowns)
    {
        foreach (var item in ColorPickerDropDowns)
        {
            var advanceColorPicker = item.FindElement(By.ClassName("main-color-picker-dropDown_wrapper"));

            advanceColorPicker.Click();

            var colorContext = ObjectRepository.Driver.FindElement(By.ClassName("main-color-picker-popover"));
            var colorList = colorContext.FindElements(By.ClassName("color-item-wrapper"));
            var randomColorIndex = Convert.ToInt32(RandomValueGenerator.GenerateRandomInt(0, colorList.Count - 1));
            colorList[randomColorIndex].Click();
        }
    }


    //combo-auto-complete
    public void ComboAutoCompleteGeneratorInGrid(ICollection<IWebElement> comboAutoCompleteElements, string searchFiter = null)
    {
        foreach (var item in comboAutoCompleteElements)
        {

            byte tryToClicklCount = 0;
        startClick:
            try
            {
                if (tryToClicklCount == 2) continue;
                tryToClicklCount++;
                item.Click();

                //In some scenarios, the rnd-wrapper (auto-combo-grid) window may not be displayed with a single click.
                if (!webElementAction.IsElementPresent(By.ClassName("rnd-wrapper")))
                    item.Click();
            }
            catch
            {
                try
                {
                    IJavaScriptExecutor jsvertical = (IJavaScriptExecutor)ObjectRepository.Driver;
                    jsvertical.ExecuteScript("document.querySelector(`.tab-content[data-tab-active='true']`).scrollTo({top:0,left:0})");
                    goto startClick;
                }
                catch
                {
                    continue; //Go to the next comboAutoComplete element
                }
            }

            while (webElementAction.IsElementPresent(By.CssSelector(".loading-parent")))
            {
                Thread.Sleep(200);
            }
            try
            {
                //Referesh ComboAutoComplete grid
                webElementAction.GetElementByCssSelector(".combo-toolbox-container .icon-refresh").Click();
                WaitForLoadingSpiner();

                var comboAutoCompleteContext = ObjectRepository.Driver.FindElement(By.ClassName("rnd-wrapper"))
                .FindElement(
                    By.CssSelector(".ag-body-viewport.ag-row-animation.ag-layout-normal"));


                if (searchFiter != null)
                {
                    var topActionsComboGrid = webElementAction.GetElementByCssSelector(".top-actions-combo-grid");
                    var searchElement = webElementAction.GetElementByCssSelector("[placeholder='Search']", topActionsComboGrid);
                    searchElement.SendKeys(searchFiter);
                    Thread.Sleep(100);
                }

                var options = comboAutoCompleteContext.FindElements(By.CssSelector(
                    ".ag-cell.ag-cell-not-inline-editing.ag-cell-normal-height.indicator-column.ag-cell-range-left.ag-cell-value"));

                var act = new Actions(ObjectRepository.Driver);
                int randomOption = default;
                if (options.Count > 4)
                {
                    randomOption = Convert.ToInt16(RandomValueGenerator.GenerateRandomInt(0, 4));
                    act.DoubleClick(options[randomOption]).Perform();
                }
                else if (options.Count != 0)
                {
                    act.DoubleClick(options[0]).Perform();
                }
                else if (options.Count == 0)
                {
                    var rndWrapper = webElementAction.GetElementBySpecificAttribute("class", "rnd-wrapper");
                    var closeBtn =
                        webElementAction.GetElementBySpecificAttribute("data-icon-name", "close", rndWrapper);
                    closeBtn.Click();
                }
                if (webElementAction.IsElementPresent(By.CssSelector("[data-section='confirmDialog']")))
                {
                    var confirmDialogBox = webElementAction.GetElementBySpecificAttribute("data-section", "confirmDialog");
                    webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", confirmDialogBox).Click();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception error:" + e.Message);
            }

        }
    }
    private void RangeInputGenerator(List<IWebElement> rangeInputElements)
    {
        foreach (var element in rangeInputElements)
        {
            var currentVal = float.Parse(element.GetAttribute("value"));
            var maxVal = float.Parse(element.GetAttribute("max"));
            var randomSteps = RandomValueGenerator.GenerateRandomInt(Convert.ToInt32(currentVal), Convert.ToInt32(maxVal));

            for (int i = 0; i < float.Parse(randomSteps); i++)
                element.SendKeys(Keys.ArrowRight);
        }
    }
}
