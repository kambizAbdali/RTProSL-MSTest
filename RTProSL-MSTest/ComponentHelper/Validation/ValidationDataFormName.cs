namespace RTProSL_MSTest.ComponentHelper.Validation;

public class ValidationDataFormName : Attribute
{
    public ValidationDataFormName(string dataFormName)
    {
        DataFormName = dataFormName;
    }

    public string DataFormName { get; set; }
}

