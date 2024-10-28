//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.BillingAR;

// define class struct BillingMethod

public class BillingMethodEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass]
[TestCategory("FileMaintenance___BillingAR")]
public class BillingMethod : BaseClass
{
    // new struct BillingMethod Entity
    private BillingMethodEntity _BillingMethodEntity;

    public void AddBillingMethodFunc()
    {
        GoToUrl("FileMaintenance", "BillingMethod");
        _BillingMethodEntity = new BillingMethodEntity();
        ShowAllRedord();
        // click on btn add in page Terms Entry Screen
        webElementAction.GetElementById("TOOL_BOX_ADD_BUTTON_ID").Click();

        // data insert to feilds in page BillingMethod  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_BillingMethodEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertBillingMethodFunc()
    {
        SearchAndEditClick(_BillingMethodEntity.Code);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInserted SubrentalReason();
        CreateValidation(_BillingMethodEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddBillingMethod()
    {
        TestInitialize(nameof(AddBillingMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddBillingMethodFunc();
                ValidateInsertBillingMethodFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteBillingMethod()
    {
        TestInitialize(nameof(DeleteBillingMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call BillingMethod add 
                AddBillingMethodFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_BillingMethodEntity.Code, "BillingmethodList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckBillingMethod()
    {
        TestInitialize(nameof(ArrowNextBtnCheckBillingMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingMethod");
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
    public void ArrowPreviousBtnCheckBillingMethod()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckBillingMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingMethod");
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
    public void ArrowFirstBtnCheckArrowNextBtnCheckBillingMethod()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckArrowNextBtnCheckBillingMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingMethod");
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
    public void ArrowLastBtnCheckArrowNextBtnCheckBillingMethod()
    {
        TestInitialize(nameof(ArrowLastBtnCheckArrowNextBtnCheckBillingMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingMethod");
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
    public void EditBillingMethod()
    {
        TestInitialize(nameof(EditBillingMethod));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                _BillingMethodEntity = new BillingMethodEntity();
                //go to page rental agent

                AddBillingMethodFunc();

                Thread.Sleep(1000);

                SearchAndEditClick(_BillingMethodEntity.Code.Trim());

                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_BillingMethodEntity);
                Thread.Sleep(3000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                Thread.Sleep(2000);

                webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();
                ValidateInsertBillingMethodFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckBillingMethod()
    {
        TestInitialize(nameof(ListViewtBtnCheckBillingMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingMethod");
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
    public void DetailValidateBillingMethod()
    {
        TestInitialize(nameof(DetailValidateBillingMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddBillingMethodFunc();

                var gridlist = webElementAction.GetElementById("BillingmethodList-gridId");

                ReadOnlyCollection<IWebElement> colIds =
                    gridlist.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _BillingMethodEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnBillingMethod()
    {
        TestInitialize(nameof(CardViewBtnBillingMethod));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "BillingMethod");
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
    public void ValidateRequiredFieldsMessageBoxInTerms()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInTerms));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "BillingMethod", filed: "description");
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
                GoToUrl("FileMaintenance", "BillingMethod");
                RefreshRecordDataInGrid(gridId: "BillingmethodList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}