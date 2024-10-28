// developed by Kambiz Abdali

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.Inventory.Sales;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Sales")]
public class SalesStock : BaseClass
{
    public class SalesStockEntity
    {
        public SalesStockEntity()
        {
            General = new General();
            PricingGL = new PricingGL();
            Setting = new Setting();
        }
        [ValidationIgnore]
        [ValidationElementProperty("id")]
        public string StockNo { set; get; }

        [ValidationElementProperty("departmentId")]
        public string Department { set; get; }

        [ValidationElementProperty("categoryId")]
        public string Category { set; get; }

        [ValidationElementProperty("sku")]
        [ValidationIgnoreInGrid]
        public string SKU { set; get; }

        public string Description { set; get; }

        [ValidationDataType(DataType.CheckBox)]
        public bool Inactive { set; get; }

        [ValidationTabClick("GENERAL")]
        public General General { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationTabClick("PRICING_GL")]
        public PricingGL PricingGL { set; get; }

        [ValidationTabClick("SETTING")]
        public Setting Setting { set; get; }
    }

    public class PricingGL
    {
        [ValidationIgnoreInGrid]
        [ValidationElementProperty("restockPct")]
        public string RestockingPercent { set; get; }

        [ValidationElementProperty("glIncomeId")]
        public string GlIncome { set; get; }
        [ValidationElementProperty("glCostOfGoodsId")]
        public string glCostOfSale { set; get; }

        [ValidationElementProperty("glInventoryId")]
        public string GlInventory { set; get; }


        [ValidationElementProperty("locationPriceRecords[0].cost")]
        public string locationPriceRecordsZeroCost { set; get; }
        [ValidationElementProperty("locationPriceRecords[0].price")]
        public string locationPriceRecordsZeroPrice { set; get; }

        [ValidationElementProperty("locationPriceRecords[1].cost")]
        public string locationPriceRecordsOneCost { set; get; }
        [ValidationElementProperty("locationPriceRecords[1].price")]
        public string locationPriceRecordsOnePrice { set; get; }


        [ValidationElementProperty("locationPriceRecords[2].cost")]
        public string locationPriceRecordsTwoCost { set; get; }
        [ValidationElementProperty("locationPriceRecords[2].price")]
        public string locationPriceRecordsTwoPrice { set; get; }


        [ValidationElementProperty("locationPriceRecords[3].cost")]
        public string locationPriceRecordsThreeCost { set; get; }
        [ValidationElementProperty("locationPriceRecords[3].price")]
        public string locationPriceRecordsThreePrice { set; get; }


        [ValidationElementProperty("locationPriceRecords[4].cost")]
        public string locationPriceRecordsFourCost { set; get; }
        [ValidationElementProperty("locationPriceRecords[4].price")]
        public string locationPriceRecordsFourPrice { set; get; }


        [ValidationElementProperty("locationPriceRecords[5].cost")]
        public string locationPriceRecordsFiveCost { set; get; }
        [ValidationElementProperty("locationPriceRecords[5].price")]
        public string locationPriceRecordsFivePrice { set; get; }
    }

    public class Setting
    {
        [ValidationIgnoreInGrid]
        [ValidationDataType(DataType.CheckBox)]
        public bool Taxable { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationDataType(DataType.CheckBox)]
        public bool Restocking { set; get; }

        [ValidationDataType(DataType.CheckBox)]
        public bool Inventory { set; get; }

        [ValidationIgnoreInGrid]
        [ValidationDataType(DataType.CheckBox)]
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

    SalesStockEntity _SalesStockEntity;
    // [Timeout(6000)] // سقف زمانی را به MaximumExecutionTime میلی ثانیه (10 دقیقه) تنظیم می کند

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInSalesStock()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInSalesStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStockSummary");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInSalesStock()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInSalesStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStockSummary");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInSalesStock()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInSalesStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStockSummary");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInSalesStock()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInSalesStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStockSummary");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInSalesStock()
    {
        TestInitialize(nameof(CardViewBtnCheckInSalesStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStockSummary");
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
    public void ListViewBtnCheckInSalesStock()
    {
        TestInitialize(nameof(ListViewBtnCheckInSalesStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStockSummary");
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
    public void AddSalesStockWithAllFields()
    {
        TestInitialize(nameof(AddSalesStockWithAllFields));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSalesStockFunc();
                ValidateInsertedSalesStock();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditSalesStock()
    {
        TestInitialize(nameof(EditSalesStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSalesStockFunc();

                Thread.Sleep(500);

                SearchSalesStockInGrid(_SalesStockEntity.StockNo.Trim());

                ClickOnEditBtn();

                // define context page to variable
                var context = GetFormLeftSideContext(isNested: true);

                //clear all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_SalesStockEntity, context);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();
                ValidateInsertedSalesStock();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    public void AddSalesStockFunc()
    {
        GoToUrl("MMInventory", "SalesStockSummary");

        ShowAllRedord();
        //click on addNewRecordBtn
        webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();

        var context = GetFormLeftSideContext(true);

        new WebElementDataGenerator(context);
        _SalesStockEntity = new SalesStockEntity();
        CreateAdd(_SalesStockEntity, context);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
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

    public void ValidateInsertedSalesStock()
    {
        SearchSalesStockInGrid(_SalesStockEntity.StockNo.Trim());
        var context = GetFormLeftSideContext(isNested: true);
        CreateValidation(_SalesStockEntity, context);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSalesStock()
    {
        TestInitialize(nameof(DeleteSalesStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSalesStockFunc();
                ShowAllRedord();
                Delete(_SalesStockEntity.StockNo, "SalesStockList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateSalesStock()
    {
        TestInitialize(nameof(DetailValidateSalesStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSalesStockFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_SalesStockEntity.StockNo.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("SalesStockSummaryList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _SalesStockEntity.StockNo.Trim()).Click();

                ChangeScreenPageSize(30);
                Thread.Sleep(3000);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                string cols_ids = default;
                foreach (var colId in colIds)
                {
                    try
                    {
                        cols_ids += colId.GetAttribute("col-id").ToString() + "_ _";
                    }
                    catch
                    {
                    }
                }


                CreateValidationInGrid(colIds, _SalesStockEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSalesStockByDepartment()
    {
        TestInitialize(nameof(FilterSalesStockByDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStockSummary");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("departmentId", "SalesStockSummaryList-gridId", "Department");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSalesStockByCategory()
    {
        TestInitialize(nameof(FilterSalesStockByCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStockSummary");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("categoryId", "SalesStockSummaryList-gridId", "Category");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSalesStockByDescription()
    {
        TestInitialize(nameof(FilterSalesStockByDescription));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStockSummary");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("description", "SalesStockSummaryList-gridId", "Description");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSalesStockByIncludeInactiveStock()
    {
        TestInitialize(nameof(FilterSalesStockByIncludeInactiveStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStockSummary");

                RefreshAllRows();
                DataLegendNameFilter("INACTIVE");
                FilterSearch filterSearch = new FilterSearch(filterId: "includeInactive", gridListId: "SalesStockSummaryList-gridId", columnName: "Inactive", colId: "inactive");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSalesStockByIncludeRepairParts()
    {
        TestInitialize(nameof(FilterSalesStockByIncludeRepairParts));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesStockSummary");

                RefreshAllRows();
                DataLegendNameFilter("REPAIRPART");
                FilterSearch filterSearch = new FilterSearch("includeRepairParts", "SalesStockSummaryList-gridId", "Repair Part", colId: "repairPart");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInSalesStockSummary()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSalesStockSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "MMInventory", subMenu: "SalesStockSummary", filed: "description");
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
                GoToUrl("MMInventory", "SalesStockSummary");
                RefreshRecordDataInGrid("SalesStockSummaryList-gridId", columnId: "id");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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
                GoToUrl("MMInventory", "SalesStockSummary");
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