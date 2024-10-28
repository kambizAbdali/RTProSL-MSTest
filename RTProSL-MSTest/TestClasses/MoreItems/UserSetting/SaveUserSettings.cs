//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.UserSetting
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___UserSetting")]
    public class SaveUserSettings : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageSaveUserSettings()
        {
            TestInitialize(nameof(OpenPageSaveUserSettings));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "SaveUserSettings");

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