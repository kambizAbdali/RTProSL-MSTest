//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.View
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___View")]
    public class OnlineSignature : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageOnlineSignaturet()
        {
            TestInitialize(nameof(OpenPageOnlineSignaturet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "OnlineSignature");

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