// Developed By Parsa Zakeri

using OpenQA.Selenium;
using RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen;
using System.Net.Mail;

namespace RTProSL_MSTest.TestClasses.Inventory.Repairs;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Repairs")]
public class InspectionHeader : BaseClass
{
    private EquipmentCheckOutInAndBilling equipmentCheckOutInAndBilling = new EquipmentCheckOutInAndBilling();

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInspectionHeader()
    {
        TestInitialize(nameof(OpenPageInspectionHeader));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "InspectionHeader");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePresentBarcodeInventoryAttachmentGridInInspectionHeader() //document "New Features August" number 1
    {
        TestInitialize(nameof(ValidatePresentBarcodeInventoryAttachmentGridInInspectionHeader));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // Initialize variables for equipment code and barcode  
                var equipmentCode = string.Empty;
                var barcode = string.Empty;

                Login();

                equipmentCode = equipmentCheckOutInAndBilling.GetRandomBarcodeEquipment();
                barcode = equipmentCheckOutInAndBilling.AddBarcodeItemToEquipment(equipmentCode: equipmentCode);

                // Navigate to the "InspectionHeader" page in the MMInventory  
                GoToUrl("MMInventory", "InspectionHeader", gotoLogin: false);

                // Input the barcode into the barcode scanner input field  
                webElementAction.GetElementByCssSelector(".barcode-scanner-input-wrapper").FindElement(By.TagName("input")).SendKeys(barcode);

                // Click on the search button to perform the search  
                webElementAction.Click(By.CssSelector(".search-button"));

                // Check for the presence of the confirm button  
                ConfirmBtnCheck();

                // Wait for any loading spinner to disappear  
                WaitForLoadingSpiner();

                // Click on the "TOOL_BOX_BARCODE_ATTACHMENT" button  
                webElementAction.Click(By.Id("TOOL_BOX_BARCODE_ATTACHMENT"));

                // Check if the page 'BarcodeInventoryAttachment' is accessible  
                if (!webElementAction.IsElementPresent(By.Id("BarcodeInventoryAttachment-gridId")))
                    Assert.Fail("Error:___ Unable to navigate to 'BarcodeInventoryAttachment' page.");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}