// develop by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance;

public class PriceListEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    public string Description { set; get; }

    [ValidationElementProperty("currencyId")]
    public string Currency { set; get; }


    [ValidationDataType(DataType.CheckBox)]
    public bool Rentals { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    public bool Sales { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool Inactive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class PriceList : BaseClass
{
    private PriceListEntity _PriceListEntity;

    public void AddPriceListFunc()
    {
        GoToUrl("FileMaintenance", "PriceList");
        _PriceListEntity = new PriceListEntity();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_PriceListEntity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertPriceListFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_PriceListEntity.Code.Trim());

        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _PriceListEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        CreateValidation(_PriceListEntity);
        //ValidateInsertedMasterInGridList();
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddPriceList()
    {
        TestInitialize(nameof(AddPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPriceListFunc();
                ValidateInsertPriceListFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditPriceList()
    {
        TestInitialize(nameof(EditPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PriceList");
                _PriceListEntity = new PriceListEntity();
                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_PriceListEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();
                Thread.Sleep(1000);
                CheckErrorDialogBox();

                ValidateInsertPriceListFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidatePriceList()
    {
        TestInitialize(nameof(DetailValidatePriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPriceListFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_PriceListEntity.Code.Trim());

                Thread.Sleep(3000);

                var gridlist = webElementAction.GetElementById("PriceList-gridId");
                var selectRow = gridlist.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _PriceListEntity.Code.Trim());
                webElementAction.DoubleClick(selectRow);

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridlist.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _PriceListEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeletePriceList()
    {
        TestInitialize(nameof(DeletePriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call AddPriceListFunc add 
                AddPriceListFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_PriceListEntity.Code, "PriceList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInPriceList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PriceList");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInPriceList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PriceList");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInPriceList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PriceList");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInPriceList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PriceList");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInPriceList()
    {
        TestInitialize(nameof(CardViewBtnCheckInPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PriceList");
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
    public void ListViewBtnCheckInPriceList()
    {
        TestInitialize(nameof(ListViewBtnCheckInPriceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "PriceList");
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
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "PriceList", filed: "description");
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
                GoToUrl("FileMaintenance", "PriceList");
                RefreshRecordDataInGrid("PriceList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}