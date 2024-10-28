using OpenQA.Selenium;
using RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.OrderProcessing.Order.RTProSL_MSTest.TestClasses.OrderProcessing.Order.OrderSummaryList;
using System.Collections.ObjectModel;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using static RTProSL_MSTest.TestClasses.OrderProcessing.Order.RTProSL_MSTest.TestClasses.OrderProcessing.Order.OrderSummaryList.OrderSummaryList;

namespace RTProSL_MSTest.TestClasses.Administration.Tables.Production;
//developed by kambiz Abdali

public class GeneralTab
{
    [ValidationElementName("Location")] public string LocationId { get; set; }

    [ValidationElementName("Rental Agent 1")]
    public string RentalAgent1Id { get; set; }

    [ValidationElementName("Rental Agent 2")]
    public string RentalAgent2Id { get; set; }

    [ValidationElementName("Ship Method")] public string ShipMethodId { get; set; }

    [ValidationElementName("Return Method")]
    public string ReturnMethodId { get; set; }

    [ValidationIgnoreInGrid]

    [ValidationElementName("Salesperson")] public string SalespersonId { get; set; }

    [ValidationElementName("Subrental Limit Pct")]
    public string SubrentalLimitPct { get; set; }

    [ValidationElementName("Staging Count")]
    public string StagingCount { get; set; }

    [ValidationElementName("Space Color")]
    [ValidationDataType(DataType.Color)]
    public string SpaceColor { get; set; }

    [ValidationElementName("AlertNotes")] public string AlertNotes { get; set; }

    [ValidationElementName("Custom Field 1")]
    public string CustomField1Id { get; set; }

    [ValidationElementName("Custom Field 2")]
    public string CustomField2Id { get; set; }

    [ValidationElementName("Custom Field 3")]
    public string CustomField3Id { get; set; }

    [ValidationDataType(DataType.TextArea)]
    [ValidationElementName("Notes")]
    public string Notes { get; set; }
}

public class AddressTab
{
    [ValidationElementName("State in ShipState")]
    public string ShipState { get; set; }

    [ValidationElementName("Billing Address")]
    public string AddressLine1 { get; set; }

    [ValidationElementName("Billing Address 2")]
    public string AddressLine2 { get; set; }

    [ValidationElementName("Billing Address 3")]
    public string AddressLine2B { get; set; }

    [ValidationElementName("State in Address")]
    public string State { get; set; }

    [ValidationElementName("ZipCode in Address")]
    public string ZipCode { get; set; }

    [ValidationElementName("City in Address")]
    public string AddressLine3 { get; set; }

    [ValidationElementName("Country in Address")]
    public string AddressLine4 { get; set; }

    [ValidationElementName("Shipping Name in shipping")]
    public string ShippingName { get; set; }

    [ValidationElementName("Shipping Name in shipping")]
    public string Phone { get; set; }

    [ValidationElementName("Shipping Name in shipping")]
    public string Fax { get; set; }

    [ValidationElementName("Address1 in shipping")]
    public string ShippingAddressLine1 { get; set; }

    [ValidationElementName("Address2 in shipping")]
    public string ShippingAddressLine2 { get; set; }

    [ValidationElementName("Address3 in shipping")]
    public string ShippingAddressLine2B { get; set; }

    [ValidationElementName("city in shipping")]
    public string ShippingAddressLine3 { get; set; }
}

public class BillingTab
{
    [ValidationElementName("Billing Contact")]
    public string ContactAcct { get; set; }

    [ValidationElementName("Billing Method")]
    public string BillingMethodId { get; set; }

    [ValidationElementName("Revenue Goal")]
    public string RevenueGoal { get; set; }

    [ValidationElementName("Credit Thru")] public string CreditThru { get; set; }

    [ValidationElementName("credit Limit")]
    public string CreditLimit { get; set; }

    [ValidationElementName("job Component")]
    public string JobComponentId { get; set; }

    [ValidationElementName("Expected Wrap Date")]
    public string ExtendedWrapDate { get; set; }

    [ValidationElementName("Terms")] public string TermsId { get; set; }

    [ValidationElementName("Current PO")] public string CurrentPo { get; set; }

    [ValidationElementName("Payment Type")]
    public string PaymentTypeId { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    public bool PoRequired { get; set; }


    [ValidationDataType(DataType.CheckBox)]
    public bool CreditApproved { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementName("Signed Terms & Conditions")]
    public bool SignedTerms { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementName("CreditHold")]
    public bool CreditHold { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementName("Upload Include")]
    public bool UploadInclude { get; set; }
}

public class InsuranceTab
{
    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationElementName("Certificate of Insurance Required")]
    public bool CertificateOfIns { get; set; }

    [ValidationElementName("Expired")] public string Expiration { get; set; }

    [ValidationElementName("InsAmount")] public string Amount { get; set; }

    [ValidationElementName("InsCo")] public string Company { get; set; }

    [ValidationElementName("InsPolicy")] public string PolicyNo { get; set; }

    public string DeductibleAmount { get; set; }
    public string InsuranceType { get; set; }
    [ValidationIgnore(true, BaseClass.IgnoreType.Validation)] //TODO resolve this
    public bool Inactive { get; set; }
}

public class ContactTab
{
    [ValidationColID("id")]
    [ValidationElementName("Contact")]
    public string Id { get; set; }

    [ValidationColID("name")] public string Name { get; set; }

    public string Phone { get; set; }

    [ValidationElementName("Contact Title")]
    public string Title { get; set; }

    public string Email { get; set; }
    public string CellPhone { get; set; }
    public bool EmailInclude { get; set; }

    [ValidationElementName("Rentex Email Invoicing Contact")]
    public bool RentexAutoInvoiceReceiveEmail { get; set; }

    public bool WebProductionAccess { get; set; }

    public bool WebQuote { get; set; }
    public bool WebCheckoutSheet { get; set; }
    public bool WebCheckinSheet { get; set; }
    public bool WebInvoice { get; set; }
    public bool WebAR { get; set; }
}

public class PriceTab
{
    [ValidationElementName("TaxType")] public string TaxTypeId { get; set; }

    [ValidationElementName("Days Per Week")]
    public string DaysPerWeek { get; set; }

    [ValidationElementName("Charge Type")] public string ChargeTypeId { get; set; }

    [ValidationElementName("Daily Weekly")]
    [ValidationDataType(DataType.DropDown)]
    public string DailyWeekly { get; set; }

    [ValidationElementName("Rental Disc")]
    public string DiscountPercentage { get; set; }

    [ValidationElementName("Rental List Price Markup%")]
    public string RentalListPriceMarkupPct { get; set; }

    [ValidationElementName("Sales List Price Markup%")]
    public string SalesListPriceMarkupPct { get; set; }

    [ValidationElementName("Sales Disc%")] public string SalesDiscPct { get; set; }

    [ValidationElementName("Rental Price List")]
    public string RentalPriceListId { get; set; }

    [ValidationElementName("Sales Price List")]
    public string SalesPriceListId { get; set; }

    [ValidationElementName("Restocking%")] public string RestockPct { get; set; }
}
//      
//      

public class ProductionEntity
{
    public ProductionEntity()
    {
        InsuranceTab = new InsuranceTab();
        GeneralTab = new GeneralTab();
        AddressTab = new AddressTab();
        BillingTab = new BillingTab();
        ContactTab = new ContactTab();
        PriceTab = new PriceTab();
    }

    [ValidationElementName("Production Code")]
    [ValidationLocatorType(LocatorType.Name)]
    public string Id { get; set; }

    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationElementName("Parent Id")]
    [ValidationLocatorType(LocatorType.Name)]
    public string ParentId { get; set; }

    [ValidationElementName("Production Type")]
    public string ProductionTypeId { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    public bool QuoteOnly { get; set; }

    [ValidationDataType(DataType.DropDown)]
    [ValidationLocatorType(LocatorType.Name)]
    public string ProductionStatus { get; set; }

    [ValidationElementName("Production Title")]
    public string ProductionTitle { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    public bool Inactive { get; set; }

    [ValidationIgnore] public string SapCustomerId { get; set; }

    [ValidationTabClick("GENERAL")] public GeneralTab GeneralTab { get; set; }


    [ValidationTabClick("ADDRESS")] public AddressTab AddressTab { get; set; }

    [ValidationTabClick("PRICING")] public PriceTab PriceTab { get; set; }

    [ValidationTabClick("BILLING")] public BillingTab BillingTab { get; set; }

    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    public InsuranceTab InsuranceTab { get; set; }

    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    public ContactTab ContactTab { get; set; }

    /*
    public string CreationDate;
       public string CreateBy;
         public string HasDeposit;
         public string ContactCell;
         public string ShippingAcctNo;
         public string ParamPrintDetail;
         public string ParamChargeNo;
         public string ParamDebitGlAccount;
         public string ParamOnLotLocation;
         public string ManagingDepartmentId;
         public string MbsCustomerClassId;
         public string MbsCustomerGroupId;
         public string FattMerchantId;
         public string RentexAutoGenerateInvoice;
         public string RentexAutoGenerateInvoiceAutoEmail;
         public string RentexAutoGenerateInvoiceBillAt;
         public string ProdTypeDesc;
         public string Wbarid;
         public string WbCompanyDebit;
         public string WbCostCenterDebit;
         public string WbGlAccountDebit;
         public string WbInternalOrderDebit;
         public string WbProfitCenterDebit;
         public string WbSetUnitDebit;
         public string WbwbsElementDebit;
         public string History;
         public string WbSetUnit;
         public string FoxProjectId;
         public string ContactTypeId;
         public string FoxResType;
         public string FoxResCat;
         public string FoxResSubCat;
         public string FoxBusUnitPc;
         public string FoxMarket;
         public string FoxCatNo;
         public string FoxBusUnitGl;
         public string FoxDivision;
         public string FoxAccountId;
         public string FoxDeptId;
         public string FoxAffiliate;
         public string FoxPo;
         public string FoxStn;
         public string AddressLine5;
         public string Picture;
         public string Name;

         public string LastRevised;
         public string LastRevisedBy;
         public string LastActivity;
         public string Email;
         public string BillingType;
         public string CloseDate;
         public string ShipCityStateZip;
         public string ParentName;
   */
}

[TestCategory("Administration")]
[TestClass, TestCategory("Administration___Tables")]
public class Production : BaseClass
{
    private ProductionEntity _productionEntity;

    [TestMethod, Timeout(MaximumExecutionTime * 2)]
    public void AddProduction()
    {
        TestInitialize(nameof(AddProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddProductionFunc();
                SearchAndEditClick(_productionEntity.Id.Trim());
                ValidateInsertedProductionInGridList();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private void ValidateInsertedProductionInGridList()
    {
        /* webElementAction.ValueValidatation(DataType.Text, LocatorType.Name, null, "parentId", "parent Id",
              _productionEntity.Id, "");*/

        ClickTab("INSURANCE");

        WaitForLoadingSpiner();
        Thread.Sleep(1000);
        InsuranceTab currentInsuranceTab = new InsuranceTab(); ;

        var insuranceColIds = webElementAction.GetElementById("Insurance-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
        currentInsuranceTab.CertificateOfIns =
            webElementAction.GetCheckBoxStatusInDataFormContext("certificateOfIns");
        CreateAddInGrid(currentInsuranceTab, insuranceColIds);
        ValidateEntityFieldDifferences(_productionEntity.InsuranceTab, currentInsuranceTab);

        //**************************generate data to CONTACTS tab*************************************

        ClickTab("CONTACTS");
        ContactTab currentContactTab = new ContactTab();

        var contactColIds = webElementAction.GetElementById("ProductionContactList-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//

        CreateAddInGrid(currentContactTab, contactColIds, true);
        ValidateEntityFieldDifferences(_productionEntity.ContactTab, currentContactTab);

        var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");
        CreateValidation(_productionEntity, context);

    }

    public ProductionEntity AddProductionFunc(bool callFromOrderProcessing = false)
    {
        IWebElement context;
        _productionEntity = new ProductionEntity();
        if (!callFromOrderProcessing)
        {
            GoToUrl("Administration", "Production");
            //click on addNewRecordBtn
            Thread.Sleep(500);
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();

            context = webElementAction.GetElementBySpecificAttribute("data-form-name", "ADD_NEW_PRODUCTION_FORM");
            new WebElementDataGenerator(context);
            _productionEntity.ParentId = webElementAction.GetInputElementByDataFormItemNameInDiv("parentId", context)
                .GetAttribute("value"); //
                                        // _productionEntity.Id = webElementAction.GetElementByName("id", context).GetAttribute("value");

            context = webElementAction.GetElementByCssSelector(".main-modal.undefined");
            webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", context).Click();
            Thread.Sleep(2000);
        }


        if (webElementAction.GetAllElementBySpecificAttribute("class", "main-modal undefined").Any())
        {
            context = webElementAction.GetAllElementBySpecificAttribute("class", "main-modal undefined")[1];
            new WebElementDataGenerator(context);
            _productionEntity.SapCustomerId = webElementAction
                .GetElementBySpecificAttribute("class", "information-container", context)
                .FindElement(By.TagName("span")).Text;
            webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", context).Click();
        }

        //*********************generate data to general tab*************************************
        context = GetFormLeftSideContext(isNested: true);
        new WebElementDataGenerator(context);

        webElementAction.DeSelectingCheckbox("quoteOnly", context);

        //*******************generate data to INSURANCE tab*************************************
        IWebElement insuranceContext = GenerateDataToInsuranceTab();
        //**************************generate data to CONTACTS tab*************************************

        ClickTab("CONTACTS");

        var contactContext = GetTabContext("CONTACTS");
        //delete all contacts
        DeleteAllRowsInMinGrid(contactContext, dataHeaderName: "ProductionContactList-MiniGrid");


        //add contact btn
        webElementAction.GetElementById("MINI_GRID_ADD_MULTI_SELECTION_BUTTON").Click();
        //click on refresh btn
        webElementAction.GetElementByCssSelector(".multi-select-container .icon-refresh").Click();
        var addcontactModal =
            webElementAction.GetElementBySpecificAttribute("data-modal-title", "CONTACT");

        var contactRows = webElementAction.GetAllElementsByCssSelector(
       "[role='row']", addcontactModal);
        webElementAction.DoubleClick(contactRows[1]);

        //click on confirm btn 
        webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", addcontactModal).Click();


        var contactColIds = webElementAction.GetElementById("ProductionContactList-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
        CreateAddInGrid(_productionEntity.ContactTab, contactColIds);

        ClickTab("BILLING");

        _productionEntity.BillingTab.CreditHold = webElementAction.DeSelectingCheckbox("creditHold");

        CreateAdd(_productionEntity);
        //click on saveAndCloseBtn and check confirm

        // If we want to add a order to the production, the inActive checkbox must be false


        if (callFromOrderProcessing)
        {
            ClickTab("INSURANCE");
            insuranceContext = GetTabContext("INSURANCE");

            Thread.Sleep(2000);

            _productionEntity.Inactive = webElementAction.DeSelectingCheckbox("inactive");
        }

        SaveAndConfirmCheck();

        return _productionEntity;
    }

    private IWebElement GenerateDataToInsuranceTab()
    {
        ClickTab("INSURANCE");

        Thread.Sleep(2000);

        _productionEntity.InsuranceTab.CertificateOfIns =
            webElementAction.GetCheckBoxStatusInDataFormContext("certificateOfIns");

        var insuranceContext = GetTabContext("INSURANCE");

        DeleteAllRowsInMinGrid(insuranceContext, "Insurance-MiniGrid");

        webElementAction.GetElementBySpecificAttribute("data-icon-name", "add", insuranceContext).Click();
        var addInsuranceModal =
            webElementAction.GetElementBySpecificAttribute("data-modal-title", "INSURANCE_DETAIL");
        new WebElementDataGenerator(addInsuranceModal, true);

        Thread.Sleep(1000);
        //click on confirm btn
        webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", addInsuranceModal).Click();

        WaitForLoadingSpiner();

        //Sometimes the focus may not be on the line and it is necessary to click on one of the columns.
        webElementAction.GetElementByCssSelector("[col-id='company']:not(:has(input), :has(div))").Click();

        Thread.Sleep(3000);
        var InsuranceColIds = webElementAction.GetElementById("Insurance-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
        Thread.Sleep(3000);
        CreateAddInGrid(_productionEntity.InsuranceTab, InsuranceColIds);
        return insuranceContext;
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteProduction()
    {
        TestInitialize(nameof(DeleteProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddProductionFunc();
                ShowAllRedord();
                RefreshAllRows();
                Delete(_productionEntity.Id, "ProductionList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInProduction()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");
                RefreshAllRows();
                ShowAllRedord();
                if (!HasRowCheck()) { testPassed = true; break; }
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInProduction()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");
                RefreshAllRows();
                ShowAllRedord();
                if (!HasRowCheck()) { testPassed = true; break; }
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInProduction()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");
                RefreshAllRows();
                ShowAllRedord();
                if (!HasRowCheck()) { testPassed = true; break; }
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInProduction()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");
                RefreshAllRows();
                ShowAllRedord();
                if (!HasRowCheck()) { testPassed = true; break; }
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInProduction()
    {
        TestInitialize(nameof(ListViewBtnCheckInProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");
                RefreshAllRows();
                ShowAllRedord();
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ThumbnailViewBtnCheckInProduction()
    {
        TestInitialize(nameof(ThumbnailViewBtnCheckInProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");
                RefreshAllRows();
                ShowAllRedord();
                ThumbnailViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInProduction()
    {
        TestInitialize(nameof(CardViewBtnCheckInProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");
                RefreshAllRows();
                ShowAllRedord();
                if (!HasRowCheck()) { testPassed = true; break; }
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime + (MaximumExecutionTime / 2))]
    public void DetailValidateProduction()
    {
        TestInitialize(nameof(DetailValidateProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddProductionFunc();
                _productionEntity.GeneralTab.SubrentalLimitPct = _productionEntity.GeneralTab.SubrentalLimitPct.Replace("%", "");
                _productionEntity.PriceTab.RentalListPriceMarkupPct = _productionEntity.PriceTab.RentalListPriceMarkupPct.Replace("%", "");
                _productionEntity.PriceTab.SalesListPriceMarkupPct = _productionEntity.PriceTab.SalesListPriceMarkupPct.Replace("%", "");
                _productionEntity.PriceTab.SalesDiscPct = _productionEntity.PriceTab.SalesDiscPct.Replace("%", "");
                _productionEntity.PriceTab.RestockPct = _productionEntity.PriceTab.RestockPct.Replace("%", "");

                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_productionEntity.Id.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("ProductionList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _productionEntity.Id.Trim()).Click();

                ChangeScreenPageSize(10);
                Thread.Sleep(3000);
                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                Thread.Sleep(2000);
                CreateValidationInGrid(colIds, _productionEntity);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime + (MaximumExecutionTime / 2))]
    public void EditProduction()
    {
        TestInitialize(nameof(EditProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddProductionFunc();

                SearchAndEditClick(_productionEntity.Id);
                CreateAdd(_productionEntity);

                //********generate data to Insurance tab***********
                GenerateDataToInsuranceTab();

                //********generate data to CONTACTS tab***********
                GenerateDataToContactTab();

                SaveAndConfirmCheck();

                SearchAndEditClick(_productionEntity.Id.Trim());
                ValidateInsertedProductionInGridList();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime * 2)]
    public void AddProductionWithGridContact()  // This test has an front-end error: row focus of insurance tab 
    {
        TestInitialize(nameof(AddProductionWithGridContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddProductionWithGridContactFunc();
                SearchAndEditClick(_productionEntity.Id.Trim());
                ValidateInsertedProductionInGridList();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private void AddProductionWithGridContactFunc()
    {
        GoToUrl("Administration", "Production");
        _productionEntity = new ProductionEntity();
        //click on addNewRecordBtn
        Thread.Sleep(500);
        webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();
        var context = webElementAction.GetElementBySpecificAttribute("data-form-name", "ADD_NEW_PRODUCTION_FORM");
        new WebElementDataGenerator(context);
        _productionEntity.ParentId = webElementAction.GetInputElementByDataFormItemNameInDiv("parentId", context)
            .GetAttribute("value"); //
                                    // _productionEntity.Id = webElementAction.GetElementByName("id", context).GetAttribute("value");

        context = webElementAction.GetElementByCssSelector(".main-modal.undefined");
        webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", context).Click();
        Thread.Sleep(2000);


        if (webElementAction.GetAllElementBySpecificAttribute("class", "main-modal undefined").Any())
        {
            context = webElementAction.GetAllElementBySpecificAttribute("class", "main-modal undefined")[1];
            new WebElementDataGenerator(context);
            _productionEntity.SapCustomerId = webElementAction
                .GetElementBySpecificAttribute("class", "information-container", context)
                .FindElement(By.TagName("span")).Text;
            webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", context).Click();
        }

        //**************************generate data to top section*************************************

        context = GetFormLeftSideContext(isNested: true);
        new WebElementDataGenerator(context);
        CreateAdd(_productionEntity, context);

        //**************************generate data to CONTACTS tab*************************************
        GenerateDataToContactTab();

        //*******************generate data to INSURANCE tab*************************************
        ClickTab("INSURANCE");

        Thread.Sleep(2000);

        _productionEntity.InsuranceTab.CertificateOfIns =
            webElementAction.GetCheckBoxStatusInDataFormContext("certificateOfIns");

        var insuranceContext = GetTabContext("INSURANCE");

        DeleteAllRowsInMinGrid(insuranceContext, "Insurance-MiniGrid");

        webElementAction.GetElementBySpecificAttribute("data-icon-name", "add", insuranceContext).Click();
        var addInsuranceModal =
            webElementAction.GetElementBySpecificAttribute("data-modal-title", "INSURANCE_DETAIL");
        new WebElementDataGenerator(addInsuranceModal, true);

        //click on confirm btn
        webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", addInsuranceModal).Click();

        WaitForLoadingSpiner();
        Thread.Sleep(3000);
        var InsuranceColIds = webElementAction.GetElementById("Insurance-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
        CreateAddInGrid(_productionEntity.InsuranceTab, InsuranceColIds);
        SaveAndConfirmCheck();
    }

    private void GenerateDataToContactTab()
    {
        ClickTab("CONTACTS");

        var contactContext = GetTabContext("CONTACTS");

        //delete all contacts
        DeleteAllRowsInMinGrid(contactContext, dataHeaderName: "ProductionContactList-MiniGrid");

        //add contact btn
        webElementAction.GetElementBySpecificAttribute("id", "MINI_GRID_ADD_BUTTON", contactContext).Click();

        Thread.Sleep(2000);
        var newRowColsContext = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row");
        new WebElementDataGenerator(newRowColsContext, true);

        //fill all checkboxes in row
        var checkboxElements = newRowColsContext.FindElements(By.TagName("input")).Where(element => element.GetAttribute("type") == "checkbox").ToList();
        new WebElementDataGenerator().CheckboxGenerator(checkboxElements);
        webElementAction.ClickOnPostBtnInMinGrid(gridId: "ProductionContactList-MiniGrid-gridId");

        var contactColIds = webElementAction.GetElementById("ProductionContactList-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//

        Thread.Sleep(3000);
        contactColIds = webElementAction.GetElementById("ProductionContactList-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));
        CreateAddInGrid(_productionEntity.ContactTab, contactColIds, true);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterProductionByParent()
    {
        TestInitialize(nameof(FilterProductionByParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("parentId", "ProductionList-gridId", "Parent");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterProductionByContact()
    {
        TestInitialize(nameof(FilterProductionByContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("contactId", "ProductionList-gridId", "Checkout Contact", "contactOut");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterProductionBySalesperson()
    {
        TestInitialize(nameof(FilterProductionBySalesperson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("salespersonId", "ProductionList-gridId", "Salesperson");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterProductionByRentalAgent()
    {
        TestInitialize(nameof(FilterProductionByRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("rentalAgentId", "ProductionList-gridId", "Rental Agent1");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterProductionByIncludeClosed()
    {
        TestInitialize(nameof(FilterProductionByIncludeClosed));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");

                //Filter Production

                RefreshAllRows();
                DataLegendNameFilter("CLOSED");

                FilterSearch filterSearch = new FilterSearch("includeClosed", "ProductionList-gridId", "Production Status", colId: "productionStatus", replacementValue: "Closed");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterProductionByIncludeHistory()
    {
        TestInitialize(nameof(FilterProductionByIncludeHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("includeHistory", "ProductionList-gridId", "History", colId: "history");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInProduction()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "Administration", subMenu: "Production", filed: "productionTypeId", steps: 2);
                validateRequiredFields.Run();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void PostContactErrorMessageInProduction()
    {
        TestInitialize(nameof(PostContactErrorMessageInProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");

                //click on addNewRecordBtn
                webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();

                GenerateDataToMainDialogBox();

                ClickTab("CONTACTS");
                var contactContext = GetTabContext("CONTACTS");

                //add contact btn
                webElementAction.GetElementBySpecificAttribute("id", "MINI_GRID_ADD_BUTTON", contactContext).Click();

                Thread.Sleep(2000);
                var newRowColsContext = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row");
                new WebElementDataGenerator(newRowColsContext, true);

                NavigateToHomePage();

                ValidateMessageBoxForPostContact();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private void ValidateMessageBoxForPostContact()
    {
        string textMessage = "The Contact has not been posted";

        var errorMessageDialogBox = webElementAction.GetAllElementsByTagName("div")
             .FirstOrDefault(element => element.GetAttribute("innerText").Contains(textMessage));

        if (errorMessageDialogBox == null)
            throw new Exception("Error: Message box 'The Contact has not been posted'  did not display");
    }

    private void GenerateDataToMainDialogBox()
    {
        var context = webElementAction.GetElementBySpecificAttribute("data-section", "modal");
        new WebElementDataGenerator(context);
        ConfirmBtnCheck(dataSection: "modal");
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void VerifyInsuranceValidationFromParent()  //
    {
        TestInitialize(nameof(VerifyInsuranceValidationFromParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Parent");
                FindColumnInMainGrid("Insurance Amount");
                GridSortDescendingByColId("insAmount");

                var firstColElement = GetFirstColElement("insAmount", "ParentList-gridId");
                webElementAction.DoubleClick(firstColElement);

                WaitForLoadingSpiner();

                ClickTab("INSURANCE");

                InsuranceTab parentInsuranceTab = new InsuranceTab();
                parentInsuranceTab.Expiration = webElementAction.GetInputElementByDataFormItemNameInDiv("insuranceExpired").GetAttribute("value");
                parentInsuranceTab.Amount = webElementAction.GetInputElementByDataFormItemNameInDiv("insAmount").GetAttribute("value");
                parentInsuranceTab.Company = webElementAction.GetInputElementByDataFormItemNameInDiv("insCo").GetAttribute("value");
                parentInsuranceTab.PolicyNo = webElementAction.GetInputElementByDataFormItemNameInDiv("insPolicy").GetAttribute("value");
                parentInsuranceTab.DeductibleAmount = string.Empty;
                parentInsuranceTab.InsuranceType = string.Empty;

                var parentCode = webElementAction.GetInputElementByDataFormItemNameInDiv("id").GetAttribute("value");

                GoToUrl("Administration", "Production", gotoLogin: false);

                //click on addNewRecordBtn
                Thread.Sleep(500);
                webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();

                var parentAndProductModal = webElementAction.GetElementBySpecificAttribute("data-modal-title", "ADD_A_NEW_PRODUCTION");

                var parentContext = parentAndProductModal.FindElements(By.CssSelector(".combo-auto-complete"));

                new WebElementDataGenerator(parentAndProductModal);

                //set parentCode to parent auto-combo-grid
                new WebElementDataGenerator().ComboAutoCompleteGenerator(parentContext, searchFiter: parentCode);

                ConfirmBtnCheck(dataSection: "modal");

                ClickTab("INSURANCE");

                var insuranceColIds = webElementAction.GetElementById("Insurance-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//

                InsuranceTab productionInsuranceTab = new InsuranceTab();

                CreateAddInGrid(productionInsuranceTab, insuranceColIds);

                ValidateEntityFieldDifferences(parentInsuranceTab, productionInsuranceTab);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    private IWebElement GetFirstColElement(string coId, string gridId)
    {
        var gridList = webElementAction.GetElementById(gridId);
        IWebElement ColElement = gridList.FindElements(By.TagName("div")).Where(o => o.GetAttribute("col-id") == coId).ElementAt(1);
        return ColElement;
    }

    [TestMethod, Timeout(MaximumExecutionTime * 2)]
    public void AddOrderToProduction()
    {
        TestInitialize(nameof(AddOrderToProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");

                RefreshAllRows();

                ClickOnDetailEntryScreen();

                GoToSubMenu("PRODUCTION_ACTION_DROP_DOWN", "ADD_NEW_ORDER");

                OrderSummaryList order = new OrderSummaryList();
                order.AddOrderFunc(addContactTypeIsGrid: true, callOrderFrom: OrderSource.Production);
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
                GoToUrl("Administration", "Production");
                RefreshRecordDataInGrid("ProductionList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrintMailingLabelsReport()
    {
        TestInitialize(nameof(ValidatePrintMailingLabelsReport));
        while (!testPassed && retryCount < maxRetries)
        {
            try
            {
                GoToUrl("Administration", "Production");
                RefreshAllRows();
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReportSubMenu(menu: "PRINT_TOOL_DROPDOWN", subMenu: "PRINT_MAILING_LABELS");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
        }
    }
}

// Note 1: Production must be checked Quotes Only 
