//develop by Parsa  Zakeri

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RTProSL_MSTest.ComponentHelper;
using SeleniumWebdriver.Settings;
using WindowsInput;

namespace RTProSL_MSTest.TestClasses.MoreItems.View
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___View")]
    public class TruckDispatchList : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageTruckDispatchList()
        {
            TestInitialize(nameof(OpenPageTruckDispatchList));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "TruckDispatchList");

                    Thread.Sleep(1000);

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterTruckDispatchListByFromToDate()
        {
            TestInitialize(nameof(FilterTruckDispatchListByFromToDate));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "TruckDispatchList");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch(gridListId: "TruckDispatchList-gridId");
                    filterSearch.FilterSearchInDateTimeDataType(dateGridColId: "contractDate", idFormDateTimeBeginAndFrom: "beginDate", idFormDateTimeToEnd: "endDate");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterTruckDispatchListByProduction()
        {
            TestInitialize(nameof(FilterTruckDispatchListByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "TruckDispatchList");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("productionIdList", "TruckDispatchList-gridId", "Production", colId: "production");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterTruckDispatchListByRentalAgent()
        {
            TestInitialize(nameof(FilterTruckDispatchListByRentalAgent));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "TruckDispatchList");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("rentalAgentIdList", "TruckDispatchList-gridId", "Rental Agent", colId: "rentalAgent");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterTruckDispatchListByLocation()
        {
            TestInitialize(nameof(FilterTruckDispatchListByLocation));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "TruckDispatchList");
                    if (!webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name = 'locationIdList']"))) goto End;
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("locationIdList", "TruckDispatchList-gridId", colId: "location" , columnName: "Location");
                    filterSearch.FilterSearchInTextDataType();
                End: { }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterTruckDispatchListByDelivery()
        {
            TestInitialize(nameof(FilterTruckDispatchListByDelivery));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "TruckDispatchList");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("delivery", "TruckDispatchList-gridId", "Type", "dispatchType", "Delivery");
                    filterSearch.FilterSearchInCheckBoxDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterTruckDispatchListByPickUp()
        {
            TestInitialize(nameof(FilterTruckDispatchListByPickUp));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "TruckDispatchList");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("pickup", "TruckDispatchList-gridId", "Type", "dispatchType", "Pickup");
                    filterSearch.FilterSearchInCheckBoxDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void MassAssignUpdateTruckDispatches()  //feature number 13 release New Features 07-07-2024(2)
        {
            TestInitialize(nameof(MassAssignUpdateTruckDispatches));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "TruckDispatchList");

                    RefreshAllRows();

                    // Click on the currently focused row in the Truck Dispatch List grid.  
                    webElementAction.GetElementById("TruckDispatchList-gridId")
                        .FindElement(By.CssSelector(".ag-row.ag-row-focus [col-id]")).Click();

                    // Select the next row in the grid using the arrow key (down).
                    NavigateGridSelection(direction: DirectionArrow.Down);

                    // Get the dispatch number element from the current row in the grid.  
                    var departmentElement = webElementAction.GetColumnInDefaultGridRow("dispatchNo", "TruckDispatchList-gridId");
                    // Right-click on the dispatch number element to bring up the context menu.  
                    webElementAction.RighClick(departmentElement);

                    // Find and click the "Mass Assign/Update Truck Dispatches" option from the context menu.  
                    webElementAction.GetElementByCssSelector(".ag-popup")
                        .FindElements(By.TagName("span"))
                        .FirstOrDefault(o => o.GetAttribute("innerText") == "Mass Assign/Update Truck Dispatches")?.Click();

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
                    GoToUrl("MoreItems", "TruckDispatchList");
                    RefreshRecordDataInGrid("TruckDispatchList-gridId", columnId: "dispatchNo");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}