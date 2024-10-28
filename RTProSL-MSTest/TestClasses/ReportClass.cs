//Developed Parsa Zakeri
using OpenQA.Selenium;
using RTProSL_MSTest.TestClasses;

namespace RTProSL_MSTest.ComponentHelper.Validation;
public class ReportClass : BaseClass
{
    private string PreviewTypeTitle; //The Desired "Title" for Locating an Item in the Code
    private string PreviewTypeOnclick; //The Desired "Onclick" for Locating an Item in the Code
    private string TypeOfMenuReports; //The Type of Requested Menu with Sending its ID
    private string[] TypeReportCard;
    public ReportClass(string ptTitle = default, string ptOnclick = default, string tOfMenuReports = default, string[] tReportCard = default)
    {
        this.PreviewTypeTitle = ptTitle; //ptTitle = PreviewTypeTitle
        this.PreviewTypeOnclick = ptOnclick; //ptOnclick = PreviewTypeOnclick
        this.TypeOfMenuReports = tOfMenuReports; //tOfMenuReports = TypeOfMenuReports
        this.TypeReportCard = tReportCard;
    }
    private void MenuBtn()
    {//--//--// AllTypeOfMenuReports == "report-preview" , "report-list" , "pdf2" , "exsel" , "printer"
        webElementAction.GetElementBySpecificAttribute("data-icon-name", TypeOfMenuReports)
            .Click(); //It finds the requested ID on the menu and clicks on it.
        WaitForLoadingSpiner();
    }
    private void ToolbarBtn()
    {
        try //AllPreviewTypeTitle == "Save File" , "Print" , "Email" , "Autofit"*2
        {
            if (webElementAction.IsElementPresent(By.CssSelector("[src='/_fr/resources.getResource?resourceName=save.svg&contentType=image%2Fsvg%2Bxml']")) == false)
                webElementAction.GetElementBySpecificAttribute("title", PreviewTypeTitle).Click();//1-Model

            var allToolbar = webElementAction.GetElementBySpecificAttribute("class", "reportView")
                .FindElements(By.TagName("div"))
                .Where(o => o.FindElements(By.TagName("img"))
                    .Where(o => o.GetAttribute("title") == PreviewTypeTitle) != null)
                .ToList();
            allToolbar[0].Click();//2-Model
            WaitForLoadingSpiner();
        }
        catch //AllPreviewTypeOnclick == "ReportExport()" , "ReportExportPrint();" , "SendEmail()" , "WidthFit()" , "HeightFit()"*2
        {
            if (webElementAction.IsElementPresent(By.CssSelector("[src='/_fr/resources.getResource?resourceName=save.svg&contentType=image%2Fsvg%2Bxml']")) == false)
                webElementAction.GetElementBySpecificAttribute("onclick", PreviewTypeOnclick).Click(); //1-Model

            var allToolbar = webElementAction.GetElementBySpecificAttribute("class", "reportView")
                .FindElements(By.TagName("div"))
                .Where(o => o.FindElements(By.TagName("img"))
                    .Where(o => o.GetAttribute("onclick") == PreviewTypeOnclick) != null)
                .ToList();
            allToolbar[0].Click(); //2-Model
            WaitForLoadingSpiner();
        }
    }
    //---------------------ReportCard----------------------
    private void SetTypeCard()
    {
        for (int i = 0; i <= TypeReportCard.Length; i++)
        {
            if (TypeReportCard[i] == "End") break;
            switch (TypeReportCard[i])
            {
                case "Input":
                    ProcessInput(i);
                    break;
                case "RadioButton":
                    ProcessRadioButton(i);
                    break;
                case "CheckBox":
                    ProcessCheckBox(i);
                    break;
                case "DropDown":
                    ProcessDropDown(i);
                    break;
                default:
                    break;
            }
        }
    }
    private void ProcessInput(int lengthArrayCard)
    {
        for (int j = lengthArrayCard + 1; j <= TypeReportCard.Length; j++)
        {
            if (TypeReportCard[j] == "RadioButton" || TypeReportCard[j] == "CheckBox" || TypeReportCard[j] == "DropDown" || TypeReportCard[j] == "End") break;
            new WebElementDataGenerator(webElementAction.GetElementBySpecificAttribute("data-form-item-name", TypeReportCard[j]));
        }
    }
    private void ProcessCheckBox(int lengthArrayCard)
    {
        for (int j = lengthArrayCard + 1; j <= TypeReportCard.Length; j++)
        {
            if (TypeReportCard[j] == "RadioButton" || TypeReportCard[j] == "Input" || TypeReportCard[j] == "DropDown" || TypeReportCard[j] == "End") break;
            if (!webElementAction.GetInputElementByDataFormItemNameInDiv(TypeReportCard[j]).Selected) webElementAction.GetInputElementByDataFormItemNameInDiv(TypeReportCard[j]).Click();
        }
    }
    private void ProcessRadioButton(int lengthArrayCard)
    {
        for (int j = lengthArrayCard + 1; j <= TypeReportCard.Length; j++)
        {
            if (TypeReportCard[j] == "Input" || TypeReportCard[j] == "CheckBox" || TypeReportCard[j] == "DropDown" || TypeReportCard[j] == "End") break;
            if (!webElementAction.GetElementById(TypeReportCard[j]).Selected) webElementAction.GetElementById(TypeReportCard[j]).Click();
        }
    }
    private void ProcessDropDown(int lengthArrayCard)
    {
        for (int j = lengthArrayCard + 1; j <= TypeReportCard.Length; j++)
        {
            if (TypeReportCard[j] == "Input" || TypeReportCard[j] == "CheckBox" || TypeReportCard[j] == "RadioButton" || TypeReportCard[j] == "End") break;
            if ((!TypeReportCard[j].Contains("!!")))
            {
                for (int i = j + 1; i <= TypeReportCard.Length; i++)
                {
                    string ValueDropDown = Generator(i, "DropDown");
                    if (string.IsNullOrEmpty(ValueDropDown)) break;
                    webElementAction.GetElementBySpecificAttribute("data-form-item-name", TypeReportCard[j]).Click();
                    Thread.Sleep(1000);
                    webElementAction.GetInputElementByDataFormItemNameInDiv(TypeReportCard[j])
                        .SendKeys(ValueDropDown); //set data in input drop down
                    if (webElementAction.IsElementPresent(By.CssSelector("[title = '" + ValueDropDown + "']")) == true)
                        webElementAction.GetElementBySpecificAttribute("title", ValueDropDown).Click();
                }
            }
        }
    }
    private string Generator(int lengthArrayCard, string type)
    {
        if (!TypeReportCard[lengthArrayCard].Contains("!!")) return null;
        string[] a = TypeReportCard[lengthArrayCard].Split("!!");
        return a[1];
    }
    public void CheckMenuReports()
    {
        SetTypeCard(); //SetValueInReportCard();
        MenuBtn();
        ToolbarBtn();
    }
}