// Developed By Mohammad Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class AddRentalBarcodedItems : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageAddRentalBarcodedItems()
    {
        TestInitialize(nameof(OpenPageAddRentalBarcodedItems));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "AddBarcodedItems");
                //var context = GetFormLeftSideContext();

                //new WebElementDataGenerator(context);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void SearchBarcodeBySerialNumber()
    {
        TestInitialize(nameof(SearchBarcodeBySerialNumber));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "AddBarcodedItems");

                webElementAction.GenerateDataToDataFormItemNameContext("equipmentId");

                var quantityToAddInput = webElementAction.GetInputElementByDataFormItemNameInDiv("quantityToAdd");
                quantityToAddInput.Clear();
                quantityToAddInput.SendKeys("1");

                WaitForLoadingSpiner();

                var purchaseAmountInput = webElementAction.GetInputElementByDataFormItemNameInDiv("purchaseAmount");
                purchaseAmountInput.SendKeys("1");

                // Uncheck Print option
                webElementAction.DeSelectingCheckbox("printBarcodes");

                //click on autoAssignBarcodes checkbox
                if (!webElementAction.GetInputElementByDataFormItemNameInDiv("autoAssignBarcodes").Selected)
                    webElementAction.GetInputElementByDataFormItemNameInDiv("autoAssignBarcodes").Click();

                //Enter Serial No Radio Button
                webElementAction.GetElementByCssSelector("#serialNoFormat-autoAssignSerial").Click();

                //click on addToRentalBarcodeList
                var addToRentalBarcodeListBtn =
                    webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm");
                addToRentalBarcodeListBtn.Click();
                WaitForLoadingSpiner();
                CheckErrorDialogBox();
                var serialNum = webElementAction.GetAllElementsByCssSelector("[col-id= 'serialNo'][role= 'gridcell']").First().Text;
                var barcode = webElementAction.GetAllElementsByCssSelector("[col-id= 'barcode'][role= 'gridcell']").First().Text;

                var mainSearchInput = webElementAction.GetElementByCssSelector(By.CssSelector("#primary-header-search-input"));
                mainSearchInput.SendKeys(serialNum);
                mainSearchInput.SendKeys(Keys.Enter);
                WaitForLoadingSpiner();
                //- Validate SerialNum in Rental Inventory Entry Screen -//
                var barcodeLabel = webElementAction.GetElementByCssSelector("[data-form-item-name='id'] .wrap-content").Text;
                var serialNumLabel = webElementAction.GetElementByCssSelector("[name='serialNo']").GetAttribute("value");

                Assert.IsTrue(barcode.Equals(barcodeLabel), "Error:__ barcode# in Add Rental Barcoded Items page doesn't equasls with Rental Inventory Entry Screen");
                Assert.IsTrue(serialNum.Equals(serialNumLabel), "Error:__ Serial# in Add Rental Barcoded Items page doesn't equasls with Rental Inventory Entry Screen");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DataEnteryinAddRentalBarcodedItems()
    {
        TestInitialize(nameof(DataEnteryinAddRentalBarcodedItems));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "AddBarcodedItems");
                Thread.Sleep(2000);
                Thread.Sleep(1000);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}
