using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.OrderProcessing.Order
{
    namespace RTProSL_MSTest.TestClasses.OrderProcessing.Order.OrderListPlus
    {
        //developed by kambiz Abdali

        public class GeneralTab
        {
            public string Language { get; set; }

            public string Currency { get; set; }

            [ValidationElementName("Ship Method")]
            [ValidationIgnoreInGrid]
            public string ShipMethodId { get; set; }
            [ValidationElementName("Return Method")]
            public string ReturnMethod { get; set; }

            [ValidationElementName("job Type")]
            [ValidationColID("productionType")]
            [ValidationElementProperty("productionTypeId")]
            public string JobType { get; set; }

            public string CheckinPriority { get; set; }

            [ValidationColID("jobComponent")]
            [ValidationElementProperty("jobComponentId")]
            public string JobComponent { get; set; }

            [ValidationElementProperty("projectId")]
            public string Project { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("partnerId")]
            public string Partner { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("partnerStructureId")]
            public string PartnerStructure { get; set; }

            [ValidationColID("manualStatus")]
            [ValidationElementProperty("manualStatusId")]
            public string ManualStatus { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("excludeFromProductionBS")]
            [ValidationElementName("Exclude from Job Billing Schedule")]
            [ValidationDataType(DataType.CheckBox)]
            public bool ExcludeFromProductionBS { get; set; }

            public string ContractDate { get; set; }
            public string CheckinDate { get; set; }
            public string StagingCount { get; set; }

            [ValidationIgnoreInGrid]
            public string OrderTimelineWidgetNotes { get; set; }

            public string WebOrderNo { get; set; }
            [ValidationElementProperty("managingDepartmentId")]
            public string ManagingDepartment { get; set; }

            [ValidationColID("chargeType")]
            [ValidationElementProperty("chargeTypeId")]
            public string ChargeType { get; set; }

            [ValidationElementProperty("customField1Id")]
            public string CustomField1 { get; set; }

            [ValidationElementProperty("customField2Id")]
            public string CustomField2 { get; set; }

            [ValidationElementProperty("customField3Id")]
            public string CustomField3 { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("Internal Order Notes")]
            [ValidationDataType(DataType.TextArea)]
            public string InternalNotes { get; set; }
        }

        public class DatesTab
        {
            public string QuoteDate { get; set; }

            [ValidationColID("pullDate")]
            [ValidationElementName("Pull Date")]
            public string PullDateOnly { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("PullTime")]
            public string PullTimeOnly { get; set; }

            [ValidationColID("shippingDate")]
            public string ShipDate { get; set; }

            [ValidationIgnoreInGrid]
            public string ShipTime { get; set; }

            [ValidationElementName("Return Date")]
            public string ReturnDate { get; set; }

            [ValidationColID("address3")]
            [ValidationElementName("City in Address")]
            public string AddressLine3 { get; set; }

            [ValidationElementName("Country in Address")]
            public string AddressLine4 { get; set; }

            [ValidationElementName("Shipping Name in shipping")]
            public string ShippingName { get; set; }

            [ValidationElementName("Shipping Name in shipping")]
            public string Phone { get; set; }

            [ValidationElementName("Shipping Name in shipping")]
            public string Fax { get; set; }

            [ValidationElementName("Address1 in shipping")]
            public string ShippingAddressLine1 { get; set; }

            [ValidationElementName("Address2 in shipping")]
            public string ShippingAddressLine2 { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("Address3 in shipping")]
            public string ShippingAddressLine2B { get; set; }

            [ValidationColID("shippingAddress4")]
            [ValidationElementName("city in shipping")]
            public string ShippingAddressLine3 { get; set; }
        }

        public class AddressTab
        {
            /*-----------------------Billing section---------------------------*/
            public string Name { get; set; }
            [ValidationColID("address1")]
            public string AddressLine1 { get; set; }
            [ValidationIgnoreInGrid]
            public string AddressLine2 { get; set; }
            [ValidationIgnoreInGrid]
            public string AddressLine2B { get; set; }

            [ValidationElementName("State in Billing Address")]
            public string State { get; set; }

            [ValidationElementName("ZipCode in Billing Address")]
            public string ZipCode { get; set; }

            [ValidationColID("address3")]
            [ValidationElementName("City in Billing Address")]
            public string AddressLine3 { get; set; }

            [ValidationElementName("Country in Billing Address")]
            public string AddressLine4 { get; set; }

            [ValidationElementName("Contact Info in Billing Address")]
            public string BillingContactNotes { get; set; }

            /*-----------------------Shipping section---------------------------*/

            [ValidationElementName("Shipping Name in shipping")]
            public string ShippingName { get; set; }

            [ValidationElementProperty("shippingAddressLine1")]
            public string ShippingAddressLine1 { get; set; }

            public string ShippingAddressLine2 { get; set; }

            public string ShippingAddressLine2B { get; set; }

            [ValidationElementName("shippingAddressLine3 (city)")]
            public string ShippingAddressLine3 { get; set; }

            [ValidationIgnoreInGrid]
            public string ShipState { get; set; }

            [ValidationIgnoreInGrid]
            public string ShipZipCode { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("Ship Country")]
            public string ShippingAddressLine4 { get; set; }

            public string ShippingContact { get; set; }

            [ValidationIgnoreInGrid]
            public string ShippingContactEmail { get; set; }


            [ValidationIgnoreInGrid]
            public string ShippingContactPhone { get; set; }

            [ValidationColID("contactCell")]
            public string ShippingContactCell { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationDataType(DataType.CheckBox)]
            public bool PrintCustomerNotes { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationDataType(DataType.TextArea)]
            [ValidationElementName("JobOrderNotes")]
            public string Notes { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationDataType(DataType.TextArea)]
            [ValidationElementName("Delivery/Return Notes")]
            public string DeliveryNotes { get; set; }

            /*-----------------------Return section---------------------------*/
            [ValidationIgnoreInGrid]
            public string ReturnName { get; set; }
            [ValidationIgnoreInGrid]
            public string ReturnAddressLine1 { get; set; }
            [ValidationIgnoreInGrid]
            public string ReturnAddressLine2 { get; set; }
            [ValidationIgnoreInGrid]
            public string returnAddressLine2B { get; set; }
            [ValidationIgnoreInGrid]
            [ValidationElementName("City in return section")]
            public string returnAddressLine3 { get; set; }
            [ValidationIgnoreInGrid]
            public string ReturnState { get; set; }
            [ValidationIgnoreInGrid]
            public string ReturnZipCode { get; set; }
            [ValidationIgnoreInGrid]
            [ValidationElementName("Country in return section")]
            public string ReturnAddressLine4 { get; set; }
            [ValidationIgnoreInGrid]
            public string ReturnContact { get; set; }
            [ValidationIgnoreInGrid]
            public string ReturnContactPhone { get; set; }
            [ValidationIgnoreInGrid]
            public string ReturnContactCell { get; set; }
            [ValidationIgnoreInGrid]
            public string ReturnContactEmail { get; set; }
        }

        public class BillingTab
        {
            [ValidationElementProperty("PaymentTypeId")]
            public string PaymentType { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationDataType(DataType.DropDown)]
            public string BillingType { get; set; }

            [ValidationColID("taxType")]
            [ValidationElementProperty("taxTypeId")]
            public string TaxType { get; set; }

            [ValidationColID("terms")]
            [ValidationElementProperty("termsId")]
            public string Terms { get; set; }

            [ValidationColID("salesperson")]
            [ValidationElementProperty("salespersonId")]
            public string Salesperson { get; set; }

            public string DaysPerWeek { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationDataType(DataType.DropDown)]
            public string DailyWeekly { get; set; }

            public bool InsuranceFeePct { get; set; }
        }

        public class PoTab
        {
            [ValidationElementName("PO Number")]
            public string Po { get; set; }

            public string PoDate { get; set; }

            public string Status { get; set; }

            [ValidationDataType(DataType.CheckBox)]
            public bool Flat { get; set; }

            public string Amount { get; set; }
            [ValidationIgnoreInGrid]
            public string CreateDate { get; set; }
            [ValidationIgnoreInGrid]
            public string CreateBy { get; set; }

            [ValidationElementName("Notes")]
            public string Description { get; set; }

            public string ChargeType { get; set; }
        }

        public class ContactTab
        {
            [ValidationColID("id")]
            [ValidationElementName("Contact")]
            public string Id { get; set; }

            [ValidationColID("name")] public string Name { get; set; }

            [ValidationColID("phone")]
            public string Phone { get; set; }

            [ValidationElementName("Contact Title")]
            public string Title { get; set; }

            public string Email { get; set; }
            [ValidationIgnoreInGrid]
            public string CellPhone { get; set; }

            public bool EmailInclude { get; set; }
        }


        public class OrderInOrderListPlusEntity
        {
            public OrderInOrderListPlusEntity()
            {
                GeneralTab = new GeneralTab();
                AddressTab = new AddressTab();
                BillingTab = new BillingTab();
                ContactTab = new ContactTab();
                DatesTab = new DatesTab();
                PoTab = new PoTab();
            }

            public string ProductionId { get; set; }

            [ValidationDataType(DataType.DropDown)]
            public string OrderType { get; set; }

            [ValidationElementProperty("locationId")]
            public string Location { get; set; }

            [ValidationColID("locationReturnTo")]
            [ValidationElementProperty("locationReturnToId")]
            public string LocationReturnTo { get; set; }

            [ValidationElementProperty("transferToId")]
            [ValidationColID("transferTo")]
            public string TransferTo { get; set; }

            public string JobTitle { get; set; }

            [ValidationElementProperty("rentalAgent1")]
            public string RentalAgent1 { get; set; }
            [ValidationElementProperty("rentalAgent2")]
            public string RentalAgent2 { get; set; }

            [ValidationDataType(DataType.CheckBox)]
            public bool BillableQuote { get; set; }

            //read from right side page
            [ValidationIgnoreInGrid]
            [ValidationIgnore(true, BaseClass.IgnoreType.Validation)]
            public string OrderNo { get; set; }

            [ValidationTabClick("GENERAL")] public GeneralTab GeneralTab { get; set; }
            [ValidationTabClick("DATES")] public DatesTab DatesTab { get; set; }

            [ValidationTabClick("ADDRESS")] public AddressTab AddressTab { get; set; }
            [ValidationTabClick("BILLING")] public BillingTab BillingTab { get; set; }

            [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
            public PoTab PoTab { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
            public ContactTab ContactTab { get; set; }
        }

        [TestCategory("OrderProcessing")]
        [TestClass, TestCategory("OrderProcessing___Order")]
        public class OrderListPlus : BaseClass
        {
            private OrderInOrderListPlusEntity _Order;

            private void GeneralTabClick()
            {
                var generalBtn = webElementAction
                    .GetAllElementBySpecificAttribute("type", "button")
                    .FirstOrDefault(o => o.GetAttribute("data-tab-name") == "GENERAL");
                generalBtn.Click();
            }

            private void AddressTabClick()
            {
                var addressBtn = webElementAction
                    .GetAllElementBySpecificAttribute("type", "button")
                    .FirstOrDefault(o => o.GetAttribute("data-tab-name") == "ADDRESS");
                addressBtn.Click();
            }

            private void PricingTabClick()
            {
                var pricingBtn = webElementAction
                    .GetAllElementBySpecificAttribute("type", "button")
                    .FirstOrDefault(o => o.GetAttribute("data-tab-name") == "PRICING");
                pricingBtn.Click();
            }

            private void ContacsTabClick()
            {
                var contacsBtn = webElementAction
                    .GetAllElementBySpecificAttribute("type", "button")
                    .FirstOrDefault(o => o.GetAttribute("data-tab-name") == "CONTACT");
                contacsBtn.Click();
            }

            private void PoTabClick()
            {
                var PoBtn = webElementAction
                    .GetAllElementBySpecificAttribute("type", "button")
                    .FirstOrDefault(o => o.GetAttribute("data-tab-name") == "PO");
                PoBtn.Click();
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ArrowNextBtnCheckInOrderListPlus()
            {
                TestInitialize(nameof(ArrowNextBtnCheckInOrderListPlus));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");
                        RefreshAllRows();
                        ShowAllRedord();
                        if (!HasRowCheck()) { testPassed = true; break; }
                        ArrowPreviousBtn();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ArrowPreviousBtnCheckInOrderListPlus()
            {
                TestInitialize(nameof(ArrowPreviousBtnCheckInOrderListPlus));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");
                        RefreshAllRows();
                        ShowAllRedord();
                        if (!HasRowCheck()) { testPassed = true; break; }
                        ArrowPreviousBtn();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ArrowLastBtnCheckInOrderListPlus()
            {
                TestInitialize(nameof(ArrowLastBtnCheckInOrderListPlus));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");
                        RefreshAllRows();
                        ShowAllRedord();
                        if (!HasRowCheck()) { testPassed = true; break; }
                        ArrowLastBtn();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ArrowFirstBtnCheckInOrderListPlus()
            {
                TestInitialize(nameof(ArrowFirstBtnCheckInOrderListPlus));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");
                        RefreshAllRows();
                        ShowAllRedord();
                        if (!HasRowCheck()) { testPassed = true; break; }
                        ArrowFirstBtn();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            private void AddOrderInOrderListPlusFunc(bool addContactTypeIsGrid = false)
            {
                GoToUrl("OrderProcessing", "OrderList");
                RefreshAllRows();
                //click on addNewRecordBtn
                Thread.Sleep(2000);
                webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();
                ConfirmBtnCheck();
                Thread.Sleep(1000);

                GenerateProductionAndParentinDialogBox();

                var mainContext = GetFormLeftSideContext(true);
                Thread.Sleep(3000);
                WaitForLoadingSpiner();

                GenerateDataInMainFormContext();
                _Order.OrderNo = webElementAction.GetInputElementByDataFormItemNameInDiv("searchOrderNo").GetAttribute("value");
                while (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='CANCEL_REASON']"))
                      || webElementAction.IsElementPresent(By.CssSelector("[data-section='confirmDialog']")))
                {
                    webElementAction.GetElementBySpecificAttribute("data-button-type", "cancel").Click();
                }

                //**************************generate data to PO tab*************************************
                ClickTab("PO");
                var poContext = GetTabContext("PO");

                webElementAction.GetElementBySpecificAttribute("data-icon-name", "add", poContext).Click();
                var addPOModal =
                    webElementAction.GetElementBySpecificAttribute("data-modal-title", "ADD_PO");

                new WebElementDataGenerator(addPOModal);

                //click on confirm btn 
                webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", addPOModal).Click();

                var poColIds = webElementAction.GetElementById("orderHeaderPO-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
                CreateAddInGrid(_Order.PoTab, poColIds);

                //**************************generate data to CONTACTS tab*************************************
                ContacsTabClick();

                var contactContext = GetTabContext("CONTACT");

                //delete all contacts
                DeleteAllRowsInMinGrid(contactContext, dataHeaderName: "OrderHeaderContactList-MiniGrid");

                if (addContactTypeIsGrid)  //add Contact Type Is grid
                {
                    //add contact btn
                    webElementAction.GetElementBySpecificAttribute("id", "MINI_GRID_ADD_BUTTON", contactContext).Click();

                    Thread.Sleep(2000);
                    var newRowColsContext = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row");
                    new WebElementDataGenerator(newRowColsContext, true);

                    //fill all checkboxes in row
                    var checkboxElements = newRowColsContext.FindElements(By.TagName("input")).Where(element => element.GetAttribute("type") == "checkbox").ToList();
                    new WebElementDataGenerator().CheckboxGenerator(checkboxElements);
                    webElementAction.ClickOnPostBtnInMinGrid(gridId: "OrderHeaderContactList-MiniGrid");
                }
                else //add Contact Type Is form
                {
                    webElementAction.GetElementById("MINI_GRID_ADD_MULTI_SELECTION_BUTTON").Click();

                    var addcontactModal =
                        webElementAction.GetElementBySpecificAttribute("data-modal-title", "CONTACT");

                    var defaultSelectedRowinContact = webElementAction.GetElementByCssSelector(
                   ".ag-cell.ag-cell-not-inline-editing.ag-cell-normal-height.ag-cell-last-left-pinned.grid-icon-class.ag-cell-focus.ag-cell-value", addcontactModal);
                    defaultSelectedRowinContact.Click();

                    //click on confirm btn 
                    webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", addcontactModal).Click();
                }
                WaitForLoadingSpiner();
                Thread.Sleep(3000);
                var contactColIds = webElementAction.GetElementById("OrderHeaderContactList-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
                CreateAddInGrid(_Order.ContactTab, contactColIds, true);

                CreateAdd(_Order);

                SaveAndConfirmCheck();

                ConfirmBtnCheck(dataSection: "alertDialog");
                if (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='ENTER_REASON']")))
                {
                    var modalReasonContext = webElementAction.GetElementBySpecificAttribute("data-modal-title", "ENTER_REASON");
                    webElementAction.GetElementBySpecificAttribute("data-icon-name", "report-scheduler", modalReasonContext).Click();
                    webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", modalReasonContext).Click();
                }
            }
            private void GenerateDataInMainFormContext()
            {
                new WebElementDataGenerator().DropDownListGeneratorWithFilter(dataFormaItemName: "orderType", filter: "Order");

                var context = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "jobTitle");
                new WebElementDataGenerator(context);

                context = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "rentalAgent1Id");
                new WebElementDataGenerator(context);

                context = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "rentalAgent2Id");
                new WebElementDataGenerator(context);
            }

            [TestMethod]
            public void DetailValidateOrderInOrderListPlus()
            {
                TestInitialize(nameof(DetailValidateOrderInOrderListPlus));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        AddOrderInOrderListPlusFunc();
                        _Order.GeneralTab.CheckinPriority = webElementAction.FormatNumberWithCommas(_Order.GeneralTab.CheckinPriority);

                        Thread.Sleep(500);
                        OpenFilterWindow();
                        Thread.Sleep(500);
                        webElementAction.GetElementByCssSelector("[data-icon-name='eraser']").Click();
                        Thread.Sleep(500);

                        webElementAction.SelectingCheckbox("transfer");
                        webElementAction.GetElementBySpecificAttribute("id", "body-filter-refresh-btn").Click();
                        ShowAllRedord();

                        Thread.Sleep(500);

                        SearchTextInMainGrid(_Order.GeneralTab.InternalNotes.Substring(0, 30));
                        WaitForLoadingSpiner();
                        Thread.Sleep(1000);

                        FindColumnInMainGrid("Tax Type");
                        Thread.Sleep(1000);
                        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _Order.BillingTab.TaxType);

                        selectRow.Click();

                        ChangeScreenPageSize(22);
                        Thread.Sleep(4000);
                        var gridList = webElementAction.GetElementById("OrderList-gridId");
                        ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                        CreateValidationInGrid(colIds, _Order);
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime + (MaximumExecutionTime / 2))]
            public void AddOrderInOrderListPlus()
            {
                TestInitialize(nameof(AddOrderInOrderListPlus));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        AddOrderInOrderListPlusFunc();
                        Thread.Sleep(4000);
                        if (webElementAction.IsElementPresent(By.CssSelector(".body-filter-button-container.down-area")) == false)
                            webElementAction.GetElementBySpecificAttribute("data-button-type", "filter").Click(); Thread.Sleep(500);
                        webElementAction.GetElementByCssSelector("[data-icon-name='eraser']").Click();
                        Thread.Sleep(500);

                        webElementAction.GetInputElementByDataFormItemNameInDiv("transfer").Click();

                        webElementAction.GetElementBySpecificAttribute("id", "body-filter-refresh-btn").Click();
                        WaitForLoadingSpiner();
                        ShowAllRedord();
                        Thread.Sleep(500);

                        SearchTextInMainGrid(_Order.GeneralTab.InternalNotes.Substring(0, 30));

                        WaitForLoadingSpiner();
                        Thread.Sleep(1000);

                        var gridList = webElementAction.GetElementById("OrderList-gridId");

                        var OrderNoDiv = gridList.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == _Order.OrderNo).FindElement(By.TagName("a"));
                        OrderNoDiv.Click();

                        ValidateInsertedOrderInGridList();

                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            private void ValidateInsertedOrderInGridList()
            {
                //click on edit btn
                webElementAction.GetElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID").Click();


                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide")
                    .FindElements(By.TagName("div")).FirstOrDefault(); ;
                CreateValidation(_Order, context);

                //**************************validation Po Tab*************************************
                PoTabClick();
                var poGrid = webElementAction.GetElementById("orderHeaderPO-MiniGrid-gridId");//.FindElements(By.CssSelector(".ag-row.ag-row-focus"));//
                PoTab currentPoTab;
                ReadOnlyCollection<IWebElement> colIds = poGrid.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                currentPoTab = new PoTab();
                CreateAddInGrid(currentPoTab, colIds);
                ValidateEntityFieldDifferences(_Order.PoTab, currentPoTab);

                //**************************validation to CONTACTS tab*************************************
                ContacsTabClick();
                ContactTab currentContactTab;
                var contactGrid = webElementAction.GetElementById("OrderHeaderContactList-MiniGrid-gridId");//.FindElements(By.CssSelector(".ag-row.ag-row-focus"));//
                currentContactTab = new ContactTab();
                colIds = contactGrid.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                CreateAddInGrid(currentContactTab, colIds, true);
                ValidateEntityFieldDifferences(_Order.ContactTab, currentContactTab);
            }


            [TestMethod, Timeout(MaximumExecutionTime + (MaximumExecutionTime / 2))]
            public void AddOrderInOrderListPlusWithGridContact()
            {
                TestInitialize(nameof(AddOrderInOrderListPlusWithGridContact));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        AddOrderInOrderListPlusFunc(addContactTypeIsGrid: true);
                        Thread.Sleep(500);
                        ConfirmBtnCheck(dataSection: "alertDialog");
                        if (webElementAction.IsElementPresent(By.CssSelector(".body-filter-button-container.down-area")) == false)
                            webElementAction.GetElementBySpecificAttribute("data-button-type", "filter").Click();
                        WaitForLoadingSpiner();
                        Thread.Sleep(500);
                        webElementAction.GetElementByCssSelector("[data-icon-name='eraser']").Click();
                        Thread.Sleep(500);

                        webElementAction.GetInputElementByDataFormItemNameInDiv("transfer").Click();

                        webElementAction.GetElementBySpecificAttribute("id", "body-filter-refresh-btn").Click();
                        ShowAllRedord();

                        Thread.Sleep(500);
                        SearchTextInMainGrid(_Order.GeneralTab.InternalNotes.Substring(0, 30));
                        WaitForLoadingSpiner();
                        Thread.Sleep(1000);

                        var gridList = webElementAction.GetElementById("OrderList-gridId");

                        var OrderNoDiv = gridList.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == _Order.OrderNo).FindElement(By.TagName("a"));
                        OrderNoDiv.Click();

                        ValidateInsertedOrderInGridList();

                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }


            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByProduction()
            {
                TestInitialize(nameof(FilterOrderPlusByProduction));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        //Select all value in grid
                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("productionId", "OrderList-gridId", "Production");
                        filterSearch.FilterSearchInTextDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByInputOrder()
            {
                TestInitialize(nameof(FilterOrderPlusByInputOrder));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        //Select all value in grid
                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("orderNo", "OrderList-gridId", "Order#");
                        filterSearch.FilterSearchInTextDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByRentalAgent()
            {
                TestInitialize(nameof(FilterOrderPlusByRentalAgent));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        //Select all value in grid
                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("rentalAgentList", "OrderList-gridId", "Rental Agent 1", colId: "rentalAgent1");
                        filterSearch.FilterSearchInTextDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusBySalesPerson()
            {
                TestInitialize(nameof(FilterOrderPlusBySalesPerson));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        //Select all value in grid
                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("salespersonList", "OrderList-gridId", "Salesperson", colId: "salesperson");
                        filterSearch.FilterSearchInTextDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByClosed()
            {
                TestInitialize(nameof(FilterOrderPlusByClosed));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        //Select all value in grid
                        RefreshAllRows();
                        DataLegendNameFilter("CLOSED");
                        FilterSearch filterSearch = new FilterSearch("closed", "OrderList-gridId", "Order Status", colId: "orderStatus", replacementValue: "Closed");
                        filterSearch.FilterSearchInCheckBoxDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByQuote()
            {
                TestInitialize(nameof(FilterOrderPlusByQuote));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        //Select all value in grid
                        RefreshAllRows();
                        DataLegendNameFilter("QUOTE");
                        FilterSearch filterSearch = new FilterSearch("quote", "OrderList-gridId", "Order Type", colId: "orderType", replacementValue: "Quote");
                        filterSearch.FilterSearchInCheckBoxDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByReservation()
            {
                TestInitialize(nameof(FilterOrderPlusByReservation));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        //Select all value in grid
                        RefreshAllRows();
                        DataLegendNameFilter("RESERVATION");
                        FilterSearch filterSearch = new FilterSearch("reservation", "OrderList-gridId", "Order Type", colId: "orderType", replacementValue: "Reservation");
                        filterSearch.FilterSearchInCheckBoxDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByCheckOrder()
            {
                TestInitialize(nameof(FilterOrderPlusByCheckOrder));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        //Select all value in grid
                        RefreshAllRows();
                        DataLegendNameFilter("ORDER");
                        FilterSearch filterSearch = new FilterSearch("order", "OrderList-gridId", "Order Type", colId: "orderType", replacementValue: "Order");
                        filterSearch.FilterSearchInCheckBoxDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByCancelled()
            {
                TestInitialize(nameof(FilterOrderPlusByCancelled));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        //Select all value in grid
                        RefreshAllRows();
                        DataLegendNameFilter("CANCELLED");
                        FilterSearch filterSearch = new FilterSearch("cancelled", "OrderList-gridId", "Order Type", colId: "orderType", replacementValue: "Cancelled");
                        filterSearch.FilterSearchInCheckBoxDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByPrecount()
            {
                TestInitialize(nameof(FilterOrderPlusByPrecount));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        //Select all value in grid
                        RefreshAllRows();
                        DataLegendNameFilter("PRECOUNT");
                        FilterSearch filterSearch = new FilterSearch("precount", "OrderList-gridId", "Order Type", colId: "orderType", replacementValue: "Precount");
                        filterSearch.FilterSearchInCheckBoxDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByShipDateRange()
            {
                TestInitialize(nameof(FilterOrderPlusByShipDateRange));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("ShippingDate1", "OrderList-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("shippingDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByPullDateRange()
            {
                TestInitialize(nameof(FilterOrderPlusByPullDateRange));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("pullDate1", "OrderList-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("pullDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByReturnDateRange()
            {
                TestInitialize(nameof(FilterOrderPlusByReturnDateRange));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("returnDate1", "OrderList-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("returnDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByCheckoutCheckinDateRange()
            {
                TestInitialize(nameof(FilterOrderPlusByCheckoutCheckinDateRange));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("checkinOutDate1", "OrderList-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("usageBeginDate", "usageEndDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByRangePickerTitle()
            {
                TestInitialize(nameof(FilterOrderPlusByRangePickerTitle));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("createDate1", "OrderList-gridId", "Creation Date");
                        filterSearch.FilterSearchInDateTimeDataType("createDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void PostContactErrorMessageInOrderListPlus()
            {
                TestInitialize(nameof(PostContactErrorMessageInOrderListPlus));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        //click on addNewRecordBtn
                        webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();

                        GenerateProductionAndParentinDialogBox();

                        ClickTab("CONTACT");
                        var contactContext = GetTabContext("CONTACT");

                        //add contact btn
                        webElementAction.GetElementBySpecificAttribute("id", "MINI_GRID_ADD_BUTTON", contactContext).Click();

                        Thread.Sleep(2000);
                        var newRowColsContext = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row");
                        new WebElementDataGenerator(newRowColsContext, true);

                        NavigateToHomePage();

                        ValidateMessageBoxForPostContact();

                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            private void ValidateMessageBoxForPostContact()
            {
                string textMessage = "The Contact has not been posted";

                var errorMessageDialogBox = webElementAction.GetAllElementsByTagName("div")
                     .FirstOrDefault(element => element.GetAttribute("innerText").Contains(textMessage));

                if (errorMessageDialogBox == null)
                    throw new Exception("Error: Message box 'The Contact has not been posted' didnot display");
            }

            private void GenerateProductionAndParentinDialogBox()
            {
                var modalContext = webElementAction.GetElementBySpecificAttribute("data-modal-title", "ADD_A_NEW_ORDER");
                int tryToSelectParent = 0;
                string productionValue = string.Empty;
                _Order = new OrderInOrderListPlusEntity();

                new WebElementDataGenerator(modalContext);

                productionValue = webElementAction.GetInputElementByDataFormItemNameInDiv("productionId").GetAttribute("value");

                if (string.IsNullOrEmpty(productionValue))
                {
                    var parentElement = webElementAction.GetInputElementByDataFormItemNameInDiv("parentId");//.Clear();
                    webElementAction.DoubleClick(parentElement);
                    parentElement.SendKeys(Keys.Backspace);
                    webElementAction.GenerateDataToDataFormItemNameContext("productionId");
                    productionValue = webElementAction.GetInputElementByDataFormItemNameInDiv("productionId").GetAttribute("value");
                    _Order.ProductionId = productionValue;
                }
                else
                {
                    _Order.ProductionId = productionValue;
                }

                webElementAction.GetElementByCssSelector(".confirm-button").Click();
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ValidateRequiredFieldsMessageBoxInOrderList()
            {
                TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInOrderList));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        ValidateRequiredFieldsMessage validateRequiredFields;
                        validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "OrderProcessing", subMenu: "OrderList", filed: "rentalAgent2Id", steps: 2);
                        validateRequiredFields.Run();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByDeliveryDateAndTimeRange()
            {
                TestInitialize(nameof(FilterOrderPlusByDeliveryDateAndTimeRange));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("deliveryDate1", "OrderList-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("createDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderPlusByPickupDateAndTimeRange()
            {
                TestInitialize(nameof(FilterOrderPlusByPickupDateAndTimeRange));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");
                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("pickupDate1", "OrderList-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("createDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void AddPOToSelectedOrders_Business() // task #:43 file :New Features 07-07-2024  
            {
                TestInitialize(nameof(AddPOToSelectedOrders_Business));
                while (!testPassed && retryCount < maxRetries)
                {
                    try
                    {
                        //step 1: Extract First Two Rows Of Orders In ARandom Job
                        var firstTwoOrders = ExtractFirstTwoRowsOfOrdersInARandomJob();
                        //step 2: Add PO To Order
                        string addedPONumber = AddPOToOrder(firstTwoOrders.First());

                        webElementAction.Click(By.CssSelector(".icon-refresh"));
                        //step 3: Add PO To Second Order
                        firstTwoOrders = RetrieveVisibleColumnIdsInMainGrid("orderNo", pageRefresh: false).Take(2);
                        AddPOToSecondOrder(firstTwoOrders.Last(), addedPONumber);
                        //step 4: Validate Added PO Number InOrder
                        firstTwoOrders = RetrieveVisibleColumnIdsInMainGrid("orderNo", pageRefresh: false).Take(2);
                        ValidateAddedPONumberInOrder(firstTwoOrders.Last(), addedPONumber);
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
                }
            }

            private IEnumerable<IWebElement> ExtractFirstTwoRowsOfOrdersInARandomJob()
            {
                GoToUrl("OrderProcessing", "OrderList");
                RefreshAllRows(filterId: "productionId");
                return RetrieveVisibleColumnIdsInMainGrid("orderNo", pageRefresh: false).Take(2);
            }

            private string AddPOToOrder(IWebElement order)
            {
                order.FindElement(By.TagName("a")).Click(); //<a href="/order-header?detailId=315463&amp;detailMode=full-screen" target="_self_detail" class="main-link hyper-link-style">315463</a>
                WaitForLoadingSpiner();
                ClickTab("PO");

                var poContext = GetTabContext("PO");
                ClickOnEditBtn();

                //click on add po
                webElementAction.Click(By.CssSelector(".info-area-order-header .icon-add"));

                var addPOModal = webElementAction.GetElementBySpecificAttribute("data-modal-title", "ADD_PO");
                new WebElementDataGenerator(addPOModal);

                var flatCheckbox = webElementAction.GetElementByCssSelector(".main-modal-content div:nth-of-type(7) .checkbox-animation");
                flatCheckbox.Click();

                webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", addPOModal).Click();

                var poColIds = webElementAction.GetElementById("orderHeaderPO-MiniGrid-gridId")
                    .FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));



                ClickTab("DATES");
                webElementAction.GenerateDataToRequiredFields(idIcons: ".required-star", context: GetTabContext("DATES"));

                ClickTab("GENERAL");
                webElementAction.GenerateDataToRequiredFields(idIcons: ".required-star", context: GetTabContext("GENERAL"));

                ClickTab("BILLING");
                webElementAction.GenerateDataToRequiredFields(idIcons: ".required-star", context: GetTabContext("BILLING"));

                webElementAction.GenerateDataToRequiredFields(idIcons: ".required-star", context: GetFormLeftSideContext(isNested: true));


                OrderInOrderListPlusEntity _OrderEntity = new OrderInOrderListPlusEntity();
                CreateAddInGrid(_OrderEntity.PoTab, poColIds);
                SaveAndConfirmCheck();

                return _OrderEntity.PoTab.Po;
            }

            private void AddPOToSecondOrder(IWebElement secondOrder, string addedPONumber)
            {
                webElementAction.RighClick(secondOrder);
                webElementAction.Click(By.XPath("//span[.='Add PO to Selected Orders']"));

                var modalContext = webElementAction.GetElementBySpecificAttribute("data-modal-title", "ADD_PO");
                var newPOContext = modalContext.FindElements(By.CssSelector(".combo-auto-complete"));
                new WebElementDataGenerator().ComboAutoCompleteGenerator(newPOContext, addedPONumber);

                ConfirmBtnCheck(dataSection: "modal");
            }

            private void ValidateAddedPONumberInOrder(IWebElement order, string addedPONumber)
            {
                order.FindElement(By.TagName("a")).Click(); //<a href="/order-header?
                ClickTab("PO");

                bool isPoPresent = IsValuePresentInGrid(gridId: "orderHeaderPO-MiniGrid-gridId", targetValue: addedPONumber);
                if (!isPoPresent)
                {
                    throw new Exception($"The added PO# {addedPONumber} from Order #1 is not displayed in Order #2.");
                }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ValidateRefreshRecordDataInGrid()
            {
                TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderList");
                        RefreshRecordDataInGrid("OrderList-gridId", columnId: "orderNo");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }
        }
    }
}