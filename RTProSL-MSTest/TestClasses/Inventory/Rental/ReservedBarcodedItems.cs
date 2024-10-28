// Developed By Mohammad Keshavarz

using RTProSL_MSTest.DataLayer;
using RTProSL_MSTest.Settings;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class ReservedBarcodedItems : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public async Task OpenPageReservedBarcodedItems()
    {
        TestInitialize(nameof(OpenPageReservedBarcodedItems));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                Login();
                if (!string.IsNullOrEmpty(AppConfigKeys.DatabaseName))
                    await UpdateSetup.SetAllowMultipleReservationOnBarcode("0");
                GoToUrl("MMInventory", "ReservedBarcodedItems", gotoLogin: false);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public async Task CardViewBtnCheckReservedBarcodedItems()
    {
        TestInitialize(nameof(CardViewBtnCheckReservedBarcodedItems));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                Login();
                if (!string.IsNullOrEmpty(AppConfigKeys.DatabaseName))
                    await UpdateSetup.SetAllowMultipleReservationOnBarcode("0");
                GoToUrl("MMInventory", "ReservedBarcodedItems", gotoLogin: false);
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
    public async Task ListViewtBtnCheckReservedBarcodedItems()
    {
        TestInitialize(nameof(ListViewtBtnCheckReservedBarcodedItems));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                Login();
                if (!string.IsNullOrEmpty(AppConfigKeys.DatabaseName))
                    await UpdateSetup.SetAllowMultipleReservationOnBarcode("0");
                GoToUrl("MMInventory", "ReservedBarcodedItems", gotoLogin: false);
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
    public async Task ArrowFirstBtnCheckReservedBarcodedItems()
    {

        TestInitialize(nameof(ArrowFirstBtnCheckReservedBarcodedItems));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                Login();
                if (!string.IsNullOrEmpty(AppConfigKeys.DatabaseName))
                    await UpdateSetup.SetAllowMultipleReservationOnBarcode("0");
                GoToUrl("MMInventory", "ReservedBarcodedItems", gotoLogin: false);
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
    public async Task ArrowLastBtnCheckReservedBarcodedItems()
    {
        TestInitialize(nameof(ArrowLastBtnCheckReservedBarcodedItems));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                Login();
                if (!string.IsNullOrEmpty(AppConfigKeys.DatabaseName))
                    await UpdateSetup.SetAllowMultipleReservationOnBarcode("0");
                GoToUrl("MMInventory", "ReservedBarcodedItems", gotoLogin: false);
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
    public async Task ArrowNextBtnCheckReservedBarcodedItems()
    {
        TestInitialize(nameof(ArrowNextBtnCheckReservedBarcodedItems));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                Login();
                if (!string.IsNullOrEmpty(AppConfigKeys.DatabaseName))
                    await UpdateSetup.SetAllowMultipleReservationOnBarcode("0");
                GoToUrl("MMInventory", "ReservedBarcodedItems", gotoLogin: false);
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
    public async Task ArrowPreviousBtnCheckReservedBarcodedItems()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckReservedBarcodedItems));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                Login();
                if (!string.IsNullOrEmpty(AppConfigKeys.DatabaseName))
                    await UpdateSetup.SetAllowMultipleReservationOnBarcode("0");
                GoToUrl("MMInventory", "ReservedBarcodedItems", gotoLogin: false);
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