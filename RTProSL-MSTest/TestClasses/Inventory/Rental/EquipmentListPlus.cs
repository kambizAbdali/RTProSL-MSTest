//develop by Mohammad_keshvarz

using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental.EquipmentListPlusEntity;

// is element class  for check  available or not available element or fields. 

// define clase  struct ParentEntity
public class EquipmentListPlusEntity
{
    // data struct haye zir ro dar constractor zir  call kardam ke niyaz nabashe har kodom ro be sorate joda to class parent ezafe konam
    public EquipmentListPlusEntity()
    {
        GeneralTab = new GeneralTab();
        PricingGLTab = new PricingGLTab();
        SettingTab = new SettingTab();
        EquipmentGroup = new EquipmentGroupTab();
        InspectionTab = new InspectionTab();
        SpecificationTab = new SpecificationTab();
    }

    [ValidationElementProperty("id")]
    public string EquipmentCode { set; get; }


    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationTabClick("GROUP")]
    public EquipmentGroupTab EquipmentGroup { get; set; }

    [ValidationTabClick("INSPECTION")]
    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    public InspectionTab InspectionTab { get; set; }

    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationTabClick("SPECIFICATIONS")]
    public SpecificationTab SpecificationTab { get; set; }

    [ValidationTabClick("GENERAL")]
    public GeneralTab GeneralTab { get; set; }

    [ValidationTabClick("PRICING_GL")]
    public PricingGLTab PricingGLTab { get; set; }

    [ValidationTabClick("SETTING")]
    public SettingTab SettingTab { get; set; }

    [ValidationElementProperty("departmentId")]
    public string Department { set; get; }

    [ValidationElementProperty("categoryId")]
    public string Category { set; get; }

    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    public string Description { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool InActive { get; set; }
}

public class GeneralTab
{
    public string Width { get; set; }
    public string Depth { get; set; }
    public string Height { get; set; }
    public string Cases { get; set; }
    public string Weight { get; set; }
    public string Volume { get; set; }
    [ValidationElementProperty("origin")]
    public string CountryofOrigin { get; set; }
    public string Commodity { get; set; }
    public string Manufacturer { get; set; }
    [ValidationElementProperty("manufacturerPartNo")]
    public string ManufacturerPart { get; set; }
    public string SortOrder { get; set; }

    [ValidationElementProperty("packingDepartmentId")]
    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    public string PackingDepartment { get; set; }

    public string BarcodePrintDescription { get; set; }

    [ValidationDataType(DataType.TextArea)]
    public string Notes { get; set; }

    [ValidationDataType(DataType.TextArea)]
    public string CustomerNotes { get; set; }
}

// define struct PricingGLEntity                                                      
public class PricingGLTab
{
    [ValidationElementProperty("glAccountId")]
    public string RentalGLAccount { get; set; }

    [ValidationElementProperty("subrentalGlAccountId")]
    public string SubrentalGLAccount { get; set; }

    [ValidationElementProperty("billLossAccountId")]
    public string LossGLAccount { get; set; }

    [ValidationElementProperty("inventoryGlAccountId")]
    public string InventoryGLAccount { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[0].daily")]
    public string BDTCURRENCYDaily { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[0].weekly")]
    public string Weekly1 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[0].biWeekly")]
    public string BiWeekly1 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[0].monthly")]
    public string Monthly1 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[0].replaceCost")]
    public string ReplacementCost1 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[0].replacePrice")]
    public string ReplacementPrice1 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[0].minDaysPerWeek")]
    public string MinDPW1 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[0].maxDiscountPercent")]
    public string MaxDiscount1 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementName("locationPriceRecords[1].daily")]
    public string CADCURRENCYDaily { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[1].weekly")]
    public string Weekly2 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[1].biWeekly")]
    public string BiWeekly2 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[1].monthly")]
    public string Monthly2 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[1].replaceCost")]
    public string ReplacementCost2 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[1].replacePrice")]
    public string ReplacementPrice2 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[1].minDaysPerWeek")]
    public string MinDPW2 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[1].maxDiscountPercent")]
    public string MaxDiscount2 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[2].daily")]
    public string EURCURRENCYDaily { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[2].weekly")]
    public string Weekly3 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[2].biWeekly")]
    public string BiWeekly3 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[2].monthly")]
    public string Monthly3 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[2].replaceCost")]
    public string ReplacementCost3 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[2].replacePrice")]
    public string ReplacementPrice3 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[2].minDaysPerWeek")]
    public string MinDPW3 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[2].maxDiscountPercent")]
    public string MaxDiscount3 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[3].daily")]
    public string JPYCURRENCYDaily { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[3].weekly")]
    public string Weekly4 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[3].biWeekly")]
    public string BiWeekly4 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[3].monthly")]
    public string Monthly4 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[3].replaceCost")]
    public string ReplacementCost4 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[3].replacePrice")]
    public string ReplacementPrice4 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[3].minDaysPerWeek")]
    public string MinDPW4 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[3].maxDiscountPercent")]
    public string MaxDiscount4 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[4].daily")]
    public string NOKCURRENCYDaily { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[4].weekly")]
    public string Weekly5 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[4].biWeekly")]
    public string BiWeekly5 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[4].monthly")]
    public string Monthly5 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[4].replaceCost")]
    public string ReplacementCost5 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[4].replacePrice")]
    public string ReplacementPrice5 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[4].minDaysPerWeek")]
    public string MinDPW5 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[4].maxDiscountPercent")]
    public string MaxDiscount5 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[5].daily")]
    public string TTDCURRENCYDaily { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[5].weekly")]
    public string Weekly6 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[5].biWeekly")]
    public string BiWeekly6 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[5].monthly")]
    public string Monthly6 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[5].replaceCost")]
    public string ReplacementCost6 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[5].replacePrice")]
    public string ReplacementPrice6 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[5].minDaysPerWeek")]
    public string MinDPW6 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[5].maxDiscountPercent")]
    public string MaxDiscount6 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[6].daily")]
    public string USDCURRENCYDaily { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[6].weekly")]
    public string Weekly7 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[6].biWeekly")]
    public string BiWeekly7 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[6].monthly")]
    public string Monthly7 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[6].replaceCost")]
    public string ReplacementCost7 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[6].replacePrice")]
    public string ReplacementPrice7 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[6].minDaysPerWeek")]
    public string MinDPW7 { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("locationPriceRecords[6].maxDiscountPercent")]
    public string MaxDiscount7 { get; set; }
}

// define struct SettingEntity
public class SettingTab
{

    [ValidationDataType(DataType.CheckBox)]
    public bool Inventory { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("accessory")]
    public bool AccessoryItem { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("barcodedOnly")]
    public bool BarcodedOnly { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("discountable")]
    public bool Discountable { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("taxable")]
    public bool Taxable { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("sellable")]
    public bool Sellable { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("Serial Number Required")]
    public bool SerialNumberRequired { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("printBarcode")]
    public bool PrintBarcode { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("rollupPricesToMainItem")]
    public bool RollupPricestoMainItem { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnPickList")]
    public bool ShowonPickListasMain { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnOrder")]
    public bool ShowonOrderEntry { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnPickList")]
    public bool PrintonQuote { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("printOnEquipPickList")]
    public bool PrintonEquipmentPickList { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnContract")]
    public bool PrintonContract { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("printOnPullList")]
    public bool PrintonPullList { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("printSerialNo")]
    public bool PrintSerialNumber { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnInvoice")]
    public bool PrintonInvoice { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("rfidOnly")]
    public bool RFIDOnly { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("depreciate")]
    public bool Depreciate { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("partner")]
    public bool Partner { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnWebsite")]
    public bool ShowonWebsite { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("disallowCheckoutMoreThanAvailable")]
    public bool DoNotAllowCheckingoutMoreThanAvailable { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("printOnPullReturnList")]
    public bool PrintScannerReadableEquipCodeonPullReturn { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("Signed Terms & allowCheckoutNotOrdered")]
    public bool AllowRentalCheckoutIfNotOrderedMorethanOrdered { get; set; }
}

// define struct GroupEntity
public class EquipmentGroupTab
{
    public string Description { set; get; }

    [ValidationElementProperty("id")]
    [ValidationColID("id")]
    public string Code { set; get; }
}

public class InspectionTab
{
    [ValidationElementProperty("inspection")]
    [ValidationDataType(DataType.CheckBox)]
    public bool Inspection { get; set; }

    [ValidationElementProperty("inspectionCheckinPrompt")]
    [ValidationDataType(DataType.CheckBox)]
    public bool InspectionCheckinPrompt { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    public bool DataStrategy { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    public bool InspectionReturntoStock { get; set; }


    [ValidationElementProperty("availableIfInspection")]
    [ValidationDataType(DataType.CheckBox)]
    public bool AvailableforRentalafter { get; set; }

    [ValidationElementProperty("availableAfterDaysInInspection")]
    public string DaysInInspection { get; set; }

    [ValidationElementProperty("lifeOfItem")]
    public string LifeOfItemDays { get; set; }

    [ValidationDataType(DataType.TextArea)]
    public string InspectionInstructions { get; set; }
}

public class SpecificationTab
{
    public string Description { set; get; }

    [ValidationElementProperty("id")]
    [ValidationColID("id")]
    public string Code { set; get; }

    [ValidationElementProperty("specificationCategoryId")]
    [ValidationColID("specificationCategoryId")]
    public string SpecificationCategory { set; get; }

}


[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class EquipmentPlus : BaseClass
{

    //new struct 
    public EquipmentListPlusEntity _EquipmentListPlusEntity;

    public void AddEquipmentFunc(bool IsEdit = false)
    {
        if (IsEdit)
        {
            goto startEdit;

        }

        GoToUrl("MMInventory", "EquipmentList");
        ShowAllRedord();
        Thread.Sleep(2000);
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

    startEdit:
        _EquipmentListPlusEntity = new EquipmentListPlusEntity();
        Thread.Sleep(2000);
        // click on main
        var ContextMain = GetFormLeftSideContext(true);
        // write data random in fields main
        new WebElementDataGenerator(ContextMain);
        Thread.Sleep(3000);
        CreateAdd(_EquipmentListPlusEntity, ContextMain);
        Thread.Sleep(2000);

        /*------------------------group Section------------------------------*/
        groupBtnClick();
        var groupContext =
            webElementAction.GetElementBySpecificAttribute("data-header-name", "EquipmentGroupComboGrid-MiniGrid");
        webElementAction.GetElementBySpecificAttribute("id", "MINI_GRID_ADD_MULTI_SELECTION_BUTTON",
            groupContext).Click();
        Thread.Sleep(500);


        if (webElementAction.IsElementPresent(By.CssSelector(".ag-cell.ag-cell-not-inline-editing.ag-cell-normal-height.ag-cell-last-left-pinned.grid-icon-class.ag-cell-focus.ag-cell-value")))
        {
            var defaultSelectedRowgroup = webElementAction.GetElementByCssSelector(
                ".ag-cell.ag-cell-not-inline-editing.ag-cell-normal-height.ag-cell-last-left-pinned.grid-icon-class.ag-cell-focus.ag-cell-value");
            defaultSelectedRowgroup.Click();
        }


        Thread.Sleep(1000);
        webElementAction.GetElementByCssSelector(".confirm-button").Click();
        var groupColIds = webElementAction.GetElementById("EquipmentGroupComboGrid-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
        CreateAddInGrid(_EquipmentListPlusEntity.EquipmentGroup, groupColIds);
        Thread.Sleep(2000);


        /*------------------------INSPECTION Section------------------------------*/
        inspectionBtnClick();
        var inspectionContext = webElementAction
            .GetAllElementBySpecificAttribute("data-section", "tabContent").FirstOrDefault(o =>
                o.GetAttribute("data-tab-name") == "INSPECTION");
        try
        {
            new WebElementDataGenerator(inspectionContext);
        }
        catch
        {
            //ignore
        }

        var lifeOfItemcontext = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "lifeOfItem");
        new WebElementDataGenerator(lifeOfItemcontext);
        Thread.Sleep(1000);
        var inspectionInstructionscontext = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "inspectionInstructions");
        new WebElementDataGenerator(inspectionInstructionscontext);
        CreateAdd(_EquipmentListPlusEntity.InspectionTab, inspectionContext);

        /*------------------------Specification Section------------------------------*/

        SpecificationTabBtnClick();
        var SpecificationsContextinspection =
            webElementAction.GetElementBySpecificAttribute("data-header-name", "specificationComboGrid-MiniGrid");
        webElementAction.GetElementBySpecificAttribute("id", "MINI_GRID_ADD_MULTI_SELECTION_BUTTON",
            SpecificationsContextinspection).Click();
        Thread.Sleep(500);
        //ye record ezafe mishavad
        var defaultSelectedRowinspection = webElementAction.GetElementByCssSelector(
            ".ag-cell.ag-cell-not-inline-editing.ag-cell-normal-height.ag-cell-last-left-pinned.grid-icon-class.ag-cell-focus.ag-cell-value");
        defaultSelectedRowinspection.Click();
        Thread.Sleep(1000);
        webElementAction.GetElementByCssSelector(".confirm-button").Click();
        var SpecificationColIds = webElementAction.GetElementById("specificationComboGrid-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
        CreateAddInGrid(_EquipmentListPlusEntity.SpecificationTab, SpecificationColIds);
        Thread.Sleep(2000);
        SaveAndConfirmCheck();
    }
    private void ValidateInsertEquipmentFunc()
    {

        if (webElementAction.IsElementPresent(By.Id("EquipmentListBodyFilterForm")))
        {//close filter window
            webElementAction.GetElementByCssSelector(".filter-button-icon").Click();
        }
        SearchAndEditClick(_EquipmentListPlusEntity.EquipmentCode);
        CreateValidation(_EquipmentListPlusEntity);

        //moghayese
        groupBtnClick();
        var groupRows = webElementAction.GetElementById("EquipmentGroupComboGrid-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus"));//
        EquipmentGroupTab EquipmentGroupCurent;
        foreach (var desiredRow in groupRows)
        {
            try
            {
                if (desiredRow.FindElements(By.TagName("div")).FirstOrDefault(o => o.GetAttribute("col-id") == "id") != null)
                {
                    EquipmentGroupCurent = new EquipmentGroupTab();
                    CreateAddInGrid(EquipmentGroupCurent, desiredRow);
                    ValidateEntityFieldDifferences(_EquipmentListPlusEntity.EquipmentGroup, EquipmentGroupCurent);
                }
            }
            catch
            {
                //ignored
            }
        }


        SpecificationTabBtnClick();
        var SpecificationRows = webElementAction.GetElementById("specificationComboGrid-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus"));//
        SpecificationTab SpecificationTabCurent;
        foreach (var desiredRow in SpecificationRows)
        {
            try
            {
                if (desiredRow.FindElements(By.TagName("div")).FirstOrDefault(o => o.GetAttribute("col-id") == "id") != null)
                {
                    SpecificationTabCurent = new SpecificationTab();
                    CreateAddInGrid(SpecificationTabCurent, desiredRow);
                    ValidateEntityFieldDifferences(_EquipmentListPlusEntity.EquipmentGroup, SpecificationTabCurent);
                }
            }
            catch
            {
                //ignored
            }
        }

    }
    public void inspectionBtnClick()
    {
        var inspectionBtn = webElementAction
            .GetAllElementBySpecificAttribute("type", "button").FirstOrDefault(o =>
                o.GetAttribute("data-tab-name") == "INSPECTION");
        inspectionBtn.Click();
    }
    private void SpecificationTabBtnClick()
    {
        var specificationBtn = webElementAction
            .GetAllElementBySpecificAttribute("type", "button").FirstOrDefault(o =>
                o.GetAttribute("data-tab-name") == "SPECIFICATIONS");
        specificationBtn.Click();
    }
    private void groupBtnClick()
    {
        var inspectionBtn = webElementAction
            .GetAllElementBySpecificAttribute("type", "button").FirstOrDefault(o =>
                o.GetAttribute("data-tab-name") == "GROUP");
        inspectionBtn.Click();
    }



    // mabye needs multiple running for pass.
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void addEquipmentPlus()
    {
        TestInitialize(nameof(addEquipmentPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddEquipmentFunc();
                ValidateInsertEquipmentFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteEquipmentPlus()
    {
        TestInitialize(nameof(DeleteEquipmentPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call department add 
                AddEquipmentFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_EquipmentListPlusEntity.EquipmentCode, "EquipmentList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime * (3 / 5))]
    public void EditEquipmentPlus()
    {
        TestInitialize(nameof(EditEquipmentPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                _EquipmentListPlusEntity = new EquipmentListPlusEntity();
                _EquipmentListPlusEntity.EquipmentCode = GetAnEquipmentCode();
                SearchAndEditClick(_EquipmentListPlusEntity.EquipmentCode);
                AddEquipmentFunc(IsEdit: true);
                ValidateInsertEquipmentFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private string GetAnEquipmentCode()
    {
        RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field
        ShowAllRedord();
        //equipment Code In firstRow with barcode
        Thread.Sleep(2000);
        return ObjectRepository.Driver.FindElements(By.CssSelector("[col-id='id'][role='gridcell']"))
             .First().Text;
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckEquipmentPlus()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckEquipmentPlus));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "EquipmentList");
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
    public void ArrowLastBtnCheckEquipmentPlus()
    {
        TestInitialize(nameof(ArrowLastBtnCheckEquipmentPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "EquipmentList");
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
    public void ArrowNextBtnCheckEquipmentPlus()
    {
        TestInitialize(nameof(ArrowNextBtnCheckEquipmentPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "EquipmentList");
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
    public void ArrowPreviousBtnCheckEquipmentPlus()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckEquipmentPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "EquipmentList");
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
    public void CardViewBtnCheckEquipmentPlus()
    {
        TestInitialize(nameof(CardViewBtnCheckEquipmentPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "EquipmentList");
                ShowAllRedord();
                //call method card viewBtn
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckEquipmentPlus()
    {
        TestInitialize(nameof(ListViewtBtnCheckEquipmentPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "EquipmentList");
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
    public void InactiveBtnCheckEquipmentPlus()
    {
        TestInitialize(nameof(InactiveBtnCheckEquipmentPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");

                ShowAllRedord();

                InActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime * 2)]
    public void DetailValidateEquipmentPlus()
    {
        TestInitialize(nameof(DetailValidateEquipmentPlus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddEquipmentFunc();

                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_EquipmentListPlusEntity.EquipmentCode.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("EquipmentList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _EquipmentListPlusEntity.EquipmentCode.Trim()).Click();

                ChangeScreenPageSize(30);
                Thread.Sleep(3000);
                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                Thread.Sleep(2000);
                CreateValidationInGrid(colIds, _EquipmentListPlusEntity);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentListPlusByDepartment()
    {
        TestInitialize(nameof(FilterEquipmentListPlusByDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");

                //Select all value in grid
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("departmentId", "EquipmentList-gridId", "Department");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentListPlusByCategory()
    {
        TestInitialize(nameof(FilterEquipmentListPlusByCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");

                //Select all value in grid
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("categoryId", "EquipmentList-gridId", "Category");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentListPlusByEquipment()
    {
        TestInitialize(nameof(FilterEquipmentListPlusByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");

                //Select all value in grid
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("equipmentId", "EquipmentList-gridId", "Code", colId: "id");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentListPlusByDescription()
    {
        TestInitialize(nameof(FilterEquipmentListPlusByDescription));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");

                //Select all value in grid
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("description", "EquipmentList-gridId", "Description");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentListPlusByPIGroup()
    {
        TestInitialize(nameof(FilterEquipmentListPlusByPIGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");

                //Select all value in grid
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("pIgroup", "EquipmentList-gridId");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentListPlusByEquipmentGroup()
    {
        TestInitialize(nameof(FilterEquipmentListPlusByEquipmentGroup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");

                //Select all value in grid
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("equipmentGroupId", "EquipmentList-gridId");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentListPlusByIncludeInactiveEquipment()
    {
        TestInitialize(nameof(FilterEquipmentListPlusByIncludeInactiveEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");

                //Select all value in grid
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                ShowAllRedord();

                //Click in filter Equipment List
                DataLegendNameFilter("INACTIVE");

                FilterSearch filterSearch = new FilterSearch("includeInactive", "EquipmentList-gridId", "Inactive", "inactive");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInEquipmentList()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInEquipmentList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "MMInventory", subMenu: "EquipmentList", filed: "description");
                validateRequiredFields.Run();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    ImageDetector imageDetector;
    [TestMethod]
    public void AddAndPrintEquipmentImageInEquipment()
    {
        TestInitialize(nameof(AddAndPrintEquipmentImageInEquipment));
        imageDetector = new ImageDetector();

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
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
    public void EditEquipmentPlusPicture()
    {
        TestInitialize(nameof(EditEquipmentPlusPicture));
        imageDetector = new ImageDetector();

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                EditPictureValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EquipmentNewArrivePlusPicture()
    {
        TestInitialize(nameof(EquipmentNewArrivePlusPicture));
        imageDetector = new ImageDetector();

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                EditPictureValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    public string GetRandomBarcodeEquipment()
    {
        RefreshAllRows(filterId: "currencyId");
        ShowAllRedord();
        FindColumnInMainGrid("Barcoded Only");
        var barcodeFilterElement = webElementAction
            .GetElementByCssSelector("[col-id='barcodedOnly'][role='columnheader']")
            .FindElement(By.CssSelector(".ag-header-cell-menu-button"));
        barcodeFilterElement.Click();

        var sortDescendingElement =
            webElementAction.GetElementByCssSelector(".ag-menu-list > div:nth-of-type(3)");
        sortDescendingElement.Click();

        //equipment Code In firstRow with barcode
        Thread.Sleep(2000);
        var equipmentCode = ObjectRepository.Driver
             .FindElements(By.CssSelector("[col-id='id'][role='gridcell']"))
             .First().Text;
        return equipmentCode;
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateSerialNumberOptionRadioButtonsInEquipmentListPlus()
    {
        TestInitialize(nameof(ValidateSerialNumberOptionRadioButtonsInEquipmentListPlus));

        while (!testPassed && retryCount < maxRetries)
        {
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                var randomBarcodeEquipment = GetRandomBarcodeEquipment();
                SearchAndEditClick(randomBarcodeEquipment);

                // Deselect RFID checkbox if present  
                DeSelectingRFIDCheckbox();

                // Click on the post button  
                webElementAction.GetElementByCssSelector(".icon-tick").Click();
                WaitForLoadingSpiner();
                // Click on the action menu  
                var actionMenu = webElementAction.GetElementByCssSelector(
                    "[data-focus-lock-disabled='false'] #ACTION_TOOL_DROPDOWN .tools-box-dropdown-toggle");
                actionMenu.Click();

                // Click on the add new barcode submenu  
                var addNewBarcodeSubMenu = ObjectRepository.Driver.FindElements(By.TagName("li"))
                    .FirstOrDefault(o => o.GetAttribute("data-menu-id").Contains("ADD_BARCODED_ITEMS"));
                addNewBarcodeSubMenu?.Click();

                // Validate serial number options  
                string[] serialNumberRadioButtonCssSelectors = {
                "#serialNoFormat-none",
                "#serialNoFormat-autoAssignSerial",
                "#serialNoFormat-enterSerialNo"
                };

                ValidateSerialNumberOptions(serialNumberRadioButtonCssSelectors);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
        }
    }

    private void DeSelectingRFIDCheckbox()
    {
        ClickTab("SETTING");
        if (webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='rfidOnly']")))
            webElementAction.DeSelectingCheckbox("rfidOnly");
    }

    private void ValidateSerialNumberOptions(string[] serialNumberRadioButtonCssSelectors)
    {
        foreach (var radioButton in serialNumberRadioButtonCssSelectors)
        {
            var serialNoFormat = webElementAction.GetElementByCssSelector(radioButton);
            serialNoFormat.Click();

            var serialNoInput = webElementAction.GetInputElementByDataFormItemNameInDiv("serialNo");
            bool isReadOnly = serialNoInput.GetAttribute("class").Contains("main-input-read-only");

            GenerateDataToPurchaseAmountAndQuantity();

            // Uncheck Print option and select Auto Assign Barcodes
            webElementAction.DeSelectingCheckbox("printBarcodes");
            webElementAction.SelectingCheckbox("autoAssignBarcodes");

            string randomSerialNumber = string.Empty;

            if (radioButton == "#serialNoFormat-enterSerialNo")
            {
                var inputSerialNumberElement = webElementAction.GetInputElementByDataFormItemNameInDiv("serialNo");
                randomSerialNumber = RandomValueGenerator.GenerateRandomInt(4);
                inputSerialNumberElement.SendKeys(randomSerialNumber);
            }

            // Click on addToRentalBarcodeList
            webElementAction.Click(By.CssSelector("[data-button-type=confirm]"));

            string serialNumber = webElementAction.GetAllElementsByCssSelector("[col-id='serialNo'][role='gridcell']")[0].Text;

            switch (radioButton)
            {
                case "#serialNoFormat-none":
                    Assert.IsTrue(isReadOnly, $"{radioButton} should be read-only.");
                    Assert.IsTrue(string.IsNullOrEmpty(serialNumber), "SerialNumber is not null or Empty!!!");
                    break;

                case "#serialNoFormat-autoAssignSerial":
                    Assert.IsTrue(isReadOnly, $"{radioButton} should be read-only.");
                    Assert.IsFalse(string.IsNullOrEmpty(serialNumber), "Inserted serial# does not assign automatically.");
                    break;

                case "#serialNoFormat-enterSerialNo":
                    Assert.IsFalse(isReadOnly, $"{radioButton} should not be read-only.");
                    Assert.AreEqual(randomSerialNumber, serialNumber, "Inserted serial# does not equal with saved value.");
                    break;
            }
            RefreshPage();
        }
    }


    private void GenerateDataToPurchaseAmountAndQuantity()
    {
        var quantityToAddInput = webElementAction.GetInputElementByDataFormItemNameInDiv("quantityToAdd");
        quantityToAddInput.SendKeys("1");

        WaitForLoadingSpiner();

        var purchaseAmountInput = webElementAction.GetInputElementByDataFormItemNameInDiv("purchaseAmount");
        purchaseAmountInput.SendKeys("1");
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshRecordDataInGrid("EquipmentList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrintLabelsReport()
    {
        TestInitialize(nameof(ValidatePrintLabelsReport));
        while (!testPassed && retryCount < maxRetries)
        {
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReportSubMenu(menu: "PRINT_TOOL_DROPDOWN", subMenu: "PRINT_LABELS");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
        }
    }

    //------------------------------------------------------------------------------------------------------

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInRentalPriceList()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRentalPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "RENTAL_PRICE_LIST");
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
    public void ValidateListBtnInRentalPriceList()
    {
        TestInitialize(nameof(ValidateListBtnInRentalPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "RENTAL_PRICE_LIST");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * 3)]
    public void ValidateExportPDFBtnInRentalPriceList()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRentalPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "RENTAL_PRICE_LIST");
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
    public void ValidateExportExcelBtnInRentalPriceList()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRentalPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "RENTAL_PRICE_LIST");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInRentalPriceList()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRentalPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "RENTAL_PRICE_LIST");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRentalPriceList()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRentalPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "RENTAL_PRICE_LIST");
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
    public void ValidateExportPDFWithRandomNamingBtnInRentalPriceList()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRentalPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "RENTAL_PRICE_LIST");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    //------------------------------------------------------------------------------------------------------

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInPrintImage()
    {
        TestInitialize(nameof(ValidatePreviewBtnInPrintImage));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "PRINT_IMAGES");
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
    public void ValidateListBtnInPrintImage()
    {
        TestInitialize(nameof(ValidateListBtnInPrintImage));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "PRINT_IMAGES");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * 3)]
    public void ValidateExportPDFBtnInPrintImage()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInPrintImage));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "PRINT_IMAGES");
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
    public void ValidateExportExcelBtnInPrintImage()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInPrintImage));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "PRINT_IMAGES");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInPrintImage()
    {
        TestInitialize(nameof(ValidatePrinterBtnInPrintImage));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "PRINT_IMAGES");
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
    public void ValidateExportPDFWithTemplateNamingBtnInPrintImage()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInPrintImage));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "PRINT_IMAGES");
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
    public void ValidateExportPDFWithRandomNamingBtnInPrintImage()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInPrintImage));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                RefreshAllRows();
                GoToSubMenu("PRINT_TOOL_DROPDOWN", "PRINT_IMAGES");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}