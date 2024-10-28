// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class RFIDTagsList : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRFIDTagsList()
    {
        TestInitialize(nameof(OpenPageRFIDTagsList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RFIDTagsList");
                Thread.Sleep(1000);

                RefreshAllRows();

                Thread.Sleep(500);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RFIDTagsList");
                RefreshRecordDataInGrid("RFIDTagsList-gridId", columnId: "tagId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}