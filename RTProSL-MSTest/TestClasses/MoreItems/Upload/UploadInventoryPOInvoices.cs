//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.Upload
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Upload")]
    public class UploadInventoryPOInvoices : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageUploadInventoryPOInvoices()
        {
            TestInitialize(nameof(OpenPageUploadInventoryPOInvoices));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "UploadInventoryPOInvoices");

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
                    GoToUrl("MoreItems", "UploadInventoryPOInvoices");
                    RefreshRecordDataInGrid("UploadInventoryPoInvoices-gridId", columnId: "uploadBatchInclude");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}