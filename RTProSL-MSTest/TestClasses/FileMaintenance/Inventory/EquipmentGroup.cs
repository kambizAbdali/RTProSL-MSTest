// develop by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

public class EquipmentGroupEntity
{
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class EquipmentGroup : BaseClass
{
    private EquipmentGroupEntity _EquipmentGroupEntity;

    public void AddEquipmentGroupFunc()
    {
        _EquipmentGroupEntity = new EquipmentGroupEntity();
        GoToUrl("FileMaintenance", "EquipmentGroup");
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_EquipmentGroupEntity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertEquipmentGroupFunc()
    {
        SearchTextInMainGrid(_EquipmentGroupEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _EquipmentGroupEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        CreateValidation(_EquipmentGroupEntity);
        //ValidateInsertedMasterInGridList();
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddEquipmentGroup()
    {
        TestInitialize(nameof(AddEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddEquipmentGroupFunc();
                ValidateInsertEquipmentGroupFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditEquipmentGroup()
    {
        TestInitialize(nameof(EditEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _EquipmentGroupEntity = new EquipmentGroupEntity();
                GoToUrl("FileMaintenance", "EquipmentGroup");

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_EquipmentGroupEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertEquipmentGroupFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInEquipmentGroup()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "EquipmentGroup");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInEquipmentGroup()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "EquipmentGroup");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInEquipmentGroup()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "EquipmentGroup");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInEquipmentGroup()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "EquipmentGroup");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInEquipmentGroup()
    {
        TestInitialize(nameof(CardViewBtnCheckInEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "EquipmentGroup");
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
    public void ListViewBtnCheckInEquipmentGroup()
    {
        TestInitialize(nameof(ListViewBtnCheckInEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "EquipmentGroup");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateEquipmentGroup()
    {
        TestInitialize(nameof(DetailValidateEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddEquipmentGroupFunc();
                ListViewBtnValidate();

                SearchTextInMainGrid(_EquipmentGroupEntity.Code.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("EquipmentGroupList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _EquipmentGroupEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _EquipmentGroupEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteEquipmentGroup()
    {
        TestInitialize(nameof(DeleteEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call
                //
                //
                //
                //
                //
                //
                //
                //add 
                AddEquipmentGroupFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_EquipmentGroupEntity.Code, "EquipmentGroupList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInEquipmentGroup()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "EquipmentGroup", filed: "description");
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
                GoToUrl("FileMaintenance", "EquipmentGroup");
                RefreshRecordDataInGrid("EquipmentGroupList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}