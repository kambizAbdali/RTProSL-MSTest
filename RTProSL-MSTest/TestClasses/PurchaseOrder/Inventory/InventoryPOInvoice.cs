//Developed Parsa Zakeri

using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Inventory
{
    [TestCategory("PurchaseOrder")]
    [TestClass, TestCategory("PurchaseOrder___Inventory")]
    public class InventoryPOInvoice : BaseClass
    {

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPOInvoiceByBeginEndDate()
        {
            TestInitialize(nameof(FilterInventoryPOInvoiceByBeginEndDate));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPOInvoiceList");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("beginDate", "InventoryPoInvoiceList-gridId");
                    filterSearch.FilterSearchInDateTimeDataType("invoiceDate");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPOInvoiceByPO()
        {
            TestInitialize(nameof(FilterInventoryPOInvoiceByPO));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPOInvoiceList");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("po", "InventoryPoInvoiceList-gridId", "PO#");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPOInvoiceByVendor()
        {
            TestInitialize(nameof(FilterInventoryPOInvoiceByVendor));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPOInvoiceList");

                    FilterSearch filterSearch = new FilterSearch("vendorId", "InventoryPoInvoiceList-gridId", "Vendor Code");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPOInvoiceByInvoice()
        {
            TestInitialize(nameof(FilterInventoryPOInvoiceByInvoice));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPOInvoiceList");

                    DataLegendNameFilter("INVOICE");
                    FilterSearch filterSearch = new FilterSearch("invoiceTypeId-0", "InventoryPoInvoiceList-gridId", "Invoice Type",
                        colId: "invoiceTypeId" , replacementValue: "Invoice");
                    filterSearch.FilterSearchInRadioButtonDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPOInvoiceByPackingSlip()
        {
            TestInitialize(nameof(FilterInventoryPOInvoiceByPackingSlip));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPOInvoiceList");

                    
                    DataLegendNameFilter("PACKING_SLIP");
                    FilterSearch filterSearch = new FilterSearch("invoiceTypeId-1", "InventoryPoInvoiceList-gridId", "Invoice Type",
                        colId: "invoiceTypeId", replacementValue: "Packing Slip");
                    filterSearch.FilterSearchInRadioButtonDataType();
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
                    GoToUrl("PurchaseOrder", "InventoryPOInvoiceList");
                    RefreshRecordDataInGrid("InventoryPoInvoiceList-gridId", columnId: "vendorId");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
