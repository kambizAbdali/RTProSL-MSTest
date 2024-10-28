using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using TimeoutAttribute = Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute;

// Help:  https://help.sl.demo.rtpro.com/Content/Chapters/Chapter6%20Order%20Processing/Ship%20Sales%20Stock%20Items.htm?skinName=1a237e
namespace RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen.Sales
{
    [TestClass]
    public class SalesOrder : Sales
    {
        private const int rowCountForValidate = 5;

        public SalesOrder()
        {
            equipmentCheckOutInAndBilling = new EquipmentCheckOutInAndBilling();
            QuantityOrdersInPickList = new string[rowCountForValidate];
            StockNumberInPickList = new string[rowCountForValidate];
        }

        private EquipmentCheckOutInAndBilling equipmentCheckOutInAndBilling;
        private string OrderedInSalesOrder { get; set; }
        private string StockNumberInSalesCheckout { get; set; }
        private string OrderedInSalesCheckout { get; set; }
        private string SerialNumber { get; set; }

        public string[] QuantityOrdersInPickList { get; set; }
        public string[] StockNumberInPickList { get; set; }

        private string AddSalesItem(bool containSerialNumber = false)
        {
            GoToUrl("MMInventory", "SalesStockSummary", gotoLogin: false);
            RefreshAllRows();
            SearchAndEditClick(StockNumberInSalesOrder);
            GoToSubMenu("ACTION_TOOL_DROPDOWN", "ADD_SALES_ITEMS");
            var Quantity = webElementAction.GetInputElementByDataFormItemNameInDiv("Quantity");
            Quantity.SendKeys(RandomValueGenerator.GenerateRandomInt(2, 5));

            if (containSerialNumber)
            {
                var SerialNoElement = webElementAction.GetElementByCssSelector("[name='SerialNo']");
                //"If the serial number input element is disabled, first the checkbox for entering the serial number must be ticked."
                if (SerialNoElement.GetAttribute("disabled") != null)
                    webElementAction.GetInputElementByDataFormItemNameInDiv("EnterSerialNo").Click();
                SerialNumber = RandomValueGenerator.GenerateRandomInt(5);
                SerialNoElement.SendKeys(SerialNumber);
            }

            var addElement = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "submit-button");
            addElement.Click();
            Thread.Sleep(500);
            var SalesOrderGridcolIds = webElementAction.GetElementById("addSalesItems-MiniGrid-gridId")
                .FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]")); //
            WaitForLoadingSpiner();
            Thread.Sleep(1000);
            var stockNo = SalesOrderGridcolIds.First(o => o.GetAttribute("col-id") == "stockNo").Text;

            return stockNo;
        }


        [TestMethod, Timeout(MaximumExecutionTime)]
        public void SalesOrderFromPickList_Business() //
        {
            TestInitialize(nameof(SalesOrderFromPickList_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(
                            callFromOrderProcessingScreen: true);
                    }

                    /* Step 2: Add sales Items from Pick List*/
                    {
                        AddSalesOrderFromPickList();
                    }

                    /* Step 3: Validate Inserted PickListItems In Sales Order Screen*/
                    {
                        ValidateInsertedPickListItemsInSalesOrder();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void ValidateInsertedPickListItemsInSalesOrder()
        {
            var salesOrderGrid = webElementAction.GetElementById("SalesItems-gridId");

            var quantityOrderedColIdsInSalesOrder =
                webElementAction.GetAllCellsInMinGridBySpecificColId(gridId: "SalesItems-gridId", colId: "ordered");
            var stockNumberColIdsInSalesOrder =
                webElementAction.GetAllCellsInMinGridBySpecificColId(gridId: "SalesItems-gridId", colId: "stockNoId");

            for (int i = 0; i < rowCountForValidate; i++)
            {
                if (QuantityOrdersInPickList[i] != quantityOrderedColIdsInSalesOrder[i].Text)
                    throw new Exception(
                        "Does not equals quantity OrderedColIdsInSalesOrder with Inserted QuantityOrders In PickList.");

                if (StockNumberInPickList[i] != stockNumberColIdsInSalesOrder[i].Text)
                    throw new Exception(
                        "Does not equals stockNumber In SalesOrder with Inserted StockNumber In PickList.");
            }
        }

        private void AddSalesOrderFromPickList()
        {
            GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_ORDER");
            GoToSubMenu("ACTION_TOOL_DROPDOWN", "PICK_LIST");
            RefreshAllRows();
            var quantityOrderedColIdsInPickList =
                webElementAction.GetAllCellsInMinGridBySpecificColId(gridId: "salesEntryPickList-gridId",
                    colId: "ordered");

            for (int i = 0; i < rowCountForValidate; i++)
            {
                quantityOrderedColIdsInPickList[i].SendKeys(RandomValueGenerator.GenerateRandomInt(1, 5));
                quantityOrderedColIdsInPickList[i + 1]
                    .Click(); // "If the focus is on a cell, its value is not readable, so we click on the next cell for this reason."
                QuantityOrdersInPickList[i] = quantityOrderedColIdsInPickList[i].Text;
            }

            var stockNumberColIdsInPickList =
                webElementAction.GetAllCellsInMinGridBySpecificColId(gridId: "salesEntryPickList-gridId",
                    colId: "stockNo");

            for (int i = 0; i < rowCountForValidate; i++)
                StockNumberInPickList[i] = stockNumberColIdsInPickList[i].Text;

            ConfirmBtnCheck(confirm: false, dataSection: "list");
            WaitForLoadingSpiner();
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ShipAllFromSalesOrder_Business()
        {
            TestInitialize(nameof(ShipAllFromSalesOrder_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(
                            callFromOrderProcessingScreen: true);
                    }

                    /* Step 2: Add Sales Order*/
                    {
                        AddSalesOrder();
                    }

                    /* Step 3: Add Sales Item*/
                    {
                        AddSalesItem();
                    }

                    /* Step 4: Ship All From SalesOrder*/
                    {
                        ShipAllFromSalesOrder();
                    }
                    /* Step 5: Vaidate Ship Items In Sales Order */
                    {
                        VaidateShipItemsInSalesOrder();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void ShipAllFromSalesOrder()
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
            GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_ORDER");
            GoToSubMenu("ACTION_TOOL_DROPDOWN", "SHIP_ALL");
            ConfirmBtnCheck(dataSection: "confirmDialog",
                confirm: true); //Confirm All the items ordered on this order will be shipped out. Continue?
        }

        private void VaidateShipItemsInSalesOrder()
        {
            var SalesOrderGridcolIds = webElementAction.GetElementById("SalesItems-gridId")
                .FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]")); //
            WaitForLoadingSpiner();
            Thread.Sleep(1000);
            var stockNoInShipGrid = SalesOrderGridcolIds.First(o => o.GetAttribute("col-id") == "stockNoId").Text;
            decimal quantityInShipGrid =
                decimal.Parse(SalesOrderGridcolIds.First(o => o.GetAttribute("col-id") == "ordered").Text);

            if (stockNoInShipGrid != StockNumberInSalesOrder)
            {
                throw new Exception("Doesn't equals stock Number In ShipGrid with saved Stock Number In Sales Order");
            }

            if (quantityInShipGrid != 1)
            {
                throw new Exception("Doesn't equals quantity In Ship Grid with saved default quantity (1.00)");
            }
        }

        //When we want to order a set of related or interconnected equipment such as a TV, a remote control, and TV remote batteries.
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void SaveSalesAsKitInSalesOrder_Business() // related to Sales order
        {
            TestInitialize(nameof(SaveSalesAsKitInSalesOrder_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        string orderNumber;
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(
                            callFromOrderProcessingScreen: true);
                    }

                    /* Step 2: Add Sales Order*/
                    {
                        AddSalesOrder();
                    }
                    string stockNumber;
                    /* Step 3: Add Sales Item*/
                    {
                        stockNumber = AddSalesItem();
                    }

                    string kitCode;
                    /* Step 4: Save As Kit*/
                    {
                        kitCode = SaveSalesAsKit();
                    }

                    /* Step 5: Vaidate inserted sales Kit In sales KitList*/
                    {
                        VaidateInsertedSalesKitAndStockInKitList(kitCode, stockNumber);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private string SaveSalesAsKit(bool currentUrlIsSalesOrder = false)
        {
            if (!currentUrlIsSalesOrder)
            {
                GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
                WaitForLoadingSpiner();
                GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_ORDER");
                WaitForLoadingSpiner();
            }

            GoToSubMenu("ACTION_TOOL_DROPDOWN", "KIT", "SAVE_AS_KIT");
            var saveAsNewKitForm = webElementAction.GetElementByCssSelector(".advance-left-section");
            new WebElementDataGenerator(saveAsNewKitForm);
            string kitCode = webElementAction.GetElementByName("kitCode").GetAttribute("value");

            if (CurrentUrlIsMultiLocation())
            {
                string currentLocation = GetCurrentLocation();
                var locationContext =
                    webElementAction.GetAllElementsByCssSelector("[data-form-item-name='locationId']");
                new WebElementDataGenerator().ComboAutoCompleteGenerator(locationContext, searchFiter: currentLocation);
            }

            ConfirmBtnCheck(dataSection: "modal");
            return kitCode;
        }

        private void VaidateInsertedSalesKitAndStockInKitList(string kitCode, string stockNumber)
        {
            WaitForLoadingSpiner();
            GoToUrl("MMInventory", "SalesKitList", gotoLogin: false);
            RefreshAllRows();

            var kitListGrid = webElementAction.GetElementById("SalesKitList-gridId");

            FindColumnInMainGrid(ColumnValue: "Code", gridId: "SalesKitList-gridId");

            var kitCodeElement = kitListGrid.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == kitCode);
            if (kitCodeElement == null)
                throw new Exception("The kitCode inserted in the kit list page was not found !!!");
            webElementAction.DoubleClick(kitCodeElement);
            Thread.Sleep(2000);
            var salesStockGrid = webElementAction.GetElementById("SalesKitDetail-gridId");

            var salesStockElement = salesStockGrid.FindElements(By.TagName("div"))
                .FirstOrDefault(o => o.Text == stockNumber);
            if (salesStockElement == null)
                throw new Exception("the salesStock number inserted in the Sales kit detail screen was not found !!!");
        }

        private void RemovePOS()
        {
            //click on icon menu kebab
            ClickOnIconMenuKebab();
            //click on ADD_POS subMenu
            Thread.Sleep(1000);
            webElementAction.Click(By.CssSelector("li[data-menu-id*='REMOVE_POS']"));
            ConfirmBtnCheck();
        }

        //When we want to order a set of related or interconnected equipment such as a TV, a remote control, and TV remote batteries.
        [TestMethod, Timeout(MaximumExecutionTime + (MaximumExecutionTime / 2))]
        public void CopyFromAKitInSalesOrder_Business() // related to Sales order
        {
            TestInitialize(nameof(CopyFromAKitInSalesOrder_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Add a Order*/
                    {
                        NavigateToOrderProcessingScreen(gotoLogin: true);
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(
                            callFromOrderProcessingScreen: true);
                    }

                    /* Step 2: Add Sales Order*/
                    {
                        AddSalesOrder();
                    }

                    string stockNumber;
                    /* Step 3: Add Sales Item*/
                    {
                        stockNumber = AddSalesItem();
                    }

                    string kitCode;
                    /* Step 4: Add Sales Kit List*/
                    {
                        kitCode = AddKitList(OrderType.Sales);
                    }

                    /* Step 5: Copy From a Kit*/
                    {
                        CopyFromAKit(kitCode, OrderType.Sales);
                    }

                    /* Step 6: Vaidate inserted sales Kit In sales KitList*/
                    {
                        //note: Due to the large grid-list, kit code needs to be left-aligned for visibility.
                        VaidateInsertedKit(kitCode, OrderType.Sales);
                    }

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void SaveAsSalesTruck_Business() // related to Sales order
        {
            TestInitialize(nameof(SaveAsSalesTruck_Business));

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

                    string truckCode = default;
                    /* Step 3: Save As Sales Truck*/
                    {
                        //note: Due to the large grid-list, truck number needs to be left-aligned for visibility.
                        truckCode = SaveAsOrderTruck(OrderType.Sales);
                    }

                    /* Step 5: Vaidate inserted sales truck In sales truck List*/
                    {
                        VaidateInsertedSalesTruckInSalesTruckList(truckCode);
                    }

                    //Add Sales Truck
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        public void VaidateInsertedSalesTruckInSalesTruckList(string truckCode)
        {
            WaitForLoadingSpiner();
            GoToUrl("MMInventory", "SalesTruckList", gotoLogin: false);
            RefreshAllRows();
            ClearAllTagList();
            var salesTruckListGrid = webElementAction.GetElementById("SalesTruckList-gridId");

            var truckCodeElement = salesTruckListGrid.FindElements(By.TagName("div"))
                .FirstOrDefault(o => o.Text == truckCode);
            if (truckCodeElement == null)
                throw new Exception("The truckCode inserted in the truck list page was not found !!!");
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void AddSalesTruckInSalesOrderScreen_Business()
        {
            TestInitialize(nameof(AddSalesTruckInSalesOrderScreen_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    //* Step 1: Add a new Order and get its orderNo *//
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                        equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(
                            callFromOrderProcessingScreen: true);
                    }

                    var truckCode = string.Empty;
                    //* Step 2: Add a new Order truck *//
                    {
                        truckCode = AddOrderTruck(OrderType.Sales);
                    }

                    /* Step 3: Vaidate inserted sales truck In sales truck List*/
                    {
                        VaidateInsertedSalesTruckInSalesOrderScreen(truckCode);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void VaidateInsertedSalesTruckInSalesOrderScreen(string truckCode)
        {
            WaitForLoadingSpiner();
            FindColumnInMainGrid(ColumnValue: "Truck", gridId: "SalesItems-gridId");
            Thread.Sleep(1000);
            var salesItemsGrid = webElementAction.GetElementById("SalesItems-gridId");
            var truckCodeElement =
                salesItemsGrid.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == truckCode);
            if (truckCodeElement == null)
                throw new Exception("The truckCode inserted in the truck list page was not found !!!");
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void AddPOSAndShippAll_Business()
        {
            TestInitialize(nameof(AddPOSAndShippAll_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string defaultPOSCustomer = default, orderNo = default;
                    //* Step 1: Selecting Default POS Customer *//
                    {
                        defaultPOSCustomer = SelectingDefaultPOSCustomer();
                    }

                    //* Step 2: Add POS *//
                    {
                        AddPosFromOrderProcessing(out orderNo);
                    }

                    /* Step 3: Ship All From SalesOrder*/
                    {
                        GoToSubMenu("ACTION_TOOL_DROPDOWN", "SHIP_ALL");
                        WaitForLoadingSpiner();
                        ConfirmBtnCheck(dataSection: "confirmDialog",
                            confirm: true); //Confirm All the ordered items on this order will be shipped out. Continue?
                    }

                    /* Step 4: Vaidate Ship Items In Sales Order */
                    {
                        var colIds = webElementAction.GetElementById("SalesItems-gridId")
                            .FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]")); //
                        StockNumberInSalesOrder = colIds.First(o => o.GetAttribute("col-id") == "stockNoId").Text;
                        VaidateShipItemsInSalesOrder();
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private string SelectingDefaultPOSCustomer()
        {
            GoToUrl("Administration", "SystemSetup");

            string point_of_sales_Url = ObjectRepository.Driver.Url + "?path=point_of_sales";

            NavigationHelper.NavigateToUrl(point_of_sales_Url);

            WaitForLoadingSpiner();

            ClickOnEditBtn();

            webElementAction.GenerateDataToDataFormItemNameContext(dataFormItemName: "posDefaultProduction");

            //click on post Btn
            webElementAction.GetElementByCssSelector(".icon-tick").Click();

            ConfirmBtnCheck(); //Save Changes

            var posDefaultProduction = webElementAction.GetInputElementByDataFormItemNameInDiv("posDefaultProduction")
                .GetAttribute("value");
            return posDefaultProduction;
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void AddPOSAndSaveSalesAsKit_Business()
        {
            TestInitialize(nameof(AddPOSAndShippAll_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string defaultPOSCustomer = default, orderNo = default;
                    //* Step 1: Selecting Default POS Customer *//
                    {
                        defaultPOSCustomer = SelectingDefaultPOSCustomer();
                    }

                    //* Step 2: Add POS *//
                    {
                        AddPosFromOrderProcessing(out orderNo);
                    }

                    string kitCode;
                    /* Step 3: Save As Kit*/
                    {
                        kitCode = SaveSalesAsKit(currentUrlIsSalesOrder: true);
                    }

                    /* Step 4: Vaidate inserted sales as Kit In sales KitList*/
                    {
                        var colIds = webElementAction.GetElementById("SalesItems-gridId")
                            .FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]")); //
                        StockNumberInSalesOrder = colIds.First(o => o.GetAttribute("col-id") == "stockNoId").Text;
                        VaidateInsertedSalesKitAndStockInKitList(kitCode, StockNumberInSalesOrder);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        string AddPosFromOrderProcessing(out string orderNo)
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);

            equipmentCheckOutInAndBilling.ClearOrderProcessingFields();
            //click on icon menu kebab
            ClickOnIconMenuKebab();

            //click on ADD_POS subMenu
            Thread.Sleep(1000);

            webElementAction.Click(By.CssSelector("li[data-menu-id*='ADD_POS']"));

            WaitForLoadingSpiner();

            orderNo = webElementAction
                .GetElementByCssSelector("[data-info-name='ORDER_NO'] .value-wrapper .ellipsis-content").Text;

            webElementAction.AddNewRowToMinGrid(DataHeaderName: "SalesItems", GridId: "SalesItems-gridId", clickOnPostBtn: false);

            FindColumnInMainGrid(ColumnValue: "Quantity Ordered", gridId: "SalesItems-gridId");
            webElementAction.SetValueToInputCellGrid(gridId: "SalesItems-gridId", colId: "ordered", "1");

            webElementAction.ClickOnPostBtnInMinGrid();
            CheckErrorDialogBox();

            return orderNo;
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void Add_ConfirmAndValidatePOSInOrderList_Business()
        {
            TestInitialize(nameof(Add_ConfirmAndValidatePOSInOrderList_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string defaultPOSCustomer = default, orderNo = default;
                    //* Step 1: Selecting Default POS Customer (Production) *//
                    {
                        defaultPOSCustomer = SelectingDefaultPOSCustomer();
                    }

                    //* Step 2: Add POS *//
                    {
                        AddPosFromOrderProcessing(out orderNo);
                    }

                    /* Step 3: Confirm Pos*/
                    {
                        ConfirmPos();
                    }

                    /* Step 4: Vaidate inserted POS in OrderList*/
                    {
                        VaidateInsertedConfirmPosInOrderList(orderNum: orderNo);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void VaidateInsertedConfirmPosInOrderList(string orderNum)
        {
            Thread.Sleep(3000);
            GoToUrl("OrderProcessing", "OrderSummaryList", gotoLogin: false);

            if (webElementAction.IsElementPresent(By.CssSelector(".body-filter-button-container.down-area")) == false)
                webElementAction.GetElementBySpecificAttribute("data-button-type", "filter").Click();

            // click on all pos orders
            webElementAction.Click(By.XPath("//a[.='All POS Orders']"));

            Thread.Sleep(2000);
            // SearchTextInMainGrid(orderNum);

            var orderNumElement = ObjectRepository.Driver.FindElements(By.TagName("div"))
                .FirstOrDefault(o => o.Text == orderNum);

            // Determine if the order is present based on whether the orderElement is null  
            bool isOrderPresentInGrid = orderNumElement != null;

            if (!isOrderPresentInGrid)
                throw new Exception("POS Order Num does not exist in orderList.");
        }

        private void ConfirmPos()
        {
            GoToSubMenu("ACTION_TOOL_DROPDOWN", "CONFIRM_POS");
            var finalizeOrderForm =
                webElementAction.GetElementBySpecificAttribute("data-modal-title", "FINALIZE_THE_ORDER");
            new WebElementDataGenerator(finalizeOrderForm);
            ConfirmBtnCheck(dataSection: "modal");
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void AddAndRemovePos_Business()
        {
            TestInitialize(nameof(AddAndRemovePos_Business));

            while (!testPassed && retryCount < maxRetries)
                try
                {
                    string defaultPOSCustomer = default, orderNo = default;
                    //* Step 1: Selecting Default POS Customer *//
                    {
                        defaultPOSCustomer = SelectingDefaultPOSCustomer();
                    }

                    //* Step 2: Add POS *//
                    {
                        AddPosFromOrderProcessing(out orderNo);
                    }

                    string kitCode;
                    /* Step 3: Remove POS*/
                    {
                        RemovePOS();
                    }

                    /* Step 4: Vaidate removed POS*/
                    {
                        if (!webElementAction.IsDivPresentBySpecificText("Error: Order Not On File",
                                contextBy: By.CssSelector("[data-section='errorDialog']")))
                            throw new Exception("Error:___Remove POS action does not work correctlly");
                        testPassed = true;
                    }
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ImportAndExportInSalesOrder_Business()
        {
            TestInitialize(nameof(ImportAndExportInSalesOrder_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    var orderNumber = string.Empty;
                    var fileName = string.Empty;
                    int countGridSalesFirst = default;

                    /*Step 1: Add a new Order and get its orderNo */
                    {
                        Login();
                        orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }
                    /* Step 2: Click clear inputs and send order number and search */
                    {
                        SearchOrderInOrderProcessingScreen(orderNumber);
                    }
                    /* Step 3: Get row count from grid pinned footer first */
                    {
                        AddSalesOrdersRandomly();
                    }
                    /* Step 4: Click menu sales, add record with "Sales Item", then export the data  */
                    {
                        fileName = ExportSalesOrderData();
                    }
                    /* Step 6: Click import to upload the data  */
                    {
                        countGridSalesFirst = ImportSalesOrderData(fileName);
                    }
                    /* Step 7: Verify that the total count matches expected value */ //4647,838   9542
                    {
                        VerifyImportResults(countGridSalesFirst);
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

        private void AddSalesOrdersRandomly()
        {
            int randomNumber = int.Parse(RandomValueGenerator.GenerateRandomInt(2, 4));
            string error = "Error: The Stock# must have a value.";
            for (int i = 1; i <= randomNumber; i++)
            {
                AddSalesOrder();
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

        private string ExportSalesOrderData(bool clickCheckBox = false)
        {
            string fileName = string.Empty;

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

        private int ImportSalesOrderData(string fileName)
        {
            int countGridSalesFirst = GetRowCountFromGridPinnedFooter(gridId: "SalesItems-gridId");
            GoToSubMenu(menu: "ACTION_TOOL_DROPDOWN", subMenu: "IMPORT");
            webElementAction.Click(
                By.CssSelector("[data-icon-name='file']")); // click on open file and find file in .svc
            //upload file to Import modal 
            GenericHelper.SetFileInWindowUploader($"{fileName: fileName}.csv",
                filePath: Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Downloads"));
            ConfirmBtnCheck(dataSection: "modal"); //click load modal and find modal files

            var elementsNumberBoxTopRead = int.Parse(webElementAction
                .GetElementByCssSelector(".number-boxes-container > div:nth-of-type(1) > .number-box-top")
                .GetAttribute("innerText")); //get text read in modal

            var elementsNumberBoxBottomAdded = int.Parse(webElementAction
                .GetElementByCssSelector(".number-boxes-container > div:nth-of-type(3) > .number-box-top")
                .GetAttribute("innerText")); //get text added in modal

            ConfirmBtnCheck(dataSection: "modal");

            if (elementsNumberBoxTopRead != countGridSalesFirst &&
                elementsNumberBoxBottomAdded !=
                countGridSalesFirst) //check read and added in modal in first count sales
                Assert.Fail($"Error:___Does not match " + elementsNumberBoxTopRead + "," +
                            elementsNumberBoxBottomAdded + "with" + countGridSalesFirst + "");


            DeleteAllCSVs();

            return countGridSalesFirst;
        }

        private void VerifyImportResults(int countGridSalesFirst)
        {
            if (GetRowCountFromGridPinnedFooter(gridId: "SalesItems-gridId") != countGridSalesFirst * 2)
                Assert.Fail("Error:__Count in the pinned footer does not match the expected count.");
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateDisplayWithFilterStatusInSalesOrderScreenLeftSide_Business()
        {
            TestInitialize(nameof(ValidateDisplayWithFilterStatusInSalesOrderScreenLeftSide_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    /* Step 1: Navigate to the login and then to the Order Processing screen  */
                    {
                        GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    }
                    /* Step 2: Navigate to the Sales Order submenu  */
                    {
                        GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_ORDER");
                    }
                    /* Step 3: Click to toggle the splitter if it is disabled  */
                    {
                        OpenToggleSplitter();
                    }
                    /* Step 4: Select 'Description' and validate the selection  */
                    {
                        ValidateRadioButtonSelectionStatus("-Description");
                    }
                    /* Step 5: Select 'Code' and validate the selection  */
                    {
                        ValidateRadioButtonSelectionStatus("-Code");
                    }
                    /* Step 6: Select 'Both' and validate the selection  */
                    {
                        ValidateRadioButtonSelectionStatus("-Both");
                    }

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void OpenToggleSplitter()
        {
            // Check if the splitter is disabled and click to toggle it
            if (!webElementAction.IsElementPresent(By.CssSelector("SplitPane splitter vertical disabled")))
                webElementAction.Click(By.CssSelector(".toggle-handler"));
        }

        private void ValidateRadioButtonSelectionStatus(string radioButtonId)
        {
            // Select the specified radio button and validate that it is selected  
            webElementAction.Click(By.Id(radioButtonId));

            SignOut();
            Thread.Sleep(1000);
            try
            {
                Login();
                GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
            }
            catch
            {
                ConfirmBtnCheck(dataSection: "errorDialog");
                GoToUrl("OrderProcessing", "OrderProcessingScreen");
            }
            GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_ORDER");
            OpenToggleSplitter();

            var radioButton = webElementAction.GetElementById(radioButtonId);
            if (!radioButton.Selected)
                Assert.Fail($"{radioButtonId} is not selected");
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateEditTotalActualInSalesOrder_Business()
        {
            TestInitialize(nameof(ValidateEditTotalActualInSalesOrder_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    var orderNumber = string.Empty;
                    string totalPriceOld = default;
                    string totalPrice = default;

                    /* Step 1: Add a new Order and get its orderNo */
                    {
                        Login();
                        orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation();
                    }
                    /* Step 2: Search Order In Order Processing Screen */
                    {
                        SearchOrderInOrderProcessingScreen(orderNumber);
                    }
                    /* Step 3: Get row count from grid pinned footer first */
                    {
                        AddSalesOrdersRandomly();
                    }
                    /* Step 4: Get updated total price from the grid */
                    {
                        totalPriceOld = GetSalesOrderTotalPrice();
                    }
                    /* Step 5: Click the icon to refresh grid if not disabled */
                    {
                        if (!webElementAction.IsElementPresent(By.CssSelector("Resizer vertical disabled")))
                            webElementAction.Click(By.CssSelector(".icon-sum"));
                    }
                    /* Step 6: Update the sales discount percentage and submit the changes */
                    {
                        UpdateSalesDiscount();
                    }
                    /* Step 7: If the modal to edit actual sales shows up, input the new value */
                    {
                        EditTotalActualSales();
                    }
                    /* Step 8: Get updated total price from the grid */
                    {
                        totalPrice = GetSalesOrderTotalPrice();
                    }
                    /* Step 9: Validate the updated total price */
                    {
                        ValidateTotalPrice(totalPrice, totalPriceOld);
                    }

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private string GetSalesOrderTotalPrice()
        {
            // Get the current total price from the grid's pinned footer.  
            return webElementAction
                .GetAllElementsByCssSelector("[col-id='extended'] > .pinned-footer").First().Text;
        }

        private void UpdateSalesDiscount()
        {
            // Update the sales discount percentage and click submit buttons 
            new WebElementDataGenerator(
                webElementAction.GetElementBySpecificAttribute("data-form-item-name",
                    "shipMethodId")); //generate "Ship Method" input

            webElementAction.GetInputElementByDataFormItemNameInDiv("salesDiscPct")
                .SendKeys("0"); //send 0 in input "Discount%"

            webElementAction.Click(
                By.CssSelector(".enormous-left-section .col-01 > .mainButton")); // click "Recalculate"

            webElementAction.Click(
                By.CssSelector(".button-with-outside-icon > .mainButton")); //click "Edit Total Actual" and generate
        }

        private void EditTotalActualSales()
        {
            // If the modal for editing total actual sales is present, input the new value and confirm  
            if (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='EDIT_TOTAL_ACTUAL_SALES']")))
            {
                var elementMainModalInput = webElementAction
                    .GetElementByCssSelector(".main-modal-content .main-input-tooltip")
                    .FindElement(By.TagName("input"));
                elementMainModalInput.Click();
                elementMainModalInput.SendKeys(Keys.Backspace);
                elementMainModalInput.SendKeys("10.0");
                ConfirmBtnCheck(dataSection: "modal");
            }

            if (webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='userId']")))
            {
                new WebElementDataGenerator(
                    webElementAction.GetElementBySpecificAttribute("data-form-item-name", "userId"));
                ConfirmBtnCheck(dataSection: "modal");
            }
        }

        private void ValidateTotalPrice(string totalPrice, string totalPriceOld)
        {
            if (totalPrice != totalPriceOld)
                Assert.Fail("The total price did not change as expected.");
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
    }
}