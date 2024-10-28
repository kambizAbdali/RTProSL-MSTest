using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using TimeoutAttribute = Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute;

// Help:  https://help.sl.demo.rtpro.com/Content/Chapters/Chapter6%20Order%20Processing/Ship%20Sales%20Stock%20Items.htm?skinName=1a237e
namespace RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen.Sales
{
    [TestClass]
    public class SalesCheckout : Sales
    {
        private const int rowCountForValidate = 5;
        public SalesCheckout()
        {
            QuantityOrdersInPickList = new string[rowCountForValidate];
            StockNumberInPickList = new string[rowCountForValidate];
        }
        private string StockNumberInSalesCheckout { get; set; }
        private string OrderedInSalesCheckout { get; set; }
        public string[] QuantityOrdersInPickList { get; set; }
        public string[] StockNumberInPickList { get; set; }


        private string ValidateSalesOrderDetailsInSalesCheckout()  //
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
            GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_CHECKOUT");
            var colIds = webElementAction.GetElementById("salesCheckoutScreen-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
            WaitForLoadingSpiner();
            Thread.Sleep(1000);
            StockNumberInSalesCheckout = colIds.First(o => o.GetAttribute("col-id") == "stockNo").Text;
            OrderedInSalesCheckout = colIds.First(o => o.GetAttribute("col-id") == "ordered").Text;

            if (StockNumberInSalesOrder != StockNumberInSalesCheckout)
            {
                throw new Exception("Doesn't equals Stock Number In Sales Order(='" + StockNumberInSalesOrder + "') with saved Stock Number In Sales Checkout (='" + StockNumberInSalesCheckout + "')");
            }

            if (OrderedInSalesOrder != OrderedInSalesCheckout)
            {
                throw new Exception("Doesn't equals Ordered In Sales Order with saved Ordered In Sales Checkout");
            }

            return StockNumberInSalesCheckout;
        }


        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ShipByRighClickOnRow_Business()
        {
            TestInitialize(nameof(ShipByRighClickOnRow_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(callFromOrderProcessingScreen: true);
                    }

                    /* Step 2: Add Sales Order*/
                    {
                        AddSalesOrder();
                    }

                    /* Step 3: Add Sales Item*/
                    {
                        AddSalesItem();
                    }

                    /* Step 4: Sales Ship Sales from RighClickOnRow*/
                    {
                        ShipFromSalesCheckout(AddShipMethod.RighClickOnRow);
                    }

                    /* Step 5: Validate in Shipped Items Grid */
                    {
                        ValidateShipItemsInSalesCheckout();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void MassShipDialog_Business()
        {
            TestInitialize(nameof(MassShipDialog_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(callFromOrderProcessingScreen: true);
                    }

                    /* Step 2: Add Sales Order*/
                    {
                        AddSalesOrder();
                    }

                    /* Step 3: Add Sales Item*/
                    {
                        AddSalesItem();
                    }

                    /* Step 4: Sales Ship Sales from RightSideFrom*/
                    {
                        ShipFromSalesCheckout(AddShipMethod.MassShipDialog);
                    }

                    /* Step 5: Validate in Shipped Items Grid */
                    {
                        ValidateShipItemsInSalesCheckout();
                    }

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime * (3 / 2))]
        public void ShipByRightSideFrom_Business()
        {
            TestInitialize(nameof(ShipByRightSideFrom_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(callFromOrderProcessingScreen: true);
                    }

                    /* Step 2: Add Sales Order*/
                    {
                        AddSalesOrder();
                    }

                    /* Step 3: Add Sales Item*/
                    {
                        AddSalesItem(containSerialNumber: true);
                    }

                    /* Step 4: Sales Ship Sales from RightSideFrom */
                    {
                        ShipFromSalesCheckout(AddShipMethod.RightSideFrom);
                    }

                    /* Step 5: Validate in Shipped Items Grid */
                    {
                        ValidateShipItemsInSalesCheckout();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void ValidateShipItemsInSalesCheckout()
        {
            var shipGridcolIds = webElementAction.GetElementById("salesCheckoutCheckedOut-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
            WaitForLoadingSpiner();
            Thread.Sleep(1000);
            var stockNoInShipGrid = shipGridcolIds.First(o => o.GetAttribute("col-id") == "stockNoId").Text;
            decimal quantityInShipGrid = decimal.Parse(shipGridcolIds.First(o => o.GetAttribute("col-id") == "quantity").Text);

            if (stockNoInShipGrid != StockNumberInSalesOrder)
            {
                throw new Exception("Doesn't equals stock Number In ShipGrid with saved Stock Number In Sales Order");
            }

            if (quantityInShipGrid != 1)
            {
                throw new Exception("Doesn't equals quantity In Ship Grid with saved default quantity (1.00)");
            }
        }

        private void ShipFromSalesCheckout(AddShipMethod addShipeMethod)
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
            GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_CHECKOUT");

            switch (addShipeMethod)
            {
                case AddShipMethod.RightSideFrom:

                    OpenDetailDialogInRightSide();

                    if (webElementAction.IsElementPresent(By.CssSelector(".tab-more-icon")))
                    {
                        webElementAction.Click(By.CssSelector(".tab-more-icon"));
                        webElementAction.Click(By.XPath("//li[.='Ship Sales']"));
                    }
                    else
                    {
                        webElementAction.Click(By.XPath("//div[.='Ship Sales']"));
                    }

                    //Send stockNumber Input
                    var stockNumberInput = webElementAction.GetElementByXPath("//div[@class='main-code-input code-input-class-name normal-code-input']//input[@class='main-input suppress-tab-on-enter main-input-no-value']");
                    stockNumberInput.Clear();
                    stockNumberInput.SendKeys(StockNumberInSalesOrder);

                    var goBtn = webElementAction.GetElementByCssSelector(".simple-barcode span");
                    goBtn.Click();
                    WaitForLoadingSpiner();
                    // refresh page
                    webElementAction.GetElementByCssSelector(".icon-refresh").Click();
                    break;

                case AddShipMethod.RighClickOnRow:
                    IWebElement salesCheckoutGrid = webElementAction.GetElementById("salesCheckoutScreen-gridId");
                    var allColIds = salesCheckoutGrid.FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
                    var stockNoCol = allColIds.First(o => o.GetAttribute("col-id") == "stockNo");
                    webElementAction.RighClick(stockNoCol);
                    webElementAction.GetElementByXPath("//span[.='Ship']").Click();
                    ConfirmBtnCheck(dataSection: "modal", confirm: true);
                    break;

                case AddShipMethod.MassShipDialog:  //AddShipMethod:[MassShipDialog, ShippAll, MassShip_With_Serial]

                    GoToSubMenu("CHECKOUT_TOOL_DROPDOWN", "SHIP_DIALOG");
                    ConfirmBtnCheck(dataSection: "modal", confirm: true);  //Mass Ship Dialog
                    break;

                case AddShipMethod.ShippAll:

                    GoToSubMenu("CHECKOUT_TOOL_DROPDOWN", "SHIP_ALL");
                    ConfirmBtnCheck(dataSection: "confirmDialog", confirm: true);  //Confirm: All the items ordered on this order will be shipped out. Continue?
                    break;

                case AddShipMethod.MassShip_With_Serial:

                    GoToSubMenu("CHECKOUT_TOOL_DROPDOWN", "MASS_SHIP_CANCEL_RETURN_WITH_SERIAL");
                    ConfirmBtnCheck(dataSection: "confirmDialog", confirm: true);  //Confirm: All the items ordered on this order will be shipped out. Continue?

                    var massShipGrid = webElementAction.GetElementById("massShipWithSerial-gridId");
                    //find serial number in div
                    var serialNumber = massShipGrid.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == SerialNumber);
                    serialNumber.Click();

                    ConfirmBtnCheck(confirm: true, dataSection: "list");

                    //Confirm: Update Order?
                    ConfirmBtnCheck(confirm: true, dataSection: "confirmDialog");

                    //Information: Success
                    ConfirmBtnCheck(dataSection: "infoDialog");

                    GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
                    GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_CHECKOUT");
                    break;

                default:
                    // code block
                    break;
            }
        }

        public enum AddShipMethod  //In RTPro, there are a few different ways to ship Sales Stock items:
        {
            RightSideFrom,
            RighClickOnRow,
            MassShipDialog,
            ShippAll,
            MassShip_With_Serial
        }
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ShipAllFromSalesCheckout_Business()
        {
            TestInitialize(nameof(ShipAllFromSalesCheckout_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(callFromOrderProcessingScreen: true);
                    }

                    /* Step 2: Add Sales Order*/
                    {
                        AddSalesOrder();
                    }

                    /* Step 3: Add Sales Item*/
                    {
                        AddSalesItem();
                    }

                    /* Step 4: Sales Ship from RightSideFrom*/
                    {
                        ShipFromSalesCheckout(AddShipMethod.ShippAll);
                    }
                    /* Step 5: Validate in Shipped Items Grid */
                    {
                        ValidateShipItemsInSalesCheckout();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void MassShipBySerial_Business()
        {
            TestInitialize(nameof(MassShipBySerial_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(callFromOrderProcessingScreen: true);
                    }
                    /* Step 2: Add Sales Order*/
                    {
                        AddSalesOrder();
                    }

                    /* Step 3: Add Sales Item*/
                    {
                        AddSalesItem(containSerialNumber: true);
                    }

                    /* Step 4: Sales Ship Sales from MassShip_Cancel_Return_With_Serial*/
                    {
                        ShipFromSalesCheckout(AddShipMethod.MassShip_With_Serial);
                    }

                    /* Step 5: Validate in Shipped Items Grid */
                    {
                        ValidateShipItemsInSalesCheckout();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ReturnAll_Business()
        {
            TestInitialize(nameof(ReturnAll_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(callFromOrderProcessingScreen: true);
                    }
                    /* Step 2: Add Sales Order*/
                    {
                        AddSalesOrder();
                    }

                    /* Step 3: Add Sales Item*/
                    {
                        AddSalesItem();
                    }

                    /* Step 4: Sales Ship from Right Side From*/
                    {
                        ShipFromSalesCheckout(AddShipMethod.RightSideFrom);
                    }

                    /* Step 5: Return All*/
                    {
                        ReturnAll();
                    }

                    /* Step 6: Validate in Shipped Items Grid */
                    {
                        ValidateShipItemsInSalesCheckout();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        //DropShip:  Sometimes items are not shipped from your warehouse, and they are shipped to the customer directly from the Vendor's warehouse instead.
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void DropShip_Business()
        {
            TestInitialize(nameof(DropShip_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(callFromOrderProcessingScreen: true);
                    }
                    /* Step 2: Add Sales Order*/
                    {
                        AddSalesOrder();
                    }

                    /* Step 3: Add Sales Item*/
                    {
                        AddSalesItem(containSerialNumber: true);
                    }

                    /* Step 4: DripShip: For drop shipping to take place, the shipping process must be completed first.*/
                    {
                        DropShip();
                    }

                    /* Step 5: Validate in Shipped Items Grid */
                    {
                        ValidateShipItemsInSalesCheckout();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void DropShip()
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
            GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_CHECKOUT");
            IWebElement salesCheckoutGrid = webElementAction.GetElementById("salesCheckoutScreen-gridId");
            var allColIds = salesCheckoutGrid.FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
            var stockNoCol = allColIds.First(o => o.GetAttribute("col-id") == "stockNo");
            webElementAction.RighClick(stockNoCol);
            webElementAction.GetElementByXPath("//span[.='Drop Ship']").Click();

            var dropModal = webElementAction.GetElementBySpecificAttribute("data-modal-title", "DROP_INPUT_BOX");
            var vendorContext = dropModal.FindElements(By.CssSelector(".combo-auto-complete"));
            new WebElementDataGenerator().ComboAutoCompleteGenerator(vendorContext); //generate data to Vendor
            ConfirmBtnCheck(dataSection: "modal", confirm: true);
        }

        private void ReturnAll()
        {
            GoToSubMenu("CHECKOUT_TOOL_DROPDOWN", "RETURN_ALL");
            ConfirmBtnCheck(confirm: true, dataSection: "confirmDialog");
        }


        [TestMethod, Timeout(MaximumExecutionTime)]
        public void SalesOrder_Business()
        {
            TestInitialize(nameof(SalesOrder_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(callFromOrderProcessingScreen: true);
                    }
                    /* Step 2: Add Sales Order*/
                    {
                        AddSalesOrder();
                    }
                    /* Step 3: Validate Seles Order In Sales Checkout Page*/
                    {
                        ValidateSalesOrderDetailsInSalesCheckout();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ShipSales_Business()
        {
            TestInitialize(nameof(ShipSales_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(callFromOrderProcessingScreen: true);
                    }
                    /* Step 2: Add Sales Order*/
                    {
                        AddSalesOrder();
                    }
                    string stockNumber;
                    /* Step 3: Validate Seles Order In Sales Checkout Page*/
                    {
                        stockNumber = ValidateSalesOrderDetailsInSalesCheckout();
                    }

                    /* Step 4: Ship sales*/
                    {
                        // TODO: 
                        //ShipSales();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime * 2)]
        public void SellAndReturnBarcoded_Business()
        {
            TestInitialize(nameof(SellAndReturnBarcoded_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string orderNum = default(string), barcode = default(string), stockNum = default(string), equipmentCode = default(string);
                    //string orderNum = "105213", barcode = "10000794", stockNum = "KGF0UMPMKD", equipmentCode = default(string);

                    // Step 1) --- Add order
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        orderNum = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(callFromOrderProcessingScreen: true);
                        Console.WriteLine(" Step 1 passed...");
                    }
                    // Step 2) --- Add BarcodeEquipment
                    {
                        equipmentCode = equipmentCheckOutInAndBilling.AddBarcodeEquipmentWithRequiredFields(IsLoginPageRequired: false);
                        Console.WriteLine(" Step 2 passed...");
                    }

                    // Step 3) --- Add Stock# to Equipment
                    {
                        stockNum = AddStockNumberToEquipment(equipmentCode);
                        ConfirmBtnCheck(dataSection: "alertDialog");
                        Console.WriteLine(" Step 3 passed...");
                    }

                    // Step 4) Add Barcode Items To Equipment
                    {
                        GoToUrl("MMInventory", "EquipmentList", gotoLogin: false);
                        barcode = equipmentCheckOutInAndBilling.AddBarcodeItemToEquipment(equipmentCode);
                        Console.WriteLine(" Step 4 passed...");
                    }

                    /* Step 5) Add Sales Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
                        AddSalesOrder(stockNum);
                        Console.WriteLine(" Step 5 passed...");
                    }

                    // step 6: --- Sell Barcode
                    {
                        SellBarcode(barcode);
                        Console.WriteLine(" Step 6 passed...");
                    }

                    // step 7: --- Return barcode
                    {
                        ReturnBarcode(barcode);
                        Console.WriteLine(" Step 7 passed...");
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void SellBarcode(string barcode)
        {
            Thread.Sleep(1000);
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
            GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_CHECKOUT");
            //var colIds = webElementAction.GetElementById("salesCheckoutScreen-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//

            OpenDetailDialogInRightSide();

            // click on more icon
            if (webElementAction.IsElementPresent(By.CssSelector(".tab-more-icon")))
            {
                webElementAction.Click(By.CssSelector(".tab-more-icon"));
                webElementAction.Click(By.XPath("//li[.='Sell Barcode']"));
            }
            else
            {
                webElementAction.Click(By.XPath("//div[.='Ship Sales']"));
            }

            //Send barcode Input
            var barcodeInput = webElementAction.GetElementByCssSelector(".tab-content[data-tab-name='SALES_BARCODE'] > .tab-content-container > div:nth-of-type(2)").FindElements(By.TagName("input")).Last();
            barcodeInput.SendKeys(barcode);

            var goBtn = webElementAction.GetElementByXPath("//div[@class='tab-content']//span[.='Go']");
            goBtn.Click();
            WaitForLoadingSpiner();
            // refresh page
            webElementAction.GetElementByCssSelector(".icon-refresh").Click();
            Thread.Sleep(1000);
        }

        private void ReturnBarcode(string barcode)
        {
            OpenDetailDialogInRightSide();
            Thread.Sleep(2000);
            // click on more icon

            if (webElementAction.IsElementPresent(By.CssSelector(".tab-more-icon")))
            {
                webElementAction.Click(By.CssSelector(".tab-more-icon"));
                webElementAction.Click(By.XPath("//li[.='Return Barcode']"));
            }
            else
            {
                webElementAction.Click(By.XPath("//div[.='Return Barcode']"));
            }

            //Send barcode Input   
            var barcodeInput = webElementAction.GetElementByCssSelector(".tab-content[data-tab-name='RETURN_BARCODE'] > .tab-content-container > div:nth-of-type(2)").FindElements(By.TagName("input")).Last();
            barcodeInput.Clear();
            barcodeInput.SendKeys(barcode);

            var goBtn = webElementAction.GetElementByXPath("//div[@class='tab-content']//span[.='Go']");
            goBtn.Click();
            WaitForLoadingSpiner();
            // refresh page
            webElementAction.GetElementByCssSelector(".icon-refresh").Click();
        }

        private string AddStockNumberToEquipment(string equipmentCode)
        {
            GoToUrl("MMInventory", "EquipmentSummaryList", gotoLogin: false);
            SearchAndEditClick(equipmentCode);
            ClickTab("SETTING");
            webElementAction.SelectingCheckbox("sellable");
            webElementAction.ClickOnPostChanges();

            Thread.Sleep(2000);
            //Click on Sales stock screen
            webElementAction.Click(By.CssSelector(".outlined-button"));

            var mainContex = GetFormLeftSideContext(isNested: true);
            webElementAction.GenerateDataToRequiredFields(context: mainContex);
            //var webElementDataGenerator = new WebElementDataGenerator(mainContex);

            webElementAction.DeSelectingCheckbox("inactive");

            if (webElementAction.IsElementPresent(By.CssSelector(".mainButton[data-tab-name='PRICING_GL'] > .position-relative")))
            {
                var pricingGlContext = GetTabContext("PRICING_GL");
                ClickTab("PRICING_GL");
                webElementAction.GenerateDataToDataFormItemNameContext("glIncomeId");
                webElementAction.GenerateDataToRequiredFields(context: pricingGlContext);
            }

            webElementAction.ClickOnPostChanges();
            Thread.Sleep(3000);
            string stockNum = webElementAction.GetElementByCssSelector(".search-code-Input").GetAttribute("value");
            return stockNum;
        }
    }
}