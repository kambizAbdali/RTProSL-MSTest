// Developed By Mohammad Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.Administration.Tables;

//** Create a data structure to read and write information. We use this data structure for validation operations
public class RentalAgentEnity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Phone { set; get; }

    [ValidationElementProperty("name")]
    public string Name { set; get; }

    [ValidationElementProperty("cellPhone")]
    public string CellPhone { set; get; }

    [ValidationElementProperty("fax")]
    public string Fax { set; get; }

    [ValidationElementProperty("monthlyRevenueGoal")]
    public string MonthlyRevenueGoal { set; get; }

    [ValidationElementProperty("email")]
    public string Email { set; get; }


    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("showOnWebsite")]
    public bool ShowonWebsite { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool InActive { get; set; }

    [ValidationDataType(DataType.TextArea)]
    public string Notes { set; get; }

    //public string FirstItemSelectedInPermittedLocation { set; get; }
    //public string FirstItemSelectedInPermittedDepartment { set; get; }
}

[TestCategory("Administration")]
[TestClass, TestCategory("Administration___Tables")]
public class RentalAgent : BaseClass
{
    // instance from RentalAgentEnity struct
    private RentalAgentEnity _RentalAgentEnity;

    // go to page Rental agent

    // add Rental agent
    public void AddRentalAgentFunc()
    {
        GoToUrl("Administration", "RentalAgent");
        _RentalAgentEnity = new RentalAgentEnity();

        ShowAllRedord();
        // click on btn add in page Rental Agent Entry Screen
        webElementAction.GetElementById("TOOL_BOX_ADD_BUTTON_ID").Click();

        // data insert to feilds in page Rental Agent Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_RentalAgentEnity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidationInsertRentalAgentFunc()
    {
        ShowAllRedord();
        Thread.Sleep(700);

        // use linq for search and find element in parent elements
        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _RentalAgentEnity.Code.Trim());

        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();

        Thread.Sleep(3000);


        CreateValidation(_RentalAgentEnity);
        //ValidateEntityUserInGridListFunc();
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddRentalAgent()
    {
        TestInitialize(nameof(AddRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _RentalAgentEnity = new RentalAgentEnity();
                AddRentalAgentFunc();

                SearchTextInMainGrid(_RentalAgentEnity.Code.Trim());

                ValidationInsertRentalAgentFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteRentalAgent()
    {
        TestInitialize(nameof(DeleteRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call addRentalAgentFunc
                AddRentalAgentFunc();
                ShowAllRedord();
                //call delete method from base class
                Delete(_RentalAgentEnity.Code, gridId: "RentalAgentList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckRentalAgent()
    {
        TestInitialize(nameof(ArrowNextBtnCheckRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Administration", "RentalAgent");
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
    public void ArrowPreviousBtnCheckRentalAgent()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Administration", "RentalAgent");
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
    public void ArrowFirstBtnCheckRentalAgent()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Administration", "RentalAgent");
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
    public void ArrowLastBtnCheckRentalAgent()
    {
        TestInitialize(nameof(ArrowLastBtnCheckRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Administration", "RentalAgent");
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
    public void EditBtnRentalAgent()
    {
        TestInitialize(nameof(EditBtnRentalAgent));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _RentalAgentEnity = new RentalAgentEnity();
                //go to page rental agent

                AddRentalAgentFunc();

                Thread.Sleep(2000);
                // click on btn edit 
                ShowAllRedord();

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
    .FirstOrDefault(o => o.Text == _RentalAgentEnity.Code.Trim());
                webElementAction.DoubleClick(selectRow);

                webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1].Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_RentalAgentEnity);
                Thread.Sleep(1000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                Thread.Sleep(1000);
                ValidationInsertRentalAgentFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void InactiveBtnCheckRentalAgent()
    {
        TestInitialize(nameof(InactiveBtnCheckRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Administration", "RentalAgent");

                InActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ActiveBtnCheckRentalAgent()
    {
        TestInitialize(nameof(ActiveBtnCheckRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Administration", "RentalAgent");

                ActiveBtnCheck();

                testPassed = true;

            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckRentalAgent()
    {
        TestInitialize(nameof(ListViewtBtnCheckRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Administration", "RentalAgent");
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
    public void ThumbnailViewBtnCheckRentalAgent()
    {
        TestInitialize(nameof(ThumbnailViewBtnCheckRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Administration", "RentalAgent");
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
    public void CardViewBtnCheckRentalAgent()
    {
        TestInitialize(nameof(CardViewBtnCheckRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Administration", "RentalAgent");
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

    public void DetailValidateRentalAgent()
    {
        TestInitialize(nameof(DetailValidateRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddRentalAgentFunc();
                ListViewBtnValidate();
                ShowAllRedord();
                Thread.Sleep(3000);

                ChangeScreenPageSize(60);
                var gridList = webElementAction.GetElementById("RentalAgentList-gridId");


                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                var count = colIds.Count;
                CreateValidationInGrid(colIds, _RentalAgentEnity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInRentalAgent()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "Administration", subMenu: "RentalAgent", filed: "phone");
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
                GoToUrl("Administration", "RentalAgent");
                RefreshRecordDataInGrid("RentalAgentList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}