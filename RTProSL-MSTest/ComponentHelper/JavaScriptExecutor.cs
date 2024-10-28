using log4net;
using OpenQA.Selenium;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.ComponentHelper;

public class JavaScriptExecutor
{
    private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(JavaScriptExecutor));

    public static object ExecuteScript(string script)
    {
        var executor = (IJavaScriptExecutor)ObjectRepository.Driver;
        Logger.Info($" Execute Script @ {script}");
        return executor.ExecuteScript(script);
    }

    public static object ExecuteScript(string script, params object[] args)
    {
        var executor = (IJavaScriptExecutor)ObjectRepository.Driver;
        return executor.ExecuteScript(script, args);
    }

    //public static void ScrollToAndClick(IWebElement element)
    //{
    //    ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
    //    Thread.Sleep(300);
    //    element.Click();
    //}

    //public static void ScrollToAndClick(By locator)
    //{
    //    IWebElement element = GenericHelper.GetElement(locator);
    //    ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
    //    Thread.Sleep(300);
    //    element.Click();
    //}
}