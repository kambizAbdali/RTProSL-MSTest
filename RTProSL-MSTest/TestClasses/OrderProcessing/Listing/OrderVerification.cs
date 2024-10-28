// developed By Parsa Zakeri

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using System.ComponentModel;

namespace RTProSL_MSTest.TestClasses.OrderProcessing.Listing
{
    [TestCategory("OrderProcessing")]
    [TestClass, TestCategory("OrderProcessing___Listing")]
    public class OrderVerification : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterOrderVerificationByOrder()
        {
            TestInitialize(nameof(FilterOrderVerificationByOrder));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OPMOrderVerification");

                    //Select all value in grid
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("orderNo", "OrderVerification-gridId", "Order#", "orders");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterOrderVerificationByVerification()
        {
            TestInitialize(nameof(FilterOrderVerificationByVerification));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OPMOrderVerification");

                    //Select all value in grid
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("verificationNo", "OrderVerification-gridId");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterOrderVerificationByDescription()
        {
            TestInitialize(nameof(FilterOrderVerificationByDescription));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OPMOrderVerification");

                    //Select all value in grid
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("description", "OrderVerification-gridId");
                    filterSearch.FilterSearchInTextDataInGridDataType();
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
                    GoToUrl("OrderProcessing", "OPMOrderVerification");
                    RefreshRecordDataInGrid("OrderVerification-gridId", columnId: "verificationNo");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
