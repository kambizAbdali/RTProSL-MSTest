//developed by Mohammad-keshavarz
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;



public class CustomField2Entity

{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }

}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___OrderProcessing")]
public class CustomField2 : BaseClass
{
    private CustomField2Entity _CustomField2Entity;
    public void AddCustomField2Func()
    {
        GoToUrl("FileMaintenance", "CustomField2");
        _CustomField2Entity = new CustomField2Entity();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        Thread.Sleep(1000);
        CreateAdd(_CustomField2Entity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }
    private void CustomField2InsertValidateFunc()
    {
        ListViewBtnValidate();
        Thread.Sleep(1000);
        SearchAndEditClick(_CustomField2Entity.Code.Trim());

        CreateValidation(_CustomField2Entity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddCustomField2()
    {
        TestInitialize(nameof(AddCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddCustomField2Func();
                CustomField2InsertValidateFunc();
                //ValidateInsertedCustomField1InGridList();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBtnCustomField2()
    {
        TestInitialize(nameof(EditBtnCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to CustomField2 page 
                GoToUrl("FileMaintenance", "CustomField2");
                _CustomField2Entity = new CustomField2Entity();
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
                CreateAdd(_CustomField2Entity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                SearchTextInMainGrid(_CustomField2Entity.Code.Trim());

                Thread.Sleep(700);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _CustomField2Entity.Code.Trim());
                webElementAction.DoubleClick(selectRow);

                Thread.Sleep(500);

                //click on edit btn
                var editOrderManualStatusBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
                editOrderManualStatusBtn.Click();
                Thread.Sleep(3000);


                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                //call method validateInsertedOrderManualStatusInGridList


                CreateValidation(_CustomField2Entity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteCustomField2()
    {
        TestInitialize(nameof(DeleteCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddCustomField2Func();
                Delete(_CustomField2Entity.Code, "CustomFieldTwo-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInCustomField2()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField2");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInCustomField2()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField2");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInCustomField2()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField2");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInCustomField2()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField2");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInCustomField2()
    {
        TestInitialize(nameof(ListViewBtnCheckInCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField2");
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInCustomField2()
    {
        TestInitialize(nameof(CardViewBtnCheckInCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "CustomField2");
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateCustomField2()
    {
        TestInitialize(nameof(DetailValidateCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddCustomField2Func();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_CustomField2Entity.Code.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("CustomFieldTwo-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _CustomField2Entity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _CustomField2Entity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInCustomField2()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "CustomField2", filed: "description");

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
                GoToUrl("FileMaintenance", "CustomField2");
                RefreshRecordDataInGrid("CustomFieldTwo-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}
