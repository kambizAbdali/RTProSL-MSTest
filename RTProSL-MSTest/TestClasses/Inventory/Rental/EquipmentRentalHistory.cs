// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;

//GoToUrl("MMInventory", "EquipmentList");

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class EquipmentRentalHistory : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageEquipmentRentalHistory()
    {
        TestInitialize(nameof(OpenPageEquipmentRentalHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentRentalHistory");
                RefreshAllRows();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }





    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckEquipmentRentalHistory()
    {
        TestInitialize(nameof(ListViewtBtnCheckEquipmentRentalHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentRentalHistory");
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
    public void ArrowFirstBtnCheckEquipmentRentalHistory()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckEquipmentRentalHistory));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentRentalHistory");
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
    public void ArrowLastBtnCheckEquipmentRentalHistory()
    {
        TestInitialize(nameof(ArrowLastBtnCheckEquipmentRentalHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentRentalHistory");
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
    public void ArrowNextBtnCheckEquipmentRentalHistory()
    {
        TestInitialize(nameof(ArrowNextBtnCheckEquipmentRentalHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentRentalHistory");
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
    public void ArrowPreviousBtnCheckEquipmentRentalHistory()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckEquipmentRentalHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentRentalHistory");
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
    public void FilterEquipmentRentalHistoryByFromDateToDate()
    {
        TestInitialize(nameof(FilterEquipmentRentalHistoryByFromDateToDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentRentalHistory");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("FromDate", "EquipmentRentalHistory-gridId");
                filterSearch.FilterSearchInDateTimeDataType("dateIn", "dateOut");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentRentalHistoryByProduction()
    {
        TestInitialize(nameof(FilterEquipmentRentalHistoryByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentRentalHistory");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("productionId", "EquipmentRentalHistory-gridId", "Production");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentRentalByEquipment()
    {
        TestInitialize(nameof(FilterEquipmentRentalByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentRentalHistory");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("equipmentId", "EquipmentRentalHistory-gridId", "Equipment");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentRentalByBarcode()
    {
        TestInitialize(nameof(FilterEquipmentRentalByBarcode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentRentalHistory");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("barcode", "EquipmentRentalHistory-gridId", "Barcode");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentRentalByOrder()
    {
        TestInitialize(nameof(FilterEquipmentRentalByOrder));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentRentalHistory");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("OrderNo", "EquipmentRentalHistory-gridId", "Order#", colId: "orderNo");
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
                GoToUrl("MMInventory", "EquipmentRentalHistory");
                RefreshRecordDataInGrid("EquipmentRentalHistory-gridId", columnId: "equipmentId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}