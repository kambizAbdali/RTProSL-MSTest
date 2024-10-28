// Developed By Mohammad Keshavarz\
namespace RTProSL_MSTest.TestClasses.Billing.Invoice;

[TestCategory("Invoice")]
[TestClass, TestCategory("Invoice___Billing")]
public class InvoiceScreen : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInvoiceScreen()
    {
        TestInitialize(nameof(OpenPageInvoiceScreen));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "InvoiceScreen");

                Thread.Sleep(2000);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}