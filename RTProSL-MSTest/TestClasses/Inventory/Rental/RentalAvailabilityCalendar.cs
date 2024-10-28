// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;



[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class RentalAvailabilityCalendar : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalAvailabilityCalendar()
    {
        TestInitialize(nameof(OpenPageRentalAvailabilityCalendar));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalAvailabilityCalendar");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}

