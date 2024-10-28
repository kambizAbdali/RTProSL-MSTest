//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;

// define class structShippingAddress
public class ShippingAddressEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string ShipCode { set; get; }

    [ValidationElementProperty("shippingName")]
    public string ShipName { set; get; }

    [ValidationElementProperty("shippingAddressLine1")]
    public string Address1 { set; get; }

    [ValidationElementProperty("shippingAddressLine2B")]
    public string Address2 { set; get; }

    [ValidationElementProperty("shippingAddressLine2")]
    public string Address3 { set; get; }

    [ValidationElementProperty("shippingAddressLine3")]
    public string City { set; get; }

    [ValidationElementProperty("shipState")]
    public string State { set; get; }

    [ValidationElementProperty("shipZipCode")]
    public string Zip { set; get; }

    [ValidationElementProperty("shippingAddressLine4")]
    public string ShipCountry { set; get; }


    [ValidationDataType(DataType.TextArea)]
    [ValidationElementProperty("notes")]
    public string Notes { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___OrderProcessing")]
public class ShippingAddress : BaseClass
{
    // new struct ShippingAddressEntity
    private ShippingAddressEntity _ShippingAddressEntity;


    public void AddShippingAddressFunc()
    {
        GoToUrl("FileMaintenance", "ShippingAddress");
        _ShippingAddressEntity = new ShippingAddressEntity();

        // click on btn add in page ShippingAddress Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page ShippingAddress  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_ShippingAddressEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertShippingAddressFunc()
    {
        SearchTextInMainGrid(_ShippingAddressEntity.ShipCode.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _ShippingAddressEntity.ShipCode.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInsertedDepartment();
        CreateValidation(_ShippingAddressEntity);
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddShippingAddress()
    {
        TestInitialize(nameof(AddShippingAddress));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddShippingAddressFunc();
                ValidateInsertShippingAddressFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteShippingAddress()
    {
        TestInitialize(nameof(DeleteShippingAddress));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call ShippingAddress add 
                AddShippingAddressFunc();
                //ShowAllRedord();
                // call delete method from base class 
                Delete(_ShippingAddressEntity.ShipCode, "ShippingAddressList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckShippingAddress()
    {
        TestInitialize(nameof(ArrowNextBtnCheckShippingAddress));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingAddress");
                //ShowAllRedord();
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
    public void ArrowPreviousBtnCheckShippingAddress()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckShippingAddress));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingAddress");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckShippingAddress()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckShippingAddress));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingAddress");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckShippingAddress()
    {
        TestInitialize(nameof(ArrowLastBtnCheckShippingAddress));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingAddress");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBtnShippingAddress()
    {
        TestInitialize(nameof(EditBtnShippingAddress));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingAddress");
                _ShippingAddressEntity = new ShippingAddressEntity();
                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();
                ;
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_ShippingAddressEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertShippingAddressFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckShippingAddress()
    {
        TestInitialize(nameof(ListViewtBtnCheckShippingAddress));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingAddress");
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckShippingAddress()
    {
        TestInitialize(nameof(CardViewBtnCheckShippingAddress));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ShippingAddress");
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateShippingAddress()
    {
        TestInitialize(nameof(DetailValidateShippingAddress));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddShippingAddressFunc();
                ChangeScreenPageSize(80);
                Thread.Sleep(3000);
                var gridList = webElementAction.GetElementById("ShippingAddressList-gridId");
                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                Thread.Sleep(1500);
                CreateValidationInGrid(colIds, _ShippingAddressEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInShippingAddress()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInShippingAddress));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "ShippingAddress", filed: "shippingName");
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
                GoToUrl("FileMaintenance", "ShippingAddress");
                RefreshRecordDataInGrid("ShippingAddressList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}