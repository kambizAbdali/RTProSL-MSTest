//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.LaborSpaceScheduling.Table;

// define class strct LBEmployee
public class OccupationEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }

    public string HourlyRate { set; get; }

    public string DailyRate { set; get; }

    public string WeekendHourlyRate { set; get; }

    public string WeekendDailyRate { set; get; }


}






[TestCategory("LaborSpaceScheduling")]
[TestClass, TestCategory("LaborSpaceScheduling___Table")]
public class Occupation : BaseClass
{
    // new struct DepartmentEntity
    private OccupationEntity _OccupationEntity;

    public void AddOccupationFunc()
    {
        GoToUrl("LaborSpaceScheduling", "Occupation");
        // click on btn add in page Department Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        webElementAction.ClearInputValuesInContext(GetFormLeftSideContext());

        // data insert to feilds in page Occupation  Entry Screen whith radnom data
        var webElementDataGenerator = new WebElementDataGenerator(GetFormLeftSideContext());


        _OccupationEntity = new OccupationEntity();

        _OccupationEntity.WeekendDailyRate =
            webElementAction.GetInputElementByDataFormItemNameInDiv("weekendDailyRate").Text;

        //To remove the focus from WeekendDailyRate (if it's currently focused, it doesn't have a percentage symbol), click on the ID.
        webElementAction.GetElementByCssSelector("[name='id']").Click();

        CreateAdd(_OccupationEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }



    private void ValidateInsertOccupationFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_OccupationEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _OccupationEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        WaitForLoadingSpiner();
        CreateValidation(_OccupationEntity);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddOccupation()
    {
        TestInitialize(nameof(AddOccupation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOccupationFunc();
                ValidateInsertOccupationFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteLbOccupation()
    {
        TestInitialize(nameof(DeleteLbOccupation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call LbEmployee add 
                AddOccupationFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_OccupationEntity.Code, "EmployeeOccupationList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckOccupation()
    {
        TestInitialize(nameof(ArrowNextBtnCheckOccupation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Occupation");
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
    public void ArrowPreviousBtnCheckOccupation()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckOccupation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Occupation");
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
    public void ArrowFirstBtnCheckOccupation()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckOccupation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Occupation");
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
    public void ArrowLastBtnCheckOccupation()
    {
        TestInitialize(nameof(ArrowLastBtnCheckOccupation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Occupation");
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
    public void EditBtnOccupation()
    {
        TestInitialize(nameof(EditBtnOccupation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Occupation");
                WaitForLoadingSpiner();

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Occupation Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                //To remove the focus from WeekendDailyRate (if it's currently focused, it doesn't have a percentage symbol), click on the ID.
                webElementAction.GetElementByCssSelector("[name='id']").Click();

                _OccupationEntity = new OccupationEntity();
                CreateAdd(_OccupationEntity);

                //click on save And Close Btn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertOccupationFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckOccupation()
    {
        TestInitialize(nameof(ListViewtBtnCheckOccupation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Occupation");
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
    public void CardViewBtnCheckOccupation()
    {
        TestInitialize(nameof(CardViewBtnCheckOccupation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "Occupation");
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
    public void DetailValidateOccupation()
    {
        TestInitialize(nameof(DetailValidateOccupation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOccupationFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_OccupationEntity.Code.Trim());
                Thread.Sleep(4000);

                var gridList = webElementAction.GetElementById("EmployeeOccupationList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _OccupationEntity.Code.Trim()).Click();

                ChangeScreenPageSize(20);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                CreateValidationInGrid(colIds, _OccupationEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInOccupation()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInOccupation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "LaborSpaceScheduling", subMenu: "Occupation", filed: "description");
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
                GoToUrl("LaborSpaceScheduling", "Occupation");
                RefreshRecordDataInGrid("EmployeeOccupationList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}