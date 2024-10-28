// Developed By Mohammad Keshavarz
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Inventory.UpdatePrices;


[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___UpdatePrices")]
public class EnterNewSalesPrices : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageEnterNewEnterNewSalesPrices()
    {
        TestInitialize(nameof(OpenPageEnterNewEnterNewSalesPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewSalesPrices");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterEnterNewEnterNewSalesPrices()
    {

        TestInitialize(nameof(OpenGridFilterEnterNewEnterNewSalesPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewSalesPrices");
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
    public void CardViewBtnCheckEnterNewEnterNewSalesPrices()
    {
        TestInitialize(nameof(CardViewBtnCheckEnterNewEnterNewSalesPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewSalesPrices");
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
    public void ListViewtBtnCheckEnterNewEnterNewSalesPrices()
    {
        TestInitialize(nameof(ListViewtBtnCheckEnterNewEnterNewSalesPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewSalesPrices");
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
    public void ArrowFirstBtnCheckEnterNewEnterNewSalesPrices()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckEnterNewEnterNewSalesPrices));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewSalesPrices");
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
    public void ArrowLastBtnCheckEnterNewEnterNewSalesPrices()
    {
        TestInitialize(nameof(ArrowLastBtnCheckEnterNewEnterNewSalesPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewSalesPrices");
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
    public void ArrowNextBtnCheckEnterNewEnterNewSalesPrices()
    {
        TestInitialize(nameof(ArrowNextBtnCheckEnterNewEnterNewSalesPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewSalesPrices");
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
    public void ArrowPreviousBtnCheckEnterNewEnterNewSalesPrices()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckEnterNewEnterNewSalesPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewSalesPrices");
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
    public void FilterEnterNewSalesPricesByDepartment()
    {
        TestInitialize(nameof(FilterEnterNewSalesPricesByDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EnterNewSalesPrices");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("departmentId", "EnterNewSalesPrices-gridId", colId: "department");
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
                GoToUrl("MMInventory", "EnterNewSalesPrices");
                RefreshRecordDataInGrid("EnterNewSalesPrices-gridId", columnId: "department");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}