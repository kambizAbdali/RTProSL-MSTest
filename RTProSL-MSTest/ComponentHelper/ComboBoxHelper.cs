using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.ComponentHelper;

public class ComboBoxHelper
{
    private static SelectElement select;

    private static WebDriverWait GetWebDriverWait(IWebDriver driver, TimeSpan timeout)
    {
        var wait = new WebDriverWait(driver, timeout)
        {
            PollingInterval = TimeSpan.FromMilliseconds(250)
        };
        wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        return wait;
    }

    public static void SelectElementWitWait(By locator, int index)
    {
        var wait = GetWebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(60));
        var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
        select = new SelectElement(element);
        select.SelectByIndex(index);
    }

    public static void SelectElement(By locator, int index)
    {
        select = new SelectElement(GenericHelper.GetElement(locator));
        select.SelectByIndex(index);
    }

    public static void SelectElement(IWebElement element, int index)
    {
        select = new SelectElement(element);
        select.SelectByIndex(index);
    }

    public static void SelectElement(By locator, string visibletext)
    {
        select = new SelectElement(GenericHelper.GetElement(locator));
        select.SelectByText(visibletext);
    }

    public static void SelectElementByValue(By locator, string valueTexts)
    {
        select = new SelectElement(GenericHelper.GetElement(locator));
        select.SelectByValue(valueTexts);
    }

    public static void SelectElementByValue(IWebElement element, string valueTexts)
    {
        select = new SelectElement(element);
        select.SelectByValue(valueTexts);
    }

    public static IList<string> GetAllItem(By locator)
    {
        select = new SelectElement(GenericHelper.GetElement(locator));
        return select.Options.Select(x => x.Text).ToList();
    }

    public static void SelectElement(IWebElement element, string visibletext)
    {
        select = new SelectElement(element);
        select.SelectByValue(visibletext);
    }

    public static void SelectElementTXT(IWebElement element, string visibletext)
    {
        select = new SelectElement(element);
        select.SelectByText(visibletext);
    }
}