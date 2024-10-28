namespace RTProSL_MSTest.ComponentHelper.Validation;

public class ValidationElementNameAttribute : Attribute
{
    public ValidationElementNameAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}