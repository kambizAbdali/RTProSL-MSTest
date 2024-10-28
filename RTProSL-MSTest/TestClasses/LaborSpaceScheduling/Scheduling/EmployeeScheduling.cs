//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.LaborSpaceScheduling.Scheduling;

public class EmployeeSchedulingEntity
{

    [ValidationElementProperty("orderNo")]
    public string Order { set; get; }

    [ValidationElementProperty("resourceId")]
    public string Employee { set; get; }

    public string StartDate { set; get; }

    [ValidationElementProperty("startTime")]
    public string BeginTime { set; get; }

    public string EndDate { set; get; }

    [ValidationElementProperty("endTime")]
    public string EndTime { set; get; }

    public string Occupation { set; get; }

    [ValidationDataType(DataType.Color)]
    public string Color { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("allDay")]
    public bool AllDayEvent { set; get; }

    [ValidationDataType(DataType.DropDown)]
    public string BillableType { set; get; }

    [ValidationElementProperty("glAccountId")]
    public string GeneralLedger { set; get; }

    [ValidationElementProperty("rate")]
    public string WeekdayRate { set; get; }

    [ValidationElementProperty("eventOvertimeRate")]
    public string OvertimeRate { set; get; }

    [ValidationElementProperty("weekendRate")]
    public string WeekdayRate2 { set; get; }

    [ValidationElementProperty("eventWeekendOvertimeRate")]
    public string OvertimeRate2 { set; get; }

    [ValidationDataType(DataType.TextArea)]
    public string Notes { set; get; }
}
[TestCategory("LaborSpaceScheduling")]
[TestClass, TestCategory("LaborSpaceScheduling___Scheduling")]
public class EmployeeScheduling : BaseClass
{
    // new struct EmployeeScheduling Entity
    private EmployeeSchedulingEntity _EmployeeSchedulingEntity;

    public void AddEmployeeSchedulingFunc()
    {
        _EmployeeSchedulingEntity = new EmployeeSchedulingEntity();
        {
            GoToUrl("LaborSpaceScheduling", "EmployeeScheduling");
            WaitForLoadingSpiner();
            Thread.Sleep(1000);
        }
        FilterOnBothEmployeeSchedule();
        WaitForLoadingSpiner();

        // click on btn add in page EmployeeScheduling Entry Screen
        webElementAction.GetElementById("TOOL_BOX_ADD_BUTTON_ID").Click();
        GenerateDataToForm();
        CreateAdd(_EmployeeSchedulingEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    //[TestMethod, Timeout(MaximumExecutionTime)]  --This test is not fully developed yet and is not a priority.
    public void AddEmployeeScheduling()
    {
        TestInitialize(nameof(AddEmployeeScheduling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddEmployeeSchedulingFunc();
                ValidateInsertEmployeeScheduling();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    //[TestMethod, Timeout(MaximumExecutionTime)] --This test is not fully developed yet and is not a priority.
    public void EditEmployeeScheduling()
    {
        TestInitialize(nameof(EditEmployeeScheduling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddEmployeeSchedulingFunc();
                Thread.Sleep(3000);
                {
                    GoToUrl("LaborSpaceScheduling", "EmployeeScheduling");
                    WaitForLoadingSpiner();
                    Thread.Sleep(1000);
                }
                //click on btn edit
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();
                GenerateDataToForm();
                CreateAdd(_EmployeeSchedulingEntity); //click on save And Close Btn and check confirm
                SaveAndConfirmCheck();
                ValidateInsertEmployeeScheduling();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    //[TestMethod, Timeout(MaximumExecutionTime)] --This test is not fully developed yet and is not a priority.
    public void DeleteEmployeeScheduling()
    {
        TestInitialize(nameof(DeleteEmployeeScheduling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddEmployeeSchedulingFunc();

                //click on delete btn
                webElementAction.GetElementById("TOOL_BOX_DELETE_BUTTON_ID").Click();
                //confirm delete item
                webElementAction.GetElementByCssSelector("data-button-type = 'confirm'").Click();
                ConfirmBtnCheck();

                ////1 not ok?
                //if (webElementAction.IsElementPresent(
                //        By.CssSelector("//span[.='3469']")))
                //    throw new Exception("The added record has not been deleted.");

                ////2 not ok?
                //if (webElementAction.IsElementPresent(
                //        By.CssSelector("//span[.='" + _EmployeeSchedulingEntity.Production + " or .='" + _EmployeeSchedulingEntity.Order + "']")))
                //    throw new Exception("The added record has not been deleted.");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private static void GenerateDataToForm()
    {
        // context of inputs 
        var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide")
            .FindElements(By.TagName("div")).First();
        var dataFormItemNames = webElementAction.GetAllElementsByTagName("div", context).Where(o =>
            o.GetAttribute("data-form-item-name") != null).ToList();

        // data insert to fields in page DispatchStatusList Entry Screen with random data
        foreach (var item in dataFormItemNames)
            try { new WebElementDataGenerator(item); } catch { }
    }

    private void FilterOnBothEmployeeSchedule()
    {
        OpenFilterWindow();
        var bothScheduleRadioButton = webElementAction.GetElementById("schedule-2");
        bothScheduleRadioButton.Click();

        //click on refresh button
        webElementAction.GetElementBySpecificAttribute("id", "body-filter-refresh-btn").Click();
        WaitForLoadingSpiner();
        ClearAllTagList();
        ConfirmBtnCheck(dataSection: "errorDialog");
    }
    private void ValidateInsertEmployeeScheduling()
    { //click on edit btn
        webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();
        Thread.Sleep(2000);
        CreateValidation(_EmployeeSchedulingEntity);
    }
}