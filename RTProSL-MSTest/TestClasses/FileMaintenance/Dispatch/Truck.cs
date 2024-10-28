//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Dispatch;

// define class struct Truck

public class TruckEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    [ValidationElementProperty("vehicleNo")]
    public string Vehicle { set; get; }

    public string Description { set; get; }

    public string LicensePlate { set; get; }

    public string State { set; get; }

    [ValidationDataType(DataType.Color)]
    public string Color { set; get; }

    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    [ValidationElementProperty("owned")]
    [ValidationDataType(DataType.CheckBox)]
    public bool Owned { set; get; }

    [ValidationElementProperty("inactive")]
    [ValidationDataType(DataType.CheckBox)]
    public bool Inactive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Dispatch")]
public class Truck : BaseClass
{
    // new struct DispatchStatusList Entity
    private TruckEntity _TruckEntity;

    public void AddTruckFunc()
    {
        GoToUrl("FileMaintenance", "Truck");
        _TruckEntity = new TruckEntity();

        // click on btn add in page DispatchStatusList Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page DispatchStatusList  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_TruckEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertTruckFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_TruckEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _TruckEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        CreateValidation(_TruckEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddTruck()
    {
        TestInitialize(nameof(AddTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddTruckFunc();
                ValidateInsertTruckFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteTruck()
    {
        TestInitialize(nameof(DeleteTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Truck add 
                AddTruckFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_TruckEntity.Code, "TruckList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckTruck()
    {
        TestInitialize(nameof(ArrowNextBtnCheckTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Truck");
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
    public void ArrowPreviousBtnCheckTruck()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckTruck));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Truck");
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
    public void ArrowFirstBtnCheckTruck()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Truck");
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
    public void ArrowLastBtnCheckTruck()
    {
        TestInitialize(nameof(ArrowLastBtnCheckTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Truck");
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
    public void EditBtnTruck()
    {
        TestInitialize(nameof(EditBtnTruck));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddTruckFunc();

                Thread.Sleep(1000);
                SearchAndEditClick(_TruckEntity.Code.Trim());


                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //clear all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Truck Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_TruckEntity);
                Thread.Sleep(1000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                Thread.Sleep(2000);

                webElementAction.GetElementBySpecificAttribute("data-icon-name", "clear-text").Click();
                ValidateInsertTruckFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckTruck()
    {
        TestInitialize(nameof(ListViewtBtnCheckTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Truck");
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
    public void DetailValidateTruck()
    {
        TestInitialize(nameof(DetailValidateTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddTruckFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_TruckEntity.Code.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("TruckList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _TruckEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _TruckEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnTruck()
    {
        TestInitialize(nameof(CardViewBtnTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Truck");
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
    public void ValidateRequiredFieldsMessageBoxInTruck()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "Truck", filed: "description");
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
                GoToUrl("FileMaintenance", "Truck");
                RefreshRecordDataInGrid("TruckList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}