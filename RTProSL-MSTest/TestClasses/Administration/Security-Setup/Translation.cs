//Develop by ParsaZakeri



using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.TestClasses.AccountsReceivable.AR;
using DataType = RTProSL_MSTest.ComponentHelper.DataType;


namespace RTProSL_MSTest.TestClasses.Administration.Security_Setup
{
    [TestCategory("Administration")]
    [TestClass, TestCategory("Administration___SecuritySetup")]
    public class Translation : BaseClass
    {

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterTranslationByLanguage()
        {
            TestInitialize(nameof(FilterTranslationByLanguage));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "Translation");

                    //Select all value in grid
                    RefreshAllRows();
                    FilterSearchTranslation("languageId", DataType.Text, "TranslationList-gridId",
                        ".dark-semibold-ordinary.ellipsis-content");
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void FilterSearchTranslation(string id, DataType dataType, string gridId, string classLan = default)
        {
            //click on btn filter
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "filter").Click();

            //generate value on input element
            var Context = webElementAction.GetElementBySpecificAttribute("data-form-item-name", id);
            new WebElementDataGenerator(Context);

            //find in value to input
            string valueInModalFilter =
                webElementAction.GetInputElementByDataFormItemNameInDiv(id).GetAttribute("value");

            //Refresh filter in grid
            webElementAction.GetElementById("body-filter-refresh-btn").Click();

            string valueLan = webElementAction.GetElementByCssSelector(classLan).Text;
            if (valueInModalFilter == valueLan)
            {
                testPassed = true;
            }
            else
            {
                throw new Exception("Doesn't match inserted filter value ('" + valueInModalFilter + "') with showed value in Grid ('" + valueLan + "')");
            }

        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRequiredFieldsMessageBoxInTranslation()
        {
            TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInTranslation));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    ValidateRequiredFieldsMessage validateRequiredFields;
                    validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "Administration", subMenu: "Translation", filed: "translated");
                    validateRequiredFields.Run();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGrid()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "Translation");
                    RefreshRecordDataInGrid("TranslationList-gridId", columnId: "id");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
