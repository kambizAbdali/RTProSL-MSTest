// Developed By Parsa Zakeri

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.FileMaintenance.Dispatch;
using System.Collections.ObjectModel;
using System.Drawing;
using SeleniumWebdriver.Settings;

namespace RTProSL_MSTest.TestClasses.Inventory.Repairs;

public class RepairTicketEntity
{
    [ValidationElementProperty("productionId")]
    public string Production { get; set; }

    [ValidationElementProperty("orderNo")]
    public string QuoteToBill { get; set; }

    [ValidationElementProperty("authorizedBy")]
    public string AuthorizedBy { get; set; }

    [ValidationElementProperty("repairPO")]
    public string RepairPO { get; set; }

    [ValidationElementProperty("estAmount")]
    public string EstAmount { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("taxTypeId")]
    public string TaxType { get; set; }

    [ValidationElementProperty("billable")]
    [ValidationDataType(DataType.CheckBox)]
    public bool Billable { get; set; }

    [ValidationElementProperty("locked")]
    [ValidationDataType(DataType.CheckBox)]
    public bool Locked { get; set; }

    [ValidationElementProperty("notes")]
    [ValidationDataType(dataType: DataType.TextArea)]
    public string TicketDescription { get; set; }
}


[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Repairs")]
public class RepairTicketList : BaseClass
{
    private RepairTicketEntity _RepairTicketEntity;
    public enum RepairTicketEnum
    {
        Add,
        Edit,
        Delete,
        Validate
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRepairTicketList()
    {
        TestInitialize(nameof(OpenPageRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddRepairTicketList()
    {
        TestInitialize(nameof(AddRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOrEditRepairTicketListFunc(RepairTicketEnum.Add);
                {
                    GoToUrl("MMInventory", "RepairTicketList", gotoLogin: false);
                    //refresh grid and search grid
                    webElementAction.Click(By.Id("TOOL_BOX_REFRESH_BUTTON_ID"));
                    SearchAndEditClick(_RepairTicketEntity.RepairPO.Trim());
                }
                ValidateInsertedRepairTicketFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditRepairTicketList()
    {
        TestInitialize(nameof(EditRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOrEditRepairTicketListFunc(RepairTicketEnum.Edit);
                {
                    GoToUrl("MMInventory", "RepairTicketList", gotoLogin: false);
                    //refresh grid and search grid
                    webElementAction.Click(By.Id("TOOL_BOX_REFRESH_BUTTON_ID"));
                    SearchAndEditClick(_RepairTicketEntity.RepairPO.Trim());
                }
                ValidateInsertedRepairTicketFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteRepairTicketList()
    {
        TestInitialize(nameof(DeleteRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOrEditRepairTicketListFunc(RepairTicketEnum.Add);

                DeleteRepairTicketListFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateRepairTicketList()
    {
        TestInitialize(nameof(DetailValidateRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOrEditRepairTicketListFunc(RepairTicketEnum.Add);
                DetailValidateInGridInsertedRepairTicketFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private void DetailValidateInGridInsertedRepairTicketFunc()
    {
        GoToUrl("MMInventory", "RepairTicketList", gotoLogin: false);

        ShowAllRedord();

        webElementAction.Click(By.Id("TOOL_BOX_REFRESH_BUTTON_ID"));

        SearchTextInMainGrid(_RepairTicketEntity.RepairPO.Trim());

        var gridList = webElementAction.GetElementById("RepairTicketList-gridId");

        gridList.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _RepairTicketEntity.RepairPO.Trim()).Click();

        ReadOnlyCollection<IWebElement> colIds =
            gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

        CreateValidationInGrid(colIds, _RepairTicketEntity);
    }

    public string AddOrEditRepairTicketListFunc(RepairTicketEnum operation)
    {
        GoToUrl("MMInventory", "RepairTicketList");

        RefreshAllRows();

        Thread.Sleep(2000);

        {
            if (operation == RepairTicketEnum.Add)
                webElementAction.ClickOnAddNewRecord();

            else if (operation == RepairTicketEnum.Edit)
                webElementAction.Click(By.Id("TOOL_BOX_EDIT_BUTTON_ID"));
        }

        _RepairTicketEntity = new RepairTicketEntity();

        {
            //=""
            var productionContext = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "productionId");

            var vendorContext = productionContext.FindElements(By.CssSelector(".combo-auto-complete"));

            new WebElementDataGenerator().ComboAutoCompleteGenerator(vendorContext); //generate data to Vendor
        }
        // data insert to fields in page DispatchStatusList  Entry List with random data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_RepairTicketEntity);

        webElementAction.Click(By.Id("TOOL_BOX_SAVE_CHANGES_BUTTON_ID"));

        return webElementAction.GetInputElementByDataFormItemTypeInDiv("searchCodeInput").GetAttribute("value");
    }

    public void ValidateInsertedRepairTicketFunc()
    {
        CreateValidation(_RepairTicketEntity);
    }

    private void DeleteRepairTicketListFunc()
    {
        { //delete new record and confirm
            Thread.Sleep(2000);

            webElementAction.Click(By.Id("TOOL_BOX_DELETE_BUTTON_ID"));

            ConfirmBtnCheck(dataSection: "confirmDialog");
        }
        { //refresh grid and search grid
            webElementAction.Click(By.Id("TOOL_BOX_REFRESH_BUTTON_ID"));

            SearchTextInMainGrid(_RepairTicketEntity.RepairPO.Trim());

            Thread.Sleep(2000);
        } //check grid if count != 0
        if (GetRowCountFromGridPinnedFooter("RepairTicketList-gridId") != 0)
            throw new Exception("Error : The specified record with ID '" + _RepairTicketEntity.RepairPO + "' has not been deleted.");
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRepairTicketByCreationDate()
    {
        TestInitialize(nameof(FilterRepairTicketByCreationDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("fromDate", "RepairTicketList-gridId", columnName: "Creation Date");
                filterSearch.FilterSearchInDateTimeDataType("creationDate");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRepairTicketByTicket()
    {
        TestInitialize(nameof(FilterRepairTicketByTicket));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("id", "RepairTicketList-gridId", columnName: "Ticket");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRepairTicketByOrderToBill()
    {
        TestInitialize(nameof(FilterRepairTicketByOrderToBill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("orderNo", "RepairTicketList-gridId");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRepairTicketByProduction()
    {
        TestInitialize(nameof(FilterRepairTicketByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("productionId", "RepairTicketList-gridId");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRepairTicketByEquipment()
    {
        TestInitialize(nameof(FilterRepairTicketByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("equipmentList", "RepairTicketList-gridId", columnName: "Equipment");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRepairTicketByBarcode()
    {
        TestInitialize(nameof(FilterRepairTicketByBarcode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("barcode", "RepairTicketList-gridId", columnName: "Barcode");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRepairTicketByCurrency()
    {
        TestInitialize(nameof(FilterRepairTicketByCurrency));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("currencyId", "RepairTicketList-gridId", columnName: "Currency");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    Dictionary<string, Color> ColorDict =
        new Dictionary<string, Color>()
        {
            {"Yellow", Color.FromArgb(255, 255, 0, (int)0.4)},
            {"Gray", Color.FromArgb(228, 228, 228, (int)0.4)}
        };

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRepairTicketByHistory()
    {
        TestInitialize(nameof(FilterRepairTicketByHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("HISTORY");
                FilterSearch filterSearch = new FilterSearch("includeHistory", "RepairTicketList-gridId", columnName: "History", colId: "history", Color: ColorDict["Gray"]);
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRepairTicketByClosed()
    {
        TestInitialize(nameof(FilterRepairTicketByClosed));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("CLOSED");
                FilterSearch filterSearch = new FilterSearch("includeClosed", "RepairTicketList-gridId", columnName: "Closed", colId: "closed", Color: ColorDict["Yellow"]);
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInRepairTicketList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInRepairTicketList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInRepairTicketList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInRepairTicketList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInRepairTicketList()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");

                //Select all value in grid
                RefreshAllRows();
                {
                    webElementAction.Click(By.Id("PRINT_TOOL_DROPDOWN"));
                    webElementAction.GetElementByCssSelector(".ant-dropdown").FindElements(By.TagName("li")).Where(o => o.GetAttribute("innerText") == "Repair Ticket").First().Click();
                    ConfirmBtnCheck();
                }
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInRepairTicketList()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");

                //Select all value in grid
                RefreshAllRows();
                {
                    webElementAction.Click(By.Id("PRINT_TOOL_DROPDOWN"));
                    webElementAction.GetElementByCssSelector(".ant-dropdown").FindElements(By.TagName("li")).Where(o => o.GetAttribute("innerText") == "Repair Ticket").First().Click();
                    ConfirmBtnCheck();
                }
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInRepairTicketList()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");

                //Select all value in grid
                RefreshAllRows();
                {
                    webElementAction.Click(By.Id("PRINT_TOOL_DROPDOWN"));
                    webElementAction.GetElementByCssSelector(".ant-dropdown").FindElements(By.TagName("li")).Where(o => o.GetAttribute("innerText") == "Repair Ticket").First().Click();
                    ConfirmBtnCheck();
                }
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer);
                report.ValidateReport();
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
                GoToUrl("MMInventory", "RepairTicketList");
                RefreshRecordDataInGrid("RepairTicketList-gridId", columnId: "productionId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInRepairTicketList()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");
                RefreshAllRows();
                {
                    webElementAction.Click(By.Id("PRINT_TOOL_DROPDOWN"));
                    webElementAction.GetElementByCssSelector(".ant-dropdown").FindElements(By.TagName("li")).Where(o => o.GetAttribute("innerText") == "Repair Ticket").First().Click();
                    ConfirmBtnCheck();
                }
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInRepairTicketList()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRepairTicketList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");
                RefreshAllRows();
                {
                    webElementAction.Click(By.Id("PRINT_TOOL_DROPDOWN"));
                    webElementAction.GetElementByCssSelector(".ant-dropdown").FindElements(By.TagName("li")).Where(o => o.GetAttribute("innerText") == "Repair Ticket").First().Click();
                    ConfirmBtnCheck();
                }
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrintRepairLabelList()
    {
        TestInitialize(nameof(ValidatePrintRepairLabelList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketList");
                RefreshAllRows();

                // Double-click on the currently focused row in the grid.  
                webElementAction.DoubleClick(webElementAction.GetElementByCssSelector(".ag-row.ag-row-focus [col-id]"));
                {
                    // Wait for any loading spinner to disappear after the double-click.  
                    WaitForLoadingSpiner();
                    // Navigate to the sub-menu for viewing repair item detail information.  
                    GoToSubMenu("REPAIR_VIEW_DROP_DOWN", "REPAIR_ITEM_DETAIL_INFORMATION");
                    // Wait for loading spinner again after navigating.  
                    WaitForLoadingSpiner();
                    // Navigate to the print sub-menu for printing repair labels.  
                    GoToSubMenu("PRINT", "PRINT_REPAIR_LABEL");
                }

                // Check if the modal for printing repair labels is present.  
                if (!webElementAction.IsElementPresent(By.CssSelector(".main-modal")))
                    Assert.Fail("Error:___ Do not find modal Print Repair label"); // Fail if the modal is not found.  

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