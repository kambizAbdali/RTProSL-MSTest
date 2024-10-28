// develop by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
using WindowsInput;
using WindowsInput.Native;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

public class RetiredReasonEntity
{
    [ValidationElementProperty("id")] public string Code { set; get; }


    public string Description { set; get; }


    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool Inactive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class RetiredReason : BaseClass
{
    private RetiredReasonEntity _RetiredReasonEntity;


    public void AddRetiredReasonFunc()
    {
        GoToUrl("FileMaintenance", "RetiredReason");
        _RetiredReasonEntity = new RetiredReasonEntity();

        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_RetiredReasonEntity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }


    private void ValidateInsertRetiredReasonFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_RetiredReasonEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _RetiredReasonEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        CreateValidation(_RetiredReasonEntity);
        //ValidateInsertedMasterInGridList();
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddRetiredReason()
    {
        TestInitialize(nameof(AddRetiredReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddRetiredReasonFunc();
                ValidateInsertRetiredReasonFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditRetiredReason()
    {
        TestInitialize(nameof(EditRetiredReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RetiredReason");
                _RetiredReasonEntity = new RetiredReasonEntity();
                ShowAllRedord();
                WaitForLoadingSpiner();

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();


                var codeElement = webElementAction.GetInputElementByDataFormItemNameInDiv("id");
                var oldCode = codeElement.GetAttribute("value");

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_RetiredReasonEntity);

                var inputSimulator = new InputSimulator();

                codeElement.Click();

                // Simulate pressing the key for each character
                inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BACK);

                codeElement.SendKeys(oldCode);

                _RetiredReasonEntity.Code = oldCode;
                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertRetiredReasonFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateRetiredReason()
    {
        TestInitialize(nameof(DetailValidateRetiredReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddRetiredReasonFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_RetiredReasonEntity.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("RetiredReasonList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _RetiredReasonEntity.Code.Trim()).Click();

                ChangeScreenPageSize(40);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _RetiredReasonEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteRetiredReason()
    {
        TestInitialize(nameof(DeleteRetiredReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call RetiredReason add 
                AddRetiredReasonFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_RetiredReasonEntity.Code, "RetiredReasonList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInRetiredReason()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInRetiredReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RetiredReason");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInRetiredReason()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInRetiredReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RetiredReason");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInRetiredReason()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInRetiredReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RetiredReason");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInRetiredReason()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInRetiredReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RetiredReason");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInRetiredReason()
    {
        TestInitialize(nameof(CardViewBtnCheckInRetiredReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RetiredReason");
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
    public void ListViewBtnCheckInRetiredReason()
    {
        TestInitialize(nameof(ListViewBtnCheckInRetiredReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RetiredReason");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInRetiredReason()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInRetiredReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "RetiredReason", filed: "description");
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
                GoToUrl("FileMaintenance", "RetiredReason");
                RefreshRecordDataInGrid("RetiredReasonList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}