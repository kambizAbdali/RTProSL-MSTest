using AventStack.ExtentReports.Utils;
using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.TestClasses;

namespace RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen.Sales
{
    public class Sales : Order
    {
        public const int rowCountForValidate = 5;
        public string StockNumberInSalesOrder { get; set; }
        public string OrderedInSalesOrder { get; set; }
        public string SerialNumber { get; set; }
        public Sales()
        {
            equipmentCheckOutInAndBilling = new EquipmentCheckOutInAndBilling();
        }
        public EquipmentCheckOutInAndBilling equipmentCheckOutInAndBilling;

        public void AddSalesOrder(string StockNumber = default)
        {
            string salesOrderGridId = "SalesItems-gridId";
            if (webElementAction.IsElementPresent(By.Id("SALES_TOOL_DROPDOWN")))
                GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_ORDER");

            Thread.Sleep(3000);
            webElementAction.ClickOnAddNewRowInMinGrid(dataHeaderName: "SalesItems");

            if (StockNumber.IsNullOrEmpty())
            {
                webElementAction.GenerateDataToGridColId(salesOrderGridId, "stockNoId");
            }
            else
            {
                webElementAction.SetValueToAutoComboCellGrid(colId: "stockNoId", StockNumber);
            }

            FindColumnInMainGrid("GL Account", gridId: salesOrderGridId);
            webElementAction.GenerateDataToGridColId(gridId: salesOrderGridId, colId: "glAccountId");

            webElementAction.ClickOnPostBtnInMinGrid(gridId: salesOrderGridId);
            ShowAllRedord();
            WaitForLoadingSpiner();
            var colIds = webElementAction.GetElementById("SalesItems-gridId")
                .FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]")); //

            StockNumberInSalesOrder = colIds.First(o => o.GetAttribute("col-id") == "stockNoId").Text;
            OrderedInSalesOrder = colIds.First(o => o.GetAttribute("col-id") == "ordered").Text;
        }

        public void AddSalesItem(bool containSerialNumber = false)
        {
            GoToUrl("MMInventory", "SalesStockSummary", gotoLogin: false);
            RefreshAllRows();
            SearchAndEditClick(StockNumberInSalesOrder);

            if (webElementAction.IsElementPresent(By.CssSelector(".mainButton[data-tab-name='PRICING_GL'] > .position-relative")))
            {
                var pricingGlContext = GetTabContext("PRICING_GL");
                ClickTab("PRICING_GL");
                new WebElementDataGenerator(pricingGlContext);

            }

            GoToSubMenu("ACTION_TOOL_DROPDOWN", "ADD_SALES_ITEMS");

            var Quantity = webElementAction.GetInputElementByDataFormItemNameInDiv("Quantity");
            Quantity.SendKeys(RandomValueGenerator.GenerateRandomInt(2, 5));

            if (containSerialNumber)
            {
                var SerialNoElement = webElementAction.GetElementByCssSelector("[name='SerialNo']");
                //"If the serial number input element is disabled, first the checkbox for entering the serial number must be ticked."
                if (SerialNoElement.GetAttribute("disabled") != null)
                    webElementAction.GetInputElementByDataFormItemNameInDiv("EnterSerialNo").Click();
                SerialNumber = RandomValueGenerator.GenerateRandomInt(5);
                SerialNoElement.SendKeys(SerialNumber);
            }
            var addElement = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "submit-button");
            addElement.Click();
        }
    }
}
