//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Dispatch;

// define class struct Driver

public class DriverEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    [ValidationElementProperty("classification")]
    public string Classification { set; get; }


    [ValidationIgnore(Type = BaseClass.IgnoreType.Add)]
    public string DriversLicense { set; get; }

    public string State { set; get; }

    [ValidationDataType(DataType.Color)]
    public string Color { set; get; }

    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    public string Name { set; get; }

    [ValidationElementProperty("inactive")]
    [ValidationDataType(DataType.CheckBox)]
    public bool Inactive { set; get; }


}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Dispatch")]
public class Driver : BaseClass
{
    // new struct Driver Entity
    private DriverEntity _DriverEntity;

    public void AddDriverFunc()
    {
        GoToUrl("FileMaintenance", "Driver");
        // click on btn add in page Driver Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        _DriverEntity = new DriverEntity();
        Thread.Sleep(2000);
        // data insert to feilds in page Driver  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());
        CreateAdd(_DriverEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertDriverFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_DriverEntity.Code.Trim());

        Thread.Sleep(700);

        var gridList = webElementAction.GetElementById("DriverList-gridId");

        var selectRow = gridList.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _DriverEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        CreateValidation(_DriverEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddDriver()
    {
        TestInitialize(nameof(AddDriver));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddDriverFunc();
                ValidateInsertDriverFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteDriver()
    {
        TestInitialize(nameof(DeleteDriver));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Truck add 
                AddDriverFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_DriverEntity.Code, "DriverList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckDriver()
    {
        TestInitialize(nameof(ArrowNextBtnCheckDriver));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Driver");
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
    public void ArrowPreviousBtnCheckDriver()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckDriver));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Driver");
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
    public void ArrowFirstBtnCheckDriver()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckDriver));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Driver");
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
    public void ArrowLastBtnCheckDriver()
    {
        TestInitialize(nameof(ArrowLastBtnCheckDriver));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Driver");
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
    public void EditBtnDriver()
    {
        TestInitialize(nameof(EditBtnDriver));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddDriverFunc();
                WaitForLoadingSpiner();
                Thread.Sleep(100);
                // click on btn edit 
                ShowAllRedord();

                SearchTextInMainGrid(_DriverEntity.Code.Trim());
                WaitForLoadingSpiner();

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
        .FirstOrDefault(o => o.Text == _DriverEntity.Code.Trim());
                webElementAction.DoubleClick(selectRow);

                webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Driver Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_DriverEntity);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();
                ValidateInsertDriverFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckDriver()
    {
        TestInitialize(nameof(ListViewtBtnCheckDriver));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Driver");
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
    public void DetailValidateDriver()
    {
        TestInitialize(nameof(DetailValidateDriver));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddDriverFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_DriverEntity.Code.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("DriverList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _DriverEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _DriverEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnDriver()
    {
        TestInitialize(nameof(CardViewBtnDriver));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Driver");
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
    public void ValidateRequiredFieldsMessageBoxInDriver()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInDriver));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "Driver", filed: "classification");
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
                GoToUrl("FileMaintenance", "Driver");
                RefreshRecordDataInGrid("DriverList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}