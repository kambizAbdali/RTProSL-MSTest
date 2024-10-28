namespace MSTestProject.ComponentHelper;

internal static class RandomValueGenerator
{
    private static readonly Random random = new();

    public static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static string GenerateRandomInt(int length)
    {
        const string chars = "123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static string GenerateRandomInt(int min, int max)
    {
        return random.Next(min, max).ToString();
    }

    public static string GenerateGmail()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var mail = new string(Enumerable.Repeat(chars, 14)
            .Select(s => s[random.Next(s.Length)]).ToArray()) + "@gmail.com";
        return mail;
    }

    public static string GenerateTextArea(int wordCount)
    {
        string textArea = default;
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        for (var i = 0; i < wordCount; i++)
            textArea += new string(Enumerable.Repeat(chars, Convert.ToInt16(GenerateRandomInt(4, 8)))
                .Select(s => s[random.Next(s.Length)]).ToArray()) + new string(' ', 1);
        return textArea.Replace(";", "");
    }

    public static string GenerateDateTimeFromDayOffset(int daysOffset)
    {
        return DateTime.Now.AddDays(daysOffset).ToString("M/d/yyyy");
    }
}