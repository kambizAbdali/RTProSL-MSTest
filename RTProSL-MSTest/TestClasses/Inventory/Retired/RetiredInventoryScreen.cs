// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.Inventory.Retired;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Retired")]
public class RetiredInventoryScreen : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRetiredInventoryScreen()
    {
        TestInitialize(nameof(OpenPageRetiredInventoryScreen));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventoryScreen");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckRetiredInventoryScreen()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckRetiredInventoryScreen));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");
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
    public void ArrowLastBtnCheckRetiredInventoryScreen()
    {
        TestInitialize(nameof(ArrowLastBtnCheckRetiredInventoryScreen));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");
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
    public void ArrowNextBtnCheckRetiredInventoryScreen()
    {
        TestInitialize(nameof(ArrowNextBtnCheckRetiredInventoryScreen));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");
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
    public void ArrowPreviousBtnCheckRetiredInventoryScreen()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckRetiredInventoryScreen));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RetiredInventory");
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