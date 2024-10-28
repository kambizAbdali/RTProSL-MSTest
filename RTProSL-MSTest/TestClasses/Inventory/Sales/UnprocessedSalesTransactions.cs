// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.Inventory.Sales;



[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Sales")]
public class UnprocessedSalesTransactions : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageUnprocessedSalesTransactions()
    {
        TestInitialize(nameof(OpenPageUnprocessedSalesTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "UnprocessedSalesTransactions");
                if (CurrentUrlIsMultiLocation())  //only multi location servers have Refresh Btn
                    RefreshAllRows();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterUnprocessedSalesTransactions()
    {

        TestInitialize(nameof(OpenGridFilterUnprocessedSalesTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "UnprocessedSalesTransactions");
                if (CurrentUrlIsMultiLocation())  //only multi location servers have Refresh Btn
                    RefreshAllRows();
                Thread.Sleep(2000);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckUnprocessedSalesTransactions()
    {
        TestInitialize(nameof(CardViewBtnCheckUnprocessedSalesTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "UnprocessedSalesTransactions");
                if (CurrentUrlIsMultiLocation())  //only multi location servers have Refresh Btn
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
    public void ListViewtBtnCheckUnprocessedSalesTransactions()
    {
        TestInitialize(nameof(ListViewtBtnCheckUnprocessedSalesTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "UnprocessedSalesTransactions");
                if (CurrentUrlIsMultiLocation())  //only multi location servers have Refresh Btn
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
    public void ArrowFirstBtnCheckUnprocessedSalesTransactions()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckUnprocessedSalesTransactions));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "UnprocessedSalesTransactions");
                if (CurrentUrlIsMultiLocation())  //only multi location servers have Refresh Btn
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
    public void ArrowLastBtnCheckUnprocessedSalesTransactions()
    {
        TestInitialize(nameof(ArrowLastBtnCheckUnprocessedSalesTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "UnprocessedSalesTransactions");
                if (CurrentUrlIsMultiLocation())  //only multi location servers have Refresh Btn
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
    public void ArrowNextBtnCheckUnprocessedSalesTransactions()
    {
        TestInitialize(nameof(ArrowNextBtnCheckUnprocessedSalesTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "UnprocessedSalesTransactions");
                if (CurrentUrlIsMultiLocation())  //only multi location servers have Refresh Btn
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
    public void ArrowPreviousBtnCheckUnprocessedSalesTransactions()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckUnprocessedSalesTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "UnprocessedSalesTransactions");

                if (CurrentUrlIsMultiLocation())  //only multi location servers have Refresh Btn
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
}