// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class ImportRFIDTags : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageImportRFIDTags()
    {
        TestInitialize(nameof(OpenPageImportRFIDTags));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "ImportRFIDTags");

                Thread.Sleep(500);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}