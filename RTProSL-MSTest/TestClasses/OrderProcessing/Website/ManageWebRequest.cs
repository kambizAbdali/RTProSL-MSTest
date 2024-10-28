// Developed By Mohammad Keshavarz
namespace RTProSL_MSTest.TestClasses.OrderProcessing.Website;

[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___Website")]
public class ManageWebRequest : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageManageWebRequest()
    {
        TestInitialize(nameof(OpenPageManageWebRequest));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMManageWebRequest");
                Thread.Sleep(2000);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterManageWebRequest()
    {

        TestInitialize(nameof(OpenGridFilterManageWebRequest));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMManageWebRequest");
                Thread.Sleep(2000);

                RefreshAllRows();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGridWebRequest()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGridWebRequest));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMManageWebRequest");
                RefreshRecordDataInGrid("ManageWebRequest-gridId", columnId: "orderNo");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGridRental()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGridRental));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMManageWebRequest");
                RefreshRecordDataInGrid("ManageWebRequestRental-gridId", columnId: "main");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}