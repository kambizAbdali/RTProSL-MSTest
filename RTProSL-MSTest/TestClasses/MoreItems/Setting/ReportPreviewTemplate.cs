// Developed By Parsa Zakeri

using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.MoreItems.Setting;

public class ReportHeaderEntity
{
    [ValidationElementProperty("reportHeaderBackgroundStyle")]
    [ValidationDataType(DataType.Color)]
    public string BackgroundColor { get; set; }
}

public class BaseEntity
{
    [ValidationElementProperty("FONT_NAME")]
    [ValidationDataType(DataType.DropDown)]
    public string FontName { get; set; }

    [ValidationElementProperty("FONT_STYLE")]
    [ValidationDataType(DataType.DropDown)]
    public string FontStyle { get; set; }

    [ValidationElementProperty("FONT_COLOR")]
    [ValidationDataType(DataType.Color)]
    public string FontColor { get; set; }

    [ValidationElementProperty("STRIKEOUT")]
    [ValidationDataType(DataType.CheckBox)]
    public string Strikeout { get; set; }

    [ValidationElementProperty("SIZE")]
    [ValidationDataType(DataType.Text)]
    public string Size { get; set; }

    [ValidationElementProperty("UNDERLINE")]
    [ValidationDataType(DataType.CheckBox)]
    public string Underline { get; set; }
}

public class CompanyNameEntity : BaseEntity { }
public class CompanyAddressEntity : BaseEntity { }
public class ReportNameEntity : BaseEntity { }
public class PageEntity : BaseEntity { }
public class DataTimesEntity : BaseEntity { }
public class ReportInfoEntity
{
    [ValidationElementProperty("reportInfoFontColor")]
    [ValidationDataType(DataType.Color)]
    public string FontColor { get; set; }
}
public class ColumnHeaderEntity : BaseEntity { }
public class GroupHeaderEntity : BaseEntity { }
//public class RowStyleEntity : BaseEntity { }
public class GroupFooterEntity : BaseEntity { }
public class FooterEntity : BaseEntity { }

[TestCategory("MoreItems")]
[TestClass, TestCategory("MoreItems___Setting")]
public class ReportPreviewTemplate : BaseClass
{
    private string templateValueElement;

    ReportHeaderEntity _ReportHeader;
    CompanyNameEntity _CompanyName;
    CompanyAddressEntity _CompanyAddress;
    ReportNameEntity _ReportName;
    PageEntity _Page;
    DataTimesEntity _DataTimes;
    ReportInfoEntity _ReportInfo;
    ColumnHeaderEntity _ColumnHeader;
    GroupHeaderEntity _GroupHeader;
    //RowStyleEntity _RowStyle;
    GroupFooterEntity _GroupFooter;
    FooterEntity _Footer;

    public enum TemplateOperationEnum
    {
        Add,
        Edit,
        Delete,
        Duplicate,
        SetAsDefaultForAllUser,
        SetAsDefaultForMe,
        TemplateSetting
    }
    Dictionary<TemplateOperationEnum, string> OperationTypeDict = new Dictionary<TemplateOperationEnum, string>()
    {
        { TemplateOperationEnum.Edit , "edit"},
        { TemplateOperationEnum.Delete , "delete"},
        { TemplateOperationEnum.Duplicate , "copy"},
        { TemplateOperationEnum.SetAsDefaultForAllUser ,"save-all"},
        { TemplateOperationEnum.SetAsDefaultForMe ,"save"},
        { TemplateOperationEnum.TemplateSetting , "setting-line"}
};

    public enum TreeMenuEnum
    {
        ReportHeader,
        CompanyName,
        CompanyAddress,
        ReportName,
        Page,
        DataTimes,
        ReportInfo,
        ColumnHeader,
        GroupHeader,
        //RowStyle,
        GroupFooter,
        Footer
    }
    Dictionary<TreeMenuEnum, string> TreeMenuDict = new Dictionary<TreeMenuEnum, string>()
    {
        { TreeMenuEnum.CompanyName ,"COMPANY_NAME"},
        { TreeMenuEnum.CompanyAddress ,"COMPANY_ADDRESS"},
        { TreeMenuEnum.ReportName ,"REPORT_NAME"},
        { TreeMenuEnum.Page ,"count"},
        { TreeMenuEnum.DataTimes,"report-scheduler" },
        { TreeMenuEnum.ReportInfo,"order-note" },
        { TreeMenuEnum.ColumnHeader,"column-title" },
        { TreeMenuEnum.GroupHeader,"group-column" },
        //{ MenuEnum.,"" }, //Row Style
        { TreeMenuEnum.GroupFooter,"group-footer" },
        { TreeMenuEnum.Footer,"show-footer" },
    };

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageReportPreviewTemplate()
    {
        TestInitialize(nameof(OpenPageReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");

                Thread.Sleep(1000);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddReportHeaderInReportPreviewTemplate()
    {
        TestInitialize(nameof(AddReportHeaderInReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.Page);

                ValidateReportPreviewTemplateFunc(TreeMenuEnum.Page);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddPageInReportPreviewTemplate()
    {
        TestInitialize(nameof(AddPageInReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.Page);

                ValidateReportPreviewTemplateFunc(TreeMenuEnum.Page);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddDataTimeInReportPreviewTemplate()
    {
        TestInitialize(nameof(AddDataTimeInReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.DataTimes);

                ValidateReportPreviewTemplateFunc(TreeMenuEnum.DataTimes);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddReportInfoInReportPreviewTemplate()
    {
        TestInitialize(nameof(AddReportInfoInReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.ReportInfo);

                ValidateReportPreviewTemplateFunc(TreeMenuEnum.ReportInfo);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddColumnHeaderInReportPreviewTemplate()
    {
        TestInitialize(nameof(AddColumnHeaderInReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.ColumnHeader);

                ValidateReportPreviewTemplateFunc(TreeMenuEnum.ColumnHeader);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddGroupHeaderInReportPreviewTemplate()
    {
        TestInitialize(nameof(AddGroupHeaderInReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.GroupHeader);

                ValidateReportPreviewTemplateFunc(TreeMenuEnum.GroupHeader);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddGroupFooterInReportPreviewTemplate()
    {
        TestInitialize(nameof(AddGroupFooterInReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.GroupFooter);

                ValidateReportPreviewTemplateFunc(TreeMenuEnum.GroupFooter);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddFooterInReportPreviewTemplate()
    {
        TestInitialize(nameof(AddFooterInReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.Footer);

                ValidateReportPreviewTemplateFunc(TreeMenuEnum.Footer);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddCompanyNameReportPreviewTemplate()
    {
        TestInitialize(nameof(AddCompanyNameReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.CompanyName);

                ValidateReportPreviewTemplateFunc(TreeMenuEnum.CompanyName);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddCompanyAddressReportPreviewTemplate()
    {
        TestInitialize(nameof(AddCompanyAddressReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.CompanyAddress);

                ValidateReportPreviewTemplateFunc(TreeMenuEnum.CompanyAddress);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddReportNameReportPreviewTemplate()
    {
        TestInitialize(nameof(AddReportNameReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.ReportName);

                ValidateReportPreviewTemplateFunc(TreeMenuEnum.ReportName);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditReportPreviewTemplate()
    {
        TestInitialize(nameof(EditReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.Page);

                ClickOnTemplateMenu(TemplateOperationEnum.Edit);

                AddOrEditFunc(TreeMenuEnum.Page, TemplateOperationEnum.Edit);

                ValidateReportPreviewTemplateFunc(TreeMenuEnum.Page);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteReportPreviewTemplate()
    {
        TestInitialize(nameof(DeleteReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.Page);

                ClickOnTemplateMenu(TemplateOperationEnum.Delete);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DuplicateTemplateReportPreviewTemplate()
    {
        TestInitialize(nameof(DuplicateTemplateReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                string oldNameTemplate = AddOrEditFunc(TreeMenuEnum.Page);

                ClickOnTemplateMenu(TemplateOperationEnum.Duplicate);

                SetTemplateNameInTemplateSettingModal(TreeMenuEnum.Page);

                ClickOnTemplateMenu(TemplateOperationEnum.Delete);

                FindTemplateMenuIsNotSelected(oldNameTemplate);

                ClickOnTemplateMenu(TemplateOperationEnum.Delete);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void TemplateSettingReportPreviewTemplate()
    {
        TestInitialize(nameof(TemplateSettingReportPreviewTemplate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MoreItems", "ReportPreviewTemplate");
                Thread.Sleep(1000);

                AddOrEditFunc(TreeMenuEnum.Page);

                ClickOnTemplateMenu(TemplateOperationEnum.TemplateSetting);

                SetTemplateNameInTemplateSettingModal(TreeMenuEnum.Page);

                ClickOnTemplateMenu(TemplateOperationEnum.Delete);

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private string AddOrEditFunc(TreeMenuEnum menu, TemplateOperationEnum type = TemplateOperationEnum.Add)
    {
        string nameTemplate = String.Empty;
        if (type == TemplateOperationEnum.Add)
        {
            webElementAction.Click(By.CssSelector("[data-icon-name='add']"));//add new template
            Thread.Sleep(2000);
            nameTemplate = SetTemplateNameInTemplateSettingModal(menu);
        }

        Thread.Sleep(2000);
        if (menu != TreeMenuEnum.ReportHeader)
            if (menu == TreeMenuEnum.CompanyName || menu == TreeMenuEnum.CompanyAddress || menu == TreeMenuEnum.ReportName)
                webElementAction.Click(By.CssSelector("[data-title='" + TreeMenuDict[menu] + "'] .ellipsis-content"));
            else
                webElementAction.Click(By.CssSelector("[data-icon-name='" + TreeMenuDict[menu] + "']"));

        new WebElementDataGenerator(webElementAction.GetElementBySpecificAttribute("data-section", "formLeftSide"));

        switch (menu)
        {
            case TreeMenuEnum.ReportHeader: _ReportHeader = new ReportHeaderEntity(); CreateAdd(_ReportHeader); break;

            case TreeMenuEnum.CompanyName: _CompanyName = new CompanyNameEntity(); CreateAdd(_CompanyName); break;

            case TreeMenuEnum.CompanyAddress: _CompanyAddress = new CompanyAddressEntity(); CreateAdd(_CompanyAddress); break;

            case TreeMenuEnum.ReportName: _ReportName = new ReportNameEntity(); CreateAdd(_ReportName); break;

            case TreeMenuEnum.Page: _Page = new PageEntity(); CreateAdd(_Page); break;

            case TreeMenuEnum.DataTimes: _DataTimes = new DataTimesEntity(); CreateAdd(_DataTimes); break;

            case TreeMenuEnum.ReportInfo: _ReportInfo = new ReportInfoEntity(); CreateAdd(_ReportInfo); break;

            case TreeMenuEnum.ColumnHeader: _ColumnHeader = new ColumnHeaderEntity(); CreateAdd(_ColumnHeader); break;

            case TreeMenuEnum.GroupHeader: _GroupHeader = new GroupHeaderEntity(); CreateAdd(_GroupHeader); break;

            case TreeMenuEnum.GroupFooter: _GroupFooter = new GroupFooterEntity(); CreateAdd(_GroupFooter); break;

            case TreeMenuEnum.Footer: _Footer = new FooterEntity(); CreateAdd(_Footer); break;
        }
        webElementAction.Click(By.Id("TOOL_BOX_SAVE_CHANGES_BUTTON_ID"));

        return nameTemplate;
    }

    private void ValidateReportPreviewTemplateFunc(TreeMenuEnum menu)
    {
        ClickOnTemplateMenu(TemplateOperationEnum.Edit);

        Thread.Sleep(2000);
        if (menu != TreeMenuEnum.ReportHeader)
            if (menu == TreeMenuEnum.CompanyName || menu == TreeMenuEnum.CompanyAddress || menu == TreeMenuEnum.ReportName)
                webElementAction.Click(By.CssSelector("[data-title='" + TreeMenuDict[menu] + "'] .ellipsis-content"));
            else
                webElementAction.Click(By.CssSelector("[data-icon-name='" + TreeMenuDict[menu] + "']"));

        switch (menu)
        {
            case TreeMenuEnum.ReportHeader: CreateValidation(_ReportHeader); break;

            case TreeMenuEnum.Page: CreateValidation(_Page); break;

            case TreeMenuEnum.DataTimes: CreateValidation(_DataTimes); break;

            case TreeMenuEnum.ReportInfo: CreateValidation(_ReportInfo); break;

            case TreeMenuEnum.ColumnHeader: CreateValidation(_ColumnHeader); break;

            case TreeMenuEnum.GroupHeader: CreateValidation(_GroupHeader); break;

            case TreeMenuEnum.GroupFooter: CreateValidation(_GroupFooter); break;

            case TreeMenuEnum.Footer: CreateValidation(_Footer); break;
        }
        webElementAction.Click(By.Id("TOOL_BOX_SAVE_CHANGES_BUTTON_ID"));
        Thread.Sleep(2000);
        ClickOnTemplateMenu(TemplateOperationEnum.Delete);
    }

    private void ClickOnTemplateMenu(TemplateOperationEnum type)
    {
        webElementAction.ScrolToLeft(".template-list");

        if (type == TemplateOperationEnum.Delete)
        {
            var cardElement = webElementAction.GetAllElementsByCssSelector("[class='template-item-card']")
                .FirstOrDefault(o => o.Text == templateValueElement);
            if (cardElement != null)
                cardElement.Click();
        }
        //find btn card selected and click 
        webElementAction.GetElementByCssSelector("[class='template-item-card selected']")
            .FindElements(By.TagName("i"))
            .FirstOrDefault(o => o.GetAttribute("data-icon-name") == "menu-kebab").Click();


        //find div menu and click in operation type
        webElementAction.GetElementByCssSelector(".ant-dropdown:not(.ant-dropdown-hidden)").FindElements(By.TagName("i"))
            .FirstOrDefault(o => o.GetAttribute("data-icon-name") == OperationTypeDict[type]).Click();

        ConfirmBtnCheck();
    }

    private string SetTemplateNameInTemplateSettingModal(TreeMenuEnum menu)
    {
        var templateNameElement = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "templateName")
            .FindElements(By.TagName("input")).FirstOrDefault();

        templateNameElement.SendKeys($"new {menu}{RandomValueGenerator.GenerateRandomInt(2)}");

        templateValueElement = templateNameElement.GetAttribute("value");

        webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm").Click();

        return templateValueElement;
    }

    private void FindTemplateMenuIsNotSelected(string templateName)
    {
        Thread.Sleep(2000);
        webElementAction.ScrolToLeft(".template-list");
        Thread.Sleep(500);

        var elements = webElementAction.GetElementByCssSelector(".template-list")
            .FindElements(By.CssSelector(".template-item-card"));

        Thread.Sleep(500);
        foreach (var item in elements)
        {
            var titleElement = webElementAction.GetElementByCssSelector(".template-content", item)
                .FindElement(By.CssSelector(".template-item-title label.ellipsis-container"));

            Thread.Sleep(500);
            var titleText = titleElement.GetAttribute("innerText").Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Thread.Sleep(500);
            if (templateName.Contains(titleText[0]))
            {
                item.Click();
                break;
            }
        }
    }
}