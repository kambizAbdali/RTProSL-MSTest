namespace RTProSL_MSTest.ComponentHelper.Validation;

public class ValidationLocatorTypeAttribute : Attribute
{
    public ValidationLocatorTypeAttribute(LocatorType locatorType)
    {
        LocatorType = locatorType;
    }

    public LocatorType LocatorType { get; set; }
}