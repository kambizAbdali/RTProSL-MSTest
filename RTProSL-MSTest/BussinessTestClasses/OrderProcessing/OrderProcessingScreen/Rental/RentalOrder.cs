using OpenQA.Selenium;
using RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen.Sales;
using RTProSL_MSTest.ComponentHelper;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using static RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen.EquipmentCheckOutInAndBilling;
using SeleniumWebdriver.ComponentHelper;
using MSTestProject.ComponentHelper;
using OpenQA.Selenium.Interactions;
using RTProSL_MSTest.TestClasses.PurchaseOrder.Subrental;

namespace RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen.Rental
{
    [TestClass]
    public class RentalOrder : Order
    {
        public RentalOrder()
        {
            equipmentCheckOutInAndBilling = new EquipmentCheckOutInAndBilling();
        }
        private EquipmentCheckOutInAndBilling equipmentCheckOutInAndBilling;
        [TestMethod, Timeout(MaximumExecutionTime * 2)]
        public void SaveRentalAsKitInRentalOrder_Business() // related to Rental order
        {
            TestInitialize(nameof(SaveRentalAsKitInRentalOrder_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string equipmentCode = string.Empty;
                    string barcode = string.Empty;

                    /* Step 1 :get a barcode equipment and add a barcode item to it*/
                    {
                        Login();
                        equipmentCode = equipmentCheckOutInAndBilling.GetRandomBarcodeEquipment();
                    }
                    /* Step 2 :Add a barcode item to equipment*/
                    {
                        barcode = equipmentCheckOutInAndBilling.AddBarcodeItemToEquipment(equipmentCode);
                    }
                    var orderNumber = string.Empty;

                    //* Step 3: Add a new Order and get its orderNo *//
                    {
                        orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }

                    //* Step 4: Add equipment to order in Rental Order Screen *//
                    {
                        equipmentCheckOutInAndBilling.AddEquipmentToRentalOrder(equipmentCode, orderNumber);
                    }

                    string kitCode;
                    /* Step 5: Save As Kit*/
                    {
                        kitCode = SaveRentalAsKit();
                    }

                    /* Step 6: Vaidate inserted rental Kit In rental Kit List*/
                    {
                        VaidateInsertedRentalKitAndStockInKitList(kitCode, equipmentCode);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private string SaveRentalAsKit()
        {
            GoToSubMenu("ACTION_TOOL_DROPDOWN", "KIT", "SAVE_AS_KIT");

            ConfirmBtnCheck(dataSection: "modal");
            var saveAsNewKitForm = webElementAction.GetElementByCssSelector(".advance-left-section");
            webElementAction.GenerateDataToRequiredFields(context: saveAsNewKitForm);
            string kitCode = webElementAction.GetElementByName("kitCode").GetAttribute("value");
            ConfirmBtnCheck(dataSection: "modal");
            return kitCode;
        }

        private void VaidateInsertedRentalKitAndStockInKitList(string kitCode, string equipmentCode)
        {
            WaitForLoadingSpiner();
            GoToUrl("MMInventory", "RentalKitList", gotoLogin: false);
            RefreshAllRows();
            var kitListGrid = webElementAction.GetElementById("RentalKitList-gridId");

            FindColumnInMainGrid(ColumnValue: "Code", gridId: "RentalKitList-gridId");
            Thread.Sleep(100);
            var kitCodeElement = kitListGrid.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == kitCode);
            if (kitCodeElement == null)
                throw new Exception("The kitCode inserted in the kit list page was not found !!!");
            webElementAction.DoubleClick(kitCodeElement);
            WaitForLoadingSpiner();
            var RentalKitDetailGrid = webElementAction.GetElementById("RentalKitDetail-gridId");

            FindColumnInMainGrid(ColumnValue: "Equipment");

            var rentalEquipmentElement = RentalKitDetailGrid.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == equipmentCode);
            if (rentalEquipmentElement == null)
                throw new Exception("The rental equipment Code inserted in the rental kit detail screen was not found !!!");
        }

        //When we want to order a set of related or interconnected equipment such as a TV, a remote control, and TV remote batteries.
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void CopyFromAKitInRentalOrder_Business() // related to rental order
        {
            TestInitialize(nameof(CopyFromAKitInRentalOrder_Business));

            string equipmentCode = string.Empty;
            string barcode = string.Empty;
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1 :get an equipment from equipment list*/
                    {
                        GoToUrl("MMInventory", "EquipmentList");
                        RefreshAllRows();  // location: canada (by default)
                        ShowAllRedord();
                        var barcodeFilterElement = webElementAction.GetElementByCssSelector("[col-id='barcodedOnly'][role='columnheader']")
                                        .FindElement(By.CssSelector(".ag-header-cell-menu-button"));
                        barcodeFilterElement.Click();

                        var sortDescendingElement = webElementAction.GetElementByCssSelector(".ag-menu-list > div:nth-of-type(3)");
                        sortDescendingElement.Click();

                        //equipment Code In firstRow with barcode
                        Thread.Sleep(2000);
                        equipmentCode = ObjectRepository.Driver.FindElements(By.CssSelector("[col-id='id'][role='gridcell']"))
                            .First().Text;
                    }

                    string orderNumber = default;

                    //* Step 2: Add a new Order and get its orderNo *//
                    {
                        orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }

                    //* Step 3: Add equipment to order in Rental Order Screen *//
                    {
                        equipmentCheckOutInAndBilling.AddEquipmentToRentalOrder(equipmentCode, orderNumber);
                    }

                    string kitCode;
                    /* Step 4: Add Rental Kit List*/
                    {
                        kitCode = AddKitList(OrderType.Rental);
                    }

                    /* Step 5: Copy From a Kit*/
                    {
                        CopyFromAKit(kitCode, OrderType.Rental);
                    }

                    /* Step 6: Vaidate inserted rental Kit In rental KitList*/
                    {
                        //note: Due to the large grid-list, kit code needs to be left-aligned for visibility.
                        VaidateInsertedKit(kitCode, OrderType.Rental);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void SaveAsRentalTruck_Business() // related to Rental order
        {
            string equipmentCode = string.Empty;
            TestInitialize(nameof(SaveAsRentalTruck_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1 :get an equipment from equipment list*/
                    {
                        Login();
                        equipmentCode = equipmentCheckOutInAndBilling.GetRandomBarcodeEquipment();
                    }

                    string orderNumber = default;

                    //* Step 2: Add a new Order and get its orderNo *//
                    {
                        orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }

                    //* Step 3: Add equipment to order in Rental Order Screen *//
                    {
                        equipmentCheckOutInAndBilling.AddEquipmentToRentalOrder(equipmentCode, orderNumber);
                    }

                    string truckCode = default;
                    /* Step 4: Save As Rantal Truck*/
                    {
                        //note: Due to the large grid-list, truck number needs to be left-aligned for visibility.
                        truckCode = SaveAsOrderTruck(OrderType.Rental);
                    }

                    /* Step 5: Vaidate inserted rental truck In rental truck List*/
                    {
                        VaidateInsertedRentalTruckInRentalTruckList(truckCode);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        public void VaidateInsertedRentalTruckInRentalTruckList(string truckCode)
        {
            WaitForLoadingSpiner();
            GoToUrl("MMInventory", "RentalTruckList", gotoLogin: false);
            if (CurrentUrlIsMultiLocation())
                RefreshAllRows();
            ClearAllTagList();
            var rentalTruckListGrid = webElementAction.GetElementById("RentalTruckList-gridId");

            var truckCodeElement = rentalTruckListGrid.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == truckCode);
            if (truckCodeElement == null)
                throw new Exception("The truckCode inserted in the truck list page was not found !!!");
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void AddRentalTruckInRentalOrderScreen()
        {
            TestInitialize(nameof(AddRentalTruckInRentalOrderScreen));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    //* Step 1: Add a new Order*//
                    {
                        Login();
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }

                    var truckCode = string.Empty;
                    //* Step 2: Add a new Order truck *//
                    {
                        NavigateToOrderProcessingScreen();
                        truckCode = AddOrderTruck(OrderType.Rental);
                    }

                    /* Step 3: Vaidate inserted rental truck In Rental Order Screen*/
                    {
                        VaidateInsertedRentalTruckInRentalOrderScreen(truckCode);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void VaidateInsertedRentalTruckInRentalOrderScreen(string truckCode)
        {
            WaitForLoadingSpiner();
            string gridId = "rentalItems-gridId";

            FindColumnInMainGrid(ColumnValue: "Truck", gridId: gridId);
            WaitForLoadingSpiner();
            Thread.Sleep(2000);//Please doesn't change this
            var rentalItemsGrid = webElementAction.GetElementById(gridId);

            var truckCodeElement = rentalItemsGrid.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == truckCode);
            if (truckCodeElement == null)
                throw new Exception("Error:__The truckCode inserted in the truck list page was not found !!!");

        }

        //[TestMethod, Timeout(MaximumExecutionTime)]
        //public void AddTemporaryKit_Business()
        //{
        //    TestInitialize(nameof(AddTemporaryKit_Business));

        //    while (!testPassed && retryCount < maxRetries)
        //        try
        //        {
        //            //* Step 1: 
        //            {
        //                GoToLogin();
        //                // NavigationHelper.NavigateToUrl("http://192.168.1.153:7089/rental-order?orderNo=100919");

        //                var sss = webElementAction.GetElementByCssSelector(".ag-center-cols-container[role='rowgroup'] > [aria-rowindex='5'] > [aria-colindex='4']");
        //                Thread.Sleep(5000);

        //                InputSimulator simulator = new InputSimulator();

        //                // Simulate clicking action or any other actions you want to perform in the first second
        //                // For example, you can simulate a mouse click using simulator.Mouse.LeftButtonClick();
        //                Thread.Sleep(1000);


        //                Thread.Sleep(1000);

        //                // Simulate pressing and holding the Ctrl key
        //                simulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.CONTROL);
        //                for (int i = 0;i<20;i++)
        //                {
        //                    simulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.CONTROL);
        //                    Thread.Sleep(200);
        //                    sss.Click();
        //                }

        //                // ساختن یک instance از Actions
        //                Actions actions = new Actions(ObjectRepository.Driver);

        //                // انجام کلیک راست موس
        //                actions.ContextClick(sss).Build().Perform();
        //                // Wait for 2 seconds
        //                Thread.Sleep(4000);
        //                sss.Click();
        //                // Release the Ctrl key
        //                simulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.CONTROL);
        //            }
        //            testPassed = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            HandleTestFailure(ex.Message);
        //        }
        //}


        [TestMethod, Timeout(MaximumExecutionTime)]
        public void RemoveKitFromOrder()
        {
            TestInitialize(nameof(RemoveKitFromOrder));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    //* Step 1: Add a new Order*//
                    {
                        Login();
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }

                    string kitCode;
                    /* Step 2: Add Rental Kit List*/
                    {
                        kitCode = AddKitList(OrderType.Rental);
                    }

                    /* Step 3: Copy From a Kit*/
                    {
                        CopyFromAKit(kitCode, OrderType.Rental);
                    }

                    /* Step 4: delete kit*/
                    {
                        DeleteKit(kitCode);
                    }

                    /* Step 5: Validate deleted kit code in Rental Items*/
                    {
                        ValidateDeletedKitInRentalItems(kitCode);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void ValidateDeletedKitInRentalItems(string kitCode)
        {
            var GridItems = webElementAction.GetElementById("rentalItems-gridId");
            var colIds = GridItems.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
            if (colIds.FirstOrDefault(o => o.Text == kitCode) != null)
            {
                throw new Exception("The deleted kit code is displayed in the grid.");
            }
        }

        private void DeleteKit(string kitCode)
        {
            GoToSubMenu("ACTION_TOOL_DROPDOWN", "REMOVE_KIT");
            var RemovekitForm = webElementAction.GetElementByCssSelector(".advance-left-section");
            var kitCodeContext = RemovekitForm.FindElements(By.CssSelector(".combo-auto-complete"));
            new WebElementDataGenerator().ComboAutoCompleteGenerator(kitCodeContext, kitCode); //generate data to Vendor
            webElementAction.GetInputElementByDataFormItemNameInDiv("newQuantity").SendKeys("1");
            ConfirmBtnCheck(dataSection: "modal");
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateQuarantineNotesInRepairListAndBarcodeQuarantineList_Business() //feature number 44 release New Features 07-07-2024(2)
        {
            TestInitialize(nameof(ValidateQuarantineNotesInRepairListAndBarcodeQuarantineList_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string equipmentCode = string.Empty;
                    string barcode = string.Empty;
                    string QuarantineNote = string.Empty;

                    /* Step 1 :get a barcode equipment and add a barcode item to it*/
                    {
                        Login();
                        equipmentCode = equipmentCheckOutInAndBilling.GetRandomBarcodeEquipment();
                    }
                    /* Step 2 :Add a barcode item to equipment*/
                    {
                        barcode = equipmentCheckOutInAndBilling.AddBarcodeItemToEquipment(equipmentCode: equipmentCode);
                    }
                    /* Step 3 :Go to Page "Rental Inventory" and search barcode*/
                    {
                        GoToUrl("MMInventory", "RentalInventory", gotoLogin: false);
                        RefreshAllRows();
                        FindAndDoubleClickRowByBarcode(barcode: barcode);
                    }
                    /* Step 4 :Click "'Action' -> 'Send Barcode Tool DropDown'" and generate "Quarantine Notes" confirm */
                    {
                        Thread.Sleep(1000);
                        QuarantineNote = GenerateDataToModalRepairTicket();
                        HandleErrorDialog();
                    }
                    /* Step 5 :Again go to Page "Rental Inventory" and search barcode , click "'Action' -> 'Send Barcode Tool DropDown'" and generate "Quarantine Notes" confirm*/
                    {
                        GoToUrl("MMInventory", "RentalInventory", gotoLogin: false);
                        FindAndDoubleClickRowByBarcode(barcode: barcode);
                        GenerateDataToModalRepairTicket();
                        try
                        {
                            HandleErrorDialog(isCheck: true);
                        }
                        catch
                        {
                            /*ignored*/
                        }
                    }
                    /* Step 6 :Go to page "Barcode Quarantine List" and check Quarantine Notes */
                    {
                        GoToUrl("MMInventory", "BarcodeQuarantineList", gotoLogin: false);
                        RefreshAllRows();
                        CheckQuarantineNoteInBarcodeQuarantineList(barcode: barcode, expectedQuarantineNote: QuarantineNote);
                    }
                    /* Step 7 :CheckOutBarcode */
                    {
                        equipmentCheckOutInAndBilling.CheckOutBarcode(barcode: barcode);
                    }
                    /* Step 8 :CheckOutBarcode */
                    {
                        try
                        {
                            equipmentCheckOutInAndBilling.CheckInBarcode(barcode: barcode, checkinType: CheckinType.Normal);
                        }
                        catch
                        {
                            /*ignored*/
                        }
                    }
                    /* Step 9 :Check Alert Dialog*/
                    {
                        HandleAlertDialog("Quarantine Note:");
                    }

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private static void FindAndDoubleClickRowByBarcode(string barcode)
        {
            Thread.Sleep(1000);
            SearchTextInMainGrid(barcode);

            Thread.Sleep(1000);

            var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                .FirstOrDefault(o => o.Text == barcode.Trim());

            if (selectRow != null)
                webElementAction.DoubleClick(selectRow);
            else // Handle the situation when the element matching is not found  
                Assert.Fail($"No row found with barcode: {barcode}");
        }

        private string GenerateDataToModalRepairTicket()
        {
            Thread.Sleep(1000);

            GoToSubMenu("ACTION_TOOL_DROPDOWN", "SEND_BARCODE_TO_REPAIR_UPON_RETURN");

            Thread.Sleep(1000);

            WaitForLoadingSpiner();

            var dataFormItemName = webElementAction.GetElementBySpecificAttribute("data-form-item-name",
                "enterDamageDescription");

            new WebElementDataGenerator(dataFormItemName);

            string QuarantineNote = dataFormItemName.Text;

            ConfirmBtnCheck(dataSection: "modal");

            return QuarantineNote;
        }

        private void HandleErrorDialog(bool isCheck = false)
        {
            if (isCheck)
            {
                var errorMessage = webElementAction.GetElementBySpecificAttribute("class", "error-message-dialog")
                    .GetAttribute("innerText");
                if (webElementAction.IsElementPresent(By.CssSelector("[data-section = 'errorDialog']")))
                    if (errorMessage.Contains("Error:"))
                        ConfirmBtnCheck(dataSection: "errorDialog");
                    else
                        CheckErrorDialogBox();
                else
                    Assert.Fail(
                        "Error dialog is not present when it was expected. Please check the application state.");
            }
            else
                ConfirmBtnCheck(dataSection: "infoDialog");
        }

        private void CheckQuarantineNoteInBarcodeQuarantineList(string barcode, string expectedQuarantineNote)
        {
            // Assuming the barcode and quarantine note are passed as arguments  
            Thread.Sleep(500); // Consider using explicit wait instead  

            SearchTextInMainGrid(barcode);

            Thread.Sleep(1000);

            var quarantineNoteElements = webElementAction.GetElementById("BarcodeQuarantineList-gridId")
                .FindElements(By.TagName("div"))
                .Where(element => element.GetAttribute("col-id") == "barcodeQuarantineNotes")
                .ToList();

            Thread.Sleep(1000);

            foreach (var noteElement in quarantineNoteElements)
            {
                Thread.Sleep(1000); // Consider using explicit wait instead  
                var actualQuarantineNote = noteElement.GetAttribute("innerText");
                if (!actualQuarantineNote.Contains("Quarantine Notes"))
                    if (!expectedQuarantineNote.Contains(actualQuarantineNote))
                        Assert.Fail(
                            $"The entered Quarantine note '{expectedQuarantineNote}' is not the same as this Quarantine note '{actualQuarantineNote}'.");
                    else
                        break;
            }
        }

        private void HandleAlertDialog(string errorMessageText)
        {
            var errorMessage = webElementAction.GetElementBySpecificAttribute("class", "alert-message-dialog").GetAttribute("innerText");

            if (errorMessage.Contains(errorMessageText))
                ConfirmBtnCheck(dataSection: "alertDialog");
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRentalAvailabilityCalendarInOrderShorList_Business()  //feature number 12 release New Features 07-07-2024(2)
        {
            TestInitialize(nameof(ValidateRentalAvailabilityCalendarInOrderShorList_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    equipmentCheckOutInAndBilling = new EquipmentCheckOutInAndBilling();

                    string equipmentCode = string.Empty;
                    string barcode = string.Empty;

                    var orderNumber = string.Empty;

                    //* Step 1:----Add a new Order and get its orderNo *//
                    {
                        Login();
                        orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }

                    //* Step 2:----Add equipment to order in Rental Order Screen *//
                    {
                        equipmentCode = equipmentCheckOutInAndBilling.AddBarcodeEquipmentWithRequiredFields(IsLoginPageRequired: false);
                    }

                    //* Step 3:----Add equipment to order in Rental Order Screen *//
                    {
                        equipmentCheckOutInAndBilling.AddEquipmentToRentalOrder(equipmentCode, orderNumber);
                    }

                    //* Step 4:----Go to Rental Availability Calendar----------//

                    string originalWindow = default;
                    {
                        originalWindow = GoToRentalAvailabilityCalendar();
                    }

                    //* Step 5:----Validate Rental Availability Calendar Display-----------*/
                    {
                        ValidateRentalAvailabilityCalendarDisplay(originalWindow);
                    }

                    testPassed = true;

                    string GoToRentalAvailabilityCalendar()
                    {
                        string originalWindow;
                        GoToSubMenu(menu: "VIEW_TOOL_DROPDOWN_2", subMenu: "ORDER_SHORT_LIST");

                        var equipmentCol = webElementAction.GetColumnInDefaultGridRow(columnId: "equipment", gridId: "NoncodedAndBarcodedItems-gridId");
                        webElementAction.RighClick(equipmentCol);

                        originalWindow = ObjectRepository.Driver.CurrentWindowHandle;
                        webElementAction.Click(By.XPath("//span[.='Rental Availability Calendar']"));
                        return originalWindow;
                    }

                    void ValidateRentalAvailabilityCalendarDisplay(string originalWindow)
                    {
                        SwitchDriverToNewWindow(originalWindow);

                        var calendarFrame = webElementAction.GetElementBySpecificAttribute("class", "calendar");

                        var diagramFrame = webElementAction.GetElementBySpecificAttribute("class", "diagram");

                        if (calendarFrame == null || diagramFrame == null)
                            Assert.Fail("Error:___The Rental Availability Calendar page was not displayed.");
                    }
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRentalAvailabilityListInOrderShorList_Business() //feature number 12 release New Features 07-07-2024(2)
        {
            TestInitialize(nameof(ValidateRentalAvailabilityListInOrderShorList_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    equipmentCheckOutInAndBilling = new EquipmentCheckOutInAndBilling();

                    string equipmentCode = string.Empty, barcode = string.Empty;
                    var orderNumber = string.Empty;

                    //* Step 1:----Add a new Order and get its orderNo *//
                    {
                        Login();
                        orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }

                    //* Step 2:----Add Barcode Equipment With Required Fields *//
                    {
                        equipmentCode = equipmentCheckOutInAndBilling.AddBarcodeEquipmentWithRequiredFields(IsLoginPageRequired: false);
                    }

                    //* Step 3:----Add equipment to order in Rental Order Screen *//
                    {
                        equipmentCheckOutInAndBilling.AddEquipmentToRentalOrder(equipmentCode, orderNumber);
                    }

                    //* Step 4:----Go to Rental Availability Calendar----------//
                    {
                        GoToRentalAvailabilityList();
                    }

                    //* Step 5:----Validate Rental Availability List Display-----------*/
                    {
                        //ValidateRentalAvailabilityListDisplay(equipmentCode); //TODO
                    }

                    testPassed = true;

                    void GoToRentalAvailabilityList()
                    {
                        GoToSubMenu(menu: "VIEW_TOOL_DROPDOWN_2", subMenu: "ORDER_SHORT_LIST");

                        var equipmentCol = webElementAction.GetColumnInDefaultGridRow(columnId: "equipment", gridId: "NoncodedAndBarcodedItems-gridId");
                        webElementAction.RighClick(equipmentCol);

                        webElementAction.Click(By.XPath("//span[.='Rental Availability List']"));
                        WaitForLoadingSpiner();
                    }

                    void ValidateRentalAvailabilityListDisplay(string equipmentCode)
                    {
                        SwitchDriverToNewWindow(ObjectRepository.Driver.CurrentWindowHandle);
                        WaitForLoadingSpiner();
                        Thread.Sleep(1000);
                        var IsEquipmentPresentInGrid = IsValuePresentInGrid(gridId: "RentalAvailabilityList-gridId", targetValue: equipmentCode);

                        if (!IsEquipmentPresentInGrid)
                            Assert.Fail("Error:___The equipment code was not displayed in RentalAvailabilityList");
                    }
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        string[] userCodes;
        [TestMethod, Timeout(MaximumExecutionTime * 2)]
        public void ValidateMultiSelectFeatureToUserLookupOnCheckinSheet_Business() // TODO:
        {
            TestInitialize(nameof(ValidateMultiSelectFeatureToUserLookupOnCheckinSheet_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string equipmentCode = string.Empty;
                    string orderNumber = string.Empty;

                    //* Step 1:----Enable Prompt for User ID at Checkout And Checkin checkbox in system setup *//
                    {
                        AllowSelectingPromptForUserIdAtCheckoutAndCheckinInSetup();
                    }

                    //* Step 2:----Extract barcode equipment from equ list *//
                    {
                        equipmentCode = equipmentCheckOutInAndBilling.GetRandomBarcodeEquipment();
                    }

                    //* Step 3:----add two barcode for two user to equipment *//
                    string[] barcodes = new string[2];
                    {
                        barcodes[0] = equipmentCheckOutInAndBilling.AddBarcodeItemToEquipment(equipmentCode);
                        GoToUrl("MMInventory", "EquipmentList", gotoLogin: false);
                        barcodes[1] = equipmentCheckOutInAndBilling.AddBarcodeItemToEquipment(equipmentCode);
                    }

                    //* Step 4:----add new order 
                    orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();

                    //* Step 5:----add equipment to order
                    {
                        equipmentCheckOutInAndBilling.AddEquipmentToRentalOrder(equipmentCode, orderNumber);
                    }
                    //* Step 5.1: Get First Active Users
                    {
                        userCodes = equipmentCheckOutInAndBilling.GetFirstActiveUsers(userCount: 2);
                    }

                    //* Step 6:----Checkout barcode1  and barcode2*//
                    for (int i = 0; i < userCodes.Count(); i++)
                        CheckOutBarcodeByUserStamp(barcodes[i], userCodes[i]);

                    //* Step 7:----Checkin barcode1 for user 1  and barcode2 for user 2*//

                    //* Step 8:----Goto checkout sheet

                    //* Step 9:----Check user exist in multi-auto-grid
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void AllowSelectingPromptForUserIdAtCheckoutAndCheckinInSetup()
        {
            GoToUrl("Administration", "SystemSetup");

            string checkoutUrl = ObjectRepository.Driver.Url + "?path=order-processing";

            NavigationHelper.NavigateToUrl(checkoutUrl);

            WaitForLoadingSpiner();

            ClickOnEditBtn();

            webElementAction.SelectingCheckbox("userOutInPrompt");

            webElementAction.ClickOnPostChanges();
            ConfirmBtnCheck();
        }

        //private void AllowSelectingPromptForUserIdAtCheckoutAndCheckinInSetup()
        //{
        //    GoToUrl("Administration", "SystemSetup");

        //    string checkoutUrl = ObjectRepository.Driver.Url + "?path=order-processing";

        //    NavigationHelper.NavigateToUrl(checkoutUrl);

        //    WaitForLoadingSpiner();

        //    ClickOnEditBtn();


        //                var act = new Actions(ObjectRepository.Driver);
        //                Thread.Sleep(500);
        //                int randomOption = default;
        //                if (options.Count > 4)
        //                {
        //                    randomOption = Convert.ToInt16(RandomValueGenerator.GenerateRandomInt(0, 4));
        //                    act.DoubleClick(options[randomOption]).Perform();
        //                }
        //                else if (options.Count != 0)
        //                {
        //                    act.DoubleClick(options[0]).Perform();
        //                }
        //                else if (options.Count == 0)
        //                {
        //                    var rndWrapper = webElementAction.GetElementBySpecificAttribute("class", "rnd-wrapper");
        //                    var closeBtn =
        //                        webElementAction.GetElementBySpecificAttribute("data-icon-name", "close", rndWrapper);
        //                    closeBtn.Click();
        //                }
        //                break;
        //            }
        //            catch (Exception e)
        //            {
        //                Assert.Fail("Exception error:" + e.Message);
        //            }
        //        }
        //        break;
        //    }
        //}

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateColumnIdsInGridByAllSubrentalRecordsForThisOrder_Business() //feature number 41 release New Features 07-07-2024(2)
        {
            TestInitialize(nameof(ValidateColumnIdsInGridByAllSubrentalRecordsForThisOrder_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1:Add new order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");

                        var orderNumberInput = webElementAction.GetElementByCssSelector("[data-input-name='order_no_input']")
                            .FindElements(By.TagName("input")).First().GetAttribute("value");

                        if (orderNumberInput == null)
                            equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }
                    /* Step 2: Go to subrental order*/
                    {
                        GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_ORDER");

                        GoToSubMenu("SUBRENTAL_TOOL_DROPDOWN", "SUBRENTAL_RECORDS");
                    }
                    /* Step 3:Go to subrental order*/
                    {
                        ExistingValidateAllColumnInGrid();
                    }

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        void ExistingValidateAllColumnInGrid()
        {
            ChangeScreenPageSize(80);

            bool allColumnsPresent = true;

            string[] columnIds = {
                    //Vendor PO
                    "po",
                    "vendorId",
                    "vendorName",
                    //Vendor
                    "listPrice",
                    "discountPercentage",
                    "actualPrice",
                    "daysPerWeek",
                    "extended",
                    "vendLocked",
                    "vendTaxable",
                    "vendorWeeklyExtended",
                    "beginDate",
                    "endDate",
                    "dailyWeekly",
                    //Production
                    "productionListPrice",
                    "productionDiscountPercentage",
                    "productionActualPrice",
                    "productionDaysPerWeek",
                    "productionExtended",
                    "productionListPrice",
                    "productionLocked",
                    "productionBeginDate",
                    "productionEndDate",
                    "productionWeeklyExtended",
                    "productionDailyWeekly",
                    //Note
                    "internalNotes",
                    "productionNotes"
                };
            foreach (var columnId in columnIds)
                if (webElementAction.IsElementPresent(By.CssSelector($"[col-id='{columnId}']")))
                {
                    allColumnsPresent = false;
                    break;
                }
            if (allColumnsPresent)
                Assert.Fail("ColId not found");
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateBarcodeRetirementManagement_Business() //feature number 45 release New Features 07-07-2024(2)
        {
            TestInitialize(nameof(ValidateBarcodeRetirementManagement_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string equipmentCode = string.Empty;
                    string barcode = string.Empty;
                    string department = string.Empty;
                    /* Step 1 :get a barcode equipment and add a barcode item to it */
                    {
                        Login();
                        equipmentCode = equipmentCheckOutInAndBilling.GetRandomBarcodeEquipment();
                    }
                    /* Step 2 :Add a barcode item to equipment */
                    {
                        barcode = equipmentCheckOutInAndBilling.AddBarcodeItemToEquipment(equipmentCode: equipmentCode);
                    }
                    /* Step 3 :Go to Page "Rental Inventory" and search barcode */
                    {
                        department = NavigateToEquipmentEntryAndGetDepartment();
                        GoToUrl("MMInventory", "RentalInventory", gotoLogin: false);
                        RefreshAllRows();
                        FindAndDoubleClickRowByBarcode(barcode: barcode);
                    }
                    /* Step 4 :Attach the barcode item */
                    {
                        Thread.Sleep(2000);
                        AttachBarcodeItem(department);
                    }
                    /* Step 5 :Navigate to "Retired Inventory" and retire the item */
                    {
                        RetireBarcodeItem(barcode: barcode);
                    }
                    /* Step 6 :Find message and check text */
                    {
                        HandleAlertDialog(errorMessageText: "Please review the inventory attachment list.");
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        void AttachBarcodeItem(string department)
        {
            webElementAction.Click(By.Id("TOOL_BOX_BARCODE_ATTACHMENT"));
            webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
            Thread.Sleep(2000);

            webElementAction.SetValueToAutoComboCellGrid("equipmentId", department);

            webElementAction.ClickOnPostBtnInMinGrid(gridId: "BarcodeInventoryAttachment-gridId");
        }

        void RetireBarcodeItem(string barcode)
        {
            GoToUrl("MMInventory", "RetiredInventoryScreen", false);

            // Toggle the 'Retired' switch  
            ToggleRetiredSwitch();

            // Handle retirement modal if present  
            HandleRetirementModal();

            // Input barcode and submit  
            var inputField = webElementAction.GetElementByCssSelector(".retired-inventory-screen-right-side > .barcode-scanner-container > .d-flex input");
            inputField.SendKeys(barcode);
            webElementAction.Click(By.CssSelector(".retired-inventory-screen-right-side .d-flex .mainButton"));
        }

        void ToggleRetiredSwitch()
        {
            var switchElements = webElementAction.GetElementByCssSelector(".main-switch").FindElements(By.TagName("button"));
            foreach (var item in switchElements)
                if (item.GetAttribute("innerText") == "Retired")
                {
                    if (!item.GetAttribute("class").Contains("switch-checked-green-color"))
                    {
                        item.Click();
                        break;
                    }
                }
                else
                    switchElements.First(o => o.GetAttribute("innerText") == "Retired" && o.GetAttribute("class") == "defaultColor").Click();
        }

        void HandleRetirementModal()
        {
            if (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='RETIRE_BARCODED_ITEM']")))
            {
                new WebElementDataGenerator(
                    webElementAction.GetElementBySpecificAttribute("data-form-name", "retireBarcodedForm"));
                ConfirmBtnCheck(dataSection: "modal");
            }
        }


        public void CheckOutBarcodeByUserStamp(string barcode, string userStamp)
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

            equipmentCheckOutInAndBilling.SetUserInUserStampModal(userStamp);

            Thread.Sleep(4000);

            if (webElementAction.IsElementPresent(By.CssSelector(".icon-close")))
                webElementAction.Click(By.CssSelector(".icon-close"));

            WaitForLoadingSpiner();
            ConfirmBtnCheck(); //Enter User Code (By default: current user)
            Thread.Sleep(2000); //for insert rental Item and bind data in Checkout Items Grid

            ConfirmBtnCheck(); //Error: Barcode belongs to location 'CANADA'. Do a Quick Transfer and continue with Checkout?
            WaitForLoadingSpiner();
            Thread.Sleep(2000);
            CheckErrorDialogBox();
            equipmentCheckOutInAndBilling.ValidateAddedBarcodeExistenceInGridList(barcode, "checkedOutItems-gridId");
        }
        public string NavigateToEquipmentEntryAndGetDepartment()
        {
            webElementAction.Click(By.CssSelector(".icon-back-history"));
            webElementAction.GetElementByCssSelector(".recent-screens-container")
                .FindElements(By.TagName("a"))
                .FirstOrDefault(o => o.GetAttribute("innerText") == "Equipment Entry Screen")
                .Click();
            Thread.Sleep(1000);
            return webElementAction.GetInputElementByDataFormItemNameInDiv("departmentId").Text;
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateArrowDownUpInformationBox_Business() //feature number 11 release New Features August
        {
            TestInitialize(nameof(ValidateArrowDownUpInformationBox_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string[] allDataInfoName_InformationBox =
                        {
                            "ORDER_NO","PRODUCTION","PRODUCTION_TITLE" //Up
                                ,"JOB_TITLE","PARENT","LOCATION","CONTACT" //all Down
                        };

                    /* Step 1 : go to order processing screen menu rental order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_ORDER");
                    }
                    /* Step 2 : generate with information bax in div*/
                    {
                        // Check if the downward arrow icon is present; if so, click it  
                        if (webElementAction.IsElementPresent(By.CssSelector("[data-section='informationBox'] .icon-colorful-pointer.icon-arrow-down")))
                            webElementAction.Click(By.CssSelector(".icon-colorful-pointer.icon-arrow-down"));

                        // Get all information boxes that match the specified criteria  
                        var allInformationBox = webElementAction.GetElementByCssSelector(".information-box")
                            .FindElements(By.TagName("div"))
                            .Where(o => o.GetAttribute("data-section") == "informationItem")
                            .ToList();

                        // Iterate over each information box to validate the data-info-name attribute against the expected values  
                        foreach (var item in allInformationBox)
                        {
                            // Get the data-info-name attribute of the current item  
                            string dataInfoName = item.GetAttribute("data-info-name");

                            // Initialize a flag to track if the data-info-name matches any expected values  
                            bool isSuccessful = false;

                            // Check if the current data-info-name exists in the expected data names  
                            for (int i = 0; i < allDataInfoName_InformationBox.Length; i++)
                            {
                                // If a match is found, set the flag to true and exit the loop  
                                if (allDataInfoName_InformationBox[i].Contains(dataInfoName))
                                {
                                    isSuccessful = true;
                                    break; // Exit the loop once a match is found  
                                }
                            }

                            // If no match was found, fail the test with an appropriate message  
                            if (!isSuccessful)
                                Assert.Fail("Does not match data info name: " + dataInfoName); // Fail the test if there is a mismatch  
                        }
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        [TestMethod, Timeout(MaximumExecutionTime * 2)]
        public void ImportAndExportInRentalOrder_Business()
        {
            TestInitialize(nameof(ImportAndExportInRentalOrder_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    var orderNumber = string.Empty;
                    var equipmentCode = string.Empty;
                    var fileName = string.Empty;
                    string countGridRentalFirst = default;

                    /*Step 1: Add a new Order and get its orderNo */
                    {
                        Login();
                        orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }
                    /*Step 2:----Add equipment to order in Rental Order Screen */
                    {
                        equipmentCode = equipmentCheckOutInAndBilling.AddBarcodeEquipmentWithRequiredFields(IsLoginPageRequired: false);
                    }
                    /* Step 2: Click clear inputs and send order number and search */
                    {
                        SearchOrderInOrderProcessingScreen(orderNumber);
                    }
                    /* Step 3: Get row count from grid pinned footer first */
                    {
                        AddRentalOrdersRandomly(equipmentCode, orderNumber);
                    }
                    /* Step 4: Click menu Rental, add record with "Rental Item", then export the data  */
                    {
                        fileName = ExportRentalOrderData();
                    }
                    /* Step 6: Click import to upload the data  */
                    {
                        countGridRentalFirst = ImportRentalOrderData(fileName);
                    }
                    /* Step 7: Verify that the total count matches expected value */
                    {
                        VerifyImportResults(int.Parse(countGridRentalFirst));
                    }

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void SearchOrderInOrderProcessingScreen(string orderNumber)
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
            equipmentCheckOutInAndBilling.ClearOrderProcessingFields();
            equipmentCheckOutInAndBilling.FillOrderNumber(orderNumber);
        }

        private void AddRentalOrdersRandomly(string equipmentCode, string orderNumber)
        {
            int randomNumber = int.Parse(RandomValueGenerator.GenerateRandomInt(2, 4));
            string error = "Error: The Stock# must have a value.";
            for (int i = 1; i <= randomNumber; i++)
            {
                equipmentCheckOutInAndBilling.AddEquipmentToRentalOrder(equipmentCode: equipmentCode, orderNumber: orderNumber);
                if (webElementAction.IsElementPresent(By.CssSelector("[data-section='errorDialog']")))
                {
                    var errorMessage = webElementAction.GetElementBySpecificAttribute("class", "error-message-dialog")
                        .GetAttribute("innerText");
                    ConfirmBtnCheck(dataSection: "errorDialog");
                    if (error.Contains(errorMessage))
                        webElementAction.Click(By.CssSelector(".icon-refresh"));
                }
            }
        }

        private string ExportRentalOrderData(bool clickCheckBox = false)
        {
            string fileName = string.Empty;
            Thread.Sleep(500);
            GoToSubMenu(menu: "ACTION_TOOL_DROPDOWN", subMenu: "EXPORT_DATA");

            fileName = RandomValueGenerator.GenerateRandomString(10);
            webElementAction.GetInputElementByDataFormItemNameInDiv("fileName").SendKeys(fileName);
            Thread.Sleep(500);

            if (clickCheckBox)
            {
                webElementAction.SelectingCheckbox(dataFormItemName: "includeCustomerNotes");
                webElementAction.SelectingCheckbox(dataFormItemName: "includeLineItemsPrices");
                webElementAction.SelectingCheckbox(dataFormItemName: "useQuantityShipped");
            }

            ConfirmBtnCheck(dataSection: "modal"); // click modal add new name in file .svc
            ConfirmBtnCheck(dataSection: "infoDialog");

            return fileName;
        }

        private string ImportRentalOrderData(string fileName)
        {
            WaitForLoadingSpiner();
            string countGridSalesFirst = GetRowCountFromGridPinnedFooter(gridId: "rentalItems-gridId").ToString();
            Thread.Sleep(500);
            GoToSubMenu(menu: "ACTION_TOOL_DROPDOWN", subMenu: "IMPORT");
            webElementAction.Click(
                By.CssSelector("[data-icon-name='file']")); // click on open file and find file in .svc
            //upload file to Import modal 
            GenericHelper.SetFileInWindowUploader(fileName: $"{fileName}.csv",
                filePath: Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Downloads"));

            ConfirmBtnCheck(dataSection: "modal"); //click load modal and find modal files

            var elementsNumberBoxTopRead = webElementAction
                .GetElementByCssSelector(".number-boxes-container > div:nth-of-type(1) > .number-box-top")
                .GetAttribute("innerText"); //get text read in modal

            var elementsNumberBoxBottomAdded = webElementAction
                .GetElementByCssSelector(".number-boxes-container > div:nth-of-type(3) > .number-box-top")
                .GetAttribute("innerText"); //get text added in modal

            Thread.Sleep(500);

            ConfirmBtnCheck(dataSection: "modal");
            //check read and added in modal in first count sales

            if (string.Compare(elementsNumberBoxTopRead, countGridSalesFirst) != 0 ||
                string.Compare(elementsNumberBoxBottomAdded, countGridSalesFirst) != 0)
            {
                Assert.Fail(message: $"Error: Does not match {elementsNumberBoxBottomAdded} with {countGridSalesFirst}");
            }
            DeleteAllCSVs();

            return countGridSalesFirst;
        }

        private void VerifyImportResults(int countGridSalesFirst)
        {
            if (GetRowCountFromGridPinnedFooter(gridId: "rentalItems-gridId") != countGridSalesFirst * 2)
                Assert.Fail("Error:__Count in the pinned footer does not match the expected count.");
        }

        private void DeleteAllCSVs()
        {
            //"DeleteCSVFile" deletes all files with the specified extension in the path.
            string[] filesDownload =
                Directory.GetFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Downloads"));

            foreach (string file in filesDownload)
            {
                string[] fileExtension = Path.GetFileName(file).Split('.');
                if (fileExtension[1].Contains("csv")) File.Delete(file);
            }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]//
        public void ReduceQtyOrderedToMatchQtyOutInRentalOrderList_Business()
        {
            TestInitialize(nameof(ReduceQtyOrderedToMatchQtyOutInRentalOrderList_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    var orderNumber = string.Empty;
                    var equipmentCode = string.Empty;
                    var fileName = string.Empty;
                    string countGridRentalFirst = default;

                    /*Step 1: Add a new Order and get its orderNo */
                    {
                        Login();
                        orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }
                    /*Step 2:----Add equipment to order in Rental Order Screen */
                    {
                        equipmentCode = equipmentCheckOutInAndBilling.AddBarcodeEquipmentWithRequiredFields(IsLoginPageRequired: false);
                    }
                    /* Step 2: Click clear inputs and send order number and search */
                    {
                        SearchOrderInOrderProcessingScreen(orderNumber);
                    }
                    /* Step 3: Get row count from grid pinned footer first */
                    {
                        AddRentalOrdersRandomly(equipmentCode, orderNumber);
                    }
                    /* Step 4: Select the row and reduce quantity ordered */
                    {
                        SelectReduceQtyOrdered("Reduce Qty Ordered to Match Qty Out");
                    }

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void SelectReduceQtyOrdered(string namePopup)
        {
            // Click on the currently focused row in the rental items grid.  
            webElementAction.GetElementById("rentalItems-gridId")
                .FindElement(By.CssSelector(".ag-row.ag-row-focus [col-id]")).Click();

            // Select the previous row in the grid using the arrow key (up).  
            NavigateGridSelection(direction: DirectionArrow.Up);

            // Retrieve the department description element from the current row in the rental items grid.  
            var departmentElement = webElementAction.GetColumnInDefaultGridRow("departmentDesc", "rentalItems-gridId");

            // Perform a right-click on the department description element to display the context menu.  
            webElementAction.RighClick(departmentElement);

            // Find and click the "Reduce Qty Ordered to Match Qty Out" option from the context menu.  
            webElementAction.GetElementByCssSelector(".ag-popup")
                .FindElements(By.TagName("span"))
                .FirstOrDefault(o => o.GetAttribute("innerText") == namePopup)?.Click();
        }



        [TestMethod, Timeout(MaximumExecutionTime)]
        public void UpdateSubrentalGLAccount_MultiSelectFeature()
        {
            TestInitialize(nameof(UpdateSubrentalGLAccount_MultiSelectFeature));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    var orderNumber = string.Empty;
                    var equipmentCode = string.Empty;
                    string countGridRentalFirst = default;

                    /*Step 1: Add a new Order and get its orderNo */
                    {
                        Login();
                        orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }
                    /*Step 2:----Add equipment to order in Rental Order Screen */
                    {
                        equipmentCode = equipmentCheckOutInAndBilling.AddBarcodeEquipmentWithRequiredFields(IsLoginPageRequired: false);
                    }
                    /* Step 2: Click clear inputs and send order number and search */
                    {
                        SearchOrderInOrderProcessingScreen(orderNumber);
                    }
                    /* Step 3: Get row count from grid pinned footer first */
                    {
                        AddRentalOrdersRandomly(equipmentCode, orderNumber);
                    }
                    /* Step 4: Select the row and reduce quantity ordered */
                    {
                        SelectReduceQtyOrdered("Update Subrental GL Account");
                    }
                    /* Step 5: Select the row and reduce quantity ordered */
                    {
                        ValidateUpdateSubrentalGLAccount();
                    }

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void ValidateUpdateSubrentalGLAccount()
        {
            if (!webElementAction.IsElementPresent(By.CssSelector(".main-modal")))
                Assert.Fail("Error:___ Do not find 'Update Subrental GL Account' modal ");

            new WebElementDataGenerator(webElementAction.GetElementBySpecificAttribute("data-form-item-name", "glAccountId"));

            var glAccount = webElementAction.GetInputElementByDataFormItemNameInDiv("glAccountId").GetAttribute("value");

            ConfirmBtnCheck(dataSection: "modal");

            ConfirmBtnCheck(dataSection: "infoDialog");

            FindColumnInMainGrid("Subrental GL Account", "rentalItems-gridId");

            var subrentalGlAccount = webElementAction.GetColumnInDefaultGridRow("subrentalGlAccountId", "rentalItems-gridId").Text;
            if (subrentalGlAccount != glAccount)
                Assert.Fail($"Error:___ value {glAccount} is not {subrentalGlAccount}");
        }
    }
}