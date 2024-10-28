// develop by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.AccountsReceivable.AR;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.Administration.Billing_Schedule;



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

[TestCategory("Administration")]
[TestClass, TestCategory("Administration___BillingSchedule")]

public class BillingScheduleCodes : BaseClass
{
    private BillingScheduleCodesEntity _BillingScheduleCodes;
    public void AddBillingScheduleCodesFunc()
    {
        _BillingScheduleCodes = new BillingScheduleCodesEntity();

        GoToUrl("Administration", "BillingScheduleCodes");

        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_BillingScheduleCodes);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertBillingScheduleCodesFunc()
    {
        SearchTextInMainGrid(_BillingScheduleCodes.Code.Trim());

        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _BillingScheduleCodes.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInsertedDepartment();
        CreateValidation(_BillingScheduleCodes);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddBillingScheduleCodes()
    {
        TestInitialize(nameof(AddBillingScheduleCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddBillingScheduleCodesFunc();
                ValidateInsertBillingScheduleCodesFunc();
                //ValidateInsertedMasterInGridList();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInBillingScheduleCodes()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInBillingScheduleCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "BillingScheduleCodes");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInBillingScheduleCodes()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInBillingScheduleCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "BillingScheduleCodes");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInBillingScheduleCodes()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInBillingScheduleCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "BillingScheduleCodes");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInBillingScheduleCodes()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInBillingScheduleCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "BillingScheduleCodes");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckBillingScheduleCodes()
    {
        TestInitialize(nameof(CardViewBtnCheckBillingScheduleCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "BillingScheduleCodes");
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
    public void ListViewBtnCheckBillingScheduleCodes()
    {
        TestInitialize(nameof(ListViewBtnCheckBillingScheduleCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "BillingScheduleCodes");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBillingSchedule()
    {
        TestInitialize(nameof(EditBillingSchedule));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddBillingScheduleCodesFunc();

                SearchAndEditClick(_BillingScheduleCodes.Code);

                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");
                ClearInputValuesInContext(context);

                Thread.Sleep(1000);

                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_BillingScheduleCodes);

                Thread.Sleep(1000);

                webElementAction.SelectingCheckbox("space");

                SaveAndConfirmCheck();

                Thread.Sleep(1000);

                ValidateInsertBillingScheduleCodesFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
                if (hasError && retryCount == maxRetries) throw new Exception("Test failed: " + ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateScheduleCodes()
    {
        TestInitialize(nameof(DetailValidateScheduleCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddBillingScheduleCodesFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_BillingScheduleCodes.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("BillingScheduleCodes-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _BillingScheduleCodes.Code.Trim()).Click();

                ChangeScreenPageSize(50);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _BillingScheduleCodes);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInBillingScheduleCodes()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInBillingScheduleCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "Administration", subMenu: "BillingScheduleCodes", filed: "description");
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
                GoToUrl("Administration", "BillingScheduleCodes");
                RefreshRecordDataInGrid("BillingScheduleCodes-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}