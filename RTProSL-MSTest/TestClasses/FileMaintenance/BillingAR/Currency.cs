//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.BillingAR;

// define class struct Currency

public class CurrencyEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("currencyId")]
    public string Code { set; get; }

    public string Symbol { set; get; }

    public string Description { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass]
[TestCategory("FileMaintenance___BillingAR")]
public class Currency : BaseClass
{
    // new struct Currency Entity
    private CurrencyEntity _CurrencyEntity;

    public void AddCurrencyFunc()
    {
        GoToUrl("FileMaintenance", "Currency");
        ListViewBtnValidate();
        ShowAllRedord();
        // click on btn add in page Currency Entry Screen
        webElementAction.GetElementById("TOOL_BOX_ADD_BUTTON_ID").Click();
        _CurrencyEntity = new CurrencyEntity();
        // data insert to filds in page Currency  Entry Screen with radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_CurrencyEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
        CheckErrorDialogBox();
    }

    private void ValidateInsertCurrencyFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_CurrencyEntity.Code.Trim());

        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _CurrencyEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInserted SubrentalReason();
        CreateValidation(_CurrencyEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddCurrency()
    {
        TestInitialize(nameof(AddCurrency));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                AddCurrencyFunc();
                ValidateInsertCurrencyFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteCurrency()
    {
        TestInitialize(nameof(DeleteCurrency));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                //call Currency add 
                AddCurrencyFunc();
                ShowAllRedord();

                // call delete method from base class 
                Delete(_CurrencyEntity.Code, "TermsList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckCurrency()
    {
        TestInitialize(nameof(ArrowNextBtnCheckCurrency));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "Currency");
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
    public void ArrowPreviousBtnCheckCurrency()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckCurrency));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "Currency");
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
    public void ArrowFirstBtnCheckArrowNextBtnCheckCurrency()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckArrowNextBtnCheckCurrency));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "Currency");
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
    public void ArrowLastBtnCheckArrowNextBtnCheckCurrency()
    {
        TestInitialize(nameof(ArrowLastBtnCheckArrowNextBtnCheckCurrency));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "Currency");
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
    public void EditCurrency()
    {
        TestInitialize(nameof(EditCurrency));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                _CurrencyEntity = new CurrencyEntity();
                //go to page rental agent

                AddCurrencyFunc();

                Thread.Sleep(3000);
                // click on btn edit 
                ShowAllRedord();

                SearchTextInMainGrid(_CurrencyEntity.Code.Trim());
                Thread.Sleep(2000);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _CurrencyEntity.Code.Trim());
                Thread.Sleep(2000);
                webElementAction.DoubleClick(selectRow);

                webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide").FindElements(By.TagName("div")).FirstOrDefault(); ;

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_CurrencyEntity);
                Thread.Sleep(3000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                Thread.Sleep(2000);

                webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();
                ValidateInsertCurrencyFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckCurrency()
    {
        TestInitialize(nameof(ListViewtBtnCheckCurrency));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "Currency");
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
    public void DetailValidateCurrency()
    {
        TestInitialize(nameof(DetailValidateCurrency));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                AddCurrencyFunc();

                SearchTextInMainGrid(_CurrencyEntity.Code.Trim());

                Thread.Sleep(2000);

                var gridlist = webElementAction.GetElementById("CurrencyList-gridId");
                var selectRow = gridlist.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _CurrencyEntity.Code.Trim());
                selectRow.Click();

                ChangeScreenPageSize(40);

                Thread.Sleep(2000);
                ReadOnlyCollection<IWebElement> colIds =
                    gridlist.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _CurrencyEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCurrency()
    {
        TestInitialize(nameof(CardViewBtnCurrency));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                GoToUrl("FileMaintenance", "Currency");
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
    public void ValidateRequiredFieldsMessageBoxInCurrency()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInCurrency));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    break;
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "Currency", filed: "description");
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
                GoToUrl("FileMaintenance", "Currency");
                RefreshRecordDataInGrid("CurrencyList-gridId", columnId: "currencyId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}