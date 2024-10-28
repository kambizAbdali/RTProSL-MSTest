//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
namespace RTProSL_MSTest.TestClasses.FileMaintenance.Dispatch;

// define class struct DispatchStatusList

public class DispatchStatusEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }

    [ValidationDataType(DataType.Color)]
    public string Color { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Dispatch")]
public class DispatchStatus : BaseClass
{
    // new struct DispatchStatusList Entity
    private TruckEntity _DispatchStatusListEntity;

    public void AddDispatchStatusFunc()
    {
        GoToUrl("FileMaintenance", "DispatchStatus");
        _DispatchStatusListEntity = new TruckEntity();

        // click on btn add in page DispatchStatusList Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page DispatchStatusList  Entry Screen whith radnom data
        var webElementDataGenerator = new WebElementDataGenerator(GetFormLeftSideContext());
        CreateAdd(_DispatchStatusListEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertDispatchStatusFunc()
    {
        SearchTextInMainGrid(_DispatchStatusListEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _DispatchStatusListEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInserted SubrentalReason();
        CreateValidation(_DispatchStatusListEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddDispatchStatus()
    {
        TestInitialize(nameof(AddDispatchStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddDispatchStatusFunc();
                ValidateInsertDispatchStatusFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteDispatchStatus()
    {
        TestInitialize(nameof(DeleteDispatchStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call DispatchStatusList add 
                AddDispatchStatusFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_DispatchStatusListEntity.Code, "DispatchStatusList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckDispatchStatus()
    {
        TestInitialize(nameof(ArrowNextBtnCheckDispatchStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "DispatchStatus");
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
    public void ArrowPreviousBtnCheckDispatchStatus()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckDispatchStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "DispatchStatus");
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
    public void ArrowFirstBtnCheckDispatchStatus()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckDispatchStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "DispatchStatus");
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
    public void ArrowLastBtnCheckDispatchStatus()
    {
        TestInitialize(nameof(ArrowLastBtnCheckDispatchStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "DispatchStatus");
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
    public void EditBtnDispatchStatus()
    {
        TestInitialize(nameof(EditBtnDispatchStatus));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _DispatchStatusListEntity = new TruckEntity();
                //go to page rental agent

                AddDispatchStatusFunc();

                Thread.Sleep(3000);

                SearchTextInMainGrid(_DispatchStatusListEntity.Code.Trim());
                Thread.Sleep(2000);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
    .FirstOrDefault(o => o.Text == _DispatchStatusListEntity.Code.Trim());
                Thread.Sleep(2000);
                webElementAction.DoubleClick(selectRow);

                webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();
                // define context page to variable

                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_DispatchStatusListEntity);
                Thread.Sleep(1000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                Thread.Sleep(2000);

                webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();
                ValidateInsertDispatchStatusFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckDispatchStatus()
    {
        TestInitialize(nameof(ListViewtBtnCheckDispatchStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to DispatchStatusList page 
                GoToUrl("FileMaintenance", "DispatchStatus");
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
    public void DetailValidateDispatchStatus()
    {
        TestInitialize(nameof(DetailValidateDispatchStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddDispatchStatusFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_DispatchStatusListEntity.Code.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("DispatchStatusList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _DispatchStatusListEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _DispatchStatusListEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnDispatchStatus()
    {
        TestInitialize(nameof(CardViewBtnDispatchStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("FileMaintenance", "DispatchStatus");
                ShowAllRedord();
                //call method card viewBtn
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInDispatchStatus()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInDispatchStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "DispatchStatus", filed: "description");
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
                GoToUrl("FileMaintenance", "DispatchStatus");
                RefreshRecordDataInGrid("DispatchStatusList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}