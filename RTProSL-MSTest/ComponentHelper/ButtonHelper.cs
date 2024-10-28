using log4net;
using MSTestProject.ComponentHelper;
using OpenQA.Selenium;

namespace SeleniumWebdriver.ComponentHelper;

public class ButtonHelper
{
    private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(ButtonHelper));
    private static IWebElement _element;

    public static void ClickButton(By locator)
    {
        _element = GenericHelper.GetElement(locator);
        _element.Click();
        Logger.Info(" Button Click @ " + locator);
    }

    public static bool IsButtonEnabled(By locator)
    {
        _element = GenericHelper.GetElement(locator);
        Logger.Info(" Checking Is Button Enabled ");
        return _element.Enabled;
    }

    public static string GetButtonText(By locator)
    {
        _element = GenericHelper.GetElement(locator);
        return _element.GetAttribute("value") ?? string.Empty;
    }

    public static void Logout()
    {
        if (GenericHelper.IsElementPresent(By.XPath("//div[@id='header']/ul[1]/li[11]/a")))
        {
            ClickButton(By.XPath("//div[@id='header']/ul[1]/li[11]/a"));
            GenericHelper.WaitForWebElementInPage(By.Id("welcome"), TimeSpan.FromSeconds(30));
        }
    }
}