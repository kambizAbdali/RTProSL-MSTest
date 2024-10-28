// develop by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;
// update Setup set UseAccessoryVersion =1 
public class AccessoryVersionEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class AccessoryVersion : BaseClass
{
    private AccessoryVersionEntity _AccessoryVersionEntity;

    public void AddAccessoryVersionFunc()
    {
        _AccessoryVersionEntity = new AccessoryVersionEntity();
        GoToUrl("FileMaintenance", "AccessoryVersion");
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_AccessoryVersionEntity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValiadteInsertAccessoryVersionFunc()
    {
        SearchTextInMainGrid(_AccessoryVersionEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _AccessoryVersionEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        CreateValidation(_AccessoryVersionEntity);
        //ValidateInsertedMasterInGridList();
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddAccessoryVersion()
    {
        TestInitialize(nameof(AddAccessoryVersion));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                AddAccessoryVersionFunc();
                ValiadteInsertAccessoryVersionFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBtnAccessoryVersion()
    {
        TestInitialize(nameof(EditBtnAccessoryVersion));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                //navigate to AccessoryVersion page 
                _AccessoryVersionEntity = new AccessoryVersionEntity();
                GoToUrl("FileMaintenance", "AccessoryVersion");

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //
                //e all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_AccessoryVersionEntity);

                Thread.Sleep(1000);
                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValiadteInsertAccessoryVersionFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteAccessoryVersion()
    {
        TestInitialize(nameof(DeleteAccessoryVersion));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                //call Salesperson add 
                AddAccessoryVersionFunc();
                //ShowAllRedord();
                // call delete method from base class 
                Delete(_AccessoryVersionEntity.Code, "AccessoryVersion-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInAccessoryVersion()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInAccessoryVersion));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "AccessoryVersion");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInAccessoryVersion()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInAccessoryVersion));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "AccessoryVersion");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInAccessoryVersion()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInAccessoryVersion));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "AccessoryVersion");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInAccessoryVersion()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInAccessoryVersion));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "AccessoryVersion");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInAccessoryVersion()
    {
        TestInitialize(nameof(ListViewBtnCheckInAccessoryVersion));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "AccessoryVersion");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateAccessoryVersion()
    {
        TestInitialize(nameof(DetailValidateAccessoryVersion));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                AddAccessoryVersionFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_AccessoryVersionEntity.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("AccessoryVersion-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _AccessoryVersionEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _AccessoryVersionEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [Priority(1)]
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInAccessoryVersion()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInAccessoryVersion));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "AccessoryVersion", filed: "description");
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
                GoToUrl("FileMaintenance", "AccessoryVersion");
                RefreshRecordDataInGrid("AccessoryVersion-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}
