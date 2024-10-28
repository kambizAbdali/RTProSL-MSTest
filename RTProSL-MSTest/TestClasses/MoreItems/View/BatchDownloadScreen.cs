//develop by Parsa Zakeri

using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.MoreItems.View;

[TestCategory("MoreItems")]
[TestClass, TestCategory("MoreItems___View")]
public class BatchDownloadScreen : BaseClass
{
    public enum ScannerTypeEnum
    {
        LoadFileFromScanner,
        VerifyData,
        PostData,
        ViewRawData
    }
    Dictionary<ScannerTypeEnum, string> ScannerTypeDict = new Dictionary<ScannerTypeEnum, string>()
    {
        { ScannerTypeEnum.LoadFileFromScanner ,"LOAD_FILE_FROM_SCANNER"},
        { ScannerTypeEnum.VerifyData,"VERIFY_DATA" },
        { ScannerTypeEnum.PostData,"POST_DATA" },
        { ScannerTypeEnum.ViewRawData,"VIEW_RAW_DATA" }
    };

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddAndRemoveScannersFromTextFile()
    {
        TestInitialize(nameof(AddAndRemoveScannersFromTextFile));
        while (!testPassed && retryCount < maxRetries)
        {
            try
            {
                // Navigate to the Batch Download Screen  
                GoToUrl("MoreItems", "BatchDownloadScreen");

                // Add a scanner file and retrieve the count of rows in the grid  
                AddScannerFile();

                // Remove all scanners from the grid  
                RemoveAllScanners();

                testPassed = true;
            }
            catch (Exception ex)
            { 
                HandleTestFailure(ex.Message);
            }
        }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddAndRemoveScannersBatch()
    {
        // Initialize the test and set the context for the test method  
        TestInitialize(nameof(AddAndRemoveScannersBatch));
        while (!testPassed && retryCount < maxRetries)
        {
            try
            {
                // Navigate to the Batch Download Screen  
                GoToUrl("MoreItems", "BatchDownloadScreen");

                // Add a scanner batch and retrieve the count of rows in the grid  
                AddScannerBatch();

                // Remove all scanners from the grid  
                RemoveAllScanners();

                testPassed = true;
            }
            catch (Exception ex)
            { 
                HandleTestFailure(ex.Message);
            }
        }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateBarcodeBatchListReport()
    {
        // Initialize the test and set the context for the test method  
        TestInitialize(nameof(ValidateBarcodeBatchListReport));
        while (!testPassed && retryCount < maxRetries)
        {
            try
            {
                // Navigate to the Batch Download Screen  
                GoToUrl("MoreItems", "BatchDownloadScreen");

                // Add a scanner file and retrieve the count of rows in the grid  
                AddScannerFile();

                // Verify that the preview screen behaves as expected  
                VerifyPreviewScreen();

                // Remove all scanners from the grid  
                RemoveAllScanners();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
        }
    }

    private void AddScannerFile()
    {
        // Get the initial row count from the grid footer  
        
        RemoveAllScanners();

        // Click to upload a scanner file  
        webElementAction.Click(By.Id(ScannerTypeDict[ScannerTypeEnum.LoadFileFromScanner]));

        // Upload the specified file  
        GenericHelper.SetFileInWindowUploader("BatchDownloadScreen.txt");
        WaitForLoadingSpiner(); // Wait for the loading spinner to disappear  

        Assert.AreEqual(4, GetRowCountFromGridPinnedFooter("DownloadBatchScanner-gridId"), "Error: Expected row count is not met."); //fix tedad row file
    }

    private void AddScannerBatch()
    {
        RemoveAllScanners();

        // Navigate to the submenu for selecting an existing batch  
        GoToSubMenu("DOWNLOAD_BATCH_SCANNER_ACTION_DROP_DOWN", "SELECT_EXISTING_BATCH");

        // Check if the modal for selecting an existing batch is present  
        if (!webElementAction.IsElementPresent(By.CssSelector(".main-modal")))
            Assert.Fail("Error: Modal for selecting existing batch is not present.");

        // Get the modal for existing batch number and fill in the batch details  
        var existingBatchModal = webElementAction.GetElementBySpecificAttribute("data-modal-title", "EXISTING_BATCH_NO");
        var kitCodeContexts = existingBatchModal.FindElements(By.CssSelector(".combo-auto-complete"));
        new WebElementDataGenerator().ComboAutoCompleteGenerator(kitCodeContexts); // Generate batch data  

        // Check the input value for the existing batch  
        var inputValue = webElementAction.GetElementByCssSelector(".search-input-component").FindElement(By.TagName("input"))
            .GetAttribute("value");

        // If no value is input, mark the test as passed  
        if (string.IsNullOrEmpty(inputValue))
            testPassed = true;

        // Confirm the selection  
        ConfirmBtnCheck(dataSection: "modal");

        if (GetRowCountFromGridPinnedFooter("DownloadBatchScanner-gridId") == 0)
            testPassed = true; // If no rows, mark the test as passed  
    }

    private void RemoveAllScanners()
    {
        var rowCount = GetRowCountFromGridPinnedFooter("DownloadBatchScanner-gridId");
        // Loop through each row in the grid and remove scanners  
        for (int i = rowCount; i > 0; i--) // Iterate backward to avoid index issues  
        {
            var gridElement = webElementAction.GetElementById("DownloadBatchScanner-gridId");
            var allColumnIds = gridElement.FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));
            allColumnIds[0].Click(); // Click the first row to select it for deletion  

            // Click the delete button  
            webElementAction.Click(By.Id("TOOL_BOX_DELETE_BUTTON_ID"));
            ConfirmBtnCheck(); // Confirm the deletion  

            // Verify that the row count decreases after deletion  
            int currentRowCount = GetRowCountFromGridPinnedFooter("DownloadBatchScanner-gridId");
            Assert.AreEqual(i - 1, currentRowCount, $"Error: Expected row count after deletion should be {i - 1}, but was {currentRowCount}.");
        }
    }

    private void VerifyPreviewScreen()
    {
        // Click the PRINT option in the tools box  
        webElementAction.GetElementByCssSelector(".tools-box-container").FindElements(By.CssSelector(".tools-box-dropdown-toggle"))
            .FirstOrDefault(o => o.GetAttribute("innerText") == "PRINT").Click();

        // Click the PRINT_BARCODED_BATCH_LIST option  
        webElementAction.Click(By.CssSelector("li[data-menu-id*='PRINT_BARCODED_BATCH_LIST']"));

        // Close the Preview Screen  
        webElementAction.Click(By.CssSelector("[data-icon-name='close']"));

        // Verify that the preview screen closed successfully  
        if (webElementAction.IsElementPresent(By.CssSelector(".webreport")))
            Assert.Fail("Error: Preview button does not work correctly");
    }

}

