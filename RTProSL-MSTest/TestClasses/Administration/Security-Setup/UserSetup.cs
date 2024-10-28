using MSTestProject.ComponentHelper;
using NUnit.Framework;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
using Assert = NUnit.Framework.Assert;
using TimeoutAttribute = Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute;

namespace RTProSL_MSTest.TestClasses.Administration.Security_Setup;
//developed by kambiz Abdali

public class UserEntity
{
    public UserEntity()
    {
        GeneralTab = new GeneralTab();
    }

    [ValidationIgnoreInGridAttribute]
    [ValidationElementName("User Code")]
    public string Id { get; set; }

    [ValidationIgnoreInGridAttribute]
    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    public string Password { get; set; }

    [ValidationColID("name")]
    [ValidationElementProperty("name")]
    public string UserName { get; set; }

    [ValidationElementProperty("inactive")]
    [ValidationDataType(DataType.CheckBox)]
    public bool InActive { get; set; }

    [ValidationElementProperty("isProfile")]
    [ValidationDataType(DataType.CheckBox)]
    public bool Profile { get; set; }

    [ValidationTabClick("GENERAL")] public GeneralTab GeneralTab { set; get; }

    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationColID("defaultDepartment")]
    public string FirstItemSelectedInPermittedDepartment { get; set; }

    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationColID("defaultLocation")]
    public string FirstItemSelectedInPermittedLocation { get; set; }
}

public class GeneralTab
{
    public string Email { get; set; }
    public string EmployeeId { get; set; }

    [ValidationElementProperty("salespersonId")]
    public string Salesperson { get; set; }

    [ValidationElementProperty("rentalAgentId")]
    public string RentalAgent { get; set; }


    [ValidationElementProperty("languageId")]

    public string Language { get; set; }

    [ValidationElementProperty("managingDepartmentId")]
    public string ManagingDept { get; set; }

    [ValidationElementProperty("minDaysPerWeek")]
    public string MinimumDaysPerWeek { get; set; }

    [ValidationElementProperty("maxRentalsDisc")]
    public string MaximumRentalDisc { get; set; }

    [ValidationElementProperty("maxRentalsDisc")]
    public string MaximumSalesDisc { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    public bool AutoLogout { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    public bool ReadOnly { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("receiveMessages")]
    public bool SendRecieveMessages { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("doNotDefaultLocationOnLookups")]
    public bool DoNotDefaultOverLocationOnLookups { get; set; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("forcePWChange")]
    public bool ForcePasswordChange { get; set; }

    [ValidationElementProperty("remote")]
    [ValidationDataType(DataType.CheckBox)]
    public bool ForceLoginAsRemoteUser { get; set; }

    [ValidationElementProperty("viewOtherRentalAgentDashboard")]
    [ValidationDataType(DataType.CheckBox)]
    public bool ViewOtherRentalAgentDataOnDashboard { get; set; }

    [ValidationElementProperty("viewOtherSalespersonDashboard")]
    [ValidationDataType(DataType.CheckBox)]
    public bool ViewOtherSalespersonsDataOnDashboard { get; set; }

    [ValidationElementProperty("isSupervisor")]
    [ValidationDataType(DataType.CheckBox)]
    public bool Supervisor { get; set; }
}

[TestCategory("Administration")]
[TestClass, TestCategory("Administration___SecuritySetup")]

public class UserSetup : BaseClass
{
    private UserEntity _userEntity;

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddUserWithAllFields()
    {
        TestInitialize(nameof(AddUserWithAllFields));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddUserFunc();
                UserEntryScreenValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    public void AddUserFunc()
    {
        _userEntity = new UserEntity();
        GoToUrl("Administration", "UserSetup");
        //click on addNewRecordBtn
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));

        var context = webElementAction.GetElementByCssSelector(".enormous-left-section > .row-division");

        new WebElementDataGenerator(context);

        webElementAction.GetInputElementByDataFormItemNameInDiv("isProfile", context).Click();

        _userEntity = new UserEntity();
        addDepartmentAndLocation();
        CreateAdd(_userEntity);

        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void addDepartmentAndLocation()
    {

        ClickTab("DEPARTMENT");

        var addFirstRowInDepartmentList =
            webElementAction.GetAllElementBySpecificAttribute("data-icon-name", "arrow-right")[0];
        addFirstRowInDepartmentList.Click();


        var FirstItemSelectedInDepartmentList =
            ObjectRepository.Driver.FindElement(By.Id("SelectedMultiSelectdepartmentListColumnStateName-gridId"))
                .FindElements(By.CssSelector("[col-id='id'][role='gridcell']"))[0].Text;
        _userEntity.FirstItemSelectedInPermittedDepartment = FirstItemSelectedInDepartmentList;


        var LocationTab = webElementAction
            .GetAllElementBySpecificAttribute("type", "button")
            .FirstOrDefault(o => o.GetAttribute("data-tab-name") == "LOCATION");
        if (LocationTab != null)
        {
            LocationTab.Click();

            //click on addFirstRowInlocationList
            var addFirstRowInLocationList =
                webElementAction.GetAllElementBySpecificAttribute("data-icon-name", "arrow-right")[1];
            addFirstRowInLocationList.Click();

            var FirstItemSelectedInLocationList =
                ObjectRepository.Driver.FindElement(By.Id("SelectedMultiSelectlocationListColumnStateName-gridId"))
                    .FindElements(By.CssSelector("[col-id='id'][role='gridcell']"))[0].Text;

            //click on firstItemSelectedInPermittedLocation
            _userEntity.FirstItemSelectedInPermittedLocation = FirstItemSelectedInLocationList;
        }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteUser()
    {
        TestInitialize(nameof(DeleteUser));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddUserFunc();
                ShowAllRedord();
                Delete(_userEntity.Id, "UserSetup-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInUserSetup()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInUserSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _userEntity = new UserEntity();
                GoToUrl("Administration", "UserSetup");
                ShowAllRedord();
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInUserSetup()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInUserSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "UserSetup");
                ShowAllRedord();
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckInUserSetup()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInUserSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "UserSetup");
                ShowAllRedord();
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInUserSetup()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInUserSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "UserSetup");
                ShowAllRedord();
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewBtnCheckInUserSetup()
    {
        TestInitialize(nameof(ListViewBtnCheckInUserSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "UserSetup");
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ThumbnailViewBtnCheckInUserSetup()
    {
        TestInitialize(nameof(ThumbnailViewBtnCheckInUserSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "UserSetup");
                ShowAllRedord();
                ThumbnailViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInUserSetup()
    {
        TestInitialize(nameof(CardViewBtnCheckInUserSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "UserSetup");
                ShowAllRedord();
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DetailValidateUser()
    {
        TestInitialize(nameof(DetailValidateUser));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddUserFunc();
                ListViewBtnValidate();
                ShowAllRedord();
                SearchTextInMainGrid(_userEntity.Id.Trim());
                var gridList = webElementAction.GetElementById("UserSetup-gridId");
                gridList.FindElements(By.TagName("div"))
                    .FirstOrDefault(o => o.Text == _userEntity.Id.Trim()).Click();
                ChangeScreenPageSize(45);
                Thread.Sleep(3000);

                ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));

                CreateValidationInGrid(colIds, _userEntity);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    public void UserEntryScreenValidate()
    {
        ShowAllRedord();

        SearchAndEditClick(_userEntity.Id.Trim());

        ClickTab("DEPARTMENT");

        ChangeScreenPageSize(65);
        webElementAction.ValidateDefaultSelectedValueInGrid(_userEntity.FirstItemSelectedInPermittedDepartment,
            "Department", "Department Grid", "SelectedMultiSelectdepartmentListColumnStateName-gridId");

        var LocationTab = webElementAction
            .GetAllElementBySpecificAttribute("type", "button")
            .FirstOrDefault(o => o.GetAttribute("data-tab-name") == "LOCATION");
        if (LocationTab != null)
        {
            ChangeScreenPageSize(100);
            LocationTab.Click();
            webElementAction.ValidateDefaultSelectedValueInGrid(_userEntity.FirstItemSelectedInPermittedLocation,
                "Location", "Location Grid", "SelectedMultiSelectlocationListColumnStateName-gridId");
        }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditUser()
    {
        TestInitialize(nameof(EditUser));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _userEntity = new UserEntity();
                //navigate to Salesperson page 
                GoToUrl("Administration", "UserSetup");

                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide")
                    .FindElements(By.TagName("div")).FirstOrDefault();

                //clear all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Partner Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);
                CreateAdd(_userEntity);
                addDepartmentAndLocation();
                //click on saveAndCloseBtn inAddUserSection
                SaveAndConfirmCheck();
                UserEntryScreenValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRequiredFieldsMessageBoxInUserSetup()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInUserSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                ValidateRequiredFieldsMessage validateRequiredFields;
                validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "Administration", subMenu: "UserSetup", filed: "name");
                validateRequiredFields.Run();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ForcePasswordChange()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInUserSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // Initialize the test for ForcePasswordChange
                TestInitialize(nameof(ForcePasswordChange));

                // Navigate to Administration UserSetup page
                GoToUrl("Administration", "UserSetup");

                // Get the first user name from the grid
                string firstUserName = webElementAction.GetAllElementsByCssSelector("[col-id='id']").Skip(1).First().Text;

                // Search for the user and click on edit
                SearchAndEditClick(firstUserName);

                // Select the force password change checkbox
                webElementAction.SelectingCheckbox("forcePWChange");

                // Enter a temporary password
                webElementAction.GetInputElementByDataFormItemNameInDiv("password").SendKeys("hd");

                // Deselect the inactive checkbox
                webElementAction.DeSelectingCheckbox("inactive");

                // Save the changes and confirm
                SaveAndConfirmCheck();

                // Sign out from current user session
                SignOut();

                // Login with the user that needs to change the password
                Login(username: firstUserName, password: "hd");

                // Wait for a message indicating password change required
                Thread.Sleep(1000);
                ConfirmBtnCheck(dataSection: "errorDialog"); // Error: Password should be changed

                // Confirm the warning message for password change
                Thread.Sleep(2000);
                ConfirmBtnCheck(dataSection: "alertDialog"); // Warning: You are required to change your password. Press OK to go to the Password Change Screen
                Thread.Sleep(2000);

                // Generate a random new password for the user
                var newPassword = RandomValueGenerator.GenerateRandomString(4);

                // Enter the new password in the "newPassword" and "confirmPassword" fields
                webElementAction.GetElementByCssSelector("[name=newPassword]").SendKeys(newPassword);
                webElementAction.GetElementByCssSelector("[name=confirmPassword]").SendKeys(newPassword);

                Thread.Sleep(3000);

                // Click on the reCaptcha frame
                var reCaptchaFrame = webElementAction.GetElementByXPath("//iframe[starts-with(@name, 'a-') and starts-with(@src, 'https://www.google.com/recaptcha')]");

                reCaptchaFrame.Click();
                Thread.Sleep(3000);
                // Confirm the action in the modal
                ConfirmBtnCheck(dataSection: "modal");

                // Click on the login button to complete the password change process
                webElementAction.GetElementByCssSelector("[data-button-type='login']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateHyperlinkInForgotPasswordChangePage()
    {
        TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInUserSetup));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AppConfigIntialize();
                webElementAction = new WebElementAction();
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

                //click on forgot password
                webElementAction.Click(By.XPath("//span[.='Forgot Your Password?']"));

                if (!webElementAction.IsElementPresent(By.XPath("//a[contains(.,'RTPro support')]"))
                    || !webElementAction.IsElementPresent(By.CssSelector(".custom-modal-container")))
                {
                    Assert.Fail("Error:_____ Hyperlink in forgot password modal does not exist.");
                }

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
                GoToUrl("Administration", "UserSetup");
                RefreshRecordDataInGrid("UserSetup-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrintSecurityReport()
    {
        TestInitialize(nameof(ValidatePrintSecurityReport));
        while (!testPassed && retryCount < maxRetries)
        {
            try
            {
                GoToUrl("Administration", "UserSetup");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReportSubMenu(menu: "USER_SETUP_VIEW_DROP_DOWN", subMenu: "PRINT_SECURITY");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
        }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrintPermittedLocationDepartmentReport()
    {
        TestInitialize(nameof(ValidatePrintPermittedLocationDepartmentReport));
        while (!testPassed && retryCount < maxRetries)
        {
            try
            {
                GoToUrl("Administration", "UserSetup");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                if (CurrentUrlIsMultiLocation())
                    report.ValidateReportSubMenu(menu: "USER_SETUP_VIEW_DROP_DOWN", subMenu: "PRINT_PERMITTED_LOC_DEP");
                else
                    report.ValidateReportSubMenu(menu: "USER_SETUP_VIEW_DROP_DOWN", subMenu: "PRINT_PERMITTED_DEP");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
        }
    }
}