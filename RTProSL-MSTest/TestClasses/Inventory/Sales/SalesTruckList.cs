//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;

namespace RTProSL_MSTest.TestClasses.Inventory.Sales;

// define class struct Truck
public class SalesTruckEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    public string Description { set; get; }

    [ValidationDataType(DataType.TextArea)]
    public string Notes { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    public bool RollupPrice { set; get; }

}


[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Sales")]
public class SalesTruckList : BaseClass
{
    // new struct DispatchStatusList Entity
    private SalesTruckEntity _SalesTruckListEntity;

    public void AddSalesTruckListFunc()
    {
        GoToUrl("MMInventory", "SalesTruckList");
        _SalesTruckListEntity = new SalesTruckEntity();
        // click on btn add in page DispatchStatusList Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page DispatchStatusList  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_SalesTruckListEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertSalesTruckListFunc()
    {
        ShowAllRedord();
        SearchTextInMainGrid(_SalesTruckListEntity.Code.Trim());

        ClearAllTagList();
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _SalesTruckListEntity.Code.Trim());
        selectRow.Click();

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID");
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        CreateValidation(_SalesTruckListEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddSalesTruckList()
    {
        TestInitialize(nameof(AddSalesTruckList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSalesTruckListFunc();
                ValidateInsertSalesTruckListFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckSalesTruckList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckSalesTruckList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesTruckList");
                _SalesTruckListEntity = new SalesTruckEntity();
                ShowAllRedord();
                //call arrow
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckSalesTruckList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckSalesTruckList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesTruckList");
                _SalesTruckListEntity = new SalesTruckEntity();
                ShowAllRedord();
                //call arrow
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckSalesTruckList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckSalesTruckList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesTruckList");
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
    public void ArrowLastBtnCheckSalesTruckList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckSalesTruckList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesTruckList");
                ShowAllRedord();
                //call arrow
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckSalesTruckList()
    {
        TestInitialize(nameof(ListViewtBtnCheckSalesTruckList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesTruckList");
                ShowAllRedord();
                //call listViewtBtn
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnSalesTruckList()
    {
        TestInitialize(nameof(CardViewBtnSalesTruckList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesTruckList");
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
    public void ValidateRequiredFieldsMessageBoxInSalesTruckList()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSalesTruckList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "MMInventory", subMenu: "SalesTruckList", filed: "description");
                validateRequiredFields.Run();
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
                GoToUrl("MMInventory", "SalesTruckList");
                RefreshRecordDataInGrid("SalesTruckList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}