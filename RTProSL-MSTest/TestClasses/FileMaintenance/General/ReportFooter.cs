//developed by Mohammad_Keshavarz

using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.Administration.Tables;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.General;

// define class struct ReportFooter

public class ReportFooterEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Code { set; get; }

    [ValidationElementProperty("locationId")]
    public string Location { set; get; }

    public string Description { set; get; }

    [ValidationElementProperty("allowFooterToSplit")]
    [ValidationDataType(DataType.CheckBox)]
    public bool AllowFootertoSplit { set; get; }

    [ValidationElementProperty("printPageHeader")]
    [ValidationDataType(DataType.CheckBox)]
    public bool PrintPageHeader { set; get; }


    [ValidationElementProperty("startNewPage")]
    [ValidationDataType(DataType.CheckBox)]
    public bool StartNewPage { set; get; }

    [ValidationIgnore]
    [ValidationElementProperty("reportFooter")]
    public string FooterTextEditor { set; get; }
}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___General")]
public class ReportFooter : BaseClass
{
    // new struct ReportFooter Entity
    private ReportFooterEntity _ReportFooterEntity;

    public void AddReportFooterFunc()
    {
        _ReportFooterEntity = new ReportFooterEntity();
        GoToUrl("FileMaintenance", "ReportFooter");
        WaitForLoadingSpiner();
        // click on btn add in page DispatchStatusList Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));


        var webElementDataGenerator = new WebElementDataGenerator(GetFormLeftSideContext());
        CreateAdd(_ReportFooterEntity);

        Thread.Sleep(3000);

        // click on "View/Edit Footer Text"
        webElementAction.GetElementBySpecificAttribute("data-button-type", "outlined").Click();
        Thread.Sleep(2000);
        _ReportFooterEntity.FooterTextEditor = GenerateDataToEditor();
        webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm").Click();


        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertReportFooterFunc()
    {
        //ShowAllRedord();
        ///////////////////// in code mire va avalin recorde jadval ro click mikone ghablan in cod dar foldere validate bood

        SearchTextInMainGrid(_ReportFooterEntity.Code.Trim());
        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _ReportFooterEntity.Code.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////


        CreateValidation(_ReportFooterEntity);
        webElementAction.GetElementBySpecificAttribute("data-button-type", "outlined").Click();
        Thread.Sleep(2000);
        var footerTextEditor = webElementAction.GetElementByXPath("//body[1]").Text;
        if (_ReportFooterEntity.FooterTextEditor != GetLast500Characters(footerTextEditor) && _ReportFooterEntity.FooterTextEditor == "")
            throw new Exception("Error __dose not match inserted footer text editor with save footer text editor");
        webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm").Click();
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddReportFooter()
    {
        TestInitialize(nameof(AddReportFooter));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddReportFooterFunc();
                ValidateInsertReportFooterFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteReportFooter()
    {
        TestInitialize(nameof(DeleteReportFooter));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Truck add 
                AddReportFooterFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_ReportFooterEntity.Code, "ReportFooterList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckReportFooter()
    {
        TestInitialize(nameof(ArrowNextBtnCheckReportFooter));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ReportFooter");
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
                GoToUrl("FileMaintenance", "ReportFooter");
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
    public void ArrowFirstBtnCheckReportFooter()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckReportFooter));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ReportFooter");
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
    public void ArrowLastBtnCheckReportFooter()
    {
        TestInitialize(nameof(ArrowLastBtnCheckReportFooter));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ReportFooter");
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
    public void EditBtnReportFooter()
    {
        TestInitialize(nameof(EditBtnReportFooter));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ReportFooter");
                Thread.Sleep(2000);

                webElementAction.GetElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID").Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide").FindElements(By.TagName("div")).FirstOrDefault();

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page DispatchStatusList  Entry Screen whith radnom data
                new WebElementDataGenerator(context);
                _ReportFooterEntity = new ReportFooterEntity();
                CreateAdd(_ReportFooterEntity);

                Thread.Sleep(3000);

                // click on "View/Edit Footer Text"
                webElementAction.GetElementBySpecificAttribute("data-button-type", "outlined").Click();
                Thread.Sleep(2000);
                _ReportFooterEntity.FooterTextEditor = GenerateDataToEditor();
                webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm").Click();

                Thread.Sleep(1000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                Thread.Sleep(2000);


                ValidateInsertReportFooterFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckReportFooter()
    {
        TestInitialize(nameof(ListViewtBtnCheckReportFooter));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ReportFooter");
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
    public void DetailValidateInsertReportFooter()
    {
        TestInitialize(nameof(DetailValidateInsertReportFooter));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddReportFooterFunc();
                ListViewBtnValidate();
                ShowAllRedord();
                Thread.Sleep(2000);

                var gridList = webElementAction.GetElementById("ReportFooterList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _ReportFooterEntity.Code.Trim()).Click();

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _ReportFooterEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnReportFooter()
    {
        TestInitialize(nameof(CardViewBtnReportFooter));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ReportFooter");
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
    public void ValidateRequiredFieldsMessageBoxInReportFooter()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInReportFooter));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "FileMaintenance", subMenu: "ReportFooter", filed: "description");
                validateRequiredFields.Run();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private string GenerateDataToEditor()
    {
        var textEditor = webElementAction.GetElementByXPath("//body[1]");
        Actions actions = new Actions(ObjectRepository.Driver);
        actions.Click(textEditor)
            .SendKeys(RandomValueGenerator.GenerateRandomString(510))
            .Build()
            .Perform();
        Thread.Sleep(2000);

        return GetLast500Characters(textEditor.Text);
    }

    private string GetLast500Characters(string text) // TODO add comment
    {
        string last500Characters = text.Substring(Math.Max(0, text.Length - 500));
        return last500Characters;
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "ReportFooter");
                RefreshRecordDataInGrid("ReportFooterList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}