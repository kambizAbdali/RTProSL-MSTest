// Developed By Mohammad Keshavarz


using MSTestProject.ComponentHelper;
using NUnit.Framework;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using static System.Net.Mime.MediaTypeNames;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;



[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class RentalPriceList : BaseClass
{
    [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckRentalPriceList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckRentalPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPriceList");
                // call method NextBtn
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckRentalPriceList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckRentalPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPriceList");
                //call arrow previous
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckRentalPriceList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckRentalPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPriceList");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckRentalPriceList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckRentalPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPriceList");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
    public void FilterRentalPriceListByDepartment()
    {
        TestInitialize(nameof(FilterRentalPriceListByDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPriceList");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("departmentId", "RentalPriceList-gridId", "Department", "department");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
    public void FilterRentalPriceListByCategory()
    {
        TestInitialize(nameof(FilterRentalPriceListByCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPriceList");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("categoryId", "RentalPriceList-gridId", "Category", "category");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
    public void FilterRentalPriceListByEquipment()
    {
        TestInitialize(nameof(FilterRentalPriceListByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPriceList");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("equipmentId", "RentalPriceList-gridId", "Equipment", colId: "equipment");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
    public void FilterRentalPriceListByProduction()
    {
        TestInitialize(nameof(FilterRentalPriceListByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPriceList");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("selected-production", "RentalPriceList-gridId");
                filterSearch.FilterSearchInRadioButtonDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
    public void ValidateColumnIdsInGridByRentalPriceList() //feature number 39 release New Features 07-07-2024(2)
    {
        TestInitialize(nameof(ValidateColumnIdsInGridByRentalPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPriceList");

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
            "standardDaily",
            "standardWeekly",
            "standardBiWeekly",
            "standardMonthly",
            "standardMaxDiscPct",
            "standardMinDPW"
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
    [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPriceList");
                RefreshRecordDataInGrid("RentalPriceList-gridId", columnId: "department");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
    public void CopyListPriceFromExistingPriceList_MultiSelectFeature()
    {
        TestInitialize(nameof(CopyListPriceFromExistingPriceList_MultiSelectFeature));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalPriceList");
                RefreshAllRows();

                // Click on the currently focused row in the Rental Price List grid.  
                webElementAction.GetElementById("RentalPriceList-gridId")
                    .FindElement(By.CssSelector(".ag-row.ag-row-focus [col-id]")).Click();

                // Select the next row in the grid using the arrow key (down).
                NavigateGridSelection(direction: DirectionArrow.Down);

                // Get the department number element from the current row in the grid.  
                var departmentElement = webElementAction.GetColumnInDefaultGridRow("department", "RentalPriceList-gridId");
                // Right-click on the department number element to bring up the context menu.  
                webElementAction.RighClick(departmentElement);

                // Find and click the "Copy Price List from an Existing Price List" option from the context menu.  
                webElementAction.GetElementByCssSelector(".ag-popup")
                    .FindElements(By.TagName("span"))
                    .FirstOrDefault(o => o.GetAttribute("innerText") == "Copy Price List from an Existing Price List")?.Click();

                if (!webElementAction.IsElementPresent(By.CssSelector(".main-modal")))
                    Assert.Fail("Error:___ Do not find 'Copy Price List from an Existing Price List' modal ");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Timeout(MaximumExecutionTime)]
    public void ValidateInsertedPriceListInRentalPriceList()
    {
        TestInitialize(nameof(ValidateInsertedPriceListInRentalPriceList));
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
                webElementAction.SelectingCheckbox("rentals");

                if (CurrentUrlIsMultiLocation())
                {
                    selectedCurrency = GenerateCurrencyToPriceList();
                    GenerateLocationToPriceList();
                }
                SaveAndConfirmCheck();

                GoToUrl("MMInventory", "RentalPriceList", gotoLogin: false);
                if (CurrentUrlIsMultiLocation())
                    RefreshAllRowsBySpecificAutoComboGrid(filterId: "currencyId", filterValue: selectedCurrency);

                RefreshAllRowsBySpecificAutoComboGrid(filterId: "priceListList", filterValue: priceListCode);

                var rentalPriceCodeColId = webElementAction.GetElementById("RentalPriceList-gridId")
                    .FindElements(By.TagName("div")).Where(o => o.GetAttribute("col-id").Contains(priceListCode, StringComparison.OrdinalIgnoreCase));

                if (rentalPriceCodeColId == null)
                    Assert.Fail("Error: The expected price list entry is not present in the Rental Price List.");

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

        // Save the new price list  
        SaveAndConfirmCheck();
    }
}