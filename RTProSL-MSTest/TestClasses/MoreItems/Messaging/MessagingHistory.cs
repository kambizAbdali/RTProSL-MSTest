//develop by Parsa Zakeri
namespace RTProSL_MSTest.TestClasses.MoreItems.Messaging
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Messaging")]
    public class MessagingHistory : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageMessagingHistory()
        {
            TestInitialize(nameof(OpenPageMessagingHistory));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "MessagingHistory");

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
                    GoToUrl("MoreItems", "MessagingHistory");
                    RefreshRecordDataInGrid("MessagingHistory-gridId", columnId: "orderNo");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}