using AventStack.ExtentReports.Utils;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.TestClasses;
using SeleniumWebdriver.Settings;
using System.Data;

// Help:  //Prerequisite (For billing): Fulfilling the 'Require Billing Schedule on Orders' checkbox is required in the system-setup.


namespace RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen
{
    [TestCategory("OrderProcessing")]
    [TestClass, TestCategory("OrderProcessing___EquipmentCheckInOutAndBilling")]
    public class EquipmentCheckOutInAndBilling : BaseClass
    {
        public enum CheckinType
        {
            Normal,
            Loss,
            Damage,
            Transfer,
            Swap,
            NoCharge
        }
        static string equipmentCode;
        public void CompleteRentalProcess(CheckinType checkinType)
        {
            string equipmentCode = string.Empty;
            string barcode = string.Empty;

            Login();

            /* Step 1 :get a barcode equipment and add a barcode item to it*/
            {
                equipmentCode = GetRandomBarcodeEquipment();
                barcode = AddBarcodeItemToEquipment(equipmentCode);
            }

            var orderNumber = string.Empty;
            var orderNumber2 = string.Empty; // for SWAP checkin type 

            //* Step 2: Add a new Order and get its orderNo *//
            {
                orderNumber = AddOrderFuncWithCurrentLocation();
            }

            //* Step 3: Add equipment to order in Rental Order Screen *//
            {
                AddEquipmentToRentalOrder(equipmentCode, orderNumber);
            }

            //* Step 4: checkout equipment related to order in  Rental Order Screen *//
            {
                CheckOutBarcode(barcode);
            }

            //* Step 5: checkin of equipment Barcode checkouted in Rental Order Screen *//
            {
                CheckInBarcode(barcode, checkinType);
            }

            //* Step 6: Bill this Order *//
            {
                BillOrder();
            }
        }

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)] //help file: Visio/OrderProcessing/OrderProcessingScreen/CheckInNormalBarcodeEquipmentAndBilling.vsdx
        public void CheckInNormalBarcodeEquipmentAndBilling_Business()
        {
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    TestInitialize(nameof(CheckInNormalBarcodeEquipmentAndBilling_Business));
                    CompleteRentalProcess(CheckinType.Normal);
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void BillOrder()
        {
            //Prerequisite: Fulfilling the 'Require Billing Schedule on Orders' checkbox is required in the system-setup.
            GoToUrl("OrderProcessing", "OrderProcessingScreen", false);

            GoToSubMenu("BILLING_TOOL_DROPDOWN", "CREATE_NEW_INVOICE");

            Thread.Sleep(1500);

            webElementAction.SelectingCheckbox("billType.rentals");
            webElementAction.SelectingCheckbox("create0Invoice"); //Create Invoice if Total Is $0.00

            ConfirmBtnCheck(dataSection: "modal"); //Click on Create the draft btn
            ConfirmBtnCheck(); //Confirm: You are billing beyond the order Usage End Date of 1/14/2024 Continue?
            ConfirmBtnCheck(); //Confirm: Do you want to create the Draft?

            WaitForLoadingSpiner();
            ConfirmBtnCheck(); //Confirm: Error: No Billing is Due. Show further details?

            CheckErrorDialogBox();

            if (!webElementAction.IsElementPresent(By.CssSelector(".invoice-screen-container")))
            {
                throw new Exception("Error message: Create new invoice Failed. The invoice-container page is not loading!!!");
            }
        }

        public void CheckOutBarcode(string barcode)
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", false);

            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_CHECKOUT");

            OpenDetailDialogInRightSide();

            var barcodeInput =
                webElementAction.GetElementByCssSelector(
                    ".tab-content[data-tab-name='BARCODED'] .barcode-scanner-container [placeholder]");
            barcodeInput.SendKeys(barcode);

            Thread.Sleep(2000);
            WaitForLoadingSpiner();
            // click on GO btn (submit barcode to checkout)
            webElementAction
                .GetElementByCssSelector(
                    ".tab-content[data-tab-name='BARCODED'] .barcode-scanner-container > .d-flex span").Click();

            if (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='ENTER_USER_CODE']")))
            {
                var enterUserCodeModal = webElementAction.GetElementBySpecificAttribute("data-modal-title", "ENTER_USER_CODE");
                new WebElementDataGenerator(enterUserCodeModal);
                ConfirmBtnCheck(dataSection: "modal");
            }
            //if (webElementAction.IsElementPresent(By.CssSelector(".icon-close")))
            //    webElementAction.Click(By.CssSelector(".icon-close"));

            WaitForLoadingSpiner();
            ConfirmBtnCheck(); //Enter User Code (By default: current user)
            Thread.Sleep(1000); //for insert rental Item and bind data in Checkout Items Grid
            WaitForLoadingSpiner();
            ConfirmBtnCheck(); //Error: Barcode belongs to location 'CANADA'. Do a Quick Transfer and continue with Checkout?
            WaitForLoadingSpiner();
            ValidateAddedBarcodeExistenceInGridList(barcode, "checkedOutItems-gridId");
        }

        public void AddEquipmentToRentalOrder(string equipmentCode, string orderNumber)
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
            Thread.Sleep(500);
            ClearOrderProcessingFields();
            Thread.Sleep(1000);
            FillOrderNumber(orderNumber);

            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_ORDER");

            Thread.Sleep(2000);
            //click on add rental item
            webElementAction.GetElementByCssSelector("[data-header-name='rentalItems'] .icon-add").Click();
            Thread.Sleep(2000);
            var newRowColsContext = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row");

            SetInputValueInActiveRowOfGrid(newRowColsContext, "equipmentId",
                equipmentCode); // equipmentCodeInfirstRow

            newRowColsContext = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row");

            FindColumnInMainGrid("Actual Price", gridId: "rentalItems-gridId");

            SetInputValueInActiveRowOfGrid(newRowColsContext, "actualPrice", "20"); // actualPriceInfirstRow

            FindColumnInMainGrid("Ordered", gridId: "rentalItems-gridId");
            //set two quantityOrdered for two barcode
            SetInputValueInActiveRowOfGrid(newRowColsContext, "quantityOrdered", "2"); // actualPriceInfirstRow


            Thread.Sleep(3000);

            webElementAction.ClickOnPostBtnInMinGrid(gridId: "rentalItems-gridId");

            ConfirmBtnCheck(false); //Auto Include Accessory? No
        }

        public void CheckInBarcode(string barcode, CheckinType checkinType, string barcodeForSwap = null,
            string orderToTransfer = null)
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", false);
            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_CHECKIN");
            OpenDetailDialogInRightSide();
            var barCodeContext = webElementAction.GetElementByCssSelector(".barcode-scanner-container");

            var barcodeInput = barCodeContext.FindElements(By.TagName("input"))
                .Where(o => o.GetAttribute("type") == "text").First();
            barcodeInput.SendKeys(barcode);

            string tomarrowDate = DateTime.Now.AddDays(1).ToString("M/d/yyyy");

            var checkinDateElement = webElementAction.GetElementByCssSelector(".date-picker-input-style");
            checkinDateElement.Clear();
            checkinDateElement.SendKeys(tomarrowDate);
            WaitForLoadingSpiner();
            switch (checkinType)
            {
                case CheckinType.Normal: // By default it is set to normal
                    {
                        WaitForLoadingSpiner();
                        Thread.Sleep(1500);

                        // click on 'GO' btn (submit barcode to checkout)
                        var goBtn = webElementAction.GetElementByCssSelector(".search-button span");
                        goBtn.Click();

                        WaitForLoadingSpiner();
                        ConfirmBtnCheck(dataSection: "modal"); //DialogBox: Enter User Code (By default: current user)
                        WaitForLoadingSpiner();
                        //DialogBox: Enter the Inspection Note
                        if (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='INPUT_BOX']")))
                        {
                            var inputBoxContext =
                                webElementAction.GetElementByCssSelector("[data-modal-title='INPUT_BOX']");
                            new WebElementDataGenerator(inputBoxContext);
                            ConfirmBtnCheck();
                        }
                    }
                    break;

                case CheckinType.Loss:
                    {
                        SetCheckinType(nameof(CheckinType.Loss));
                        // click on 'GO' btn (submit barcode to checkout)
                        webElementAction.GetElementByCssSelector(".search-button span").Click();

                        ConfirmBtnCheck(); //DialogBox: Enter User Code (By default: current user)

                        //DialogBox: Loss Reason

                        if (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='LOSS_REASON']")))
                        {
                            var lossReasonContext =
                                webElementAction.GetElementByCssSelector("[data-modal-title='LOSS_REASON']");
                            new WebElementDataGenerator(lossReasonContext);
                            ConfirmBtnCheck(dataSection: "modal");
                        }
                    }
                    break;

                case CheckinType.Damage:
                    {
                        SetCheckinType(nameof(CheckinType.Damage));

                        // click on 'GO' btn (submit barcode to checkout)
                        webElementAction.GetElementByCssSelector(".search-button span").Click();
                        ConfirmBtnCheck(); // Confirm message: You are billing beyond the order Usage End Date of 1/17/2024 Continue?
                        ConfirmBtnCheck(dataSection: "modal"); // Confirm message: Do you want to create the Draft?
                    }
                    break;


                case CheckinType.Transfer:
                    {
                        SetCheckinType(nameof(CheckinType.Transfer));

                        //Enter Order# To Transfer.
                        var transferToOrderElement = webElementAction.GetElementByCssSelector("[name='orderNo']");
                        transferToOrderElement.SendKeys(orderToTransfer);

                        ConfirmBtnCheck(true); // Window: Enter Order# To Transfer.

                        ConfirmBtnCheck(
                            true); // Confirm: Order you entered belongs to a different Production. Transfer anyway?

                        // click on 'GO' btn (submit barcode to checkout)
                        //webElementAction.GetElementByCssSelector(".search-button span").Click();
                        ConfirmBtnCheck(dataSection: "modal"); //DialogBox: Enter User Code (By default: current user)
                        WaitForLoadingSpiner();
                        ConfirmBtnCheck(true);
                        WaitForLoadingSpiner();
                    }
                    break;

                case CheckinType.Swap:
                    {
                        SetCheckinType(nameof(CheckinType.Swap));

                        Thread.Sleep(2000);
                        // click on 'GO' btn (submit barcode to checkout)
                        webElementAction.GetElementByCssSelector(".search-button span").Click();

                        ConfirmBtnCheck(dataSection: "modal"); //DialogBox: Enter User Code (By default: current user)
                        WaitForLoadingSpiner();
                        Thread.Sleep(2000);
                        var barcodeCell = ObjectRepository.Driver.FindElements(By.TagName("div"))
                            .FirstOrDefault(o => o.Text == barcodeForSwap);
                        barcodeCell.Click();

                        //click on confirm Btn
                        webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm").Click();

                        ConfirmBtnCheck(true); //Do you want to swap Barcode# 9362 with Barcode# 9359 (out on Order# 5801) ?
                    }
                    break;

                case CheckinType.NoCharge:
                    {
                        SetCheckinType("No Charge");

                        // click on 'GO' btn (submit barcode to checkout)
                        webElementAction.GetElementByCssSelector(".search-button span").Click();
                        ConfirmBtnCheck(); //DialogBox: Enter User Code (By default: current user)
                    }
                    break;

            }

            Thread.Sleep(4000);
        }

        public void ClearOrderProcessingFields()
        {
            Thread.Sleep(2000);
            WaitForLoadingSpiner();
            var clearOrderProcessingFields = webElementAction.GetElementByCssSelector(".icon-eraser");
            clearOrderProcessingFields.Click();
        }

        public void FillOrderNumber(string orderNo)
        {
            var order_no_input = webElementAction.GetInputElementByDataInputNameInDiv("order_no_input");
            order_no_input.SendKeys(orderNo);

            Thread.Sleep(1500);

            var searhBtn = webElementAction.GetElementBySpecificAttribute("data-input-name", "order_no_input")
                .FindElement(By.TagName("button"));
            searhBtn.Click();
            WaitForLoadingSpiner();
        }


        public string AddOrderFuncWithCurrentLocation(bool callFromOrderProcessingScreen = false)
        {
            if (callFromOrderProcessingScreen)
            {
                ClearOrderProcessingFields();
                var addOrderBtn =
                    webElementAction.GetElementByCssSelector(
                        ".ant-collapse > div:nth-of-type(1) div:nth-of-type(3) i:nth-of-type(1)");
                addOrderBtn.Click();

                ConfirmBtnCheck(); //Do you want to add a new Order?
            }

            else
            {
                GoToUrl("OrderProcessing", "OrderSummaryList", false);
                RefreshAllRows();
                //click on addNewRecordBtn
                Thread.Sleep(2000);
                webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();
                ConfirmBtnCheck();
                Thread.Sleep(1000);
            }

            var productionContext =
                webElementAction.GetElementBySpecificAttribute("data-form-item-name", "productionId");
            new WebElementDataGenerator(productionContext);
            WaitForLoadingSpiner();
            webElementAction.GetElementByCssSelector(".confirm-button").Click();

            while (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='CANCEL_REASON']"))
                   || webElementAction.IsElementPresent(By.CssSelector("[data-section='confirmDialog']")))
            {
                webElementAction.GetElementBySpecificAttribute("data-button-type", "cancel").Click();
            }

            var contextOrderHeader = webElementAction.GetElementByCssSelector(".enormous-left-section > .row-division");
            GenerateDataToRequiredElements(contextOrderHeader);

            //tab general
            var contextGeneral = GetTabContext("GENERAL");
            GenerateDataToRequiredElements(contextGeneral);

            //tab date
            ClickTab("DATES");
            var contextDate = GetTabContext("DATES");
            GenerateDataToRequiredElements(contextDate);

            //tab billing
            ClickTab("BILLING");
            var contextBilling = GetTabContext("BILLING");
            GenerateDataToRequiredElements(contextBilling);

            Thread.Sleep(2000);
            new WebElementDataGenerator().DropDownListGeneratorWithFilter(dataFormaItemName: "orderType", filter: "Order");
            var orderNo = webElementAction.GetInputElementByDataFormItemNameInDiv("searchOrderNo").GetAttribute("value");
            WaitForLoadingSpiner();
            Thread.Sleep(1500);
            //  set Regular Bill value to billingType dropdown
            new WebElementDataGenerator().DropDownListGeneratorWithFilter(dataFormaItemName: "billingType", filter: "Regular Bill");

            GenerateDataToContactTab();

            SaveAndConfirmCheck();
            ConfirmBtnCheck();
            if (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='ENTER_REASON']")))
            {
                var modalReasonContext =
                    webElementAction.GetElementBySpecificAttribute("data-modal-title", "ENTER_REASON");
                webElementAction.GetElementBySpecificAttribute("data-icon-name", "report-scheduler", modalReasonContext)
                    .Click();
                webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", modalReasonContext)
                    .Click();
            }
            ConfirmBtnCheck(
                dataSection:
                "alertDialog"); //Alert: No Certificate of Insurance, or Certificate of Insurance is Expired
            return orderNo;
        }

        private void GenerateDataToContactTab()
        {
            //**************************generate data to CONTACTS tab*************************************
            ClickTab("CONTACT");
            ListViewtBtnClick();
            var contactContext = GetTabContext("CONTACT");

            //delete all contacts
            DeleteAllRowsInMinGrid(contactContext, dataHeaderName: "OrderHeaderContactList-MiniGrid");

            //add contact btn
            webElementAction.GetElementBySpecificAttribute("id", "MINI_GRID_ADD_BUTTON", contactContext).Click();

            Thread.Sleep(2000);
            var newRowColsContext = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row");
            new WebElementDataGenerator(newRowColsContext, true);

            //fill all checkboxes in row
            var checkboxElements = newRowColsContext.FindElements(By.TagName("input")).Where(element => element.GetAttribute("type") == "checkbox").ToList();
            new WebElementDataGenerator().CheckboxGenerator(checkboxElements);

            webElementAction.ClickOnPostBtnInMinGrid(gridId: "OrderHeaderContactList-MiniGrid-gridId");
        }

        public string AddBarcodeItemToEquipment(string equipmentCode)
        {
            RefreshAllRows();
            SearchAndEditClick(equipmentCode);

            //If equipment has an RFID checkbox, we cannot add a barcode to it.
            DeSelectingRFIDCheckboxForEquipment();
            SelectingInventoryCheckboxForEquipment();

            //click on post Btn
            webElementAction.GetElementByCssSelector(".icon-tick").Click();

            WaitForLoadingSpiner();
            var actionMenu =
                webElementAction.GetElementByCssSelector(
                    "[data-focus-lock-disabled='false'] #ACTION_TOOL_DROPDOWN .tools-box-dropdown-toggle");
            actionMenu.Click();

            var addNewBarcodeSubMenu = ObjectRepository.Driver.FindElements(By.TagName("li"))
                .Where(o => o.GetAttribute("data-menu-id").Contains("ADD_BARCODED_ITEMS")).FirstOrDefault();
            addNewBarcodeSubMenu.Click();

            var quantityToAddInput = webElementAction.GetInputElementByDataFormItemNameInDiv("quantityToAdd");
            quantityToAddInput.SendKeys("1");

            WaitForLoadingSpiner();

            var purchaseAmountInput = webElementAction.GetInputElementByDataFormItemNameInDiv("purchaseAmount");
            purchaseAmountInput.SendKeys("1");

            // Uncheck Print option
            webElementAction.DeSelectingCheckbox("printBarcodes");

            //click on autoAssignBarcodes checkbox

            if (!webElementAction.GetInputElementByDataFormItemNameInDiv("autoAssignBarcodes").Selected)
                webElementAction.GetInputElementByDataFormItemNameInDiv("autoAssignBarcodes").Click();

            //click on addToRentalBarcodeList
            var addToRentalBarcodeListBtn =
                webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm");
            addToRentalBarcodeListBtn.Click();

            Thread.Sleep(2000);
            var barcode = webElementAction.GetAllElementsByCssSelector("[col-id= 'barcode'][role= 'gridcell']")[0].Text;
            return barcode;
        }

        private void DeSelectingRFIDCheckboxForEquipment()
        {
            ClickTab("SETTING");
            if (webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='rfidOnly']")))
                webElementAction.DeSelectingCheckbox("rfidOnly");
        }

        private void SelectingInventoryCheckboxForEquipment()
        {
            ClickTab("SETTING");
            if (webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='inventory']")))
                webElementAction.SelectingCheckbox("inventory");
        }

        public string AddNonCodeItemToEquipment(string equipmentCode)
        {
            SearchAndEditClick(equipmentCode);
            //click on post Btn
            webElementAction.GetElementByCssSelector(".icon-tick").Click();
            var actionMenu = webElementAction.GetElementByCssSelector(
                    "[data-focus-lock-disabled='false'] #ACTION_TOOL_DROPDOWN .tools-box-dropdown-toggle");
            actionMenu.Click();

            var addNewNonCodeSubMenu = ObjectRepository.Driver.FindElements(By.TagName("li"))
                .Where(o => o.GetAttribute("data-menu-id").Contains("ADD_NONCODED_ITEMS")).FirstOrDefault();
            addNewNonCodeSubMenu.Click();

            Thread.Sleep(2000);

            var purchaseAmountInput = webElementAction.GetInputElementByDataFormItemNameInDiv("purchaseAmount");
            purchaseAmountInput.SendKeys("1");

            var quantityToAddInput = webElementAction.GetInputElementByDataFormItemNameInDiv("quantityToAdd");
            quantityToAddInput.SendKeys("1");

            //click on addToRentalBarcodeList
            var addToRentalNonCodeListBtn =
                webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm");
            addToRentalNonCodeListBtn.Click();

            ConfirmBtnCheck(); //Do you want to add Quantity of 1.

            var noncode = webElementAction.GetAllElementsByCssSelector("[col-id= 'noncoded'][role= 'gridcell']")[0]
                .Text;
            return noncode;
        }

        private void CheckOutNoncodeEquipment()
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", false);

            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_CHECKOUT");

            GoToSubMenu("CHECKOUT_DROPDOWN", "CHECKOUT_ALL");

            ConfirmBtnCheck(
                true); //Confirm: This will Checkout all items with Checkout Date of -- / -- / 2024 3:11 PM.Continue?

            ConfirmBtnCheck(true); //Confirm: Are you Sure?
        }

        private void CheckInNoncode()
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", false);
            ConfirmBtnCheck(dataSection: "alertDialog");
            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_CHECKIN");

            Thread.Sleep(2000);
            var menuElement = webElementAction.GetElementById("ACTION_TOOL_DROPDOWN");
            menuElement.Click();

            //click on CHECKIN_ALL submenu
            webElementAction.GetElementByCssSelector("[data-menu-id*='CHECKIN_ALL'] .ellipsis-content").Click();

            //click on CHECKIN_ALL-Items submenu  //ToDo Wait for element
            webElementAction.GetElementByCssSelector("ul[id*='CHECKIN_ALL-popup'] li:nth-child(3)").Click();

            ConfirmBtnCheck(
                true); //Confirm: This will Checkin ALL remaining items with Checkin Date of -- / -- / 2024 -:-- PM.Continue ?
            ConfirmBtnCheck(true); //Confirm: Are you Sure?

            Thread.Sleep(4000);
        }

        public string GetRandomNoncodeEquipment()
        {
            GoToUrl("MMInventory", "EquipmentList");
            RefreshAllRows(filterId: "currencyId");
            ShowAllRedord();
            var barcodeFilterElement = webElementAction
                .GetElementByCssSelector("[col-id='barcodedOnly'][role='columnheader']")
                .FindElement(By.CssSelector(".ag-header-cell-menu-button"));
            barcodeFilterElement.Click();

            var sortAcendingElement =
                webElementAction.GetElementByCssSelector(".ag-menu-list > div:nth-of-type(2)");
            sortAcendingElement.Click();

            //equipment Code In firstRow with barcode
            Thread.Sleep(2000);
            var equipmentCode = ObjectRepository.Driver
                 .FindElements(By.CssSelector("[col-id='id'][role='gridcell']"))
                 .First().Text;
            return equipmentCode;
        }

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]  //help file: Visio/OrderProcessing/OrderProcessingScreen/NonCodeEquipmentCheckInOutAndBilling.vsdx
        public void NonCodeEquipmentCheckInOutAndBilling_Business()
        {
            TestInitialize(nameof(NonCodeEquipmentCheckInOutAndBilling_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string equipmentCode = string.Empty, noncode = string.Empty;

                    /* Step 1 :get a noncode equipment and add a noncode item to it*/
                    {
                        equipmentCode = GetRandomNoncodeEquipment();
                        AddNonCodeItemToEquipment(equipmentCode);
                    }

                    var orderNumber = string.Empty;

                    //* Step 2: Add a new Order and get its orderNo *//
                    {
                        orderNumber = AddOrderFuncWithCurrentLocation();
                    }

                    //* Step 3: Add equipment to order in Rental Order Screen *//
                    {
                        AddEquipmentToRentalOrder(equipmentCode, orderNumber);
                    }

                    //* Step 4: checkout equipment related to order in  Rental Order Screen *//
                    {
                        CheckOutNoncodeEquipment();
                    }

                    //* Step 5: checkin of equipment Noncode checkouted in Rental Order Screen *//
                    {
                        CheckInNoncode();
                    }

                    //* Step 6: Bill this Order *//
                    {
                        BillOrder();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]  //help file: Visio/OrderProcessing/OrderProcessingScreen/ValidateEquipmentBarcodePrinting.vsdx
        public void ValidateEquipmentBarcodePrinting_Business()
        {
            TestInitialize(nameof(ValidateEquipmentBarcodePrinting_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string equipmentCode = string.Empty, barcode = string.Empty;

                    /* Step 1 :get a barcode equipment and add a barcode item to it*/
                    {
                        Login();
                        equipmentCode = GetRandomBarcodeEquipment();
                    }
                    /* Step 2 :Add a barcode item to Equipment*/
                    {
                        barcode = AddBarcodeItemToEquipment(equipmentCode);
                    }
                    /* Step 3 :Validate Equipment Barcode Printing*/
                    {
                        ValidateEquipmentBarcodePrinting(equipmentCode);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }


        private void ValidateEquipmentBarcodePrinting(string equipmentCode)
        {
            GoToUrl("MMInventory", "EquipmentList", gotoLogin: false);
            SearchAndEditClick(equipmentCode);

            //click on post Btn
            webElementAction.GetElementByCssSelector(".icon-tick").Click();

            var actionMenu = webElementAction.GetElementByCssSelector(
                "[data-focus-lock-disabled='false'] #ACTION_TOOL_DROPDOWN .tools-box-dropdown-toggle");
            actionMenu.Click();

            var addNewBarcodeSubMenu = ObjectRepository.Driver.FindElements(By.TagName("li"))
                .Where(o => o.GetAttribute("data-menu-id").Contains("ADD_BARCODED_ITEMS")).FirstOrDefault();
            addNewBarcodeSubMenu.Click();

            var quantityToAddInput = webElementAction.GetInputElementByDataFormItemNameInDiv("quantityToAdd");
            quantityToAddInput.SendKeys("1");

            var purchaseAmountInput = webElementAction.GetInputElementByDataFormItemNameInDiv("purchaseAmount");
            purchaseAmountInput.SendKeys("1");

            // Uncheck Print option
            webElementAction.DeSelectingCheckbox("printBarcodes");

            //click on addToRentalBarcodeList
            var addToRentalBarcodeListBtn =
                webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm");
            addToRentalBarcodeListBtn.Click();
        }

        private static void SetCheckinType(string checkInType)
        {
            var checkinTypeInput = webElementAction.GetElementByCssSelector(".checkin-type-select")
                .FindElement(By.TagName("input"));
            checkinTypeInput.SendKeys(checkInType);
            webElementAction
                .GetElementByCssSelector("[title='" + checkInType + "'] > .ant-select-item-option-content").Click();
        }

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
        public void CheckInLossBarcodeEquipmentAndBilling_Business()
        {
            TestInitialize(nameof(CheckInLossBarcodeEquipmentAndBilling_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    CompleteRentalProcess(CheckinType.Loss);
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime * 2)]
        public void CheckInSwapBarcodeEquipmentAndBilling_Business()
        {
            TestInitialize(nameof(CheckInSwapBarcodeEquipmentAndBilling_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string equipmentCode = string.Empty;
                    string barcode1 = string.Empty;
                    string barcode2 = string.Empty;

                    /* Step 1: get a barcode equipment and add a barcode item to it*/
                    {
                        GoToUrl("MMInventory", "EquipmentList");

                        if (CurrentUrlIsMultiLocation())
                        {
                            RefreshAllRows("currencyId");
                        }
                        else
                        {
                            RefreshAllRows();
                        }

                        ShowAllRedord();
                        var barcodeFilterElement = webElementAction
                            .GetElementByCssSelector("[col-id='barcodedOnly'][role='columnheader']")
                            .FindElement(By.CssSelector(".ag-header-cell-menu-button"));
                        barcodeFilterElement.Click();

                        var sortDescendingElement =
                            webElementAction.GetElementByCssSelector(".ag-menu-list > div:nth-of-type(3)");
                        sortDescendingElement.Click();

                        //equipment Code In firstRow with barcode
                        Thread.Sleep(2000);
                        equipmentCode = ObjectRepository.Driver
                            .FindElements(By.CssSelector("[col-id='id'][role='gridcell']"))
                            .First().Text;
                    }

                    /* Step 2: Add a barcode (#1) item to the equipment*/
                    {
                        barcode1 = AddBarcodeItemToEquipment(equipmentCode);
                    }

                    var orderNumber1 = string.Empty;

                    //* Step 3: Add a new Order (#1) and get its orderNo *//
                    {
                        orderNumber1 = AddOrderFuncWithCurrentLocation();
                    }

                    //* Step 4: Add equipment to order (#1) in Rental Order Screen *//
                    {
                        AddEquipmentToRentalOrder(equipmentCode, orderNumber1);
                    }

                    //* Step 5: checkout equipment related to order (#1) in  Rental Order Screen *//
                    {
                        CheckOutBarcode(barcode1);
                    }

                    var orderNumber2 = string.Empty; // for SWAP checkin type 
                                                     //* Step 6: Add a new Order (#2) and get its orderNo
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
                        orderNumber2 = AddOrderFuncWithCurrentLocation(callFromOrderProcessingScreen: true);
                    }

                    //* Step 7: add barcode (#2) to the same equipment related to Order (#2)
                    {
                        GoToUrl("MMInventory", "EquipmentList", gotoLogin: false);
                        barcode2 = AddBarcodeItemToEquipment(equipmentCode);
                    }

                    //* Step 8: Add equipment to order (#2) in Rental Order Screen *//
                    {
                        AddEquipmentToRentalOrder(equipmentCode, orderNumber2);
                    }

                    //* Step 9: Add a barcode (#2) item to the equipment
                    {
                        CheckOutBarcode(barcode2);
                    }

                    //* Step 10: checkin of equipment Barcode checkouted in Rental Order Screen Page *//
                    {
                        CheckInBarcode(barcode1, CheckinType.Swap, barcodeForSwap: barcode2);
                    }

                    //* Step 11: Bill Order (#2) in Rental Order Screen Page *//
                    {
                        BillOrder();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]   //help file: Visio/OrderProcessing/OrderProcessingScreen/CheckInNormalBarcodeEquipmentAndBilling.vsdx
        public void CheckInDamageBarcodeEquipmentAndBilling_Business()
        {
            TestInitialize(nameof(CheckInDamageBarcodeEquipmentAndBilling_Business));
            //    while (!testPassed && retryCount < maxRetries)
            //        try
            //        {
            CompleteRentalProcess(CheckinType.Damage);
            testPassed = true;
            //        }
            //        catch (Exception ex)
            //        {
            //            HandleTestFailure(ex.Message);
            //        }
        }

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime * 2)] //help file: Visio/OrderProcessing/OrderProcessingScreen/CheckInTransferBarcodeEquipmentAndBilling.vsdx
        public void CheckInTransferBarcodeEquipmentAndBilling_Business()
        {
            TestInitialize(nameof(CheckInTransferBarcodeEquipmentAndBilling_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    var orderNumberForTransfer = string.Empty; // for transfer checkin type 

                    //* Step 1: Add a new Order (orderNumberForTransfer) and get its orderNo
                    {
                        Login();
                        orderNumberForTransfer = AddOrderFuncWithCurrentLocation();
                        Console.WriteLine("Step 1 passed: Add a new Order (orderNumberForTransfer) and get its orderNo");
                    }

                    string equipmentCode = string.Empty;
                    string barcode = string.Empty;

                    /* Step 2: get a barcode equipment */
                    {
                        equipmentCode = GetRandomBarcodeEquipment();
                        Console.WriteLine("Step 2 passed: get a barcode equipment");
                    }

                    /* Step 3: Add a barcode item to the equipment*/
                    {
                        barcode = AddBarcodeItemToEquipment(equipmentCode);
                        Console.WriteLine("Step 3 passed: Add a barcode item to the equipment");
                    }

                    var orderNumber = string.Empty;

                    //* Step 4: Add a new Order (#1) and get its orderNo *//
                    {
                        orderNumber = AddOrderFuncWithCurrentLocation();
                        Console.WriteLine("Step 4 passed:Add a new Order (#1) and get its orderNo");
                    }

                    //* Step 5: Add equipment to order (#1) in Rental Order Screen *//
                    {
                        AddEquipmentToRentalOrder(equipmentCode, orderNumber);
                        Console.WriteLine("Step 5 passed: Add equipment to order (#1) in Rental Order Screen");
                    }

                    //* Step 6: checkout equipment related to order (#1) in  Rental Order Screen *//
                    {
                        CheckOutBarcode(barcode);
                        Console.WriteLine("Step 6 passed: checkout equipment related to order (#1) in  Rental Order Screen");
                    }
                    //* Step 7: checkin of equipment Barcode checkouted in Rental Order Screen Page *//
                    {
                        CheckInBarcode(barcode, CheckinType.Transfer, orderToTransfer: orderNumberForTransfer);
                        Console.WriteLine("Step 7 passed: checkin of equipment Barcode checkouted in Rental Order Screen Page");
                    }

                    //* Step 8: Bill Order (#1) in Rental Order Screen Page *//
                    {
                        BillOrder();
                        Console.WriteLine("Step 8 passed: Bill Order (#1) in Rental Order Screen Page");
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        public string GetRandomBarcodeEquipment(bool gotoLogin = false)
        {
            GoToUrl("MMInventory", "EquipmentList", gotoLogin: gotoLogin);
            RefreshAllRows(filterId: "currencyId");
            ShowAllRedord();
            FindColumnInMainGrid("Barcoded Only");
            var barcodeFilterElement = webElementAction
                .GetElementByCssSelector("[col-id='barcodedOnly'][role='columnheader']")
                .FindElement(By.CssSelector(".ag-header-cell-menu-button"));
            barcodeFilterElement.Click();

            var sortDescendingElement =
                webElementAction.GetElementByCssSelector(".ag-menu-list > div:nth-of-type(3)");
            sortDescendingElement.Click();

            FindColumnInMainGrid("Code");
            //equipment Code In firstRow with barcode
            Thread.Sleep(2000);

            var equipmentCode = ObjectRepository.Driver
                 .FindElements(By.CssSelector("[col-id='id'][role='gridcell']"))
                 .First().Text;
            return equipmentCode;
        }

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)] //help file: Visio/OrderProcessing/OrderProcessingScreen/CheckInNormalBarcodeEquipmentAndBilling.vsdx
        public void CheckInNoChargeBarcodeEquipmentAndBilling_Business()
        {
            TestInitialize(nameof(CheckInNoChargeBarcodeEquipmentAndBilling_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    CompleteRentalProcess(CheckinType.NoCharge);
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        public void ValidateAddedBarcodeExistenceInGridList(string barcode, string gridId)
        {
            var GridItems = webElementAction.GetElementById(gridId);
            var colIds = GridItems.FindElements(By.CssSelector(".ag-body-viewport [col-id]"));
            if (colIds.FirstOrDefault(o => o.Text == barcode) == null)
            {
                throw new Exception("The added barcode (" + barcode + ") is not displayed in the grid (" + gridId + ").");
            }
        }

        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)] //help file: Visio/OrderProcessing/OrderProcessingScreen/CheckInNormalBarcodeEquipmentAndBilling.vsdx
        public void MassCheckoutNoncoded_Business()
        {
            TestInitialize(nameof(MassCheckoutNoncoded_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string nonCodeEquipmentCode = string.Empty;
                    string nonCodeItem = string.Empty;

                    var orderNumber = string.Empty;

                    /* Step 1 :get a noncode equipment and add a noncode item to it*/
                    {
                        nonCodeEquipmentCode = GetRandomNoncodeEquipment();
                        AddNonCodeItemToEquipment(nonCodeEquipmentCode);
                    }

                    //* Step 3: Add a new Order and get its orderNo *//
                    {
                        orderNumber = AddOrderFuncWithCurrentLocation();
                    }

                    //* Step 5: Add equipment to order in Rental Order Screen *//
                    {
                        AddEquipmentToRentalOrder(nonCodeEquipmentCode, orderNumber);
                    }

                    string insertedQuantityInMassCheckout;
                    //Step 6: Mass checkout Noncoded
                    {
                        insertedQuantityInMassCheckout = MassCheckoutNoncoded(quantityCheckout: "1");
                    }

                    // Step 7: Validate mass In order items grid and checkout items grid
                    {
                        ValidateMassCheckout(insertedQuantityInMassCheckout, nonCodeEquipmentCode);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private string MassCheckoutNoncoded(string quantityCheckout)
        {
            // Navigate to the Order Processing screen
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_CHECKOUT");
            GoToSubMenu("CHECKOUT_DROPDOWN", "MASS_CHECKOUT_NONCODED");

            // Find and interact with the quantity element
            IWebElement quantityElement = webElementAction.GetColumnInDefaultGridRow("quantity");
            webElementAction.DoubleClick(quantityElement);

            IWebElement quantityInput = quantityElement.FindElement(By.TagName("input"));
            quantityInput.SendKeys(quantityCheckout);
            quantityCheckout = quantityInput.GetAttribute("value");

            // Click the "Update and Exit" button
            webElementAction.ClickOnPostBtnInMinGrid(gridId: "massCheckoutNoncoded-gridId");
            webElementAction.GetElementByCssSelector(".cancel-button span").Click();
            ConfirmBtnCheck(dataSection: "confirmDialog");
            SetUserInUserStampModal();
            return quantityCheckout;
        }

        public void SetUserInUserStampModal(string userCode = null)
        {
            if (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='ENTER_USER_CODE']")))
            {
                var enterUserCodeModal = webElementAction.GetElementBySpecificAttribute("data-modal-title", "ENTER_USER_CODE");
                var userStampContext = enterUserCodeModal.FindElements(By.CssSelector(".combo-auto-complete"));
                if (string.IsNullOrEmpty(userCode))
                {
                    new WebElementDataGenerator().ComboAutoCompleteGenerator(userStampContext, searchFiter: userCode);
                }
                else
                {
                    new WebElementDataGenerator().ComboAutoCompleteGenerator(userStampContext);
                }
                webElementAction.Click(By.XPath("//span[.='OK']")); //Confirm entered user stup
            }
        }

        public void ValidateMassCheckout(string insertedQuantityInMassCheckout, string nonCodeEquipmentCode)
        {
            ValidateQtyOutInRentalCheckoutScreen(insertedQuantityInMassCheckout);
            ValidateEquipmentInRentalCheckoutGrid(nonCodeEquipmentCode);
            ValidateQuantityInCheckedOutItemsGrid(insertedQuantityInMassCheckout);
            ValidateEquipmentInCheckedOutItemsGrid(nonCodeEquipmentCode);
        }

        private void ValidateQtyOutInRentalCheckoutScreen(string insertedQuantityInMassCheckout)
        {
            WaitForLoadingSpiner();
            // Get the 'qtyOut' element from the default grid row in the 'rentalCheckoutScreen-gridId' grid
            var qtyOutElement = webElementAction.GetColumnInDefaultGridRow("qtyOut", "rentalCheckoutScreen-gridId");

            // Get the text value of the 'qtyOut' element
            string qtyOut = qtyOutElement.Text;

            // Compare the inserted quantity in the mass checkout screen with the saved quantity in the Rental Checkout Screen
            if (qtyOut != insertedQuantityInMassCheckout)
            {
                throw new Exception("Error. The inserted quantity in the mass checkout screen does not match the saved quantity in the Rental Checkout Screen.");
            }
        }


        private void ValidateEquipmentInRentalCheckoutGrid(string nonCodeEquipmentCode)
        {
            var rentalCheckoutGrid = webElementAction.GetElementById("rentalCheckoutScreen-gridId");
            var isEquipmentInRentalCheckoutGrid = rentalCheckoutGrid.FindElements(By.TagName("div"))
                .FirstOrDefault(o => o.GetAttribute("col-id") == "equipmentId" && o.Text == nonCodeEquipmentCode);

            if (isEquipmentInRentalCheckoutGrid == null)
                throw new Exception($"Error. The desired checkout nonCodeEquipmentCode ({nonCodeEquipmentCode}) is not present in the rentalCheckoutGrid.");
        }

        private void ValidateQuantityInCheckedOutItemsGrid(string insertedQuantityInMassCheckout)
        {
            var checkedOutItemsGrid = webElementAction.GetElementById("checkedOutItems-gridId");
            var isCheckoutQuantityInCheckedOutItemsGrid = checkedOutItemsGrid.FindElements(By.TagName("div"))
                .FirstOrDefault(o => o.GetAttribute("col-id") == "quantity" && o.Text == insertedQuantityInMassCheckout);

            if (isCheckoutQuantityInCheckedOutItemsGrid == null)
                throw new Exception($"Error. The desired checkout quantity ({insertedQuantityInMassCheckout}) is not present in the checkedOutItemsGrid.");
        }

        private void ValidateEquipmentInCheckedOutItemsGrid(string nonCodeEquipmentCode)
        {
            var checkedOutItemsGrid = webElementAction.GetElementById("checkedOutItems-gridId");
            var isEquipmentInCheckedOutItemsGrid = checkedOutItemsGrid.FindElements(By.TagName("div"))
                .FirstOrDefault(o => o.GetAttribute("col-id") == "equipmentId" && o.Text == nonCodeEquipmentCode);

            if (isEquipmentInCheckedOutItemsGrid == null)
                throw new Exception($"Error. The desired checkout nonCodeEquipmentCode ({nonCodeEquipmentCode}) is not present in the grid.");
        }

        private string CancelCheckoutWithRightClick()
        {
            throw new NotImplementedException();
        }

        private void CheckoutWithRightClickInRentalCheckoutScreen(string equipmentCode, string quantity)
        {
            // Get the 'qtyOut' element from the default grid row in the 'rentalCheckoutScreen-gridId' grid
            var qtyOutElement = webElementAction.GetColumnInDefaultGridRow("equipmentId", "rentalItems-gridId");
            webElementAction.RighClick(qtyOutElement);

            var CheckoutNoncodedItem = webElementAction.GetElementByXPath("//span[.='Checkout Noncoded']");
            CheckoutNoncodedItem.Click();
            var modalContext = webElementAction.GetElementBySpecificAttribute("data-modal-title", "CHECKOUT_NONCODED");
            var inputQuantity = modalContext.FindElement(By.TagName("input"));
            inputQuantity.SendKeys(quantity);

            ConfirmBtnCheck(dataSection: "modal"); //Checkout Noncoded

            ConfirmBtnCheck(); //Do you want to checkout more than ordered?
        }

        public string AddBarcodeEquipmentWithRequiredFields(bool IsLoginPageRequired)
        {
            GoToUrl("MMInventory", "EquipmentSummaryList", gotoLogin: IsLoginPageRequired);
            Thread.Sleep(2000);
            RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                                                     //click on addNewRecordBtn
            webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

            webElementAction.ClickOnPostChanges();
            Thread.Sleep(2000);
            var Contextmain = GetFormLeftSideContext(true);
            new WebElementDataGenerator(Contextmain);
            // Guaranteeing the filling of the department and category
            ////while (webElementAction.GetElementByCssSelector("[data-form-item-name='departmentId'] .code-container", Contextmain).Text.Trim().IsNullOrEmpty()
            ////        || webElementAction.GetAllElementsByCssSelector("[data-form-item-name='categoryId'] .code-container", Contextmain).First().Text.Trim().IsNullOrEmpty())
            ////{
            //    Contextmain = GetFormLeftSideContext(true);
            //    // write data random in fields main
            //    new WebElementDataGenerator(Contextmain);
            //}

            webElementAction.DeSelectingCheckbox("inactive");

            Thread.Sleep(2000);
            /*------------------------PRICING GL Section------------------------------*/
            ClickTab("PRICING_GL");

            var pricingGLContex = webElementAction.GetElementByCssSelector(".tab-content[data-tab-name='PRICING_GL'] .row-division");
            new WebElementDataGenerator(pricingGLContex);

            //If equipment has an RFID checkbox, we cannot add a barcode to it.
            DeSelectingRFIDCheckboxForEquipment();
            SelectingInventoryCheckboxForEquipment();

            ClickTab("GENERAL");
            webElementAction.GenerateDataToRequiredFields(context: GetTabContext("GENERAL"));

            string equipmentId = webElementAction.GetInputElementByDataFormItemNameInDiv("id").GetAttribute("value");
            SaveAndConfirmCheck();
            return equipmentId;
        }

        string[] userCodes;
        public string[] GetFirstActiveUsers(int userCount)
        {
            GoToUrl("Administration", "UserSetup", gotoLogin: false);
            DataLegendNameFilter("ACTIVE");

            //equipment Code In firstRow with barcode
            Thread.Sleep(2000);
            userCodes = ObjectRepository.Driver
                 .FindElements(By.CssSelector("[col-id='id'][role='gridcell']"))
                 .Take(userCount).Select(o => o.Text).ToArray();
            return userCodes;
        }
    }

    //[TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)] //help file: Visio/OrderProcessing/OrderProcessingScreen/CheckInNormalBarcodeEquipmentAndBilling.vsdx
    //public void CheckouAndCancelCheckoutNoncodedWithRightClick_Business()
    //{
    //    TestInitialize(nameof(CheckouAndCancelCheckoutNoncodedWithRightClick_Business));

    //    //while (!testPassed && retryCount < maxRetries)
    //    //    try
    //    //    {
    //    string nonCodeEquipmentCode = string.Empty;
    //    string nonCodeItem = string.Empty;

    //    var orderNumber = string.Empty;

    //    /* Step 1 :get a noncode equipment and add a noncode item to it*/
    //    {
    //        nonCodeEquipmentCode = GetRandomNoncodeEquipment();
    //        AddNonCodeItemToEquipment(nonCodeEquipmentCode);
    //    }

    //    //* Step 3: Add a new Order and get its orderNo *//
    //    {
    //        orderNumber = AddOrderFuncWithCurrentLocation();
    //    }

    //    //* Step 5: Add equipment to order in Rental Order Screen *//
    //    {
    //        AddEquipmentToOrder(nonCodeEquipmentCode, orderNumber);
    //    }

    //    string quantityCheckout = "1";
    //    //Step 6: Checkout With RightClick In Rental Checkout Screen
    //    {
    //        CheckoutWithRightClickInRentalCheckoutScreen(nonCodeEquipmentCode, quantityCheckout);
    //    }

    //    //Step 6: Validate Checkouted item In order items grid and checkout items grid
    //    {
    //        //ValidateMassCheckout(nonCodeEquipmentCode);
    //    }
    //    // Step 7: Validate mass In order items grid and checkout items grid
    //    {

    //    }
    //    testPassed = true;
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    HandleTestFailure(ex.Message);
    //    //}
    //}
}
