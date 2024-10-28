// Developed By Mohammad Keshavarz
namespace RTProSL_MSTest.TestClasses.OrderProcessing.Reports;

[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___Reports")]
public class GanttChartforOpenOrders : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageGanttChartforOpenOrders()
    {
        TestInitialize(nameof(OpenPageGanttChartforOpenOrders));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMGanttChartforOpenOrders");
                Thread.Sleep(2000);

                RefreshAllRows();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}