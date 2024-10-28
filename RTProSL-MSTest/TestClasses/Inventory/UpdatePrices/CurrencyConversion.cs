// Developed By Mohammad Keshavarz


using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Inventory.UpdatePrices;



[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___UpdatePrices")]
public class CurrencyConversion : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCurrencyConversion()
    {
        TestInitialize(nameof(OpenPageCurrencyConversion));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                {
                    testPassed=true;
                    break;
                }

                GoToUrl("MMInventory", "CurrencyConversion");
                Thread.Sleep(2000);

                var context = webElementAction.GetElementByCssSelector(".modal-page-content");

                new WebElementDataGenerator(context);

                Thread.Sleep(3000);

                webElementAction.GetElementByCssSelector(".mainButton").Click();

                CheckErrorDialogBox();


                for (int i = 0; i < 2; i++)
                {

                    if (webElementAction.IsElementPresent(By.CssSelector("[data-section='confirmDialog']")))
                    {
                        var confirmDialogBox = webElementAction.GetElementBySpecificAttribute("data-section", "confirmDialog");
                        webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", confirmDialogBox).Click();
                    }

                }
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