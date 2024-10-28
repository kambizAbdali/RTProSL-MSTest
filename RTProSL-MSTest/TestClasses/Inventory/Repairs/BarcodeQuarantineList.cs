// Developed By Mohammad Keshavarz
// Help:The prerequisite for running tests in this submenu is to check the "Allow Multiple Reservation on Barcode" box in the system-setup.

namespace RTProSL_MSTest.TestClasses.Inventory.Repairs;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Repairs")]
public class BarcodeQuarantineList : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageBarcodeQuarantineList()
    {
        TestInitialize(nameof(OpenPageBarcodeQuarantineList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "BarcodeQuarantineList");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterBarcodeQuarantineList()
    {
        TestInitialize(nameof(OpenGridFilterBarcodeQuarantineList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "BarcodeQuarantineList");
                RefreshAllRows();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }

    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckBarcodeQuarantineList()
    {
        TestInitialize(nameof(CardViewBtnCheckBarcodeQuarantineList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "BarcodeQuarantineList");
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
    public void ListViewtBtnCheckBarcodeQuarantineList()
    {
        TestInitialize(nameof(ListViewtBtnCheckBarcodeQuarantineList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "BarcodeQuarantineList");
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
    public void ArrowFirstBtnCheckBarcodeQuarantineList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckBarcodeQuarantineList));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "BarcodeQuarantineList");
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
    public void ArrowLastBtnCheckBarcodeQuarantineList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckBarcodeQuarantineList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "BarcodeQuarantineList");
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
    public void ArrowNextBtnCheckBarcodeQuarantineList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckBarcodeQuarantineList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "BarcodeQuarantineList");
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
    public void ArrowPreviousBtnCheckBarcodeQuarantineList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckBarcodeQuarantineList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "BarcodeQuarantineList");
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
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "BarcodeQuarantineList");
                RefreshRecordDataInGrid("BarcodeQuarantineList-gridId", columnId: "barcode");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}