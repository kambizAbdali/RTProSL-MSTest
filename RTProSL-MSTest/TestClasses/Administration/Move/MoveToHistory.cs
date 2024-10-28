//Develop by ParsaZakeri

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Administration.Move
{
    [TestCategory("Administration")]
    [TestClass, TestCategory("Administration___Move")]
    public class MoveToHistory : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterMoveToHistoryByLastActivityProduction()
        {
            TestInitialize(nameof(FilterMoveToHistoryByLastActivityProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");

                    webElementAction.GetElementByCssSelector("li:nth-of-type(1) > .d-flex").Click();
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("AsOfDate", "MoveToHistoryProduction-gridId", colId: "lastActivity");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterMoveToHistoryByCreationDateOrder()
        {
            TestInitialize(nameof(FilterMoveToHistoryByCreationDateOrder));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");

                    webElementAction.GetElementByCssSelector("li:nth-of-type(2) .ellipsis-content").Click();
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("AsOfDate", "MoveToHistoryOrder-gridId" ,colId: "lastCheckinDate");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterMoveToHistoryByCreationDateInvoice()
        {
            TestInitialize(nameof(FilterMoveToHistoryByCreationDateInvoice));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");

                    webElementAction.GetElementByCssSelector("li:nth-of-type(3) > .d-flex").Click();
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("AsOfDate", "MoveToHistoryInvoice-gridId", colId: "creationDate");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterMoveToHistoryByCreationDateRepair()
        {
            TestInitialize(nameof(FilterMoveToHistoryByCreationDateRepair));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");

                    webElementAction.GetElementByCssSelector("li:nth-of-type(4) > .d-flex").Click();
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("AsOfDate", "MoveToHistoryRepair-gridId" ,  colId: "creationDate");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterMoveToHistoryByCreationAR()
        {
            TestInitialize(nameof(FilterMoveToHistoryByCreationAR));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");

                    webElementAction.GetElementByCssSelector("li:nth-of-type(5) .ellipsis-container").Click();
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("AsOfDate", "MoveToHistoryAR-gridId", colId: "date");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterMoveToHistoryByCreationDateInventoryPO()
        {
            TestInitialize(nameof(FilterMoveToHistoryByCreationDateInventoryPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");

                    webElementAction.GetElementByCssSelector("li:nth-of-type(6) .ellipsis-container").Click();
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("AsOfDate", "MoveToHistoryInventoryPo-gridId", colId: "date");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterMoveToHistoryByCreationDateSubrentalPO()
        {
            TestInitialize(nameof(FilterMoveToHistoryByCreationDateSubrentalPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");

                    webElementAction.GetElementByCssSelector("li:nth-of-type(7) > .d-flex").Click();
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("AsOfDate", "MoveToHistorySubrentalPo-gridId", colId: "poDate");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGridProduction()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGridProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");
                    webElementAction.GetElementByCssSelector("li:nth-of-type(1) > .d-flex").Click();
                    RefreshRecordDataInGrid("MoveToHistoryProduction-gridId", columnId: "productionStatus");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGridOrder()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGridOrder));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");
                    webElementAction.GetElementByCssSelector("li:nth-of-type(2) .ellipsis-content").Click();
                    RefreshRecordDataInGrid("MoveToHistoryOrder-gridId", columnId: "orderNo");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGridInvoice()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGridInvoice));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");
                    webElementAction.GetElementByCssSelector("li:nth-of-type(3) > .d-flex").Click();
                    RefreshRecordDataInGrid("MoveToHistoryInvoice-gridId", columnId: "invoice");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGridRepair()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGridRepair));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");
                    webElementAction.GetElementByCssSelector("li:nth-of-type(4) > .d-flex").Click();
                    RefreshRecordDataInGrid("MoveToHistoryRepair-gridId", columnId: "ticketNo");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGridAR()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGridAR));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");
                    webElementAction.GetElementByCssSelector("li:nth-of-type(5) .ellipsis-container").Click();
                    RefreshRecordDataInGrid("MoveToHistoryAR-gridId", columnId: "paymentNo");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGridInventoryPo()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGridInventoryPo));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");
                    webElementAction.GetElementByCssSelector("li:nth-of-type(6) .ellipsis-container").Click();
                    RefreshRecordDataInGrid("MoveToHistoryInventoryPo-gridId", columnId: "po");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGridSubrentalPo()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGridSubrentalPo));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "MoveToHistory");
                    webElementAction.GetElementByCssSelector("li:nth-of-type(7) > .d-flex").Click();
                    RefreshRecordDataInGrid("MoveToHistorySubrentalPo-gridId", columnId: "po");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
