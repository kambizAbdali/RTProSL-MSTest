// Developed By Mohammad Keshavarz


using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;



[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class RentalAvailabilityList : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalAvailabilityList()
    {
        TestInitialize(nameof(OpenPageRentalAvailabilityList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalAvailabilityList");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterRentalAvailabilityList()
    {

        TestInitialize(nameof(OpenGridFilterRentalAvailabilityList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalAvailabilityList");
                Thread.Sleep(2000);

                RefreshAllRows();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalAvailabilityListByDepartment()
    {
        TestInitialize(nameof(FilterRentalAvailabilityListByDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalAvailabilityList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("departmentId", "RentalAvailabilityList-gridId", "Department", "department");
                filterSearch.FilterSearchInTextDataType();  
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalAvailabilityListByCategory()
    {
        TestInitialize(nameof(FilterRentalAvailabilityListByCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalAvailabilityList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("categoryId", "RentalAvailabilityList-gridId", "Category" , "category");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalAvailabilityListByEquipment()
    {
        TestInitialize(nameof(FilterRentalAvailabilityListByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalAvailabilityList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("equipmentId", "RentalAvailabilityList-gridId", "Equipment", "equipment");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }   
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalAvailabilityListByDescription()
    {
        TestInitialize(nameof(FilterRentalAvailabilityListByDescription));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalAvailabilityList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("description", "RentalAvailabilityList-gridId", "Description");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalAvailabilityListByShowAvail()
    {
        TestInitialize(nameof(FilterRentalAvailabilityListByShowAvail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalAvailabilityList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("showAvailPct", "RentalAvailabilityList-gridId", colId: "availToday Pct", replacementValue:"%");
                filterSearch.FilterSearchInCheckBoxDataType();
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
                GoToUrl("MMInventory", "RentalAvailabilityList");
                RefreshRecordDataInGrid("RentalAvailabilityList-gridId", columnId: "equipment");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

}