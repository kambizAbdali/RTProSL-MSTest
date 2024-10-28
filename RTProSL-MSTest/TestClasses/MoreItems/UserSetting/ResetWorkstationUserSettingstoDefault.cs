//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.UserSetting
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___UserSetting")]
    public class ResetWorkstationUserSettingstoDefault : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageResetWorkstationUserSettingstoDefault()
        {
            TestInitialize(nameof(OpenPageResetWorkstationUserSettingstoDefault));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "ResetWorkstationUserSettingstoDefault");

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