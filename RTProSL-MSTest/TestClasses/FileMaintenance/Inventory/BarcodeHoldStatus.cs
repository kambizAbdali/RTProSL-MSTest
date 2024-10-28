// develop by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

public class BarcodeHoldStatusEntity
{
    [ValidationIgnoreInGrid]
    [ValidationElementProperty("id")] public string Code { set; get; }

    public string Description { set; get; }

    [ValidationDataType(DataType.Color)]
    public string Color { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool Inactive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class BarcodeHoldStatus : BaseClass
{
    private BarcodeHoldStatusEntity _BarcodeHoldStatus;

    public void AddBarcodeHoldStatusFunc()
    {
        _BarcodeHoldStatus = new BarcodeHoldStatusEntity();
        GoToUrl("FileMaintenance", "BarcodeHoldStatus");

        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_BarcodeHoldStatus);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertBarcodeHoldStatusFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_BarcodeHoldStatus.Code.Trim());

        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _BarcodeHoldStatus.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        CreateValidation(_BarcodeHoldStatus);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddBarcodeHoldStatus()
    {
        TestInitialize(nameof(AddBarcodeHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddBarcodeHoldStatusFunc();
                ValidateInsertBarcodeHoldStatusFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBarcodeHoldStatus()
    {
        TestInitialize(nameof(EditBarcodeHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _BarcodeHoldStatus = new BarcodeHoldStatusEntity();
                GoToUrl("FileMaintenance", "BarcodeHoldStatus");

                Thread.Sleep(3000);

                ShowAllRedord();
                WaitForLoadingSpiner();
                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_BarcodeHoldStatus);

                Thread.Sleep(1000);
                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertBarcodeHoldStatusFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteBarcodeHoldStatus()
    {
        TestInitialize(nameof(DeleteBarcodeHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call BarcodeHoldStatus add 
                AddBarcodeHoldStatusFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_BarcodeHoldStatus.Code, "BarcodeHoldStatusList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInBarcodeHoldStatus()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInBarcodeHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BarcodeHoldStatus");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInBarcodeHoldStatus()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInBarcodeHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BarcodeHoldStatus");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInBarcodeHoldStatus()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInBarcodeHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BarcodeHoldStatus");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInBarcodeHoldStatus()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInBarcodeHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BarcodeHoldStatus");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInBarcodeHoldStatus()
    {
        TestInitialize(nameof(CardViewBtnCheckInBarcodeHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BarcodeHoldStatus");
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
    public void ListViewBtnCheckInBarcodeHoldStatus()
    {
        TestInitialize(nameof(ListViewBtnCheckInBarcodeHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BarcodeHoldStatus");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateBarcodeHoldStatus()
    {
        TestInitialize(nameof(DetailValidateBarcodeHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddBarcodeHoldStatusFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_BarcodeHoldStatus.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("BarcodeHoldStatusList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _BarcodeHoldStatus.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _BarcodeHoldStatus);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInBarcodeHoldStatus()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInBarcodeHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "BarcodeHoldStatus", filed: "description");
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
                GoToUrl("FileMaintenance", "BarcodeHoldStatus");
                RefreshRecordDataInGrid("BarcodeHoldStatusList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}