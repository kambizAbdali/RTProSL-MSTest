//Developed Parsa Zakeri

using RTProSL_MSTest.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Inventory
{
    [TestCategory("PurchaseOrder")]
    [TestClass, TestCategory("PurchaseOrder___Inventory")]
    public class InventoryPODetail : BaseClass
    {
        
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPODetailByBeginEndDate()
        {
            TestInitialize(nameof(FilterInventoryPODetailByBeginEndDate));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPODetail");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("beginDate", "InventoryPODetailList-gridId");
                    filterSearch.FilterSearchInDateTimeDataType("estimatedShipDate", "estimatedArrivalDate");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPODetailByVendor()
        {
            TestInitialize(nameof(FilterInventoryPODetailByVendor));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPODetail");

                    FilterSearch filterSearch = new FilterSearch("vendorId", "InventoryPODetailList-gridId", "Vendor");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPODetailByApprovedBy()
        {
            TestInitialize(nameof(FilterInventoryPODetailByApprovedBy));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPODetail");

                    FilterSearch filterSearch = new FilterSearch("approvedBy", "InventoryPODetailList-gridId", "Approved By");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPODetailByEquipment()
        {
            TestInitialize(nameof(FilterInventoryPODetailByEquipment));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPODetail");

                    FilterSearch filterSearch = new FilterSearch("equipmentList","InventoryPODetailList-gridId", "Equipment /Stock#", colId: "equipmentStockNo");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPODetailByStock()
        {
            TestInitialize(nameof(FilterInventoryPODetailByStock));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPODetail");

                    FilterSearch filterSearch = new FilterSearch("stockNoList", "InventoryPODetailList-gridId", "Equipment /Stock#", colId: "equipmentStockNo");
                    filterSearch.FilterSearchInTextDataType();
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
                    GoToUrl("PurchaseOrder", "InventoryPO");
                    RefreshRecordDataInGrid("InventoryPODetailList-gridId", columnId: "type");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
