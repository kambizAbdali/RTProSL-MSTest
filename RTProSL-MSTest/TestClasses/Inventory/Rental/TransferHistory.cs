// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;



[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class TransferHistory : BaseClass
{


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageTransferHistory()
    {
        TestInitialize(nameof(OpenPageTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "TransferHistory");
                RefreshAllRows(filterId: "equipmentId");
                Thread.Sleep(500);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckTransferHistory()
    {
        TestInitialize(nameof(CardViewBtnCheckTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "TransferHistory");
                RefreshAllRows(filterId: "equipmentId");
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
    public void ListViewtBtnCheckTransferHistory()
    {
        TestInitialize(nameof(ListViewtBtnCheckTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "TransferHistory");
                RefreshAllRows(filterId: "equipmentId");
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
    public void ArrowFirstBtnCheckTransferHistory()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckTransferHistory));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "TransferHistory");
                RefreshAllRows(filterId: "equipmentId");
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
    public void ArrowLastBtnCheckTransferHistory()
    {
        TestInitialize(nameof(ArrowLastBtnCheckTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "TransferHistory");
                RefreshAllRows(filterId: "equipmentId");
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
    public void ArrowNextBtnCheckTransferHistory()
    {
        TestInitialize(nameof(ArrowNextBtnCheckTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "TransferHistory");
                RefreshAllRows(filterId: "equipmentId");
                ShowAllRedord();
                ConfirmBtnCheck(dataSection: "errorDialog");
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
    public void ArrowPreviousBtnCheckTransferHistory()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "TransferHistory");
                RefreshAllRows(filterId: "equipmentId");
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
    public void FilterTransferHistoryByEquipment()
    {
        TestInitialize(nameof(FilterTransferHistoryByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "TransferHistory");

                RefreshAllRows(filterId: "equipmentId");
                FilterSearch filterSearch = new FilterSearch("equipmentId", "TransferHistoryList-gridId", "Equipment");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterTransferHistoryByOrder()
    {
        TestInitialize(nameof(FilterTransferHistoryByOrder));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "TransferHistory");

                RefreshAllRows(filterId: "equipmentId");
                FilterSearch filterSearch = new FilterSearch("orderNo", "TransferHistoryList-gridId", "Order#");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterTransferHistoryByBarcode()
    {
        TestInitialize(nameof(FilterTransferHistoryByBarcode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "TransferHistory");

                RefreshAllRows(filterId: "equipmentId");
                FilterSearch filterSearch = new FilterSearch("barcode", "TransferHistoryList-gridId" , "Barcode");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterTransferHistoryByBeginDateINOUT()
    {
        TestInitialize(nameof(FilterTransferHistoryByBeginDateINOUT));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "TransferHistory");

                RefreshAllRows(filterId: "equipmentId");
                FilterSearch filterSearch = new FilterSearch("beginDate", "TransferHistoryList-gridId");
                filterSearch.FilterSearchInDateTimeDataType("dateIn", "dateOut");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}