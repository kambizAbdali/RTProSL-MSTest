using log4net;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenCvSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using WindowsInput.Native;
using WindowsInput;
using AventStack.ExtentReports.Utils;

namespace MSTestProject.ComponentHelper;

public class GenericHelper
{
    private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(GenericHelper));

    private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
    {
        return x =>
        {
            if (x.FindElements(locator).Count >= 1)
                return true;
            Logger.Info(" Waiting for Element : " + locator);
            return false;
        };
    }

    private static Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
    {
        return x => { return x.FindElements(locator); };
    }

    private static Func<IWebDriver, IWebElement?> WaitForWebElementInPageFunc(By locator)
    {
        return x =>
        {
            if (x.FindElements(locator).Count == 1)
                return x.FindElement(locator);
            return null;
        };
    }

    public static void SelecFromAutoSuggest(By autoSuggesLocator, string initialStr, string strToSelect,
        By autoSuggestistLocator)
    {
        var autoSuggest = ObjectRepository.Driver.FindElement(autoSuggesLocator);
        autoSuggest.SendKeys(initialStr);
        Thread.Sleep(1000);

        var wait = GetWebdriverWait(TimeSpan.FromSeconds(40));
        var elements = wait.Until(GetAllElements(autoSuggestistLocator));
        var select = elements.First(x => x.Text.Equals(strToSelect, StringComparison.OrdinalIgnoreCase));
        select.Click();
        Thread.Sleep(1000);
    }

    public static WebDriverWait GetWebdriverWait(TimeSpan timeout)
    {
        ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        var wait = new WebDriverWait(ObjectRepository.Driver, timeout)
        {
            PollingInterval = TimeSpan.FromMilliseconds(500)
        };
        wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
        Logger.Info(" Wait Object Created ");
        return wait;
    }

    public static bool IsElementPresent(By locator)
    {
        try
        {
            Logger.Info(" Checking for the element " + locator);
            return ObjectRepository.Driver.FindElements(locator).Count == 1;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static IWebElement GetElement(By locator)
    {
        if (IsElementPresent(locator))
            return ObjectRepository.Driver.FindElement(locator);
        throw new NoSuchElementException("Element Not Found : " + locator);
    }


    public static string TakeScreenShot(string testMethodName)
    {
        DeleteScreenShotFile(testMethodName);
        // Check if the TestScreenshots folder exists, if not, create it

        if (!Directory.Exists(screenshotFolderPath))
        {
            Directory.CreateDirectory(screenshotFolderPath);
        }

        //string screenshotFileName = $"Screenshot_{DateTime.Now:yyyy-MM-dd-HH-mm-ss-fff}.png";
        string screenshotFileName = testMethodName + $".jpeg";
        string screenshotFilePath = Path.Combine(screenshotFolderPath, screenshotFileName);

        // if (Directory.Exists(screenshotFilePath))
        //Directory.Delete(screenshotFilePath);

        var screen = ObjectRepository.Driver.TakeScreenshot();
        screen.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Jpeg);
        Logger.Info(" ScreenShot Taken : " + screenshotFilePath);
        return screenshotFilePath;
    }

    const string screenshotFolderPath = @"C:\TakeTestScreenshot";

    public static void DeleteScreenShotFile(string testMethodName)
    {
        string screenshotFileName = testMethodName + $".jpeg";
        string screenshotFilePath = Path.Combine(screenshotFolderPath, screenshotFileName);

        if (File.Exists(screenshotFilePath))
        {
            File.Delete(screenshotFilePath);
            Logger.Info("Delete ScreenShot file: " + screenshotFilePath);
        }
    }

    public static bool WaitForWebElement(By locator, TimeSpan timeout)
    {
        ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        Logger.Info(" Setting the Explicit wait to 1 sec ");
        var wait = GetWebdriverWait(timeout);
        var flag = wait.Until(WaitForWebElementFunc(locator));
        ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =
            TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
        Logger.Info(" Setting the Explicit wait Configured value ");
        return flag;
    }

    public static IWebElement WaitForWebElementVisible(By locator, TimeSpan timeout)
    {
        ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        Logger.Info(" Setting the Explicit wait to 1 sec ");
        var wait = GetWebdriverWait(timeout);
        var flag = wait.Until(ExpectedConditions.ElementIsVisible(locator));
        ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =
            TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
        Logger.Info(" Setting the Explicit wait Configured value ");
        return flag;
    }

    public static IWebElement? WaitForWebElementInPage(By locator, TimeSpan timeout)
    {
        ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        Logger.Info(" Setting the Explicit wait to 1 sec ");
        var wait = GetWebdriverWait(timeout);
        var flag = wait.Until(WaitForWebElementInPageFunc(locator));
        Logger.Info(" Setting the Explicit wait Configured value ");
        ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =
            TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
        return flag;
    }

    public static IWebElement Wait(Func<IWebDriver, IWebElement> conditions, TimeSpan timeout)
    {
        ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        Logger.Info(" Setting the Explicit wait to 1 sec ");
        var wait = GetWebdriverWait(timeout);
        var flag = wait.Until(conditions);
        Logger.Info(" Setting the Explicit wait Configured value ");
        ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =
            TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
        return flag;
    }

    public static string SetFileInWindowUploader(string fileName, string filePath = default)
    {
        // Get the base directory where the executable is located
        string binDirectory = AppContext.BaseDirectory;

        // Construct the path to the project's root folder
        string rootFolder = System.IO.Path.GetFullPath(System.IO.Path.Combine(binDirectory, "..\\..\\..\\.."));

        if (filePath.IsNullOrEmpty())
        {
            // Construct the path to the file
            filePath = System.IO.Path.Combine(rootFolder, "RTProSL-MSTest\\AttachFiles", fileName);
        }
        else
        {
            filePath = System.IO.Path.Combine(filePath, fileName);
        }
        Thread.Sleep(2000);
        // Check if the file exists
        if (System.IO.File.Exists(filePath))
        {
            var inputSimulator = new InputSimulator();

            foreach (char c in filePath)
            {
                Thread.Sleep(50);
                // Simulate pressing the key for each character
                inputSimulator.Keyboard.TextEntry(c);
            }
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        else
        {
            Console.WriteLine("File not found.");
        }
        return filePath;
    }

    public enum TestMethodStatus
    {
        Started,
        Failed,
        Passed,
    }
    public static void WriteTestMethodSatusToLogFile(string testName, TestMethodStatus status)
    {
        string fileName = "testResult.txt"; // Specify your file path
        string path = @"C:\TestResult";
        string testResultFilePath = Path.Combine(path, fileName);

        // Get the current datetime
        string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        string message = "[TestMethod: " + testName + "], [" + status.ToString() + "]";

        // Create the formatted string
        string formattedMessage = $"{currentDateTime}, '{message}'";

        // Ensure the directory exists
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path); // Create the directory if it doesn't exist
        }
        // Use File class to write to the file
        if (!File.Exists(testResultFilePath))
        {
            // If the file does not exist, create it and write the message
            File.WriteAllText(testResultFilePath, formattedMessage + Environment.NewLine);
        }
        else
        {
            // If the file exists, append the message to the last line
            File.AppendAllText(testResultFilePath, formattedMessage + Environment.NewLine);
        }
    }
}