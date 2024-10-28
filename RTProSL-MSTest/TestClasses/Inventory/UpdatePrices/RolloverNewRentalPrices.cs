// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper;
namespace RTProSL_MSTest.TestClasses.Inventory.UpdatePrices;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___UpdatePrices")]
public class RentalPhysicalInventory : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRolloverNewRentalPrices()
    {
        TestInitialize(nameof(OpenPageRolloverNewRentalPrices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RolloverNewRentalPrices");

                Thread.Sleep(2000);

                var context = webElementAction.GetElementBySpecificAttribute("data-form-name", "RolloverNewRentalPricesFormName");

                new WebElementDataGenerator(context);

                Thread.Sleep(3000);

                webElementAction.GetElementByCssSelector(".mainButton").Click();

                CheckErrorDialogBox();

                for (int i = 0; i < 2; i++)
                    ConfirmBtnCheck();

                Thread.Sleep(3000);
                webElementAction.GetElementByCssSelector(".mainButton").Click();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}