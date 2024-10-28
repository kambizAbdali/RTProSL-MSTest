using MSTestProject.ComponentHelper;
using OpenQA.Selenium;

namespace SeleniumWebdriver.ComponentHelper;

public class RadioButtonHelper
{
    private static IWebElement element;

    public static void ClickRadioButton(By locator)
    {
        element = GenericHelper.GetElement(locator);
        element.Click();
    }

    public static bool IsRadioButtonSelected(By locator)
    {
        element = GenericHelper.GetElement(locator);
        var flag = element.GetAttribute("checked");

        if (flag == null)
            return false;
        return flag.Equals("true") || flag.Equals("checked");
    }
}