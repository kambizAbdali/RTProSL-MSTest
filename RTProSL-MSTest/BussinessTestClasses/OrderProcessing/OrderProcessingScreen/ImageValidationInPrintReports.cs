using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.TestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen
{
    [TestClass]
    public class ImageValidationInPrintReports : BaseClass
    {
        public ImageValidationInPrintReports()
        {
            equipmentCheckOutInAndBilling = new EquipmentCheckOutInAndBilling();
        }

        EquipmentCheckOutInAndBilling equipmentCheckOutInAndBilling;


        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)] //help file: Visio/OrderProcessing/OrderProcessingScreen/CheckInNormalBarcodeEquipmentAndBilling.vsdx
        public void ValidateEquipmentImageInPullListReport_Business()
        {
            TestInitialize(nameof(ValidateEquipmentImageInPullListReport_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    ValidateEquipmentImageAppearInPreviewReport("PULL_LIST");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime * 2)] //help file: Visio/OrderProcessing/OrderProcessingScreen/CheckInNormalBarcodeEquipmentAndBilling.vsdx
        public void ValidateEquipmentImageInCheckoutSheetReport_Business()
        {
            TestInitialize(nameof(ValidateEquipmentImageInCheckoutSheetReport_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    ValidateEquipmentImageAppearInPreviewReport("CHECKOUT_SHEET_CONTRACT");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod]
        public void ValidateEquipmentImageInReturnListReport_Business()
        {
            TestInitialize(nameof(ValidateEquipmentImageInReturnListReport_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    ValidateEquipmentImageAppearInPreviewReport("RETURN_LIST");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod]
        public void ValidateEquipmentImageInCheckinSheetReport_Business()
        {
            TestInitialize(nameof(ValidateEquipmentImageInCheckinSheetReport_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    ValidateEquipmentImageAppearInPreviewReport("CHECKIN_SHEET");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        ImageDetector imageDetector;
        public void ValidateEquipmentImageAppearInPreviewReport(string report)
        {
            imageDetector = new ImageDetector();
            string equipmentCode = string.Empty;
            string barcode = string.Empty;

            Login();

            /* Step 1 :get a barcode equipment and add a barcode item to it*/
            {
                equipmentCode = equipmentCheckOutInAndBilling.GetRandomBarcodeEquipment();
                barcode = equipmentCheckOutInAndBilling.AddBarcodeItemToEquipment(equipmentCode);
            }

            var orderNumber = string.Empty;
            var orderNumber2 = string.Empty; // for SWAP checkin type 

            //* Step 2: add a new Order and get its orderNo *//
            {
                orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
            }

            //* Step 3: add equipment to order in Rental Order Screen *//
            {
                equipmentCheckOutInAndBilling.AddEquipmentToRentalOrder(equipmentCode, orderNumber);
            }

            //* Step 4: checkout equipment related to order in  Rental Order Screen *//
            {
                equipmentCheckOutInAndBilling.CheckOutBarcode(barcode);
            }

            //* Step 5: add image to equipment *//
            {
                GoToUrl("MMInventory", "EquipmentSummaryList", gotoLogin: false);
                RefreshAllRows();
                SearchAndEditClick(equipmentCode);

                imageDetector.RemoveAllPicturesIfExist();
                imageDetector.AddPicture();
                SaveAndConfirmCheck();
            }

            //* Step 6: Pull List Report *//
            {
                GoToUrl("OrderProcessing", "OrderProcessingScreen", false);
                GoToSubMenu("PRINT_TOOL_DROPDOWN", report);

                webElementAction.SelectingCheckbox("printThumbnails");
                //click on preview btn
                webElementAction.GetElementByCssSelector(".icon-report-preview").Click();
                WaitForLoadingSpiner();
            }

            //* Step 7: Detect Equipment Image in print screen *//
            {
                bool detectedImage = imageDetector.LocateImageInScreenshot();
                if (!detectedImage)
                    throw new Exception("Error: _____ The inserted equipment image does not appear in the print screen.\r\n");
            }
        }
    }
}