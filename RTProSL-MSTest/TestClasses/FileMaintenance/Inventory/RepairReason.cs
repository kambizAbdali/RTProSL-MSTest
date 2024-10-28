using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class RepairReason : BaseClass //   developed by kambiz Abdali
{
    private RepairReasonEntity _RepairReasonEntity;

    public class RepairReasonEntity
    {
        [ValidationIgnore]
        [ValidationElementProperty("id")]
        public string Code { set; get; } //

        public string Description { set; get; } //

        [ValidationElementProperty("inactive")]
        public bool Inactive { set; get; } //
    }
    private void ValidateInsertedRepairReasonFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_RepairReasonEntity.Code.Trim());

        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _RepairReasonEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        //moghayese
        CreateValidation(_RepairReasonEntity);
    }

    private void AddRepairReasonFunc()
    {
        GoToUrl("FileMaintenance", "RepairReason");
        _RepairReasonEntity = new RepairReasonEntity();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_RepairReasonEntity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInRepairReason()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInRepairReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RepairReason");
                _RepairReasonEntity = new RepairReasonEntity();
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
    public void ArrowPreviousBtnCheckInRepairReason()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInRepairReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RepairReason");
                _RepairReasonEntity = new RepairReasonEntity();
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
    public void ArrowLastBtnCheckInRepairReason()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInRepairReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RepairReason");
                _RepairReasonEntity = new RepairReasonEntity();
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
    public void ArrowFirstBtnCheckInRepairReason()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInRepairReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RepairReason");
                _RepairReasonEntity = new RepairReasonEntity();
                if (!HasRowCheck()) { testPassed = true; break; }
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInRepairReason()
    {
        TestInitialize(nameof(ListViewBtnCheckInRepairReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RepairReason");
                _RepairReasonEntity = new RepairReasonEntity();
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInRepairReason()
    {
        TestInitialize(nameof(CardViewBtnCheckInRepairReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RepairReason");
                _RepairReasonEntity = new RepairReasonEntity();
                if (!HasRowCheck()) { testPassed = true; break; }
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddRepairReasonWithAllFields()
    {
        TestInitialize(nameof(AddRepairReasonWithAllFields));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddRepairReasonFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditRepairReason()
    {
        TestInitialize(nameof(EditRepairReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RepairReason");
                _RepairReasonEntity = new RepairReasonEntity();

                Thread.Sleep(3000);

                ShowAllRedord();

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_RepairReasonEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertedRepairReasonFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateRepairReason()
    {
        TestInitialize(nameof(DetailValidateRepairReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddRepairReasonFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_RepairReasonEntity.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("RepairReasonList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _RepairReasonEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _RepairReasonEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteRepairReason()
    {
        TestInitialize(nameof(DeleteRepairReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call RepairReason add 
                AddRepairReasonFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_RepairReasonEntity.Code, "RepairReasonList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInRepairReason()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInRepairReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "RepairReason", filed: "description");
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
                GoToUrl("FileMaintenance", "RepairReason");
                RefreshRecordDataInGrid("RepairReasonList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}