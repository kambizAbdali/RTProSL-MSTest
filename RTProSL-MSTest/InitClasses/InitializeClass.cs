using log4net;
using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using RTProSL_MSTest.Report;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Configuration;
using SeleniumWebdriver.CustomException;
using SeleniumWebdriver.Settings;
using System.Diagnostics;

//using OpenQA.Selenium.PhantomJS;

namespace RTProSL_MSTest.InitClasses;

[TestClass]
public class InitializeClass
{
    private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(InitializeClass));

    private static FirefoxProfile GetFirefoxptions()
    {
        var profile = new FirefoxProfile();
        var manager = new FirefoxProfileManager();
        //profile = manager.GetProfile("default");
        Logger.Info(" Using Firefox Profile ");
        return profile;
    }

    private static FirefoxOptions GetOptions()
    {
        var manager = new FirefoxProfileManager();

        var options = new FirefoxOptions
        {
            Profile = manager.GetProfile("default"),
            AcceptInsecureCertificates = true
        };
        return options;
    }

    private static ChromeOptions GetChromeOptions()
    {
        var option = new ChromeOptions();
        option.AddArgument("start-maximized");
        //option.AddArgument("--headless");
        //option.AddExtension(@"C:\Users\rahul.rathore\Desktop\Cucumber\extension_3_0_12.crx");
        Logger.Info(" Using Chrome Options ");
        return option;
    }

    private static InternetExplorerOptions GetIEOptions()
    {
        var options = new InternetExplorerOptions();
        options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
        options.EnsureCleanSession = true;
        options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
        Logger.Info(" Using Internet Explorer Options ");
        return options;
    }

    private static FirefoxDriver GetFirefoxDriver()
    {
        var options = new FirefoxOptions();
        //FirefoxDriver driver = new FirefoxDriver(GetFirefoxptions());
        var driver = new FirefoxDriver();
        return driver;
    }

    private static ChromeDriver GetChromeDriver()
    {
        DisposeChromeDriver();
        var driver = new ChromeDriver();
        return driver;
    }

    private static EdgeDriver GetEdgeDriver()
    {
        DisposeEdgeDriver();
        var driver = new EdgeDriver();
        return driver;
    }

    public static void DisposeChromeDriver()
    {
        var chromeDrivers = Process.GetProcessesByName("ChromeDriver");

        foreach (var item in chromeDrivers)
        {
            item.Kill();
            item.WaitForExit();
            item.Dispose();
        }
    }

    public static void DisposeEdgeDriver()
    {
        var edgeDrivers = Process.GetProcessesByName("msedgedriver");

        foreach (var item in edgeDrivers)
        {
            item.Kill();
            item.WaitForExit();
            item.Dispose();
        }
    }

    private static InternetExplorerDriver GetIEDriver()
    {
        var driver = new InternetExplorerDriver(GetIEOptions());
        return driver;
    }

    /*private static PhantomJSDriver GetPhantomJsDriver()
    {
        PhantomJSDriver driver = new PhantomJSDriver(GetPhantomJsDrvierService());
       
        return driver;
    }

    private static PhantomJSOptions GetPhantomJsptions()
    {
        PhantomJSOptions option = new PhantomJSOptions();
        option.AddAdditionalCapability("handlesAlerts", true);
        Logger.Info(" Using PhantomJS Options  ");
        return option;
    }
        
    private static PhantomJSDriverService GetPhantomJsDrvierService()
    {
        PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
        service.LogFile = "TestPhantomJS.log";
        service.HideCommandPromptWindow = false;
        service.LoadImages = true;
        Logger.Info(" Using PhantomJS Driver Service  ");
        return service;
    */

    [AssemblyInitialize]
    //[BeforeFeature()]
    public static void InitWebdriver(TestContext tc)
    {
        ObjectRepository.Config = new AppConfigReader();
        Reporter.GetReportManager();
        Reporter.AddTestCaseMetadataToHtmlReport(tc);
        switch (ObjectRepository.Config.GetBrowser())
        {
            case BrowserType.Firefox:
                ObjectRepository.Driver = GetFirefoxDriver();
                Logger.Info(" Using Firefox Driver  ");

                break;

            case BrowserType.Chrome:
                ObjectRepository.Driver = GetChromeDriver();
                Logger.Info(" Using Chrome Driver  ");
                break;

            case BrowserType.IExplorer:
                ObjectRepository.Driver = GetIEDriver();
                Logger.Info(" Using Internet Explorer Driver  ");
                break;

            case BrowserType.PhantomJs:
                //ObjectRepository.Driver = GetPhantomJsDriver();
                Logger.Info(" Using PhantomJs Driver  ");
                break;

            case BrowserType.Edge:
                ObjectRepository.Driver = GetEdgeDriver();
                Logger.Info(" Using Edge Driver  ");
                break;

            default:
                throw new NoSutiableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser());
        }

        ObjectRepository.Driver.Manage()
            .Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
        ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =
            TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
        BrowserHelper.BrowserMaximize();
    }

    [AssemblyCleanup]
    //[AfterScenario()]
    public static void TearDown()
    {
    }
}