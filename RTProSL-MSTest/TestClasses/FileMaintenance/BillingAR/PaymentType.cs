//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.BillingAR;

// define class struct PaymentTypeList

public class PaymentTypeEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }


    [ValidationDataType(DataType.CheckBox)]
    public bool FattMerchant { set; get; }

    [ValidationElementProperty("inactive")]
    [ValidationDataType(DataType.CheckBox)]
    public bool Inactive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass]
[TestCategory("FileMaintenance___BillingAR")]
public class PaymentType : BaseClass
{
    // new struct PaymentType Entity
    private PaymentTypeEntity _PaymentTypeEntity;


    public void AddPaymentTypeFunc()
    {
        GoToUrl("FileMaintenance", "PaymentType");

        // click on btn add in page PaymentType Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        _PaymentTypeEntity = new PaymentTypeEntity();

        // data insert to feilds in page PaymentType  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_PaymentTypeEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertPaymentTypeFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_PaymentTypeEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _PaymentTypeEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInserted SubrentalReason();
        CreateValidation(_PaymentTypeEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddPaymentTypeStatus()
    {
        TestInitialize(nameof(AddPaymentTypeStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPaymentTypeFunc();
                ValidateInsertPaymentTypeFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeletePaymentType()
    {
        TestInitialize(nameof(DeletePaymentType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call PaymentType add 
                AddPaymentTypeFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_PaymentTypeEntity.Code, "PaymentTypeList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckPaymentType()
    {
        TestInitialize(nameof(ArrowNextBtnCheckPaymentType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PaymentType");
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
    public void ArrowPreviousBtnCheckPaymentType()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckPaymentType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PaymentType");
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
    public void ArrowFirstBtnCheckArrowNextBtnCheckPaymentType()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckArrowNextBtnCheckPaymentType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PaymentType");
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
    public void ArrowLastBtnCheckArrowNextBtnCheckPaymentType()
    {
        TestInitialize(nameof(ArrowLastBtnCheckArrowNextBtnCheckPaymentType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PaymentType");
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
    public void EditPaymentType()
    {
        TestInitialize(nameof(EditPaymentType));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _PaymentTypeEntity = new PaymentTypeEntity();
                //go to page rental agent

                AddPaymentTypeFunc();

                Thread.Sleep(3000);
                // click on btn edit 
                ShowAllRedord();

                SearchTextInMainGrid(_PaymentTypeEntity.Code.Trim());
                Thread.Sleep(2000);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _PaymentTypeEntity.Code.Trim());
                Thread.Sleep(2000);
                webElementAction.DoubleClick(selectRow);

                webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_PaymentTypeEntity);
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
    public void ListViewtBtnCheckPaymentType()
    {
        TestInitialize(nameof(ListViewtBtnCheckPaymentType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PaymentType");
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
    public void DetailValidatePaymentType()
    {
        TestInitialize(nameof(DetailValidatePaymentType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPaymentTypeFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_PaymentTypeEntity.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("PaymentTypeList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _PaymentTypeEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds =
                    gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _PaymentTypeEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnPaymentType()
    {
        TestInitialize(nameof(CardViewBtnPaymentType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PaymentType");
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
    public void ValidateRequiredFieldsMessageBoxInPaymentType()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInPaymentType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "PaymentType", filed: "description");
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
                GoToUrl("FileMaintenance", "PaymentType");
                RefreshRecordDataInGrid("PaymentTypeList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}