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
    public class InventoryPODetailSearch : BaseClass
    {

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPODetailSearchByFromToDate()
        {
            TestInitialize(nameof(FilterInventoryPODetailSearchByFromToDate));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPODetailSearch");

                    GetElementEquipment("equipmentId");
                    FilterSearch filterSearch = new FilterSearch("beginDate", "InventoryPODetailSearch-gridId");
                    filterSearch.FilterSearchInDateTimeDataType("date");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPODetailSearchByVendor()
        {
            TestInitialize(nameof(FilterInventoryPODetailSearchByVendor));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPODetailSearch");

                    GetElementEquipment("equipmentId");
                    FilterSearch filterSearch = new FilterSearch("vendorId", "InventoryPODetailSearch-gridId", "Vendor");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPODetailSearchByEquipment()
        {
            TestInitialize(nameof(FilterInventoryPODetailSearchByEquipment));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPODetailSearch");

                    FilterSearch filterSearch = new FilterSearch("equipmentId", "InventoryPODetailSearch-gridId", "Equipment /Stock#",colId: "id");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryPODetailSearchByStock()
        {
            TestInitialize(nameof(FilterInventoryPODetailSearchByStock));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPODetailSearch");

                    FilterSearch filterSearch = new FilterSearch("stockNoId", "InventoryPODetailSearch-gridId", "Equipment /Stock#", colId: "id");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        private void GetElementEquipment(string IdFilter)
        {
            var ContextText = webElementAction.GetElementBySpecificAttribute("data-form-item-name", IdFilter);
            new WebElementDataGenerator(ContextText);
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGrid()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryPODetailSearch");
                    RefreshRecordDataInGrid("InventoryPODetailSearch-gridId", columnId: "id");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
