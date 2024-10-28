//develop by Mohammad_keshvarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
namespace RTProSL_MSTest.TestClasses.Administration.Tables;

// is element class  for check  available or not available element or fields. 

// define clase  struct ParentEntity
public class ParentEntity
{
    // data struct haye zir ro dar constractor zir  call kardam ke niyaz nabashe har kodom ro be sorate joda to class parent ezafe konam
    public ParentEntity()
    {
        GeneralTab = new GeneralTab();
        AddressTab = new AddressTab();
        BillingTab = new BillingTab();
        InsuranceTab = new InsuranceTab();
        ContactTab = new ContactTab();
    }


    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    [ValidationElementProperty("productionTypeId")]
    public string ProductionType { set; get; }

    [ValidationElementProperty("name")] public string ParentName { set; get; }

    [ValidationElementProperty("rentalAgent1")]
    public string rentalAgent1Id { set; get; }

    [ValidationElementProperty("rentalAgent2")]
    public string rentalAgent2Id { set; get; }

    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool InActive { get; set; }


    [ValidationTabClick("GENERAL")] public GeneralTab GeneralTab { get; set; }

    [ValidationTabClick("ADDRESS")] public AddressTab AddressTab { get; set; }

    [ValidationTabClick("BILLING")] public BillingTab BillingTab { get; set; }

    [ValidationTabClick("INSURANCE")] public InsuranceTab InsuranceTab { get; set; }

    [ValidationIgnore()]
    [ValidationTabClick("CONTACTS")]
    public ContactTab ContactTab { get; set; }
}

// define struct GeneralTab
public class GeneralTab
{
    [ValidationElementName("CustomField 1")]
    public string customField1Id { set; get; }

    [ValidationElementName("CustomField 2")]
    public string customField2Id { set; get; }

    [ValidationElementName("Custom Field 3")]
    public string customField3Id { set; get; }

    [ValidationDataType(DataType.TextArea)]
    public string Notes { set; get; }
}

// define struct AddressEntity                                                      
public class AddressTab
{
    [ValidationElementName("Address 1")] public string addressLine1 { set; get; }

    [ValidationElementName("Address 2")] public string addressLine2 { set; get; }

    [ValidationElementName("Address 3")] public string addressLine2B { set; get; }

    [ValidationElementName("City")] public string addressLine3 { set; get; }

    public string State { set; get; }

    [ValidationElementName("Zip")] public string ZipCode { set; get; }

    [ValidationElementName("Country")] public string addressLine4 { set; get; }

    public string Phone { set; get; }

    public string Fax { set; get; }

    public string shippingName { set; get; }

    [ValidationElementName("Shipping Address 1")]
    public string shippingAddressLine1 { set; get; }

    [ValidationElementName("Shipping Address 2")]
    public string shippingAddressLine2 { set; get; }

    [ValidationElementName("Shipping Address 3")]
    public string shippingAddressLine2B { set; get; }

    [ValidationElementName("ShipCountry")] public string shippingAddressLine4 { set; get; }

    public string Email { set; get; }
}

// define struct BillingEntity
public class BillingTab
{
    public string Thru { set; get; }

    public string creditLimit { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    public bool CreditApproved { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    public bool CreditHold { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("poRequired")]
    public bool PORequired { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementName("Signed Terms & Conditions")]
    public bool SignedTerms { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("arCombined")]
    public bool ARCombined { set; get; }

    [ValidationElementProperty("dailyWeekly")]
    [ValidationDataType(DataType.DropDown)]
    public string DailyWeekly { set; get; }

    [ValidationElementProperty("daysPerWeek")]
    public string DaysperWeek { set; get; }

    [ValidationElementProperty("discountPercentage")]
    public string RentalDisc { set; get; }

    [ValidationElementProperty("salesDiscPct")]
    public string SalesDisc { set; get; }

    [ValidationElementProperty("rentalPriceListId")]
    public string RentalPriceList { set; get; }

    [ValidationElementProperty("salesPriceListId")]
    public string SalesPriceList { set; get; }


    [ValidationElementProperty("paymentTypeId")]
    public string PaymentType { set; get; }


    [ValidationDataType(DataType.DropDown)]
    public string BillingType { set; get; }

    [ValidationElementProperty("termsId")] public string Terms { set; get; }

    [ValidationElementProperty("taxTypeId")]
    public string TaxType { set; get; }

    [ValidationElementProperty("masterId")]
    public string Master { set; get; }

    [ValidationElementProperty("contactAcct")]
    public string BillingContact { set; get; }

    [ValidationElementProperty("billingMethodId")]
    public string BillingMethod { set; get; }

    [ValidationElementProperty("contactNotes")]
    [ValidationDataType(DataType.TextArea)]
    public string contactNotes { set; get; }
}

// define struct InsuranceEntity
public class InsuranceTab
{
    [ValidationElementName("Expiration")] public string InsuranceExpired { set; get; }

    [ValidationElementName("Amount")] public string InsAmount { set; get; }

    [ValidationElementName("Insurance Company")]
    public string InsCo { set; get; }

    [ValidationElementName("Policy")] public string InsPolicy { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("certificateOfIns")]
    public bool CertificateOfIns { set; get; }
}

public class ContactTab
{
    public string Id { get; set; }

    [ValidationElementProperty("name")]
    [ValidationColID("name")]
    public string ContactName { get; set; }
    public string Phone { get; set; }

    [ValidationElementName("Contact Title")]
    public string Title { get; set; }

    public string Email { get; set; }
    [ValidationColID("phone")]
    public string CellPhone { get; set; }
    public bool EmailInclude { get; set; }
}

[TestCategory("Administration")]
[TestClass, TestCategory("Administration___Tables")]
public class Parent : BaseClass
{
    //new struct 
    public ParentEntity _ParentEntity;

    public ParentEntity AddParentFunc(bool addContactTypeIsGrid = false, bool callFromOrderProcessing = false)
    {
        _ParentEntity = new ParentEntity();

        if (!callFromOrderProcessing)
        {
            GoToUrl("Administration", "Parent");
            //click on addNewRecordBtn
            webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        }

        var Contextmain =
            ObjectRepository.Driver.FindElement(By.CssSelector(".row-division.fit-width.responsiveRow.undefined"));
        // write data random in fields main
        new WebElementDataGenerator(Contextmain);

        webElementAction.DeSelectingCheckbox("inactive");

        CreateAdd(_ParentEntity);

        //-------------Generate data to Contact tab-------------------------//
        ClickTab("CONTACTS");

        var contactContext = GetTabContext("CONTACTS");
        // click on post changes btn
        webElementAction.GetElementById("TOOL_BOX_SAVE_CHANGES_BUTTON_ID").Click();

        //Credit Hold is unchecked. This will uncheck Credit Hold on all the Productions. Continue?
        if (webElementAction.IsElementPresent(By.CssSelector("[data-button-type='cancel']")))
        {
            webElementAction.GetElementBySpecificAttribute("data-button-type", "cancel").Click();
        }
        // click on edit btn
        ClickOnEditBtn();
        if (addContactTypeIsGrid)
        {
            //click on listView Btn
            webElementAction.GetElementByCssSelector("[data-header-name='ParentContactList-MiniGrid'] .icon-grid").Click();
            //add contact btn
            webElementAction.GetElementBySpecificAttribute("id", "MINI_GRID_ADD_BUTTON", contactContext).Click();

            Thread.Sleep(2000);
            var newRowColsContext = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row");
            new WebElementDataGenerator(newRowColsContext, true);

            //fill all checkboxes in row
            var checkboxElements = newRowColsContext.FindElements(By.TagName("input")).Where(element => element.GetAttribute("type") == "checkbox").ToList();
            new WebElementDataGenerator().CheckboxGenerator(checkboxElements);
            webElementAction.ClickOnPostBtnInMinGrid(gridId: "ParentContactList-MiniGrid-gridId");


            //var contactColIds = webElementAction.GetElementByCssSelector("#ParentContactList-MiniGrid-gridId")
            //    .FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//

            Thread.Sleep(3000);
            var contactColIds = webElementAction.GetElementByCssSelector("#ParentContactList-MiniGrid-gridId")
                  .FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));
            CreateAddInGrid(_ParentEntity.ContactTab, contactColIds, true);

            ConfirmBtnCheck();
        }
        else
        {
            // click on btn add new 
            webElementAction.GetElementById("MINI_GRID_ADD_MULTI_SELECTION_BUTTON").Click();
            // difane and find first row in grid 
            var defaultSelectedRow = webElementAction.GetElementByCssSelector(
                ".ag-body-vertical-content-no-gap div:nth-of-type(12) i:nth-of-type(1)");
            Thread.Sleep(3000);
            // click on first row in grid
            defaultSelectedRow.Click();
            Thread.Sleep(1000);

            // click on btn confirm 
            webElementAction.GetElementByCssSelector(".confirm-button").Click();
            Thread.Sleep(1000);
        }

        //-------------Generate data to BILLING tab-------------------------//

        ClickTab("BILLING");
        Thread.Sleep(2000);

        _ParentEntity.BillingTab.CreditHold = webElementAction.DeSelectingCheckbox("creditHold");

        // If we want to add a production to the parent, the inActive checkbox must be false
        Thread.Sleep(2000);
        _ParentEntity.InActive = webElementAction.DeSelectingCheckbox("inactive");

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
        ConfirmBtnCheck(); //It may have two confirmation steps
        ListViewBtnValidate();
        return _ParentEntity;
    }

    private void ValidateInsertParentFunc()
    {
        SearchTextInMainGrid(_ParentEntity.Code);

        Thread.Sleep(700);
        ShowAllRedord();

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _ParentEntity.Code);
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(2000);

        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();

        // moghayese
        CreateValidation(_ParentEntity);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void addParent()
    {
        TestInitialize(nameof(addParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddParentFunc();
                ValidateInsertParentFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteParent()
    {
        TestInitialize(nameof(DeleteParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddParentFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_ParentEntity.Code, "ParentList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditParent()
    {
        TestInitialize(nameof(EditParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call ParentEntity class struc
                _ParentEntity = new ParentEntity();

                GoToUrl("Administration", "Parent");

                WaitForLoadingSpiner();
                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                WaitForLoadingSpiner();
                var EditSectionContactsBtn = webElementAction.GetAllElementBySpecificAttribute("type", "button")
                    .FirstOrDefault(o => o.GetAttribute("data-tab-name") == "CONTACTS");

                var contextMain = GetFormLeftSideContext(isNested: true);
                new WebElementDataGenerator(contextMain);

                webElementAction.DeSelectingCheckbox("inactive");

                CreateAdd(_ParentEntity);

                _ParentEntity.InActive = webElementAction.DeSelectingCheckbox("inactive");

                EditSectionContactsBtn.Click();

                webElementAction.GetElementById("MINI_GRID_ADD_MULTI_SELECTION_BUTTON").Click();

                // girde samte rast delete mishe
                var SelectedGridFirstRow =
                    webElementAction.GetElementByXPath(
                        "//div[@id='SelectedMultiSelectParentContactList-gridId']//div[@class='ag-header ag-pivot-off ag-header-allow-overflow']//i[@class='icon-small-font icon-delete']");
                SelectedGridFirstRow.Click();

                Thread.Sleep(500);

                //ye record ezafe mishavad
                var defaultSelectedRow = webElementAction.GetElementByCssSelector(
                    ".ag-cell.ag-cell-not-inline-editing.ag-cell-normal-height.ag-cell-last-left-pinned.grid-icon-class.ag-cell-focus.ag-cell-value");
                defaultSelectedRow.Click();

                // confirm ok click
                Thread.Sleep(1000);
                webElementAction.GetElementByCssSelector(".confirm-button").Click();

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();
                for (int i = 0; i < 2; i++)
                    ConfirmBtnCheck();

                Thread.Sleep(2000);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _ParentEntity.Code.Trim());
                webElementAction.DoubleClick(selectRow);

                CreateValidation(_ParentEntity);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckParent()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckParent));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Parent");
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
    public void ArrowLastBtnCheckParent()
    {
        TestInitialize(nameof(ArrowLastBtnCheckParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Parent");
                ShowAllRedord();
                Thread.Sleep(1000);
                //call method arrowlastbtn
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckParent()
    {
        TestInitialize(nameof(ArrowNextBtnCheckParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Parent");
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
    public void ArrowPreviousBtnCheckParent()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Parent");
                ShowAllRedord();
                //call arrow previous
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckParent()
    {
        TestInitialize(nameof(CardViewBtnCheckParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Parent");
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
    public void ListViewtBtnCheckParent()
    {
        TestInitialize(nameof(ListViewtBtnCheckParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Parent");
                ShowAllRedord();
                //call list view btn 
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void InactiveBtnCheckParent()
    {
        TestInitialize(nameof(InactiveBtnCheckParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Parent");
                FindColumnInMainGrid("Inactive");
                InActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateParent()
    {
        TestInitialize(nameof(DetailValidateParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddParentFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_ParentEntity.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("ParentList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _ParentEntity.Code.Trim()).Click();
                ChangeScreenPageSize(35);
                Thread.Sleep(2000);
                gridList = webElementAction.GetElementById("ParentList-gridId");
                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                _ParentEntity.BillingTab.SalesDisc = _ParentEntity.BillingTab.SalesDisc.Replace("%", "");
                CreateValidationInGrid(colIds, _ParentEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddParentWithGridContact()
    {
        TestInitialize(nameof(AddParentWithGridContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddParentFunc(addContactTypeIsGrid: true);
                ValidateInsertParentFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void PostContactErrorMessageInParent()
    {
        TestInitialize(nameof(PostContactErrorMessageInParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Parent");

                //click on addNewRecordBtn
                webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();

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

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxParent()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "Administration", subMenu: "Parent", filed: "id");
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
                GoToUrl("Administration", "Parent");
                RefreshRecordDataInGrid("ParentList-gridId", columnId: "id");
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
                GoToUrl("Administration", "Parent");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReportSubMenu(menu: "PRINT", subMenu: "PRINT_MAILING_LABELS");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
        }
    }
}
//اگر یک اکویپمنت سلیبل شود و 