// developed by Kambiz Abdali

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;


[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class RentalKitList : BaseClass
{

    public class RentalKitListEntity
    {
        [ValidationElementProperty("id")]
        public string Code { set; get; }

        [ValidationElementProperty("departmentId")]
        public string Department { set; get; }

        public string Description { set; get; }

        [ValidationElementProperty("locationId")]
        public string Location { set; get; }

        public string SortOrder { set; get; }

        [ValidationElementProperty("currencyId")]
        public string Currency { set; get; }

        [ValidationDataType(DataType.CheckBox)]
        public bool SavePrice { set; get; }

        [ValidationDataType(DataType.CheckBox)]
        public bool RollupPrice { set; get; }

        [ValidationDataType(DataType.CheckBox)]
        public bool ShowOnWebsite { set; get; }

        [ValidationDataType(DataType.CheckBox)]
        public bool Inactive { set; get; }

        [ValidationElementProperty("notes")]
        [ValidationDataType(DataType.TextArea)]
        public string Notes { set; get; }
    }

    RentalKitListEntity _RentalKitListEntity;

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInRentalKitList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInRentalKitList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalKitList");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInRentalKitList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInRentalKitList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalKitList");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInRentalKitList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInRentalKitList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalKitList");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInRentalKitList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInRentalKitList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalKitList");
                RefreshAllRows();
                ShowAllRedord();
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInRentalKitList()
    {
        TestInitialize(nameof(CardViewBtnCheckInRentalKitList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalKitList");
                if (!HasRowCheck()) { testPassed = true; break; }
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInRentalKitList()
    {
        TestInitialize(nameof(ListViewBtnCheckInRentalKitList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalKitList");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddRentalKitListWithAllFields()
    {
        TestInitialize(nameof(AddRentalKitListWithAllFields));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddRentalKitListFunc();
                ValidateInsertedRentalKitListInGridList();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBtnRentalKitList()
    {
        TestInitialize(nameof(EditBtnRentalKitList));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _RentalKitListEntity = new RentalKitListEntity();
                //navigate to Salesperson page 

                AddRentalKitListFunc();
                Thread.Sleep(2000);

                SearchTextInMainGrid(_RentalKitListEntity.Code.Trim());

                Thread.Sleep(500);
                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _RentalKitListEntity.Code.Trim());

                selectRow.Click();

                webElementAction.GetElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Partner Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);


                CreateAdd(_RentalKitListEntity, context);
                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertedRentalKitListInGridList();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    public void AddRentalKitListFunc()
    {
        GoToUrl("MMInventory", "RentalKitList");
        _RentalKitListEntity = new RentalKitListEntity();
        ShowAllRedord();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        var context = GetFormLeftSideContext(true);

        new WebElementDataGenerator(context);
        webElementAction.DeSelectingCheckbox("inactive");
        CreateAdd(_RentalKitListEntity, context);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
        RefreshAllRows();
    }

    public void ValidateInsertedRentalKitListInGridList()
    {
        //RefreshAllRows();
        ShowAllRedord();
        try
        {
            webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();
            Thread.Sleep(500);
        }
        catch
        {
            //ignored
        }
        SearchTextInMainGrid(_RentalKitListEntity.Code.Trim());

        Thread.Sleep(500);
        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _RentalKitListEntity.Code.Trim());

        selectRow.Click();

        //click on edit btn
        webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

        Thread.Sleep(500);
        var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide")
           .FindElements(By.TagName("div")).FirstOrDefault();
        CreateValidation(_RentalKitListEntity, context);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteRentalKitList()
    {
        TestInitialize(nameof(DeleteRentalKitList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddRentalKitListFunc();
                ClearAllTagList();
                ShowAllRedord();
                Delete(_RentalKitListEntity.Code, "RentalKitListList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateRentalKitList()
    {
        TestInitialize(nameof(DetailValidateRentalKitList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddRentalKitListFunc();

                _RentalKitListEntity.SortOrder = webElementAction.FormatNumberWithCommas(_RentalKitListEntity.SortOrder);
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_RentalKitListEntity.Code.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("RentalKitList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _RentalKitListEntity.Code.Trim()).Click();

                ChangeScreenPageSize(40);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _RentalKitListEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterRentalKitListByDepartment()
    {
        TestInitialize(nameof(FilterRentalKitListByDepartment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalKitList");

                //Select all value in grid
                RefreshAllRows();
                ShowAllRedord();
                FilterSearch filterSearch = new FilterSearch("departmentId", "RentalKitList-gridId", "Department");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInRentalKitList()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInRentalKitList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "MMInventory", subMenu: "RentalKitList", filed: "description");
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
                GoToUrl("MMInventory", "RentalKitList");
                RefreshRecordDataInGrid("RentalKitList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}