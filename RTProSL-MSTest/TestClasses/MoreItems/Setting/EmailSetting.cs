//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.Setting
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Setting")]
    public class EmailSetting : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageEmailSetting()
        {
            TestInitialize(nameof(OpenPageEmailSetting));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "EmailSetting");

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