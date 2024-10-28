// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.OrderProcessing.File;

[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___File")]
public class CheckinbyEquipment : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCheckinbyEquipment()
    {
        TestInitialize(nameof(OpenPageCheckinbyEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMCheckinbyEquipment");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterCheckinbyEquipmentByEquipment()
    {
        TestInitialize(nameof(FilterCheckinbyEquipmentByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMCheckinbyEquipment");

                //Select all value in grid
                FilterSearch filterSearch = new FilterSearch("equipmentList", "checkinByEquipment-gridId", colId: "equipment");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                retryCount++;
                if (hasDialogBox && hasError) break;
                if (retryCount == maxRetries) throw new Exception("Test failed: " + ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMCheckinbyEquipment");
                RefreshRecordDataInGrid("checkinByEquipment-gridId", columnId: "orderNo");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}