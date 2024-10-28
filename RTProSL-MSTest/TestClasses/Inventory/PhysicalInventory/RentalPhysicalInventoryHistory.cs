// Developed By Mohammad Keshavarz
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Inventory.PhysicalInventory;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Repairs")]
public class RentalPhysicalInventoryHistory : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalPhysicalInventoryHistory()
    {
        TestInitialize(nameof(OpenPageRentalPhysicalInventoryHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPIHistory");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterRentalPhysicalInventoryHistory()
    {

        TestInitialize(nameof(OpenGridFilterRentalPhysicalInventoryHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPIHistory");
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
    public void CardViewBtnCheckRentalPhysicalInventoryHistory()
    {
        TestInitialize(nameof(CardViewBtnCheckRentalPhysicalInventoryHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "RentalPIHistory");
                RefreshAllRows();
                ShowAllRedord();
                //call method card viewBtn
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckRentalPhysicalInventoryHistory()
    {
        TestInitialize(nameof(ListViewtBtnCheckRentalPhysicalInventoryHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "RentalPIHistory");
                RefreshAllRows();
                ShowAllRedord();
                //call list view btn 
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckRentalPhysicalInventoryHistory()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckRentalPhysicalInventoryHistory));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to pageViewBarcodedSubrentalHistory
                GoToUrl("MMInventory", "RentalPIHistory");
                RefreshAllRows();
                ShowAllRedord();
                //call method arrowFirstBtn
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckRentalPhysicalInventoryHistory()
    {
        TestInitialize(nameof(ArrowLastBtnCheckRentalPhysicalInventoryHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "RentalPIHistory");
                RefreshAllRows();
                ShowAllRedord();
                Thread.Sleep(1000);
                //call method arrowlastbtn
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckRentalPhysicalInventoryHistory()
    {
        TestInitialize(nameof(ArrowNextBtnCheckRentalPhysicalInventoryHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "RentalPIHistory");
                RefreshAllRows();
                ShowAllRedord();
                // call method NextBtn
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckRentalPhysicalInventoryHistory()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckRentalPhysicalInventoryHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "RentalPIHistory");
                RefreshAllRows();
                ShowAllRedord();
                //call arrow previous
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalPhysicalInventoryHistoryByBeginEndDate()
    {
        TestInitialize(nameof(FilterRentalPhysicalInventoryHistoryByBeginEndDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPIHistory");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("beginDate", "RentalPhysicalInventoryHistory-gridId");
                filterSearch.FilterSearchInDateTimeDataType("startDate", "stopDate");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalPhysicalInventoryHistoryByPIGroup()
    {
        TestInitialize(nameof(FilterRentalPhysicalInventoryHistoryByPIGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPIHistory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("PIEquipmentGroupId", "RentalPhysicalInventoryHistory-gridId", "PI Group", "piEquipmentGroup");
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
                GoToUrl("MMInventory", "RentalPIHistory");
                RefreshRecordDataInGrid("RentalPhysicalInventoryHistory-gridId", columnId: "piNo");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}