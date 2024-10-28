//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.Setting
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Setting")]
    public class CustomizeFormat : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageCustomizeFormat()
        {
            TestInitialize(nameof(OpenPageCustomizeFormat));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "CustomizeFormat");

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