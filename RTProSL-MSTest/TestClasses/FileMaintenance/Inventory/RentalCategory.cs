// develop by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

public class RentalCategoryEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    [ValidationElementProperty("departmentId")]
    public string Department { set; get; }

    public string Description { set; get; }

    [ValidationElementProperty("glAccountId")]
    public string GLAccount { set; get; }

    public string SortOrder { set; get; }

    [ValidationElementProperty("glInventoryId")]
    public string GLInventory { set; get; }

    [ValidationElementProperty("subrentalGlAccountId")]
    public string SubrentalGLAccount { set; get; }

    [ValidationElementProperty(" glCostOfGoodsId")]
    public string GLCostofGoods { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("subtotal")]
    public bool PrintSubtota { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnWebsite")]
    public bool ShowonWebsite { set; get; }


    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool Inactive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class RentalCategory : BaseClass
{
    private RentalCategoryEntity _RentalCategoryEntity;

    public void AddRentalCategoryFunc()
    {
        GoToUrl("FileMaintenance", "RentalCategory");
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());
        _RentalCategoryEntity = new RentalCategoryEntity();
        CreateAdd(_RentalCategoryEntity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();

        CheckErrorDialogBox();
    }


    private void ValidateInsertRentalCategoryFunc()
    {
        TestInitialize(nameof(ValidateInsertRentalCategoryFunc));
        ShowAllRedord();

        SearchTextInMainGrid(_RentalCategoryEntity.Code.Trim());

        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _RentalCategoryEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        CreateValidation(_RentalCategoryEntity);
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddRentalCategory()
    {
        TestInitialize(nameof(AddRentalCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddRentalCategoryFunc();
                ValidateInsertRentalCategoryFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteRentalCategory()
    {
        TestInitialize(nameof(DeleteRentalCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Contact add 
                AddRentalCategoryFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_RentalCategoryEntity.Code, "RentalCategoryList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditRentalCategory()
    {
        TestInitialize(nameof(EditRentalCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RentalCategory");
                _RentalCategoryEntity = new RentalCategoryEntity();

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_RentalCategoryEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertRentalCategoryFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInRentalCategory()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInRentalCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RentalCategory");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInRentalCategory()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInRentalCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RentalCategory");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInRentalCategory()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInRentalCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RentalCategory");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInRentalCategory()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInRentalCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RentalCategory");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInRentalCategory()
    {
        TestInitialize(nameof(CardViewBtnCheckInRentalCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RentalCategory");
                if (!HasRowCheck()) { testPassed = true; break;} 
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInRentalCategory()
    {
        TestInitialize(nameof(ListViewBtnCheckInRentalCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "RentalCategory");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateRentalCategory()
    {
        TestInitialize(nameof(DetailValidateRentalCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddRentalCategoryFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_RentalCategoryEntity.Code.Trim());
                Thread.Sleep(3000);

                var gridlist = webElementAction.GetElementById("RentalCategoryList-gridId");
                var selectRow = gridlist.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _RentalCategoryEntity.Code.Trim());
                webElementAction.DoubleClick(selectRow);

                Thread.Sleep(3000);


                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridlist.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _RentalCategoryEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInRentalCategory()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInRentalCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "RentalCategory", filed: "description");
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
                GoToUrl("FileMaintenance", "RentalCategory");
                RefreshRecordDataInGrid("RentalCategoryList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}