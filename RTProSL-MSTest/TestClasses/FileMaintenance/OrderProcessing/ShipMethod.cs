//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;

// define class structShipMethod
public class ShipMethodEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool InActive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___OrderProcessing")]
public class ShipMethod : BaseClass
{
    // new struct ShipMethodEntity
    private ShipMethodEntity _ShipMethodEntity;


    public string AddShipMethodFunc()
    {
        GoToUrl("FileMaintenance", "ShipMethod");
        _ShipMethodEntity = new ShipMethodEntity();

        // click on btn add in page ShippingAddress Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in pageShippingAddress  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());
        webElementAction.GetInputElementByDataFormItemNameInDiv("inactive").Click();

        CreateAdd(_ShipMethodEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
        return _ShipMethodEntity.Code;
    }

    private void ValidateInsertShipMethodFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_ShipMethodEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _ShipMethodEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //Validate Inserted ProjectCodes();
        CreateValidation(_ShipMethodEntity);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddShipMethod()
    {
        TestInitialize(nameof(AddShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddShipMethodFunc();
                ValidateInsertShipMethodFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteShipMethod()
    {
        TestInitialize(nameof(DeleteShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call ShipMethod add 
                AddShipMethodFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_ShipMethodEntity.Code, "ShipMethodList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckShipMethod()
    {
        TestInitialize(nameof(ArrowNextBtnCheckShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShipMethod");
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
    public void ArrowPreviousBtnCheckShipMethod()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShipMethod");
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
    public void ArrowFirstBtnCheckShipMethod()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShipMethod");
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
    public void ArrowLastBtnCheckShipMethod()
    {
        TestInitialize(nameof(ArrowLastBtnCheckShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShipMethod");
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
    public void EditBtnShipMethod()
    {
        TestInitialize(nameof(EditBtnShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShipMethod");
                _ShipMethodEntity = new ShipMethodEntity();

                Thread.Sleep(3000);
                ShowAllRedord();
                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_ShipMethodEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertShipMethodFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void InactiveBtnCheckShipMethod()
    {
        TestInitialize(nameof(InactiveBtnCheckShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShipMethod");

                InActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ActiveBtnCheckShipMethod()
    {
        TestInitialize(nameof(ActiveBtnCheckShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShipMethod");

                ActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckShipMethod()
    {
        TestInitialize(nameof(ListViewtBtnCheckShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShipMethod");
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
    public void CardViewBtnCheckShipMethod()
    {
        TestInitialize(nameof(CardViewBtnCheckShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShipMethod");
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
    public void DetailValidateShipMethod()
    {
        TestInitialize(nameof(DetailValidateShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddShipMethodFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_ShipMethodEntity.Code.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("ShipMethodList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _ShipMethodEntity.Code.Trim()).Click();

                ChangeScreenPageSize(40);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _ShipMethodEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInShipMethod()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInShipMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "ShipMethod", filed: "description");
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
                GoToUrl("FileMaintenance", "ShipMethod");
                RefreshRecordDataInGrid("ShipMethodList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}