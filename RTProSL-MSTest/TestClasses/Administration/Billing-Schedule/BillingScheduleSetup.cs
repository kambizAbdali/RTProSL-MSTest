using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.AccountsReceivable.AR;

namespace RTProSL_MSTest.TestClasses.Administration.Billing_Schedule;

[TestCategory("Administration")]
[TestClass, TestCategory("Administration___BillingSchedule")]
public class BillingScheduleSetup : BaseClass //   developed by kambiz Abdali
{

    public class BillingScheduleSetupEntity
    {
        [ValidationIgnore(true, IgnoreType.Add)]
        [ValidationElementProperty("id")]
        public string Code { set; get; } //

        public string Cycle { set; get; } //

        public string Count { set; get; } //
        public string DiscountPercentage { set; get; } //
    }
    private BillingScheduleSetupEntity _billingScheduleSetupEntity;

    private void AddBillingScheduleSetupFunc()
    {
        GoToUrl("Administration", "BillingScheduleSetup");
        _billingScheduleSetupEntity = new BillingScheduleSetupEntity();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        var context = GetFormLeftSideContext();
        new WebElementDataGenerator(context);
        CreateAdd(_billingScheduleSetupEntity);

        _billingScheduleSetupEntity.Code = webElementAction.GetInputElementByDataFormItemNameInDiv("id", context).GetAttribute("value");
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }
    public void ValidateInsertedBillingScheduleSetupFunc()
    {
        Thread.Sleep(500);
        var selectRow = webElementAction.GetElementsByTagName("div")
            .FirstOrDefault(o => o.GetAttribute("class").Contains("ag-cell-focus"));
        webElementAction.DoubleClick(selectRow);
        Thread.Sleep(500);
        CreateValidation(_billingScheduleSetupEntity);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInBillingScheduleSetup()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInBillingScheduleSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "BillingScheduleSetup");
                if (!HasRowCheck()) { testPassed = true; break;} 
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInBillingScheduleSetup()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInBillingScheduleSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "BillingScheduleSetup");
                if (!HasRowCheck()) { testPassed = true; break;} 
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInBillingScheduleSetup()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInBillingScheduleSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "BillingScheduleSetup");
                if (!HasRowCheck()) { testPassed = true; break;} 
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInBillingScheduleSetup()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInBillingScheduleSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "BillingScheduleSetup");
                if (!HasRowCheck()) { testPassed = true; break;} 
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInBillingScheduleSetup()
    {
        TestInitialize(nameof(ListViewBtnCheckInBillingScheduleSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "BillingScheduleSetup");
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInBillingScheduleSetup()
    {
        TestInitialize(nameof(CardViewBtnCheckInBillingScheduleSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "BillingScheduleSetup");
                if (!HasRowCheck()) { testPassed = true; break;} 
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddBillingScheduleSetupWithAllFields()
    {
        TestInitialize(nameof(AddBillingScheduleSetupWithAllFields));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddBillingScheduleSetupFunc();
                ValidateInsertedBillingScheduleSetupFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBillingScheduleSetup()
    {
        TestInitialize(nameof(EditBillingScheduleSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _billingScheduleSetupEntity = new BillingScheduleSetupEntity();
                //navigate to Salesperson page 
                GoToUrl("Administration", "BillingScheduleSetup");

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Partner Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_billingScheduleSetupEntity);
                _billingScheduleSetupEntity.Code = webElementAction.GetInputElementByDataFormItemNameInDiv("id", context).GetAttribute("value");
                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();
                ValidateInsertedBillingScheduleSetupFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInBillingScheduleSetup()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInBillingScheduleSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "Administration", subMenu: "BillingScheduleSetup", filed: "count");
                validateRequiredFields.Run();
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
                GoToUrl("Administration", "BillingScheduleSetup");
                RefreshRecordDataInGrid("BillingScheduleSetup-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

} // be dalile dastore aghaye delfan dar in senario be dalile unic naboodane item haye grid DetailValidate disabele shod .