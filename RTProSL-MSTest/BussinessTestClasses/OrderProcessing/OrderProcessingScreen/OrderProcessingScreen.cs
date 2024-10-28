// Developed By Mohammad Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses;
using RTProSL_MSTest.TestClasses.Administration.Tables;
using RTProSL_MSTest.TestClasses.Administration.Tables.Production;

//using RTProSL_Test.TestClasses.Administration.Tables;
using System.ComponentModel.DataAnnotations;

namespace RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen;

[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___Order")]
public class OrderProcessingScreen : BaseClass
{
    public void AddProductionInGridFunc()
    {
        Thread.Sleep(2000);

        webElementAction.GetElementByCssSelector(".ant-collapse > div:nth-of-type(1) .add-icon-decoration").Click();

        Thread.Sleep(2000);

        ConfirmBtnCheck();

        Thread.Sleep(2000);

        var modalContext = webElementAction.GetElementBySpecificAttribute("data-modal-title", "ADD_A_NEW_ORDER");

        do
        {
            new WebElementDataGenerator(modalContext);
            var parentValue = webElementAction.GetInputElementByDataFormItemNameInDiv("productionId").GetAttribute("value");
            if (parentValue != string.Empty) break;
        } while (true);

        webElementAction.GetElementByCssSelector(".confirm-button").Click();
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageEnterNewOrder()
    {
        TestInitialize(nameof(OpenPageEnterNewOrder));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OrderProcessingScreen");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddProductionInGrid()
    {
        TestInitialize(nameof(AddProductionInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OrderProcessingScreen");
                AddProductionInGridFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime * 2)]
    public void Add_Parent_Production_Order_Business()
    {
        TestInitialize(nameof(Add_Parent_Production_Order_Business));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OrderProcessingScreen");

                //TODO clear Order Processing Fields
                var clearOrderProcessingFields = webElementAction.GetElementByCssSelector(".icon-eraser");
                clearOrderProcessingFields.Click();

                var collapses = webElementAction.GetAllElementsByCssSelector(".ant-collapse-header");

                //*--------------------Add and validate Parent--------------------*//
                var parentCollaps = collapses[1];
                var addParentElement = parentCollaps.FindElement(By.CssSelector(".icon-add"));
                addParentElement.Click();
                ConfirmBtnCheck();
                var parentEntity = new Parent().AddParentFunc(addContactTypeIsGrid: true, callFromOrderProcessing: true);

                collapses = webElementAction.GetAllElementsByCssSelector(".ant-collapse-header");
                var productionCollaps = collapses[2];
                var addProductionElement = productionCollaps.FindElement(By.CssSelector(".icon-add"));
                addProductionElement.Click();

                var context = webElementAction.GetElementBySpecificAttribute("data-form-name", "ADD_NEW_PRODUCTION_FORM");

                var parentCode = webElementAction.GetInputElementByDataFormItemNameInDiv("parentId").GetAttribute("value");

                if (parentCode != parentEntity.Code)
                {
                    throw new Exception("The parent code is not bind or is invalid in production page");
                }

                //*--------------------Add and validate production--------------------*//

                context = webElementAction.GetElementBySpecificAttribute("data-form-name", "ADD_NEW_PRODUCTION_FORM");
                var productionCodeElement = webElementAction.GetElementByCssSelector(".advance-left-section [data-form-item-type='code-input']");
                new WebElementDataGenerator(productionCodeElement);

                context = webElementAction.GetElementByCssSelector(".main-modal.undefined");
                webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", context).Click();
                var productionEntity = new Production().AddProductionFunc(true);

                //*--------------------Add and validate order--------------------*//

                collapses = webElementAction.GetAllElementsByCssSelector(".ant-collapse-header");
                var orderCollaps = collapses[0];
                var addOrderElement = orderCollaps.FindElement(By.CssSelector(".icon-add"));
                addOrderElement.Click();
                ConfirmBtnCheck();

                var newOrderModal = webElementAction.GetElementBySpecificAttribute("data-modal-title", "ADD_A_NEW_ORDER");

                var productionValueInNewOrder = webElementAction.GetInputElementByDataFormItemNameInDiv("productionId", newOrderModal).GetAttribute("value");

                if (!productionValueInNewOrder.Equals(productionEntity.Id))
                {
                    throw new Exception("The production id is not bind or is invalid in Order page");
                }

                var parentValueInNewOrder = webElementAction.GetInputElementByDataFormItemNameInDiv("parentId", newOrderModal).GetAttribute("value");
                if (parentValueInNewOrder != parentEntity.Code)
                {
                    throw new Exception("The parent code is not bind or is invalid in Order page");
                }

                ConfirmBtnCheck(dataSection: "modal");


                // TODO: for after release
                //var orderEntity = new OrderSummaryList().AddOrderFunc(true, callOrderFrom: OrderSummaryList.OrderSource.OrderProcessing, generateDataToParentProductionModal: false);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    EquipmentCheckOutInAndBilling equipmentCheckOutInAndBilling;
    [TestMethod, Timeout(MaximumExecutionTime * 2)]
    public void DeleteOrder_Business()
    {
        TestInitialize(nameof(DeleteOrder_Business));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                equipmentCheckOutInAndBilling = new EquipmentCheckOutInAndBilling();

                Login();

                var orderNumber = equipmentCheckOutInAndBilling.AddOrderFuncWithCurrentLocation(callFromOrderProcessingScreen: false);

                GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);

                ConfirmBtnCheck(dataSection: "errorDialog"); //Error: Order Not On File

                equipmentCheckOutInAndBilling.ClearOrderProcessingFields();
                equipmentCheckOutInAndBilling.FillOrderNumber(orderNumber);

                GoToSubMenu("ORDER_TOOL_DROPDOWN", "DELETE_ORDER");

                ConfirmBtnCheck(dataSection: "confirmDialog");//Delete this Order?
                ConfirmBtnCheck(dataSection: "infoDialog"); // Order was deleted successfully.

                ValidateOrderDeletedInOrderList(orderNumber, gridId: "OrdersSummary-gridId");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    public void ValidateOrderDeletedInOrderList(string orderNumber, string gridId)
    {
        GoToUrl("OrderProcessing", "OrderList", gotoLogin: false);

        WaitForLoadingSpiner();

        CloseFilterWindow();

        Thread.Sleep(700);

        RefreshAllRows();

        WaitForLoadingSpiner();

        ShowAllRedord();

        // Clear the search textbox if it's not empty
        if (webElementAction.IsElementPresent(By.CssSelector("[data-icon-name='clear-text']")) == true)
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();

        // Click on listViewBtn 
        if (webElementAction.IsElementPresent(By.CssSelector(".first-button-gap")) == true)
        {
            var listViewBtn = webElementAction.GetElementByCssSelector(".first-button-gap");
            listViewBtn.Click();
        }

        SearchTextInMainGrid(orderNumber.Trim());

        var isPresentDeletedItem = webElementAction.IsDivPresentBySpecificText(orderNumber, By.Id(gridId));
        if (isPresentDeletedItem) throw new Exception("Error: Delete operation of order with number " + orderNumber + " failed...");
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void RecentParentCodesDisplayedOnOrderProcessing_Business()
    {
        TestInitialize(nameof(RecentParentCodesDisplayedOnOrderProcessing_Business));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Parent");
                ListViewtBtnClick();

                GenerateTenTextAndSearchInOrderProcessingScreen("ParentList-gridId", "parentId");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void RecentProductionCodesDisplayedOnOrderProcessing_Business()
    {
        TestInitialize(nameof(RecentProductionCodesDisplayedOnOrderProcessing_Business));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Production");
                RefreshAllRows();
                ListViewtBtnClick();

                GenerateTenTextAndSearchInOrderProcessingScreen("ProductionList-gridId", "productionId");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void RecentContactCodesDisplayedOnOrderProcessingScreen_Business()
    {
        TestInitialize(nameof(RecentContactCodesDisplayedOnOrderProcessingScreen_Business));
        //    while (!testPassed && retryCount < maxRetries)
        //        try
        //        {
        GoToUrl("Administration", "Contact");
        DataLegendNameFilter("ACTIVE");
        GenerateTenTextAndSearchInOrderProcessingScreen("ContactList-gridId", "contactId");

        testPassed = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            HandleTestFailure(ex.Message);
        //        }
    }

    private void GenerateTenTextAndSearchInOrderProcessingScreen(string grid, string dataInputName)
    {
        WaitForLoadingSpiner();
        equipmentCheckOutInAndBilling = new EquipmentCheckOutInAndBilling();

        //Get ten row in grid
        var firstTenElements = webElementAction.GetElementById(grid).FindElements(By.TagName("div"))
            .Where(o => o.GetAttribute("col-id") == "id").Take(11);

        var firstTenItemsText = firstTenElements.Select(element => element.Text).ToList();

        //go to order processing screen
        GoToUrl("OrderProcessing", "OrderProcessingScreen", gotoLogin: false);
        ConfirmBtnCheck(dataSection: "errorDialog");

        //find input search
        var searchInput = webElementAction.GetInputElementByDataInputNameInDiv(dataInputName);
        for (int i = 1; i < firstTenItemsText.Count; i++)
        {
            equipmentCheckOutInAndBilling.ClearOrderProcessingFields();
            searchInput.Click();
            searchInput.SendKeys(firstTenItemsText[i]);
        }

        searchInput.Click();
        WaitForLoadingSpiner();
        Thread.Sleep(500);
        //check tooltip menu if less than ten exception
        if (webElementAction.GetElementByCssSelector(".ant-dropdown-menu").FindElements(By.TagName("li")).Count() < 10)
            throw new Exception("Error : The number of records in the menu is less than ten.");
    }
}
