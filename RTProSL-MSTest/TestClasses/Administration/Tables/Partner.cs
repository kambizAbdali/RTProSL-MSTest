//developed by Mohammad_Keshavarz
// Prerequisite: The "Use Partner" checkbox must be checked in the system setup.

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.ComponentHelper.Validation;
//using RTProSL_Test.TestClasses.Administration.Tables;
using SeleniumWebdriver.Settings;

namespace RTProSL_MSTest.TestClasses.Administration.Tables;

// define strct Partner
public class PartnerEntity
{
    [ValidationIgnore]
    [ValidationElementProperty("id")] public string PartnerCode { set; get; }

    [ValidationElementProperty("name")] public string PartnerName { set; get; }

    [ValidationElementProperty("addressLine1")]
    public string Address1 { set; get; }

    [ValidationElementProperty("addressLine2")]
    public string Address2 { set; get; }

    [ValidationElementProperty("addressLine2B")] public string addressAddress3 { set; get; }

    [ValidationElementProperty("addressLine3")] public string Address4 { set; get; }

    [ValidationElementProperty("addressLine4")] public string Address5 { set; get; }

    [ValidationElementProperty("rentalPct")]
    public string Rental { set; get; }

    [ValidationElementProperty("salesPct")] public string Sale { set; get; }

    [ValidationElementProperty("subrentalPct")] public string Subrental { set; get; }

    [ValidationElementProperty("phone")] public string Phone { set; get; }

    [ValidationElementProperty("email")] public string Email { set; get; }

    [ValidationDataType(DataType.CheckBox)]
    [ValidationElementProperty("inactive")] public bool InActive { get; set; }

}

[TestCategory("Administration")]
[TestClass, TestCategory("Administration___Tables")]
public class Partner : BaseClass
{
    // new struct PartnerEntity
    private PartnerEntity _PartnerEntity;

    // Prerequisite: The "Use Partner" checkbox must be checked in the system setup.
    public void AddPartnerPageFunc()
    {
        _PartnerEntity = new PartnerEntity();
        GoToUrl("Administration", "Partner");

        // click on btn add in page Partner Entry Screen
        webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
        // genarated data random in fields 
        new WebElementDataGenerator(GetFormLeftSideContext(true));

        CreateAdd(_PartnerEntity);
        //click on saveAndCloseBtn and check confirm
        SaveAndConfirmCheck();
    }

    private void ValidateInsertedPartner()
    {
        ShowAllRedord();

        SearchTextInMainGrid(_PartnerEntity.PartnerCode.Trim());

        Thread.Sleep(700);

        var selectRow = ObjectRepository.Driver.FindElements(By.TagName("div"))
            .FirstOrDefault(o => o.Text == _PartnerEntity.PartnerCode.Trim());
        webElementAction.DoubleClick(selectRow);

        Thread.Sleep(500);

        //click on edit btn
        var editUserBtn = webElementAction.GetAllElementBySpecificAttribute("id", "TOOL_BOX_EDIT_BUTTON_ID")[1];
        editUserBtn.Click();
        Thread.Sleep(3000);

        // moghayese
        CreateValidation(_PartnerEntity);
    }

    // Prerequisite: The "Use Partner" checkbox must be checked in the system setup.
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddPartner()
    {
        TestInitialize(nameof(AddPartner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddPartnerPageFunc();
                ValidateInsertedPartner();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    // Prerequisite: The "Use Partner" checkbox must be checked in the system setup.
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeletePartner()
    {
        TestInitialize(nameof(DeletePartner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Partner add 
                AddPartnerPageFunc();
                ShowAllRedord();
                // call delete method from base class 
                Delete(_PartnerEntity.PartnerCode, "PartnerList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckPartner()
    {
        TestInitialize(nameof(ArrowNextBtnCheckPartner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // navigate 
                GoToUrl("Administration", "Partner");
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
    public void ArrowPreviousBtnCheckPartner()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckPartner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //call Login Method
                GoToUrl("Administration", "Partner");
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
    public void ArrowFirstBtnCheckPartner()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckPartner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Partner page 
                _PartnerEntity = new PartnerEntity();
                GoToUrl("Administration", "Partner");
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
    public void ArrowLastBtnCheckPartner()
    {
        TestInitialize(nameof(ArrowLastBtnCheckPartner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Partner page 
                GoToUrl("Administration", "Partner");
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

    // Prerequisite: The "Use Partner" checkbox must be checked in the system setup.
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditPartner()
    {
        TestInitialize(nameof(EditPartner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                _PartnerEntity = new PartnerEntity();
                GoToUrl("Administration", "Partner");
                ListViewBtnValidate();
                ShowAllRedord();
                Thread.Sleep(3000);

                // click on btn edit 
                webElementAction.GetElementById("TOOL_BOX_EDIT_BUTTON_ID").Click();

                // define context page to variable
                var context = webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide");

                //cleare all fields in context page 
                webElementAction.ClearInputValuesInContext(context);

                // data insert to feilds in page Partner Entry Screen whith radnom data
                var webElementDataGenerator = new WebElementDataGenerator(context);


                CreateAdd(_PartnerEntity);
                //click on saveAndCloseBtn and check confirm
                SaveAndConfirmCheck();

                ValidateInsertedPartner();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void InactiveBtnCheckPartner()
    {
        TestInitialize(nameof(InactiveBtnCheckPartner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Partner");

                InActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ActiveBtnCheckPartner()
    {
        TestInitialize(nameof(ActiveBtnCheckPartner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Partner page 
                GoToUrl("Administration", "Partner");

                ActiveBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckPartner()
    {
        TestInitialize(nameof(ListViewtBtnCheckPartner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Partner page 
                GoToUrl("Administration", "Partner");
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
    public void CardViewBtnCheckPartner()
    {
        TestInitialize(nameof(CardViewBtnCheckPartner));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Partner");
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
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Administration", "Partner");
                RefreshRecordDataInGrid("PartnerList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

}