//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.Upload
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Upload")]
    public class UploadSubrentalPOInvoices : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageUploadSubrentalPOInvoices()
        {
            TestInitialize(nameof(OpenPageUploadSubrentalPOInvoices));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "UploadSubrentalPOInvoices");

                    Thread.Sleep(1000);

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
                    GoToUrl("MoreItems", "UploadSubrentalPOInvoices");
                    RefreshRecordDataInGrid("UploadSubrentalPoInvoices-gridId", columnId: "uploadBatchInclude");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}