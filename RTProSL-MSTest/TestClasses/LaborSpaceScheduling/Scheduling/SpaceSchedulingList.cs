//develop by Parsa Zakeri

namespace RTProSL_MSTest.TestClasses.LaborSpaceScheduling.Scheduling;

[TestCategory("LaborSpaceScheduling")]
[TestClass, TestCategory("LaborSpaceScheduling___Scheduling")]
public class SpaceSchedulingList : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenSpaceSchedulingList()
    {
        TestInitialize(nameof(OpenSpaceSchedulingList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling" , "LBLaborSpaceScheduling");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGridLabor()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGridLabor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LBLaborSpaceScheduling");
                RefreshRecordDataInGrid("LaborSchedulingList-gridId", columnId: "resourceId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGridSpace()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGridSpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LBLaborSpaceScheduling");
                RefreshRecordDataInGrid("spaceSchedulingList-gridId", columnId: "resourceId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}

