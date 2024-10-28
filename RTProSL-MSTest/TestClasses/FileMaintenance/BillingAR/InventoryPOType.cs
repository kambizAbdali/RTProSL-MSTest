//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.BillingAR;

// define class struct InventoryPoTypeList

public class InventoryPoTypeEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    public bool ProductionRequired { set; get; }


    [ValidationElementProperty("inactive")]
    [ValidationDataType(DataType.CheckBox)]
    public bool Inactive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass]
[TestCategory("FileMaintenance___BillingAR")]
public class InventoryPoType : BaseClass
{
    // new struct InventoryPoType Entity
    private InventoryPoTypeEntity _InventoryPoTypeEntity;


    public void AddInventoryPoTypeFunc()
    {
        GoToUrl("FileMaintenance", "InventoryPOType");
        _InventoryPoTypeEntity = new InventoryPoTypeEntity();
        // click on btn add in page PaymentType Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page PaymentType  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_InventoryPoTypeEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertPaymentTypeFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_InventoryPoTypeEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _InventoryPoTypeEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInserted SubrentalReason();
        CreateValidation(_InventoryPoTypeEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddInventoryPoTypeStatus()
    {
        TestInitialize(nameof(AddInventoryPoTypeStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddInventoryPoTypeFunc();
                ValidateInsertPaymentTypeFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteInventoryPoType()
    {
        TestInitialize(nameof(DeleteInventoryPoType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call PaymentType add 
                AddInventoryPoTypeFunc();
                ShowAllRedord();
                WaitForLoadingSpiner();
                // call delete method from base class 
                Delete(_InventoryPoTypeEntity.Code, "InventoryPoTypeList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInventoryPoType()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInventoryPoType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "InventoryPOType");
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
    public void ArrowPreviousBtnCheckInventoryPoType()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInventoryPoType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "InventoryPOType");
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
    public void ArrowFirstBtnCheckArrowNextBtnCheckInventoryPoType()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckArrowNextBtnCheckInventoryPoType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "InventoryPOType");
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
    public void ArrowLastBtnCheckArrowNextBtnCheckInventoryPoType()
    {
        TestInitialize(nameof(ArrowLastBtnCheckArrowNextBtnCheckInventoryPoType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "InventoryPOType");
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
    public void EditInventoryPoType()
    {
        TestInitialize(nameof(EditInventoryPoType));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _InventoryPoTypeEntity = new InventoryPoTypeEntity();
                //go to page rental agent

                AddInventoryPoTypeFunc();

                Thread.Sleep(3000);
                // click on btn edit 
                ShowAllRedord();

                SearchTextInMainGrid(_InventoryPoTypeEntity.Code.Trim());
                Thread.Sleep(2000);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _InventoryPoTypeEntity.Code.Trim());
                Thread.Sleep(2000);
                webElementAction.DoubleClick(selectRow);

                webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_InventoryPoTypeEntity);
                Thread.Sleep(1000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                Thread.Sleep(2000);

                webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();
                ValidateInsertPaymentTypeFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckInventoryPoType()
    {
        TestInitialize(nameof(ListViewtBtnCheckInventoryPoType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "InventoryPOType");
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
    public void DetailValidateInventoryPoType()
    {
        TestInitialize(nameof(DetailValidateInventoryPoType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddInventoryPoTypeFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_InventoryPoTypeEntity.Code.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("InventoryPoTypeList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _InventoryPoTypeEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds =
                    gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _InventoryPoTypeEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnInventoryPoTypeType()
    {
        TestInitialize(nameof(CardViewBtnInventoryPoTypeType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "InventoryPOType");
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
    public void ValidateRequiredFieldsMessageBoxInInventoryPOType()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInInventoryPOType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "InventoryPOType", filed: "description");
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
                GoToUrl("FileMaintenance", "InventoryPOType");
                RefreshRecordDataInGrid("InventoryPoTypeList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}