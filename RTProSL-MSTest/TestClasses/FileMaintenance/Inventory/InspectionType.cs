// develop by Mohammad_Keshavarz

// Prerequisite: The "Use Equipment Inspection" option must be checked in the system setup.

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

public class InspectionTypeEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }


    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("promptRCD")]
    public bool PromptRCD { set; get; }


    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("notesRequired")]
    public bool RequireNotes { set; get; }


    [ValidationDataType(DataType.TextArea)]
    [ValidationElementProperty("notes")]
    public string Notes { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class InspectionType : BaseClass
{
    private InspectionTypeEntity _InspectionTypeEntity;

    public void AddInspectionTypeFunc()
    {
        GoToUrl("FileMaintenance", "InspectionType");
        _InspectionTypeEntity = new InspectionTypeEntity();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_InspectionTypeEntity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }


    private void ValidateInsertInspectionTypeFunc()
    {
        SearchTextInMainGrid(_InspectionTypeEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _InspectionTypeEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        CreateValidation(_InspectionTypeEntity);
        //ValidateInsertedMasterInGridList();
    }

    // Prerequisite: The "Use Equipment Inspection" option must be checked in the system setup.
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddInspectionType()
    {
        TestInitialize(nameof(AddInspectionType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddInspectionTypeFunc();
                ValidateInsertInspectionTypeFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditInspectionType()
    {
        TestInitialize(nameof(EditInspectionType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to InspectionType page 
                GoToUrl("FileMaintenance", "InspectionType");
                _InspectionTypeEntity = new InspectionTypeEntity();
                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_InspectionTypeEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertInspectionTypeFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateInspectionType()
    {
        TestInitialize(nameof(DetailValidateInspectionType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddInspectionTypeFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_InspectionTypeEntity.Code.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("InspectionTypeList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _InspectionTypeEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _InspectionTypeEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteInspectionType()
    {
        TestInitialize(nameof(DeleteInspectionType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call InspectionType add 
                AddInspectionTypeFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_InspectionTypeEntity.Code, "InspectionTypeList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInInspectionType()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInInspectionType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "InspectionType");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInInspectionType()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInInspectionType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "InspectionType");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInInspectionType()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInInspectionType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "InspectionType");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);


            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInInspectionType()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInInspectionType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "InspectionType");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInInspectionType()
    {
        TestInitialize(nameof(CardViewBtnCheckInInspectionType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "InspectionType");
                if (!HasRowCheck()) { testPassed = true; break;} 
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInInspectionType()
    {
        TestInitialize(nameof(ListViewBtnCheckInInspectionType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "InspectionType");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInInspectionType()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInInspectionType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "InspectionType", filed: "description");
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
                GoToUrl("FileMaintenance", "InspectionType");
                RefreshRecordDataInGrid("InspectionTypeList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}