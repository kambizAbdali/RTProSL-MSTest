// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.OrderProcessing.Reports;

[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___Reports")]
public class GanttChartforEquipmentAvailability : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageGanttChartforEquipmentAvailability()
    {
        TestInitialize(nameof(OpenPageGanttChartforEquipmentAvailability));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMGanttChartforEquipmentAvailability");
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