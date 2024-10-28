// develop by Mohammad_Keshavarz

// Prerequisite: The "Use Partner" checkbox must be checked in the system setup.

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.Administration.Tables;

public class PartnerstructureEntity
{
    public string Description { set; get; }

    [ValidationElementProperty("id")]
    public string Code { set; get; }
}

[TestCategory("Administration")]
[TestClass, TestCategory("Administration___Tables")]
public class PartnerStructure : BaseClass
{
    private PartnerstructureEntity _PartnerStructure;

    public void AddPartnerstructureFunc()
    {
        GoToUrl("Administration", "PartnerStructure");
        _PartnerStructure = new PartnerstructureEntity();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_PartnerStructure);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }


    private void ValidateInsertPartnetStructureFunc()
    {
        SearchTextInMainGrid(_PartnerStructure.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _PartnerStructure.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);
        CreateValidation(_PartnerStructure);
        //ValidateInsertedMasterInGridList();
    }

    // Prerequisite: The "Use Partner" checkbox must be checked in the system setup.
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddPartnerstructure()
    {
        TestInitialize(nameof(AddPartnerstructure));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPartnerstructureFunc();
                ValidateInsertPartnetStructureFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditPartnerstructure()
    {
        TestInitialize(nameof(EditPartnerstructure));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to department page 
                GoToUrl("Administration", "PartnerStructure");
                _PartnerStructure = new PartnerstructureEntity();

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);


                CreateAdd(_PartnerStructure);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertPartnetStructureFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInPartnerStructure()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInPartnerStructure));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "PartnerStructure");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInPartnerStructure()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInPartnerStructure));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "PartnerStructure");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInPartnerStructure()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInPartnerStructure));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "PartnerStructure");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInPartnerStructure()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInPartnerStructure));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "PartnerStructure");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInPartnerStructure()
    {
        TestInitialize(nameof(ListViewBtnCheckInPartnerStructure));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "PartnerStructure");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    // Prerequisite: The "Use Partner" checkbox must be checked in the system setup.
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidatePartnerstructure()
    {
        TestInitialize(nameof(DetailValidatePartnerstructure));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPartnerstructureFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_PartnerStructure.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("PartnerStructureList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _PartnerStructure.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _PartnerStructure);
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
                GoToUrl("Administration", "PartnerStructure");
                RefreshRecordDataInGrid("PartnerStructureList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}