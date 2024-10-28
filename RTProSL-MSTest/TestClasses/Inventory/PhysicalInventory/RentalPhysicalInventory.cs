// Developed By Mohammad Keshavarz
using OpenQA.Selenium;

namespace RTProSL_MSTest.TestClasses.Inventory.PhysicalInventory;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Repairs")]
public class RentalPhysicalInventory : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalPhysicalInventory()
    {
        TestInitialize(nameof(OpenPageRentalPhysicalInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPhysicalInventory");
                Thread.Sleep(2000);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInRentalPhysicalInventory()
    {
        TestInitialize(nameof(ListViewBtnCheckInRentalPhysicalInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPhysicalInventory");
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    // This test is different from other CardViewBtn tests.
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInRentalPhysicalInventory()
    {
        TestInitialize(nameof(CardViewBtnCheckInRentalPhysicalInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPhysicalInventory");
                ShowAllRedord();

                Thread.Sleep(2000);
                var cardView = webElementAction.GetElementByCssSelector(".icon-card-view");
                cardView.Click();

                if (webElementAction.IsElementPresent(By.CssSelector(".stepper-cards-container.has-grid-view")))
                    Assert.Fail("CardViewBtn In Rental Physical Inventory does not work correctly");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}