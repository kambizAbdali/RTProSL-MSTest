//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.LaborSpaceScheduling.Table;

// define class strct SpaceType
public class SpaceTypeEntity
{

    [ValidationElementProperty("id")]
    public string Code { set; get; }

    public string Description { set; get; }

}






[TestCategory("LaborSpaceScheduling")]
[TestClass, TestCategory("LaborSpaceScheduling___Table")]
public class SpaceType : BaseClass
{
    // new struct SpaceTypeEntity
    private SpaceTypeEntity _SpaceTypeEntity;

    public void AddSpaceTypeFunc()
    {
        _SpaceTypeEntity = new SpaceTypeEntity();

        GoToUrl("LaborSpaceScheduling", "SpaceType");
        // click on btn add in page SpaceType Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        webElementAction.ClearInputValuesInContext(GetFormLeftSideContext());

        // data insert to feilds in page Occupation  Entry Screen whith radnom data
        new WebElementDataGenerator(GetFormLeftSideContext());

        _SpaceTypeEntity = new SpaceTypeEntity();

        CreateAdd(_SpaceTypeEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }



    private void ValidateInsertSpaceTypeFunc()
    {
        ShowAllRedord();

        SearchAndEditClick(_SpaceTypeEntity.Code);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //ValidateInsertedDepartment();
        CreateValidation(_SpaceTypeEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddSpaceType()
    {
        TestInitialize(nameof(AddSpaceType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpaceTypeFunc();
                ValidateInsertSpaceTypeFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }



    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSpaceType()
    {
        TestInitialize(nameof(DeleteSpaceType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Space add 
                AddSpaceTypeFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_SpaceTypeEntity.Code, "SpaceTypeList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckSpaceType()
    {
        TestInitialize(nameof(ArrowNextBtnCheckSpaceType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _SpaceTypeEntity = new SpaceTypeEntity();

                GoToUrl("LaborSpaceScheduling", "SpaceType");
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
    public void ArrowPreviousBtnCheckSpaceType()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckSpaceType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "SpaceType");
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
    public void ArrowFirstBtnCheckSpaceType()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckSpaceType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "SpaceType");
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
    public void ArrowLastBtnCheckSpaceType()
    {
        TestInitialize(nameof(ArrowLastBtnCheckSpaceType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "SpaceType");
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
    public void EditBtnSpaceType()
    {
        TestInitialize(nameof(EditBtnSpaceType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "SpaceType");
                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Occupation Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                _SpaceTypeEntity = new SpaceTypeEntity();

                CreateAdd(_SpaceTypeEntity);
                //click on save And Close Btn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertSpaceTypeFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckSpaceType()
    {
        TestInitialize(nameof(ListViewtBtnCheckSpaceType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "SpaceType");
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
    public void CardViewBtnCheckSpaceType()
    {
        TestInitialize(nameof(CardViewBtnCheckSpaceType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "SpaceType");
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
    public void DetailValidateSpaceType()
    {
        TestInitialize(nameof(DetailValidateSpaceType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddSpaceTypeFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_SpaceTypeEntity.Code.Trim());
                Thread.Sleep(4000);

                var gridList = webElementAction.GetElementById("SpaceTypeList-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _SpaceTypeEntity.Code.Trim()).Click();

                ChangeScreenPageSize(20);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
                CreateValidationInGrid(colIds, _SpaceTypeEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInSpaceType()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInSpaceType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "LaborSpaceScheduling", subMenu: "SpaceType", filed: "description");
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
                GoToUrl("LaborSpaceScheduling", "SpaceType");
                RefreshRecordDataInGrid("SpaceTypeList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}