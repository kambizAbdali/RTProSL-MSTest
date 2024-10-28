//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.Messaging
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Messaging")]
    public class SystemMessageSetup : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageSystemMessageSetup()
        {
            TestInitialize(nameof(OpenPageSystemMessageSetup));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "SystemMessageSetup");

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