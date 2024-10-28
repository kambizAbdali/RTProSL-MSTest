//develop by Mohammad_Keshavarz
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.MoreItems.View
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___View")]
    public class RFIDBatch : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageRFIDBatch()
        {
            TestInitialize(nameof(OpenPageRFIDBatch));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "RFIDBatch");

                    Thread.Sleep(1000);

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterRFIDBatchByBatch()
        {
            TestInitialize(nameof(FilterRFIDBatchByBatch));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "RFIDBatch");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("id", "RFIdBatch-gridId", "Batch#");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterRFIDBatchByProject()
        {
            TestInitialize(nameof(FilterRFIDBatchByProject));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "RFIDBatch");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("projectId", "RFIdBatch-gridId", "Project");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterRFIDBatchByAction()
        {
            TestInitialize(nameof(FilterRFIDBatchByAction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "RFIDBatch");

                    RefreshAllRows();
                    string[] fieldsDropDown =
                            {
                        "Checkout" ,"Cancel Checkout" ,"Checkin" ,"Cancel Checkin" , "PI" ,"Cancel PI" , "Staging" , "Cancel Staging" ,"Order Verification" ,"Tag Convert Batch" ,"Tag Insert Batch" ,"View Info Batch"
                    };

                    FilterSearch filterSearch = new FilterSearch("actionId", "RFIdBatch-gridId", "Action");
                    filterSearch.FilterSearchInDropDownDataType(fieldsDropDown);
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterRFIDBatchByBeginEndDate()
        {
            TestInitialize(nameof(FilterRFIDBatchByBeginEndDate));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "RFIDBatch");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("beginDate", "RFIdBatch-gridId");
                    filterSearch.FilterSearchInDateTimeDataType("transactionDate");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterRFIDBatchByParent()
        {
            TestInitialize(nameof(FilterRFIDBatchByParent));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "RFIDBatch");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("parentId", "RFIdBatch-gridId", "Parent");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterRFIDBatchByProduction()
        {
            TestInitialize(nameof(FilterRFIDBatchByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "RFIDBatch");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("productionId", "RFIdBatch-gridId", "Production");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterRFIDBatchByOrder()
        {
            TestInitialize(nameof(FilterRFIDBatchByOrder));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "RFIDBatch");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("orderNo", "RFIdBatch-gridId", "Order# / PI#");
                    filterSearch.FilterSearchInTextDataType();
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
                    GoToUrl("MoreItems", "RFIDBatch");
                    RefreshRecordDataInGrid("RFIdBatch-gridId", columnId: "id");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}