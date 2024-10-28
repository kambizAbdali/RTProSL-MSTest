// Developed By Mohammad Keshavarz

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.FileMaintenance.BillingAR;
using SeleniumWebdriver.Settings;
using WindowsInput;
using static RTProSL_MSTest.TestClasses.Inventory.Rental.RentalInventoryMassUpdate;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;



[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class RentalInventoryMassUpdate : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalInventoryMassUpdate()
    {
        TestInitialize(nameof(OpenPageRentalInventoryMassUpdate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventoryMassUpdate");
                RefreshAllRows();
                Thread.Sleep(500);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryMassUpdateByDepartment()
    {
        TestInitialize(nameof(FilterRentalInventoryMassUpdateByDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventoryMassUpdate");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("departmentId", "RentalInventoryMassUpdateList-gridId", "Department", colId: "department");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryMassUpdateByCategory()
    {
        TestInitialize(nameof(FilterRentalInventoryMassUpdateByCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventoryMassUpdate");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("categoryId", "RentalInventoryMassUpdateList-gridId", "Category", colId: "category");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryMassUpdateByEquipment()
    {
        TestInitialize(nameof(FilterRentalInventoryMassUpdateByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventoryMassUpdate");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("equipmentId", "RentalInventoryMassUpdateList-gridId", "Equipment", colId: "equipment");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryMassUpdateByDescription()
    {
        TestInitialize(nameof(FilterRentalInventoryMassUpdateByDescription));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventoryMassUpdate");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("description", "RentalInventoryMassUpdateList-gridId", "Description", colId: "description");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryMassUpdateByCreateDateBeginEnd()
    {
        TestInitialize(nameof(FilterRentalInventoryMassUpdateByCreateDateBeginEnd));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventoryMassUpdate");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("CreateDateBegin", "RentalInventoryMassUpdateList-gridId");
                filterSearch.FilterSearchInDateTimeDataType("createDate", "purchaseDate");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryMassUpdateByOwner()
    {
        TestInitialize(nameof(FilterRentalInventoryMassUpdateByOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventoryMassUpdate");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("owner", "RentalInventoryMassUpdateList-gridId" , "Owner");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void MassUpdateRentalInventoryMassUpdate() //feature number 27 release New Features 07-07-2024(2)
    {
        TestInitialize(nameof(MassUpdateRentalInventoryMassUpdate));
        while (!testPassed && retryCount < maxRetries)
            try
            { 
                GoToUrl("MMInventory", "RentalInventoryMassUpdate");
                RefreshAllRows();

                ClickMassUpdateInContextMenu();

                // Check if the model number input field is present in the mass update form.  
                if (!webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='modelNo']")))
                    Assert.Fail("Error:___ do not find model input"); // Fail if the model input is not found.  

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
                GoToUrl("MMInventory", "RentalInventoryMassUpdate");
                RefreshRecordDataInGrid("RentalInventoryMassUpdateList-gridId", columnId: "department");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    private string ClickMassUpdateInContextMenu()
    {
        // Click on the currently focused row in the Rental Inventory Mass Update grid.  
        webElementAction.GetElementById("RentalInventoryMassUpdateList-gridId")
            .FindElement(By.CssSelector(".ag-row.ag-row-focus [col-id]")).Click();

        var columnBarcode = webElementAction.GetColumnInDefaultGridRow("barcode", "RentalInventoryMassUpdateList-gridId");

        // Select the next row in the grid using the arrow key (down). 
        NavigateGridSelection(direction: DirectionArrow.Down);

        // Get the department element from the current row in the grid.  
        var departmentElement =
            webElementAction.GetColumnInDefaultGridRow("department", "RentalInventoryMassUpdateList-gridId");
        webElementAction.RighClick(departmentElement);

        // Find and click the "Mass Update" option from the context menu.  
        webElementAction.GetElementByCssSelector(".ag-popup")
            .FindElements(By.TagName("span"))
            .FirstOrDefault(o => o.GetAttribute("innerText") == "Mass Update")?.Click();

        return columnBarcode.Text;
    }

    public class RentalInventoryMassUpdateRentalEntryScreenEntity
    {
        [ValidationIgnore]
        [ValidationElementProperty("poId")]
        public string PO { set; get; }

        public string PurchaseDate { set; get; }

        [ValidationIgnore]
        public string PurchaseAmount { set; get; }

        [ValidationElementProperty("ownerId")]
        public string Owner { set; get; }

        public string Manufacturer { set; get; }

        [ValidationElementProperty("vendorId")]
        public string Vendor { set; get; }

        public string StorageLocation { set; get; }

        [ValidationElementProperty("modelNo")]
        public string Model { set; get; }

        [ValidationIgnore]
        [ValidationElementProperty("comments")]
        [ValidationDataFormName("notes")]
        public string comments_notes { set; get; }
    }

    private RentalInventoryMassUpdateRentalEntryScreenEntity _rentalInventoryMassUpdateRentalEntryScreenEntity;

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateDataMassUpdateInRentalInventoryMassUpdate()
    {
        TestInitialize(nameof(ValidateDataMassUpdateInRentalInventoryMassUpdate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _rentalInventoryMassUpdateRentalEntryScreenEntity =
                    new RentalInventoryMassUpdateRentalEntryScreenEntity();

                GoToUrl("MMInventory", "RentalInventoryMassUpdate");
                RefreshAllRows();

                string barcode = ClickMassUpdateInContextMenu();

                new WebElementDataGenerator(
                    webElementAction.GetElementBySpecificAttribute("data-form-name", "MassUpdateDialogFormName"));

                webElementAction.GetInputElementByDataFormItemNameInDiv("storageLocation").Clear();

                CreateAdd(_rentalInventoryMassUpdateRentalEntryScreenEntity);

                ConfirmBtnCheck(dataSection: "modal");

                GoToUrl("MMInventory", "RentalInventoryEntryScreen", gotoLogin: false);

                var barcodeScanner = webElementAction.GetInputElementByDataFormItemNameInDiv("barcode");
                barcodeScanner.Click();
                barcodeScanner.SendKeys(barcode);

                webElementAction.Click(By.CssSelector(".search-button"));

                CreateValidation(_rentalInventoryMassUpdateRentalEntryScreenEntity);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}