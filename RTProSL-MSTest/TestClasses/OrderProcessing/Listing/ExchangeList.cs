// Developed By Mohammad Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.OrderProcessing.Listing;

[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___Listing")]
public class ExchangeList : BaseClass

{



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageExchangeList()
    {
        TestInitialize(nameof(OpenPageExchangeList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterExchangeList()
    {

        TestInitialize(nameof(OpenGridFilterExchangeList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");
                Thread.Sleep(2000);

                RefreshAllRows();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }

    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckExchangeList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckExchangeList));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");
                RefreshAllRows();
                ShowAllRedord();
                //call method arrowFirstBtn
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckExchangeList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckExchangeList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");
                RefreshAllRows();
                ShowAllRedord();
                Thread.Sleep(1000);
                //call method arrowlastbtn
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckExchangeList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckExchangeList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");
                RefreshAllRows();
                ShowAllRedord();
                // call method NextBtn
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckExchangeList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckExchangeList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");
                RefreshAllRows();
                ShowAllRedord();
                //call arrow previous
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterExchangeListByParent()
    {
        TestInitialize(nameof(FilterExchangeListByParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("parentId", "ExchangeList-gridId", colId: "parent");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterExchangeListByProject()
    {
        TestInitialize(nameof(FilterExchangeListByProject));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("projectId", "ExchangeList-gridId", colId: "project");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterExchangeListByRentalAgent()
    {
        TestInitialize(nameof(FilterExchangeListByRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("rentalAgentId", "ExchangeList-gridId", colId: "rentalAgent");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterExchangeListByProduction()
    {
        TestInitialize(nameof(FilterExchangeListByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("productionId", "ExchangeList-gridId", colId: "production");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterExchangeListByJobComponent()
    {
        TestInitialize(nameof(FilterExchangeListByJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("jobComponentId", "ExchangeList-gridId");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterExchangeListBySalesperson()
    {
        TestInitialize(nameof(FilterExchangeListBySalesperson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("salespersonId", "ExchangeList-gridId", colId: "salesperson");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    //TODO 
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterExchangeListByLocation()
    {
        TestInitialize(nameof(FilterExchangeListByLocation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                if (!webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name = 'locationId']"))) goto End;
                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("locationId", "ExchangeList-gridId", colId: "location");
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
    public void FilterExchangeListByOrder()
    {
        TestInitialize(nameof(FilterExchangeListByOrder));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("orderNo", "ExchangeList-gridId");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterExchangeListByBarcodeIn()
    {
        TestInitialize(nameof(FilterExchangeListByBarcodeIn));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("barcode", "ExchangeList-gridId", colId: "barcodeIn");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterExchangeListByBarcodeOut()
    {
        TestInitialize(nameof(FilterExchangeListByBarcodeOut));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("barcode", "ExchangeList-gridId", colId: "barcodeIn");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterExchangeListByBeginEndDate()
    {
        TestInitialize(nameof(FilterExchangeListByBeginEndDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("fromDate", "ExchangeList-gridId");
                filterSearch.FilterSearchInDateTimeDataType("dateIn", "dateOut");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterExchangeListByPendingExchanges()
    {
        TestInitialize(nameof(FilterExchangeListByPendingExchanges));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("pendingExchanges", "ExchangeList-gridId");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterExchangeListByStopBilling()
    {
        TestInitialize(nameof(FilterExchangeListByStopBilling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMExchangeList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("stopBilling", "ExchangeList-gridId");
                filterSearch.FilterSearchInCheckBoxDataType();
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
                GoToUrl("OrderProcessing", "OPMExchangeList");
                RefreshRecordDataInGrid("ExchangeList-gridId", columnId: "equipment");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}