using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumWebdriver.BaseClasses;

namespace SeleniumWebdriver.PageObject;

public class HomePage : PageBase
{
    private readonly IWebDriver driver;

    public HomePage(IWebDriver _driver) : base(_driver)
    {
        driver = _driver;
    }

    #region Actions

    public void QuickSearch(string text)
    {
        QuickSearchTextBox.SendKeys(text);
        QuickSearchBtn.Click();
    }

    #endregion

    #region Navigation

    public LoginPage NavigateToLogin()
    {
        FileABugLink.Click();
        GenericHelper.WaitForWebElementInPage(By.Id("log_in"), TimeSpan.FromSeconds(30));
        return new LoginPage(driver);
    }

    #endregion

    #region WebElement

    [FindsBy(How = How.Id, Using = "quicksearch_main")]
    public IWebElement QuickSearchTextBox;
    //private IWebElement QuickSearchTextBox => driver.FindElement(By.Id("quicksearch_main"));

    [FindsBy(How = How.Id, Using = "find")]
    [CacheLookup]
    public IWebElement QuickSearchBtn;
    //private IWebElement QuickSearchBtn => driver.FindElement(By.Id("find"));

    [FindsBy(How = How.LinkText, Using = "File a Bug")]
    private IWebElement FileABugLink;
    //private IWebElement FileABugLink => driver.FindElement(By.LinkText("File a Bug"));

    #endregion
}