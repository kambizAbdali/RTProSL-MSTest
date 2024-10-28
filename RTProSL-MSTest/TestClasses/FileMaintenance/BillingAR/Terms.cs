//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.BillingAR;

// define class struct Terms

public class TermsEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Discount { set; get; }

    public string Description { set; get; }

    public string DueDays { set; get; }

    [ValidationElementProperty("discDays")]
    public string DiscountDays { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    public bool Inactive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass]
[TestCategory("FileMaintenance___BillingAR")]
public class Terms : BaseClass
{
    // new struct Terms Entity
    private TermsEntity _TermsEntity;

    public void AddTermsFunc()
    {
        GoToUrl("FileMaintenance", "Terms");
        _TermsEntity = new TermsEntity();
        ShowAllRedord();
        // click on btn add in page Terms Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page Terms  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_TermsEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertTermsFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_TermsEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _TermsEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInserted SubrentalReason();
        CreateValidation(_TermsEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddTerms()
    {
        TestInitialize(nameof(AddTerms));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddTermsFunc();
                ValidateInsertTermsFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteTerms()
    {
        TestInitialize(nameof(DeleteTerms));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Terms add 
                AddTermsFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_TermsEntity.Code, "TermsList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckTerms()
    {
        TestInitialize(nameof(ArrowNextBtnCheckTerms));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Terms");
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
    public void ArrowPreviousBtnCheckTerms()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckTerms));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Terms");
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
    public void ArrowFirstBtnCheckArrowNextBtnCheckTerms()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckArrowNextBtnCheckTerms));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Terms");
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
    public void ArrowLastBtnCheckArrowNextBtnCheckTerms()
    {
        TestInitialize(nameof(ArrowLastBtnCheckArrowNextBtnCheckTerms));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Terms");
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
    public void EditTerms()
    {
        TestInitialize(nameof(EditTerms));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _TermsEntity = new TermsEntity();
                //go to page rental agent

                AddTermsFunc();

                Thread.Sleep(3000);
                // click on btn edit 
                ShowAllRedord();

                SearchTextInMainGrid(_TermsEntity.Code.Trim());
                Thread.Sleep(2000);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _TermsEntity.Code.Trim());
                Thread.Sleep(2000);
                webElementAction.DoubleClick(selectRow);

                webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_TermsEntity);
                Thread.Sleep(3000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                Thread.Sleep(2000);

                webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();
                ValidateInsertTermsFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckTerms()
    {
        TestInitialize(nameof(ListViewtBtnCheckTerms));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Terms");
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
    public void DetailValidateTerms()
    {
        TestInitialize(nameof(DetailValidateTerms));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddTermsFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_TermsEntity.Code.Trim());

                Thread.Sleep(3000);

                //var gridList = webElementAction.GetElementById("PaymentTypeList-gridId");
                //gridList.FindElements(By.TagName("div"))
                //    .FirstOrDefault(o => o.Text == _GeneralLedgerEntity.Code.Trim()).Click();

                var gridlist = webElementAction.GetElementById("TermsList-gridId");
                var selectRow = gridlist.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _TermsEntity.Code.Trim());
                webElementAction.DoubleClick(selectRow);


                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds =
                    gridlist.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _TermsEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnTerms()
    {
        TestInitialize(nameof(CardViewBtnTerms));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Terms");
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
    public void ValidateRequiredFieldsMessageBoxInTerms()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInTerms));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "Terms", filed: "description");
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
                GoToUrl("FileMaintenance", "Terms");
                RefreshRecordDataInGrid("TermsList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}