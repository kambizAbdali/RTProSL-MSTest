using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.AccountsReceivable.AR;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.Administration.Tables;
//developed by kambiz Abdali

public class MasterEntity
{
    public string Description { set; get; }

    [ValidationElementProperty("id")] public string Code { set; get; }
}

[TestCategory("Administration")]
[TestClass, TestCategory("Administration___Tables")]

public class Master : BaseClass
{
    private MasterEntity _MasterEntity;

    public void AddMasterFunc()
    {
        GoToUrl("Administration", "Master");
        _MasterEntity = new MasterEntity();
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        var context = GetFormLeftSideContext();
        new WebElementDataGenerator(context);

        _MasterEntity.Code = webElementAction.GetElementByName("id").GetAttribute("value");
        _MasterEntity.Description = webElementAction.GetInputElementByDataFormItemNameInDiv("description")
            .GetAttribute("value");
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidationInsertMasterFunc()
    {
        ShowAllRedord();
        Thread.Sleep(700);
        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _MasterEntity.Code.Trim());

        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();

        Thread.Sleep(3000);

        CreateValidation(_MasterEntity);
    }

    [TestMethod, Timeout(MaximumExecutionTime), TestCategory("Administration")]
    public void AddMaster()
    {
        TestInitialize(nameof(AddMaster));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _MasterEntity = new MasterEntity();
                AddMasterFunc();

                SearchTextInMainGrid(_MasterEntity.Code.Trim());

                ValidationInsertMasterFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditBtnMaster()
    {
        TestInitialize(nameof(EditBtnMaster));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Master");
                _MasterEntity = new MasterEntity();
                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);


                // read and write data in struct
                _MasterEntity.Code =
                    webElementAction.GetInputElementByDataFormItemNameInDiv("id").GetAttribute("value");
                _MasterEntity.Description = webElementAction.GetElementByName("description").GetAttribute("value");

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                SearchTextInMainGrid(_MasterEntity.Code.Trim());

                Thread.Sleep(700);

                var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _MasterEntity.Code.Trim());
                webElementAction.DoubleClick(selectRow);

                Thread.Sleep(500);

                //click on edit btn
                var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
                editUserBtn.Click();
                Thread.Sleep(3000);

                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                //call method validateInsertedUserInGridList


                CreateValidation(_MasterEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteMaster()
    {
        TestInitialize(nameof(DeleteMaster));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddMasterFunc();
                Delete(_MasterEntity.Code, "MasterList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    public void ScrollTo(int xPosition = 0, int yPosition = 0)
    {
        var js = $"window.scrollTo({xPosition}, {yPosition})"; //  String.Format("") equals $
        JavaScriptExecutor.ExecuteScript(js);
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInMaster()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInMaster));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Master");
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInMaster()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInMaster));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Master");
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInMaster()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInMaster));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Master");
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInMaster()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInMaster));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Master");
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInMaster()
    {
        TestInitialize(nameof(ListViewBtnCheckInMaster));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Master");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInMaster()
    {
        TestInitialize(nameof(CardViewBtnCheckInMaster));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Master");
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateMaster()
    {
        TestInitialize(nameof(DetailValidateMaster));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddMasterFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_MasterEntity.Code.Trim());

                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("MasterList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _MasterEntity.Code.Trim()).Click();

                ChangeScreenPageSize(10);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _MasterEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInMaster()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInMaster));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "Administration", subMenu: "Master", filed: "description");
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
                GoToUrl("Administration", "Master");
                RefreshRecordDataInGrid("MasterList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}