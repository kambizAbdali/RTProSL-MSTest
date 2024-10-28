using log4net;
using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.ComponentHelper;

public class NavigationHelper
{
    private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(NavigationHelper));

    public static void NavigateToUrl(string Url)
    {
        ObjectRepository.Driver.Navigate().GoToUrl(Url);
        Logger.Info(" Navigate To Page " + Url);
        if (Url.StartsWith("https:"))
            handleSSLError();
    }

    private static void handleSSLError()
    {
        try
        {
            GenericHelper.WaitForWebElement(By.Id("details-button"), TimeSpan.FromSeconds(5));
            var Advanced = ObjectRepository.Driver.FindElement(By.Id("details-button"));
            Advanced.Click();

            GenericHelper.WaitForWebElement(By.Id("proceed-link"), TimeSpan.FromSeconds(20));
            var unsafeBtn = ObjectRepository.Driver.FindElement(By.Id("proceed-link"));
            unsafeBtn.Click();
        }
        catch
        {
        }
    }
}