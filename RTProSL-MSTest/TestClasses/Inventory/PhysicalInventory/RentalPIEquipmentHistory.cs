// Developed By Mohammad Keshavarz
namespace RTProSL_MSTest.TestClasses.Inventory.PhysicalInventory;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Repairs")]
public class RentalPIEquipmentHistory : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalPIEquipmentHistory()
    {
        TestInitialize(nameof(OpenPageRentalPIEquipmentHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "RentalPIEquipmentHistory");

                Thread.Sleep(2000);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterRentalPIEquipmentHistory()
    {

        TestInitialize(nameof(OpenGridFilterRentalPIEquipmentHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPIEquipmentHistory");
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
    public void CardViewBtnCheckRentalPIEquipmentHistory()
    {
        TestInitialize(nameof(CardViewBtnCheckRentalPIEquipmentHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "RentalPIEquipmentHistory");
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
    public void ListViewtBtnCheckRentalPIEquipmentHistory()
    {
        TestInitialize(nameof(ListViewtBtnCheckRentalPIEquipmentHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "RentalPIEquipmentHistory");
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
    public void ArrowFirstBtnCheckRentalPIEquipmentHistory()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckRentalPIEquipmentHistory));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPIEquipmentHistory");
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
    public void ArrowLastBtnCheckRentalPIEquipmentHistory()
    {
        TestInitialize(nameof(ArrowLastBtnCheckRentalPIEquipmentHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPIEquipmentHistory");
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
    public void ArrowNextBtnCheckRentalPIEquipmentHistory()
    {
        TestInitialize(nameof(ArrowNextBtnCheckRentalPIEquipmentHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPIEquipmentHistory");
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
    public void ArrowPreviousBtnCheckRentalPIEquipmentHistory()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckRentalPIEquipmentHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPIEquipmentHistory");
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
                GoToUrl("MMInventory", "RentalPIEquipmentHistory");
                RefreshRecordDataInGrid("PIEquipmentHistory-gridId", columnId: "updateFlag");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}