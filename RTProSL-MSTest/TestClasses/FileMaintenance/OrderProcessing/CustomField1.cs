//developed by mohammad-keshavarz
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;

public class CustomField1Entity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }

}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___OrderProcessing")]
public class CustomField1 : BaseClass
{
    private CustomField1Entity _CustomField1Entity;

    public void AddCustomField1Func()
    {
        GoToUrl("FileMaintenance", "CustomField1");
        _CustomField1Entity = new CustomField1Entity();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        Thread.Sleep(1000);
        CreateAdd(_CustomField1Entity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void CustomField1ValidateInsertFunc()
    {
        ListViewBtnValidate();
        Thread.Sleep(1000);
        SearchAndEditClick(_CustomField1Entity.Code.Trim());
        CreateValidation(_CustomField1Entity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddCustomField1()
    {
        TestInitialize(nameof(AddCustomField1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddCustomField1Func();
                CustomField1ValidateInsertFunc();
                //ValidateInsertedCustomField1InGridList();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBtnCustomField1()
    {
        TestInitialize(nameof(EditBtnCustomField1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to CustomField1 page 
                GoToUrl("FileMaintenance", "CustomField1");

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);
                _CustomField1Entity = new CustomField1Entity();
                Thread.Sleep(1000);
                // read and write data in struct
                CreateAdd(_CustomField1Entity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                SearchTextInMainGrid(_CustomField1Entity.Code.Trim());

                Thread.Sleep(700);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _CustomField1Entity.Code.Trim());
                webElementAction.DoubleClick(selectRow);

                Thread.Sleep(500);

                //click on edit btn
                var editOrderManualStatusBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
                editOrderManualStatusBtn.Click();
                Thread.Sleep(3000);

                CreateValidation(_CustomField1Entity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteCustomField1()
    {
        TestInitialize(nameof(DeleteCustomField1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddCustomField1Func();
                Delete(_CustomField1Entity.Code, "CustomFieldOne-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInCustomField1()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInCustomField1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField1");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInCustomField1()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInCustomField1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField1");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInCustomField1()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInCustomField1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField1");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInCustomField1()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInCustomField1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField1");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInCustomField1()
    {
        TestInitialize(nameof(ListViewBtnCheckInCustomField1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField1");
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInCustomField1()
    {
        TestInitialize(nameof(CardViewBtnCheckInCustomField1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField1");
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateCustomField1()
    {
        TestInitialize(nameof(DetailValidateCustomField1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddCustomField1Func();

                ListViewBtnValidate();

                ShowAllRedord();

                SearchTextInMainGrid(_CustomField1Entity.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("CustomFieldOne-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _CustomField1Entity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _CustomField1Entity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInCustomField1()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInCustomField1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "CustomField1", filed: "description");

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
                GoToUrl("FileMaintenance", "CustomField1");
                RefreshRecordDataInGrid("CustomFieldOne-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}
