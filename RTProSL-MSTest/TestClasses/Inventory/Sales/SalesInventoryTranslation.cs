// Developed By Parsa Zakeri


using System.Collections.ObjectModel;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.Administration.Tables;
using SeleniumWebdriver.Settings;
using static OpenQA.Selenium.PrintOptions;

namespace RTProSL_MSTest.TestClasses.Inventory.Sales
{
    [TestCategory("Inventory")]
    [TestClass, TestCategory("Inventory___Sales")]
    public class SalesInventoryTranslation : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterSalesInventoryTranslationByStock()
        {
            TestInitialize(nameof(FilterSalesInventoryTranslationByStock));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "SalesInventoryTranslation");

                    //Select all value in grid
                    RefreshAllRows();
                    ShowAllRedord();
                    FilterSearch filterSearch = new FilterSearch("StockNoId", "SalesInventoryTranslation-gridId", colId: "stock");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterSalesInventoryTranslationByLanguage()
        {
            TestInitialize(nameof(FilterSalesInventoryTranslationByLanguage));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "SalesInventoryTranslation");

                    //Select all value in grid
                    RefreshAllRows();
                    ShowAllRedord();
                    FilterSearchSalesInventoryTransactions("languageList", "SalesInventoryTranslation-gridId");
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void FilterSearchSalesInventoryTransactions(string id, string gridId)
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

            //Find value in grid
            var gridLisInput = webElementAction.GetElementById(gridId);
            gridLisInput.FindElements(By.TagName("div"));



            try
            {
                if (gridLisInput.FindElements(By.TagName("div")).Where(o => o.GetAttribute("col-id") == valueInModalFilter) != null)
                    testPassed = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGrid()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "SalesInventoryTransactions");
                    RefreshRecordDataInGrid("SalesInventoryTranslation-gridId", columnId: "stock");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
