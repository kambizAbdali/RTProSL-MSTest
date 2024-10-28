//developed by Mohammad_Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.Administration.Security_Setup;
using System.Collections.ObjectModel;

namespace RTProSL_MSTest.TestClasses.Administration.Tables;

// define strct
// 
public class ContactEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")]
    public string ContactCode { set; get; }

    [ValidationElementProperty("name")]
    public string ContactName { set; get; }

    [ValidationElementProperty("title")] public string ContactTitle { set; get; }

    public string Phone { set; get; }

    public string Fax { set; get; }

    public string CellPhone { set; get; }

    public string Email { set; get; }

    public string Pager { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    public bool EmailInclude { set; get; }


    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")]
    public bool InActive { get; set; }

    [ValidationElementProperty("addressLine1")]
    public string Address1 { set; get; }

    [ValidationElementProperty("addressLine2")]
    public string Address2 { set; get; }

    [ValidationElementProperty("addressLine2B")]
    public string Address3 { set; get; }

    [ValidationElementProperty("addressLine3")]
    public string City { set; get; }


    public string State { set; get; }

    public string ZipCode { set; get; }

    [ValidationElementProperty("addressLine4")]
    public string addressLine4 { set; get; }

    [ValidationDataType(DataType.TextArea)]
    public string Notes { set; get; }
}

[TestCategory("Administration")]
[TestClass, TestCategory("Administration___Tables")]
public class Contact : BaseClass
{
    // new struct ContactEntity
    private ContactEntity _ContactEntity;

    public void AddContactPageFunc()
    {
        _ContactEntity = new ContactEntity();
        GoToUrl("Administration", "Contact");
        ShowAllRedord();
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        // genarated data random in fields 
        new WebElementDataGenerator(GetFormLeftSideContext());

        CreateAdd(_ContactEntity);

        // click on btn save and close
        SaveAndConfirmCheck();
    }

    private void ValidateInsertedContactFunc()
    {
        ListViewBtnValidate();
        ShowAllRedord();
        Thread.Sleep(1000);

        var gridContext = webElementAction.GetElementById("ContactList-gridId");
        if (_ContactEntity.ContactCode != string.Empty)
        {
            SearchTextInMainGrid(_ContactEntity.ContactCode.Trim());
            Thread.Sleep(700);
            var selectRow = gridContext.FindElements(By.TagName("div"))
                .FirstOrDefault(o => o.Text == _ContactEntity.ContactCode.Trim());

            webElementAction.DoubleClick(selectRow);
        }
        else
        {
            SearchTextInMainGrid(_ContactEntity.ContactTitle.Trim());

            Thread.Sleep(18000);
            var selectRow = gridContext.FindElements(By.TagName("div"))
                .FirstOrDefault(o => o.Text == _ContactEntity.ContactTitle.Trim());
            webElementAction.DoubleClick(selectRow);
        }

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(1000);

        if (_ContactEntity.ContactCode == string.Empty) IsElementPresentList.Add(_ContactEntity.ContactCode);
        CreateValidation(_ContactEntity);
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddContact()
    {
        TestInitialize(nameof(AddContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddContactPageFunc();
                ValidateInsertedContactFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteContact()
    {
        TestInitialize(nameof(DeleteContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Contact add 
                AddContactPageFunc();
                ShowAllRedord();
                if (_ContactEntity.ContactCode != string.Empty)
                    Delete(_ContactEntity.ContactCode, "ContactList-gridId");
                else
                    Delete(_ContactEntity.ContactTitle, "ContactList-gridId");

                // call delete method from base class 

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInContact()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // navigate 
                GoToUrl("Administration", "Contact");
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
    public void ArrowPreviousBtnCheckInContact()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Salesperson page 
                GoToUrl("Administration", "Contact");
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
    public void ArrowFirstBtnCheckInContact()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Salesperson page 
                GoToUrl("Administration", "Contact");
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
    public void ArrowLastBtnCheckInContact()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Contact page 
                GoToUrl("Administration", "Contact");
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
    public void EditBtnContact()
    {
        TestInitialize(nameof(EditBtnContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _ContactEntity = new ContactEntity();
                //navigate to Salesperson page 
                GoToUrl("Administration", "Contact");

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Rental Agent Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);

                CreateAdd(_ContactEntity);

                Thread.Sleep(1000);

                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertedContactFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void InactiveBtnCheckContact()
    {
        TestInitialize(nameof(InactiveBtnCheckContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to ContactEntity page 
                GoToUrl("Administration", "Contact");

                InActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ActiveBtnCheckContact()
    {
        TestInitialize(nameof(ActiveBtnCheckContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Contact");

                ActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckContact()
    {
        TestInitialize(nameof(ListViewtBtnCheckContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Salesperson page 
                GoToUrl("Administration", "Contact");
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
    public void ThumbnailViewBtnCheckContact()
    {
        TestInitialize(nameof(ThumbnailViewBtnCheckContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Salesperson page 
                GoToUrl("Administration", "Contact");

                //call thumbnailViewBtn 
                ThumbnailViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckContact()
    {
        TestInitialize(nameof(CardViewBtnCheckContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Salesperson page 
                GoToUrl("Administration", "Contact");
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
    public void DetailValidateContact()
    {
        TestInitialize(nameof(DetailValidateContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddContactPageFunc();
                ListViewBtnValidate();
                ShowAllRedord();

                SearchTextInMainGrid(_ContactEntity.ContactName.Trim());
                Thread.Sleep(3000);

                var gridList = webElementAction.GetElementById("ContactList-gridId");

                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _ContactEntity.ContactName.Trim()).Click();

                ChangeScreenPageSize(45);

                Thread.Sleep(5000);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _ContactEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInContact()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInContact));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "Administration", subMenu: "Contact", filed: "phone");
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
                GoToUrl("Administration", "Contact");
                RefreshRecordDataInGrid("ContactList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrintMailingLabelsReport()
    {
        TestInitialize(nameof(ValidatePrintMailingLabelsReport));
        while (!testPassed && retryCount < maxRetries)
        {
            try
            {
                GoToUrl("Administration", "Contact");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReportSubMenu(menu: "PRINT", subMenu: "PRINT_MAILING_LABELS");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
        }
    }
}