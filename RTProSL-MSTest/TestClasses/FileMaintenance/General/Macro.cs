//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.FileMaintenance.General;

// define class struct Macro

public class MacroEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string Keyword { set; get; }

    [ValidationDataType(DataType.TextArea)]
    public string SubstitutionalText { set; get; }

}

[TestCategory("FileMaintenance")]
[TestClass, TestCategory("FileMaintenance___General")]
public class Macro : BaseClass
{
    // new struct Macro Entity
    private MacroEntity _MacroEntity;

    public void AddMacroFunc()
    {
        _MacroEntity = new MacroEntity();
        GoToUrl("FileMaintenance", "Macro");

        ShowAllRedord();
        // click on btn add in page DispatchStatusList Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        // data insert to feilds in page DispatchStatusList  Entry Screen whith radnom data
        var webElementDataGenerator = new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_MacroEntity);

        //click on saveAnd Close Btn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertMacroFunc()
    {
        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[0];
        editUserBtn.Click();
        Thread.Sleep(500);

        //click on edit btn
        editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        CreateValidation(_MacroEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddMacro()
    {
        TestInitialize(nameof(AddMacro));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddMacroFunc();
                ValidateInsertMacroFunc();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteMacro()
    {
        TestInitialize(nameof(DeleteMacro));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Macro add 
                AddMacroFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_MacroEntity.Keyword, "MacroList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckMacro()
    {
        TestInitialize(nameof(ArrowNextBtnCheckMacro));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Macro");
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
    public void ArrowPreviousBtnCheckMacro()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckMacro));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Macro");
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
    public void ArrowFirstBtnCheckMacro()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckMacro));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Macro");
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
    public void ArrowLastBtnCheckMacro()
    {
        TestInitialize(nameof(ArrowLastBtnCheckMacro));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Macro");
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
    public void EditBtnMacro()
    {
        TestInitialize(nameof(EditBtnMacro));
        // use while for run 3 
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _MacroEntity = new MacroEntity();
                //go to page Macro

                AddMacroFunc();

                Thread.Sleep(3000);

                webElementAction.GetElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID").Click();
                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Macro Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_MacroEntity);
                Thread.Sleep(1000);
                //click on saveAndCloseBtn
                SaveAndConfirmCheck();

                Thread.Sleep(2000);
                ValidateInsertMacroFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckMacro()
    {
        TestInitialize(nameof(ListViewtBtnCheckMacro));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Macro");
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
    public void DetailValidateMacro()
    {
        TestInitialize(nameof(DetailValidateMacro));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddMacroFunc();
                ListViewBtnValidate();
                //ShowAllRedord();

                SearchTextInMainGrid(_MacroEntity.Keyword.Trim());

                Thread.Sleep(3000);
                var gridlist = webElementAction.GetElementById("MacroList-gridId");
                var selectRow = gridlist.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _MacroEntity.Keyword.Trim());
                webElementAction.DoubleClick(selectRow);

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridlist.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _MacroEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnMacro()
    {
        TestInitialize(nameof(CardViewBtnMacro));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Macro");
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
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("FileMaintenance", "Macro");
                RefreshRecordDataInGrid("MacroList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}