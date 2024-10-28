// Developed By Mohammad Keshavarz

using NLog.Filters;
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class ViewBarcodedSubrentalHistory : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageViewBarcodedSubrentalHistory()
    {
        TestInitialize(nameof(OpenPageViewBarcodedSubrentalHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "ViewBarcodedSubrentalHistory");

                RefreshAllRows();
                Thread.Sleep(500);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckViewBarcodedSubrentalHistory()
    {
        TestInitialize(nameof(CardViewBtnCheckViewBarcodedSubrentalHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "ViewBarcodedSubrentalHistory");
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
    public void ListViewtBtnCheckViewBarcodedSubrentalHistory()
    {
        TestInitialize(nameof(ListViewtBtnCheckViewBarcodedSubrentalHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "ViewBarcodedSubrentalHistory");
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
    public void ArrowFirstBtnCheckViewBarcodedSubrentalHistory()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckViewBarcodedSubrentalHistory));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "ViewBarcodedSubrentalHistory");
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
    public void ArrowLastBtnCheckViewBarcodedSubrentalHistory()
    {
        TestInitialize(nameof(ArrowLastBtnCheckViewBarcodedSubrentalHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "ViewBarcodedSubrentalHistory");
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
    public void ArrowNextBtnCheckViewBarcodedSubrentalHistory()
    {
        TestInitialize(nameof(ArrowNextBtnCheckViewBarcodedSubrentalHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "ViewBarcodedSubrentalHistory");
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
    public void ArrowPreviousBtnCheckViewBarcodedSubrentalHistory()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckViewBarcodedSubrentalHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "ViewBarcodedSubrentalHistory");
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
    public void FilterBarcodedSubrentalByBarCode()
    {
        TestInitialize(nameof(FilterBarcodedSubrentalByBarCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "ViewBarcodedSubrentalHistory");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("barcode", "BarCodedSubRentalHistoryList-gridId", "Barcode");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterBarcodedSubrentalByEquipment()
    {
        TestInitialize(nameof(FilterBarcodedSubrentalByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "ViewBarcodedSubrentalHistory");

                RefreshAllRows(filterId: "equipmentId");
                FilterSearch filterSearch = new FilterSearch("equipmentId", "BarCodedSubRentalHistoryList-gridId", "Equipment");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    //fromDateOut
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterBarcodedSubrentalByFromDateToDate()
    {
        TestInitialize(nameof(FilterBarcodedSubrentalByFromDateToDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "ViewBarcodedSubrentalHistory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("fromDateOut", "BarCodedSubRentalHistoryList-gridId");
                filterSearch.FilterSearchInDateTimeDataType("dateIn", "dateOut");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterBarcodedSubrentalByVendor()
    {
        TestInitialize(nameof(FilterBarcodedSubrentalByVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "ViewBarcodedSubrentalHistory");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("vendorId", "BarCodedSubRentalHistoryList-gridId", "Vendor");
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
                GoToUrl("MMInventory", "ViewBarcodedSubrentalHistory");
                RefreshRecordDataInGrid("BarCodedSubRentalHistoryList-gridId", columnId: "equipmentId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}