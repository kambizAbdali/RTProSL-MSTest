using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses;
using RTProSL_MSTest.TestClasses.OrderProcessing.Order.RTProSL_MSTest.TestClasses.OrderProcessing.Order.OrderSummaryList;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataType = RTProSL_MSTest.ComponentHelper.DataType;

namespace RTProSL_MSTest.BussinessTestClasses.OrderHeaderScreen
{
    [TestClass]
    public class OrderBillingSchedule : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void CreateOrderBillingScheduleFromOrder_Business()
        {
            TestInitialize(nameof(CreateOrderBillingScheduleFromOrder_Business));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderSummaryList");
                    //Select all value in grid
                    RefreshAllRows();

                    var gridOrderElement = webElementAction.GetElementById(Id: "OrdersSummary-gridId");
                    var firstTwoOrderElements = webElementAction.GetAllElementsByTagName("a", gridOrderElement).Take(2).ToList();
                    var firstTwoOrderTexts = firstTwoOrderElements.Select(element => element.Text).ToList();

                    // Add Order Billing Schedule to Order #1
                    firstTwoOrderElements[0].Click();

                    GoToSubMenu("ACTION_TOOL_DROPDOWN", "ORDER_BILLING_SCHEDULE");

                    //click on last record in grid
                    if (GetRowCountFromGridPinnedFooter(gridId: "OrderBillingScheduleList-gridId") > 0)
                    {
                        webElementAction.GetAllCellsInMinGridBySpecificColId(gridId: "OrderBillingScheduleList-gridId", colId: "cycle").Last().Click();
                        this.DeleteAllRowsInMinGrid(tabContaxt: GetTabContext("NORMAL"), dataHeaderName: "OrderBillingScheduleList");
                    }

                    AddNormlBillingSchedule();

                    CreateBillingScheduleFromOrderFunc(firstTwoOrderTexts);
                    ConfirmBtnCheck();
                    // Validate Inserted Order Billing Schedule from another order 
                    var orderBillingScheduleColIds = webElementAction.GetElementById("OrderBillingScheduleList-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
                    CreateValidationInGrid(orderBillingScheduleColIds, orderBillingScheduleEntity);

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        private void CreateBillingScheduleFromOrderFunc(List<string> firstTwoOrderTexts)
        {
            GoToUrl("OrderProcessing", "OrderSummaryList", gotoLogin: false);

            RefreshAllRows();
            this.SearchAndEditClick(firstTwoOrderTexts[1]);
            GoToSubMenu("ACTION_TOOL_DROPDOWN", "ORDER_BILLING_SCHEDULE");

            // click on Create from Order Button
            webElementAction.Click(By.XPath("//span[.='Create from Order']"));

            ConfirmBtnCheck();// Confirm: All the previous Billing schedule will be Replaced. Do you want to continue?

            var copyFromQuoteNumInput = webElementAction.GetElementByName("FromOrderNo");
            copyFromQuoteNumInput.SendKeys(firstTwoOrderTexts[0]);

            ConfirmBtnCheck(dataSection: "modal");
            CheckErrorDialogBox();
        }

        public void SearchAndEditClick(string orderNo)
        {
            SearchTextInMainGrid(orderNo);
            WaitForLoadingSpiner();

            ClearAllTagList();

            Thread.Sleep(1000);
            var gridList = webElementAction.GetElementById("OrdersSummary-gridId");

            var OrderNoDiv = gridList.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == orderNo).FindElement(By.TagName("a"));
            OrderNoDiv.Click();
        }

        OrderBillingScheduleEntity orderBillingScheduleEntity;

        private void AddNormlBillingSchedule()
        {
            var addNormalBillingSchedule = webElementAction.GetElementByCssSelector(".icon-add");
            addNormalBillingSchedule.Click();

            WaitForLoadingSpiner();
            var orderBillingScheduleEntryContext = webElementAction.GetElementByCssSelector("[data-form-name='OrderBillingScheduleList'] .advance-left-section");
            // Generate data for the billing schedule entry  
            new WebElementDataGenerator(orderBillingScheduleEntryContext);

            // Clear amount value 
            var amountInput = webElementAction.GetInputElementByDataFormItemNameInDiv("amount");
            webElementAction.DoubleClick(amountInput);
            amountInput.SendKeys(Keys.Backspace);

            SaveAndConfirmCheck();

            orderBillingScheduleEntity = new OrderBillingScheduleEntity();

            var orderBillingScheduleColIds = webElementAction.GetElementById("OrderBillingScheduleList-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//

            CreateAddInGrid(orderBillingScheduleEntity, orderBillingScheduleColIds, true);
        }

        public class OrderBillingScheduleEntity
        {
            public string Cycle { get; set; }                // Cycle (e.g., weekly, monthly)  
            [ValidationColID("weeks")]
            [ValidationIgnore]
            public string WeeksOrMonths { get; set; }        // Weeks / Months  
            [ValidationIgnore]
            public string BeginDate { get; set; }            // Begin Date  
            [ValidationIgnore]
            public string EndDate { get; set; }              // End Date  
            [ValidationColID("amount")]
            public string FixedAmount { get; set; }          // Fixed Amount  
            [ValidationColID("id")]
            [ValidationIgnore]
            public string QuoteNumber { get; set; }          // Quote#  
            public decimal DiscountPercentage { get; set; }  // Disc%  
            [ValidationIgnore]
            public string PrintSortOrder { get; set; }       // Print Sort Order  
            public bool DiscountLockedItems { get; set; }    // Discount Locked Items  
            public string Note { get; set; }                 // Note 
        }

        public void DeleteAllRowsInMinGrid(IWebElement tabContaxt, string dataHeaderName)
        {
            while (!webElementAction.IsElementPresent(By.CssSelector("#TOOL_BOX_DELETE_BUTTON_ID[disabled] .icon-delete"), tabContaxt))
            {
                webElementAction.GetElementByCssSelector("[data-header-name='" + dataHeaderName + "'] .icon-delete").Click();
                ConfirmBtnCheck(dataSection: "confirmDialog");

                // Temporary Codes
                if (webElementAction.IsElementPresent(By.CssSelector("[data-section=errorDialog]")))
                {
                    ConfirmBtnCheck(dataSection: "errorDialog");
                    break;
                }
            }
        }

        public class BillingScheduleCodesEntity
        {
            [ValidationIgnore]
            [ValidationElementProperty("id")]
            public string Code { set; get; }

            [ValidationDataType(DataType.DropDown)]
            [ValidationElementProperty("bsAction")]
            public string RepeatLoop { set; get; }

            public string Description { set; get; }

            [ValidationElementProperty("bsCycle")] public string Cycle { set; get; }

            [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
            [ValidationDataType(DataType.CheckBox)]
            public bool Space { set; get; }
        }
        BillingScheduleCodesEntity _BillingScheduleCodes;

        public void AddBillingScheduleCodesFunc()
        {
            _BillingScheduleCodes = new BillingScheduleCodesEntity();

            GoToUrl("Administration", "BillingScheduleCodes");

            //click on addNewRecordBtn
            webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
            new WebElementDataGenerator(GetFormLeftSideContext());

            webElementAction.DeSelectingCheckbox(dataFormItemName: "space");

            CreateAdd(_BillingScheduleCodes);
            //click on saveAndCloseBtn and check confirm
            SaveAndConfirmCheck();
        }

        public class BillingScheduleSetupEntity
        {
            [ValidationIgnore(true, IgnoreType.Add)]
            [ValidationElementProperty("id")]
            public string Code { set; get; } //

            public string Cycle { set; get; } //

            public string Count { set; get; } //
            public string DiscountPercentage { set; get; } //
        }
        private BillingScheduleSetupEntity[] _billingScheduleSetupList;

        private BillingScheduleSetupEntity AddBillingScheduleSetupFunc()
        {
            var _billingScheduleSetupEntity = new BillingScheduleSetupEntity();
            //click on addNewRecordBtn
            webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
            var context = GetFormLeftSideContext();
            new WebElementDataGenerator(context);

            var billingScheduleCodeContext = context.FindElements(By.CssSelector(".combo-auto-complete"));
            //Add _BillingScheduleCodes to Code
            new WebElementDataGenerator().ComboAutoCompleteGenerator(billingScheduleCodeContext, searchFiter: _BillingScheduleCodes.Code);

            CreateAdd(_billingScheduleSetupEntity);

            _billingScheduleSetupEntity.Code = webElementAction.GetInputElementByDataFormItemNameInDiv("id", context).GetAttribute("value");
            //click on saveAndCloseBtn and check confirm
            SaveAndConfirmCheck();

            return _billingScheduleSetupEntity;
        }


        //[TestMethod, Timeout(MaximumExecutionTime)]
        //public void CreateOrderBillingScheduleFromTemplate_Business()
        //{
        //    TestInitialize(nameof(CreateOrderBillingScheduleFromTemplate_Business));
        //    //while (!testPassed && retryCount < maxRetries)
        //    //    try
        //    //    {
        //    //1) Add a Billing Schedule Code Alpha
        //    {
        //        AddBillingScheduleCodesFunc();
        //    }

        //    //2) Add 2 Billing Schedule Setup to Billing Schedule Code Alpha
        //    {
        //        GoToUrl("Administration", "BillingScheduleSetup", gotoLogin: false);
        //        _billingScheduleSetupList = new BillingScheduleSetupEntity[2];

        //        for (int i = 0; i < _billingScheduleSetupList.Length; i++)
        //            _billingScheduleSetupList[i] = AddBillingScheduleSetupFunc();
        //    }

        //    string orderNumber = default;
        //    //3) Go to a random order billing schedule 
        //    {
        //        GoToUrl("OrderProcessing", "OrderSummaryList", gotoLogin: false);
        //        //Select all value in grid
        //        RefreshAllRows();
        //        var gridOrderElement = webElementAction.GetElementById(Id: "OrdersSummary-gridId");
        //        var firstOrderElement = webElementAction.GetAllElementsByTagName("a", gridOrderElement).First();
        //        orderNumber = firstOrderElement.Text;
        //        //click on first order
        //        firstOrderElement.Click();
        //        GoToSubMenu("ACTION_TOOL_DROPDOWN", "ORDER_BILLING_SCHEDULE");
        //    }

        //    //4) Select Billing Schedule Code Alpha And Create From Template
        //    {
        //        var billingScheduleCodeIdContext = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "billingScheduleCodeId").FindElements(By.CssSelector(".combo-auto-complete"));
        //        new WebElementDataGenerator().ComboAutoCompleteGenerator(billingScheduleCodeIdContext, _BillingScheduleCodes.Code);
        //        webElementAction.Click(By.XPath("//span[.='Create from Template']"));
        //        ConfirmBtnCheck();
        //    }

        //    //5) Validate Added Billing Schedule Setups
        //    {
        //        var orderBillingScheduleNormalGrid = webElementAction.GetElementById("OrderBillingScheduleList-gridId");
        //        var orderIds = webElementAction.GetAllCellsInMinGridBySpecificColId(gridId: "OrderBillingScheduleList-gridId", colId: "id").Select(o => o.Text);
        //        foreach (var orderId in orderIds)
        //        {
        //            if (orderId.Equals())
        //        }
        //    }

        //    // Validate Inserted Order Billing Schedule from another order 
        //    var orderBillingScheduleColIds = webElementAction.GetElementById("OrderBillingScheduleList-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
        //    CreateValidationInGrid(orderBillingScheduleColIds, orderBillingScheduleEntity);

        //    testPassed = true;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    HandleTestFailure(ex.Message);
        //    //}
        //}
    }
}