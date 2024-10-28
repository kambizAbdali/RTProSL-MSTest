using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.Settings;
using RTProSL_MSTest.TestClasses.PurchaseOrder.Subrental;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;
//developed by kambiz Abdali

public class OrderManualStatusEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___OrderProcessing")]
public class OrderManualStatus : BaseClass
{
    private OrderManualStatusEntity _OrderManualStatusEntity;

    public void AddOrderManualStatusFunc()
    {
        GoToUrl("FileMaintenance", "OrderManualStatus");
        _OrderManualStatusEntity = new OrderManualStatusEntity();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());
        CreateAdd(_OrderManualStatusEntity);
        Thread.Sleep(1000);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void OrderManualStatusInsertValidate()
    {
        ListViewBtnValidate();
        Thread.Sleep(3000);

        SearchAndEditClick(_OrderManualStatusEntity.Code.Trim());
        CreateValidation(_OrderManualStatusEntity);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddOrderManualStatus()
    {
        TestInitialize(nameof(AddOrderManualStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOrderManualStatusFunc();
                OrderManualStatusInsertValidate();
                //ValidateInsertedOrderManualStatusInGridList();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBtnOrderManualStatus()
    {
        TestInitialize(nameof(EditBtnOrderManualStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOrderManualStatusFunc();

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page OrderManualStatusSetup Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                // read and write data in struct
                CreateAdd(_OrderManualStatusEntity);
                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();


                ///////////////////// in code mire va avalin recorde jadval ro click mikone ghablan in cod dar foldere validate bood

                SearchTextInMainGrid(_OrderManualStatusEntity.Code.Trim());
                Thread.Sleep(700);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _OrderManualStatusEntity.Code.Trim());
                webElementAction.DoubleClick(selectRow);

                Thread.Sleep(500);

                //click on edit btn
                var editOrderManualStatusBtn =
                    webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
                editOrderManualStatusBtn.Click();
                Thread.Sleep(3000);

                CreateValidation(_OrderManualStatusEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteOrderManualStatus()
    {
        TestInitialize(nameof(DeleteOrderManualStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOrderManualStatusFunc();
                Delete(_OrderManualStatusEntity.Code, "OrderManualStatusList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInOrderManualStatus()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInOrderManualStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "OrderManualStatus");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInOrderManualStatus()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInOrderManualStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "OrderManualStatus");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInOrderManualStatus()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInOrderManualStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "OrderManualStatus");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInOrderManualStatus()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInOrderManualStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "OrderManualStatus");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInOrderManualStatus()
    {
        TestInitialize(nameof(ListViewBtnCheckInOrderManualStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "OrderManualStatus");
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInOrderManualStatus()
    {
        TestInitialize(nameof(CardViewBtnCheckInOrderManualStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "OrderManualStatus");
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateOrderManualStatus()
    {
        TestInitialize(nameof(DetailValidateOrderManualStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOrderManualStatusFunc();

                SearchTextInMainGrid(_OrderManualStatusEntity.Code);
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("OrderManualStatusList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _OrderManualStatusEntity.Code).Click();

                Thread.Sleep(2000);
                gridList = webElementAction.GetElementById("OrderManualStatusList-gridId");
                ReadOnlyCollection<IWebElement> colIds =
                    gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                //_SubrentalPOScreenEntity.BillingTab.SalesDisc = _SubrentalPOScreenEntity.BillingTab.SalesDisc.Replace("%", "");
                CreateValidationInGrid(colIds, _OrderManualStatusEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInOrderManualStatus()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInOrderManualStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "OrderManualStatus", filed: "description");
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
                GoToUrl("FileMaintenance", "OrderManualStatus");
                RefreshRecordDataInGrid("OrderManualStatusList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}