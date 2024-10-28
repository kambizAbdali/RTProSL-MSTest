namespace RTProSL_MSTest.ComponentHelper.Validation;

public class ValidationIgnoreInGridAttribute : Attribute
{
    public ValidationIgnoreInGridAttribute(bool validationIgnore = true)
    {
        ValidationIgnore = validationIgnore;
    }

    public bool ValidationIgnore { get; set; }

}