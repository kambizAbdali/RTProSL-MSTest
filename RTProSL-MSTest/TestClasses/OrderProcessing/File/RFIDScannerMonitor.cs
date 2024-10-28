// Developed By Parsa Zakeri

namespace RTProSL_MSTest.TestClasses.OrderProcessing.File;



[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___File")]
public class RFIDScannerMonitor : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRFIDScannerMonitor()
    {
        TestInitialize(nameof(OpenPageRFIDScannerMonitor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMRFIDScannerMonitor");
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
                GoToUrl("OrderProcessing", "OPMRFIDScannerMonitor");
                RefreshRecordDataInGrid("RFIdScannerMonitor-gridId", columnId: "barcode");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}