//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;

// define class struct ShippingMethodCharge
public class ShippingMethodChargeEntity
{
    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    [ValidationElementProperty("shippingMethodId")]
    public string ShipMethod { set; get; }


    [ValidationElementProperty("shippingChargeCodeId")]
    public string ShippingChargeCode { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___OrderProcessing")]
public class ShippingMethodCharge : BaseClass
{
    // new struct ShippingMethodChargeEntity
    private ShippingMethodChargeEntity _ShippingMethodChargeEntity;

    static string shipMethodCode;
    public void AddShippingMethodChargeFunc()
    {
        GoToUrl("FileMaintenance", "ShippingMethodCharge");
        _ShippingMethodChargeEntity = new ShippingMethodChargeEntity();

        // click on btn add in page Department Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page ShippingMethodCharge  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_ShippingMethodChargeEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertShippingMethodChargeFunc()
    {
        ShowAllRedord();

        Thread.Sleep(1000);

        //click on edit btn
        var editUserBtn = webElementAction.GetElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID");
        editUserBtn.Click();
        Thread.Sleep(3000);

        CreateValidation(_ShippingMethodChargeEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddShippingMethodCharge()
    {
        TestInitialize(nameof(AddShippingMethodCharge));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddShippingMethodChargeFunc();
                ValidateInsertShippingMethodChargeFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteShippingMethodCharge()
    {
        TestInitialize(nameof(DeleteShippingMethodCharge));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call ShippingMethodCharge add 
                AddShippingMethodChargeFunc();

                var rowCountsBeforDelete = GetRowCountFromGridPinnedFooter(gridId: "ShippingChargeMethodList-gridId");

                var deleteBtn_By = By.Id("TOOL_BOX_DELETE_BUTTON_ID");
                webElementAction.Click(deleteBtn_By);
                Thread.Sleep(500);

                var confirmDialogContext = webElementAction.GetElementBySpecificAttribute("data-section", "confirmDialog");

                var confirmUserDeleteBtn =
                    webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", confirmDialogContext);
                confirmUserDeleteBtn.Click();
                WaitForLoadingSpiner();

                var rowCountsAfterDelete = GetRowCountFromGridPinnedFooter(gridId: "ShippingChargeMethodList-gridId");

                if (rowCountsBeforDelete <= rowCountsAfterDelete) Assert.Fail("Error:__Delete operation failed...");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckShippingMethodCharge()
    {
        TestInitialize(nameof(ArrowNextBtnCheckShippingMethodCharge));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingMethodCharge");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckShippingMethodCharge()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckShippingMethodCharge));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingMethodCharge");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckShippingMethodCharge()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckShippingMethodCharge));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingMethodCharge");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckShippingMethodCharge()
    {
        TestInitialize(nameof(ArrowLastBtnCheckShippingMethodCharge));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingMethodCharge");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBtnShippingMethodCharge()
    {
        TestInitialize(nameof(EditBtnShippingMethodCharge));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingMethodCharge");
                _ShippingMethodChargeEntity = new ShippingMethodChargeEntity();
                Thread.Sleep(2000);
                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_ShippingMethodChargeEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertShippingMethodChargeFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckShippingMethodCharge()
    {
        TestInitialize(nameof(ListViewtBtnCheckShippingMethodCharge));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingMethodCharge");
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckShippingMethodCharge()
    {
        TestInitialize(nameof(CardViewBtnCheckShippingMethodCharge));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingMethodCharge");
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateShippingMethodCharge()
    {
        TestInitialize(nameof(DetailValidateShippingMethodCharge));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddShippingMethodChargeFunc();
                ListViewtBtnClick();
                ShowAllRedord();

                Thread.Sleep(2000);

                var gridList = webElementAction.GetElementById("ShippingChargeMethodList-gridId");

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                CreateValidationInGrid(colIds, _ShippingMethodChargeEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInShippingMethodCharge()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInShippingMethodCharge));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "ShippingMethodCharge", filed: "shippingMethodId");
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
                GoToUrl("FileMaintenance", "ShippingMethodCharge");
                RefreshRecordDataInGrid("ShippingChargeMethodList-gridId", columnId: "shippingMethodId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}