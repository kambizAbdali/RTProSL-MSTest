//develop by Mohammad_keshvarz

using OpenQA.Selenium;
using System.Drawing;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
using System.Drawing;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using static RTProSL_MSTest.TestClasses.BaseClass;

namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Subrental;


// define clase  struct ParentEntity
public class SubrentalPOEntity
{
    public SubrentalPOEntity()
    {
        GeneralTab = new GeneralTab();
        ShipMethod = new ShipMethodTab();
    }

    [ValidationTabClick("GENERAL")]
    public GeneralTab GeneralTab { get; set; }

    [ValidationTabClick("SHIP_METHOD")]
    public ShipMethodTab ShipMethod { get; set; }
}

// define struct GeneralTab
public class GeneralTab
{
    [ValidationIgnore(true, BaseClass.IgnoreType.Validation)]
    [ValidationElementProperty("poId")]
    public string PO { set; get; }

    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationElementProperty("vendorId")]
    public string Vendor { set; get; }

    [ValidationElementProperty("poDate")]
    public string PODate { set; get; }

    [ValidationElementProperty("amount")]
    public string POAmount { set; get; }

    [ValidationElementProperty("sappo")]
    public string SapPO { set; get; }

    [ValidationColID("currency")]
    [ValidationElementProperty("currencyId")]
    public string Currency { set; get; }
    [ValidationColID("terms")]
    [ValidationElementProperty("termsId")]
    public string Terms { set; get; }

    [ValidationElementProperty("sapAmount")]
    public string SAPAmount { set; get; }

    [ValidationIgnore]
    [ValidationIgnoreInGrid]
    [ValidationElementProperty("tax")]
    public string TaxUnlocked { set; get; }

    [ValidationElementProperty("taxRate")]
    public string TaxRate { set; get; }

    [ValidationColID("taxType")]
    [ValidationElementProperty("taxTypeId")]
    public string TaxType { set; get; }

    [ValidationDataType(DataType.DropDown)]
    [ValidationElementProperty("status")]
    public string Status { set; get; }

    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationElementProperty("invoicePlanBegDate")]
    public string InvoicePlanBegDate { set; get; }

    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationElementProperty("invoicePlanBegDate")]
    public string InvoicePlanEndDate { set; get; }

    [ValidationColID("subrentalReason")]
    [ValidationElementProperty("subrentalReasonId")]
    public string SubrentalReason { set; get; }

    [ValidationIgnoreInGrid(true)]
    [ValidationColID("managingDepartment")]
    [ValidationElementProperty("managingDepartmentId")]
    public string ManagingDept { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("approved")]
    public bool Approved { set; get; }

    public string ClosedDate { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("uploadInclude")]
    public bool UploadInclude { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("noFurtherBillFromVendor")]
    public bool NoFurtherRentalBillfromVendor { set; get; }

    [ValidationDataType(DataType.TextArea)]
    public string Notes { set; get; }

    [ValidationDataType(DataType.TextArea)]
    public string ContactNotes { set; get; }
}

public class ShipMethodTab
{
    [ValidationColID("shipMethodId")]
    [ValidationElementProperty("shipMethodId")]
    public string ShipMethod { set; get; }

    [ValidationElementProperty("shipType")]
    public string ShipType { set; get; }

    [ValidationElementProperty("dispatchDate")]
    [ValidationIgnoreAttribute(type: IgnoreType.Validation)]
    public string DispatchDate { set; get; }

    [ValidationElementProperty("note")]
    public string Note { set; get; }

    [ValidationColID("dispatchNo")]
    [ValidationElementProperty("dispatchNo")]
    public string Dispatch { set; get; }
}

[TestCategory("PurchaseOrder")]
[TestClass, TestCategory("PurchaseOrder___Subrental")]
public class SubrentalPO : BaseClass
{

    //new struct 
    public SubrentalPOEntity _SubrentalPOEntity;

    private void GeneralTabClick()
    {
        var ShipMethodBtn = webElementAction.GetElementByCssSelector(".mainButton[data-tab-name='GENERAL']");
        ShipMethodBtn.Click();
    }

    public void AddSubrentalPOFunc()
    {
        _SubrentalPOEntity = new SubrentalPOEntity();

        GoToUrl("PurchaseOrder", "SubrentalPO");
        RefreshAllRows();
        ShowAllRedord();

        Thread.Sleep(2000);

        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        CreateAdd(_SubrentalPOEntity);

        //click on post button
        webElementAction.GetElementByCssSelector(".icon-tick").Click();

        AddShipMethod();

        webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();

        SaveAndConfirmCheck();
        ConfirmBtnCheck();
        CheckErrorDialogBox();
    }

    private void AddShipMethod()
    {
        var shipMethodContext = webElementAction
            .GetAllElementBySpecificAttribute("data-section", "tabContent")
            .FirstOrDefault(o => o.GetAttribute("data-tab-name") == "SHIP_METHOD");

        //delete all shipMethods
        while (!webElementAction.IsElementPresent(By.CssSelector("#MINI_GRID_DELETE_BUTTON[disabled] .icon-delete"),
                   shipMethodContext))
        {
            Thread.Sleep(1500);
            webElementAction.GetElementByCssSelector("[#MINI_GRID_DELETE_BUTTON .icon-delete", shipMethodContext)
                .Click();
        }

        //add shipMethod
        webElementAction.GetElementBySpecificAttribute("id", "MINI_GRID_ADD_BUTTON", shipMethodContext).Click();

        Thread.Sleep(2000);
        var newRowColsContext = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row");
        new WebElementDataGenerator(newRowColsContext, true);

        //fill all checkboxes in row
        var checkboxElements = newRowColsContext.FindElements(By.TagName("input"))
            .Where(element => element.GetAttribute("type") == "checkbox").ToList();
        new WebElementDataGenerator().CheckboxGenerator(checkboxElements);

        //click on dispatch dateTime
        webElementAction.Click(By.CssSelector(".ant-picker-input"), newRowColsContext);

        //click on datetime now btn
        webElementAction.Click(By.CssSelector(".ant-picker-now-btn"));


        //click on post shipMethod
        webElementAction.ClickOnPostBtnInMinGrid(gridId: "shipMethodPickupAndReturn-MiniGrid-gridId");

        Thread.Sleep(1000);
        var shipMethodColIds = webElementAction.GetElementById("shipMethodPickupAndReturn-MiniGrid-gridId")
            .FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]")); //
        CreateAddInGrid(_SubrentalPOEntity.ShipMethod, shipMethodColIds, true);
    }

    private void ValidateInsertSubrentalPOFunc()
    {
        CreateValidation(_SubrentalPOEntity);

        //**************************validate data in CONTACTS tab*************************************
        var shipMethodTab = webElementAction
            .GetAllElementBySpecificAttribute("data-section", "tabContent")
            .FirstOrDefault(o => o.GetAttribute("data-tab-name") == "SHIP_METHOD");
        shipMethodTab.Click();
        ShipMethodTab currentShipMethodTab;
        var gridList =
            webElementAction.GetElementById(
                "shipMethodPickupAndReturn-MiniGrid-gridId"); //.FindElements(By.CssSelector(".ag-row.ag-row-focus"));//
        currentShipMethodTab = new ShipMethodTab();
        var colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
        CreateAddInGrid(currentShipMethodTab, colIds, true);
        ValidateEntityFieldDifferences(_SubrentalPOEntity.ShipMethod, currentShipMethodTab);

    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddSubrentalPO()
    {
        TestInitialize(nameof(AddSubrentalPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSubrentalPOFunc();
                this.SearchAndEditClick(_SubrentalPOEntity.GeneralTab.PO);
                ValidateInsertSubrentalPOFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSubrentalPO()
    {
        TestInitialize(nameof(DeleteSubrentalPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSubrentalPOFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_SubrentalPOEntity.GeneralTab.PO, "SubrentalPOList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditSubrentalPO()
    {
        TestInitialize(nameof(EditSubrentalPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSubrentalPOFunc();

                this.SearchAndEditClick(_SubrentalPOEntity.GeneralTab.PO);
                // define context page to variable

                CreateAdd(_SubrentalPOEntity);
                Thread.Sleep(1000);

                //click on post button
                webElementAction.GetElementByCssSelector(".icon-tick").Click();

                ClickOnSecondBackOnHistory();
                this.SearchAndEditClick(_SubrentalPOEntity.GeneralTab.PO);
                ValidateInsertSubrentalPOFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInSubrentalPO()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInSubrentalPO));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "SubrentalPO");
                ShowAllRedord();
                RefreshAllRows();
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
    public void ArrowLastBtnCheckInSubrentalPO()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInSubrentalPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "SubrentalPO");
                ShowAllRedord();
                RefreshAllRows();
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
    public void ArrowNextBtnCheckInSubrentalPO()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInSubrentalPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "SubrentalPO");
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
    public void ArrowPreviousBtnCheckInSubrentalPO()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInSubrentalPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "SubrentalPO");
                ShowAllRedord();
                RefreshAllRows();
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
    public void DetailValidateSubrentalPO()
    {
        TestInitialize(nameof(DetailValidateSubrentalPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSubrentalPOFunc();

                // include close Subrental PO
                RefreshAllRows(filterId: "includeClosed");

                SearchTextInMainGrid(_SubrentalPOEntity.GeneralTab.PO);
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("SubrentalPOList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _SubrentalPOEntity.GeneralTab.PO.Trim()).Click();
                ChangeScreenPageSize(35);
                Thread.Sleep(2000);
                gridList = webElementAction.GetElementById("SubrentalPOList-gridId");
                ReadOnlyCollection<IWebElement> colIds =
                    gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                //_SubrentalPOScreenEntity.BillingTab.SalesDisc = _SubrentalPOScreenEntity.BillingTab.SalesDisc.Replace("%", "");
                CreateValidationInGrid(colIds, _SubrentalPOEntity);
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
            {"Red", Color.FromArgb(203, 70, 70, 102)},
            {"Orange", Color.FromArgb(255, 153, 0, (int)0.4)},
            {"Yellow", Color.FromArgb(255, 255, 0, (int)0.4)},
        };

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOByBeginEndDate()
    {
        TestInitialize(nameof(FilterSubrentalPOByBeginEndDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPO");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("beginDate", "SubrentalPOList-gridId");
                filterSearch.FilterSearchInDateTimeDataType("usageBegDate", "usageEndDate");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOByPo()
    {
        TestInitialize(nameof(FilterSubrentalPOByPo));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPO");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("po", "SubrentalPOList-gridId", "PO#", colId: "poId");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOByVendor()
    {
        TestInitialize(nameof(FilterSubrentalPOByVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPO");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("vendorId", "SubrentalPOList-gridId", "Vendor");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOByOrder()
    {
        TestInitialize(nameof(FilterSubrentalPOByOrder));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPO");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("orderNo", "SubrentalPOList-gridId", columnName: "Order#");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOByProduction()
    {
        TestInitialize(nameof(FilterSubrentalPOByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPO");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("productionId", "SubrentalPOList-gridId", "Production", "production");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOByVendorType()
    {
        TestInitialize(nameof(FilterSubrentalPOByVendorType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPO");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("vendorType", "SubrentalPOList-gridId", "Vendor Type");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOBySubrentalReason()
    {
        TestInitialize(nameof(FilterSubrentalPOBySubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPO");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("subrentalReason", "SubrentalPOList-gridId", "Subrental Reason");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOByUnused()
    {
        TestInitialize(nameof(FilterSubrentalPOByUnused));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPO");

                RefreshAllRows();
                DataLegendNameFilter("UNUSED");
                FilterSearch filterSearch = new FilterSearch("unusedOnly", "SubrentalPOList-gridId", "Used", colId: "used", Color: ColorDict["Red"]);
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOByHistory()
    {
        TestInitialize(nameof(FilterSubrentalPOByHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPO");

                RefreshAllRows();
                DataLegendNameFilter("HISTORY");
                FilterSearch filterSearch = new FilterSearch("includeHistory", "SubrentalPOList-gridId", "History", "history");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOByClosed()
    {
        TestInitialize(nameof(FilterSubrentalPOByClosed));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPO");

                RefreshAllRows();
                DataLegendNameFilter("CLOSED");
                FilterSearch filterSearch = new FilterSearch("includeClosed", "SubrentalPOList-gridId", "Status", "status", "Closed", ColorDict["Yellow"]);
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOByOutOfSync()
    {
        TestInitialize(nameof(FilterSubrentalPOByOutOfSync));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPO");

                RefreshAllRows();
                DataLegendNameFilter("OUT_OF_SYNC");

                FilterSearch filterSearch = new FilterSearch("outOfSync", gridListId: "SubrentalPOList-gridId", "Out of Sync", Color: ColorDict["Orange"]);
                filterSearch.FilterSearchInCheckBoxDataType();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInSubrentalPO()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSubrentalPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "PurchaseOrder", subMenu: "SubrentalPO", filed: "amount");
                validateRequiredFields.Run();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    private void SearchAndEditClick(string code)
    {
        CloseFilterWindow();

        Thread.Sleep(700);
        ShowAllRedord();

        // Clear the search textbox if it's not empty
        if (webElementAction.IsElementPresent(By.CssSelector("[data-icon-name='clear-text']")) == true)
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();

        // Clear the search textbox if it's not empty
        if (webElementAction.IsElementPresent(By.CssSelector(".first-button-gap")) == true)
        {
            var listViewBtn = webElementAction.GetElementByCssSelector(".first-button-gap");
            listViewBtn.Click();
        }

        SearchTextInMainGrid(code);

        WaitForLoadingSpiner();
        Thread.Sleep(1000);
        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == code.Trim());

        selectRow.Click();

        WaitForLoadingSpiner();
        IWebElement editBtn = webElementAction.GetElementByCssSelector(".icon-edit");
        editBtn.Click();

    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPO");
                RefreshRecordDataInGrid("SubrentalPOList-gridId", columnId: "poId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}