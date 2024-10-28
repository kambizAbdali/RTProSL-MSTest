// Developed By Mohammad Keshavarz
namespace RTProSL_MSTest.TestClasses.OrderProcessing.Reports;



[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___Reports")]
public class ProductionReplacementCostSheet : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageProductionReplacementCostSheet()
    {
        TestInitialize(nameof(OpenPageProductionReplacementCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMProductionReplacementCostSheet");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}