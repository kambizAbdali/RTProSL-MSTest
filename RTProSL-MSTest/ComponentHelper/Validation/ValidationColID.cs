namespace RTProSL_MSTest.ComponentHelper.Validation;

public class ValidationColID : Attribute
{
    public ValidationColID(string colID)
    {
        ColID = colID;
    }
    public string ColID { get; set; }
}