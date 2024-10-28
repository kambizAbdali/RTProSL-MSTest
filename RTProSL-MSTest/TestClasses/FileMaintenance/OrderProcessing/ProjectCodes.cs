//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;

// define class struct ProjectCodes
public class ProjectCodesEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }


    public string StartDate { set; get; }


    public string Description { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool InActive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___OrderProcessing")]
public class ProjectCodes : BaseClass
{
    // new struct ProjectCodes Entity
    private ProjectCodesEntity _ProjectCodesEntity;

    public void AddProjectCodesFunc()
    {
        GoToUrl("FileMaintenance", "ProjectCodes");
        _ProjectCodesEntity = new ProjectCodesEntity();

        // click on btn add in page ProjectCodes Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page ProjectCodes  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_ProjectCodesEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertProjectCodesFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_ProjectCodesEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _ProjectCodesEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        //Validate Inserted ProjectCodes();
        CreateValidation(_ProjectCodesEntity);
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddProjectCodesType()
    {
        TestInitialize(nameof(AddProjectCodesType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddProjectCodesFunc();
                ValidateInsertProjectCodesFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteProjectCodesType()
    {
        TestInitialize(nameof(DeleteProjectCodesType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call ProjectCodes add 
                AddProjectCodesFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_ProjectCodesEntity.Code, "ProjectCodesList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckProjectCodes()
    {
        TestInitialize(nameof(ArrowNextBtnCheckProjectCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ProjectCodes");
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
    public void ArrowPreviousBtnCheckProjectCodes()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckProjectCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ProjectCodes");
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
    public void ArrowFirstBtnCheckProjectCodes()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckProjectCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ProjectCodes");
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
    public void ArrowLastBtnCheckProjectCodes()
    {
        TestInitialize(nameof(ArrowLastBtnCheckProjectCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ProjectCodes");
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
    public void EditBtnProjectCodes()
    {
        TestInitialize(nameof(EditBtnProjectCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ProjectCodes");
                _ProjectCodesEntity = new ProjectCodesEntity();

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_ProjectCodesEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertProjectCodesFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void InactiveBtnCheckProjectCodesType()
    {
        TestInitialize(nameof(InactiveBtnCheckProjectCodesType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ProjectCodes");

                InActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ActiveBtnCheckProjectCodesType()
    {
        TestInitialize(nameof(ActiveBtnCheckProjectCodesType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ProjectCodes");

                ActiveBtnCheck();

                testPassed = true;

            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckProjectCodesType()
    {
        TestInitialize(nameof(ListViewtBtnCheckProjectCodesType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ProjectCodes");
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
    public void CardViewBtnCheckProjectCodes()
    {
        TestInitialize(nameof(CardViewBtnCheckProjectCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ProjectCodes");
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
    public void DetailValidateProjectCodes()
    {
        TestInitialize(nameof(DetailValidateProjectCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddProjectCodesFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_ProjectCodesEntity.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("ProjectCodesList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _ProjectCodesEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _ProjectCodesEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInProjectCodes()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInProjectCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "ProjectCodes", filed: "description");

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
                GoToUrl("FileMaintenance", "ProjectCodes");
                RefreshRecordDataInGrid("ProjectCodesList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}
