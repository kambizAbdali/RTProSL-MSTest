//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.View
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___View")]
    public class UsersCurrentlyinRTPro : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageUsersCurrentlyinRTPro()
        {
            TestInitialize(nameof(OpenPageUsersCurrentlyinRTPro));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "UsersCurrentlyinRTPro");

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
                    GoToUrl("MoreItems", "UsersCurrentlyinRTPro");
                    RefreshRecordDataInGrid("UsersCurrentlyInRTPro-gridId", columnId: "ag-Grid-AutoColumn");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}