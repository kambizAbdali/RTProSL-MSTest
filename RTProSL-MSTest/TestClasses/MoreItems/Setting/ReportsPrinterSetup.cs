//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.Setting
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Setting")]
    public class ReportsPrinterSetup : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageReportsPrinterSetup()
        {
            TestInitialize(nameof(OpenPageReportsPrinterSetup));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "ReportsPrinterSetup");

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