// develop by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

public class PiEquipmentGroupEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    [ValidationElementProperty("timesPerYear")]
    public string TimesPerYear { set; get; }
    public string Description { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class PiEquipmentGroup : BaseClass
{
    private PiEquipmentGroupEntity _PIEquipmentGroupEntity;

    public void AddPiEquipmentGroupFunc()
    {
        GoToUrl("FileMaintenance", "PIEquipmentGroup");

        //click on addNewRecordBtn
        webElementAction.ClickOnAddNewRecord();
        new WebElementDataGenerator(GetFormLeftSideContext());
        _PIEquipmentGroupEntity = new PiEquipmentGroupEntity();
        CreateAdd(_PIEquipmentGroupEntity);
        Thread.Sleep(1000);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertPIEquipmentGroupFunc()
    {
        SearchAndEditClick(_PIEquipmentGroupEntity.Code.Trim());
        CreateValidation(_PIEquipmentGroupEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddPiEquipmentGroup()
    {
        TestInitialize(nameof(AddPiEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPiEquipmentGroupFunc();
                ValidateInsertPIEquipmentGroupFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditPiEquipmentGroup()
    {
        TestInitialize(nameof(EditPiEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PIEquipmentGroup");
                _PIEquipmentGroupEntity = new PiEquipmentGroupEntity();

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_PIEquipmentGroupEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertPIEquipmentGroupFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidatePIEquipmentGroup()
    {
        TestInitialize(nameof(DetailValidatePIEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPiEquipmentGroupFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_PIEquipmentGroupEntity.Code.Trim());

                Thread.Sleep(2000);

                var gridList = webElementAction.GetElementById("PiEquipmentGroupList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _PIEquipmentGroupEntity.Code.Trim()).Click();
                Thread.Sleep(1500);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _PIEquipmentGroupEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeletePiEquipmentGroup()
    {
        TestInitialize(nameof(DeletePiEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Contact add 
                AddPiEquipmentGroupFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_PIEquipmentGroupEntity.Code, "PiEquipmentGroupList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInPIEquipmentGroup()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInPIEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PIEquipmentGroup");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInPIEquipmentGroup()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInPIEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PIEquipmentGroup");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInPIEquipmentGroup()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInPIEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PIEquipmentGroup");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInPIEquipmentGroup()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInPIEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PIEquipmentGroup");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInPIEquipmentGroup()
    {
        TestInitialize(nameof(CardViewBtnCheckInPIEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PIEquipmentGroup");
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
    public void ListViewBtnCheckInPIEquipmentGroup()
    {
        TestInitialize(nameof(ListViewBtnCheckInPIEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PIEquipmentGroup");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInPIEquipmentGroup()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInPIEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "PIEquipmentGroup", filed: "description");
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
                GoToUrl("FileMaintenance", "PIEquipmentGroup");
                RefreshRecordDataInGrid("PiEquipmentGroupList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}