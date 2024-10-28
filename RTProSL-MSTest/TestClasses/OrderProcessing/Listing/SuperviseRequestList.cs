// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.OrderProcessing.Listing;


[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___Listing")]
public class SuperviseRequestList : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSuperviseRequestList()
    {
        TestInitialize(nameof(OpenPageSuperviseRequestList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "SuperviseRequestList");
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
                GoToUrl("OrderProcessing", "SuperviseRequestList");
                RefreshRecordDataInGrid("SuperviseRequestList-gridId", columnId: "recNo");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}