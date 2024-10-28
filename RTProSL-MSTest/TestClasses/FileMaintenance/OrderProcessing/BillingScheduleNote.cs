//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;

// define class struct BillingScheduleNoteList
public class BillingScheduleNoteListEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    [ValidationDataType(DataType.TextArea)]
    public string Description { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___OrderProcessing")]
public class BillingScheduleNoteList : BaseClass
{
    // new struct BillingScheduleNoteList Entity
    private BillingScheduleNoteListEntity _BillingScheduleNoteListEntity;

    public void AddBillingScheduleNoteListFunc()
    {
        GoToUrl("FileMaintenance", "BillingScheduleNote");
        _BillingScheduleNoteListEntity = new BillingScheduleNoteListEntity();

        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page BillingScheduleNoteList  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_BillingScheduleNoteListEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertBillingScheduleNoteListFunc()
    {
        SearchTextInMainGrid(_BillingScheduleNoteListEntity.Code.Trim());

        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _BillingScheduleNoteListEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        //Validate Inserted BillingScheduleNoteList();
        CreateValidation(_BillingScheduleNoteListEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddBillingScheduleNoteListType()
    {
        TestInitialize(nameof(AddBillingScheduleNoteListType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddBillingScheduleNoteListFunc();
                ValidateInsertBillingScheduleNoteListFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteBillingScheduleNoteList()
    {
        TestInitialize(nameof(DeleteBillingScheduleNoteList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call BillingScheduleNoteList add 
                AddBillingScheduleNoteListFunc();
                //ShowAllRedord();
                // call delete method from base class 
                Delete(_BillingScheduleNoteListEntity.Code, "BillingScheduleNoteList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckBillingScheduleNoteList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckBillingScheduleNoteList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingScheduleNote");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckBillingScheduleNoteList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckBillingScheduleNoteList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingScheduleNote");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckBillingScheduleNoteList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckBillingScheduleNoteList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingScheduleNote");
                //call method arrowFirstBtn
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckBillingScheduleNoteList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckBillingScheduleNoteList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingScheduleNote");

                //ShowAllRedord();
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBtnBillingScheduleNoteListType()
    {
        TestInitialize(nameof(EditBtnBillingScheduleNoteListType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingScheduleNote");

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);
                _BillingScheduleNoteListEntity = new BillingScheduleNoteListEntity();
                CreateAdd(_BillingScheduleNoteListEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertBillingScheduleNoteListFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckBillingScheduleNoteList()
    {
        TestInitialize(nameof(ListViewtBtnCheckBillingScheduleNoteList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingScheduleNote");
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckBillingScheduleNoteList()
    {
        TestInitialize(nameof(CardViewBtnCheckBillingScheduleNoteList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingScheduleNote");

                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateBillingScheduleNote()
    {
        TestInitialize(nameof(DetailValidateBillingScheduleNote));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddBillingScheduleNoteListFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_BillingScheduleNoteListEntity.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("BillingScheduleNoteList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _BillingScheduleNoteListEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _BillingScheduleNoteListEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxBillingScheduleNote()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxBillingScheduleNote));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "BillingScheduleNote", filed: "description");
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
                GoToUrl("FileMaintenance", "BillingScheduleNote");
                RefreshRecordDataInGrid("BillingScheduleNoteList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}