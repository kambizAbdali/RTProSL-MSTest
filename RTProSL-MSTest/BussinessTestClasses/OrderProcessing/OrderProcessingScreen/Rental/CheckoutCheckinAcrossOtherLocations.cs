using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.TestClasses;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen.Rental
{
    [TestCategory("OrderProcessing")]
    [TestClass, TestCategory("OrderProcessing___OrderProcessingScreen")]
    public class CheckoutCheckinAcrossOtherLocations : BaseClass
    {
        EquipmentCheckOutInAndBilling equipmentCheckOutCheckIn;
        public CheckoutCheckinAcrossOtherLocations()
        {
            equipmentCheckOutCheckIn = new EquipmentCheckOutInAndBilling();
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void CheckoutAcrossOtherLocations_Business()
        {
            TestInitialize(nameof(CheckoutAcrossOtherLocations_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    if (!CurrentUrlIsMultiLocation())
                        goto finishTest;

                    string currentLocation = string.Empty, equipmentCode = string.Empty, barcode = string.Empty;

                    /* Step 1 : Allow Selecting Checkout Location In System Setup*/
                    {
                        AllowSelectingCheckoutLocation();
                    }

                    /* Step 2 :get a barcode equipment and add a barcode item to equipment */
                    {
                        equipmentCode = equipmentCheckOutCheckIn.GetRandomBarcodeEquipment();
                        barcode = equipmentCheckOutCheckIn.AddBarcodeItemToEquipment(equipmentCode);
                    }
                    string orderNumber = default;

                    /* Step 3: Get an order number related to another location. */
                    {
                        orderNumber = GetOrderNumberForDifferentLocation();
                    }

                    //* Step 4: Add equipment to order of related to other location in Rental Order Screen *//
                    {
                        equipmentCheckOutCheckIn.AddEquipmentToRentalOrder(equipmentCode, orderNumber);
                    }

                    /* Step 5: Check out the barcode related to another location order */
                    {
                        CheckoutAcrossOtherLocation(barcode, orderNumber);
                    }

                    /* Step 6: Validation of the existence of the barcode added to the barcode checkout list*/
                    {
                        equipmentCheckOutCheckIn.ValidateAddedBarcodeExistenceInGridList(barcode, "checkedOutItems-gridId");
                    }

                finishTest:
                    { testPassed = true; }
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void CheckoutAcrossOtherLocation(string barcode, string orderNumber)
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);

            equipmentCheckOutCheckIn.ClearOrderProcessingFields();

            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "CHECKOUT_ACROSS_OTHER_LOCATIONS");

            var orderNoElement = webElementAction.GetElementByCssSelector("[name='orderNo']");
            orderNoElement.SendKeys(orderNumber);

            ConfirmBtnCheck(dataSection: "modal");// Checkout across Other Locations

            WaitForLoadingSpiner();

            // if barcode tab name does not present 
            if (!webElementAction.IsElementPresent(By.CssSelector("[data-tab-name='BARCODED']")))
                webElementAction.GetElementByCssSelector(".detail-sidebar-icons").Click();

            var barcodeInput = webElementAction.GetElementByCssSelector(".tab-content[data-tab-name='BARCODED'] .barcode-scanner-container [placeholder]");
            barcodeInput.SendKeys(barcode);

            Thread.Sleep(2000);
            WaitForLoadingSpiner();
            // click on GO btn (submit barcode to checkout)
            webElementAction.GetElementByCssSelector(".tab-content[data-tab-name='BARCODED'] .barcode-scanner-container > .d-flex span").Click();

            WaitForLoadingSpiner();
            ConfirmBtnCheck(); //Enter User Code (By default: current user)
            Thread.Sleep(2000); //for insert rental Item and bind data in Checkout Items Grid

            ConfirmBtnCheck(); //Error: Barcode belongs to location 'CANADA'. Do a Quick Transfer and continue with Checkout?
            WaitForLoadingSpiner();
            Thread.Sleep(3000);
        }

        private void CheckinAcrossOtherLocation(string barcode, string orderNumber)
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);

            equipmentCheckOutCheckIn.ClearOrderProcessingFields();

            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "CHECKIN_ACROSS_OTHER_LOCATIONS");

            var orderNoElement = webElementAction.GetElementByCssSelector("[name='orderNo']");
            orderNoElement.SendKeys(orderNumber);

            ConfirmBtnCheck();// Checkin across Other Locations

            WaitForLoadingSpiner();

            // if barcode tab name does not present                [class='barcode-description-title']
            if (!webElementAction.IsElementPresent(By.CssSelector("[data-button-type='search']")))
                webElementAction.GetElementByCssSelector(".detail-sidebar-icons").Click();

            var barCodeContext = webElementAction.GetElementByCssSelector(".barcode-scanner-container");

            var barcodeInput = barCodeContext.FindElements(By.TagName("input")).Where(o => o.GetAttribute("type") == "text").First();
            barcodeInput.SendKeys(barcode);

            string tomarrowDate = DateTime.Now.AddDays(1).ToString("M/d/yyyy");

            var checkinDateElement = webElementAction.GetElementByCssSelector(".date-picker-input-style");
            checkinDateElement.Clear();
            checkinDateElement.SendKeys(tomarrowDate);
            WaitForLoadingSpiner();

            // By default it is set to normal

            WaitForLoadingSpiner();
            Thread.Sleep(1500);

            // click on 'GO' btn (submit barcode to checkout)
            var goBtn = webElementAction.GetElementByCssSelector(".search-button span");
            goBtn.Click();
            Thread.Sleep(2000);
            goBtn.Click();
            WaitForLoadingSpiner();
            ConfirmBtnCheck(); //DialogBox: Enter User Code (By default: current user)
            WaitForLoadingSpiner();
            //DialogBox: Enter the Inspection Note
            if (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='INPUT_BOX']")))
            {
                var inputBoxContext = webElementAction.GetElementByCssSelector("[data-modal-title='INPUT_BOX']");
                new WebElementDataGenerator(inputBoxContext);
                ConfirmBtnCheck();
            }
        }

        private string GetOrderNumberForDifferentLocation()
        {
            GoToUrl("OrderProcessing", "OrderSummaryList", gotoLogin: false);
            RefreshAllRows();
            UncheckShowAllRecord();

            SetCustomShowAll("ORDER");

            WaitForLoadingSpiner();

            var currentLocation = GetCurrentLocation();

            if (currentLocation != "NEWYORK")
                SearchTextInMainGrid("NEWYORK");  // The assumption is that the location NEWYORK is another place.
            ClearAllTagList();
            WaitForLoadingSpiner();
            //get Order Number For Different Location
            var orderNumber = webElementAction.GetAllElementBySpecificAttribute("col-id", "orderNo")[1].Text;
            return orderNumber;
        }

        private void AllowSelectingCheckoutLocation()
        {
            GoToUrl("Administration", "SystemSetup");

            string checkoutUrl = ObjectRepository.Driver.Url + "?path=checkout";

            NavigationHelper.NavigateToUrl(checkoutUrl);

            WaitForLoadingSpiner();

            var editBtn = webElementAction.GetElementByCssSelector(".icon-edit");
            editBtn.Click();

            var allowSelectLocationOut = webElementAction.GetInputElementByDataFormItemNameInDiv("selectLocationOut");

            //click on post Btn
            webElementAction.GetElementByCssSelector(".icon-tick").Click();
        }

        private void AllowSelectingCheckinLocation()
        {
            GoToUrl("Administration", "SystemSetup");

            string checkoutUrl = ObjectRepository.Driver.Url + "?path=checkin";

            NavigationHelper.NavigateToUrl(checkoutUrl);

            WaitForLoadingSpiner();

            var editBtn = webElementAction.GetElementByCssSelector(".icon-edit");
            editBtn.Click();

            //allowSelectLocationIn
            webElementAction.SelectingCheckbox("selectLocationIn");

            //click on post Btn
            webElementAction.GetElementByCssSelector(".icon-tick").Click();
            ConfirmBtnCheck();// Confirm: Save Changes
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void CheckinAcrossOtherLocations_Business()
        {
            TestInitialize(nameof(CheckinAcrossOtherLocations_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    if (!CurrentUrlIsMultiLocation())
                        goto finishTest;

                    string currentLocation = string.Empty, equipmentCode = string.Empty, barcode = string.Empty;

                    /* Step 1 : Allow Selecting Checkout Location In System Setup*/
                    {
                        AllowSelectingCheckinLocation();
                    }

                    /* Step 2 :get a barcode equipment and add a barcode item to equipment */
                    {
                        equipmentCode = equipmentCheckOutCheckIn.GetRandomBarcodeEquipment();
                        barcode = equipmentCheckOutCheckIn.AddBarcodeItemToEquipment(equipmentCode);
                    }
                    string orderNumber = default;

                    /* Step 3: get Order Number For Different Location. */
                    {
                        orderNumber = GetOrderNumberForDifferentLocation();
                    }

                    //* Step 4: Add equipment to order of related to other location in Rental Order Screen *//
                    {
                        equipmentCheckOutCheckIn.AddEquipmentToRentalOrder(equipmentCode, orderNumber);
                    }

                    //* Step 5: checkout equipment related to the order in Rental Order Screen *//
                    {
                        equipmentCheckOutCheckIn.CheckOutBarcode(barcode);
                    }

                    //* Step 6: checkin equipment related to other location in Rental Order Screen *//
                    {
                        CheckinAcrossOtherLocation(barcode, orderNumber);
                    }

                    /* Step 7: Validation of the existence of the barcode added to the barcode checkin list*/
                    {
                        equipmentCheckOutCheckIn.ValidateAddedBarcodeExistenceInGridList(barcode, "RentalCheckinCheckedIn-gridId");
                    }

                finishTest: { testPassed = true; }
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        //"Allow Selecting Checkin Location' checkbox in the system setup."
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void CheckinByProductionAcrossOtherLocations_Business()
        {
            TestInitialize(nameof(CheckinByProductionAcrossOtherLocations_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    if (!CurrentUrlIsMultiLocation())
                        goto finishTest;

                    string currentLocation = string.Empty, equipmentCode = string.Empty, barcode = string.Empty, productionId = string.Empty;
                    /* Step 1: Go to Checkin by Selected Orders page*/
                    {
                        AllowSelectingCheckinLocation();
                    }

                    /* Step 2: Checkin by Production across Other Locations*/
                    {
                        productionId = SetAndGetRandomProductionFromCheckInModal();
                    }

                    /* Step 3: Checkin by Production across Other Locations*/
                    {
                        ValidateProductionValueInCheckinBySelectedOrdersPage(productionId);
                    }

                finishTest:
                    {
                        testPassed = true;
                    }
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void CheckinBySelectedOrders_Business()
        {
            TestInitialize(nameof(CheckinBySelectedOrders_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string orderNumber = string.Empty;

                    //* Step 1: Add a new Order and get its orderNo *//
                    {
                        Login();
                        orderNumber = equipmentCheckOutCheckIn.AddOrderFuncWithCurrentLocation();
                    }

                    string[] selectedOrderNumbers = default;
                    //* Step 2: Checkin Multiple Selected Order *//
                    {
                        (selectedOrderNumbers) = CheckinMultipleSelectedOrder(orderNumber);
                    }

                    /* Step 3: Validate selected orders in Rental Checkin Screen  */
                    {
                        ValidateSelectedOrdersInRentalCheckinScreen(selectedOrderNumbers);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void ValidateSelectedOrdersInRentalCheckinScreen(string[] selectedOrderNumbers)
        {
            WaitForLoadingSpiner();
            IWebElement rentalCheckinGrid = default;
            ReadOnlyCollection<IWebElement> colIdsCheckinItems = default;
            foreach (var orderNum in selectedOrderNumbers)
            {
                FilterRentalCheckinScreen(orderNum);
                WaitForLoadingSpiner();

                rentalCheckinGrid = webElementAction.GetElementById("RentalCheckinScreen-gridId");
                colIdsCheckinItems = rentalCheckinGrid.FindElements(By.CssSelector("[col-id='orderNo']"));
                if (colIdsCheckinItems.FirstOrDefault(o => o.Text == orderNum) == null)
                {
                    throw new Exception("Order number " + orderNum + " has not been added to the checked-in orders.");
                }
            }
        }

        private void FilterRentalCheckinScreen(string orderId)
        {
            var RentalCheckinScreen = webElementAction.GetElementByCssSelector("[data-header-name='RentalCheckinScreen']");
            var searchInput = webElementAction.GetElementByCssSelector("input[class*=\"main-search-input\"]", RentalCheckinScreen);
            searchInput.Clear();
            searchInput.SendKeys(orderId);
        }

        private string[] CheckinMultipleSelectedOrder(string orderNumber)
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);

            equipmentCheckOutCheckIn.ClearOrderProcessingFields();
            //To go to the sub-menu CHECKIN_BY_SELECTED, at least one order must be selected on the OrderProcessingScreen page
            equipmentCheckOutCheckIn.FillOrderNumber(orderNumber);

            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "CHECKIN_BY_SELECTED");
            RefreshAllRows();

            var firstTreeRows = webElementAction.GetAllElementsByCssSelector(".ag-center-cols-container > [aria-rowindex]:nth-of-type(-n+3)");

            int index = 0;
            var selectedOrderNumbers = new string[3];

            foreach (var row in firstTreeRows)
            {
                row.Click();
                selectedOrderNumbers[index] = row.GetAttribute("row-id");
                index++;
            }

            //click on checkin selected btn
            webElementAction.GetElementByCssSelector(".confirm-button span").Click();
            return selectedOrderNumbers;
        }

        private void ValidateProductionValueInCheckinBySelectedOrdersPage(string productionId)
        {
            WaitForLoadingSpiner();
            var checkinByOtherLocationsGrid = webElementAction.GetElementById("checkinByOtherLocations-gridId");

            var productionColIds = checkinByOtherLocationsGrid.FindElements
                (By.TagName("div")).Where(o => o.GetAttribute("col-id") == "production");

            // item[0] is header  // item[n] is null
            foreach (var item in productionColIds.Skip(1).Take(productionColIds.Count() - 2))
            {
                if (item.Text != productionId)
                    throw new Exception("The functionality of the filter button to display productions with number " + productionId + " is incorrect.");
            }
        }

        private string SetAndGetRandomProductionFromCheckInModal()
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);

            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "CHECKIN_BY_PRODUCTION_ACROSS_OTHER_LOCATIONS");

            //generate production value in modal of checkin by production across other locations  
            var productionContext = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "productionId");
            new WebElementDataGenerator(productionContext);

            // get Production value In Modal
            var productionElement = webElementAction.GetInputElementByDataFormItemNameInDiv("productionId");
            string inputProductionInModal = productionElement.GetAttribute("value");

            ConfirmBtnCheck(dataSection: "modal"); //Confirm: Checkin by Production across Other Locations.
            WaitForLoadingSpiner();
            return inputProductionInModal;
        }
    }
}