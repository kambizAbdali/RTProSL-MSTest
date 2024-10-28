//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;

// define class struct SubrentalReason
public class SubrentalReasonEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool InActive { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___OrderProcessing")]
public class SubrentalReason : BaseClass
{
    // new struct SubrentalReasonEntity
    private SubrentalReasonEntity _SubrentalReasonEntity;

    public void AddSubrentalReasonFunc()
    {
        GoToUrl("FileMaintenance", "SubrentalReason");
        _SubrentalReasonEntity = new SubrentalReasonEntity();
        ShowAllRedord();
        // click on btn add in page SubrentalReason Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page SubrentalReason  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_SubrentalReasonEntity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }


    private void ValidateInsertSubrentalReasonFunc()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_SubrentalReasonEntity.Code.Trim());

        Thread.Sleep(2000);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _SubrentalReasonEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(2000);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInserted SubrentalReason();
        CreateValidation(_SubrentalReasonEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddSubrentalReason()
    {
        TestInitialize(nameof(AddSubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSubrentalReasonFunc();
                ValidateInsertSubrentalReasonFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSubrentalReason()
    {
        TestInitialize(nameof(DeleteSubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call SubrentalReason add 
                AddSubrentalReasonFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_SubrentalReasonEntity.Code, "SubrentalReasonList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckSubrentalReason()
    {
        TestInitialize(nameof(ArrowNextBtnCheckSubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SubrentalReason");
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
    public void ArrowPreviousBtnCheckSubrentalReason()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckSubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SubrentalReason");
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
    public void ArrowFirstBtnCheckSubrentalReason()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckSubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SubrentalReason");
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
    public void ArrowLastBtnCheckProduction()
    {
        TestInitialize(nameof(ArrowLastBtnCheckProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SubrentalReason");
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
    public void EditBtnSubrentalReason()
    {
        TestInitialize(nameof(EditBtnSubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SubrentalReason");

                Thread.Sleep(3000);

                ShowAllRedord();

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);
                _SubrentalReasonEntity = new SubrentalReasonEntity();
                CreateAdd(_SubrentalReasonEntity);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertSubrentalReasonFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void InactiveBtnCheckSubrentalReason()
    {
        TestInitialize(nameof(InactiveBtnCheckSubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SubrentalReason");

                ActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ActiveBtnCheckSubrentalReason()
    {
        TestInitialize(nameof(ActiveBtnCheckSubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SubrentalReason");
                ShowAllRedord();
                // Click on button inActive
                webElementAction.GetAllElementsByCssSelector("[data-legend-name='INACTIVE']")[1].Click();

                for (int i = 0; i < 2; i++)
                    // Click on button active
                    webElementAction.GetAllElementsByCssSelector("[data-legend-name='ACTIVE']")[1].Click();

                var inActiveColIds = webElementAction.GetAllElementsByCssSelector("[col-id='inactive']");
                foreach (var item in inActiveColIds)
                {
                    if (webElementAction.IsElementPresent(By.CssSelector(".icon-tick-blue"), item))
                        throw new Exception("Error: Active button validate incorrected.");
                };
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckSubrentalReason()
    {
        TestInitialize(nameof(ListViewtBtnCheckSubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SubrentalReason");
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
    public void CardViewBtnCheckSubrentalReason()
    {
        TestInitialize(nameof(CardViewBtnCheckSubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "SubrentalReason");
                ShowAllRedord();
                //call card btn
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateSubrentalReason()
    {
        TestInitialize(nameof(DetailValidateSubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSubrentalReasonFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_SubrentalReasonEntity.Code.Trim());
                Thread.Sleep(4000);

                var gridList = webElementAction.GetElementById("SubrentalReasonList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _SubrentalReasonEntity.Code.Trim()).Click();

                ChangeScreenPageSize(60);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                // _DepartmentEntity.SortOrder = webElementAction.FormatNumberWithCommas(_DepartmentEntity.SortOrder);
                CreateValidationInGrid(colIds, _SubrentalReasonEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInSubrentalReason()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "SubrentalReason", filed: "description");
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
                GoToUrl("FileMaintenance", "SubrentalReason");
                RefreshRecordDataInGrid("SubrentalReasonList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}