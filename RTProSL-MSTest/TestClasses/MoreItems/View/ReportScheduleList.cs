//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.View
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___View")]
    public class ReportScheduleList : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageReportScheduleList()  // UseReportSchedule=1
        {
            TestInitialize(nameof(OpenPageReportScheduleList));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "ReportScheduleList");

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