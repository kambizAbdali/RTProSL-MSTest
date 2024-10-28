// Developed By Kambiz Abdali
namespace RTProSL_MSTest.TestClasses.OrderProcessing.Order
{
    [TestCategory("OrderProcessing")]
    [TestClass, TestCategory("OrderProcessing___Order")]
    public class AfterHoursCheckout : BaseClass
    {

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenAfterHoursCheckoutPage()
        {
            TestInitialize(nameof(OpenAfterHoursCheckoutPage));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "AfterHoursCheckout");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}