// develop by Mohammad_Keshavarz
//Specification
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

//Prerequisite: Checking the "Use Specification" option in the system setup.


public class SpecificationEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }

    public string SpecificationCategory { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class Specification : BaseClass
{
    private SpecificationEntity _SpecificationEntity;

    public void AddSpecificationFunc()
    {
        GoToUrl("FileMaintenance", "Specification");
        _SpecificationEntity = new SpecificationEntity();
        WaitForLoadingSpiner();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        WaitForLoadingSpiner();
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_SpecificationEntity);
        Thread.Sleep(1000);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
        ShowAllRedord();
    }

    private void ValidateInsertSpecificationFunc()
    {
        //ShowAllRedord();
        SearchTextInMainGrid(_SpecificationEntity.Code.Trim());

        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _SpecificationEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        CreateValidation(_SpecificationEntity);
        //ValidateInsertedMasterInGridList();
    }

    //Prerequisite: Checking the "Use Specification" option in the system setup.
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddSpecification()
    {
        TestInitialize(nameof(AddSpecification));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpecificationFunc();
                ValidateInsertSpecificationFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditSpecification()
    {
        TestInitialize(nameof(EditSpecification));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to department page 
                GoToUrl("FileMaintenance", "Specification");
                _SpecificationEntity = new SpecificationEntity();

                WaitForLoadingSpiner();

                ClickOnEditBtn();

                // define context page to variable
                var context = GetFormLeftSideContext();

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                context = GetFormLeftSideContext();
                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_SpecificationEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertSpecificationFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateSpecification()
    {
        TestInitialize(nameof(DetailValidateSpecification));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpecificationFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_SpecificationEntity.Code.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("Specification-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _SpecificationEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _SpecificationEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSpecification()
    {
        TestInitialize(nameof(DeleteSpecification));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // call add Specification
                AddSpecificationFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_SpecificationEntity.Code, "Specification-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInSpecification()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInSpecification));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Specification");
                _SpecificationEntity = new SpecificationEntity();
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInSpecification()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInSpecification));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Specification");
                _SpecificationEntity = new SpecificationEntity();
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInSpecification()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInSpecification));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Specification");
                _SpecificationEntity = new SpecificationEntity();
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInSpecification()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInSpecification));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Specification");
                _SpecificationEntity = new SpecificationEntity();
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInSpecification()
    {
        TestInitialize(nameof(CardViewBtnCheckInSpecification));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Specification");
                _SpecificationEntity = new SpecificationEntity();
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
    public void ListViewBtnCheckInSpecification()
    {
        TestInitialize(nameof(ListViewBtnCheckInSpecification));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Specification");
                _SpecificationEntity = new SpecificationEntity();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInSpecification()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSpecification));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "Specification", filed: "description");
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
                GoToUrl("FileMaintenance", "Specification");
                RefreshRecordDataInGrid("Specification-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}
