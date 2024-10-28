// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.OrderProcessing.File;

[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___File")]
public class RentalAvailabilityCalendar : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalAvailabilityCalendar()
    {
        TestInitialize(nameof(OpenPageRentalAvailabilityCalendar));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMRentalAvailabilityCalendar");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

}