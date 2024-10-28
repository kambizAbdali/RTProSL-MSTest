// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.Inventory.Sales;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Sales")]
public class AddSalesItems : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageAddSalesStockItems()
    {
        TestInitialize(nameof(OpenPageAddSalesStockItems));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "AddSalesStockItems");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}