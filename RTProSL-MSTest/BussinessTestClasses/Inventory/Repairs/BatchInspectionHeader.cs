using OpenQA.Selenium;
using RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.TestClasses;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTProSL_MSTest.BussinessTestClasses.Inventory.Repairs
{
    [TestClass]
    public class BatchInspectionHeader : BaseClass
    {

        public BatchInspectionHeader() { }

        static int RCD_Count = 3;
        //Test Method to add a new barcode and pass batch inspection
        [TestMethod]
        public void AddAndPassBatchInspection()
        {
            TestInitialize(nameof(AddAndPassBatchInspection));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string equipmentNumber = default;
                    // Step 1) Select a barcode equipment
                    {
                        equipmentNumber = GetRandomBarcodeEquipment();
                    }

                    string[] barcodes = new string[2];
                    // Step 2) Add Barcode Item To Equipment
                    {
                        barcodes[0] = AddBarcodeItemToEquipment(equipmentNumber);
                        GoToUrl("MMInventory", "EquipmentList", gotoLogin: false);
                        barcodes[1] = AddBarcodeItemToEquipment(equipmentNumber);
                    }

                    // Step 3) Enable Inspection of Equipment
                    {
                        ClickOnFirstBackOnHistory();
                        ClickOnEditBtn();
                        ClickTab("INSPECTION");
                        webElementAction.SelectingCheckbox("inspection");
                        webElementAction.ClickOnPostChanges();
                    }

                    // Step 4) Delete Previous Inspection types add a new inspection type to equipment
                    {
                        DeletePreviousInspectionTypes();
                        AddNewInspectionType();
                    }

                    // Step 5) Add barcode to Batch Inspection and Pass it
                    {
                        AddBarcodesToBatchInspection(barcodes, InspectionStatus.Pass);
                    }

                    //TODO: Step 6) Check pass batch inspection value
                    {
                        //ValidateBatchInspectionStatus(InspectionStatus.Pass);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void ValidateBatchInspectionStatus(InspectionStatus inspectionStatus)
        {
            webElementAction.ScrollDown(".stepper-card-wrapper");
            Thread.Sleep(1000);
            if (inspectionStatus == InspectionStatus.Pass)
            {
                if (!webElementAction.IsElementPresent(By.CssSelector(".passStatus.wrap-content")))
                    throw new Exception("Error: Pass status of Inspection doesn't appear in form!!");
            }
            else if (inspectionStatus == InspectionStatus.Fail)
            {
                if (!webElementAction.IsElementPresent(By.CssSelector(".failStatus.wrap-content")))
                    throw new Exception("Error: Fail status of Inspection doesn't appear in form!!");
            }
        }

        [TestMethod]
        public void AddAndFailBatchInspection()  // update setup set MoveItemToRepairOnFailedInspection=1
        {
            TestInitialize(nameof(AddAndPassBatchInspection));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string equipmentNumber = default;
                    // Step 1) Select a barcode equipment
                    {
                        equipmentNumber = GetRandomBarcodeEquipment();
                    }
                    string[] barcodes = new string[2];
                    // Step 2) Add Barcode Items To Equipment
                    {
                        barcodes[0] = AddBarcodeItemToEquipment(equipmentNumber);
                        GoToUrl("MMInventory", "EquipmentList", gotoLogin: false);
                        barcodes[1] = AddBarcodeItemToEquipment(equipmentNumber);
                    }

                    // Step 3) Enable Inspection of Equipment
                    {
                        ClickOnFirstBackOnHistory();
                        ClickOnEditBtn();
                        ClickTab("INSPECTION");
                        webElementAction.SelectingCheckbox("inspection");
                        webElementAction.ClickOnPostChanges();
                    }

                    // Step 4) Delete Previous Inspection types add a new inspection type to equipment
                    {
                        DeletePreviousInspectionTypes();
                        AddNewInspectionType();
                    }

                    // Step 5) Add barcode to Batch Inspection and Pass it
                    {
                        AddBarcodesToBatchInspection(barcodes, InspectionStatus.Fail);
                    }

                    //// TODO: Step 6) Check pass batch inspection value 
                    //{
                    //    ValidateBatchInspectionStatus(InspectionStatus.Fail);
                    //}
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        public enum InspectionStatus
        {
            Pass,
            Fail
        }
        private void AddBarcodesToBatchInspection(string[] barcodes, InspectionStatus inspectionStatus)
        {

            GoToUrl("MMInventory", "BatchInspectionHeader", gotoLogin: false);

            foreach (var barcode in barcodes)
            {
                var inputBarcode = webElementAction.GetElementByCssSelector("[name='Barcode']");

                inputBarcode.SendKeys(barcode);

                var goBtn = webElementAction.GetElementByCssSelector(".search-button span");
                goBtn.Click();
                WaitForLoadingSpiner();
            }

            var confirmBtn = webElementAction.GetElementByCssSelector("[data-button-type=confirm]");
            confirmBtn.Click();

            var inspectionBoxContext = webElementAction.GetElementByCssSelector(".inspectionHeaderBox");
            new WebElementDataGenerator(inspectionBoxContext);

            //Note: If the Prompt RCD tick is checked for inspection type, then the RCD grid will not be displayed.
            if (webElementAction.IsElementPresent(By.Id("InspectionHeader-card-number-0-MiniGrid-gridId")))
            {                                                    //InspectionHeader-card-number-0-MiniGrid-gridId
                // insert RCD Records
                for (int i = 0; i < RCD_Count; i++)
                {
                    webElementAction.ClickOnAddNewRowInMinGrid(dataHeaderName: "InspectionHeader-card-number-0-MiniGrid");
                    var newRowColsContext = webElementAction.GetAllElementsByCssSelector(".ag-center-cols-container .new-added-row")[i];
                    new WebElementDataGenerator(newRowColsContext, IsContextGrid: true);
                    webElementAction.ClickOnPostBtnInMinGrid(gridId: "InspectionHeader-card-number-0-MiniGrid-gridId");
                    WaitForLoadingSpiner();
                }
            }

            if (inspectionStatus == InspectionStatus.Pass)
            {
                var passBtn = webElementAction.GetElementByCssSelector(".passButton span");
                passBtn.Click();
                CheckErrorDialogBox();
                WaitForLoadingSpiner();
                ConfirmBtnCheck(dataSection: "infoDialog");
                CheckErrorDialogBox();
            }

            else if (inspectionStatus == InspectionStatus.Fail)
            {
                var failBtn = webElementAction.GetElementByCssSelector(".failButton span");
                failBtn.Click();

                var noteModal = webElementAction.GetElementByCssSelector(".main-modal");
                new WebElementDataGenerator(noteModal);

                //click on confirmBtn
                webElementAction.Click(By.CssSelector(".confirm-button > .d-flex"));

                CheckErrorDialogBox();
                WaitForLoadingSpiner();
                ConfirmBtnCheck(dataSection: "infoDialog");
                CheckErrorDialogBox();
            }
        }

        private void AddNewInspectionType()
        {
            webElementAction.ClickOnAddNewRecord();

            var mainContex = GetFormLeftSideContext(isNested: true);

            var webElementDataGenerator = new WebElementDataGenerator(mainContex);

            //generate data to rcdTestCount
            var rcdTestCount = webElementAction.GetInputElementByDataFormItemNameInDiv("rcdTestCount");
            webElementAction.DoubleClick(rcdTestCount);
            rcdTestCount.SendKeys(Keys.Backspace);
            rcdTestCount.SendKeys(RCD_Count.ToString());
            webElementAction.ClickOnPostChanges();
        }

        private void DeletePreviousInspectionTypes()
        {
            GoToSubMenu("INSPECTION_TOOL_DROPDOWN", "INSPECTION_TYPE");

            var deleteBtn = webElementAction.GetElementById("TOOL_BOX_DELETE_BUTTON_ID"); //click on delete btn
            var rowCount = GetRowCountFromGridPinnedFooter(gridId: "EquipmentInspection-gridId");
            while (rowCount > 0) // Delete all previous inspection type of equipment
            {
                deleteBtn.Click();
                ConfirmBtnCheck(dataSection: "confirmDialog");
                rowCount--;
            }
        }


        public string GetRandomBarcodeEquipment()
        {
            GoToUrl("MMInventory", "EquipmentList", gotoLogin: true);
            ClickOnEditBtn();
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

            WaitForLoadingSpiner();
            FindColumnInMainGrid("Code");
            //equipment Code In firstRow with barcode
            Thread.Sleep(2000);
            var equipmentCode = ObjectRepository.Driver
                 .FindElements(By.CssSelector("[col-id='id'][role='gridcell']"))
                 .First().Text;
            return equipmentCode;
        }

        public string AddBarcodeItemToEquipment(string equipmentCode)
        {
            SearchAndEditClick(equipmentCode);

            //If equipment has an RFID checkbox, we cannot add a barcode to it.
            DeSelectingRFIDCheckbox();


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
            CheckErrorDialogBox();
            Thread.Sleep(2000);
            var barcode = webElementAction.GetAllElementsByCssSelector("[col-id= 'barcode'][role= 'gridcell']")[0].Text;
            return barcode;
        }

        private void DeSelectingRFIDCheckbox()
        {
            ClickTab("SETTING");
            if (webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='rfidOnly']")))
                webElementAction.DeSelectingCheckbox("rfidOnly");
        }
        private EquipmentCheckOutInAndBilling equipmentCheckOutInAndBilling = new EquipmentCheckOutInAndBilling();

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateBarcodeInformationInBatchInspectionHeader()//document "New Features August" number 2
        {
            TestInitialize(nameof(ValidateBarcodeInformationInBatchInspectionHeader));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string[] barcodes = new string[2];
                    {
                        string equipmentNumber = default;
                        equipmentNumber = GetRandomBarcodeEquipment();
                        barcodes[0] = AddBarcodeItemToEquipment(equipmentNumber);
                        GoToUrl("MMInventory", "EquipmentList", gotoLogin: false);
                        barcodes[1] = AddBarcodeItemToEquipment(equipmentNumber);
                        ClickOnFirstBackOnHistory();
                        ClickOnEditBtn();
                        ClickTab("INSPECTION");
                        webElementAction.SelectingCheckbox("inspection");
                        webElementAction.ClickOnPostChanges();
                        DeletePreviousInspectionTypes();
                        AddNewInspectionType();
                    }
                    GoToUrl("MMInventory", "BatchInspectionHeader", gotoLogin: false);

                    // Enter the first barcode into the barcode input field  
                    webElementAction.GetElementByCssSelector(".barcode-scanner-input-wrapper").FindElement(By.TagName("input")).SendKeys(barcodes[0]);

                    // Click on the search button  
                    webElementAction.Click(By.CssSelector(".search-button"));

                    // Check for the presence of the confirm button  
                    ConfirmBtnCheck();

                    // Wait for loading spinner to disappear  
                    WaitForLoadingSpiner();

                    // Click on the next step button  
                    webElementAction.Click(By.Id("stepper-action-button"));

                    // Click on the "TOOL_BOX_BARCODE_ATTACHMENT" button  
                    webElementAction.Click(By.Id("TOOL_BOX_BARCODE_ATTACHMENT"));

                    // Check if the barcode information modal is present  
                    if (!webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='BARCODES_INFORMATION']")))
                        Assert.Fail("Error: Barcode Information modal not found.");

                    // Verify that the barcode in the 'id' column matches the entered barcode  
                    if (webElementAction.GetColumnInDefaultGridRow(columnId: "id", gridId: "InspectionHeader-gridId").Text != barcodes[0])
                        Assert.Fail($"Error: Mismatched barcode. Expected: {barcodes[0]}, Found: {webElementAction.GetColumnInDefaultGridRow(columnId: "id", gridId: "InspectionHeader-gridId").Text}");

                    // Click on the 'hasAttachment' column  
                    webElementAction.GetColumnInDefaultGridRow(columnId: "hasAttachment", gridId: "InspectionHeader-gridId").Click();

                    // Check if the 'BarcodeInventoryAttachment' page is accessible  
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
}
