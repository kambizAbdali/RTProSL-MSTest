
//develop by Kambiz Abdali
using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
using WindowsInput;

//Need to zoom out for run
namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Inventory
{
    [TestCategory("PurchaseOrder")]
    [TestClass, TestCategory("PurchaseOrder___Inventory")]
    public class InventoryPO : BaseClass
    {
        private static InventoryPOEntity _InventoryPOEntity;

        public enum OperationType
        {
            Add,
            Edit
        }

        public class GeneralTab
        {
            public string ShipMethodId { get; set; }
            public string ShippingAmount { get; set; }
            public string EstimatedShipDate { get; set; }
            public string EstimatedArrivalDate { get; set; }
            public string TermsId { get; set; }
            public string ProductionId { get; set; }
            public string OrderNo { get; set; }
            public string LanguageId { get; set; }
            public string RentalPriceListId { get; set; }
            public string SalesPriceListId { get; set; }
            public string MangDeptId { get; set; }

            [ValidationDataType(DataType.TextArea)]
            public string Notes { get; set; }
        }

        public class InventoryPOEntity
        {
            public InventoryPOEntity()
            {
                GeneralTab = new GeneralTab();
                AddressTab = new AddressTab();
                CurrencyTab = new CurrencyTab();
                RentalTab = new RentalTab();
                SalesTab = new SalesTab();
                MiscTab = new MiscTab();
                ShippingTab = new ShippingTab();
            }
            [ValidationIgnore(true, IgnoreType.Add)]
            [ValidationTabClick("CURRENCY")] public CurrencyTab CurrencyTab { get; set; }
            public string Id { get; set; }
            public string Date { get; set; }
            public string VendorId { get; set; }
            public string LocationId { get; set; }
            public string Descriptionc { get; set; }
            public string TypeId { get; set; }
            public string Amount { get; set; }
            public string DiscountPercentage { get; set; }
            public string Use4Decimal { get; set; }
            public bool Approved { get; set; }
            public bool PickupScheduled { get; set; }
            public bool Closed { get; set; }
            [ValidationTabClick("GENERAL")] public GeneralTab GeneralTab { get; set; }
            [ValidationTabClick("ADDRESS")] public AddressTab AddressTab { get; set; }


            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            [ValidationTabClick("RENTALS")]
            public RentalTab RentalTab { get; set; }

            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            [ValidationTabClick("SALES")]
            public SalesTab SalesTab { get; set; }

            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            [ValidationTabClick("MISC")]
            public MiscTab MiscTab { get; set; }

            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            [ValidationTabClick("SHIPPING")]
            public ShippingTab ShippingTab { get; set; }
        }

        public class AddressTab
        {
            public string ShippingName { get; set; }
            public string ShippingAddressLine1 { get; set; }
            public string ShippingAddressLine2 { get; set; }
            public string ShippingAddressLine2B { get; set; }
            public string ShippingAddressLine3 { get; set; }
            public string ShipState { get; set; }
            public string ShipZipCode { get; set; }
            public string ShippingAddressLine4 { get; set; }
            public string Phone { get; set; }
            public string CompanyAddress { get; set; }
            public string ProductionAddress { get; set; }
        }

        public class CurrencyTab
        {
            [ValidationIgnore(true, IgnoreType.Validation)]
            [ValidationElementProperty("vendorCurrencyId")]
            public string VendorCurrency { get; set; }
        }

        // Money fields, because they have calculations, may not be the same after being inserted and opened again. That is why they are ignored
        public class RentalTab
        {
            public string EquipmentId { get; set; }
            public string Description { get; set; }
            public string VendorCatalogNo { get; set; }
            public string Notes { get; set; }
            public string QuantityOrdered { get; set; }
            public string QuantityReceived { get; set; }
            public string QuantityAdded { get; set; }
            public string QuantityInvoiced { get; set; }
            public string GlAccountId { get; set; }
            public string ListPrice { get; set; }
            public string Discount { get; set; }
            public string ActualPrice { get; set; }
            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string Total { get; set; }

            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string DiscountPercentage { get; set; }
            public bool Locked { get; set; }

            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string VendorDispersedAmount { get; set; }
            public bool Taxable { get; set; }
            public bool Inventory { get; set; }
            public string ManufacturerPartNo { get; set; }
            public string Manufacturer { get; set; }
            public string NewlistPrice { get; set; }
            public string Newdiscount { get; set; }
            public string NewactualPrice { get; set; }
            public string Newtotal { get; set; }

            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string NewlocalDispersedAmount { get; set; }
            public string NewvendorDispersedAmount { get; set; }
            public string NewlocalDispersedAmountextended { get; set; }
        }


        // Money fields, because they have calculations, may not be the same after being inserted and opened again. That is why they are ignored.
        public class SalesTab
        {
            public string StockNoId { get; set; }
            public string Description { get; set; }
            public string VendorCatalogNo { get; set; }
            public string VendorPartNo { get; set; }
            public string QtyOrdered { get; set; }
            public string QtyReceived { get; set; }
            public string QtyAdded { get; set; }

            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string ListPrice { get; set; }
            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string Discount { get; set; }
            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string ActualPrice { get; set; }
            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string Total { get; set; }
            public string DiscountPercentage { get; set; }
            public bool Locked { get; set; }
            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string VendordispersedAmount { get; set; }
            public string GlaccountId { get; set; }
            public bool Taxable { get; set; }
            public string Notes { get; set; }
            public bool Inventory { get; set; }
            public string Qtyinvoiced { get; set; }
            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string NewlistPrice { get; set; }
            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string Newdiscount { get; set; }
            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string NewactualPrice { get; set; }
            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string Newtotal { get; set; }
            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string NewlocalDispersedAmount { get; set; }
            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string NewvendorDispersedAmount { get; set; }
            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string NewlocalDispersed { get; set; }
        }

        public class MiscTab
        {
            public string Misc { get; set; }
            public string Description { get; set; }
            public string QtyOrdered { get; set; }
            public string QtyReceived { get; set; }
            public string ListPrice { get; set; }
            public string Discount { get; set; }
            public string ActualPrice { get; set; }

            [ValidationIgnore(true, IgnoreType.AddAndValidation)]
            public string Total { get; set; }
            public string DiscountPercentage { get; set; }
            public string GlAccountId { get; set; }
            public bool Taxable { get; set; }
            public bool Locked { get; set; }
            public string Notes { get; set; }
            public string QtyInvoiced { get; set; }
            public string NewlistPrice { get; set; }
            public string Newdiscount { get; set; }
            public string NewactualPrice { get; set; }
            public string Newtotal { get; set; }
        }

        public class ShippingTab
        {
            public string ShippingChargeCode { get; set; }
            public string Description { get; set; }
            public string VendorAmount { get; set; }
            public string OrderNo { get; set; }
            public string GlAccountId { get; set; }
            public string InvoiceId { get; set; }
        }

        [TestMethod, Timeout(MaximumExecutionTime * 2)]
        public void AddInventoryPO()
        {
            TestInitialize(nameof(AddInventoryPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    AddOrEditInventoryPOFunc(OperationType.Add);
                    ValidateInsertedInventoryPOInGridList();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime * 2)]
        public void EditInventoryPO()
        {
            TestInitialize(nameof(EditInventoryPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    AddOrEditInventoryPOFunc(OperationType.Edit);
                    ValidateInsertedInventoryPOInGridList();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        public void AddOrEditInventoryPOFunc(OperationType operationType)
        {
            GoToUrl("PurchaseOrder", "InventoryPO");
            _InventoryPOEntity = new InventoryPOEntity();

            RefreshAllRows();

            if (operationType == OperationType.Add) //for edit inserted Inventory PO
            {
                //click on addNewRecordBtn
                webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
            }
            else
            {
                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();
            }
            var context = GetFormLeftSideContext(true);

            string vendorValue = webElementAction.GetInputElementByDataFormItemNameInDiv("vendorId", context).GetAttribute("value");

            var poNumberElement = webElementAction.GetInputElementByDataFormItemNameInDiv("id", context);
            var poNumberValue = poNumberElement.GetAttribute("value");

            if (operationType == OperationType.Add)
                new WebElementDataGenerator(context);

            // The "poNumberElement" may be disable and its value may have been generated automatically. 
            //if (!poNumberElement.GetAttribute("class").Contains("main-input-disable"))
            //{
            //    webElementAction.DoubleClick(poNumberElement);
            //    poNumberElement.SendKeys(Keys.Backspace);
            //    poNumberElement.SendKeys(poNumberValue);
            //}

            //close checkbox should be disabled.
            webElementAction.GetInputElementByDataFormItemNameInDiv("closed").Click();
            // the confirmed checkbox must be disabled.
            webElementAction.GetInputElementByDataFormItemNameInDiv("approved").Click();

            if (operationType == OperationType.Add)
            {
                //The first CURRENCY tab must be filled.
                //Currency Tab only change for add mode beacase maybe it has dependency.
                //*******
                //*******************Generate data to CURRENCY Tabs*************************************
                // if UseCurrency=true in setup, this condition trigger.
                if (webElementAction.IsElementPresent(By.CssSelector("[data-tab-name='CURRENCY']")))
                {
                    ClickTab("CURRENCY");
                    var currencyContext = GetTabContext("CURRENCY");
                    new WebElementDataGenerator(currencyContext);
                    _InventoryPOEntity.CurrencyTab.VendorCurrency = webElementAction.GetInputElementByDataFormItemNameInDiv("vendorCurrencyId", currencyContext).GetAttribute("value");
                }
            }

            webElementAction.DeSelectingCheckbox("closed");
            webElementAction.DeSelectingCheckbox("approved");

            // click on post changes btn
            webElementAction.GetElementById("TOOL_BOX_SAVE_CHANGES_BUTTON_ID").Click();

            ConfirmBtnCheck(); // Confirm:Not all items have been received or posted to inventory. Do you wish to close the PO?
            ClickOnEditBtn();

            //**************************Generate data to General, Address and Currency Tabs*************************************
            CreateAdd(_InventoryPOEntity, context);
            //var vendorInputElement = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "vendorId");
            //var comboAutoCompleteVendor = vendorInputElement.FindElements(By.CssSelector(".combo-auto-complete"));
            //new WebElementDataGenerator().ComboAutoCompleteGenerator(comboAutoCompleteVendor, vendorValue);

            Thread.Sleep(1000);
            // click on post changes btn
            webElementAction.GetElementById("TOOL_BOX_SAVE_CHANGES_BUTTON_ID").Click();

            ConfirmBtnCheck(dataSection: "errorDialog"); //Error: There are not billed shipping charges for this PO.

            // click on edit btn
            webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();

            //**************************Generate data to Sales Tab*************************************
            ClickTab("SALES");
            Thread.Sleep(1000);
            var salesContext = GetTabContext("SALES");
            DeleteAllRowsInMinGrid(tabContaxt: salesContext, "salesMiniGrid-MiniGrid");

            webElementAction.GetElementBySpecificAttribute("data-icon-name", "add", salesContext).Click();
            Thread.Sleep(2000);
            var salesGrid = webElementAction.GetElementById("salesMiniGrid-MiniGrid-gridId");

            var newRowColsContextSales = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row", salesGrid);
            new WebElementDataGenerator(newRowColsContextSales, true);

            GenerateReceivedAndOrderedQuantitiesToGrid("salesMiniGrid-MiniGrid-gridId");

            GenerateDataToDiscountPercentageColumn(gridId: "salesMiniGrid-MiniGrid-gridId");


            //click on post sale row
            webElementAction.ClickOnPostBtnInMinGrid(gridId: "salesMiniGrid-MiniGrid-gridId");
            WaitForLoadingSpiner();
            ConfirmBtnCheck();
            WaitForLoadingSpiner();
            var saleColIds = webElementAction.GetElementById("salesMiniGrid-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
            saleColIds.First(o => o.GetAttribute("col-id") == "stockNoId").Click();
            Thread.Sleep(1500);
            CreateAddInGrid(_InventoryPOEntity.SalesTab, saleColIds);

            //**************************Generate data to SHIPPING Tab*************************************

            ClickTab("SHIPPING");
            Thread.Sleep(1000);
            var shippingContext = GetTabContext("SHIPPING");
            DeleteAllRowsInMinGrid(tabContaxt: shippingContext, "shippingMiniGrid-MiniGrid");
            Thread.Sleep(1000);
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "add", shippingContext).Click();

            Thread.Sleep(1000);
            var shippingGrid = webElementAction.GetElementById("shippingMiniGrid-MiniGrid-gridId");

            var newRowColsContextShipping = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row", shippingGrid);
            new WebElementDataGenerator(newRowColsContextShipping, true);

            //click on post sale row
            webElementAction.ClickOnPostBtnInMinGrid(gridId: "shippingMiniGrid-MiniGrid-gridId");
            ConfirmBtnCheck();
            var shippingColIds = webElementAction.GetElementById("shippingMiniGrid-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
            CreateAddInGrid(_InventoryPOEntity.ShippingTab, shippingColIds);

            //**************************Generate data to Misc Tab*************************************
            ClickTab("MISC");
            Thread.Sleep(3000);
            var miscContext = GetTabContext("MISC");

            DeleteAllRowsInMinGrid(tabContaxt: miscContext, "miscMiniGrid-MiniGrid");
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "add", miscContext).Click();

            var miscGrid = webElementAction.GetElementById("miscMiniGrid-MiniGrid-gridId");

            var newRowColsContextMisc = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row", miscGrid);
            Thread.Sleep(2000);
            new WebElementDataGenerator(newRowColsContextMisc, true);

            GenerateReceivedAndOrderedQuantitiesToGrid("miscMiniGrid-MiniGrid-gridId");

            var miscColIds = webElementAction.GetElementById("miscMiniGrid-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//

            GenerateDataToDiscountPercentageColumn(gridId: "miscMiniGrid-MiniGrid-gridId");

            //click on post sale row
            webElementAction.ClickOnPostBtnInMinGrid("miscMiniGrid-MiniGrid-gridId");
            ConfirmBtnCheck();
            miscColIds = webElementAction.GetElementById("miscMiniGrid-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
            CreateAddInGrid(_InventoryPOEntity.MiscTab, miscColIds);

            //**************************Generate data to Rental Tab*************************************
            ClickTab("RENTALS");

            var rentalContext = GetTabContext("RENTALS");
            DeleteAllRowsInMinGrid(tabContaxt: rentalContext, "rentalsMiniGrid-MiniGrid");

            Thread.Sleep(2000);

            webElementAction.GetElementBySpecificAttribute("data-icon-name", "add", rentalContext).Click();

            var rentalGrid = webElementAction.GetElementById("rentalsMiniGrid-MiniGrid-gridId");

            Thread.Sleep(2000);
            var newRowColsContextRental = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row", rentalGrid);
            Thread.Sleep(1000);
            new WebElementDataGenerator(newRowColsContextRental, true);

            GenerateReceivedAndOrderedQuantitiesToGrid("rentalsMiniGrid-MiniGrid-gridId");
            webElementAction.ClickOnPostBtnInMinGrid(gridId: "rentalsMiniGrid-MiniGrid-gridId");

            //Confirm messageBox:   Auto Include Accessory ? No
            if (webElementAction.IsElementPresent(By.CssSelector(".cancel-button > .d-flex")))
                webElementAction.GetElementByCssSelector(".cancel-button > .d-flex").Click();
            // click on cancel btn that it has for insert new roe
            if (webElementAction.IsElementPresent(By.CssSelector(".inline-cancel-button span")))
                webElementAction.GetElementByCssSelector(".inline-cancel-button span").Click();

            Thread.Sleep(2000);
            var rentalColIds = webElementAction.GetElementById("rentalsMiniGrid-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//

            Thread.Sleep(1000);
            rentalColIds.First(o => o.GetAttribute("col-id") == "equipmentId").Click();
            CreateAddInGrid(_InventoryPOEntity.RentalTab, rentalColIds);

            // click on edit btn
            webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();

            _InventoryPOEntity.Id = webElementAction.GetInputElementByDataFormItemNameInDiv("id", context).GetAttribute("value");

            //click on saveAndCloseBtn and check confirm
            SaveAndConfirmCheck();
        }

        private void GenerateDataToDiscountPercentageColumn(string gridId)
        {
            IWebElement discount = webElementAction.GetElementByCssSelector("#" + gridId + " .ag-body-viewport .ag-row-focus [col-id='discount'] input");
            webElementAction.DoubleClick(discount);
            Thread.Sleep(500);
            discount.Clear();
            var discountVal = discount.GetAttribute("value").Trim();
            for (int i = 0; i < discountVal.Length; i++)
                discount.SendKeys(Keys.Backspace);
            discount.SendKeys(RandomValueGenerator.GenerateRandomInt(1));
        }

        private static void GenerateReceivedAndOrderedQuantitiesToGrid(string GridId)
        {
            IWebElement quantityReceivedInput = default;
            IWebElement quantityOrderedInput = default;
            try
            {    // For Sales and Misc tabs, col-id='qtyReceived'
                quantityReceivedInput = webElementAction.GetElementByCssSelector("#" + GridId + " .ag-body-viewport .ag-row-focus [col-id='qtyReceived'] input");
                quantityOrderedInput = webElementAction.GetElementByCssSelector("#" + GridId + " .ag-body-viewport .ag-row-focus [col-id='qtyOrdered'] input");
            }
            catch
            {    // For Rental tab, col-id='quantityReceived'                                                                                                         
                quantityReceivedInput = webElementAction.GetElementByCssSelector("#" + GridId + " .ag-body-viewport .ag-row-focus [col-id='quantityReceived'] input");
                quantityOrderedInput = webElementAction.GetElementByCssSelector("#" + GridId + " .ag-body-viewport .ag-row-focus [col-id='quantityOrdered'] input");
            }


            // Define a method to set the input fields  
            void SetInputField(IWebElement inputField, int value)
            {
                webElementAction.DoubleClick(inputField);
                (new InputSimulator()).Keyboard.TextEntry(value.ToString());
                inputField.Clear();
                inputField.SendKeys(value.ToString());
            }

            // Set quantity received to zero  
            SetInputField(quantityReceivedInput, 0);

            // Set quantity ordered to a random integer greater than zero  
            int randomQuantityOrdered = (int.Parse(RandomValueGenerator.GenerateRandomInt(1)));
            SetInputField(quantityOrderedInput, randomQuantityOrdered);
        }

        public void ValidateInsertedInventoryPOInGridList()
        {
            // Clear LocationAndDateTags in grid-list
            ClearLocationAndDateTags();
            RentalTab currentRentalTab;
            SalesTab currentSalesTab;
            MiscTab currentMiscTab;
            ShippingTab currentShippingTab;
            Thread.Sleep(2000);

            SearchTextInMainGrid(_InventoryPOEntity.Id.Trim());

            Thread.Sleep(1000);
            var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                .FirstOrDefault(o => o.Text == _InventoryPOEntity.Id.Trim());

            Thread.Sleep(1000);
            webElementAction.DoubleClick(selectRow);

            var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide")
               .FindElements(By.TagName("div")).FirstOrDefault();

            CreateValidation(_InventoryPOEntity, context);

            //**************************validation Rental Tab*************************************
            ClickTab("RENTALS");
            var rentalGrid = webElementAction.GetElementById("rentalsMiniGrid-MiniGrid-gridId");//.FindElements(By.CssSelector(".ag-row.ag-row-focus"));//
            ReadOnlyCollection<IWebElement> colIds = rentalGrid.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
            currentRentalTab = new RentalTab();
            CreateAddInGrid(currentRentalTab, colIds);
            ValidateEntityFieldDifferences(_InventoryPOEntity.RentalTab, currentRentalTab);

            //**************************validation sales Tab*************************************
            ClickTab("SALES");
            var salesGrid = webElementAction.GetElementById("salesMiniGrid-MiniGrid-gridId");//.FindElements(By.CssSelector(".ag-row.ag-row-focus"));//
            colIds = salesGrid.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
            currentSalesTab = new SalesTab();
            CreateAddInGrid(currentSalesTab, colIds);

            ValidateEntityFieldDifferences(_InventoryPOEntity.SalesTab, currentSalesTab);

            //**************************validation misc Tab*************************************
            ClickTab("MISC");
            var miscGrid = webElementAction.GetElementById("miscMiniGrid-MiniGrid-gridId");//.FindElements(By.CssSelector(".ag-row.ag-row-focus"));//
            colIds = miscGrid.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
            currentMiscTab = new MiscTab();
            CreateAddInGrid(currentMiscTab, colIds);

            ValidateEntityFieldDifferences(_InventoryPOEntity.MiscTab, currentMiscTab);


            //**************************Validation CURRENCY Tab*************************************

            if (CurrentUrlIsMultiLocation())
            {
                context = GetTabContext("CURRENCY");
                ClickTab("CURRENCY");
                var currentValue = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "vendorCurrencyId", context)
                                   .FindElements(By.TagName("input")).FirstOrDefault().GetAttribute("value").Trim();
                if (_InventoryPOEntity.CurrencyTab.VendorCurrency != currentValue)
                    throw new Exception("Doesn't match inserted VendorCurrency ='" + _InventoryPOEntity.CurrencyTab.VendorCurrency + "' with saved VendorCurrency ='" + currentValue + "'\n");

            }

            //**************************validation Shipping Tab*************************************
            ClickTab("SHIPPING");
            var shippingGrid = webElementAction.GetElementById("shippingMiniGrid-MiniGrid-gridId");//.FindElements(By.CssSelector(".ag-row.ag-row-focus"));//
            colIds = shippingGrid.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
            currentShippingTab = new ShippingTab();
            CreateAddInGrid(currentShippingTab, colIds);
            ValidateEntityFieldDifferences(_InventoryPOEntity.ShippingTab, currentShippingTab);
        }

        private static void ClearLocationAndDateTags()
        {
            if (webElementAction.IsElementPresent(By.CssSelector("[class='tag-list-wrapper']")))
            {
                var tagListWrapper = webElementAction.GetElementByCssSelector("[class='tag-list-wrapper']");
                var closeTagBtns = webElementAction.GetAllElementBySpecificAttribute("data-icon-name", "close", tagListWrapper);
                foreach (var item in closeTagBtns)
                {
                    webElementAction.GetAllElementBySpecificAttribute("data-icon-name", "close", tagListWrapper).First().Click();
                }

            }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void DeleteInventoryPO()
        {
            TestInitialize(nameof(DeleteInventoryPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");

                    _InventoryPOEntity = new InventoryPOEntity();
                    //click on addNewRecordBtn
                    webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();

                    var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide")
                        .FindElements(By.TagName("div")).FirstOrDefault();

                    var poNumberElement = webElementAction.GetInputElementByDataFormItemNameInDiv("id", context);
                    var poNumberValue = poNumberElement.GetAttribute("value");
                    var webElementDataGenerator = new WebElementDataGenerator(context);

                    poNumberElement.Clear();
                    poNumberElement.SendKeys(poNumberValue);

                    webElementAction.GetInputElementByDataFormItemNameInDiv("closed").Click();

                    ClickTab("GENERAL");
                    webElementAction.GenerateDataToDataFormItemNameContext(dataFormItemName: "estimatedArrivalDate");
                    //click on saveAndCloseBtn and check confirm
                    SaveAndConfirmCheck();
                    // Clear LocationAndDateTags in grid-list
                    ClearLocationAndDateTags();
                    ShowAllRedord();
                    Delete(poNumberValue, "InventoryPOList-gridId");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ArrowNextBtnCheckInInventoryPO()
        {
            TestInitialize(nameof(ArrowNextBtnCheckInInventoryPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");
                    ShowAllRedord();
                    ArrowNextBtn();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ArrowPreviousBtnCheckInInventoryPO()
        {
            TestInitialize(nameof(ArrowPreviousBtnCheckInInventoryPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");
                    ShowAllRedord();
                    ArrowPreviousBtn();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ArrowLastBtnCheckInInventoryPO()
        {
            TestInitialize(nameof(ArrowLastBtnCheckInInventoryPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");
                    ShowAllRedord();
                    ArrowLastBtn();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ArrowFirstBtnCheckInInventoryPO()
        {
            TestInitialize(nameof(ArrowFirstBtnCheckInInventoryPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");
                    ShowAllRedord();
                    ArrowFirstBtn();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime * 3)]
        public void DetailValidateInventoryPO()
        {
            TestInitialize(nameof(DetailValidateInventoryPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    AddOrEditInventoryPOFunc(OperationType.Add);
                    ListViewBtnValidate();
                    ShowAllRedord();
                    SearchTextInMainGrid(_InventoryPOEntity.Id);
                    var gridList = webElementAction.GetElementById("InventoryPOList-gridId");
                    Thread.Sleep(2000);

                    gridList.FindElements(By.TagName("div"))
                        .FirstOrDefault(o => o.Text == _InventoryPOEntity.Id.Trim()).Click();
                    ChangeScreenPageSize(50);
                    Thread.Sleep(6000);

                    ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                    CreateValidationInGrid(colIds, _InventoryPOEntity);
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPOByBeginEndDate()
        {
            TestInitialize(nameof(FilterInventoryPOByBeginEndDate));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("beginDate", "InventoryPOList-gridId");
                    filterSearch.FilterSearchInDateTimeDataType("date");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPOByPO()
        {
            TestInitialize(nameof(FilterInventoryPOByPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("id", "InventoryPOList-gridId", "PO");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPOByVendor()
        {
            TestInitialize(nameof(FilterInventoryPOByVendor));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("vendorId", "InventoryPOList-gridId", "Vendor");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPOByCreatedBy()
        {
            TestInitialize(nameof(FilterInventoryPOByCreatedBy));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("createById", "InventoryPOList-gridId", "Created by", colId: "createBy");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPOByDescription()
        {
            TestInitialize(nameof(FilterInventoryPOByDescription));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("description", "InventoryPOList-gridId", "Description");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPOByIncludeClosed()
        {
            TestInitialize(nameof(FilterInventoryPOByIncludeClosed));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");

                    RefreshAllRows();
                    ShowAllRedord();
                    FilterSearch filterSearch = new FilterSearch("includeClosed", "InventoryPOList-gridId", "Closed", colId: "closed");
                    filterSearch.FilterSearchInCheckBoxDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPOByIncludeHistory()
        {
            TestInitialize(nameof(FilterInventoryPOByIncludeHistory));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");

                    RefreshAllRows();
                    DataLegendNameFilter("HISTORY");
                    FilterSearch filterSearch = new FilterSearch("includeHistory", "InventoryPOList-gridId", "History", "history");
                    filterSearch.FilterSearchInCheckBoxDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRequiredFieldsMessageBoxInInventoryPO()
        {
            TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInInventoryPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    ValidateRequiredFieldsMessage validateRequiredFields;
                    validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "PurchaseOrder", subMenu: "InventoryPO", filed: "description");
                    validateRequiredFields.Run();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        string[] InventoryPOStatusList = { "COMPLETE", "NOT_RECEIVED", "HISTORY", "NOT_POSTED", "VOID" };

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateInventoryPOStatusInEntryScreen()
        {
            TestInitialize(nameof(ValidateInventoryPOStatusInEntryScreen));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");
                    foreach (var status in InventoryPOStatusList)
                    {
                        ClearAllTagList();
                        SetCustomShowAll(status);
                        var idElement = RetrieveVisibleColumnIdsInMainGrid("id").FirstOrDefault();
                        if (idElement != null)
                        {
                            webElementAction.DoubleClick(idElement);
                            WaitForLoadingSpiner();
                            var statusElement = webElementAction.GetElementBySpecificAttribute("data-form-item-name", status);
                            if (statusElement.Text.ToUpper().Replace(" ", "_") != status)
                                Assert.Fail("The Status of the Inventory PO item does not appears as a label on the right side of the Inventory Purchase Order Entry Screen");
                            GoToUrl("PurchaseOrder", "InventoryPO", gotoLogin: false);
                        }
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGrid()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPO");
                    RefreshRecordDataInGrid("InventoryPOList-gridId", columnId: "id");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
