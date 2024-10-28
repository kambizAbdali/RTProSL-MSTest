//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.BillingAR;

// define class struct Tax

public class TaxEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }

    public string County { set; get; }

    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    [ValidationElementProperty("rentRate")]
    public string RentalRate { set; get; }

    [ValidationElementProperty("rentRate2")]
    public string RentalRate2 { set; get; }

    public string SaleRate { set; get; }

    public string SaleRate2 { set; get; }

    public string ShipRate { set; get; }

    public string ShipRate2 { set; get; }

    public string LaborRate { set; get; }

    public string LaborRate2 { set; get; }

    public string SpaceRate { set; get; }

    public string SpaceRate2 { set; get; }

    public string Tax1Label { set; get; }

    public string Tax2Label { set; get; }


    [ValidationElementProperty("glAccount1Id")]
    public string GLAccount1 { set; get; }

    [ValidationElementProperty("glAccount2Id")]
    public string GLAccount2 { set; get; }

    [ValidationElementProperty("wfwDynamicsTaxDetailId1")]
    public string GLAccDynamicsTaxDetailId1 { set; get; }

    [ValidationElementProperty("wfwDynamicsTaxDetailId2")]
    public string DynamicsTaxDetailId2 { set; get; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("quickBooksTaxAgency")]
    public string QuickBookTaxAgency { set; get; }


    [ValidationDataType(DataType.CheckBox)]
    public bool VendorFlag { set; get; }


    [ValidationDataType(DataType.CheckBox)]
    public bool RentalTaxonTax { set; get; }


    [ValidationDataType(DataType.CheckBox)]
    public bool SalesTaxonTax { set; get; }


    [ValidationDataType(DataType.CheckBox)]
    public bool Inactive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass]
[TestCategory("FileMaintenance___BillingAR")]
public class Tax : BaseClass
{
    // new struct Tax Entity
    private TaxEntity _TaxEntity;


    public void AddTaxFunc()
    {
        GoToUrl("FileMaintenance", "Tax");
        ListViewBtnValidate();
        ShowAllRedord();
        _TaxEntity = new TaxEntity();
        // click on btn add in page Tax Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page Tax  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_TaxEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
        
    }

    private void ValidateInsertTaxFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_TaxEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _TaxEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInserted SubrentalReason();
        CreateValidation(_TaxEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddTax()
    {
        TestInitialize(nameof(AddTax));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddTaxFunc();
                ValidateInsertTaxFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteTax()
    {
        TestInitialize(nameof(DeleteTax));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Tax add 
                AddTaxFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_TaxEntity.Code, "TaxList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckTax()
    {
        TestInitialize(nameof(ArrowNextBtnCheckTax));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Tax");
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
    public void ArrowPreviousBtnCheckTax()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckTax));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Tax");
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
    public void ArrowFirstBtnCheckArrowNextBtnCheckTax()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckArrowNextBtnCheckTax));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Tax");
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
    public void ArrowLastBtnCheckArrowNextBtnCheckTax()
    {
        TestInitialize(nameof(ArrowLastBtnCheckArrowNextBtnCheckTax));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Tax");
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
    public void EditTax()
    {
        TestInitialize(nameof(EditTax));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddTaxFunc();

                Thread.Sleep(3000);
                // click on btn edit 
                ShowAllRedord();

                SearchTextInMainGrid(_TaxEntity.Code.Trim());
                Thread.Sleep(2000);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _TaxEntity.Code.Trim());
                Thread.Sleep(2000);
                webElementAction.DoubleClick(selectRow);

                webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_TaxEntity);
                Thread.Sleep(3000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                if (webElementAction.IsElementPresent(By.CssSelector("[data-section='confirmDialog']")))
                {
                    var confirmDialogBox = webElementAction.GetElementBySpecificAttribute("data-section", "confirmDialog");
                    webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm", confirmDialogBox).Click();
                }

                Thread.Sleep(2000);

                webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();
                ValidateInsertTaxFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckTax()
    {
        TestInitialize(nameof(ListViewtBtnCheckTax));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Tax");
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
    public void DetailValidateTax()
    {
        TestInitialize(nameof(DetailValidateTax));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddTaxFunc();

                SearchTextInMainGrid(_TaxEntity.Code.Trim());
                Thread.Sleep(3000);

                var gridlist = webElementAction.GetElementById("TaxList-gridId");
                var selectRow = gridlist.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _TaxEntity.Code.Trim());
                selectRow.Click();

                ChangeScreenPageSize(45);
                Thread.Sleep(2000);
                ReadOnlyCollection<IWebElement> colIds =
                    gridlist.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _TaxEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnTax()
    {
        TestInitialize(nameof(CardViewBtnTax));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Tax");
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
    public void ValidateRequiredFieldsMessageBoxInTax()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInTax));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "Tax", filed: "description");
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
                GoToUrl("FileMaintenance", "Tax");
                RefreshRecordDataInGrid("TaxList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}