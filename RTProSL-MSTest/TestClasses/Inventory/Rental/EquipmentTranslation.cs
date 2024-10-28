// develop by Kambiz Abdali

using RTProSL_MSTest.ComponentHelper;
namespace RTProSL_MSTest.TestClasses.Inventory.Rental;


[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class EquipmentTranslation : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInEquipmentTranslation()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInEquipmentTranslation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentTranslation");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInEquipmentTranslation()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInEquipmentTranslation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentTranslation");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInEquipmentTranslation()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInEquipmentTranslation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentTranslation");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInEquipmentTranslation()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInEquipmentTranslation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentTranslation");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentTranslationByDepartment()
    {
        TestInitialize(nameof(FilterEquipmentTranslationByDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentTranslation");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("departmentId", "EquipmentTranslation-gridId");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentTranslationByCategory()
    {
        TestInitialize(nameof(FilterEquipmentTranslationByCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentTranslation");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("categoryId", "EquipmentTranslation-gridId");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentTranslationByEquipment()
    {
        TestInitialize(nameof(FilterEquipmentTranslationByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentTranslation");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("equipmentId", "EquipmentTranslation-gridId");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentTranslationByLanguage()
    {
        TestInitialize(nameof(FilterEquipmentTranslationByLanguage));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentTranslation");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("languageId", "EquipmentTranslation-gridId");
                filterSearch.FilterSearchInTextDataType();
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
                GoToUrl("MMInventory", "EquipmentTranslation");
                RefreshRecordDataInGrid("EquipmentTranslation-gridId", columnId: "equipment");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}