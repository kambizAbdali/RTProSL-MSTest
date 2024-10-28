using OpenQA.Selenium.Remote;

namespace SeleniumWebdriver.ComponentHelper;

public class CustomWebElement : RemoteWebElement
{
    private string ElementName = "Default Name";

    public CustomWebElement(RemoteWebDriver parentDriver, string id) : base(parentDriver, id)
    {
    }

    public string Name
    {
        set => ElementName = value;
    }

    public override string ToString()
    {
        return ElementName;
    }
}