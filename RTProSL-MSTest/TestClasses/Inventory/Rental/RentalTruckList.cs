// Developed By Mohammad Keshavarz


using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;

//** Create a data structure to read and write information. We use this data structure for validation operations
public class RentalTruckEnity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }
    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    public string description { set; get; }

    [ValidationDataType(DataType.TextArea)]
    public string Notes { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    public bool RollupPrice { get; set; }

    //public string FirstItemSelectedInPermittedLocation { set; get; }
    //public string FirstItemSelectedInPermittedDepartment { set; get; }
}

public class RentalTruckequiepmentEnity
{
    [ValidationElementProperty("mainId")]
    public string Main { set; get; }

    [ValidationElementProperty("equipmentId")]
    public string Equipment { set; get; }

    [ValidationElementProperty("description")]
    public string Description { set; get; }
    public string Quantity { set; get; }
    public string Daily { set; get; }

    public string Weekly { set; get; }

    public string ExtendedDailyekly { set; get; }

    public string ExtendedWeekly { set; get; }

    public string Billable { set; get; }

    public string QtyonTruck { set; get; }

    public string SortOrder { set; get; }

}

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class RentalTruck : BaseClass
{
    // instance from RentalAgentEnity struct
    private RentalTruckEnity _RentalTruckEnity;

    // add Rental agent
    public void AddRentalTruckFunc()
    {
        GoToUrl("MMInventory", "RentalTruckList");

        ShowAllRedord();
        // click on btn add in page Rental Truck Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page Rental Agent Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());
        _RentalTruckEnity = new RentalTruckEnity();
        CreateAdd(_RentalTruckEnity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidationInsertRentalTruckFunc()
    {
        ShowAllRedord();
        Thread.Sleep(700);

        //var searchInput = webElementAction.GetElementBySpecificAttribute("class", "grid-search-input-container")
        //    .FindElement(By.TagName("input")); //grid-search-input-container
        //searchInput.SendKeys(_RentalAgentEnity.Code.Trim());



        // use linq for search and find element in parent elements
        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _RentalTruckEnity.Code.Trim());

        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();

        Thread.Sleep(3000);


        CreateValidation(_RentalTruckEnity);
        //ValidateEntityUserInGridListFunc();
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddRentalTruck()
    {
        TestInitialize(nameof(AddRentalTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _RentalTruckEnity = new RentalTruckEnity();
                AddRentalTruckFunc();

                SearchTextInMainGrid(_RentalTruckEnity.Code.Trim());

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteRentalTruck()
    {
        TestInitialize(nameof(DeleteRentalTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // call addRentalTruckFunc
                AddRentalTruckFunc();
                ClearAllTagList();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_RentalTruckEnity.Code, "RentalTruckList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckRentalTruck()
    {
        TestInitialize(nameof(ArrowNextBtnCheckRentalTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalTruckList");
                ShowAllRedord();
                // call method NextBtn
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckRentalTruck()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckRentalTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalTruckList");
                ShowAllRedord();
                //call arrow previous
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckRentalTruck()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckRentalTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalTruckList");
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
    public void ArrowLastBtnCheckRentalTruck()
    {
        TestInitialize(nameof(ArrowLastBtnCheckRentalTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalTruckList");
                ShowAllRedord();
                //call method arrowlastbtn
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckRentalTruck()
    {
        TestInitialize(nameof(ListViewtBtnCheckRentalTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalTruckList");
                ShowAllRedord();
                //call list view btn 
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ThumbnailViewBtnCheckRentalTruck()
    {
        TestInitialize(nameof(ThumbnailViewBtnCheckRentalTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalTruckList");
                ShowAllRedord();
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
    public void CardViewBtnCheckRentalTruck()
    {
        TestInitialize(nameof(CardViewBtnCheckRentalTruck));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RentalTruckList");
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
    public void ValidateRequiredFieldsMessageBoxInRentalTruckList()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInRentalTruckList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "MMInventory", subMenu: "RentalTruckList", filed: "description");
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
                GoToUrl("MMInventory", "RentalTruckList");
                RefreshRecordDataInGrid("RentalTruckList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

}