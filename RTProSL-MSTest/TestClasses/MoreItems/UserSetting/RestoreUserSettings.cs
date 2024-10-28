//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.UserSetting
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___UserSetting")]
    public class RestoreUserSettings : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageRestoreUserSettings()
        {
            TestInitialize(nameof(OpenPageRestoreUserSettings));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "RestoreUserSettings");

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