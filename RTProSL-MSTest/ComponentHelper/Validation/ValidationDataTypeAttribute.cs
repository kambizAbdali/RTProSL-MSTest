namespace RTProSL_MSTest.ComponentHelper.Validation;

public class ValidationDataTypeAttribute : Attribute
{
    public ValidationDataTypeAttribute(DataType dataType)
    {
        DataType = dataType;
    }

    public DataType DataType { get; set; }
}