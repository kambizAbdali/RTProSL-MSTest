using RTProSL_MSTest.TestClasses;
using OpenQA.Selenium;

namespace RTProSL_MSTest.ComponentHelper.ErrorMessageValidating
{
    public class ValidateRequiredFieldsMessage : BaseClass
    {
        private string Menu { get; set; }
        private string SubMenu { get; set; }
        private byte Steps { get; set; }
        private string Filed { get; set; }
        private string ClearDataFormItemName { get; set; }
        private string MessageBoxText = "You must either fill in the required fields";
        public ValidateRequiredFieldsMessage(string menu, string subMenu, string filed, byte steps = 1, string clearDataFormItemName = null)
        {
            Menu = menu;
            SubMenu = subMenu;
            Filed = filed;
            Steps = steps;
            ClearDataFormItemName = clearDataFormItemName;
        }

        public void Run()
        {
            GoToUrl(Menu, SubMenu);

            ClickAddNewRecord();

            if (Steps == 2)
                GenerateDataToMainDialogBox();

            FillFiled();

            if (!string.IsNullOrEmpty(ClearDataFormItemName))
                ClearInput();

            NavigateToHomePage();

            ValidateMessageBoxForRequiredFields();
        }

        private void FillFiled()
        {
            var filedElement = webElementAction.GetAllElementBySpecificAttribute("data-form-item-name", Filed).Last();
            new WebElementDataGenerator(filedElement);
        }

        private void ValidateMessageBoxForRequiredFields()
        {
            var errorMessageBox = webElementAction.GetAllElementsByTagName("div")
                 .FirstOrDefault(element => element.GetAttribute("innerText").Contains(MessageBoxText));

            if (errorMessageBox == null)
                throw new Exception("Error: The message box for required fields validation did not display");
        }

        private void GenerateDataToMainDialogBox()
        {
            var context = webElementAction.GetElementBySpecificAttribute("data-section", "modal");
            while (true)
            {
                var contexInput = webElementAction.GetElementBySpecificAttribute("data-section", "modal").FindElements(By.TagName("input")).ToList();
                new WebElementDataGenerator(context);
                for (int i = 1; i < contexInput.Count; i++)
                    if (contexInput[i].GetAttribute("value") != null)
                        ConfirmBtnCheck(dataSection: "modal");
                if (!webElementAction.IsElementPresent(By.CssSelector("[data-icon-name = 'error']"))) break;
            }
        }
        private void ClickAddNewRecord()
        {
            var addBtn = webElementAction.GetElementBySpecificAttribute("id", "contents-container")
                .FindElements(By.TagName("button"))
                .FirstOrDefault(o => o.GetAttribute("Id").Contains("ADD_BUTTON"));

            if (addBtn != null)
                addBtn.Click();
        }
        public void ClearInput()
        {
            var input = webElementAction.GetInputElementByDataFormItemNameInDiv(ClearDataFormItemName);
            input.Clear();
        }
    }
}