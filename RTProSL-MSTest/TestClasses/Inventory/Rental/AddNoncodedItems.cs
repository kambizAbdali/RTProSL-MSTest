// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper;
namespace RTProSL_MSTest.TestClasses.Inventory.Rental;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class AddNoncodedItems : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageAddNoncodedItems()
    {
        TestInitialize(nameof(OpenPageAddNoncodedItems));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "AddNoncodedItems");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DataEnteryinAddNoncodedItems()
    {
        TestInitialize(nameof(DataEnteryinAddNoncodedItems));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "AddNoncodedItems");
                Thread.Sleep(2000);

                var context = GetFormLeftSideContext();

                new WebElementDataGenerator(context);
                Thread.Sleep(1000);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}