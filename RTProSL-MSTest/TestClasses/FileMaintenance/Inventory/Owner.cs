// develop by Mohammad_Keshavarz

//Prerequisite: Checking the 'Use Owner Logic for Sales' and 'Use Owner Logic for Rental Equipment' options in the system setup.
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

public class OwnerEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    [ValidationElementProperty("percentage")]
    public string RentalPercentage { set; get; }

    public string Description { set; get; }

    [ValidationElementProperty("salesPercentage")]
    public string SalesPercentage { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool Inactive { set; get; }

    [ValidationElementProperty("address1")]
    public string Address1 { set; get; }

    [ValidationElementProperty("address2")]
    public string Address2 { set; get; }

    [ValidationElementProperty("address2B")]
    public string Address3 { set; get; }

    [ValidationElementProperty("address3")]
    public string Address4 { set; get; }

    [ValidationElementProperty("address4")]
    public string Address5 { set; get; }

    public string Phone { set; get; }

    public string Pager { set; get; }

    public string Email { set; get; }

    public string Fax { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___Inventory")]
public class Owner : BaseClass
{
    private OwnerEntity _OwnerEntity;

    public void AddOwnerFunc()
    {
        GoToUrl("FileMaintenance", "Owner");
        ShowAllRedord();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());
        _OwnerEntity = new Inventory.OwnerEntity();
        CreateAdd(_OwnerEntity);
        Thread.Sleep(1000);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();

        
    }

    private void ValidateInsertedOwnerFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_OwnerEntity.Code.Trim());

        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _OwnerEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        CreateValidation(_OwnerEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddOwner()
    {
        TestInitialize(nameof(AddOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOwnerFunc();
                ValidateInsertedOwnerFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBtnOwner()
    {
        TestInitialize(nameof(EditBtnOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Owner");
                ShowAllRedord();
                _OwnerEntity = new OwnerEntity();

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_OwnerEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();
                ShowAllRedord();
                ValidateInsertedOwnerFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateOwner()
    {
        TestInitialize(nameof(DetailValidateOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOwnerFunc();
                ListViewBtnValidate();
                //ShowAllRedord();

                SearchTextInMainGrid(_OwnerEntity.Code.Trim());

                Thread.Sleep(3000);
                var gridlist = webElementAction.GetElementById("OwnerList-gridId");
                var selectRow = gridlist.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _OwnerEntity.Code.Trim());
                selectRow.Click();

                ChangeScreenPageSize(30);
               
                ReadOnlyCollection<IWebElement> colIds = gridlist.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                //_OwnerEntity.SalesPercentage = _OwnerEntity.SalesPercentage.Replace("%", "");
                CreateValidationInGrid(colIds, _OwnerEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteOwner()
    {
        TestInitialize(nameof(DeleteOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Owner add 
                AddOwnerFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_OwnerEntity.Code, "OwnerList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInOwner()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Owner");
                ShowAllRedord();
                ShowAllRedord();
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInOwner()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Owner");
                ShowAllRedord();
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInOwner()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Owner");
                ShowAllRedord();
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInOwner()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Owner");
                ShowAllRedord();
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    public void CardViewBtnCheckInOwner()
    {
        TestInitialize(nameof(CardViewBtnCheckInOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Owner");
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
    public void ListViewBtnCheckInOwner()
    {
        TestInitialize(nameof(ListViewBtnCheckInOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Owner");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInOwner()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInOwner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "Owner", filed: "description");
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
                GoToUrl("FileMaintenance", "Owner");
                RefreshRecordDataInGrid("OwnerList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}