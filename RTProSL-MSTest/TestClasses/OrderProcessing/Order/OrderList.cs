using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.OrderProcessing.Order.RTProSL_MSTest.TestClasses.OrderProcessing.Order.OrderListPlus;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using DataType = RTProSL_MSTest.ComponentHelper.DataType;

namespace RTProSL_MSTest.TestClasses.OrderProcessing.Order
{
    namespace RTProSL_MSTest.TestClasses.OrderProcessing.Order.OrderSummaryList
    {
        //developed by kambiz Abdali

        public class GeneralTab
        {
            [ValidationIgnoreInGrid]
            public string Language { get; set; }

            [ValidationIgnoreInGrid]
            public string Currency { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("Ship Method")]
            public string ShipMethodId { get; set; }

            [ValidationElementName("Return Method")]
            public string ReturnMethod { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("job Type")]
            [ValidationElementProperty("productionTypeId")]
            public string JobType { get; set; }

            [ValidationIgnoreInGrid]
            public string CheckinPriority { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("jobComponentId")]
            public string JobComponent { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("projectId")]
            public string Project { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("partnerId")]
            public string Partner { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("partnerStructureId")]
            public string PartnerStructure { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("manualStatusId")]
            public string ManualStatus { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("excludeFromProductionBS")]
            [ValidationElementName("Exclude from Job Billing Schedule")]
            [ValidationDataType(DataType.CheckBox)]
            public bool ExcludeFromProductionBS { get; set; }

            [ValidationIgnoreInGrid]
            public string ContractDate { get; set; }
            [ValidationIgnoreInGrid]
            public string CheckinDate { get; set; }
            [ValidationIgnoreInGrid]
            public string StagingCount { get; set; }
            [ValidationIgnoreInGrid]
            public string OrderTimelineWidgetNotes { get; set; }

            [ValidationIgnore(true, BaseClass.IgnoreType.Validation)]
            [ValidationIgnoreInGrid]
            public string WebOrderNo { get; set; }
            [ValidationElementProperty("managingDepartmentId")]
            public string ManagingDepartment { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("chargeTypeId")]
            public string ChargeType { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("customField1Id")]
            public string customField1 { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("customField2Id")]
            public string customField2 { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("customField3Id")]
            public string customField3 { get; set; }

            [MaxLength(60)]
            [ValidationElementName("Internal Order Notes")]
            [ValidationDataType(DataType.TextArea)]
            public string InternalNotes { get; set; }
        }

        public class DatesTab
        {
            [ValidationIgnoreInGrid]
            public string QuoteDate { get; set; }

            [ValidationElementName("Pull Date")]
            [ValidationIgnoreInGrid]
            public string PullDateOnly { get; set; }

            [ValidationElementName("PullTime")]
            [ValidationIgnoreInGrid]
            public string PullTimeOnly { get; set; }

            [ValidationColID("shippingDate")]
            public string ShipDate { get; set; }

            [ValidationIgnoreInGrid]
            public string ShipTime { get; set; }

            [MaxLength(9)]
            [ValidationElementName("Return Date")]
            public string ReturnDate { get; set; }

            [ValidationElementName("City in Address")]
            [ValidationIgnoreInGrid]
            public string AddressLine3 { get; set; }

            [ValidationElementName("Country in Address")]
            [ValidationIgnoreInGrid]
            public string AddressLine4 { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("Shipping Name in shipping")]
            public string ShippingName { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("Shipping Name in shipping")]
            public string Phone { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("Shipping Name in shipping")]
            public string Fax { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("Address1 in shipping")]
            public string ShippingAddressLine1 { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("Address2 in shipping")]
            public string ShippingAddressLine2 { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("Address3 in shipping")]
            public string ShippingAddressLine2B { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementName("city in shipping")]
            public string ShippingAddressLine3 { get; set; }
        }

        public class AddressTab
        {
            /*-----------------------Billing section---------------------------*/
            public string Name { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string AddressLine2B { get; set; }

            [ValidationElementName("State in Billing Address")]
            public string State { get; set; }

            [ValidationElementName("ZipCode in Billing Address")]
            public string ZipCode { get; set; }

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

            public string ShipState { get; set; }

            public string ShipZipCode { get; set; }

            [ValidationElementName("Ship Country")]
            public string ShippingAddressLine4 { get; set; }

            public string ShippingContact { get; set; }

            public string ShippingContactEmail { get; set; }

            public string ShippingContactPhone { get; set; }

            public string ShippingContactCell { get; set; }

            [ValidationDataType(DataType.CheckBox)]
            public bool printCustomerNotes { get; set; }

            [ValidationDataType(DataType.TextArea)]
            [ValidationElementName("JobOrderNotes")]
            public string Notes { get; set; }

            [ValidationDataType(DataType.TextArea)]
            [ValidationElementName("Delivery/Return Notes")]
            public string DeliveryNotes { get; set; }

            /*-----------------------Return section---------------------------*/
            public string ReturnName { get; set; }

            public string ReturnAddressLine1 { get; set; }
            public string ReturnAddressLine2 { get; set; }
            public string ReturnAddressLine2B { get; set; }
            [ValidationElementName("City in return section")]
            public string ReturnAddressLine3 { get; set; }
            public string ReturnState { get; set; }
            public string ReturnZipCode { get; set; }
            [ValidationElementName("Country in return section")]
            public string ReturnAddressLine4 { get; set; }//ignore

            public string ReturnContact { get; set; }//ignore
            public string ReturnContactPhone { get; set; }//ignore
            public string ReturnContactCell { get; set; }//ignore
            public string ReturnContactEmail { get; set; }//ignore
        }

        public class BillingTab
        {
            [ValidationElementProperty("PaymentTypeId")]
            public string PaymentType { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationDataType(DataType.DropDown)]
            public string BillingType { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("taxTypeId")]
            public string TaxType { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("termsId")]
            public string Terms { get; set; }

            [ValidationColID("salesperson")]
            [ValidationElementProperty("salespersonId")]
            public string Salesperson { get; set; }

            [ValidationIgnoreInGrid]
            public string DaysPerWeek { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationDataType(DataType.DropDown)]
            public string DailyWeekly { get; set; }

            [ValidationIgnoreInGrid]
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

            public string Phone { get; set; }

            [ValidationElementName("Contact Title")]
            public string Title { get; set; }

            public string Email { get; set; }
            public string CellPhone { get; set; }
            public bool EmailInclude { get; set; }
        }

        public class OrderSummaryListEntity
        {
            public OrderSummaryListEntity()
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

            [ValidationElementProperty("LocationId")]
            public string Location { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("locationReturnToId")]
            public string LocationReturnTo { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("transferToId")]
            public string TransferTo { get; set; }

            public string JobTitle { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationColID("rentalAgent1")]
            [ValidationElementProperty("rentalAgent1Id")]
            public string RentalAgent1 { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationElementProperty("rentalAgent2Id")]
            public string RentalAgent2 { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationDataType(DataType.CheckBox)]
            public bool BillableQuote { get; set; }

            //read from right side page
            [ValidationIgnoreInGrid]
            [ValidationIgnore(true, BaseClass.IgnoreType.Validation)]
            public string OrderNo { get; set; }

            [ValidationTabClick("GENERAL")] public GeneralTab GeneralTab { get; set; }
            [ValidationTabClick("DATES")] public DatesTab DatesTab { get; set; }

            [ValidationIgnoreInGrid]
            [ValidationTabClick("ADDRESS")] public AddressTab AddressTab { get; set; }
            [ValidationTabClick("BILLING")] public BillingTab BillingTab { get; set; }

            [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
            public PoTab PoTab { get; set; }
            [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
            public ContactTab ContactTab { get; set; }
        }

        [TestCategory("OrderProcessing")]
        [TestClass, TestCategory("OrderProcessing___Order")]
        public class OrderSummaryList : BaseClass
        {
            private OrderSummaryListEntity _OrderSummaryListEntity;

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


            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ArrowNextBtnCheckInOrderList()
            {
                TestInitialize(nameof(ArrowNextBtnCheckInOrderList));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");
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
            public void ArrowPreviousBtnCheckInOrderList()
            {
                TestInitialize(nameof(ArrowPreviousBtnCheckInOrderList));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");
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
            public void ArrowLastBtnCheckInOrderList()
            {
                TestInitialize(nameof(ArrowLastBtnCheckInOrderList));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");
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
            public void ArrowFirstBtnCheckInOrderList()
            {
                TestInitialize(nameof(ArrowFirstBtnCheckInOrderList));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");
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

            [TestMethod, Timeout(MaximumExecutionTime * 2)]
            public void DetailValidateOrderInOrderSummaryList()
            {
                TestInitialize(nameof(DetailValidateOrderInOrderSummaryList));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        AddOrderFunc();
                        SearchAddedOrderInGrid();

                        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
        .FirstOrDefault(o => o.Text == _OrderSummaryListEntity.JobTitle);

                        selectRow.Click();

                        ChangeScreenPageSize(40);
                        Thread.Sleep(2000);

                        var gridList = webElementAction.GetElementById("OrdersSummary-gridId");
                        //gridList.FindElements(By.TagName("div"))
                        //    .FirstOrDefault(o => o.Text == _OrderSummaryListEntity.OrderNo.Trim());

                        ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                        _OrderSummaryListEntity.DatesTab.ReturnDate = _OrderSummaryListEntity.DatesTab.ReturnDate.Substring(0, 11);
                        CreateValidationInGrid(colIds, _OrderSummaryListEntity);
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            private void SearchAddedOrderInGrid()
            {
                Thread.Sleep(500);

                OpenFilterWindow();

                Thread.Sleep(500);
                webElementAction.GetElementByCssSelector("[data-icon-name='eraser']").Click();
                Thread.Sleep(500);

                webElementAction.GetInputElementByDataFormItemNameInDiv("transfer").Click();


                webElementAction.GetElementBySpecificAttribute("id", "body-filter-refresh-btn").Click();
                ShowAllRedord();

                Thread.Sleep(500);

                SearchTextInMainGrid(_OrderSummaryListEntity.OrderNo.Trim());
                Thread.Sleep(3000);
            }
            public enum OrderSource
            {
                OrderProcessing,
                OrderList,
                Production,
            }
            public OrderSummaryListEntity AddOrderFunc(bool addContactTypeIsGrid = false, OrderSource callOrderFrom = OrderSource.OrderList, bool generateDataToParentProductionModal = true)
            {
                if (callOrderFrom == OrderSource.OrderList)
                {
                    GoToUrl("OrderProcessing", "OrderSummaryList");
                    //click on addNewRecordBtn
                    Thread.Sleep(2000);
                    webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
                    ConfirmBtnCheck();
                    Thread.Sleep(1000);
                    AddParentAndProductionToOrder();
                }
                else
                {
                    if (generateDataToParentProductionModal)
                        AddParentAndProductionToOrder();
                    ConfirmBtnCheck();
                }
                WaitForLoadingSpiner();
                GenerateDataInMainFormContext();

                //generate data to jobTitle
                new WebElementDataGenerator(webElementAction.GetElementBySpecificAttribute("data-form-item-name", "jobTitle"));

                //generate data to rentalAgent 1
                new WebElementDataGenerator(webElementAction.GetElementBySpecificAttribute("data-form-item-name", "rentalAgent1Id"));

                CreateAdd(_OrderSummaryListEntity);

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
                CreateAddInGrid(_OrderSummaryListEntity.PoTab, poColIds);

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
                    //click on post contact
                    webElementAction.ClickOnPostBtnInMinGrid();
                }
                else //add Contact Type Is form
                {
                    //click on ADD_MULTI_SELECTION
                    webElementAction.GetElementById("MINI_GRID_ADD_MULTI_SELECTION_BUTTON").Click();

                    var addcontactModal =
                        webElementAction.GetElementBySpecificAttribute("data-modal-title", "CONTACT");

                    var defaultSelectedRowinContact = webElementAction.GetElementByCssSelector(
                   ".ag-cell.ag-cell-not-inline-editing.ag-cell-normal-height.ag-cell-last-left-pinned.grid-icon-class.ag-cell-focus.ag-cell-value", addcontactModal);
                    defaultSelectedRowinContact.Click();

                    //click on confirm btn 
                    webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", addcontactModal).Click();
                }

                Thread.Sleep(3000);
                var contactColIds = webElementAction.GetElementById("OrderHeaderContactList-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
                CreateAddInGrid(_OrderSummaryListEntity.ContactTab, contactColIds, true);

                ConfirmBtnCheck();

                _OrderSummaryListEntity.OrderNo = webElementAction.GetInputElementByDataFormItemNameInDiv("searchOrderNo").GetAttribute("value");

                if (callOrderFrom != OrderSource.Production)
                {
                    webElementAction.Click(By.Id("TOOL_BOX_SAVE_AND_CLOSE_BUTTON_ID"));
                    Thread.Sleep(1000);
                    CheckErrorDialogBox();
                }
                else
                {
                    webElementAction.ClickOnPostChanges();
                    ConfirmBtnCheck(dataSection: "alertDialog");
                }

                if (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='ENTER_REASON']")))
                {
                    var modalReasonContext = webElementAction.GetElementBySpecificAttribute("data-modal-title", "ENTER_REASON");
                    webElementAction.GetElementBySpecificAttribute("data-icon-name", "report-scheduler", modalReasonContext).Click();
                    webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", modalReasonContext).Click();
                }
                return _OrderSummaryListEntity;
            }

            private void GenerateDataInMainFormContext()
            {
                new WebElementDataGenerator().DropDownListGeneratorWithFilter(dataFormaItemName: "orderType", filter: "Order");
                var context = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "jobTitle");
                new WebElementDataGenerator(context);
                context = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "rentalAgent1Id");
                new WebElementDataGenerator(context);
            }

            private void AddParentAndProductionToOrder()
            {
                var modalContext = webElementAction.GetElementBySpecificAttribute("data-modal-title", "ADD_A_NEW_ORDER");
                int tryToSelectParent = 0;
                string productionValue = string.Empty;
                _OrderSummaryListEntity = new OrderSummaryListEntity();

                new WebElementDataGenerator(modalContext);

                productionValue = webElementAction.GetInputElementByDataFormItemNameInDiv("productionId").GetAttribute("value");

                if (string.IsNullOrEmpty(productionValue))
                {
                    var parentElement = webElementAction.GetInputElementByDataFormItemNameInDiv("parentId");//.Clear();
                    webElementAction.DoubleClick(parentElement);
                    parentElement.SendKeys(Keys.Backspace);
                    webElementAction.GenerateDataToDataFormItemNameContext("productionId");
                    productionValue = webElementAction.GetInputElementByDataFormItemNameInDiv("productionId").GetAttribute("value");
                    _OrderSummaryListEntity.ProductionId = productionValue;
                }
                else
                {
                    _OrderSummaryListEntity.ProductionId = productionValue;
                }

                webElementAction.GetElementByCssSelector(".confirm-button").Click();
            }

            [TestMethod, Timeout(MaximumExecutionTime * 2)]
            public void AddOrderInOrderSummaryList()
            {
                TestInitialize(nameof(AddOrderInOrderSummaryList));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        AddOrderFunc();
                        WaitForLoadingSpiner();
                        ConfirmBtnCheck(dataSection: "alertDialog");
                        WaitForLoadingSpiner();
                        var filterContext_By = By.CssSelector(".body-filter-button-container.down-area");
                        if (!webElementAction.IsElementPresent(filterContext_By))
                            webElementAction.GetElementBySpecificAttribute("data-button-type", "filter").Click();
                        WaitForLoadingSpiner();

                        webElementAction.GetElementByCssSelector("[data-icon-name='eraser']").Click();
                        Thread.Sleep(500);

                        webElementAction.GetInputElementByDataFormItemNameInDiv("transfer").Click();

                        webElementAction.GetElementBySpecificAttribute("id", "body-filter-refresh-btn").Click();
                        WaitForLoadingSpiner();
                        ShowAllRedord();


                        Thread.Sleep(500);

                        SearchTextInMainGrid(_OrderSummaryListEntity.OrderNo);
                        WaitForLoadingSpiner();

                        ClearAllTagList();

                        Thread.Sleep(1000);
                        var gridList = webElementAction.GetElementById("OrdersSummary-gridId");

                        var OrderNoDiv = gridList.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == _OrderSummaryListEntity.OrderNo).FindElement(By.TagName("a"));
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
                CreateValidation(_OrderSummaryListEntity, context);

                //**************************validate data in Po Tab*************************************
                ClickTab("PO");
                var poGrid = webElementAction.GetElementById("orderHeaderPO-MiniGrid-gridId");//.FindElements(By.CssSelector(".ag-row.ag-row-focus"));//
                PoTab currentPoTab;
                ReadOnlyCollection<IWebElement> colIds = poGrid.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                currentPoTab = new PoTab();
                CreateAddInGrid(currentPoTab, colIds);
                ValidateEntityFieldDifferences(_OrderSummaryListEntity.PoTab, currentPoTab);

                //**************************validate data in
                //
                //
                //
                //
                //S tab*************************************
                ContacsTabClick();
                ContactTab currentContactTab;
                var contactGrid = webElementAction.GetElementById("OrderHeaderContactList-MiniGrid-gridId");//.FindElements(By.CssSelector(".ag-row.ag-row-focus"));//
                currentContactTab = new ContactTab();
                colIds = contactGrid.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                CreateAddInGrid(currentContactTab, colIds, true);
                ValidateEntityFieldDifferences(_OrderSummaryListEntity.ContactTab, currentContactTab);
            }

            [TestMethod, Timeout(MaximumExecutionTime + (MaximumExecutionTime / 2))]
            public void AddOrderInOrderSummaryListWithGridContact()
            {
                TestInitialize(nameof(AddOrderInOrderSummaryListWithGridContact));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        AddOrderFunc(addContactTypeIsGrid: true);
                        Thread.Sleep(500);

                        //If the filter window is not displayed, filter button is clicked
                        if (!webElementAction.IsElementPresent(By.XPath("//div[@class='body-filter-button-container down-area']")))
                            webElementAction.GetElementBySpecificAttribute("data-button-type", "filter").Click();
                        WaitForLoadingSpiner();
                        ConfirmBtnCheck(dataSection: "alertDialog");
                        Thread.Sleep(500);
                        webElementAction.GetElementByCssSelector("[data-icon-name='eraser']").Click();
                        Thread.Sleep(500);

                        webElementAction.GetInputElementByDataFormItemNameInDiv("transfer").Click();

                        webElementAction.GetElementBySpecificAttribute("id", "body-filter-refresh-btn").Click();
                        ShowAllRedord();
                        WaitForLoadingSpiner();
                        Thread.Sleep(500);

                        SearchTextInMainGrid(_OrderSummaryListEntity.OrderNo);

                        WaitForLoadingSpiner();
                        Thread.Sleep(1000);
                        var gridList = webElementAction.GetElementById("OrdersSummary-gridId");

                        var OrderNoDiv = gridList.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == _OrderSummaryListEntity.OrderNo).FindElement(By.TagName("a"));
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
            public void FilterOrderByProduction()
            {
                TestInitialize(nameof(FilterOrderByProduction));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        //Select all value in grid
                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("productionId", "OrdersSummary-gridId", "Production");
                        filterSearch.FilterSearchInTextDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByInputOrder()
            {
                TestInitialize(nameof(FilterOrderByInputOrder));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        //Select all value in grid
                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("orderNo", "OrdersSummary-gridId", "Order#");
                        filterSearch.FilterSearchInTextDataInGridDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByRentalAgent()
            {
                TestInitialize(nameof(FilterOrderByRentalAgent));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        //Select all value in grid
                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("rentalAgentList", "OrdersSummary-gridId", "Rental Agent", colId: "rentalAgent1");
                        filterSearch.FilterSearchInTextDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderBySalesPerson()
            {
                TestInitialize(nameof(FilterOrderBySalesPerson));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        //Select all value in grid
                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("salespersonList", "OrdersSummary-gridId", "Salesperson", colId: "salesperson");
                        filterSearch.FilterSearchInTextDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByClosed()
            {
                TestInitialize(nameof(FilterOrderByClosed));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        //Select all value in grid
                        RefreshAllRows();
                        DataLegendNameFilter("CLOSED");
                        FilterSearch filterSearch = new FilterSearch("closed", "OrdersSummary-gridId", "Order Status", colId: "orderStatus", replacementValue: "Closed");
                        filterSearch.FilterSearchInCheckBoxDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByQuote()
            {
                TestInitialize(nameof(FilterOrderByQuote));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        //Select all value in grid
                        RefreshAllRows();
                        DataLegendNameFilter("QUOTE");
                        FilterSearch filterSearch = new FilterSearch("quote", "OrdersSummary-gridId", "Order Type", colId: "orderType", replacementValue: "Quote");
                        filterSearch.FilterSearchInCheckBoxDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByReservation()
            {
                TestInitialize(nameof(FilterOrderByReservation));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        //Select all value in grid
                        RefreshAllRows();
                        DataLegendNameFilter("RESERVATION");
                        FilterSearch filterSearch = new FilterSearch("reservation", "OrdersSummary-gridId", "Order Type", colId: "orderType", replacementValue: "Reservation");
                        filterSearch.FilterSearchInCheckBoxDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByCheckOrder()
            {
                TestInitialize(nameof(FilterOrderByCheckOrder));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        //Select all value in grid
                        RefreshAllRows();
                        DataLegendNameFilter("ORDER");
                        FilterSearch filterSearch = new FilterSearch("order", "OrdersSummary-gridId", "Order Type", colId: "orderType", replacementValue: "Order");
                        filterSearch.FilterSearchInCheckBoxDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByCancelled()
            {
                TestInitialize(nameof(FilterOrderByCancelled));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        //Select all value in grid
                        RefreshAllRows();
                        DataLegendNameFilter("CANCELLED");
                        FilterSearch filterSearch = new FilterSearch("cancelled", "OrdersSummary-gridId", "Order Type", colId: "orderType", replacementValue: "Cancelled");
                        filterSearch.FilterSearchInCheckBoxDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByPrecount()
            {
                TestInitialize(nameof(FilterOrderByPrecount));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        //Select all value in grid
                        RefreshAllRows();
                        DataLegendNameFilter("PRECOUNT");
                        FilterSearch filterSearch = new FilterSearch("precount", "OrdersSummary-gridId", "Order Type", colId: "orderType", replacementValue: "Precount");
                        filterSearch.FilterSearchInCheckBoxDataType();
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByShipDateRange()
            {
                TestInitialize(nameof(FilterOrderByShipDateRange));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("ShippingDate1", "OrdersSummary-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("shippingDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByPullDateRange()
            {
                TestInitialize(nameof(FilterOrderByPullDateRange));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("pullDate1", "OrdersSummary-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("pullDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByReturnDateRange()
            {
                TestInitialize(nameof(FilterOrderByReturnDateRange));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("returnDate1", "OrdersSummary-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("returnDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByCheckoutCheckinDateRange()
            {
                TestInitialize(nameof(FilterOrderByCheckoutCheckinDateRange));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("checkinOutDate1", "OrdersSummary-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("usageBeginDate", "usageEndDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByRangePickerTitle()
            {
                TestInitialize(nameof(FilterOrderByRangePickerTitle));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("createDate1", "OrdersSummary-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("createDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }


            [TestMethod, Timeout(MaximumExecutionTime)]
            public void PostContactErrorMessageInOrderListSummery()
            {
                TestInitialize(nameof(PostContactErrorMessageInOrderListSummery));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        //click on addNewRecordBtn
                        webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();

                        AddParentAndProductionToOrder();

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
                    throw new Exception("Error: Message box 'The Contact has not been posted'  did not display");
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ValidateRequiredFieldsMessageBoxInOrderSummaryList()
            {
                TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInOrderSummaryList));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        ValidateRequiredFieldsMessage validateRequiredFields;

                        validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "OrderProcessing", subMenu: "OrderSummaryList", filed: "rentalAgent2Id", steps: 2);

                        validateRequiredFields.Run();

                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }


            public void AddPrimaryContactFunc()
            {
                GoToUrl("OrderProcessing", "OrderSummaryList");
                RefreshAllRows();
                var firstOrderNum = webElementAction.GetAllCellsInMinGridBySpecificColId(gridId: "OrdersSummary-gridId", colId: "orderNo").First().FindElement(By.TagName("a"));
                //click on addNewRecordBtn
                firstOrderNum.Click();
                WaitForLoadingSpiner();

                DeleteAllContacts();

                AddContacts();
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void AddPrimaryContact()
            {
                TestInitialize(nameof(AddPrimaryContact));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        AddPrimaryContactFunc();
                        VerifyContactInformation();

                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }


            private void DeleteAllContacts()
            {
                ClickOnEditBtn();
                ClickTab("CONTACT");
                var contactContext = GetTabContext("CONTACT");
                DeleteAllRowsInMinGrid(contactContext, dataHeaderName: "OrderHeaderContactList-MiniGrid");
                webElementAction.ClickOnPostChanges();
                // Add more steps as needed
            }

            private void AddContacts()
            {
                WaitForLoadingSpiner();
                var addPrimaryContact = webElementAction.GetElementByCssSelector(".add-icon-box");
                addPrimaryContact.Click();

                var firstTwoItems = webElementAction.GetAllElementsByCssSelector(".icon-small-font.icon-add").Skip(1).Take(2).ToList();

                foreach (var item in firstTwoItems)
                    item.Click();

                ConfirmBtnCheck(dataSection: "modal");

                var contactColIds = webElementAction.GetElementById("OrderHeaderContactList-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));
                _OrderSummaryListEntity = new OrderSummaryListEntity();
                CreateAddInGrid(_OrderSummaryListEntity.ContactTab, contactColIds, true);
                // Add more steps as needed
                webElementAction.ClickOnPostChanges();
            }

            private void VerifyContactInformation()
            {
                var PrimaryContactForm = webElementAction.GetElementByCssSelector(".font-weight-bold");

                if (webElementAction.FindElementsContainingText(_OrderSummaryListEntity.ContactTab.Id).Count == 0)
                {
                    throw new Exception("Error: Contact does not exist in Primary Contact Form");
                }

                if (webElementAction.FindElementsContainingText(_OrderSummaryListEntity.ContactTab.Name).Count == 0)
                {
                    throw new Exception("Error: Contact Name does not exist in Primary Contact Form");
                }

                if (webElementAction.FindElementsContainingText(_OrderSummaryListEntity.ContactTab.Email).Count == 0)
                {
                    throw new Exception("Error: Contact Email does not exist in Primary Contact Form");
                }

                // Add more verification steps as needed
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void VerifyPrimaryContactSelectionDialogDisplay()
            {
                TestInitialize(nameof(VerifyPrimaryContactSelectionDialogDisplay));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        AddPrimaryContactFunc();

                        ClickEditPrimaryContact();
                        string secondContactValue = SelectSecondContact();

                        VerifyPrimaryContactInGrid(secondContactValue);

                        VerifyPrimaryContactInPrimaryContactForm();

                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            private void ClickEditPrimaryContact()
            {
                var editPrimaryContact = webElementAction.GetElementByCssSelector(".orange-color");
                editPrimaryContact.Click();
            }

            private string SelectSecondContact()
            {
                var setPrimaryContactGrid = webElementAction.GetElementById("SingleContactColumnStateName-gridId");
                var secondContactElement = setPrimaryContactGrid.FindElements(By.CssSelector("[col-id='id']"))[2];
                secondContactElement.Click();

                var secondContactValue = webElementAction.GetElementById("SingleContactColumnStateName-gridId")
                                            .FindElements(By.CssSelector("[col-id='id']"))[2]
                                            .Text;
                ConfirmBtnCheck(dataSection: "modal");
                return secondContactValue;
            }

            private void VerifyPrimaryContactInGrid(string secondContactValue)
            {
                var contactColIds = webElementAction.GetElementById("OrderHeaderContactList-MiniGrid-gridId")
                                                    .FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));
                if (!contactColIds.Any(o => o.Text.Contains(secondContactValue)))
                {
                    throw new Exception("Error: Editing the primary contact does not work correctly in the Min-grid.");
                }
            }

            private void VerifyPrimaryContactInPrimaryContactForm()
            {
                var primaryContactForm = webElementAction.GetElementByCssSelector(".font-weight-bold");
                if (webElementAction.FindElementsContainingText(_OrderSummaryListEntity.ContactTab.Id).Count == 0)
                {
                    throw new Exception("Error: Editing the primary contact does not work correctly in the PrimaryContactForm.");
                }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void VerifySignedTermsAndConditionsCheckboxFromProductionDefault()
            {
                TestInitialize(nameof(VerifySignedTermsAndConditionsCheckboxFromProductionDefault));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("Administration", "Production");
                        // go page production check checkbox in false and save

                        RefreshAllRows();

                        SelectRandomProductionAndEdit();

                        GenerateDataToGeneralAndContactTabs();
                        var productionNumber = webElementAction.GetInputElementByDataFormItemTypeInDiv("searchCodeInput").GetAttribute("value");
                        SaveAndConfirmCheck();

                        Thread.Sleep(2000);
                        AddNewOrder(productionNumber);

                        ClickTab("GENERAL");

                        if (!webElementAction.GetInputElementByDataFormItemNameInDiv("signedTerms").Selected)
                            throw new Exception("Error : The selected checkbox is not being displayed on this page");

                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            private void AddNewOrder(string productionNumber)
            {
                GoToUrl("OrderProcessing", "OrderSummaryList", false);
                // go page order add new order with check checkbox is false

                RefreshAllRows();
                webElementAction.ClickOnAddNewRecord();

                var Context = webElementAction.GetElementBySpecificAttribute("data-modal-title", "ADD_A_NEW_ORDER")
                    .FindElements(By.CssSelector("[data-form-item-name='productionId']"));
                new WebElementDataGenerator().ComboAutoCompleteGenerator(Context, productionNumber);

                ConfirmBtnCheck(dataSection: "modal", confirm: true);
            }

            private void GenerateDataToGeneralAndContactTabs()
            {
                ClickTab("GENERAL");

                if (webElementAction.GetInputElementByDataFormItemNameInDiv("signedTerms").Selected)
                    webElementAction.Click(By.Id("TOOL_BOX_CANCEL_CHANGES_BUTTON_ID"));
                else
                {
                    Thread.Sleep(2000);
                    webElementAction.SelectingCheckbox("signedTerms");
                    {
                        ClickTab("CONTACTS");

                        if (GetRowCountFromGridPinnedFooter("ProductionContactList-MiniGrid-gridId") == 0)
                        {
                            var contactContext = GetTabContext("CONTACTS");
                            //delete all contacts
                            DeleteAllRowsInMinGrid(contactContext, dataHeaderName: "ProductionContactList-MiniGrid");

                            //add contact btn
                            webElementAction.Click(By.Id("MINI_GRID_ADD_MULTI_SELECTION_BUTTON"));
                            //click on refresh btn
                            webElementAction.Click(By.CssSelector(".multi-select-container .icon-refresh"));

                            var addContactModal =
                                webElementAction.GetElementBySpecificAttribute("data-modal-title", "CONTACT");

                            webElementAction.Click(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"), addContactModal);

                            //click on confirm btn 
                            ConfirmBtnCheck(dataSection: "modal");
                        }
                    }
                }
            }

            private static void SelectRandomProductionAndEdit()
            {
                var CountRow = webElementAction.GetElementById("ProductionList-gridId").FindElements(By.TagName("div"))
                    .Where(o => o.GetAttribute("col-id") == "id").Count();

                var randomRow = int.Parse(RandomValueGenerator.GenerateRandomInt(0, CountRow));

                var idColIds = webElementAction.GetAllElementsByCssSelector("[col-id='id']").Skip(randomRow).First();
                //var idColId = idColIds.Skip(randomRow).First();
                idColIds.Click();
                Thread.Sleep(2000);

                webElementAction.Click(By.Id("TOOL_BOX_EDIT_BUTTON_ID"));
            }
            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ClearAllColumnsFilterInOrderList()
            {
                TestInitialize(nameof(VerifySignedTermsAndConditionsCheckboxFromProductionDefault));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        RefreshAllRows();
                        ClearAllColumnsFilter(gridId: "OrdersSummary-gridId", FindColumnTxt: "Rental Agent", colId: "rentalAgent1");
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
                GoToUrl("OrderProcessing", "OrderSummaryList");
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
                order.FindElement(By.TagName("a")).Click(); //<a href="/order-header?detailId=315463&amp;detailMode=full-screen" target="_self_detail" class="main-link hyper-link-style">315463</a>
                ClickTab("PO");

                bool isPoPresent = IsValuePresentInGrid(gridId: "orderHeaderPO-MiniGrid-gridId", targetValue: addedPONumber);
                if (!isPoPresent)
                {
                    throw new Exception($"The added PO# {addedPONumber} from Order #1 is not displayed in Order #2.");
                }
            }


            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByDeliveryDateAndTimeRange()
            {
                TestInitialize(nameof(FilterOrderByDeliveryDateAndTimeRange));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("deliveryDate1", "OrdersSummary-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("createDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void FilterOrderByPickupDateAndTimeRange()
            {
                TestInitialize(nameof(FilterOrderByPickupDateAndTimeRange));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");

                        RefreshAllRows();
                        FilterSearch filterSearch = new FilterSearch("pickupDate1", "OrdersSummary-gridId");
                        filterSearch.FilterSearchInDateTimeDataType("createDate");
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ChangeOrderTypeInOrderHeaderScreenAndCheckRecordInExceptionsReport_Business() // feature number 28 release New Features 07-07-2024(2)
            {
                TestInitialize(nameof(ChangeOrderTypeInOrderHeaderScreenAndCheckRecordInExceptionsReport_Business));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");
                        RefreshAllRows();
                        string orderNumberName;

                        /* Step 1:Goto order list and find one row and click */
                        {
                            while (true)
                            {
                                orderNumberName = SelectRandomOrder();
                                ChangeOrderType(orderNumberName);

                                if (webElementAction.IsElementPresent(By.CssSelector("[data-section = 'errorDialog']")))
                                    HandleErrors(true);
                                else
                                    break;
                            }
                        }
                        /* Step :Goto "Exceptions Report" and check order in find record log*/
                        {
                            GoToUrl("Reports", "ExceptionsReport", false);

                            CheckOrderInExceptionsReport(orderNumberName);
                            if (webElementAction.IsElementPresent(By.CssSelector("[data-section = 'errorDialog']")))
                                HandleErrors();
                            IsValuePresentInGrid("EXCEPTIONS_REPORT-gridId", orderNumberName);
                        }
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }
            void HandleErrors(bool isGenerate = false)
            {
                Thread.Sleep(1000);
                var errorMessage = webElementAction.GetElementBySpecificAttribute("class", "error-message-dialog").GetAttribute("innerText");
                if (errorMessage.Contains("Error:"))
                    ConfirmBtnCheck(dataSection: "errorDialog");
                if (!isGenerate)
                    Assert.Fail("fail load list log order");

                webElementAction.Click(By.Id("TOOL_BOX_CANCEL_CHANGES_BUTTON_ID"));
                GoToUrl("OrderProcessing", "OrderSummaryList", false);
                RefreshAllRows();

            }
            string SelectRandomOrder()
            {
                Thread.Sleep(1000);
                var gridList = webElementAction.GetElementById("OrdersSummary-gridId");
                var taxTypeColId = gridList.FindElements(By.TagName("div"))
                    .Where(o => o.GetAttribute("col-id") == "orderNo"
                                && !o.GetAttribute("innerText").Contains("Quote#")
                                || !o.GetAttribute("innerText").Contains("Reference#"))
                    .ToList();

                var randomIndex = int.Parse(RandomValueGenerator.GenerateRandomInt(0, taxTypeColId.Count));
                var selectedOrder = taxTypeColId[randomIndex];
                var orderName = selectedOrder.GetAttribute("innerText");
                Thread.Sleep(1000);
                webElementAction.DoubleClick(selectedOrder);

                WaitForLoadingSpiner();
                Thread.Sleep(3000);

                ConfirmBtnCheck();

                webElementAction.GetElementByCssSelector(
                    ".ant-collapse > div:nth-of-type(1) .ellipsis-container").FindElements(By.TagName("a"))
                    .Where(o => o.GetAttribute("innerText").Contains(orderName))
                    .First().Click();
                Thread.Sleep(1000);
                return orderName;
            }

            void CheckOrderInExceptionsReport(string orderNumber)
            {
                Thread.Sleep(1000);
                GoToUrl("Reports", "ExceptionsReport", false);
                var inputElement = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "orderNo").FindElements(By.TagName("input")).First();
                inputElement.SendKeys(orderNumber);

                Thread.Sleep(2000);
                webElementAction.GetElementBySpecificAttribute("data-icon-name", "report-list").Click();
                WaitForLoadingSpiner();
            }

            void ChangeOrderType(string orderNumber)
            {
                Thread.Sleep(1000);
                ClickOnEditBtn();

                Thread.Sleep(1000);

                string[] orderTypes = { "Quote", "Reservation", "Order", "Precount" };
                var activityTypeDropDown = webElementAction.GetInputElementByDataFormItemNameInDiv("orderType");

                // Get the current order type  
                string currentOrderType = activityTypeDropDown.GetAttribute("title");

                // Select a new random order type that is different from the current type  
                string newOrderType;
                do
                {
                    int randomIndex = int.Parse(RandomValueGenerator.GenerateRandomInt(0, orderTypes.Length));
                    newOrderType = orderTypes[randomIndex];
                }
                while (currentOrderType.Contains(newOrderType)); // Keep looping until we get a different order type

                // Sending the new order type  
                activityTypeDropDown.SendKeys(newOrderType);

                // Click on the newly selected order type  
                if (webElementAction.IsElementPresent(By.CssSelector($"[title='{newOrderType}']")))
                {
                    webElementAction.GetElementBySpecificAttribute("title", newOrderType).Click();
                }

                SaveAndConfirmCheck();

                ConfirmBtnCheck(dataSection: "alertDialog");
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ValidateInternalOrderInOrderHeaderScreen_Business()
            {
                TestInitialize(nameof(ValidateInternalOrderInOrderHeaderScreen_Business));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");
                        RefreshAllRows();
                        string textNoteOrder;
                        string textNoteOrderInEdit;

                        // Step 1: Navigate to the delivery return submenu  
                        {
                            NavigateToSubMenu("INTERNAL_NOTES");
                        }
                        // Step 2: Add a note and get the entered text  
                        {
                            textNoteOrder = EnterOrderNoteAndConfirm(dataModalTitle: "INTERNAL_ORDER_NOTES");
                        }
                        // Step 3: Retrieve the edited note text  
                        {
                            textNoteOrderInEdit =
                                RetrieveEditedNoteText(nameElementRed: "Internal Order Notes", dataModalTitle: "INTERNAL_ORDER_NOTES");
                        }
                        // Step 4: Validate the edited note text against the original  
                        {
                            ValidateNotesMatch(editedNote: textNoteOrderInEdit, originalNote: textNoteOrder);
                        }

                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ValidateBillingOrderInOrderHeaderScreen_Business()
            {
                TestInitialize(nameof(ValidateBillingOrderInOrderHeaderScreen_Business));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");
                        RefreshAllRows();
                        string textNoteOrder;
                        string textNoteOrderInEdit;

                        // Step 1: Navigate to the delivery return submenu  
                        {
                            NavigateToSubMenu("PRODUCTION_ORDER");
                        }
                        // Step 2: Add a note and get the entered text  
                        {
                            textNoteOrder = EnterOrderNoteAndConfirm(dataModalTitle: "PRODUCTION_ORDER_NOTES");
                        }
                        // Step 3: Retrieve the edited note text  
                        {
                            textNoteOrderInEdit =
                                RetrieveEditedNoteText(nameElementRed: "Billing Notes", dataModalTitle: "PRODUCTION_ORDER_NOTES");
                        }
                        // Step 4: Validate the edited note text against the original  
                        {
                            ValidateNotesMatch(editedNote: textNoteOrderInEdit, originalNote: textNoteOrder);
                        }
                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ValidateDeliveryReturnOrderInOrderHeaderScreen_Business()
            {
                TestInitialize(nameof(ValidateDeliveryReturnOrderInOrderHeaderScreen_Business));
                while (!testPassed && retryCount < maxRetries)
                {
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");
                        RefreshAllRows();
                        string textNoteOrder;
                        string textNoteOrderInEdit;

                        // Step 1: Navigate to the delivery return submenu  
                        {
                            NavigateToSubMenu("DELIVERY_RETURN");
                        }
                        // Step 2: Add a note and get the entered text  
                        {
                            textNoteOrder = EnterOrderNoteAndConfirm(dataModalTitle: "DELIVERY_RETURN_NOTES");
                        }
                        // Step 3: Retrieve the edited note text  
                        {
                            textNoteOrderInEdit =
                                RetrieveEditedNoteText(nameElementRed: "Delivery Notes", dataModalTitle: "ORDER_DELIVERY_RETURN_NOTES");
                        }
                        // Step 4: Validate the edited note text against the original  
                        {
                            ValidateNotesMatch(editedNote: textNoteOrderInEdit, originalNote: textNoteOrder);
                        }

                        testPassed = true;
                    }
                    catch (Exception ex)
                    {
                        HandleTestFailure(ex.Message);
                    }
                }
            }
            // Navigates to the specified submenu and clicks on a random order  
            private void NavigateToSubMenu(string subMenu)
            {
                int randomIndex = int.Parse(RandomValueGenerator.GenerateRandomInt(1, 25));
                webElementAction.GetElementByCssSelector($".ag-pinned-left-cols-container > [row-index='{randomIndex}'] .dark-regular-small")
                    .FindElement(By.TagName("a")).Click();
                Thread.Sleep(1000);
                GoToSubMenu("ORDER_HEADER_SCREEN_NOTES_DROP_DOWN", subMenu);
            }

            // Enters a note for the specified data modal and returns the entered text  
            private string EnterOrderNoteAndConfirm(string dataModalTitle)
            {
                string textNoteOrder = RandomValueGenerator.GenerateRandomString(10);
                var textAreaInput = webElementAction.GetElementByCssSelector($"[data-modal-title='{dataModalTitle}'] .notes-dialog-content .customInput_wrapper")
                    .FindElement(By.TagName("textarea"));
                textAreaInput.Clear();
                textAreaInput.SendKeys(textNoteOrder);
                Thread.Sleep(1000);
                ConfirmBtnCheck(dataSection: "modal");

                return textNoteOrder;
            }

            // Retrieves the edited note text based on the red indicator name and modal title  
            private string RetrieveEditedNoteText(string nameElementRed, string dataModalTitle)
            {
                var findElementRed = webElementAction.GetElementByCssSelector(".red-indicator")
                    .FindElements(By.TagName("div")).Where(o => o.Text == nameElementRed).ToList();

                Thread.Sleep(1000);
                findElementRed[0].Click();

                //ClickOnEditBtn();
                //var internalOrderTextInEdit = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "internalNotes")
                //    .FindElement(By.TagName("textarea")).Text;

                Thread.Sleep(1000);
                return webElementAction.GetElementByCssSelector($"[data-modal-title='{dataModalTitle}'] .notes-dialog-content .customInput_wrapper").Text;
            }

            // Validates that the edited note matches the original note  
            private void ValidateNotesMatch(string editedNote, string originalNote)
            {
                if (editedNote != originalNote)
                    Assert.Fail($"Error: The entered note '{editedNote}' does not match the original note '{originalNote}'.");
            }

            [TestMethod, Timeout(MaximumExecutionTime)]
            public void ValidateRefreshRecordDataInGrid()
            {
                TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
                while (!testPassed && retryCount < maxRetries)
                    try
                    {
                        GoToUrl("OrderProcessing", "OrderSummaryList");
                        RefreshRecordDataInGrid("OrdersSummary-gridId", columnId: "orderNo");
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