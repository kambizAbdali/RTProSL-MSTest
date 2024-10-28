using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumWebdriver.BaseClasses;

namespace SeleniumWebdriver.PageObject;

public class EnterBug : PageBase
{
    private IWebDriver driver;

    #region WenElement

    [FindsBy(How = How.LinkText, Using = "Testng")]
    private IWebElement Testng;
    //private IWebElement Testng => driver.FindElement(By.LinkText("Testng"));

    #endregion

    public EnterBug(IWebDriver _driver) : base(_driver)
    {
        driver = _driver;
    }
}