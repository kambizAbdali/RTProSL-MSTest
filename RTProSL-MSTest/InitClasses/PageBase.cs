using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumWebdriver.ComponentHelper;

namespace SeleniumWebdriver.BaseClasses;

public class PageBase
{
    private readonly IWebDriver driver;

    [FindsBy(How = How.LinkText, Using = "Home")]
    private IWebElement HomeLink;
    //private IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));

    public PageBase(IWebDriver _driver)
    {
        //PageFactory.InitElements(_driver,this);
        driver = _driver;
    }

    public string Title => driver.Title;

    public void Logout()
    {
        if (GenericHelper.IsElementPresent(By.XPath("//div[@id='header']/ul[1]/li[11]/a")))
            ButtonHelper.ClickButton(By.XPath("//div[@id='header']/ul[1]/li[11]/a"));
        GenericHelper.WaitForWebElementInPage(By.Id("welcome"), TimeSpan.FromSeconds(30));
    }

    protected void NaviGateToHomePage()
    {
        HomeLink.Click();
    }
}