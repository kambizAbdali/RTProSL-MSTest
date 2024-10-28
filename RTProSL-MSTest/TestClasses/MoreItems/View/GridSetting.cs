//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.View
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___View")]
    public class GridSetting : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageGridSetting()
        {
            TestInitialize(nameof(OpenPageGridSetting));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "GridSetting");

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
                    GoToUrl("MoreItems", "GridSetting");
                    RefreshRecordDataInGrid("GridSetting-gridId", columnId: "userCode");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}