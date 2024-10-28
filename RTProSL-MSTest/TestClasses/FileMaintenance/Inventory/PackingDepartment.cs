using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class PackingDepartment : BaseClass //   developed by kambiz Abdali
{
    private PackingDepartmentEntity _packingDepartmentEntity;

    public class PackingDepartmentEntity
    {
        [ValidationIgnore]
        [ValidationElementProperty("id")]
        public string Code { set; get; } //

        public string Description { set; get; } //

        [ValidationDataType(DataType.CheckBox)]
        [ValidationElementProperty("inactive")]
        public bool Inactive { set; get; }
    }

    public void ValidateInsertedPackingDepartmentFunc()
    {
        ShowAllRedord();
        Thread.Sleep(2000);

        SearchTextInMainGrid(_packingDepartmentEntity.Code);

        Thread.Sleep(2000);

        var selectRow = ObjectRepository.Driver
            .FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _packingDepartmentEntity.Code.Trim());
        Thread.Sleep(2000);
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);
        CreateValidation(_packingDepartmentEntity);
    }
    public void AddDepartmentPageFunc()
    {
        GoToUrl("FileMaintenance", "PackingDepartment");
        _packingDepartmentEntity = new PackingDepartmentEntity();

        // click on btn add in page Rental Agent Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page Rental Agent Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_packingDepartmentEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInPackingDepartment()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInPackingDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PackingDepartment");
                if (!HasRowCheck()) { testPassed = true; break;} 
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
                if (hasDialogBox)
                    break;
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInPackingDepartment()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInPackingDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PackingDepartment");
                if (!HasRowCheck()) { testPassed = true; break;} 
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInPackingDepartment()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInPackingDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PackingDepartment");
                if (!HasRowCheck()) { testPassed = true; break;} 
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInPackingDepartment()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInPackingDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PackingDepartment");
                if (!HasRowCheck()) { testPassed = true; break;} 
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInPackingDepartment()
    {
        TestInitialize(nameof(ListViewBtnCheckInPackingDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PackingDepartment");
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInPackingDepartment()
    {
        TestInitialize(nameof(CardViewBtnCheckInPackingDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PackingDepartment");
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
    public void AddPackingDepartment()
    {
        TestInitialize(nameof(AddPackingDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddDepartmentPageFunc();
                ValidateInsertedPackingDepartmentFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidatePackingDepartment()
    {
        TestInitialize(nameof(DetailValidatePackingDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddDepartmentPageFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_packingDepartmentEntity.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("PackingDepartmentList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _packingDepartmentEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _packingDepartmentEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)] // no data for edit button edit is disable
    public void EditPackingDepartment()
    {
        TestInitialize(nameof(DetailValidatePackingDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _packingDepartmentEntity = new PackingDepartmentEntity();
                //navigate to Salesperson page 

                GoToUrl("FileMaintenance", "PackingDepartment");

                Thread.Sleep(3000);

                ShowAllRedord();
                // click on btn edit 
                var editUserBtn = webElementAction.GetElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID");
                editUserBtn.Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Partner Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_packingDepartmentEntity);
                //click on saveAndCloseBtn inAddUserSection

                CheckErrorDialogBox();
                SaveAndConfirmCheck();

                Thread.Sleep(1000);
                ValidateInsertedPackingDepartmentFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeletePackingDepartment()
    {
        TestInitialize(nameof(DeletePackingDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Contact add 
                AddDepartmentPageFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_packingDepartmentEntity.Code, "PackingDepartmentList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInPackingDepartment()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInPackingDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "PackingDepartment", filed: "description");
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
                GoToUrl("FileMaintenance", "PackingDepartment");
                RefreshRecordDataInGrid("PackingDepartmentList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}