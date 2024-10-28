//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;

// define class struct JobComponent
public class JobComponentEntity
{

    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool InActive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___OrderProcessing")]
public class JobComponent : BaseClass
{
    // new struct JobComponentEntity
    private JobComponentEntity _JobComponentEntity;

    public void AddJobComponentFunc()
    {
        GoToUrl("FileMaintenance", "JobComponent");
        _JobComponentEntity = new JobComponentEntity();
        ShowAllRedord();
        // click on btn add in page JobComponent Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page JobComponent Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_JobComponentEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }


    private void ValidateInsertJobComponentFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_JobComponentEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _JobComponentEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(2000);
        CreateValidation(_JobComponentEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddJobComponent()
    {
        TestInitialize(nameof(AddJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddJobComponentFunc();
                ValidateInsertJobComponentFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteJobComponent()
    {
        TestInitialize(nameof(DeleteJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call JobComponent add 
                AddJobComponentFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_JobComponentEntity.Code, "JobComponentList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckJobComponent()
    {
        TestInitialize(nameof(ArrowNextBtnCheckJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "JobComponent");
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
    public void ArrowPreviousBtnCheckJobComponent()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "JobComponent");
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
    public void ArrowFirstBtnCheckJobComponent()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "JobComponent");
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
    public void ArrowLastBtnCheckJobComponent()
    {
        TestInitialize(nameof(ArrowLastBtnCheckJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "JobComponent");
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
    public void EditBtnJobComponent()
    {
        TestInitialize(nameof(EditBtnJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "JobComponent");
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
                _JobComponentEntity = new JobComponentEntity();
                CreateAdd(_JobComponentEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertJobComponentFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void InactiveBtnCheckJobComponent()
    {
        TestInitialize(nameof(InactiveBtnCheckJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "JobComponent");

                InActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ActiveBtnCheckJobComponent()
    {
        TestInitialize(nameof(ActiveBtnCheckJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "JobComponent");

                ActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckJobComponent()
    {
        TestInitialize(nameof(ListViewtBtnCheckJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "JobComponent");
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
    public void CardViewBtnCheckJobComponent()
    {
        TestInitialize(nameof(CardViewBtnCheckJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "JobComponent");
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
    public void DetailValidateJobComponent()
    {
        TestInitialize(nameof(DetailValidateJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddJobComponentFunc();
                ListViewBtnValidate();
                ShowAllRedord();
                var gridList = webElementAction.GetElementById("JobComponentList-gridId");

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                var count = colIds.Count;
                CreateValidationInGrid(colIds, _JobComponentEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInJobComponent()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "JobComponent", filed: "description");
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
                GoToUrl("FileMaintenance", "JobComponent");
                RefreshRecordDataInGrid("JobComponentList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}