namespace RTProSL_MSTest.ComponentHelper.Validation;

public class ValidationIWebElementAttribute : Attribute
{
    public ValidationIWebElementAttribute(string methodName)
    {
        MethodName = methodName;
    }

    public string MethodName { get; set; }
}