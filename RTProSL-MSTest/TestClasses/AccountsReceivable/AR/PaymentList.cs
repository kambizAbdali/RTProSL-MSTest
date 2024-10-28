// Developed By Parsa Zakeri

using System.Collections;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;
using RTProSL_MSTest.TestClasses.Inventory.Rental.EquipmentListPlusEntity;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.AR;

public class PaymentEntity
{
    [ValidationColID("paymentNo")]
    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationDataType(DataType.Text)]
    public string Payment { set; get; }


    [ValidationDataFormName("PRODUCTION")]
    [ValidationElementProperty("productionId")]
    [ValidationDataType(DataType.Text)]
    public string Job { set; get; } //customer

    [ValidationElementProperty("transactionDate")]
    [ValidationDataType(DataType.Text)]
    public string PaymentDate { set; get; }

    [ValidationColID("paymentTypeId")]
    [ValidationDataFormName("PAYMENT_TYPE")]
    [ValidationDataType(DataType.Text)]
    public string PaymentType { set; get; }

    [ValidationDataFormName("CHECK_NO")]
    [ValidationElementProperty("reference")]  //col-id= reference
    [ValidationDataType(DataType.Text)]
    public string Check { set; get; }

    [ValidationColID("arType")] // Payment List (grid)
    [ValidationDataFormName("AR_TYPE")] // Payment Detail Screen (right side)
    [ValidationElementProperty("accountReceivableTypeId")] // Payment Entry Screen (add)
    [ValidationDataType(DataType.Text)]
    public string ARType { set; get; }

    [ValidationIgnoreInGrid(true)]
    [ValidationDataFormName("CREDIT_GL")]
    [ValidationElementProperty("creditGeneralLedgerId")]
    [ValidationDataType(DataType.Text)]
    public string CreditGL { set; get; }

    [ValidationColID("glAcct")]
    [ValidationDataFormName("DEBIT_GL")]
    [ValidationElementProperty("generalLedgerAccountId")]
    [ValidationDataType(DataType.Text)]
    public string DebitGL { set; get; }

    [ValidationDataFormName("LOCATION")]
    [ValidationElementProperty("locationId")]
    [ValidationDataType(DataType.Text)]
    public string Location { set; get; }

    [ValidationColID("unapplied")]
    [ValidationDataFormName("RECEIVED")]
    [ValidationElementProperty("amount")]
    [ValidationDataType(DataType.Text)]
    public string Received { set; get; }

    [ValidationIgnoreInGrid(true)]
    [ValidationDataFormName("APPLY_DATE")]
    [ValidationElementProperty("applyDate")]
    [ValidationDataType(DataType.Text)]
    public string ApplyDate { set; get; }

    [ValidationDataFormName("CURRENCY")]
    [ValidationElementProperty("currencyId")]
    [ValidationDataType(DataType.Text)]
    public string Currency { set; get; }

    [ValidationDataFormName("NOTES")]
    [ValidationElementProperty("notes")]
    [ValidationDataType(DataType.TextArea)]
    public string Notes { set; get; }
}

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___PaymentList")]
public class PaymentList : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPagePaymentList()
    {
        TestInitialize(nameof(OpenPagePaymentList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckPaymentList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckPaymentList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");
                RefreshAllRows();
                ShowAllRedord();
                // call method NextBtn
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckPaymentList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckPaymentList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");
                RefreshAllRows();
                ShowAllRedord();
                Thread.Sleep(1000);
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckPaymentList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckPaymentList));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");
                RefreshAllRows();
                ShowAllRedord();
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckPaymentList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckPaymentList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");
                RefreshAllRows();
                ShowAllRedord();
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddPayment()
    {
        TestInitialize(nameof(AddPayment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPaymentFunc();
                RefreshAllRows();
                ValidateInsertedPaymentInEditScreen();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ApplyPayment()
    {
        TestInitialize(nameof(ApplyPayment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPaymentFunc();
                RefreshAllRows();
                UnAppliedAndApplied(); //TODO:NewFeature //next add payment
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * (3 / 2))]
    public void EditPayment() //TODO: After Fix bug
    {
        TestInitialize(nameof(EditPayment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                {//Add new Payment
                    AddPaymentFunc();
                    Thread.Sleep(3000);
                    RefreshAllRows();
                }
                { // find payment and edit 
                    EditPaymentFunc();
                    Thread.Sleep(2000);
                    RefreshAllRows();
                }
                //check payment with edit
                ValidateInsertedPaymentInEditScreen();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeletePayment()
    {
        TestInitialize(nameof(DeletePayment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPaymentFunc();
                Thread.Sleep(2000);
                RefreshAllRows();
                ClearAllTagList();
                ShowAllRedord();
                Delete(_PaymentEntity.Payment, "PaymentList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidatePaymentList()
    {
        TestInitialize(nameof(DetailValidatePaymentList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPaymentFunc();

                ValidateInsetedPaymentInGrid();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private void ValidateInsetedPaymentInGrid()
    {
        GoToUrl("AccountsReceivable", "PaymentList", gotoLogin: false);
        ListViewBtnValidate();
        RefreshAllRows();
        ShowAllRedord();
        ClearAllTagList();
        SearchTextInMainGrid(_PaymentEntity.Payment.Trim());
        Thread.Sleep(3000);

        var gridList = webElementAction.GetElementById("PaymentList-gridId");

        gridList.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _PaymentEntity.Payment.Trim()).Click();

        ChangeScreenPageSize(30);
        Thread.Sleep(3000);
        ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
        Thread.Sleep(2000);
        CreateValidationInGrid(colIds, _PaymentEntity);
        testPassed = true;
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInPayment()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInPayment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "AccountsReceivable", subMenu: "PaymentList", filed: "transactionDate", steps: 2, clearDataFormItemName: "transactionDate");
                validateRequiredFields.Run();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterPaymentByBeginEndDate()
    {
        TestInitialize(nameof(FilterPaymentByBeginEndDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("beginDate", "PaymentList-gridId", columnName: "Creation Date");
                filterSearch.FilterSearchInDateTimeDataType("transactionDate");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterPaymentByParent()
    {
        TestInitialize(nameof(FilterPaymentByParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("parentId", "PaymentList-gridId", columnName: "Customer");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterPaymentByProduction()
    {
        TestInitialize(nameof(FilterPaymentByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("productionIdList", "PaymentList-gridId", columnName: "Job");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterPaymentByCurrency()
    {
        TestInitialize(nameof(FilterPaymentByCurrency));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("currencyId", "PaymentList-gridId", columnName: "Currency");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterPaymentByUnApplied()
    {
        TestInitialize(nameof(FilterPaymentByUnApplied));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("UNAPPLIED");
                FilterSearch filterSearch = new FilterSearch("includeUnapplied", "PaymentList-gridId", columnName: "Status", colId: "status", replacementValue: "Unapplied");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterPaymentByApplied()
    {
        TestInitialize(nameof(FilterPaymentByApplied));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("APPLIED");
                FilterSearch filterSearch = new FilterSearch("includeApplied", "PaymentList-gridId", columnName: "Status", colId: "status", replacementValue: "Applied");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterPaymentByVoid()
    {
        TestInitialize(nameof(FilterPaymentByVoid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("VOID");
                FilterSearch filterSearch = new FilterSearch("includeVoid", "PaymentList-gridId", columnName: "Status", colId: "status", replacementValue: "Void");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterPaymentByRefundAdjustment()
    {
        TestInitialize(nameof(FilterPaymentByRefundAdjustment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("REFUND_ADJUSTMENT");
                FilterSearch filterSearch = new FilterSearch("includeRefundAdjustment", "PaymentList-gridId", columnName: "Status", colId: "status", replacementValue: "Ref/Adj");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidatePaymentInRightSideFormScreen()
    {
        TestInitialize(nameof(DetailValidatePaymentInRightSideFormScreen));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPaymentFunc();
                ValidateInsertedPaymentInRightSideForm(); //ValidatePaymentInDetailScreen();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    public PaymentEntity _PaymentEntity;
    private void AddPaymentFunc()
    {
        GoToUrl("AccountsReceivable", "PaymentList");

        _PaymentEntity = new PaymentEntity();
        RefreshAllRows();
        CloseDetail();
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));//click add btn

        if (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='ADD_A_NEW_PAYMENT']")))
        {
            ConfirmBtnCheck(dataSection: "modal");
            webElementAction.GenerateDataToRequiredFields();
            ConfirmBtnCheck(dataSection: "modal");
        }
        GenerateAndInitializeDataToPayment();
    }

    private void GenerateAndInitializeDataToPayment()
    {
        new WebElementDataGenerator(GetFormLeftSideContext());
        Thread.Sleep(2000);

        CreateAdd(_PaymentEntity);

        webElementAction.Click(By.Id("TOOL_BOX_SAVE_CHANGES_BUTTON_ID"));

        if (webElementAction.IsElementPresent(By.CssSelector(".icon-error")))
        {
            webElementAction.GenerateDataToRequiredFields(context: GetFormLeftSideContext());
            CreateAdd(_PaymentEntity);
            webElementAction.Click(By.Id("TOOL_BOX_SAVE_CHANGES_BUTTON_ID"));
        }

        Thread.Sleep(2000);
        _PaymentEntity.Payment = webElementAction.GetInputElementByDataFormItemTypeInDiv("searchCodeInput").GetAttribute("value");
        GoToUrl("AccountsReceivable", "PaymentList", gotoLogin: false);
        ClearAllTagList();
    }

    private void UnAppliedAndApplied()
    {
        //TODO:NewFeature
        SearchAndEditClick(_PaymentEntity.Payment);
        WaitForLoadingSpiner();
        webElementAction.GetElementBySpecificAttribute("data-form-item-name", "payment").Click();
        // Step 1 : Click Print Payment
        CheckPrintPayment();
        // Step 2 : Click Add Apply
        AddApplyRefundAdjustment();
        // Step 3 : Click Add Adjustment Date
        ChangeRefundAdjustmentDate();
        // Step 4 : Click Add Payment GL
        ValidateInsertedDataToARPaymentGLGrid();
    }

    private static void ValidateInsertedDataToARPaymentGLGrid()
    {
        webElementAction.Click(By.Id("TOOL_BOX_AR_PAYMENT_GL"));
        Thread.Sleep(2000);
        var grid = webElementAction.GetElementById("ARPaymentGLRecords-gridId").FindElements(By.TagName("div"))
            .Where(o => o.GetAttribute("col-id") == "glAccount").ToList();
        if (grid.Count() == 2)
            throw new Exception("Grid is null");
    }

    private void ChangeRefundAdjustmentDate()
    {
        webElementAction.Click(By.Id("CHANGE_REFUND_ADJUSTMENT_DATE"));
        Thread.Sleep(2000);
        new WebElementDataGenerator(webElementAction.GetElementBySpecificAttribute("data-form-item-name", "date"));
        ConfirmBtnCheck(dataSection: "modal");
        ConfirmBtnCheck(dataSection: "infoDialog");
    }

    private void AddApplyRefundAdjustment()
    {
        webElementAction.Click(By.Id("APPLY_REFUND_ADJUSTMENT"));
        Thread.Sleep(2000);

        ConfirmBtnCheck(dataSection: "modal");
        var dialogContext = webElementAction.GetElementBySpecificAttribute("data-section", "modal");
        webElementAction.GenerateDataToRequiredFields(context: dialogContext);
        ConfirmBtnCheck(dataSection: "modal");
        ConfirmBtnCheck(dataSection: "infoDialog");
    }


    private void CheckPrintPayment()
    {   // click btn printer and check page and close
        webElementAction.Click(By.Id("TOOL_BOX_PRINT_PAYMENTS_ID"));

        Thread.Sleep(2000);
        WaitForLoadingSpiner();
        if (webElementAction.IsElementPresent(By.CssSelector("[data-focus-lock-disabled='false']")))
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "close").Click(); //close Preview Screen
    }

    private void ValidateInsertedPaymentInEditScreen()
    {   //find payment and click edit, check all value 
        CloseDetail();
        SearchAndEditClick(_PaymentEntity.Payment);
        CreateValidation(_PaymentEntity);
    }

    private void EditPaymentFunc()
    {   //find payment and click edit, change all inputs and save
        CloseDetail();
        SearchAndEditClick(_PaymentEntity.Payment);
        GenerateAndInitializeDataToPayment();
    }
    private void CloseDetail(bool isnClose = true)
    {
        if (!isnClose) //close screen
            if (!webElementAction.IsElementPresent(By.Id("DETAIL_CONTAINER_ID")))
                webElementAction.GetElementBySpecificAttribute("data-icon-name", "detail-open").Click();
        if (isnClose) //open screen
            if (webElementAction.IsElementPresent(By.Id("DETAIL_CONTAINER_ID")))
                webElementAction.GetElementBySpecificAttribute("data-icon-name", "detail-close").Click();
    }

    private void ValidateInsertedPaymentInRightSideForm()
    {
        RefreshAllRows();
        SearchTextInMainGrid(_PaymentEntity.Payment);

        webElementAction.GetElementById("PaymentList-gridId").FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _PaymentEntity.Payment).Click();

        webElementAction.Click(By.Id("TOOL_BOX_DETAIL_BUTTON_ID"));
        Thread.Sleep(3000);
        CreateValidationInInformationBox(_PaymentEntity);
    }

    private void ValidatePaymentInDetailScreen()
    {
        RefreshAllRows();
        SearchTextInMainGrid(_PaymentEntity.Payment);

        webElementAction.GetElementById("PaymentList-gridId").FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _PaymentEntity.Payment).Click();

        CloseDetail(false);
        Thread.Sleep(2000);

        var fieldsToCheck = new Dictionary<string, string>
        {
            { "PRODUCTION", _PaymentEntity.Job },
            { "LOCATION", _PaymentEntity.Location },
            { "PAYMENT_TYPE", _PaymentEntity.PaymentType },
            { "CHECK_NO", _PaymentEntity.Check },
            { "AR_TYPE", _PaymentEntity.ARType },
            { "CREDIT_GL", _PaymentEntity.CreditGL },
            { "DEBIT_GL", _PaymentEntity.DebitGL },
            { "RECEIVED", _PaymentEntity.Received },
            { "APPLY_DATE", DateTime.ParseExact(_PaymentEntity.ApplyDate, "M/d/yyyy", null).ToString("yyyy/MM/dd") },
            { "CURRENCY", _PaymentEntity.Currency },
            { "NOTES", _PaymentEntity.Notes }
        };

        foreach (var fieldEntry in fieldsToCheck)
        {
            var field = fieldEntry.Key;
            var value = webElementAction.GetElementBySpecificAttribute("data-info-name", field).GetAttribute("data-info-value");

            if (field == "APPLY_DATE") value = value.Replace("-", "/").Substring(0, 10);
            if (value == null) value = "";

            if (!fieldEntry.Value.Contains(value))
                throw new Exception("Does not match '" + fieldEntry.Value + "' with in '" + value + "'");
        }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentList");
                RefreshRecordDataInGrid("PaymentList-gridId", columnId: "paymentNo");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}