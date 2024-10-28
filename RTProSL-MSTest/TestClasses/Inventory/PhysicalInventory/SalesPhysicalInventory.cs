// Developed By Mohammad Keshavarz

using OpenQA.Selenium;
namespace RTProSL_MSTest.TestClasses.Inventory.PhysicalInventory;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Repairs")]
public class SalesPhysicalInventory : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSalesPhysicalInventory()
    {
        TestInitialize(nameof(OpenPageSalesPhysicalInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPhysicalInventory");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}