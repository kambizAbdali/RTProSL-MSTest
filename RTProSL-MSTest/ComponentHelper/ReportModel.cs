//Developed Parsa Zakeri
using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.TestClasses;
using SeleniumWebdriver.Settings;
using System.Collections.ObjectModel;
using WindowsInput;

namespace RTProSL_MSTest.ComponentHelper.Validation;
public class ReportModel : BaseClass
{
    private string downloadURL = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
    private ReportTypeEnum ReportType; //The Type of Requested Menu with Sending its ID
    private int ReportSteps; //The term "ReportSteps" is used to retrieve the values of steps on a page for easy reference in the code.
    public string DataFormItemNameValue;
    public string today = DateTime.Now.ToString("MM/dd/yyyy");
    public string yearAgo = DateTime.Now.AddYears(-1).ToString("MM/dd/yyyy");
    private string SubMenuTitle;
    private bool IsDateGenerated = false;
    private string[] IsGenerateReport;
    private string randomTempalteNamePDF = RandomValueGenerator.GenerateRandomString(10);
    public ReportModel(ReportTypeEnum reportType, int stepReports = default, string dataFormItemNameValue = "fromDate", StructReport reportStruct = default,
        string[] isGenerateReport = default, bool isDateGenerated = false)
    {
        this.ReportType = reportType; //tOfMenuReports = TypeOfMenuReports
        this.ReportSteps = stepReports;
        this.ReportEntity = reportStruct; // Setting up a "reportStruct" and retrieving values can help address the issue of filling in required fields.
        this.DataFormItemNameValue = dataFormItemNameValue;
        this.IsGenerateReport = isGenerateReport;
        this.IsDateGenerated = isDateGenerated;
    }
    public StructReport ReportEntity { get; set; }
    public struct StructReport
    {
        public string InputStep1; //"InputStep1" is used to retrieve the value of the first page in the first step.
        public string ColId1Step2; //"ColId1Step2" is used to find the ID in the table and send a value to it.
        public string ColId2Step2; //"ColId2Step2" is used to find the ID in the table and send a value to it.
        public string ColId3Step2; //"ColId3Step2" is used to find the ID in the table and send a value to it.
        public string GridList; //We defined a variable to receive the ""GridListId"" that is sent from the test method.
    }

    public enum ReportTypeEnum
    {
        Preview,
        List,
        PDF,
        Excel,
        Printer,
        Template,
        Random
    }
    Dictionary<ReportTypeEnum, string> ReportTypeDict = new Dictionary<ReportTypeEnum, string>()
    {
        { ReportTypeEnum.Preview ,"report-preview"},
        { ReportTypeEnum.List,"report-list" },
        { ReportTypeEnum.PDF,"pdf2" },
        { ReportTypeEnum.Excel,"exsel" },
        { ReportTypeEnum.Printer, "printer" }
    };

    private void ClickOnReportBtn(ReportTypeEnum ReportType = default)
    {
        webElementAction.GetElementBySpecificAttribute("data-icon-name", ReportTypeDict[ReportType])
            .Click(); //It finds the requested ID on the menu and clicks on it.
        WaitForLoadingSpiner();
    }

    private void PreviewScreenPresentValidate()
    {
        if (webElementAction.IsElementPresent(By.CssSelector(".tabModal-header"))) //"tabModal" is the ID of the page that checks this ID after the button function, then closes it and checks it again.
            webElementAction.Click(By.CssSelector("[data-icon-name = 'close']"), webElementAction.GetElementByCssSelector(".tabModal-header")); //close Preview Screen
        if (webElementAction.IsElementPresent(By.CssSelector(".webreport"))) Assert.Fail("Error:___ Preview Btn does not work correctly");
    }

    private void DeleteAllExcelPDFs()
    {//"DeletePDFExcelFile" deletes all files with the specified extension in the path.
        string[] filesDownload = Directory.GetFiles(downloadURL).Where(file =>
            file.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) ||
            file.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) ||
            file.EndsWith(".crdownload", StringComparison.OrdinalIgnoreCase)).ToArray(); ;

        SubMenuTitle = webElementAction
            .GetElementBySpecificAttribute("class", "ellipsis-content page-title page-title-content")
            .GetAttribute("innerText");

        foreach (string file in filesDownload)
            File.Delete(file);
    }

    Dictionary<string, string> wordMapping = new Dictionary<string, string>()
        {
            {"Production","Customer"},
            {"Customer","Production"},
            {"Job","Parent"},
            {"Parent","Job"},
            {"Statements","Statement"}
        };

    private void ValidateSavedReportFile(int maxWaitTimeInSeconds = 20)
    {
        string[] filesDownload = Directory.GetFiles(downloadURL).Where(file =>
            file.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) ||
            file.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) ||
            file.EndsWith(".crdownload", StringComparison.OrdinalIgnoreCase)).ToArray(); // Check for files every 0.5 seconds;
        bool validFile = false;

        int firstSpaceIndex = SubMenuTitle.IndexOf(' ');
        string firstWord = SubMenuTitle.Substring(0, firstSpaceIndex).Replace("-", "");
        if (firstWord.Contains("/"))
            firstWord = firstWord.Split("/")[0];

        // Start the timer
        int elapsedTime = 0;
        while (elapsedTime < maxWaitTimeInSeconds * 1000) // Convert to milliseconds
        {
            foreach (string file in filesDownload)
            {
                WaitForLoadingSpiner();
                string[] formatFileS = Path.GetFileName(file).Split('.');
                string fileName = formatFileS[0];
                string fileExtension = formatFileS[formatFileS.Length - 1];

                if (fileName.Contains(firstWord) || fileName.Contains(randomTempalteNamePDF) || fileName.Contains("RTPro"))
                {
                    validFile = true;
                    File.Delete(file);
                }
                else
                {
                    if (wordMapping.ContainsKey(firstWord))
                    {
                        firstWord = wordMapping[firstWord];
                        if (fileName.Contains(firstWord))
                        {
                            validFile = true;
                            File.Delete(file);
                        }
                    }
                    else
                    {
                        if (fileExtension != "xlsx" && fileExtension != "pdf" && fileExtension != "crdownload") continue;
                        if (fileExtension == "xlsx") SubMenuTitle = "RTPro";
                        File.Delete(file);
                        throw new Exception($"Error : The name of the downloaded file(SubMenuTitle :'{SubMenuTitle}' + fileName : '{fileName}')  is not in the download directory.");
                    }
                }
            }

            if (validFile) break; // Exit if a valid file was found

            Thread.Sleep(500); // Wait for 0.5 seconds
            elapsedTime += 500; // Increment elapsed time
        }

        if (!validFile) throw new Exception("Error: File Not Found Or The desired file has not been downloaded");
    }


    private void ValidateReportBtn(ReportTypeEnum reportType)
    {
        switch (reportType)
        {
            case ReportTypeEnum.Preview or ReportTypeEnum.List:
                PreviewScreenPresentValidate();
                break;
            case ReportTypeEnum.PDF or ReportTypeEnum.Excel:
                ValidateSavedReportFile();
                break;
            case ReportTypeEnum.Printer:
                Thread.Sleep(3000);
                InputSimulator sim = new InputSimulator();
                sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.ESCAPE);
                webElementAction.GetElementBySpecificAttribute("id", "contents-container").Click();
                break;
        }
    }
    private void GetReport()
    {
        switch (ReportSteps)
        {
            case 2:
                if (webElementAction.IsElementPresent(By.CssSelector("[data-button-type = 'confirm']")))
                    webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm").Click();// Click next step
                GenerateDateInReport();
                break;
            case 3:
                {
                    if (webElementAction.IsElementPresent(By.CssSelector($"[data-form-item-name='{ReportEntity.InputStep1}']")))
                        new WebElementDataGenerator(webElementAction.GetElementBySpecificAttribute("data-form-item-name", ReportEntity.InputStep1));
                }
                webElementAction.GetElementBySpecificAttribute("data-button-type", "confirm").Click();
                {
                    webElementAction.EnableEditBtnInMinGridIfDisable("projectedEquipmentUtilizationAnalysisKit-MiniGrid-gridId"); //find all element in css and click
                    GetAllColIdInGrid(ReportEntity.ColId1Step2).SendKeys(RandomValueGenerator.GenerateRandomInt(100, 1000)); //send value
                    webElementAction.ClickOnPostBtnInMinGrid("projectedEquipmentUtilizationAnalysisKit-MiniGrid-gridId");
                }
                {
                    var confirmBtn = webElementAction.GetAllElementBySpecificAttribute("data-button-type", "confirm")
                        .ToList(); // find confirm in step and click confirm "Next"
                    confirmBtn[1].Click();
                }
                break;
        }
    }
    private IWebElement GetAllColIdInGrid(string value)
    {
        var gridList = webElementAction.GetElementById(ReportEntity.GridList);
        ReadOnlyCollection<IWebElement> colIds = gridList.FindElements(By.CssSelector(".ag-body-viewport .ag-row-focus [col-id]"));
        return colIds.FirstOrDefault(o => o.GetAttribute("col-id") == value).FindElement(By.TagName("input"));
    }
    private bool IsReportDialogVisible()
    {//"IsReportDialogVisible" checks if the error dialog is displayed on the page, closes it if it exists, and passes the test.
        if (webElementAction.IsElementPresent(By.CssSelector("[data-section = 'errorDialog']")))
        {
            var errorMessage = webElementAction.GetElementBySpecificAttribute("class", "error-message-dialog").GetAttribute("innerText");
            if (errorMessage.Contains("Error:"))
            {
                ConfirmBtnCheck(dataSection: "errorDialog");
                if (errorMessage.Contains("Error: There is no item matching with the selected filter options"))
                    IsDateGenerated = true;
                return true;
            }
            CheckErrorDialogBox();
        }
        return false;
    }
    private void IsReportErrorIconVisible()
    {//IsReportErrorIconVisible checks if the error icon is displayed on the page.

        if (webElementAction.IsElementPresent(By.CssSelector(".icon-error")))
        {
            webElementAction.GenerateDataToRequiredFields();
            ClickOnReportBtn(ReportType);
        }
        if (webElementAction.IsElementPresent(By.CssSelector(".icon-error")))
            testPassed = true;
    }
    private IWebElement ReportIconParent(ReportTypeEnum reportType)
    {
        IWebElement reportIcon = webElementAction.GetElementBySpecificAttribute("data-icon-name", ReportTypeDict[reportType]);
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)ObjectRepository.Driver;

        return (IWebElement)jsExecutor.ExecuteScript("return arguments[0].parentNode;", reportIcon);
    }
    public void ValidateReport(ReportTypeEnum reportType = default)
    {
        GenerateAllInputInReport();
        if (ReportSteps != default) GetReport();
        if (ReportType == ReportTypeEnum.Excel || ReportType == ReportTypeEnum.PDF) DeleteAllExcelPDFs();

        if (reportType == ReportTypeEnum.Template || reportType == ReportTypeEnum.Random) CreateTemplateAndRandomName(reportType);

        if (!ReportIconParent(ReportType).GetAttribute("class").Contains("disabled"))
        {//check parent icon btn is not disabled
            GenerateDateInReport();
            ClickOnReportBtn(ReportType);
            IsReportErrorIconVisible();
            if (testPassed) return;
            if (!IsReportDialogVisible()) ValidateReportBtn(ReportType);
        }
        if (reportType == ReportTypeEnum.Random || reportType == ReportTypeEnum.Template) DeleteTemplate();
    }

    private void GenerateDateInReport()
    {
        Thread.Sleep(2000);
        if (!IsReportDialogVisible() && IsDateGenerated || IsDateGenerated)
        {
            var dateElements = webElementAction.GetElementBySpecificAttribute("data-form-item-name", DataFormItemNameValue)
                .FindElements(By.TagName("input")).ToList();
            dateElements[0].Click(); dateElements[0].Clear(); dateElements[0].SendKeys(RandomValueGenerator.GenerateDateTimeFromDayOffset(-7));
            dateElements[2].Click(); dateElements[2].Clear(); dateElements[2].SendKeys(today);
            GetReport();
            IsDateGenerated = false;
        }
    }

    private void GenerateAllInputInReport()
    {
        if (IsGenerateReport != default)
            foreach (var inputs in IsGenerateReport)
                new WebElementDataGenerator(webElementAction.GetElementBySpecificAttribute("data-form-item-name", inputs));
    }

    private void CreateTemplateAndRandomName(ReportTypeEnum reportType = default)
    {
        GoToSubMenu("REPORT_NAMING_TEMPLATES", "REPORT_NAMING_TEMPLATES");
        //is open sub menu template name
        if (!webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='REPORT_NAMING_TEMPLATES']")))
            Assert.Fail("Error:___ is not open modal export naming template");
        switch (reportType)
        {
            case ReportTypeEnum.Template:
                webElementAction.GetElementByCssSelector(".template-naming-toolbar").FindElements(By.TagName("button"))
                    .FirstOrDefault(o => o.GetAttribute("innerText") == "{ReportName}").Click();
                break;
            case ReportTypeEnum.Random:
                webElementAction.GetElementById("new-convention").SendKeys(randomTempalteNamePDF);
                break;
        }
        webElementAction.Click(By.CssSelector(".icon-add"));

        GotoSubMenuInSelectedReportNames();
    }

    private void DeleteTemplate()
    {
        string originalTab = ObjectRepository.Driver.CurrentWindowHandle;
        ObjectRepository.Driver.SwitchTo().Window(originalTab);

        GoToSubMenu("REPORT_NAMING_TEMPLATES", "REPORT_NAMING_TEMPLATES");
        GotoSubMenuInSelectedReportNames("Delete TemplateDelete Template");
    }

    private void GotoSubMenuInSelectedReportNames(string nameMenu = "Set as DefaultSet as Default")
    {
        By menuKebabCssSelector = By.CssSelector(".new-card-layout > div:nth-of-type(2) .icon-menu-kebab");
        webElementAction.Click(menuKebabCssSelector);

        var context = webElementAction.GetElementByCssSelector(".menu-list");

        if (nameMenu != "Delete TemplateDelete Template")
        {
            var flowElement = webElementAction.GetElementByCssSelector(".pl-layout",
                context: webElementAction.GetElementByCssSelector(".new-card-layout > div:nth-of-type(2)")).GetAttribute("innerText");

            if (flowElement.Contains("Default"))
            {
                webElementAction.Click(By.XPath("//li[.='Delete TemplateDelete Template']"), context);
                webElementAction.Click(menuKebabCssSelector);
            }
        }

        webElementAction.Click(By.XPath($"//li[.='{nameMenu}']"));

        ConfirmBtnCheck(dataSection: "modal");
    }

    public void ValidateReportSubMenu(string menu = default, string subMenu = default)
    {
        try
        {
            GoToSubMenu(menu: menu, subMenu: subMenu);
        }
        catch
        {
            // Click the PRINT option in the tools box  
            webElementAction.GetElementByCssSelector(".tools-box-container").FindElements(By.CssSelector(".tools-box-dropdown-toggle"))
                .FirstOrDefault(o => o.GetAttribute("innerText") == "PRINT").Click();

            webElementAction.Click(By.CssSelector($"li[data-menu-id*='{subMenu}']"));
        }

        ValidateReportBtn(ReportType);
    }
}
