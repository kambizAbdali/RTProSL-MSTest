//developed by Parsa_Zakeri
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace RTProSL_MSTest.TestClasses.LaborSpaceScheduling.Scheduling;

// define class strct EmployeeScheduling
public class SpaceSchedulingEntity
{
    [ValidationElementProperty("productionId")]
    public string Production { set; get; }

    [ValidationElementProperty("orderNo")]
    public string Order { set; get; }

    [ValidationElementProperty("jobTitle")]
    public string ProductionTitle { set; get; }

    [ValidationElementProperty("resourceId")]
    public string Space { set; get; }

    [ValidationElementProperty("holdStatusId")]
    public string SpaceHoldStatus { set; get; }

    [ValidationDataType(DataType.Color)]
    public string Color { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("allDay")]
    public bool AllDayEvent { set; get; }

    [ValidationElementProperty("startDate")]
    public string StartDTrans { set; get; }

    [ValidationElementProperty("startTime")]
    public string BeginTime { set; get; }

    [ValidationElementProperty("endDate")]
    public string EndDTrans { set; get; }

    [ValidationElementProperty("endTime")]
    public string EndTime { set; get; }

    [ValidationElementProperty("billableType")]
    [ValidationDataType(DataType.CheckBox)]
    public string BillableType { set; get; }

    [ValidationElementProperty("glAccountId")]
    public string GeneralLedger { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    public bool Billable { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("durationLabel")]
    public bool Taxable { set; get; }

    [ValidationDataType(DataType.TextArea)]
    public string Notes { set; get; }
}
[TestCategory("LaborSpaceScheduling")]
[TestClass, TestCategory("LaborSpaceScheduling___Scheduling")]
public class SpaceSchedulingGantt : BaseClass
{   // new struct SpaceScheduling Entity 
    private SpaceSchedulingEntity _SpaceSchedulingEntity;

    public void AddSpaceSchedulingFunc()
    {
        _SpaceSchedulingEntity = new SpaceSchedulingEntity();
        {
            GoToUrl("LaborSpaceScheduling", "SpaceScheduling");
            Thread.Sleep(2000);
        }
        FilterOnBothSchedule();
        // click on btn add in page SpaceScheduling Entry Screen
        webElementAction.GetElementById("TOOL_BOX_ADD_BUTTON_ID").Click();
        GenerateDataToForm();
        Thread.Sleep(3000);
        CreateAdd(_SpaceSchedulingEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
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
        {
            var startDate = webElementAction.GetAllElementBySpecificAttribute("data-form-item-name", "startDate").Last().FindElement(By.TagName("input"));
            startDate.Click(); startDate.Clear(); startDate.SendKeys(DateTime.Now.ToString("M/d/yyyy"));
            var endDate = webElementAction.GetAllElementBySpecificAttribute("data-form-item-name", "endDate").Last().FindElement(By.TagName("input"));
            endDate.Click(); endDate.Clear(); endDate.SendKeys(DateTime.Now.AddDays(5).ToString("M/d/yyyy"));
        }
    }

    private void FilterOnBothSchedule()
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

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddSpaceScheduling()
    {
        TestInitialize(nameof(AddSpaceScheduling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpaceSchedulingFunc();
                ValidateInsertSpaceScheduling();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime * 2)]
    public void EditBtnSpaceScheduling()
    {
        TestInitialize(nameof(EditBtnSpaceScheduling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpaceSchedulingFunc(); // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();
                GenerateDataToForm();
                CreateAdd(_SpaceSchedulingEntity);
                SaveAndConfirmCheck();//click on save And Close Btn and check confirm
                ValidateInsertSpaceScheduling();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    private void ValidateInsertSpaceScheduling()
    { //click on edit btn
        webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();
        Thread.Sleep(2000);
        CreateValidation(_SpaceSchedulingEntity);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSpaceScheduling()
    {
        TestInitialize(nameof(DeleteSpaceScheduling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpaceSchedulingFunc();
                {
                    webElementAction.Click(By.Id("TOOL_BOX_DELETE_BUTTON_ID"));//click on delete btn
                    ConfirmBtnCheck();
                }
                var elements = webElementAction.GetElementBySpecificAttribute("data-resource-id", _SpaceSchedulingEntity.Space.Trim())
                    .FindElements(By.TagName("i"));

                bool productionExists = elements.Any(o => o.GetAttribute("span") == _SpaceSchedulingEntity.Production.Trim());
                bool orderExists = elements.Any(o => o.GetAttribute("span") == _SpaceSchedulingEntity.Order.Trim());

                if (productionExists || orderExists)
                    throw new Exception("The added record has not been deleted.");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}