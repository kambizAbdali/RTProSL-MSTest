// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class RentalInventoryEntryScreen : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInventoryEntryScreen()
    {
        TestInitialize(nameof(OpenPageInventoryEntryScreen));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventoryEntryScreen");
                Thread.Sleep(500);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}