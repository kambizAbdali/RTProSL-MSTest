//developed by Mohammad_Keshavarz
//Help from kambiz: Prerequisite for running tests=> Enable Credit Reason checkbox on the system setup page.

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.BillingAR;

// define class struct CreditReason

public class CreditReasonEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass]
[TestCategory("FileMaintenance___BillingAR")]
public class CreditReason : BaseClass
{
    // new struct CreditReason Entity
    private CreditReasonEntity _CreditReasonEntity;

    public void AddCreditReasonFunc()
    {
        GoToUrl("FileMaintenance", "CreditReason");
        _CreditReasonEntity = new CreditReasonEntity();
        ShowAllRedord();
        // click on btn add in page CreditReason Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page CreditReason  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_CreditReasonEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertCreditReasonFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_CreditReasonEntity.Code.Trim());

        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _CreditReasonEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInserted SubrentalReason();
        CreateValidation(_CreditReasonEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddCreditReason()
    {
        TestInitialize(nameof(AddCreditReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddCreditReasonFunc();
                ValidateInsertCreditReasonFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteCreditReason()
    {
        TestInitialize(nameof(DeleteCreditReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call CreditReason add 
                AddCreditReasonFunc();
                ShowAllRedord();
                // call delete method from base
                Delete(_CreditReasonEntity.Code, "CreaditReasonList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckCreditReason()
    {
        TestInitialize(nameof(ArrowNextBtnCheckCreditReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CreditReason");
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
    public void ArrowPreviousBtnCheckCreditReason()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckCreditReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CreditReason");
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
    public void ArrowFirstBtnCheckArrowNextBtnCheckCreditReason()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckArrowNextBtnCheckCreditReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CreditReason");
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
    public void ArrowLastBtnCheckArrowNextBtnCheckCreditReason()
    {
        TestInitialize(nameof(ArrowLastBtnCheckArrowNextBtnCheckCreditReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CreditReason");
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
    public void EditCreditReason()
    {
        TestInitialize(nameof(EditCreditReason));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _CreditReasonEntity = new CreditReasonEntity();
                //go to page rental agent

                AddCreditReasonFunc();

                Thread.Sleep(3000);
                // click on btn edit 
                ShowAllRedord();
                ////////////////// click on first row in grid table
                SearchTextInMainGrid(_CreditReasonEntity.Code.Trim());
                Thread.Sleep(2000);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _CreditReasonEntity.Code.Trim());
                Thread.Sleep(2000);
                webElementAction.DoubleClick(selectRow);

                webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_CreditReasonEntity);
                Thread.Sleep(3000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                Thread.Sleep(2000);

                webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();
                ValidateInsertCreditReasonFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckCreditReason()
    {
        TestInitialize(nameof(ListViewtBtnCheckCreditReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CreditReason");
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
    public void DetailValidateCreditReason()
    {
        TestInitialize(nameof(DetailValidateCreditReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddCreditReasonFunc();

                ListViewBtnValidate();

                ShowAllRedord();

                SearchTextInMainGrid(_CreditReasonEntity.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("CreaditReasonList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _CreditReasonEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds =
                    gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _CreditReasonEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInCreditReason()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInCreditReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "CreditReason", filed: "description");
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
                GoToUrl("FileMaintenance", "CreditReason");
                RefreshRecordDataInGrid("CreaditReasonList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}