//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.Messaging
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Messaging")]
    public class SystemMessageRoleList : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageSystemMessageRoleList()
        {
            TestInitialize(nameof(OpenPageSystemMessageRoleList));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "SystemMessageRoleList");

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
                    GoToUrl("MoreItems", "SystemMessageRoleList");
                    RefreshRecordDataInGrid("SystemMessageRoleList-gridId", columnId: "id");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}