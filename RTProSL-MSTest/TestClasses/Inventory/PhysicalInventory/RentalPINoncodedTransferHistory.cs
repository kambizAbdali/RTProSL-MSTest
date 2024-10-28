// Developed By Mohammad Keshavarz
namespace RTProSL_MSTest.TestClasses.Inventory.PhysicalInventory;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Repairs")]
public class RentalPINoncodedTransferHistory : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalPINoncodedTransferHistory()
    {
        TestInitialize(nameof(OpenPageRentalPINoncodedTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("MMInventory", "RentalPINoncodedTransferHistory");
                Thread.Sleep(2000);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterRentalPINoncodedTransferHistory()
    {

        TestInitialize(nameof(OpenGridFilterRentalPINoncodedTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("MMInventory", "RentalPINoncodedTransferHistory");
                Thread.Sleep(2000);

                RefreshAllRows(filterId: "equipmentId");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }

    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckRentalPINoncodedTransferHistory()
    {
        TestInitialize(nameof(CardViewBtnCheckRentalPINoncodedTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("MMInventory", "RentalPINoncodedTransferHistory");
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
    public void ListViewtBtnCheckRentalPINoncodedTransferHistory()
    {
        TestInitialize(nameof(ListViewtBtnCheckRentalPINoncodedTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("MMInventory", "RentalPINoncodedTransferHistory");
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
    public void ArrowFirstBtnCheckRentalPINoncodedTransferHistory()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckRentalPINoncodedTransferHistory));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("MMInventory", "RentalPINoncodedTransferHistory");
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
    public void ArrowLastBtnCheckRentalPINoncodedTransferHistory()
    {
        TestInitialize(nameof(ArrowLastBtnCheckRentalPINoncodedTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("MMInventory", "RentalPINoncodedTransferHistory");
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
    public void ArrowNextBtnCheckRentalPINoncodedTransferHistory()
    {
        TestInitialize(nameof(ArrowNextBtnCheckRentalPINoncodedTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("MMInventory", "RentalPINoncodedTransferHistory");
                RefreshAllRows(filterId: "equipmentId");
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
    public void ArrowPreviousBtnCheckRentalPINoncodedTransferHistory()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckRentalPINoncodedTransferHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("MMInventory", "RentalPINoncodedTransferHistory");
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
}