//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.Setting
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Setting")]
    public class CameraSetting : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageCameraSetting()
        {
            TestInitialize(nameof(OpenPageCameraSetting));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "CameraSetting");

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