// Developed By Kambiz Abdali
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;

namespace RTProSL_MSTest.TestClasses.OrderProcessing.Order
{
    [TestCategory("OrderProcessing")]
    [TestClass, TestCategory("OrderProcessing___Order")]
    public class NewOrder : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenNewOrderPage()
        {
            TestInitialize(nameof(OpenNewOrderPage));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "AddNewOrder");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}