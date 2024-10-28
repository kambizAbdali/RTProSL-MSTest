using RTProSL_MSTest.Settings;
using SeleniumWebdriver.Interfaces;

namespace SeleniumWebdriver.Configuration;

public class AppConfigReader : IConfig
{
    public BrowserType? GetBrowser()
    {
        var browser = AppConfigKeys.Browser;
        try
        {
            return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public int GetElementLoadTimeOut()
    {
        var timeout = AppConfigKeys.ElementLoadTimeout;
        if (timeout == null)
            return 30;
        return Convert.ToInt32(timeout);
    }

    public int GetPageLoadTimeOut()
    {
        var timeout = AppConfigKeys.PageLoadTimeout;
        if (timeout == null)
            return 30;
        return Convert.ToInt32(timeout);
    }

    public string GetPassword()
    {
        return AppConfigKeys.Password;
    }

    public string GetUsername()
    {
        return AppConfigKeys.Username;
    }

    public string GetWebsite()
    {
        return AppConfigKeys.Website;
    }
}