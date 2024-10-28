// develop by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

//Prerequisite: Checking the "Use Specification" option in the system setup.
public class SpecificationCategoryEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }
}
[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]

public class SpecificationCategory : BaseClass
{
    private SpecificationCategoryEntity _SpecificationCategoryEnity;

    public void AddSpecificationCategoryFunc()
    {
        GoToUrl("FileMaintenance", "SpecificationCategory");
        _SpecificationCategoryEnity = new SpecificationCategoryEntity();

        //click on addNewRecordBtn
        webElementAction.GetElementBySpecificAttribute("data-icon-name", "add").Click();
        var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");
        new WebElementDataGenerator(context);

        CreateAdd(_SpecificationCategoryEnity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertSpecificationCategoryFunc()
    {
        Thread.Sleep(2000);

        SearchTextInMainGrid(_SpecificationCategoryEnity.Code.Trim());
        Thread.Sleep(2000);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _SpecificationCategoryEnity.Code.Trim());

        Thread.Sleep(2000);
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        CreateValidation(_SpecificationCategoryEnity);
        //ValidateInsertedMasterInGridList();
    }

    public void AddSpecificationCategory()
    {
        TestInitialize(nameof(AddSpecificationCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpecificationCategoryFunc();
                ValidateInsertSpecificationCategoryFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    //Prerequisite: Checking the "Use Specification" option in the system setup.
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditSpecificationCategory()
    {
        TestInitialize(nameof(EditSpecificationCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SpecificationCategory");
                _SpecificationCategoryEnity = new SpecificationCategoryEntity();

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_SpecificationCategoryEnity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertSpecificationCategoryFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateSpecificationCategory()
    {
        TestInitialize(nameof(DetailValidateSpecificationCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpecificationCategoryFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_SpecificationCategoryEnity.Code.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("SpecificationCategory-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _SpecificationCategoryEnity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _SpecificationCategoryEnity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSpecificationCategory()
    {
        TestInitialize(nameof(DeleteSpecificationCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // call add SpecificationCategoryFunc
                AddSpecificationCategoryFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_SpecificationCategoryEnity.Code, "SpecificationCategory-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInSpecificationCategory()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInSpecificationCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SpecificationCategory"); ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInSpecificationCategory()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInSpecificationCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SpecificationCategory");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInSpecificationCategory()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInSpecificationCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SpecificationCategory");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInSpecificationCategory()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInSpecificationCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SpecificationCategory");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInSpecificationCategory()
    {
        TestInitialize(nameof(CardViewBtnCheckInSpecificationCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SpecificationCategory");
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
    public void ListViewBtnCheckInSpecificationCategory()
    {
        TestInitialize(nameof(ListViewBtnCheckInSpecificationCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SpecificationCategory");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInSpecificationCategory()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSpecificationCategory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "SpecificationCategory", filed: "description");
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
                GoToUrl("FileMaintenance", "SpecificationCategory");
                RefreshRecordDataInGrid("SpecificationCategory-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}
