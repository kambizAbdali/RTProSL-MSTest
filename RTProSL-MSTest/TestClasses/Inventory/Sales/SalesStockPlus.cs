// developed by Kambiz Abdali

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
using static RTProSL_MSTest.TestClasses.Inventory.Sales.SalesStock;

namespace RTProSL_MSTest.TestClasses.Inventory.Sales;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Sales")]
public class SalesStockPlus : BaseClass
{
    public class SalesStockPlusEntity
    {
        public SalesStockPlusEntity()
        {
            General = new General();
            PricingGL = new PricingGL();
            Setting = new Setting();
        }
        [ValidationElementProperty("id")]
        public string StockNo { set; get; }

        [ValidationElementProperty("departmentId")]
        public string Department { set; get; }

        [ValidationElementProperty("categoryId")]
        public string Category { set; get; }

        [ValidationElementProperty("sku")]
        public string SKU { set; get; }

        public string Description { set; get; }

        [ValidationDataType(DataType.CheckBox)]
        public bool Inactive { set; get; }

        [ValidationTabClick("GENERAL")]
        public General General { set; get; }


        [ValidationTabClick("PRICING_GL")]
        public PricingGL PricingGL { set; get; }

        [ValidationTabClick("SETTING")]
        public Setting Setting { set; get; }
    }

    public class PricingGL
    {

        [ValidationElementProperty("restockPct")]
        public string RestockingPercent { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationElementProperty("glIncomeId")]
        public string GlIncome { set; get; }

        [ValidationElementProperty("glCostOfGoodsId")]
        public string glCostOfSale { set; get; }

        [ValidationElementProperty("glInventoryId")]
        public string GlInventory { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationElementProperty("locationPriceRecords[0].cost")]
        public string locationPriceRecordsZeroCost { set; get; }
        [ValidationIgnoreInGrid]
        [ValidationElementProperty("locationPriceRecords[0].price")]
        public string locationPriceRecordsZeroPrice { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationElementProperty("locationPriceRecords[1].cost")]
        public string locationPriceRecordsOneCost { set; get; }
        [ValidationIgnoreInGrid]
        [ValidationElementProperty("locationPriceRecords[1].price")]
        public string locationPriceRecordsOnePrice { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationElementProperty("locationPriceRecords[2].cost")]
        public string locationPriceRecordsTwoCost { set; get; }
        [ValidationIgnoreInGrid]
        [ValidationElementProperty("locationPriceRecords[2].price")]
        public string locationPriceRecordsTwoPrice { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationElementProperty("locationPriceRecords[3].cost")]
        public string locationPriceRecordsThreeCost { set; get; }
        [ValidationIgnoreInGrid]
        [ValidationElementProperty("locationPriceRecords[3].price")]
        public string locationPriceRecordsThreePrice { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationElementProperty("locationPriceRecords[4].cost")]
        public string locationPriceRecordsFourCost { set; get; }
        [ValidationIgnoreInGrid]
        [ValidationElementProperty("locationPriceRecords[4].price")]
        public string locationPriceRecordsFourPrice { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationElementProperty("locationPriceRecords[5].cost")]
        public string locationPriceRecordsFiveCost { set; get; }
        [ValidationIgnoreInGrid]
        [ValidationElementProperty("locationPriceRecords[5].price")]
        public string locationPriceRecordsFivePrice { set; get; }
    }

    public class Setting
    {
        [ValidationIgnoreInGrid]
        [ValidationDataType(DataType.CheckBox)]
        public bool Taxable { set; get; }

        [ValidationDataType(DataType.CheckBox)]
        [ValidationIgnoreInGrid]
        public bool Restocking { set; get; }

        [ValidationDataType(DataType.CheckBox)]
        public bool Inventory { set; get; }

        [ValidationDataType(DataType.CheckBox)]
        [ValidationIgnoreInGrid]
        public bool PrintOnEquipPickList { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationDataType(DataType.CheckBox)]
        public bool ShowOnWebsite { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationDataType(DataType.CheckBox)]
        public bool Discountable { set; get; }

        [ValidationDataType(DataType.CheckBox)]
        public bool RepairPart { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationElementProperty("requireSerialNumber")]
        [ValidationDataType(DataType.CheckBox)]
        public bool SerialNumberRequired { set; get; }
    }


    public class General
    {
        public string Measure { set; get; }

        public string Weight { set; get; }

        [ValidationElementProperty("minOnHand")]
        public string ReorderPoint { set; get; }

        [ValidationColID("reorderQty")]
        public string ReorderQty { set; get; }

        [ValidationElementProperty("vendorId")]
        public string Vendor { set; get; }

        [ValidationElementProperty("vendorPartNo")]
        public string VendorPart { set; get; }

        public string Manufacturer { set; get; }
        public string ManufacturerPartNo { set; get; }

        [ValidationElementProperty("ownerId")]
        [ValidationIgnoreInGrid]
        public string Owner { set; get; }

        [ValidationDataType(DataType.TextArea)]
        public string Notes { set; get; }

    }

    SalesStockPlusEntity _SalesStockPlusEntity;

    // [Timeout(6000)] // سقف زمانی را به MaximumExecutionTime میلی ثانیه (10 دقیقه) تنظیم می کند

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInSalesStockPlus()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInSalesStockPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInSalesStockPlus()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInSalesStockPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInSalesStockPlus()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInSalesStockPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInSalesStockPlus()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInSalesStockPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInSalesStockPlus()
    {
        TestInitialize(nameof(CardViewBtnCheckInSalesStockPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                if (!HasRowCheck()) { testPassed = true; break; }
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInSalesStockPlus()
    {
        TestInitialize(nameof(ListViewBtnCheckInSalesStockPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddSalesStockPlusWithAllFields()
    {
        TestInitialize(nameof(AddSalesStockPlusWithAllFields));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSalesStockPlusFunc();
                ValidateInsertedSalesStockPlus();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private void SearchSalesStockInGrid(string stockNumber)
    {
        webElementAction.GetElementBySpecificAttribute("data-button-type", "filter").Click();
        webElementAction.SelectingCheckbox("includeInactive"); // include Inactive 
        webElementAction.SelectingCheckbox("includeRepairParts");  // include RepairParts

        webElementAction.GetElementBySpecificAttribute("id", "body-filter-refresh-btn").Click();

        SearchTextInMainGrid(stockNumber);
        Thread.Sleep(1000);
        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
    .FirstOrDefault(o => o.Text == stockNumber);

        webElementAction.DoubleClick(selectRow);
        WaitForLoadingSpiner();
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditSalesStockPlus()
    {
        TestInitialize(nameof(EditSalesStockPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSalesStockPlusFunc();
                ShowAllRedord();
                Thread.Sleep(500);

                SearchSalesStockInGrid(_SalesStockPlusEntity.StockNo.Trim());

                ClickOnEditBtn();

                // define context page to variable
                var context = GetFormLeftSideContext(isNested: true);

                //clear all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_SalesStockPlusEntity, context);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();
                ValidateInsertedSalesStockPlus();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    public void AddSalesStockPlusFunc()
    {
        GoToUrl("MMInventory", "SalesStock");

        ShowAllRedord();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        var context = GetFormLeftSideContext(true);

        new WebElementDataGenerator(context);
        _SalesStockPlusEntity = new SalesStockPlusEntity();
        webElementAction.DeSelectingCheckbox("inactive");
        CreateAdd(_SalesStockPlusEntity, context);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    public void ValidateInsertedSalesStockPlus()
    {
        SearchSalesStockInGrid(_SalesStockPlusEntity.StockNo.Trim());

        ClickOnEditBtn();

        var context = GetFormLeftSideContext(isNested: true);
        CreateValidation(_SalesStockPlusEntity, context);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSalesStockPlus()
    {
        TestInitialize(nameof(DeleteSalesStockPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSalesStockPlusFunc();
                ShowAllRedord();
                Delete(_SalesStockPlusEntity.StockNo, "SalesStockPlusList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateSalesStockPlus()
    {
        TestInitialize(nameof(DetailValidateSalesStockPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSalesStockPlusFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_SalesStockPlusEntity.StockNo.Trim());
                var gridList = webElementAction.GetElementById("SalesStockList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _SalesStockPlusEntity.StockNo.Trim()).Click();

                ChangeScreenPageSize(30);
                Thread.Sleep(4000);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                _SalesStockPlusEntity.PricingGL.RestockingPercent = _SalesStockPlusEntity.PricingGL.RestockingPercent.Replace("%", "");
                CreateValidationInGrid(colIds, _SalesStockPlusEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSalesStockPlusByDepartment()
    {
        TestInitialize(nameof(FilterSalesStockPlusByDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("departmentId", "SalesStockList-gridId", "Department");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSalesStockPlusByCategory()
    {
        TestInitialize(nameof(FilterSalesStockPlusByCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("categoryId", "SalesStockList-gridId", "Category");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSalesStockPlusByDescription()
    {
        TestInitialize(nameof(FilterSalesStockPlusByDescription));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("description", "SalesStockList-gridId", "Description");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSalesStockPlusByIncludeInactiveStock()
    {
        TestInitialize(nameof(FilterSalesStockPlusByIncludeInactiveStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");

                RefreshAllRows();
                DataLegendNameFilter("INACTIVE");
                FilterSearch filterSearch = new FilterSearch("includeInactive", "SalesStockList-gridId", "Inactive", colId: "inactive");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSalesStockPlusByIncludeRepairParts()
    {
        TestInitialize(nameof(FilterSalesStockPlusByIncludeRepairParts));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");

                RefreshAllRows();
                DataLegendNameFilter("REPAIRPART");
                FilterSearch filterSearch = new FilterSearch("includeRepairParts", "SalesStockList-gridId", "Repair Part", "repairPart");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInSalesStock()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSalesStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "MMInventory", subMenu: "SalesStock", filed: "description");
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
                GoToUrl("MMInventory", "SalesStock");
                RefreshRecordDataInGrid("SalesStockList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInSalesPriceCostReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSalesPriceCostReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "SALES_PRICE_COST_REPORT");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInSalesPriceCostReport()
    {
        TestInitialize(nameof(ValidateListBtnInSalesPriceCostReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "SALES_PRICE_COST_REPORT");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * 3)]
    public void ValidateExportPDFBtnInSalesPriceCostReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSalesPriceCostReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "SALES_PRICE_COST_REPORT");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInSalesPriceCostReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSalesPriceCostReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "SALES_PRICE_COST_REPORT");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInSalesPriceCostReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSalesPriceCostReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "SALES_PRICE_COST_REPORT");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInSalesPriceCostReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSalesPriceCostReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "SALES_PRICE_COST_REPORT");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInSalesPriceCostReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSalesPriceCostReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "SALES_PRICE_COST_REPORT");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    //------------------------------------------------------------------------------------------------------

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInStockBarcodeLabel()
    {
        TestInitialize(nameof(ValidatePreviewBtnInStockBarcodeLabel));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "STOCK_BARCODE_LABEL");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInStockBarcodeLabel()
    {
        TestInitialize(nameof(ValidateListBtnInStockBarcodeLabel));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "STOCK_BARCODE_LABEL");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * 3)]
    public void ValidateExportPDFBtnInStockBarcodeLabel()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInStockBarcodeLabel));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "STOCK_BARCODE_LABEL");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInStockBarcodeLabel()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInStockBarcodeLabel));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "STOCK_BARCODE_LABEL");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInStockBarcodeLabel()
    {
        TestInitialize(nameof(ValidatePrinterBtnInStockBarcodeLabel));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "STOCK_BARCODE_LABEL");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInStockBarcodeLabel()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInStockBarcodeLabel));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "STOCK_BARCODE_LABEL");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInStockBarcodeLabel()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInStockBarcodeLabel));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStock");
                RefreshAllRows();
                GoToSubMenu("PRINT", "STOCK_BARCODE_LABEL");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}