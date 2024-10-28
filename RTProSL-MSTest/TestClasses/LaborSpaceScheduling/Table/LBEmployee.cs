//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.LaborSpaceScheduling.Table;

// define class strct LBEmployee
public class LBEmployeeEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string FirstName { set; get; }

    public string LastName { set; get; }

    [ValidationElementProperty("employeeId")]
    public string ID { set; get; }

    [ValidationElementProperty("billableRate")]
    public string BillableRate { set; get; }

    [ValidationDataType(DataType.DropDown)]
    [ValidationElementProperty("hourlyDay")]
    public string HourlyDay { set; get; }

    [ValidationElementProperty("occupationId")]
    public string Occupation { set; get; }

    [ValidationIgnoreInGrid]

    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    [ValidationElementProperty("pager")]
    public string Pager { set; get; }

    [ValidationDataType(DataType.Color)]
    [ValidationElementProperty("color")]
    public string ColorCode { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("internal")]
    public bool Internal { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("active")]
    public bool Active { set; get; }

    [ValidationElementProperty("cellPhone")]
    public string CellPhone { set; get; }

    [ValidationElementProperty("addressLine1")]
    public string Address { set; get; }

    [ValidationElementProperty("addressLine2")]
    public string Address2 { set; get; }

    [ValidationElementProperty("addressLine3")]
    public string City { set; get; }

    [ValidationElementProperty("state")]
    public string State { set; get; }

    [ValidationElementProperty("zip")]
    public string Zip { set; get; }

    [ValidationDataType(DataType.TextArea)]
    [ValidationElementProperty("notes")]
    public string Notes { set; get; }

    [ValidationIgnore]
    [ValidationElementProperty("workBeginTime")]
    public string BeginTime { set; get; }

    [ValidationIgnore]
    [ValidationElementProperty("workEndTime")]
    public string EndTime { set; get; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("workDays.sunday")]
    public bool Sunday { set; get; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("workDays.monday")]
    public bool Monday { set; get; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("workDays.tuesday")]
    public bool Tuesday { set; get; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("workDays.wednesday")]
    public bool Wednesday { set; get; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("workDays.thursday")]
    public bool Thursday { set; get; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("workDays.friday")]
    public bool Friday { set; get; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("workDays.saturday")]
    public bool Saturday { set; get; }
}


[TestCategory("LaborSpaceScheduling")]
[TestClass, TestCategory("LaborSpaceScheduling___Table")]
public class LBEmployee : BaseClass
{
    // new struct DepartmentEntity
    private LBEmployeeEntity _LBEmployeeEntity;



    public void AddLbEmployeeFunc()
    {
        GoToUrl("LaborSpaceScheduling", "LBEmployee");
        _LBEmployeeEntity = new LBEmployeeEntity();
        // click on btn add in page Department Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        webElementAction.ClearInputValuesInContext(GetFormLeftSideContext());

        // data insert to feilds in page Department  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_LBEmployeeEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }
    private void ValidateInsertLbEmployeeFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_LBEmployeeEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _LBEmployeeEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        CreateValidation(_LBEmployeeEntity);
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddLbEmployee()
    {
        TestInitialize(nameof(AddLbEmployee));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddLbEmployeeFunc();
                ValidateInsertLbEmployeeFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteLbEmployee()
    {
        TestInitialize(nameof(DeleteLbEmployee));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call LbEmployee add 
                AddLbEmployeeFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_LBEmployeeEntity.Code, "EmployeeList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckLBEmployee()
    {
        TestInitialize(nameof(ArrowNextBtnCheckLBEmployee));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // navigate 
                GoToUrl("LaborSpaceScheduling", "LBEmployee");
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
    public void ArrowPreviousBtnCheckLbEmployee()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckLbEmployee));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to GoTo LbEmployee Func page 
                GoToUrl("LaborSpaceScheduling", "LBEmployee");
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
    public void ArrowFirstBtnCheckLbEmployee()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckLbEmployee));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to GoTo LbEmployeeFunc page 
                GoToUrl("LaborSpaceScheduling", "LBEmployee");
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
    public void ArrowLastBtnCheckLbEmployee()
    {
        TestInitialize(nameof(ArrowLastBtnCheckLbEmployee));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to LbEmployee page 
                GoToUrl("LaborSpaceScheduling", "LBEmployee");
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
    public void EditBtnLbEmployee()
    {
        TestInitialize(nameof(EditBtnLbEmployee));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to department page 
                GoToUrl("LaborSpaceScheduling", "LBEmployee");

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page LbEmployee Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);
                _LBEmployeeEntity = new LBEmployeeEntity();
                CreateAdd(_LBEmployeeEntity);

                //click on save And Close Btn and check confirm
                SaveAndConfirmCheck();
                ConfirmBtnCheck(); // Code will be changed in all files. Continue?
                ValidateInsertLbEmployeeFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckLbEmployee()
    {
        TestInitialize(nameof(ListViewtBtnCheckLbEmployee));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to LbEmployee page 
                GoToUrl("LaborSpaceScheduling", "LBEmployee");
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
    public void ThumbnailViewBtnCheckLbEmployee()
    {
        TestInitialize(nameof(ThumbnailViewBtnCheckLbEmployee));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to LbEmployee page 
                GoToUrl("LaborSpaceScheduling", "LBEmployee");

                //call thumbnailViewBtn 
                ThumbnailViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckLbEmployee()
    {
        TestInitialize(nameof(CardViewBtnCheckLbEmployee));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to LbEmployee page 
                GoToUrl("LaborSpaceScheduling", "LBEmployee");
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
    public void DetailValidateLbEmployee()
    {
        TestInitialize(nameof(DetailValidateLbEmployee));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddLbEmployeeFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_LBEmployeeEntity.Code.Trim());
                Thread.Sleep(4000);

                var gridList = webElementAction.GetElementById("EmployeeList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _LBEmployeeEntity.Code.Trim()).Click();

                ChangeScreenPageSize(60);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                CreateValidationInGrid(colIds, _LBEmployeeEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInOrderManualStatus()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInOrderManualStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "LaborSpaceScheduling", subMenu: "LBEmployee", filed: "firstName");
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
                GoToUrl("LaborSpaceScheduling", "LBEmployee");
                RefreshRecordDataInGrid("EmployeeList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}
