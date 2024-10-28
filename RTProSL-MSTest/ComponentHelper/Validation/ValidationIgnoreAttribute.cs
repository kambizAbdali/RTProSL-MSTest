using static RTProSL_MSTest.TestClasses.BaseClass;

namespace RTProSL_MSTest.ComponentHelper.Validation;

public class ValidationIgnoreAttribute : Attribute
{
    public ValidationIgnoreAttribute(bool validationIgnore = true,
        IgnoreType type = IgnoreType.Validation)
    {
        ValidationIgnore = validationIgnore;
        Type = type;
    }

    public bool ValidationIgnore { get; set; }
    public IgnoreType Type { get; set; }
}