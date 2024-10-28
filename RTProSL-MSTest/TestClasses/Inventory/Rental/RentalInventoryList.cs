// Developed By Mohammad Keshavarz

using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.TestClasses.Administration.Tables;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class RentalInventoryList : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalInventory()
    {
        TestInitialize(nameof(OpenPageRentalInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");
                Thread.Sleep(500);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterRentalInventory()
    {

        TestInitialize(nameof(OpenGridFilterRentalInventory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");
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
    public void FilterRentalInventoryByDepartment()
    {
        TestInitialize(nameof(FilterRentalInventoryByDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("departmentId", "RentalInventoryList-gridId", "Department");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryByEquipment()
    {
        TestInitialize(nameof(FilterRentalInventoryByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("equipmentId", "RentalInventoryList-gridId", "Equipment");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryByEquipmentGroup()
    {
        TestInitialize(nameof(FilterRentalInventoryByEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("equipmentGroupId", "RentalInventoryList-gridId");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryByVendor()
    {
        TestInitialize(nameof(FilterRentalInventoryByVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("vendorId", "RentalInventoryList-gridId", "Vendor");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryByOwner()
    {
        TestInitialize(nameof(FilterRentalInventoryByOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("ownerId", "RentalInventoryList-gridId");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryBySpecification()
    {
        TestInitialize(nameof(FilterRentalInventoryBySpecification));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("specificationList", "RentalInventoryList-gridId");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryByItemType()
    {
        TestInitialize(nameof(FilterRentalInventoryByItemType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("itemType", "RentalInventoryList-gridId");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryByManufacturer()
    {
        TestInitialize(nameof(FilterRentalInventoryByManufacturer));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("manufacturer", "RentalInventoryList-gridId", "Manufacturer");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryByCreateDate()
    {
        TestInitialize(nameof(FilterRentalInventoryByCreateDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("createDate1", "RentalInventoryList-gridId", "Created by", "createBy");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryByMWO()
    {
        TestInitialize(nameof(FilterRentalInventoryByMWO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("MWO", "RentalInventoryList-gridId", columnName: "MWO", colId: "mwo");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryBySerial()
    {
        TestInitialize(nameof(FilterRentalInventoryBySerial));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("serialNo", "RentalInventoryList-gridId", "Serial#");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryByRadioID()
    {
        TestInitialize(nameof(FilterRentalInventoryByRadioID));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("radioId", "RentalInventoryList-gridId", "Radio ID", colId: "radioID");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryByModel()
    {
        TestInitialize(nameof(FilterRentalInventoryByModel));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("modelNo", "RentalInventoryList-gridId", "Model#");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryByStorageLocation()
    {
        TestInitialize(nameof(FilterRentalInventoryByStorageLocation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("storageLocation", "RentalInventoryList-gridId", "Storage Location");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalInventoryByPO()
    {
        TestInitialize(nameof(FilterRentalInventoryByPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("PO", "RentalInventoryList-gridId", colId: "po");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    ImageDetector imageDetector;
    [TestMethod]
    public void AddAndPrintBarcodeImageInRentalInventory()
    {
        TestInitialize(nameof(AddAndPrintBarcodeImageInRentalInventory));
        imageDetector = new ImageDetector();

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");
                RefreshAllRows();
                ClickOnDetailEntryScreen();
                Thread.Sleep(1000);
                ClickOnEditBtn();

                imageDetector.RemoveAllPicturesIfExist();

                imageDetector.AddPicture();

                imageDetector.ClickOnImageMoreOption();

                imageDetector.ClickOnPrintBtn();

                imageDetector.ClickOnImageSizeX5RedioButton();

                //Click on preview btn
                webElementAction.GetElementByCssSelector(".icon-report-preview").Click();

                bool detectedImage = imageDetector.LocateImageInScreenshot();

                if (!detectedImage)
                    throw new Exception("Error: _____ The inserted image does not appear in the print screen.\r\n");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EdiRentalInventoryPicture()
    {
        TestInitialize(nameof(EdiRentalInventoryPicture));
        imageDetector = new ImageDetector();

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");
                EditPictureValidate();
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
                GoToUrl("MMInventory", "RentalInventory");
                RefreshRecordDataInGrid("RentalInventoryList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrintBarcodeLabelList()
    {
        TestInitialize(nameof(ValidatePrintBarcodeLabelList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalInventory");
                RefreshAllRows();

                // Double-click on the currently focused row in the grid.  
                webElementAction.DoubleClick(webElementAction.GetElementByCssSelector(".ag-row.ag-row-focus [col-id]"));

                WaitForLoadingSpiner();

                // Find the PRINT option in the tools box dropdown and click it.  
                webElementAction.GetElementByCssSelector(".tools-box-container")
                    .FindElements(By.CssSelector(".tools-box-dropdown-toggle"))
                    .FirstOrDefault(o => o.GetAttribute("innerText") == "PRINT")?.Click();

                // Click on the PRINT_BARCODE_LABELS menu item.  
                webElementAction.Click(By.CssSelector("li[data-menu-id*='PRINT_BARCODE_LABELS']"));

                // Check if the modal for printing barcode labels is present.  
                if (!webElementAction.IsElementPresent(By.CssSelector(".main-modal")))
                    Assert.Fail("Error:___ Do not find print barcode label modal"); // Fail if the modal is not found.  

                // Find the input element within the modal.  
                var inputElement = webElementAction.GetElementByCssSelector(".main-modal").FindElement(By.TagName("input"));

                // If the input field is empty, send the value "1" to it.  
                if (string.IsNullOrEmpty(inputElement.GetAttribute("value")))
                    inputElement.SendKeys("1");

                ConfirmBtnCheck(dataSection: "modal");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}