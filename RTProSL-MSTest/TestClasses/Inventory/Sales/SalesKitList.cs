// Developed By Parsa Zakeri


using System.Collections.ObjectModel;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.Administration.Tables;
using SeleniumWebdriver.Settings;
using static OpenQA.Selenium.PrintOptions;

namespace RTProSL_MSTest.TestClasses.Inventory.Sales
{
    [TestCategory("Inventory")]
    [TestClass, TestCategory("Inventory___Sales")]
    public class SalesKitList : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterSalesKitListByDepartment()
        {
            TestInitialize(nameof(FilterSalesKitListByDepartment));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "SalesKitList");

                    //Select all value in grid
                    RefreshAllRows();
                    ShowAllRedord();
                    FilterSearch filterSearch = new FilterSearch("departmentId", "SalesKitList-gridId");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRequiredFieldsMessageBoxInSalesKitList()
        {
            TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSalesKitList));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    ValidateRequiredFieldsMessage validateRequiredFields;
                    validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "MMInventory", subMenu: "SalesKitList", filed: "description");
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
                    GoToUrl("MMInventory", "SalesKitList");
                    RefreshRecordDataInGrid("SalesKitList-gridId", columnId: "id");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
