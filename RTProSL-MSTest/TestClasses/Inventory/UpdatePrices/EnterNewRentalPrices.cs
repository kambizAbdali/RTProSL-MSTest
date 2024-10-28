// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Inventory.UpdatePrices;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___UpdatePrices")]
public class EnterNewRentalPrices : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageEnterNewRentalPrices()
    {
        TestInitialize(nameof(OpenPageEnterNewRentalPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewRentalPrices");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterEnterNewRentalPrices()
    {

        TestInitialize(nameof(OpenGridFilterEnterNewRentalPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewRentalPrices");
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
    public void CardViewBtnCheckEnterNewRentalPrices()
    {
        TestInitialize(nameof(CardViewBtnCheckEnterNewRentalPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewRentalPrices");
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
    public void ListViewtBtnCheckEnterNewRentalPrices()
    {
        TestInitialize(nameof(ListViewtBtnCheckEnterNewRentalPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewRentalPrices");
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
    public void ArrowFirstBtnCheckEnterNewRentalPrices()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckEnterNewRentalPrices));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewRentalPrices");
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
    public void ArrowLastBtnCheckEnterNewRentalPrices()
    {
        TestInitialize(nameof(ArrowLastBtnCheckEnterNewRentalPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewRentalPrices");
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
    public void ArrowNextBtnCheckEnterNewRentalPrices()
    {
        TestInitialize(nameof(ArrowNextBtnCheckEnterNewRentalPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewRentalPrices");
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
    public void ArrowPreviousBtnCheckEnterNewRentalPrices()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckEnterNewRentalPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewRentalPrices");
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
    public void FilterEnterNewRentalPricesByEquipment()
    {
        TestInitialize(nameof(FilterEnterNewRentalPricesByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewRentalPrices");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("equipmentId", "EnterNewRentalPrices-gridId");
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
                GoToUrl("MMInventory", "EnterNewRentalPrices");
                RefreshRecordDataInGrid("EnterNewRentalPrices-gridId", columnId: "equipmentId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}