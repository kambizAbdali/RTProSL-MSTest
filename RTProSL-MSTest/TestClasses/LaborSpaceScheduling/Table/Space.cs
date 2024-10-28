//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.LaborSpaceScheduling.Table;

// define class strct Space
public class SpaceEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }


    [ValidationElementProperty("spaceTypeId")]
    public string SpaceType { set; get; }



    [ValidationElementProperty("locationId")]
    public string Location { set; get; }



    public string HourlyRate { set; get; }

    public string DailyRate { set; get; }


    public string WeeklyRate { set; get; }


    public string WeekendHourlyRate { set; get; }

    public string WeekendDailyRate { set; get; }


    [ValidationElementProperty("glAccountId")]
    public string GLAccount { set; get; }

    [ValidationElementProperty("departmentId")]
    public string Department { set; get; }

    [ValidationElementProperty("categoryId")]
    public string Category { set; get; }


    [ValidationDataType(DataType.Color)]
    public string Color { set; get; }

    public string OvertimeRate { set; get; }

    public string WeekendOvertimeRate { set; get; }

    public string CalculateOvertimeAfterHours { set; get; }

    [ValidationDataType(DataType.TextArea)]
    public string Notes { set; get; }
}

[TestCategory("LaborSpaceScheduling")]
[TestClass, TestCategory("LaborSpaceScheduling___Table")]
public class Space : BaseClass
{
    // new struct DepartmentEntity
    private SpaceEntity _SpaceEntity;
    public void AddSpaceFunc()
    {
        _SpaceEntity = new SpaceEntity();

        GoToUrl("LaborSpaceScheduling", "Space");

        // click on btn add in page Department Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        webElementAction.ClearInputValuesInContext(GetFormLeftSideContext());

        // data insert to feilds in page Occupation  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        _SpaceEntity = new SpaceEntity();

        _SpaceEntity.WeekendDailyRate =
            webElementAction.GetInputElementByDataFormItemNameInDiv("weekendDailyRate").Text;
        CreateAdd(_SpaceEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }



    private void ValidateInsertSpaceFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_SpaceEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _SpaceEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);


        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInsertedDepartment();
        CreateValidation(_SpaceEntity);
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddSpace()
    {
        TestInitialize(nameof(AddSpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpaceFunc();
                ValidateInsertSpaceFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSpace()
    {
        TestInitialize(nameof(DeleteSpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Space add 
                AddSpaceFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_SpaceEntity.Code, "SpaceList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckSpace()
    {
        TestInitialize(nameof(ArrowNextBtnCheckSpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Space");
                ShowAllRedord();
                //call arrow
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckSpace()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckSpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Space");
                ShowAllRedord();
                //call arrow
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckSpace()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckSpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Space");
                ShowAllRedord();
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
    public void ArrowLastBtnCheckSpace()
    {
        TestInitialize(nameof(ArrowLastBtnCheckSpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Space");
                ShowAllRedord();
                //call arrow
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditSpace()
    {
        TestInitialize(nameof(EditSpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Space");
                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Occupation Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);
                _SpaceEntity = new SpaceEntity();

                _SpaceEntity.WeekendDailyRate =
                    webElementAction.GetInputElementByDataFormItemNameInDiv("weekendDailyRate").Text;

                CreateAdd(_SpaceEntity);

                //click on save And Close Btn and check confirm
                SaveAndConfirmCheck();
                ConfirmBtnCheck(confirm: true); //Code will be changed in all files. Continue?
                ValidateInsertSpaceFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckSpace()
    {
        TestInitialize(nameof(ListViewtBtnCheckSpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Space");
                ShowAllRedord();
                //call listViewtBtn
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckSpace()
    {
        TestInitialize(nameof(CardViewBtnCheckSpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Space");
                ShowAllRedord();
                //call card btn
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateSpace()
    {
        TestInitialize(nameof(DetailValidateSpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpaceFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_SpaceEntity.Code.Trim());

                Thread.Sleep(4000);

                var gridList = webElementAction.GetElementById("SpaceList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _SpaceEntity.Code.Trim()).Click();
                WaitForLoadingSpiner();
                ChangeScreenPageSize(50);
                Thread.Sleep(5000);
                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                CreateValidationInGrid(colIds, _SpaceEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInSpace()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "LaborSpaceScheduling", subMenu: "Space", filed: "description");
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
                GoToUrl("LaborSpaceScheduling", "Space");
                RefreshRecordDataInGrid("SpaceList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}
