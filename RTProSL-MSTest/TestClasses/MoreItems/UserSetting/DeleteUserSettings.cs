//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.UserSetting
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___UserSetting")]
    public class DeleteUserSettings : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageDeleteUserSettings()
        {
            TestInitialize(nameof(OpenPageDeleteUserSettings));
            while (!testPassed && retryCount < maxRetries)
                try
                {

                    GoToUrl("MoreItems", "DeleteUserSettings");

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