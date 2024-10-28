// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.Billing.Create;



[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Create")]
public class BatchInvoice : BaseClass
{
    // go to page Rental agent

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageBatchInvoice()
    {
        TestInitialize(nameof(OpenPageBatchInvoice));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "BatchInvoice");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

}