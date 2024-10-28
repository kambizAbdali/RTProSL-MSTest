using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
//using RTProSL_Test.TestClasses.Administration.Tables;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.Administration.Tables;
//developed by kambiz Abdali 

[TestCategory("Administration")]
[TestClass, TestCategory("Administration___Tables")]
public class Vendor : BaseClass
{
    private static VendorEntity _vendorEntity;

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddVendorWithAllFields()
    {
        TestInitialize(nameof(AddVendorWithAllFields));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddVendorFunc();
                ValidateInsertedVendorInGridList();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditVendor()
    {
        TestInitialize(nameof(EditVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Vendor");

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide")
                    .FindElements(By.TagName("div")).FirstOrDefault();

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);
                _vendorEntity = new VendorEntity();
                CreateAdd(_vendorEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertedVendorInGridList();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    public void AddVendorFunc()
    {
        GoToUrl("Administration", "Vendor");
        _vendorEntity = new VendorEntity();
        //click on addNewRecordBtn
        webElementAction.GetElementById("TOOL_BOX_ADD_BUTTON_ID").Click();
        var webElementDataGenerator = new WebElementDataGenerator(GetFormLeftSideContext(true));

        CreateAdd(_vendorEntity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    public void ValidateInsertedVendorInGridList()
    {
        Thread.Sleep(700);
        ShowAllRedord();

        Thread.Sleep(500);

        SearchTextInMainGrid(_vendorEntity.VendorCode.Trim());

        Thread.Sleep(500);
        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _vendorEntity.VendorCode.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        CreateValidation(_vendorEntity);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteVendor()
    {
        TestInitialize(nameof(DeleteVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddVendorFunc();
                ShowAllRedord();
                Delete(_vendorEntity.VendorCode, "VendorList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInVendor()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Vendor");
                ShowAllRedord();
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInVendor()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Vendor");
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
    public void ArrowLastBtnCheckInVendor()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Vendor");
                ShowAllRedord();
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInVendor()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Vendor");
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
    public void ListViewBtnCheckInVendor()
    {
        TestInitialize(nameof(ListViewBtnCheckInVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Vendor");
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
    public void ThumbnailViewBtnCheckInVendor()
    {
        TestInitialize(nameof(ThumbnailViewBtnCheckInVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Vendor");
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
    public void CardViewBtnCheckInVendor()
    {
        TestInitialize(nameof(CardViewBtnCheckInVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Vendor");
                ShowAllRedord();
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateVendor()
    {
        TestInitialize(nameof(DetailValidateVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddVendorFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_vendorEntity.VendorCode.Trim());

                Thread.Sleep(4000);

                var gridList = webElementAction.GetElementById("VendorList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _vendorEntity.VendorCode.Trim()).Click();
                ChangeScreenPageSize(30);
                Thread.Sleep(3000);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                _vendorEntity.GeneralTab.SalesDiscount = _vendorEntity.GeneralTab.SalesDiscount.Replace("%", "");
                _vendorEntity.GeneralTab.RentalDiscount = _vendorEntity.GeneralTab.RentalDiscount.Replace("%", "");


                CreateValidationInGrid(colIds, _vendorEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }



    public class GeneralTab
    {
        public string TaxId { set; get; } //

        [ValidationElementProperty("billingType")]
        [ValidationDataType(DataType.DropDown)]
        public string BillingCharges { set; get; } //

        public string DaysPerWeek { set; get; } //

        [ValidationDataType(DataType.DropDown)]
        public string DailyWeekly { set; get; } //

        [ValidationElementProperty("taxTypeId")]
        public string TaxType { set; get; } //

        [ValidationElementProperty("salesDiscPct")]
        public string SalesDiscount { set; get; } //


        [ValidationElementProperty("rentalDiscPct")]
        public string RentalDiscount { set; get; } //

        [ValidationElementProperty("termsId")]
        public string Terms { set; get; } //

        [ValidationDataType(DataType.TextArea)]
        public string Notes { set; get; } //
    }

    public class VendorEntity
    {
        public VendorEntity()
        {
            AddressTab = new AddressTab();
            GeneralTab = new GeneralTab();
        }

        [ValidationElementProperty("id")] public string VendorCode { set; get; } //

        [ValidationElementProperty("vendorTypeId")]

        public string VendorType { set; get; }

        [ValidationElementProperty("name")] public string VendorName { set; get; }

        [ValidationElementProperty("locationId")]
        public string Location { set; get; } //

        [ValidationElementProperty("currencyId")]
        public string Currency { set; get; } //

        [ValidationElementProperty("inactive")]
        public bool InActive { set; get; } //

        [ValidationTabClick("ADDRESS")] public AddressTab AddressTab { get; set; }

        [ValidationTabClick("GENERAL")] public GeneralTab GeneralTab { get; set; }
    }

    public class AddressTab
    {
        /// AddressTab
        [ValidationElementProperty("addressLine1")]
        public string AddressOne { set; get; }

        [ValidationElementProperty("addressLine2")]
        public string AddressTwo { set; get; }

        [ValidationElementProperty("addressLine2B")]
        public string AddressThree { set; get; }

        [ValidationElementProperty("addressLine3")] //City
        public string AddressFour { set; get; }

        [ValidationElementProperty("addressLine4")]
        public string AddressFive { set; get; } //Country


        public string State { set; get; }

        [ValidationElementProperty("zipCode")] public string Zip { set; get; }

        public string WebSite { set; get; }
        public string Contact { set; get; }
        public string Phone { set; get; }
        public string Fax { set; get; }
        public string Email { set; get; }

        [ValidationElementProperty("mbsVendorClassId")]
        public string VendorClass { set; get; }

        [ValidationElementProperty("mbsPaymentMethodId")]
        public string PaymentMethod { set; get; }

        public bool MbS1099 { set; get; }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBox()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBox));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "Administration", subMenu: "Vendor", filed: "name");
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
                GoToUrl("Administration", "Vendor");
                RefreshRecordDataInGrid("VendorList-gridId", columnId: "id");
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
                GoToUrl("Administration", "Vendor");
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