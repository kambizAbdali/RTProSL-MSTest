using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.TestClasses;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

// Help: To subrental an order, the order must be added by the same user.
// Prerequisite: Presence of a Rental Item in the Rental Order for the order
// Help: "When entering a Subrental PO, Approved checkbox in the general tab must be ticked.
//        Otherwise, we will encounter the following error: This PO is approved and cann't be used.


namespace RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen.Rental
{
    [TestClass]
    public class ChangeSubrentalVendor : BaseClass
    {
        public ChangeSubrentalVendor()
        {
            EquipmentCheckOutInAndBilling = new EquipmentCheckOutInAndBilling();
        }
        EquipmentCheckOutInAndBilling EquipmentCheckOutInAndBilling;
        public string VendorId { get; private set; }
        public string PoNumber { get; private set; }
        public string OrderNumber { get; private set; }
        public string EquipmentCode { get; private set; }
        public string NewVendorValue { get; private set; }


        [TestMethod, Timeout(MaximumExecutionTime * 2)]
        public void ChangeSubrentalVendor_Business()
        {
            TestInitialize(nameof(ChangeSubrentalVendor_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a subrental po*/
                    {
                        AddSubrentalPO();
                    }

                    /* Step 2: Get a random barcode equipment*/
                    {
                        EquipmentCode = GetRandomBarcodeEquipment();
                    }

                    //* Step 3: Add a new Order and get its orderNo *//
                    {
                        OrderNumber = EquipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }

                    //* Step 4: Add equipment to order in Rental Order Screen *//
                    {
                        EquipmentCheckOutInAndBilling.AddEquipmentToRentalOrder(EquipmentCode, OrderNumber);
                    }

                    //* Step 5: Add subrental Vendor in Rental Order Screen
                    {
                        AddSubrentalToOrder();
                    }

                    //* Step 6: Change subrental Vendor in Order Processing Screen
                    {
                        ChangeSubrental();
                    }

                    //* Step 7: Validate New Subrental Value in Subrental Records List
                    {
                        ValidateNewSubrentalValue();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private string GetRandomBarcodeEquipment()
        {
            GoToUrl("MMInventory", "EquipmentList", gotoLogin: false);
            RefreshAllRows();  // location: canada (by default)
            ShowAllRedord();
            var barcodeFilterElement = webElementAction.GetElementByCssSelector("[col-id='barcodedOnly'][role='columnheader']")
                            .FindElement(By.CssSelector(".ag-header-cell-menu-button"));
            barcodeFilterElement.Click();

            var sortDescendingElement = webElementAction.GetElementByCssSelector(".ag-menu-list > div:nth-of-type(3)");
            sortDescendingElement.Click();

            //equipment Code In firstRow with barcode
            Thread.Sleep(2000);
            return ObjectRepository.Driver.FindElements(By.CssSelector("[col-id='id'][role='gridcell']"))
                .First().Text;
        }

        private void ValidateNewSubrentalValue()
        {
            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_ORDER");
            WaitForLoadingSpiner();

            GoToSubMenu("SUBRENTAL_TOOL_DROPDOWN", "-SUBRENTAL");
            WaitForLoadingSpiner();

            var subrentalGrid = webElementAction.GetElementById("SubrentalRecords-gridId");
            ReadOnlyCollection<IWebElement> colIds =
                subrentalGrid.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

            var VendorInGrid = colIds.First(o => o.GetAttribute("col-id") == "vendorId").Text;

            if (VendorInGrid != NewVendorValue)
            {
                throw new Exception("The new value of the Vendor is invalid");
            }
        }

        private void AddSubrentalToOrder()
        {
            GoToSubMenu("SUBRENTAL_TOOL_DROPDOWN", "-SUBRENTAL");
            WaitForLoadingSpiner();
            Thread.Sleep(1000);
            //click on add subrental btn
            webElementAction.GetAllElementsByCssSelector("[data-section='list'] .icon-add").First().Click();

            var newRowColIdsContext = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row");
            var vendorContext = webElementAction.GetElementBySpecificAttribute("col-id", "vendorId", newRowColIdsContext);

            webElementAction.SetValueToAutoComboCellGrid(colId: "vendorId", value: VendorId);
            webElementAction.SetValueToAutoComboCellGrid(colId: "po", value: PoNumber);
            webElementAction.SetValueToAutoComboCellGrid(colId: "daysPerWeek", value: "2");
            webElementAction.ClickOnPostBtnInMinGrid(gridId: "SubrentalRecords-gridId");
            ConfirmBtnCheck(); // Confirm: Subrent Accessory Items?

            WaitForLoadingSpiner();
            var poIsApproves = ObjectRepository.Driver.FindElements(By.TagName("div")).
                FirstOrDefault(o => o.Text.Contains("PO is approved and cannot be used"));

            var subrentalGrid = webElementAction.GetElementById("SubrentalRecords-gridId");
            ReadOnlyCollection<IWebElement> colIds =
                subrentalGrid.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
            VendorId = colIds.First(o => o.GetAttribute("col-id") == "vendorId").Text;
            PoNumber = colIds.First(o => o.GetAttribute("col-id") == "po").Text;
        }

        public void ChangeSubrental()
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
            ConfirmBtnCheck(); // Confirm: Discard Changes?
            WaitForLoadingSpiner();
            GoToSubMenu("RENTAL_TOOL_DROPDOWN", "CHANGE_SUBRENTAL_VENDOR");

            webElementAction.GenerateAutoCompleteComboWithSpecificValue("vendorId", VendorId);
            webElementAction.GenerateAutoCompleteComboWithSpecificValue("po", PoNumber);

        tryToGenerateNewVendor:
            var newVendorContext = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "newVendorId");
            new WebElementDataGenerator(newVendorContext);
            NewVendorValue = webElementAction.GetInputElementByDataFormItemNameInDiv("newVendorId").GetAttribute("value");

            //New Vendor and Existing Vendor must be different.
            if (NewVendorValue == VendorId) goto tryToGenerateNewVendor;

            ConfirmBtnCheck(dataSection: "modal"); // change subrental vendor
            ConfirmBtnCheck(dataSection: "infoDialog"); // Information: Vendor changed successfully
        }

        public void AddSubrentalPO()
        {
            GoToUrl("PurchaseOrder", "SubrentalPO");
            RefreshAllRows();
            ShowAllRedord();

            Thread.Sleep(2000);

            //click on addNewRecordBtn
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();

            //click on post button
            webElementAction.GetElementByCssSelector(".icon-tick").Click();

            webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();
            var generalTabContext = GetTabContext("GENERAL");
            new WebElementDataGenerator(generalTabContext);
            VendorId = webElementAction
                                .GetInputElementByDataFormItemNameInDiv("vendorId", generalTabContext)
                                .GetAttribute("value");
            PoNumber = webElementAction.GetInputElementByDataFormItemNameInDiv("poId").GetAttribute("value");

            ClickTab("GENERAL");

            // deActive of approved Checkbox
            webElementAction.DeSelectingCheckbox(dataFormItemName: "approved");

            SaveAndConfirmCheck();
            ConfirmBtnCheck();
            CheckErrorDialogBox();
        }
    }
}