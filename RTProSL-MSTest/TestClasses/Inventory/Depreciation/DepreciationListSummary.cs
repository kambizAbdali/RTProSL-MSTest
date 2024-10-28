using RTProSL_MSTest.DataLayer;

namespace RTProSL_MSTest.TestClasses.Inventory.Depreciation
{
    [TestClass]
    public class DepreciationListSummary : BaseClass
    {
        //There is no such content on many pages.
        //TODO: It should be checked with the manual testing team
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageDepreciationListSummary()
        {
            TestInitialize(nameof(OpenPageDepreciationListSummary));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    Login();
                    //await UpdateSetup.SetUseDeprec("1");
                    GoToUrl("MMInventory", "DepreciationListSummary", gotoLogin:false);
                    Thread.Sleep(1000);
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
                    GoToUrl("MMInventory", "DepreciationListSummary");
                    RefreshRecordDataInGrid("DepreciationListSummary-gridId", columnId: "equipment");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}