//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.View
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___View")]
    public class AboutRentalTrackerPro : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageAboutRentalTrackerPro()
        {
            TestInitialize(nameof(OpenPageAboutRentalTrackerPro));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "AboutRentalTrackerPro");

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