//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.Administration.Tables;

// define strct Salesperson
public class SalespersonEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Name { set; get; }

    public string Phone { set; get; }

    public string CellPhone { set; get; }

    public string Fax { set; get; }

    public string Email { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool InActive { get; set; }

    [ValidationDataType(DataType.TextArea)]
    public string Notes { set; get; }
}

[TestCategory("Administration")]
[TestClass, TestCategory("Administration___Tables")]
public class Salesperson : BaseClass
{
    // new struct SalespersonEntity
    private SalespersonEntity _SalespersonEntity;

    public void AddSalespersonPageFunc()
    {
        _SalespersonEntity = new SalespersonEntity();
        GoToUrl("Administration", "Salesperson");
        ShowAllRedord();
        // click on btn add in page Salesperson Entry Screen
        webElementAction.GetElementById("TOOL_BOX_ADD_BUTTON_ID").Click();

        // genarated data random in fields 
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_SalespersonEntity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertSalepersonFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_SalespersonEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _SalespersonEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        // moghayese
        CreateValidation(_SalespersonEntity);
        //ValidateInsertedUserInGridListFunc();
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddSalesPerson()
    {
        TestInitialize(nameof(AddSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _SalespersonEntity = new SalespersonEntity();
                AddSalespersonPageFunc();
                ValidateInsertSalepersonFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSalesPerson()
    {
        TestInitialize(nameof(DeleteSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Salesperson add 
                AddSalespersonPageFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_SalespersonEntity.Code, "SalespersonList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckSalesPerson()
    {
        TestInitialize(nameof(ArrowNextBtnCheckSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // navigate 
                GoToUrl("Administration", "Salesperson");
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
    public void ArrowPreviousBtnCheckSalesPerson()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Salesperson page 
                GoToUrl("Administration", "Salesperson");
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
    public void ArrowFirstBtnCheckSalesPerson()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Salesperson page 
                GoToUrl("Administration", "Salesperson");
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
    public void ArrowLastBtnCheckSalesPerson()
    {
        TestInitialize(nameof(ArrowLastBtnCheckSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Salesperson page 
                GoToUrl("Administration", "Salesperson");
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
    public void EditSalesPerson()
    {
        TestInitialize(nameof(EditSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _SalespersonEntity = new SalespersonEntity();
                //navigate to Salesperson page 
                GoToUrl("Administration", "Salesperson");

                ShowAllRedord();

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Salesperson Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);
                CreateAdd(_SalespersonEntity);
                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();
                ValidateInsertSalepersonFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void InActiveBtnCheckSalesPerson()
    {
        TestInitialize(nameof(InActiveBtnCheckSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to SalespersonEntity page 
                GoToUrl("Administration", "Salesperson");

                InActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ActiveBtnCheckSalesPerson()
    {
        TestInitialize(nameof(ActiveBtnCheckSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Salesperson page 
                GoToUrl("Administration", "Salesperson");
                FindColumnInMainGrid("Inactive");
                ActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckSalesPerson()
    {
        TestInitialize(nameof(ListViewtBtnCheckSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Salesperson page 
                GoToUrl("Administration", "Salesperson");
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
    public void ThumbnailViewBtnCheckSalesPerson()
    {
        TestInitialize(nameof(ThumbnailViewBtnCheckSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Salesperson page 
                GoToUrl("Administration", "Salesperson");

                //call thumbnailViewBtn 
                ThumbnailViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckSalesPerson()
    {
        TestInitialize(nameof(CardViewBtnCheckSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Salesperson page 
                GoToUrl("Administration", "Salesperson");
                ShowAllRedord();
                //call card btn
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateSalesPerson()
    {
        TestInitialize(nameof(DetailValidateSalesPerson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSalespersonPageFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                ChangeScreenPageSize(10);

                var gridList = webElementAction.GetElementById("SalespersonList-gridId");

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                var count = colIds.Count;
                CreateValidationInGrid(colIds, _SalespersonEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInSalesperson()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSalesperson));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "Administration", subMenu: "Salesperson", filed: "name");
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
                GoToUrl("Administration", "Salesperson");
                RefreshRecordDataInGrid("SalespersonList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}