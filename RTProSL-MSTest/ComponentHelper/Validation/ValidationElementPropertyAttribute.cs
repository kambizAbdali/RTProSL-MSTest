namespace RTProSL_MSTest.ComponentHelper.Validation;

public class ValidationElementPropertyAttribute : Attribute
{
    public ValidationElementPropertyAttribute(string property)
    {
        Property = property;
    }

    public string Property { get; set; }
}