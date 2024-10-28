//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;

public class ShippingChargeCodeEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    [ValidationDataType(DataType.DropDown)]
    [ValidationElementProperty("type")]
    public string Type { set; get; }

    public string Description { set; get; }

    public string Amount { set; get; }

    [ValidationElementProperty("taxTypeId")]
    public string TaxType { set; get; }

    [ValidationElementProperty("glAccountId")]
    public string GLAccount { set; get; }

    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("requireTruck")]
    public bool RequireTruck { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___OrderProcessing")]
public class ShippingChargeCode : BaseClass
{
    // new struct ProductionTypeEntity
    private ShippingChargeCodeEntity _ShippingChargeCodeEntity;


    public void AddShippingChargeCodeFunc()
    {
        GoToUrl("FileMaintenance", "ShippingChargeCodes");
        _ShippingChargeCodeEntity = new ShippingChargeCodeEntity();

        // click on btn add in pageShippingChargeCode Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page ShippingChargeCode  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_ShippingChargeCodeEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertShippingChargeCodeFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_ShippingChargeCodeEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _ShippingChargeCodeEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        CreateValidation(_ShippingChargeCodeEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddShippingChargeCode()
    {
        TestInitialize(nameof(AddShippingChargeCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddShippingChargeCodeFunc();
                ValidateInsertShippingChargeCodeFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteShippingChargeCode()
    {
        TestInitialize(nameof(DeleteShippingChargeCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call ShippingMethodCharge add 
                AddShippingChargeCodeFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_ShippingChargeCodeEntity.Code, "ShippingChargeCodesList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckShippingChargeCode()
    {
        TestInitialize(nameof(ArrowNextBtnCheckShippingChargeCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingChargeCodes");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckShippingChargeCode()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckShippingChargeCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingChargeCodes");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckShippingChargeCode()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckShippingChargeCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingChargeCodes");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckShippingChargeCode()
    {
        TestInitialize(nameof(ArrowLastBtnCheckShippingChargeCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingChargeCodes");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBtnShippingChargeCode()
    {
        TestInitialize(nameof(EditBtnShippingChargeCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingChargeCodes");
                _ShippingChargeCodeEntity = new ShippingChargeCodeEntity();
                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_ShippingChargeCodeEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertShippingChargeCodeFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckShippingChargeCode()
    {
        TestInitialize(nameof(ListViewtBtnCheckShippingChargeCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingChargeCodes");
                _ShippingChargeCodeEntity = new ShippingChargeCodeEntity();
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckShippingChargeCode()
    {
        TestInitialize(nameof(CardViewBtnCheckShippingChargeCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingChargeCodes");
                _ShippingChargeCodeEntity = new ShippingChargeCodeEntity();
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateShippingChargeCode()
    {
        TestInitialize(nameof(DetailValidateShippingChargeCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddShippingChargeCodeFunc();

                SearchTextInMainGrid(_ShippingChargeCodeEntity.Code);

                var gridList = webElementAction.GetElementById("ShippingChargeCodesList-gridId");

                gridList.FindElement(By.CssSelector(".ag-pinned-left-cols-container .ag-cell-last-left-pinned")).Click();

                ChangeScreenPageSize(60);
                Thread.Sleep(2000);
                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _ShippingChargeCodeEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private void SearchAddedShippingChargeCodeInGrid()
    {
        throw new NotImplementedException();
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInShippingChargeCodes()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInShippingChargeCodes));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "ShippingChargeCodes", filed: "description");
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
                GoToUrl("FileMaintenance", "ShippingChargeCodes");
                RefreshRecordDataInGrid("ShippingChargeCodesList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}