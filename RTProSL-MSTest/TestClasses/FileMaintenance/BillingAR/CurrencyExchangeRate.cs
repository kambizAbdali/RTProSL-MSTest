//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.BillingAR;

// define class struct CurrencyExchangeRate

public class CurrencyExchangeRateEntity
{
    [ValidationElementProperty("fromCurrencyId")]
    public string FromCurrency { set; get; }

    [ValidationElementProperty("toCurrencyId")]
    public string ToCurrency { set; get; }

    public string Date { set; get; }

    public string ExchangeRate { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass]
[TestCategory("FileMaintenance___BillingAR")]
public class CurrencyExchangeRate : BaseClass
{
    // new struct CurrencyExchangeRate Entity
    private CurrencyExchangeRateEntity _CurrencyExchangeRateEntity;


    public void AddCurrencyExchangeRateFunc()
    {
        GoToUrl("FileMaintenance", "CurrencyExchangeRate");
        ListViewBtnValidate();

        ShowAllRedord();
        WaitForLoadingSpiner();
        // click on btn add in page CurrencyExchangeRate Entry Screen
        webElementAction.GetElementById("TOOL_BOX_ADD_BUTTON_ID").Click();
        _CurrencyExchangeRateEntity = new CurrencyExchangeRateEntity();

        // data insert to feilds in page CurrencyExchangeRate  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_CurrencyExchangeRateEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertCurrencyExchangeRateFunc()
    {
        //click on edit btn
        var editUserBtn = webElementAction.GetElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID");
        editUserBtn.Click();
        Thread.Sleep(500);

        //click on edit btn
        editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInserted SubrentalReason();
        CreateValidation(_CurrencyExchangeRateEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime * 2)]
    public void AddCurrencyExchangeRate()
    {
        TestInitialize(nameof(AddCurrencyExchangeRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                AddCurrencyExchangeRateFunc();
                ValidateInsertCurrencyExchangeRateFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteCurrencyExchangeRate()
    {
        TestInitialize(nameof(DeleteCurrencyExchangeRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                AddCurrencyExchangeRateFunc();
                ShowAllRedord();

                var gridId = "CurrencyExchangeRateList-gridId";
                var rowCountsBeforDelete = GetRowCountFromGridPinnedFooter(gridId: gridId);

                var deleteBtn_By = By.Id("TOOL_BOX_DELETE_BUTTON_ID");
                webElementAction.Click(deleteBtn_By);
                Thread.Sleep(500);

                var confirmDialogContext = webElementAction.GetElementBySpecificAttribute("data-section", "confirmDialog");

                var confirmUserDeleteBtn =
                    webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", confirmDialogContext);
                confirmUserDeleteBtn.Click();
                WaitForLoadingSpiner();

                var rowCountsAfterDelete = GetRowCountFromGridPinnedFooter(gridId: gridId);

                if (rowCountsBeforDelete <= rowCountsAfterDelete) Assert.Fail("Error:__Delete operation failed...");
                testPassed = true;

            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckCurrencyExchangeRate()
    {
        TestInitialize(nameof(ArrowNextBtnCheckCurrencyExchangeRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "CurrencyExchangeRate");
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
    public void ArrowPreviousBtnCheckCurrencyExchangeRate()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckCurrencyExchangeRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "CurrencyExchangeRate");
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
    public void ArrowFirstBtnCheckArrowNextBtnCheckCurrencyExchangeRate()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckArrowNextBtnCheckCurrencyExchangeRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "CurrencyExchangeRate");
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
    public void ArrowLastBtnCheckArrowNextBtnCheckCurrencyExchangeRate()
    {
        TestInitialize(nameof(ArrowLastBtnCheckArrowNextBtnCheckCurrencyExchangeRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "CurrencyExchangeRate");
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
    public void EditCurrencyExchangeRate()
    {
        TestInitialize(nameof(EditCurrencyExchangeRate));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                _CurrencyExchangeRateEntity = new CurrencyExchangeRateEntity();
                //go to page rental agent

                AddCurrencyExchangeRateFunc();

                Thread.Sleep(3000);
                // click on btn edit 
                ShowAllRedord();

                SearchTextInMainGrid(_CurrencyExchangeRateEntity.FromCurrency.Trim());
                Thread.Sleep(2000);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _CurrencyExchangeRateEntity.FromCurrency.Trim());
                Thread.Sleep(2000);
                webElementAction.DoubleClick(selectRow);

                webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_CurrencyExchangeRateEntity);
                Thread.Sleep(3000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                Thread.Sleep(2000);

                webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();
                ValidateInsertCurrencyExchangeRateFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckCurrencyExchangeRate()
    {
        TestInitialize(nameof(ListViewtBtnCheckCurrencyExchangeRate));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "CurrencyExchangeRate");
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
    public void DetailValidateCurrencyExchangeRate()
    {
        TestInitialize(nameof(DetailValidateCurrencyExchangeRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                AddCurrencyExchangeRateFunc();
                ChangeScreenPageSize(30);
                Thread.Sleep(3000);
                var gridlist = webElementAction.GetElementById("CurrencyExchangeRateList-gridId");

                ReadOnlyCollection<IWebElement> colIds =
                    gridlist.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _CurrencyExchangeRateEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCurrencyExchangeRate()
    {
        TestInitialize(nameof(CardViewBtnCurrencyExchangeRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "CurrencyExchangeRate");
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
    public void ValidateRequiredFieldsMessageBoxInCurrencyExchangeRate()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInCurrencyExchangeRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "CurrencyExchangeRate", filed: "exchangeRate");
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
                GoToUrl("FileMaintenance", "CurrencyExchangeRate");
                RefreshRecordDataInGrid("CurrencyExchangeRateList-gridId", columnId: "fromCurrencyId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}