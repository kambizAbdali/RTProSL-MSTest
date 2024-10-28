// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.Billing.Create;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Create")]
public class ConfirmDrafts : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageConfirmDrafts()
    {
        TestInitialize(nameof(OpenPageConfirmDrafts));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "ConfirmDrafts");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}