// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.Billing.Create;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Create")]
public class CreateNonOrderInvoice : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCreateNonOrderInvoice()
    {
        TestInitialize(nameof(OpenPageCreateNonOrderInvoice));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "CreateNon-OrderInvoice");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}