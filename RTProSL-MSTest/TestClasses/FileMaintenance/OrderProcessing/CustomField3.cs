// Develop By Mohammad-Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;

public class CustomField3Entity

{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___OrderProcessing")]
public class CustomField3 : BaseClass
{
    private CustomField3Entity _CustomField3Entity;


    public void AddCustomField3Func()
    {
        GoToUrl("FileMaintenance", "CustomField3");
        _CustomField3Entity = new CustomField3Entity();
        //click on add NewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        Thread.Sleep(1000);
        CreateAdd(_CustomField3Entity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void CustomField3InsertValidate()
    {
        ListViewBtnValidate();
        Thread.Sleep(1000);
        SearchAndEditClick(_CustomField3Entity.Code.Trim());

        CreateValidation(_CustomField3Entity);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddCustomField3()
    {
        TestInitialize(nameof(AddCustomField3));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddCustomField3Func();
                CustomField3InsertValidate();
                //ValidateInsertedCustomField1InGridList();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBtnCustomField3()
    {
        TestInitialize(nameof(EditBtnCustomField3));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to CustomField2 page 
                GoToUrl("FileMaintenance", "CustomField3");
                _CustomField3Entity = new CustomField3Entity();

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                Thread.Sleep(1000);
                // read and write data in struct
                CreateAdd(_CustomField3Entity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                SearchTextInMainGrid(_CustomField3Entity.Code.Trim());
                Thread.Sleep(700);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _CustomField3Entity.Code.Trim());
                webElementAction.DoubleClick(selectRow);

                Thread.Sleep(500);

                //click on edit btn
                var editOrderManualStatusBtn =
                    webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
                editOrderManualStatusBtn.Click();
                Thread.Sleep(3000);

                CreateValidation(_CustomField3Entity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteCustomField3()
    {
        TestInitialize(nameof(DeleteCustomField3));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddCustomField3Func();
                Delete(_CustomField3Entity.Code, "CustomFieldThree-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInCustomField3()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInCustomField3));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField3");
                _CustomField3Entity = new CustomField3Entity();
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInCustomField3()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInCustomField3));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField3");
                _CustomField3Entity = new CustomField3Entity();
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInCustomField3()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInCustomField3));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField3");
                _CustomField3Entity = new CustomField3Entity();
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInCustomField3()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInCustomField3));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField3");
                _CustomField3Entity = new CustomField3Entity();
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInCustomField3()
    {
        TestInitialize(nameof(ListViewBtnCheckInCustomField3));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField3");
                _CustomField3Entity = new CustomField3Entity();
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInCustomField3()
    {
        TestInitialize(nameof(CardViewBtnCheckInCustomField3));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField3");
                _CustomField3Entity = new CustomField3Entity();
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateCustomField3()
    {
        TestInitialize(nameof(DetailValidateCustomField3));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddCustomField3Func();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_CustomField3Entity.Code.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("CustomFieldThree-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _CustomField3Entity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _CustomField3Entity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInCustomField3()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInCustomField3));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "CustomField3", filed: "description");
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
                GoToUrl("FileMaintenance", "CustomField3");
                RefreshRecordDataInGrid("CustomFieldThree-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}
