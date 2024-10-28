// develop by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

public class SalesCategoryEntity
{
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    [ValidationElementProperty("departmentId")]
    public string Department { set; get; }

    public string Description { set; get; }

    [ValidationElementProperty("glAccountId")]
    public string GLAccount { set; get; }

    [ValidationIgnoreInGrid]
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
public class SalesCategory : BaseClass
{
    private SalesCategoryEntity _SalesCategoryEntity;


    public void AddSalesCategoryFunc()
    {
        GoToUrl("FileMaintenance", "SalesCategory");
        _SalesCategoryEntity = new SalesCategoryEntity();
        ShowAllRedord();

        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_SalesCategoryEntity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertSaleCategoryFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_SalesCategoryEntity.Code.Trim());
        Thread.Sleep(2000);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _SalesCategoryEntity.Code.Trim());
        Thread.Sleep(2000);

        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        ////click on edit btn
        //var editUserBtn = webElementAction.GetElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID");
        //editUserBtn.Click();

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();

        Thread.Sleep(3000);
        CreateValidation(_SalesCategoryEntity);

    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddSalesCategory()
    {
        TestInitialize(nameof(AddSalesCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSalesCategoryFunc();
                ValidateInsertSaleCategoryFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditSaleCategory()
    {
        TestInitialize(nameof(EditSaleCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SalesCategory");
                _SalesCategoryEntity = new SalesCategoryEntity();

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Sales Categoryy Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_SalesCategoryEntity);

                Thread.Sleep(1000);
                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertSaleCategoryFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSalesCategory()
    {
        TestInitialize(nameof(DeleteSalesCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Sales Category add 
                AddSalesCategoryFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_SalesCategoryEntity.Code, "SalesCategoryList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateSalesCategory()
    {
        TestInitialize(nameof(DetailValidateSalesCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSalesCategoryFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_SalesCategoryEntity.Code.Trim());
                Thread.Sleep(4000);

                var gridList = webElementAction.GetElementById("SalesCategoryList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _SalesCategoryEntity.Code.Trim()).Click();

                ChangeScreenPageSize(20);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));


                _SalesCategoryEntity.SortOrder = webElementAction.FormatNumberWithCommas(_SalesCategoryEntity.SortOrder);

                CreateValidationInGrid(colIds, _SalesCategoryEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInSalesCategory()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInSalesCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SalesCategory");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInSalesCategory()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInSalesCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SalesCategory");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInSalesCategory()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInSalesCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SalesCategory");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInSalesCategory()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInSalesCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SalesCategory");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInSalesCategory()
    {
        TestInitialize(nameof(CardViewBtnCheckInSalesCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SalesCategory");
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
    public void ListViewBtnCheckInSalesCategory()
    {
        TestInitialize(nameof(ListViewBtnCheckInSalesCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SalesCategory");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInSalesCategory()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSalesCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "SalesCategory", filed: "description");
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
                GoToUrl("FileMaintenance", "SalesCategory");
                RefreshRecordDataInGrid("SalesCategoryList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}