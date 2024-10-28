//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.Upload
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Upload")]
    public class UploadARPayments : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageUploadARPayments()
        {
            TestInitialize(nameof(OpenPageUploadARPayments));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "UploadARPayments");

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
                    GoToUrl("MoreItems", "UploadARPayments");
                    RefreshRecordDataInGrid("UploadARPayments-gridId", columnId: "uploadBatchInclude");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}