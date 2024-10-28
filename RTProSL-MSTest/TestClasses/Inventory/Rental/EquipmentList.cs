//develop by Mohammad_keshvarz

using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using OpenQA.Selenium.Interactions;
using WindowsInput;
using static RTProSL_MSTest.TestClasses.PurchaseOrder.Inventory.InventoryPO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AventStack.ExtentReports.Gherkin.Model;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;

// is element class  for check  available or not available element or fields. 

// define clase  struct ParentEntity
public class EquipmentEntity
{
    // data struct haye zir ro dar constractor zir  call kardam ke niyaz nabashe har kodom ro be sorate joda to class parent ezafe konam
    public EquipmentEntity()
    {
        GeneralTab = new GeneralTab();
        PricingGLTab = new PricingGLTab();
        SettingTab = new SettingTab();
        EquipmentGroup = new EquipmentGroupTab();
        InspectionTab = new InspectionTab();
        SpecificationTab = new SpecificationTab();
        //LocationQty = new LOCATION_QTYTab();
    }


    [ValidationElementProperty("id")]
    public string EquipmentCode { set; get; }


    [ValidationTabClick("GENERAL")]
    public GeneralTab GeneralTab { get; set; }


    [ValidationTabClick("LocationQty")]
    public LocationQty LocationQty { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationTabClick("PRICING_GL")]
    public PricingGLTab PricingGLTab { get; set; }

    [ValidationTabClick("SETTING")]
    public SettingTab SettingTab { get; set; }

    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationTabClick("GROUP")]
    public EquipmentGroupTab EquipmentGroup { get; set; }


    [ValidationTabClick("INSPECTION")]
    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    public InspectionTab InspectionTab { get; set; }

    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationTabClick("SPECIFICATIONS")]
    public SpecificationTab SpecificationTab { get; set; }

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




public class LocationQty
{
    //To Do Validate
}


public class GeneralTab
{
    [ValidationIgnoreInGrid]
    public string Width { get; set; }
    [ValidationIgnoreInGrid]
    public string Depth { get; set; }
    [ValidationIgnoreInGrid]
    public string Height { get; set; }
    [ValidationIgnoreInGrid]
    public string Cases { get; set; }
    [ValidationIgnoreInGrid]
    public string Weight { get; set; }
    [ValidationIgnoreInGrid]
    public string Volume { get; set; }
    [ValidationElementProperty("origin")]
    [ValidationIgnoreInGrid]
    public string CountryofOrigin { get; set; }

    [ValidationIgnoreInGrid]
    public string Commodity { get; set; }

    [ValidationIgnoreInGrid]
    public string Manufacturer { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("manufacturerPartNo")]
    public string ManufacturerPart { get; set; }
    public string SortOrder { get; set; }

    [ValidationElementProperty("packingDepartmentId")]
    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    public string PackingDepartment { get; set; }

    [ValidationIgnoreInGrid]
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

    [ValidationElementProperty("locationPriceRecords[0].daily")]
    public string BDTCURRENCYDaily { get; set; }

    [ValidationElementProperty("locationPriceRecords[0].weekly")]
    public string Weekly1 { get; set; }

    [ValidationElementProperty("locationPriceRecords[0].biWeekly")]
    public string BiWeekly1 { get; set; }

    [ValidationElementProperty("locationPriceRecords[0].monthly")]
    public string Monthly1 { get; set; }

    [ValidationElementProperty("locationPriceRecords[0].replaceCost")]
    public string ReplacementCost1 { get; set; }

    [ValidationElementProperty("locationPriceRecords[0].replacePrice")]
    public string ReplacementPrice1 { get; set; }

    [ValidationElementProperty("locationPriceRecords[0].minDaysPerWeek")]
    public string MinDPW1 { get; set; }

    [ValidationElementProperty("locationPriceRecords[0].maxDiscountPercent")]
    public string MaxDiscount1 { get; set; }


    [ValidationElementName("locationPriceRecords[1].daily")]
    public string CADCURRENCYDaily { get; set; }

    [ValidationElementProperty("locationPriceRecords[1].weekly")]
    public string Weekly2 { get; set; }

    [ValidationElementProperty("locationPriceRecords[1].biWeekly")]
    public string BiWeekly2 { get; set; }

    [ValidationElementProperty("locationPriceRecords[1].monthly")]
    public string Monthly2 { get; set; }

    [ValidationElementProperty("locationPriceRecords[1].replaceCost")]
    public string ReplacementCost2 { get; set; }

    [ValidationElementProperty("locationPriceRecords[1].replacePrice")]
    public string ReplacementPrice2 { get; set; }

    [ValidationElementProperty("locationPriceRecords[1].minDaysPerWeek")]
    public string MinDPW2 { get; set; }

    [ValidationElementProperty("locationPriceRecords[1].maxDiscountPercent")]
    public string MaxDiscount2 { get; set; }

    [ValidationElementProperty("locationPriceRecords[2].daily")]
    public string EURCURRENCYDaily { get; set; }

    [ValidationElementProperty("locationPriceRecords[2].weekly")]
    public string Weekly3 { get; set; }

    [ValidationElementProperty("locationPriceRecords[2].biWeekly")]
    public string BiWeekly3 { get; set; }

    [ValidationElementProperty("locationPriceRecords[2].monthly")]
    public string Monthly3 { get; set; }

    [ValidationElementProperty("locationPriceRecords[2].replaceCost")]
    public string ReplacementCost3 { get; set; }

    [ValidationElementProperty("locationPriceRecords[2].replacePrice")]
    public string ReplacementPrice3 { get; set; }

    [ValidationElementProperty("locationPriceRecords[2].minDaysPerWeek")]
    public string MinDPW3 { get; set; }

    [ValidationElementProperty("locationPriceRecords[2].maxDiscountPercent")]
    public string MaxDiscount3 { get; set; }


    [ValidationElementProperty("locationPriceRecords[3].daily")]
    public string JPYCURRENCYDaily { get; set; }

    [ValidationElementProperty("locationPriceRecords[3].weekly")]
    public string Weekly4 { get; set; }

    [ValidationElementProperty("locationPriceRecords[3].biWeekly")]
    public string BiWeekly4 { get; set; }

    [ValidationElementProperty("locationPriceRecords[3].monthly")]
    public string Monthly4 { get; set; }

    [ValidationElementProperty("locationPriceRecords[3].replaceCost")]
    public string ReplacementCost4 { get; set; }

    [ValidationElementProperty("locationPriceRecords[3].replacePrice")]
    public string ReplacementPrice4 { get; set; }

    [ValidationElementProperty("locationPriceRecords[3].minDaysPerWeek")]
    public string MinDPW4 { get; set; }

    [ValidationElementProperty("locationPriceRecords[3].maxDiscountPercent")]
    public string MaxDiscount4 { get; set; }

    [ValidationElementProperty("locationPriceRecords[4].daily")]
    public string NOKCURRENCYDaily { get; set; }

    [ValidationElementProperty("locationPriceRecords[4].weekly")]
    public string Weekly5 { get; set; }

    [ValidationElementProperty("locationPriceRecords[4].biWeekly")]
    public string BiWeekly5 { get; set; }

    [ValidationElementProperty("locationPriceRecords[4].monthly")]
    public string Monthly5 { get; set; }

    [ValidationElementProperty("locationPriceRecords[4].replaceCost")]
    public string ReplacementCost5 { get; set; }

    [ValidationElementProperty("locationPriceRecords[4].replacePrice")]
    public string ReplacementPrice5 { get; set; }

    [ValidationElementProperty("locationPriceRecords[4].minDaysPerWeek")]
    public string MinDPW5 { get; set; }

    [ValidationElementProperty("locationPriceRecords[4].maxDiscountPercent")]
    public string MaxDiscount5 { get; set; }

    [ValidationElementProperty("locationPriceRecords[5].daily")]
    public string TTDCURRENCYDaily { get; set; }

    [ValidationElementProperty("locationPriceRecords[5].weekly")]
    public string Weekly6 { get; set; }

    [ValidationElementProperty("locationPriceRecords[5].biWeekly")]
    public string BiWeekly6 { get; set; }

    [ValidationElementProperty("locationPriceRecords[5].monthly")]
    public string Monthly6 { get; set; }

    [ValidationElementProperty("locationPriceRecords[5].replaceCost")]
    public string ReplacementCost6 { get; set; }

    [ValidationElementProperty("locationPriceRecords[5].replacePrice")]
    public string ReplacementPrice6 { get; set; }

    [ValidationElementProperty("locationPriceRecords[5].minDaysPerWeek")]
    public string MinDPW6 { get; set; }

    [ValidationElementProperty("locationPriceRecords[5].maxDiscountPercent")]
    public string MaxDiscount6 { get; set; }

    [ValidationElementProperty("locationPriceRecords[6].daily")]
    public string USDCURRENCYDaily { get; set; }

    [ValidationElementProperty("locationPriceRecords[6].weekly")]
    public string Weekly7 { get; set; }

    [ValidationElementProperty("locationPriceRecords[6].biWeekly")]
    public string BiWeekly7 { get; set; }

    [ValidationElementProperty("locationPriceRecords[6].monthly")]
    public string Monthly7 { get; set; }

    [ValidationElementProperty("locationPriceRecords[6].replaceCost")]
    public string ReplacementCost7 { get; set; }

    [ValidationElementProperty("locationPriceRecords[6].replacePrice")]
    public string ReplacementPrice7 { get; set; }

    [ValidationElementProperty("locationPriceRecords[6].minDaysPerWeek")]
    public string MinDPW7 { get; set; }

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

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("printBarcode")]
    public bool PrintBarcode { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("rollupPricesToMainItem")]
    public bool RollupPricestoMainItem { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnPickList")]
    public bool ShowonPickListasMain { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnOrder")]
    public bool ShowonOrderEntry { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnPickList")]
    public bool PrintonQuote { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("printOnEquipPickList")]
    public bool PrintonEquipmentPickList { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnContract")]
    public bool PrintonContract { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("printOnPullList")]
    public bool PrintonPullList { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("printSerialNo")]
    public bool PrintSerialNumber { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnInvoice")]
    public bool PrintonInvoice { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("rfidOnly")]
    public bool RFIDOnly { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("depreciate")]
    public bool Depreciate { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("partner")]
    public bool Partner { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnWebsite")]
    public bool ShowonWebsite { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("disallowCheckoutMoreThanAvailable")]
    public bool DoNotAllowCheckingoutMoreThanAvailable { get; set; }

    [ValidationIgnoreInGrid]
    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("printOnPullReturnList")]
    public bool PrintScannerReadableEquipCodeonPullReturn { get; set; }

    [ValidationIgnoreInGrid]
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
public class Equipment : BaseClass
{

    //new struct    
    public EquipmentEntity _EquipmentEntity;

    public EquipmentEntity AddEquipmentFunc(bool IsEdit = false)
    {
        if (IsEdit)
        {
            goto startEdit;
        }

        GoToUrl("MMInventory", "EquipmentSummaryList");
        Thread.Sleep(2000);
        RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
    startEdit:
        _EquipmentEntity = new EquipmentEntity();
        Thread.Sleep(2000);
        // click on main
        var Contextmain = GetFormLeftSideContext(true);
        // write data random in fields main
        new WebElementDataGenerator(Contextmain);

        var inActiveElement = webElementAction.GetInputElementByDataFormItemNameInDiv("inactive");

        CreateAdd(_EquipmentEntity, Contextmain);

        Thread.Sleep(2000);

        /*------------------------group Section------------------------------*/
        groupBtnClick();
        var groupContext =
            webElementAction.GetElementBySpecificAttribute("data-header-name", "EquipmentGroupComboGrid-MiniGrid");
        webElementAction.GetElementBySpecificAttribute("id", "MINI_GRID_ADD_MULTI_SELECTION_BUTTON",
            groupContext).Click();
        Thread.Sleep(500);
        //if it has a row
        if (webElementAction.IsElementPresent(By.CssSelector(".ag-cell.ag-cell-not-inline-editing.ag-cell-normal-height.ag-cell-last-left-pinned.grid-icon-class.ag-cell-focus.ag-cell-value")) == true)  //There may be no record. 
        {
            var defaultSelectedRowgroup = webElementAction.GetElementByCssSelector(
           ".ag-cell.ag-cell-not-inline-editing.ag-cell-normal-height.ag-cell-last-left-pinned.grid-icon-class.ag-cell-focus.ag-cell-value");

            defaultSelectedRowgroup.Click(); //Add default selected record
            Thread.Sleep(1000);
            webElementAction.GetElementByCssSelector(".confirm-button").Click();
            var groupColIds = webElementAction.GetElementById("EquipmentGroupComboGrid-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
            if (groupColIds.Count > 1)
            {
                CreateAddInGrid(_EquipmentEntity.EquipmentGroup, groupColIds);
            }
            Thread.Sleep(2000);
        }
        else
        {
            webElementAction.GetElementByCssSelector(".confirm-button").Click();
        }

        /*------------------------INSPECTION Section------------------------------*/
        ClickTab("INSPECTION");
        var inspectionContext = GetTabContext("INSPECTION");

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
        CreateAdd(_EquipmentEntity.InspectionTab, inspectionContext);

        /*------------------------Specification Section------------------------------*/

        ClickTab("SPECIFICATIONS");
        var SpecificationsContextinspection = GetTabContext("SPECIFICATIONS");

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

        CreateAddInGrid(_EquipmentEntity.SpecificationTab, SpecificationColIds);
        Thread.Sleep(2000);
        SaveAndConfirmCheck();
        return _EquipmentEntity;
    }
    private void ValidateInsertEquipmentFunc()
    {

        SearchAndEditClick(_EquipmentEntity.EquipmentCode);
        CreateValidation(_EquipmentEntity);

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
                    ValidateEntityFieldDifferences(_EquipmentEntity.EquipmentGroup, EquipmentGroupCurent);
                }
            }
            catch
            {
                //ignored
            }
        }

        ClickTab("SPECIFICATIONS");
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
                    ValidateEntityFieldDifferences(_EquipmentEntity.EquipmentGroup, SpecificationTabCurent);
                }
            }
            catch
            {
                //ignored
            }
        }
    }

    private void groupBtnClick()
    {
        var inspectionBtn = webElementAction
            .GetAllElementBySpecificAttribute("type", "button").FirstOrDefault(o =>
                o.GetAttribute("data-tab-name") == "GROUP");
        inspectionBtn.Click();
    }

    [TestMethod, Timeout(MaximumExecutionTime * 3)]
    public void AddEquipment()
    {
        TestInitialize(nameof(AddEquipment));
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
    public void DeleteEquipment()
    {
        TestInitialize(nameof(DeleteEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call department add 
                AddEquipmentFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_EquipmentEntity.EquipmentCode, "EquipmentSummaryList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime + (MaximumExecutionTime / 2))]
    public void EditEquipment()
    {
        TestInitialize(nameof(EditEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentList");
                _EquipmentEntity = new EquipmentEntity();
                _EquipmentEntity.EquipmentCode = GetAnEquipmentCode();
                SearchAndEditClick(_EquipmentEntity.EquipmentCode);
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
        RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.  
        ShowAllRedord();
        //equipment Code In firstRow with barcode
        Thread.Sleep(2000);
        return ObjectRepository.Driver.FindElements(By.CssSelector("[col-id='id'][role='gridcell']"))
             .First().Text;
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckEquipment()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckEquipment));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
    public void ArrowLastBtnCheckEquipment()
    {
        TestInitialize(nameof(ArrowLastBtnCheckEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
    public void ArrowNextBtnCheckEquipment()
    {
        TestInitialize(nameof(ArrowNextBtnCheckEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
    public void ArrowPreviousBtnCheckEquipment()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
    public void CardViewBtnCheckEquipment()
    {
        TestInitialize(nameof(CardViewBtnCheckEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
    public void ListViewtBtnCheckEquipment()
    {
        TestInitialize(nameof(ListViewtBtnCheckEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
    public void InactiveBtnCheckEquipment()
    {
        TestInitialize(nameof(InactiveBtnCheckEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");

                Thread.Sleep(1000);

                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                FindColumnInMainGrid("Inactive");
                InActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateEquipment()
    {
        TestInitialize(nameof(DetailValidateEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddEquipmentFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_EquipmentEntity.EquipmentCode.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("EquipmentSummaryList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _EquipmentEntity.EquipmentCode.Trim()).Click();

                ChangeScreenPageSize(40);
                Thread.Sleep(3000);
                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                Thread.Sleep(2000);
                CreateValidationInGrid(colIds, _EquipmentEntity);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddEqupmentWithLocationQty()
    {
        TestInitialize(nameof(AddEqupmentWithLocationQty));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                if (!CurrentUrlIsMultiLocation())
                    goto finishTest;
                GoToUrl("MMInventory", "EquipmentSummaryList");
                Thread.Sleep(2000);
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                //click on addNewRecordBtn
                webElementAction.GetElementById("EQUIPMENT_LIST_ADD_BUTTON").Click();
            startEdit:
                _EquipmentEntity = new EquipmentEntity();
                Thread.Sleep(2000);
                // click on main
                var Contextmain = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide")
                    .FindElements(By.TagName("div")).FirstOrDefault();
                // write data random in fields main
                new WebElementDataGenerator(Contextmain);

                Thread.Sleep(2000);

                ClickTab("PRICING_GL");

                Thread.Sleep(1000);
                var RentalGlinPricing =
                    webElementAction.GetElementByCssSelector(".tab-content[data-tab-name='PRICING_GL'] .row-division");

                Thread.Sleep(1000);

                new WebElementDataGenerator(RentalGlinPricing);

                Thread.Sleep(1000);


                ClickTab("SETTING");

                var ckecboxBarcodOnly = webElementAction.GetInputElementByDataFormItemNameInDiv("barcodedOnly");
                ckecboxBarcodOnly.Click();

                Thread.Sleep(1000);


                var BtnPost = webElementAction.GetElementById("TOOL_BOX_SAVE_CHANGES_BUTTON_ID");
                BtnPost.Click();

                WaitForLoadingSpiner();

                Thread.Sleep(2000);

                ClickTab("LOCATION_QTY");

                var locationQtyGridElement =
                    webElementAction.GetElementById("EquipmentDetailQuantities-MiniGrid-gridId");
                var canadaLocation = locationQtyGridElement.FindElements(By.TagName("div")).Where(o => o.GetAttribute("value") == "CANADA").FirstOrDefault();

                //webElementAction.DoubleClick(canadaLocation);

                var locQtyColIds = webElementAction.GetElementById("EquipmentDetailQuantities-MiniGrid-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
                foreach (var colId in locQtyColIds)
                {
                    Thread.Sleep(1000);
                    new WebElementDataGenerator(colId);
                }

            finishTest: { }
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentListByDepartment()
    {
        TestInitialize(nameof(FilterEquipmentListByDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");

                //Select all value in grid
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("departmentId", "EquipmentSummaryList-gridId", "Department");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentListByCategory()
    {
        TestInitialize(nameof(FilterEquipmentListByCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");

                //Select all value in grid
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("categoryId", "EquipmentSummaryList-gridId", "Category");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentListByEquipment()
    {
        TestInitialize(nameof(FilterEquipmentListByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");

                //Select all value in grid
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("equipmentId", "EquipmentSummaryList-gridId", "Code", colId: "id");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentListByDescription()
    {
        TestInitialize(nameof(FilterEquipmentListByDescription));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");

                //Select all value in grid
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("description", "EquipmentSummaryList-gridId", "Description");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterEquipmentListByIncludeInactiveEquipment()
    {
        TestInitialize(nameof(FilterEquipmentListByIncludeInactiveEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");

                //Select all value in grid
                RefreshAllRows(filterId: "currencyId");  // In the filter window, there may be a required currency field.
                ShowAllRedord();

                //Click in filter Equipment List
                DataLegendNameFilter("INACTIVE");

                FilterSearch filterSearch = new FilterSearch("includeInactive", "EquipmentSummaryList-gridId", "Inactive", "inactive");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBox()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBox));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "MMInventory", subMenu: "EquipmentSummaryList", filed: "description");
                validateRequiredFields.Run();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    ImageDetector imageDetector;
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddAndPrintEquipmentImageInEquipmentSummary()
    {
        TestInitialize(nameof(AddAndPrintEquipmentImageInEquipmentSummary));
        imageDetector = new ImageDetector();

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
    public void EditEquipmentSummaryPicture()
    {
        TestInitialize(nameof(EditEquipmentSummaryPicture));
        imageDetector = new ImageDetector();

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");
                EditPictureValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    public class NewArriveEntity
    {
        [ValidationColID("equipmentId")]
        public string Equipment { get; set; }

        [ValidationColID("txnDate")]
        public string Date { get; set; }

        [ValidationColID("equipDesc")]
        public string Description { get; set; }

        [ValidationColID("sortOrder")]
        public string SortDate { get; set; }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddNewArriveList()
    {
        TestInitialize(nameof(AddNewArriveList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");
                GoToSubMenu("WEBSITE_TOOL_DROPDOWN", "NEW_ARRIVALS");
                webElementAction.ClickOnAddNewRecord();

                NewArriveEntity newArrive = new NewArriveEntity();

                var newRowColsContext = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row");
                new WebElementDataGenerator(newRowColsContext, IsContextGrid: true);
                //add RCD values 
                webElementAction.ClickOnPostBtnInMinGrid(gridId: "EquipmentNewArrivals-gridId");
                CheckErrorDialogBox();

                var arriveColIds = webElementAction.GetElementById("EquipmentNewArrivals-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
                CreateAddInGrid(newArrive, arriveColIds);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    public class EquipmentFeaturedItem
    {
        [ValidationColID("equipmentId")]
        public string Equipment { get; set; }

        [ValidationColID("transactionDate")]
        public string Date { get; set; }

        [ValidationColID("description")]
        public string Description { get; set; }

        [ValidationColID("sortOrder")]
        public string SortDate { get; set; }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddFeaturedItemsList()
    {
        TestInitialize(nameof(AddFeaturedItemsList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");
                GoToSubMenu("WEBSITE_TOOL_DROPDOWN", "EQUIPMENT_FEATURED_ITEMS_LIST");
                webElementAction.ClickOnAddNewRecord();

                EquipmentFeaturedItem equipmentFeaturedItem = new EquipmentFeaturedItem();

                var newRowColsContext = webElementAction.GetElementByCssSelector(".ag-center-cols-container .new-added-row");
                new WebElementDataGenerator(newRowColsContext, IsContextGrid: true);
                //add RCD values 
                webElementAction.ClickOnPostBtnInMinGrid(gridId: "EquipmentFeaturedItemsList-gridId");
                CheckErrorDialogBox();

                var featuredItemColIds = webElementAction.GetElementById("EquipmentFeaturedItemsList-gridId").FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));//
                CreateAddInGrid(equipmentFeaturedItem, featuredItemColIds);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void SetWebsiteAddedDate()
    {
        TestInitialize(nameof(SetWebsiteAddedDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");

                RefreshAllRows();

                var firstEquId = webElementAction.GetElementById("EquipmentSummaryList-gridId").FindElements(By.CssSelector("[col-id='id']")).Skip(1).First();

                webElementAction.RighClick(firstEquId);

                var setWebsiteAddedDateElement = webElementAction.GetElementByXPath("//span[.='Set Website Added Date']");
                setWebsiteAddedDateElement.Click();

                var mainModal = webElementAction.GetElementByCssSelector(".main-modal");
                new WebElementDataGenerator(mainModal);

                var websiteAddedDateValue = webElementAction.GetInputElementByDataFormItemNameInDiv("websiteAddedDate").GetAttribute("value");

                ConfirmBtnCheck(dataSection: "modal");

                ConfirmBtnCheck(dataSection: "infoDialog"); //Information: 0 of 1 Equipments were Updated.

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
    private void DeSelectingRFIDCheckbox()
    {
        ClickTab("SETTING");
        if (webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='rfidOnly']")))
            webElementAction.DeSelectingCheckbox("rfidOnly");
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateSerialNumberOptionRadioButtonsInEquipmentListSummary()
    {
        TestInitialize(nameof(ValidateSerialNumberOptionRadioButtonsInEquipmentListSummary));

        while (!testPassed && retryCount < maxRetries)
        {
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");

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
            catch (NoSuchElementException ex)
            {
                HandleTestFailure(ex.Message);
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
        }
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
    public void ValidateColumnIdsInGridByEquipmentList_Business()
    {
        TestInitialize(nameof(ValidateColumnIdsInGridByEquipmentList_Business)); //feature number 42 release New Features 07-07-2024(2)
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //Check multi location
                if (CurrentUrlIsMultiLocation())
                {
                    /* Step 1:Goto 'Equipment List' */
                    {
                        GoToUrl("MMInventory", "EquipmentSummaryList");
                        RefreshAllRows();
                    }
                    /* Step 2:Goto sub menu view click location quantity*/
                    {
                        GoToSubMenu("VIEW_TOOL_DROPDOWN", "LOCATION_QUANTITY");
                    }
                    /* Step 3:Existing Validate All Column In Grid */
                    {
                        ExistingValidateAllColumnInGrid();
                    }
                }

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    void ExistingValidateAllColumnInGrid()
    {
        bool allColumnsPresent = true;
        bool allContextMenuPresent = true;

        string[] columnIds =
        {
                //Total
                "totalOwn",
                "totalOut",
                "totalRepair",
                "totalInspection",
                "totalInTruck",
                "totalOnHand"
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
    public void CheckCardViewOfTheGridEquipmentList()  //feature number 17 release New Features 07-07-2024(2)
    {
        TestInitialize(nameof(CheckCardViewOfTheGridEquipmentList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "EquipmentSummaryList");
                RefreshAllRows();
                // Get the element representing the grid with the ID "EquipmentSummaryList-gridId" and find the focused row within that grid that has a column identifier. 
                webElementAction.GetElementById("EquipmentSummaryList-gridId").FindElement(By.CssSelector(".ag-row.ag-row-focus [col-id]")).Click();

                // Select the next row in the grid by simulating a "Down" arrow key press. 
                NavigateGridSelection(direction: DirectionArrow.Down);

                // Retrieve the element in the focused grid row that corresponds to the "departmentId" column.  
                var departmentElement = webElementAction.GetColumnInDefaultGridRow("departmentId", "EquipmentSummaryList-gridId");
                webElementAction.RighClick(departmentElement);

                // If the popup is not found, the test fails with an assertion message.  
                if (!webElementAction.IsElementPresent(By.CssSelector(".ag-popup")))
                    Assert.Fail("Error:___ do not find equipment popup ");

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
                GoToUrl("MMInventory", "EquipmentSummaryList");
                RefreshRecordDataInGrid("EquipmentSummaryList-gridId", columnId: "id");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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
                GoToUrl("MMInventory", "EquipmentSummaryList");
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