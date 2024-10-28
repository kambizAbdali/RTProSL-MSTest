namespace SeleniumWebdriver.ComponentHelper;

internal class FileHelper
{
    public static string SaveScreenShot(string absolutePath, string fileName)
    {
        var dir = Directory.Exists(absolutePath);
        if (!dir) Directory.CreateDirectory(absolutePath);

        return absolutePath;
    }
}