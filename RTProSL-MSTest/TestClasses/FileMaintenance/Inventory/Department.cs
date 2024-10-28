//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

// System-Setup:  Use Department and Category for Adding Rental Inventory
// define class strct depertment
public class DepartmentEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string SortOrder { set; get; }
    public string Description { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnWebsite")]
    public bool ShowonWebsite { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool InActive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class Department : BaseClass
{
    // new struct DepartmentEntity
    private DepartmentEntity _DepartmentEntity;


    public void AddDepartmentFunc()
    {
        GoToUrl("FileMaintenance", "Department");

        ListViewBtnValidate();

        // click on btn add in page Department Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page Department  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());
        _DepartmentEntity = new DepartmentEntity();
        CreateAdd(_DepartmentEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
        //canceldialogBtn.Click();
        webElementAction.GetElementBySpecificAttribute("data-button-type", "cancel").Click();
    }

    public void AddDepartmentWhitaddUserFunc()
    {
        GoToUrl("FileMaintenance", "Department");
        ShowAllRedord();
        // click on btn add in page Department Entry Screen
        webElementAction.GetElementById("TOOL_BOX_ADD_BUTTON_ID").Click();

        // context of inputs 
        var context =
            ObjectRepository.Driver.FindElement(
                By.XPath("//*[@id=\"FullScreenDetailContainer\"]/div[3]/div[2]/form/div/div[1]"));
        // genarated data 
        var webElementDataGenerator = new WebElementDataGenerator(context);
        _DepartmentEntity = new DepartmentEntity();
        CreateAdd(_DepartmentEntity);


        // click on btn save and close in page Department  Entry Screen
        SaveAndConfirmCheck();
        CheckErrorDialogBox();

        //confirm dialogBtn.Click();
        webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm").Click();
    }

    private void ValidateInsertDepartmentFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_DepartmentEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _DepartmentEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInsertedDepartment();
        CreateValidation(_DepartmentEntity);
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddDepartment()
    {
        TestInitialize(nameof(AddDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddDepartmentFunc();
                ValidateInsertDepartmentFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddDepartmentWhitAddUserDepartment()
    {
        TestInitialize(nameof(AddDepartmentWhitAddUserDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddDepartmentWhitaddUserFunc();
                ShowAllRedord();

                SearchTextInMainGrid(_DepartmentEntity.Code.Trim());

                Thread.Sleep(700);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _DepartmentEntity.Code.Trim());
                webElementAction.DoubleClick(selectRow);

                Thread.Sleep(500);

                //click on edit btn
                var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
                editUserBtn.Click();
                Thread.Sleep(3000);

                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                CreateValidation(_DepartmentEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteDepartment()
    {
        TestInitialize(nameof(DeleteDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call department add 
                AddDepartmentFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_DepartmentEntity.Code, "DepartmentList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckDepartment()
    {
        TestInitialize(nameof(ArrowNextBtnCheckDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Department");
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
    public void ArrowPreviousBtnCheckDepartment()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to department page 
                GoToUrl("FileMaintenance", "Department");
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
    public void ArrowFirstBtnCheckDepartment()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to department page 
                GoToUrl("FileMaintenance", "Department");
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
    public void ArrowLastBtnCheckDepartment()
    {
        TestInitialize(nameof(ArrowLastBtnCheckDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to department page 
                GoToUrl("FileMaintenance", "Department");
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
    public void EditBtnDepartment()
    {
        TestInitialize(nameof(EditBtnDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to department page 
                GoToUrl("FileMaintenance", "Department");

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);
                _DepartmentEntity = new DepartmentEntity();
                CreateAdd(_DepartmentEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertDepartmentFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void InActiveBtnCheckDepartment()
    {
        TestInitialize(nameof(InActiveBtnCheckDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to department page 
                GoToUrl("FileMaintenance", "Department");

                InActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ActiveBtnCheckDepartment()
    {
        TestInitialize(nameof(ActiveBtnCheckDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to department page 
                GoToUrl("FileMaintenance", "Department");
                ActiveBtnCheck();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckDepartment()
    {
        TestInitialize(nameof(ListViewtBtnCheckDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to department page 
                GoToUrl("FileMaintenance", "Department");
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
    public void ThumbnailViewBtnCheckDepartment()
    {
        TestInitialize(nameof(ThumbnailViewBtnCheckDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to department page 
                GoToUrl("FileMaintenance", "Department");
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
    public void CardViewBtnCheckDepartment()
    {
        TestInitialize(nameof(CardViewBtnCheckDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to department page 
                GoToUrl("FileMaintenance", "Department");
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
    public void DetailValidateDepartment()
    {
        TestInitialize(nameof(DetailValidateDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddDepartmentFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_DepartmentEntity.Code.Trim());
                Thread.Sleep(4000);

                var gridList = webElementAction.GetElementById("DepartmentList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _DepartmentEntity.Code.Trim()).Click();

                ChangeScreenPageSize(20);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                // _DepartmentEntity.SortOrder = webElementAction.FormatNumberWithCommas(_DepartmentEntity.SortOrder);
                CreateValidationInGrid(colIds, _DepartmentEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInDepartment()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "Department", filed: "description");
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
                GoToUrl("FileMaintenance", "Department");
                RefreshRecordDataInGrid("DepartmentList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}
