// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.Inventory.Sales;



[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Sales")]
public class SalesAvailability : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSalesAvailabilityList()
    {
        TestInitialize(nameof(OpenPageSalesAvailabilityList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesAvailability");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterSalesAvailabilityList()
    {

        TestInitialize(nameof(OpenGridFilterSalesAvailabilityList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesAvailability");
                Thread.Sleep(2000);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckSalesAvailabilityList()
    {
        TestInitialize(nameof(CardViewBtnCheckSalesAvailabilityList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesAvailability");
                ShowAllRedord();
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckSalesAvailabilityList()
    {
        TestInitialize(nameof(ListViewtBtnCheckSalesAvailabilityList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesAvailability");
                ShowAllRedord();
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckSalesAvailabilityList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckSalesAvailabilityList));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesAvailability");
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
    public void ArrowLastBtnCheckSalesAvailabilityList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckSalesAvailabilityList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesAvailability");
                ShowAllRedord();
                Thread.Sleep(1000);
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckSalesAvailabilityList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckSalesAvailabilityList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesAvailability");
                ShowAllRedord();
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckSalesAvailabilityList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckSalesAvailabilityList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesAvailability");
                ShowAllRedord();
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
                GoToUrl("MMInventory", "SalesAvailability");
                RefreshRecordDataInGrid("SalesAvailabilityList-gridId", columnId: "stockNo");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}