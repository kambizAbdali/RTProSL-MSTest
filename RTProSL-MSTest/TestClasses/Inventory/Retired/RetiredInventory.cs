// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.Administration.Tables;
using SeleniumWebdriver.Settings;

namespace RTProSL_MSTest.TestClasses.Inventory.Retired;



[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Retired")]
public class RetiredInventory : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRetiredInventory()
    {
        TestInitialize(nameof(OpenPageRetiredInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "RetiredInventory");

                Thread.Sleep(2000);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterRetiredInventory()
    {

        TestInitialize(nameof(OpenGridFilterRetiredInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");
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
    public void CardViewBtnCheckRetiredInventory()
    {
        TestInitialize(nameof(CardViewBtnCheckRetiredInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");
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
    public void ListViewtBtnCheckRetiredInventory()
    {
        TestInitialize(nameof(ListViewtBtnCheckRetiredInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");
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
    public void ArrowFirstBtnCheckRetiredInventory()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckRetiredInventory));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");
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
    public void ArrowLastBtnCheckRetiredInventory()
    {
        TestInitialize(nameof(ArrowLastBtnCheckRetiredInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");
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
    public void ArrowNextBtnCheckRetiredInventory()
    {
        TestInitialize(nameof(ArrowNextBtnCheckRetiredInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");
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
    public void ArrowPreviousBtnCheckRetiredInventory()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckRetiredInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");
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
    public void FilterRetiredInventoryByBeginEndDate()
    {
        TestInitialize(nameof(FilterRetiredInventoryByBeginEndDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("fromDate", "RetiredInventoryList-gridId");
                filterSearch.FilterSearchInDateTimeDataType("retiredDate");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRetiredInventoryByReasonCode()
    {
        TestInitialize(nameof(FilterRetiredInventoryByReasonCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("RetiredReasonId", "RetiredInventoryList-gridId", "Retired Reason",colId: "retiredReasonId");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRetiredInventoryByEquipment()
    {
        TestInitialize(nameof(FilterRetiredInventoryByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("equipmentId", "RetiredInventoryList-gridId", "Equipment");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRetiredInventoryByBarcode()
    {
        TestInitialize(nameof(FilterRetiredInventoryByBarcode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("barcode", "RetiredInventoryList-gridId", "Barcode", colId: "id");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRetiredInventoryBySerial()
    {
        TestInitialize(nameof(FilterRetiredInventoryBySerial));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("serialNo", "RetiredInventoryList-gridId", "Serial#");
                filterSearch.FilterSearchInTextDataInGridDataType();
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
                GoToUrl("MMInventory", "RetiredInventory");
                RefreshRecordDataInGrid("RetiredInventoryList-gridId", columnId: "equipmentId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrintBarcodeLabelsReport()
    {
        TestInitialize(nameof(ValidatePrintBarcodeLabelsReport));
        while (!testPassed && retryCount < maxRetries)
        {
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");
                RefreshAllRows();
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReportSubMenu(menu: "PRINT_TOOL_DROPDOWN", subMenu: "PRINT_BARCODE_LABELS");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
        }
    }
}