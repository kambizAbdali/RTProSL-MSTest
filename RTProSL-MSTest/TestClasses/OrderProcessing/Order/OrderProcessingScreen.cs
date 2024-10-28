// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.OrderProcessing.Order;

[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___Order")]
public class OrderProcessingScreen : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageEnterNewOrder()
    {
        TestInitialize(nameof(OpenPageEnterNewOrder));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OrderProcessingScreen");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}