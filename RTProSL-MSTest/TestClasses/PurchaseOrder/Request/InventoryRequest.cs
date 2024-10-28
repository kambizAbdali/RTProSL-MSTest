//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
using System.Drawing;

namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Request;

// define class strct InventoryRequest
public class InventoryRequestEntity
{

    [ValidationElementProperty("requestNo")]
    public string Request { set; get; }


    public string Date { set; get; }

    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    [ValidationIgnoreInGrid]
    [ValidationElementProperty("languageId")]
    public string Language { set; get; }

    [ValidationElementProperty("productionId")]
    public string Production { set; get; }

    [ValidationDataType(DataType.TextArea)]
    [ValidationElementProperty("notes")]
    public string Notes { set; get; }


    [TestCategory("PurchaseOrder")]
    [TestClass, TestCategory("PurchaseOrder___Request")]
    public class InventoryRequest : BaseClass
    {
        // new struct InventoryRequestEntity
        private InventoryRequestEntity _InventoryRequestEntity;


        public void AddInventoryRequestFunc()
        {
            _InventoryRequestEntity = new InventoryRequestEntity();

            GoToUrl("PurchaseOrder", "InventoryRequest");
            RefreshAllRows();
            // click on btn add in page InventoryRequest Entry Screen
            webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
            //RefreshAllRows();
            // context of inputs 


            var maincontex = GetFormLeftSideContext(true);
            var requestElement = webElementAction.GetElementByXPath("//input[@class='main-input']");

            var requestValue = requestElement.GetAttribute("value"); ;
            var webElementDataGenerator = new WebElementDataGenerator(maincontex);

            requestElement.Clear();
            requestElement.SendKeys(requestValue);

            CreateAdd(_InventoryRequestEntity, maincontex);
            //click on saveAndCloseBtn and check confirm
            SaveAndConfirmCheck();
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void AddInventoryRequest()
        {
            TestInitialize(nameof(AddInventoryRequest));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    AddInventoryRequestFunc();

                    SearchAndEditClick(_InventoryRequestEntity.Request);
                    CreateAdd(_InventoryRequestEntity);
                    CreateValidation(_InventoryRequestEntity);


                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }




        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ArrowNextBtnCheckInventoryRequest()
        {
            TestInitialize(nameof(ArrowNextBtnCheckInventoryRequest));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryRequest");
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
        public void ArrowPreviousBtnCheckInventoryRequest()
        {
            TestInitialize(nameof(ArrowPreviousBtnCheckInventoryRequest));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryRequest");
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
        public void ArrowFirstBtnCheckInventoryRequest()
        {
            TestInitialize(nameof(ArrowFirstBtnCheckInventoryRequest));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryRequest");
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
        public void ArrowLastBtnCheckInventoryRequest()
        {
            TestInitialize(nameof(ArrowLastBtnCheckInventoryRequest));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryRequest");
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




        private void ValidateInsertInventoryRequestFunc()
        {
            SearchTextInMainGrid(_InventoryRequestEntity.Request.Trim());
            Thread.Sleep(700);

            var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                .FirstOrDefault(o => o.Text == _InventoryRequestEntity.Request.Trim());
            webElementAction.DoubleClick(selectRow);

            Thread.Sleep(500);

            //click on edit btn
            var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
            editUserBtn.Click();
            Thread.Sleep(3000);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            //ValidateInsertedDepartment();

            var mainContext = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide")
                .FindElements(By.TagName("div")).FirstOrDefault();
            CreateValidation(_InventoryRequestEntity, mainContext);
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void EditBtnInventoryRequest()
        {
            TestInitialize(nameof(EditBtnInventoryRequest));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    //navigate to department page 
                    GoToUrl("PurchaseOrder", "InventoryRequest");

                    Thread.Sleep(3000);

                    RefreshAllRows();

                    Thread.Sleep(3000);


                    // click on btn edit 
                    webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                    // define context page to variable
                    var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");



                    var maincontex = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide")
                        .FindElements(By.TagName("div")).FirstOrDefault();

                    var requestElement = webElementAction.GetElementByXPath("//input[@class='main-input']");
                    var requestValue = requestElement.GetAttribute("value");

                    //cleare all fields in context page 
                    webElementAction.ClearInputValuesInContext(context);

                    // data insert to feilds in page Rental Agent Entry Screen whith radnom data


                    _InventoryRequestEntity = new InventoryRequestEntity();


                    var webElementDataGenerator = new WebElementDataGenerator(maincontex);

                    requestElement.Clear();
                    requestElement.SendKeys(requestValue);

                    CreateAdd(_InventoryRequestEntity, maincontex);


                    //click on saveAndCloseBtn and check confirm
                    SaveAndConfirmCheck();

                    ValidateInsertInventoryRequestFunc();

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void DetailValidateInventoryRequest()
        {
            TestInitialize(nameof(DetailValidateInventoryRequest));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    AddInventoryRequestFunc();
                    ListViewBtnValidate();
                    ShowAllRedord();

                    SearchTextInMainGrid(_InventoryRequestEntity.Request.Trim());
                    Thread.Sleep(4000);

                    var gridList = webElementAction.GetElementById("InventoryRequest-gridId");
                    gridList.FindElements(By.TagName("div"))
                        .FirstOrDefault(o => o.Text == _InventoryRequestEntity.Request.Trim()).Click();

                    ChangeScreenPageSize(30);
                    Thread.Sleep(4000);
                    ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                    // _DepartmentEntity.SortOrder = webElementAction.FormatNumberWithCommas(_DepartmentEntity.SortOrder);
                    CreateValidationInGrid(colIds, _InventoryRequestEntity);
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryRequestByFromToDate()
        {
            TestInitialize(nameof(FilterInventoryRequestByFromToDate));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryRequest");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("beginDate", "InventoryRequest-gridId");
                    filterSearch.FilterSearchInDateTimeDataType("createDate");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryRequestByRequest()
        {
            TestInitialize(nameof(FilterInventoryRequestByRequest));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryRequest");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("requestNo", "InventoryRequest-gridId", "Request#");
                    filterSearch.FilterSearchInTextDataInGridDataType();

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryRequestByOrder()
        {
            TestInitialize(nameof(FilterInventoryRequestByOrder));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryRequest");

                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("orderNo", "InventoryRequest-gridId", "Order#");
                    filterSearch.FilterSearchInTextDataInGridDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryRequestByCreatedBy()
        {
            TestInitialize(nameof(FilterInventoryRequestByCreatedBy));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryRequest");

                    FilterSearch filterSearch = new FilterSearch("createBy", "InventoryRequest-gridId", "Created by");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        Dictionary<string, Color> ColorDict =
            new Dictionary<string, Color>()
            {
                {"Green", Color.FromArgb(0, 255, 0)},
            };

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterInventoryRequestByIncludeComplete()
        {
            TestInitialize(nameof(FilterInventoryRequestByIncludeComplete));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("PurchaseOrder", "InventoryRequest");

                    DataLegendNameFilter("COMPLETE");
                    FilterSearch filterSearch = new FilterSearch("includeComplete", "InventoryRequest-gridId", "Complete", colId: "complete", Color: ColorDict["Green"]);
                    filterSearch.FilterSearchInCheckBoxDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRequiredFieldsMessageBoxInInventoryRequest()
        {
            TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInInventoryRequest));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    ValidateRequiredFieldsMessage validateRequiredFields;
                    validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "PurchaseOrder", subMenu: "InventoryRequest", filed: "notes", clearDataFormItemName: "date");
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
                    GoToUrl("PurchaseOrder", "InventoryRequest");
                    RefreshRecordDataInGrid("InventoryRequest-gridId", columnId: "requestNo");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
