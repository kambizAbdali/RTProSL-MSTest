//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.LaborSpaceScheduling.Table;

// define class strct SpaceHoldStatus
public class SpaceHoldStatusEntity
{

    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }

    [ValidationDataType(DataType.Color)]
    public string Color { set; get; }

    [ValidationElementProperty("inactive")]
    [ValidationDataType(DataType.CheckBox)]
    public bool Inactive { set; get; }
}






[TestCategory("LaborSpaceScheduling")]
[TestClass, TestCategory("LaborSpaceScheduling___Table")]
public class SpaceHoldStatus : BaseClass
{
    // new struct SpaceHoldStatus Entity
    private SpaceHoldStatusEntity _SpaceHoldStatusEntity;

    public void AddSpaceHoldStatusFunc()
    {
        _SpaceHoldStatusEntity = new SpaceHoldStatusEntity();

        GoToUrl("LaborSpaceScheduling", "SpaceHoldStatus");

        // click on btn add in pageSpaceHoldStatus Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        webElementAction.ClearInputValuesInContext(GetFormLeftSideContext());

        // data insert to feilds in page Occupation  Entry Screen whith radnom data
        var webElementDataGenerator = new WebElementDataGenerator(GetFormLeftSideContext());

        _SpaceHoldStatusEntity = new SpaceHoldStatusEntity();

        CreateAdd(_SpaceHoldStatusEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertSpaceHoldStatusFunc()
    {
        ShowAllRedord();
        SearchAndEditClick(_SpaceHoldStatusEntity.Code);
        CreateValidation(_SpaceHoldStatusEntity);
    }

    [TestMethod, Timeout(MaximumExecutionTime * 4)]
    public void AddSpaceHoldStatus()
    {
        TestInitialize(nameof(AddSpaceHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpaceHoldStatusFunc();
                ValidateInsertSpaceHoldStatusFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSpaceHoldStatus()
    {
        TestInitialize(nameof(DeleteSpaceHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Space add 
                AddSpaceHoldStatusFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_SpaceHoldStatusEntity.Code, "SpaceHoldStatusList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckSpaceHoldStatus()
    {
        TestInitialize(nameof(ArrowNextBtnCheckSpaceHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "SpaceHoldStatus");
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
    public void ArrowPreviousBtnCheckSpaceHoldStatus()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckSpaceHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "SpaceHoldStatus");
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
    public void ArrowFirstBtnCheckSpaceHoldStatus()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckSpaceHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "SpaceHoldStatus");
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
    public void ArrowLastBtnCheckSpaceHoldStatus()
    {
        TestInitialize(nameof(ArrowLastBtnCheckSpaceHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "SpaceHoldStatus");
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
    public void EditBtnSpaceHoldStatus()
    {
        TestInitialize(nameof(EditBtnSpaceHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _SpaceHoldStatusEntity = new SpaceHoldStatusEntity();

                GoToUrl("LaborSpaceScheduling", "SpaceHoldStatus");
                ShowAllRedord();
                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Occupation Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_SpaceHoldStatusEntity);
                //click on save And Close Btn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertSpaceHoldStatusFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckSpaceHoldStatus()
    {
        TestInitialize(nameof(ListViewtBtnCheckSpaceHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "SpaceHoldStatus");
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
    public void CardViewBtnCheckSpaceHoldStatus()
    {
        TestInitialize(nameof(CardViewBtnCheckSpaceHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "SpaceHoldStatus");
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
    public void DetailValidateSpaceHoldStatus()
    {
        TestInitialize(nameof(DetailValidateSpaceHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpaceHoldStatusFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_SpaceHoldStatusEntity.Code.Trim());
                Thread.Sleep(4000);

                var gridList = webElementAction.GetElementById("SpaceHoldStatusList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _SpaceHoldStatusEntity.Code.Trim()).Click();

                ChangeScreenPageSize(20);

                var colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                CreateValidationInGrid(colIds, _SpaceHoldStatusEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInSpaceHoldStatus()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSpaceHoldStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "LaborSpaceScheduling", subMenu: "SpaceHoldStatus", filed: "description");
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
                GoToUrl("LaborSpaceScheduling", "SpaceHoldStatus");
                RefreshRecordDataInGrid("SpaceHoldStatusList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}