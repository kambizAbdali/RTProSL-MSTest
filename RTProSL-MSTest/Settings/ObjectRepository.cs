using OpenQA.Selenium;
using SeleniumWebdriver.Interfaces;
using SeleniumWebdriver.PageObject;

namespace SeleniumWebdriver.Settings;

public class ObjectRepository
{
    public static HomePage hPage;
    public static LoginPage lPage;
    public static EnterBug ePage;
    public static BugDetail bPage;
    public static IConfig Config { get; set; }
    public static IWebDriver Driver { get; set; }
}