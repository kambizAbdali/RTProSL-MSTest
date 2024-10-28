using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.TestClasses;
using SeleniumWebdriver.Settings;
using static RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen.EquipmentCheckOutInAndBilling;

namespace RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen.Rental
{
    [TestCategory("OrderProcessing")]
    [TestClass, TestCategory("OrderProcessing___OrderProcessingScreen")]
    public class ChangeCheckoutInDate : BaseClass
    {
        EquipmentCheckOutInAndBilling equipmentCheckOutCheckIn;
        public ChangeCheckoutInDate()
        {
            equipmentCheckOutCheckIn = new EquipmentCheckOutInAndBilling();
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ChangeCheckoutDate_Business() //BI = Besiness
        {
            TestInitialize(nameof(ChangeCheckoutDate_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string equipmentCode = string.Empty;
                    string barcode = string.Empty;

                    /* Step 1 :get a barcode equipment and add a barcode item to it*/
                    {
                        equipmentCode = equipmentCheckOutCheckIn.GetRandomBarcodeEquipment(gotoLogin: true);

                        barcode = equipmentCheckOutCheckIn.AddBarcodeItemToEquipment(equipmentCode);
                    }

                    var orderNumber = string.Empty;

                    //* Step 2: Add a new Order and get its orderNo *//
                    {
                        orderNumber = equipmentCheckOutCheckIn.AddOrderFuncWithCurrentLocation();
                    }

                    //* Step 3: Add equipment to order in Rental Order Screen *//
                    {
                        equipmentCheckOutCheckIn.AddEquipmentToRentalOrder(equipmentCode, orderNumber);
                    }

                    //* Step 4: checkout equipment related to order in  Rental Order Screen *//
                    {
                        equipmentCheckOutCheckIn.CheckOutBarcode(barcode);
                    }

                    //* Step 5: Set New Date *//

                    string newDateTime = string.Empty;
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen", false);
                        GoToSubMenu("RENTAL_TOOL_DROPDOWN", "CHANGE_CHECKOUT_DATE");
                        newDateTime = ChangeDate();
                    }

                    //* Step 6: Validate new date checkout
                    {
                        ValidateInsertedNewCheckOutDateInGrid(newDateTime);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void ValidateInsertedNewCheckOutDateInGrid(string insertedNewDate)
        {
            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_CHECKIN");

            GoToSubMenu("VIEW_TOOL_DROPDOWN", "DETAIL_TRANSACTION_RECORDS");

            WaitForLoadingSpiner();

            var rentalInDetailGrid = webElementAction.GetElementById("rentalInDetailScreen-gridId");

            var colIds = rentalInDetailGrid.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

            var newDateValueInDiv = colIds.FirstOrDefault(o => insertedNewDate == o.Text);

            if (newDateValueInDiv == null)
            {
                throw new Exception("The new date value has not been displayed correctly in the checkIn grid.");
            }
        }
        private void ValidateInsertedNewCheckinDateInGrid(string insertedNewDate)
        {
            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_CHECKIN");

            GoToSubMenu("VIEW_TOOL_DROPDOWN", "DETAIL_TRANSACTION_RECORDS");

            WaitForLoadingSpiner();

            var rentalInDetailGrid = webElementAction.GetElementById("rentalInDetailScreen-gridId");

            var colIds = rentalInDetailGrid.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

            var newDateValueInDiv = colIds.FirstOrDefault(o => insertedNewDate == o.Text);

            if (newDateValueInDiv == null)
            {
                throw new Exception("The new date value has not been displayed correctly in the checkIn grid.");
            }
        }

        private string ChangeDate()
        {
            // set previousDate
            webElementAction.GenerateDataToDataFormItemNameContext(dataFormItemName: "previousDate");

            // set newDate to two Days From Now
            var newDateElement = webElementAction.GetElementByCssSelector(".date-picker-input-style");
            string twoDaysFromNowFormatted = DateTime.Now.AddDays(2).ToString("M/d/yyyy h:mm tt");  //   1/10/2024 5:22 PM
            newDateElement.Clear();
            newDateElement.SendKeys(twoDaysFromNowFormatted);

            ConfirmBtnCheck();
            WaitForLoadingSpiner();
            var confirmInfoBtn = webElementAction.GetElementByCssSelector(".confirm-button span"); //Date changed successfully.
            confirmInfoBtn.Click();
            ConfirmBtnCheck(dataSection: "infoDialog");
            return twoDaysFromNowFormatted;
        }

        [TestMethod, Timeout(MaximumExecutionTime * 2)]
        public void ChangeCheckinDate_Business()
        {
            TestInitialize(nameof(ChangeCheckinDate_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string equipmentCode = string.Empty;
                    string barcode = string.Empty;

                    /* Step 1 :get a barcode equipment and add a barcode item to it*/
                    {
                        equipmentCode = equipmentCheckOutCheckIn.GetRandomBarcodeEquipment(gotoLogin: true);

                        barcode = equipmentCheckOutCheckIn.AddBarcodeItemToEquipment(equipmentCode);
                    }

                    var orderNumber = string.Empty;

                    //* Step 2: Add a new Order and get its orderNo *//
                    {
                        orderNumber = equipmentCheckOutCheckIn.AddOrderFuncWithCurrentLocation();
                    }

                    //* Step 3: Add equipment to order in Rental Order Screen *//
                    {
                        equipmentCheckOutCheckIn.AddEquipmentToRentalOrder(equipmentCode, orderNumber);
                    }

                    //* Step 4: checkout equipment related to order in  Rental Order Screen *//
                    {
                        equipmentCheckOutCheckIn.CheckOutBarcode(barcode);
                    }

                    //* Step 5: checkin of checkouted equipment Barcode in Rental Order Screen *//
                    {
                        equipmentCheckOutCheckIn.CheckInBarcode(barcode, checkinType: CheckinType.Normal);
                    }

                    string newDateTime = string.Empty;
                    //* Step 6: Change Checkin Date*//
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen", false);
                        GoToSubMenu("RENTAL_TOOL_DROPDOWN", "CHANGE_CHECKIN_DATE_ACROSS_ORDER");
                        newDateTime = ChangeDate();
                    }

                    //* Step 7: Validate Inserted New Date In Rental Detail Screen *//
                    {
                        ValidateInsertedNewCheckinDateInGrid(newDateTime);
                    }

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}