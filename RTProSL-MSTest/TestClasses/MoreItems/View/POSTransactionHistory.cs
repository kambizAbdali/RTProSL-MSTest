//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.View
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___View")]
    public class POSTransactionHistory : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPagePOSTransactionHistory()
        {
            TestInitialize(nameof(OpenPagePOSTransactionHistory));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "POSTransactionHistory");

                    Thread.Sleep(1000);

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}