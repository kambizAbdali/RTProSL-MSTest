namespace RTProSL_MSTest.ComponentHelper.Validation;


public class ValidationTabClickAttribute : Attribute
{
    public ValidationTabClickAttribute(string tabId)
    {
        TabId = tabId;
    }

    public string TabId { get; set; }
}