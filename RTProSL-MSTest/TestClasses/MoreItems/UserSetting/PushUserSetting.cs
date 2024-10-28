//develop by Parsa Zakeri

namespace RTProSL_MSTest.TestClasses.MoreItems.UserSetting;

[TestCategory("MoreItems")]
[TestClass, TestCategory("MoreItems___UserSetting")]
public class PushUserSetting : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageDeleteUserSettings()
    {
        TestInitialize(nameof(OpenPageDeleteUserSettings));
        while (!testPassed && retryCount < maxRetries)
            try
            {

                GoToUrl("MoreItems", "PushUserSettings");

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
                GoToUrl("MoreItems", "PushUserSettings");
                RefreshRecordDataInGrid("PushUserSettings-gridId", columnId: "pageName");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}

