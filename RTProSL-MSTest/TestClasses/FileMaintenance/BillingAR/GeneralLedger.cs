//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.BillingAR;

// define class struct GeneralLedger

public class GeneralLedgerEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }


    [ValidationElementProperty("inactive")]
    [ValidationDataType(DataType.CheckBox)]
    public bool Inactive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass]
[TestCategory("FileMaintenance___BillingAR")]
public class GeneralLedger : BaseClass
{
    // new struct GeneralLedger Entity
    private GeneralLedgerEntity _GeneralLedgerEntity;

    public void AddGeneralLedgerFunc()
    {
        GoToUrl("FileMaintenance", "GeneralLedger");
        _GeneralLedgerEntity = new GeneralLedgerEntity();
        // click on btn add in page GeneralLedger Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page GeneralLedger  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_GeneralLedgerEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertGeneralLedgerFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_GeneralLedgerEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _GeneralLedgerEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInserted SubrentalReason();
        CreateValidation(_GeneralLedgerEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddGeneralLedger()
    {
        TestInitialize(nameof(AddGeneralLedger));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddGeneralLedgerFunc();
                ValidateInsertGeneralLedgerFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteGeneralLedger()
    {
        TestInitialize(nameof(DeleteGeneralLedger));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call GeneralLedger add 
                AddGeneralLedgerFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_GeneralLedgerEntity.Code, "GeneralLedgerList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckGeneralLedgerList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckGeneralLedgerList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "GeneralLedger");
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
    public void ArrowPreviousBtnCheckGeneralLedgerList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckGeneralLedgerList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "GeneralLedger");
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
    public void ArrowFirstBtnCheckArrowNextBtnCheckGeneralLedgerList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckArrowNextBtnCheckGeneralLedgerList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "GeneralLedger");
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
    public void ArrowLastBtnCheckArrowNextBtnCheckGeneralLedgerList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckArrowNextBtnCheckGeneralLedgerList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "GeneralLedger");
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
    public void EditGeneralLedgerList()
    {
        TestInitialize(nameof(EditGeneralLedgerList));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _GeneralLedgerEntity = new GeneralLedgerEntity();
                //go to page rental agent

                AddGeneralLedgerFunc();

                Thread.Sleep(3000);
                // click on btn edit 
                ShowAllRedord();

                SearchTextInMainGrid(_GeneralLedgerEntity.Code.Trim());
                Thread.Sleep(2000);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _GeneralLedgerEntity.Code.Trim());
                Thread.Sleep(2000);
                webElementAction.DoubleClick(selectRow);

                webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_GeneralLedgerEntity);
                Thread.Sleep(1000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                Thread.Sleep(2000);

                webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();
                ValidateInsertGeneralLedgerFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckGeneralLedger()
    {
        TestInitialize(nameof(ListViewtBtnCheckGeneralLedger));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "GeneralLedger");
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
    public void DetailValidateGeneralLedger()
    {
        TestInitialize(nameof(DetailValidateGeneralLedger));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddGeneralLedgerFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_GeneralLedgerEntity.Code.Trim());
                Thread.Sleep(3000);

                var gridlist = webElementAction.GetElementById("GeneralLedgerList-gridId");
                var selectRow = gridlist.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _GeneralLedgerEntity.Code.Trim());
                webElementAction.DoubleClick(selectRow);


                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds =
                    gridlist.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _GeneralLedgerEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnGeneralLedger()
    {
        TestInitialize(nameof(CardViewBtnGeneralLedger));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "GeneralLedger");
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
    public void ValidateRequiredFieldsMessageBoxInGeneralLedger()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInGeneralLedger));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "GeneralLedger", filed: "description");
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
                GoToUrl("FileMaintenance", "GeneralLedger");
                RefreshRecordDataInGrid("GeneralLedgerList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}