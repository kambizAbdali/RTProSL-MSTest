// Developed By Mohammad Keshavarz

using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Inventory.Sales;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Sales")]
public class SalesPriceList : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSalesPriceList()
    {
        TestInitialize(nameof(OpenPageSalesPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPriceList");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterSalesPriceList()
    {

        TestInitialize(nameof(OpenGridFilterSalesPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPriceList");
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
    public void ListViewtBtnCheckSalesPriceList()
    {
        TestInitialize(nameof(ListViewtBtnCheckSalesPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPriceList");
                RefreshAllRows();
                ShowAllRedord();
                //call list view btn 
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckSalesPriceList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckSalesPriceList));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPriceList");
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
    public void ArrowLastBtnCheckSalesPriceList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckSalesPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPriceList");
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
    public void ArrowNextBtnCheckSalesPriceList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckSalesPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPriceList");
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
    public void ArrowPreviousBtnCheckSalesPriceList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckSalesPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPriceList");
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
    public void FilterSalesPriceListByDepartment()
    {
        TestInitialize(nameof(FilterSalesPriceListByDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPriceList");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("departmentId", "SalesPriceList-gridId", colId: "department");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSalesPriceListByCategory()
    {
        TestInitialize(nameof(FilterSalesPriceListByCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPriceList");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("categoryId", "SalesPriceList-gridId", colId: "category");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSalesPriceListByStock()
    {
        TestInitialize(nameof(FilterSalesPriceListByStock));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPriceList");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("stockNo", "SalesPriceList-gridId");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateColumnIdsInGridBySalesPriceList() //feature number 40 release New Features 07-07-2024(2)
    {
        TestInitialize(nameof(ValidateColumnIdsInGridBySalesPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPriceList");

                //Select all value in grid
                RefreshAllRows();

                ExistingValidateAllColumnInGrid();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    void ExistingValidateAllColumnInGrid()
    {
        ChangeScreenPageSize(80);

        bool allColumnsPresent = true;

        string[] columnIds = {
            "standardPrice",
            "standardMaxDiscPct"
        };

        foreach (var columnId in columnIds)
            if (webElementAction.IsElementPresent(By.CssSelector($"[col-id='{columnId}']")))
            {
                allColumnsPresent = false;
                break;
            }

        if (allColumnsPresent)
            Assert.Fail("ColId not found");
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesPriceList");
                RefreshRecordDataInGrid("SalesPriceList-gridId", columnId: "department");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateInsertedPriceListInSalesPriceList()
    {
        TestInitialize(nameof(ValidateInsertedPriceListInSalesPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                string selectedCurrency = default;
                // Generate a random code for the price list  
                var priceListCode = RandomValueGenerator.GenerateRandomString(10);
                GoToUrl("FileMaintenance", "PriceList");

                // Click the add button to create a new price list  
                webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

                // Input the generated price list code  
                webElementAction.GetInputElementByDataFormItemNameInDiv("id").SendKeys(priceListCode);

                // Select the rentals checkbox  
                webElementAction.SelectingCheckbox("sales");

                if (CurrentUrlIsMultiLocation())
                {
                    selectedCurrency = GenerateCurrencyToPriceList();
                    GenerateLocationToPriceList();
                }
                SaveAndConfirmCheck();

                GoToUrl("MMInventory", "SalesPriceList", gotoLogin: false);
                if (CurrentUrlIsMultiLocation())
                    RefreshAllRowsBySpecificAutoComboGrid(filterId: "currencyId", filterValue: selectedCurrency);

                RefreshAllRowsBySpecificAutoComboGrid(filterId: "priceListId", filterValue: priceListCode);

                var salesPriceCodeColId = webElementAction.GetElementById("SalesPriceList-gridId")
                    .FindElements(By.TagName("div")).Where(o => o.GetAttribute("col-id").Contains(priceListCode, StringComparison.OrdinalIgnoreCase));

                if (salesPriceCodeColId == null)
                    Assert.Fail("Error: The expected price list entry is not present in the Sales Price List.");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private string GenerateCurrencyToPriceList()
    {
        // Generate a new WebElementDataGenerator for currency  
        new WebElementDataGenerator(webElementAction.GetElementBySpecificAttribute("data-form-item-name", "currencyId"));

        // Get the selected currency value  
        var selectedCurrency = webElementAction.GetInputElementByDataFormItemNameInDiv("currencyId").GetAttribute("value");

        return selectedCurrency;
    }

    private void GenerateLocationToPriceList()
    {
        // Get the current location for reference  
        var currentLocation = GetCurrentLocation();

        // Click the multi-selection icon  
        webElementAction.Click(By.CssSelector(".icon-multi-selection"));

        // Find and double-click the row corresponding to the current location  
        var currentLocationRow = webElementAction.GetElementById("AvailableMultiSelectPriceLocationTabList-gridId")
            .FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.GetAttribute("col-id") == "id" && o.GetAttribute("innerText") == currentLocation);

        if (currentLocationRow != null)
            webElementAction.DoubleClick(currentLocationRow);
        else
            Assert.Fail($"Error: Current location '{currentLocation}' not found in the available locations.");

        ConfirmBtnCheck(dataSection: "modal");
    }
}