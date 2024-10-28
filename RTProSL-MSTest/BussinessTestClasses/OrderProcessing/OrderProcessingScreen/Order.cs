using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.TestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen
{
    public class Order : BaseClass
    {
        public enum OrderType
        {
            Rental,
            Sales
        }
        public void CopyFromAKit(string kitCode, OrderType orderType)
        {
            NavigateToOrderProcessingScreen();

            if (orderType == OrderType.Rental)
            {
                GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_ORDER");
            }
            else if (orderType == OrderType.Sales)
            {
                GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_ORDER");
            }
            WaitForLoadingSpiner();

            GoToSubMenu("ACTION_TOOL_DROPDOWN", "KIT", "COPY_FROM_A_KIT");

            var rentalKitDropDown = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "kitCodeId");

            var COPY_FROM_A_KIT_Modal = webElementAction.GetElementBySpecificAttribute("data-modal-title", "COPY_FROM_A_KIT");
            var kitCodeContext = COPY_FROM_A_KIT_Modal.FindElements(By.CssSelector(".combo-auto-complete"));
            new WebElementDataGenerator().ComboAutoCompleteGenerator(kitCodeContext, kitCode); //generate data to Vendor
            webElementAction.GetInputElementByDataFormItemNameInDiv("quantity").SendKeys("1");
            ConfirmBtnCheck(dataSection: "modal", confirm: true);
            WaitForLoadingSpiner();
        }

        public string AddKitList(OrderType orderType)
        {
            if (orderType == OrderType.Rental)
            {
                GoToUrl("MMInventory", "RentalKitList", gotoLogin: false);
            }
            else if (orderType == OrderType.Sales)
            {
                GoToUrl("MMInventory", "SalesKitList", gotoLogin: false);
            }

            WaitForLoadingSpiner();
            // click on btn add in page DispatchStatusList Entry Screen
            webElementAction.GetElementById("TOOL_BOX_ADD_BUTTON_ID").Click();

            // context of inputs 
            var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

            // Generate Data to formLeft side 
            var webElementDataGenerator = new WebElementDataGenerator(context);
            webElementAction.DeSelectingCheckbox("inactive");
            string kitCode = webElementAction.GetInputElementByDataFormItemNameInDiv("id").GetAttribute("value");
            webElementAction.ClearValueInAutoComboGrid("currencyId");
            SaveAndConfirmCheck();
            return kitCode;
        }

        public void VaidateInsertedKit(string kitCode, OrderType orderType)
        {
            IWebElement kitListGrid = default;
            if (orderType == OrderType.Sales)
            {
                kitListGrid = webElementAction.GetElementById("SalesItems-gridId");
                FindColumnInMainGrid(ColumnValue: "Kit", gridId: "SalesItems-gridId");
            }
            else if (orderType == OrderType.Rental)
            {
                kitListGrid = webElementAction.GetElementById("rentalItems-gridId");
                FindColumnInMainGrid(ColumnValue: "Kit", gridId: "rentalItems-gridId");
            }

            WaitForLoadingSpiner();
            Thread.Sleep(2000);

            var kitCodeElement = kitListGrid.FindElements(By.TagName("div")).FirstOrDefault(o => o.Text == kitCode);
            if (kitCodeElement == null)
                throw new Exception("The kitCode inserted in the kit list page was not found !!!");
        }

        public string SaveAsOrderTruck(OrderType orderType)
        {
            if (orderType == OrderType.Sales)
            {
                GoToSubMenu("ACTION_TOOL_DROPDOWN", "-TRUCK", "SAVE_AS_SALES_TRUCK");
            }
            else if (orderType == OrderType.Rental)
            {
                GoToSubMenu("ACTION_TOOL_DROPDOWN", "-TRUCK", "SAVE_AS_RENTAL_TRUCK");
            }
            var newOrderTruckForm = webElementAction.GetElementByCssSelector(".advance-left-section");
            new WebElementDataGenerator(newOrderTruckForm);
            string truckCode = webElementAction.GetElementByName("truckCode").GetAttribute("value");
            ConfirmBtnCheck(dataSection: "modal");
            return truckCode;
        }

        public string AddOrderTruck(OrderType orderType)
        {

            if (orderType == OrderType.Sales)
            {
                GoToSubMenu("SALES_TOOL_DROPDOWN", "SALES_ORDER");
                WaitForLoadingSpiner();
                GoToSubMenu("ACTION_TOOL_DROPDOWN", "-TRUCK", "ADD_SALES_TRUCK");
            }
            else if (orderType == OrderType.Rental)
            {
                GoToSubMenu("RENTAL_TOOL_DROPDOWN", "RENTAL_ORDER");
                WaitForLoadingSpiner();
                GoToSubMenu("ACTION_TOOL_DROPDOWN", "-TRUCK", "ADD_RENTAL_TRUCK");
            }
            WaitForLoadingSpiner();
            var newOrderTruckForm = webElementAction.GetElementByCssSelector(".advance-left-section");
            new WebElementDataGenerator(newOrderTruckForm);

            var truckCode = GetTruckCodeInModal(orderType);

            ConfirmBtnCheck(dataSection: "modal");
            CheckErrorDialogBox();
            return truckCode;
        }

        public void NavigateToOrderProcessingScreen(bool gotoLogin = false)
        {
            GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin);
            WaitForLoadingSpiner();
        }

        private string GetTruckCodeInModal(OrderType orderType)
        {
            var formSelector = ".advance-left-section";
            var truckIdFieldName = orderType == OrderType.Rental ? "rentalTruckId" : "truckId";
            var truckCode = webElementAction.GetInputElementByDataFormItemNameInDiv(truckIdFieldName).GetAttribute("value");
            return truckCode;
        }
    }
}
