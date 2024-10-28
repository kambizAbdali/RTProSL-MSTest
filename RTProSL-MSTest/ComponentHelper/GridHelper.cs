using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.ComponentHelper;

public class GridHelper
{
    internal static string GetTableXpath(string locator, int row, int col)
    {
        return $"{locator}//tbody//tr[{row}]//td[{col}]";
    }

    private static IWebElement GetGridElement(string locator, int row, int col)
    {
        var xpath = GetTableXpath(locator, row, col);
        if (GenericHelper.IsElementPresent(By.XPath(xpath + "//a")))
            return ObjectRepository.Driver.FindElement(By.XPath(xpath + "//a"));
        if (GenericHelper.IsElementPresent(By.XPath(xpath + "//input")))
            return ObjectRepository.Driver.FindElement(By.XPath(xpath + "//input"));
        return ObjectRepository.Driver.FindElement(By.XPath(xpath));
    }

    /// <summary>
    ///     Get the column value
    /// </summary>
    /// <param name="locator"> grid locator </param>
    /// <param name="row"> row index </param>
    /// <param name="col">column index </param>
    /// <returns></returns>
    public static string GetColumnValue(string locator, int row, int col)
    {
        /* string tableXpath = GetTableXpath(locator, row, col);
         string value = string.Empty;


         if (GenericHelper.IsElemetPresent(By.XPath(tableXpath)))
         {
             value = ObjectRepository.Driver.FindElement(By.XPath(tableXpath)).Text;
         }

         return value;*/
        return GetGridElement(locator, row, col).Text;
    }

    public static IList<string> GetAllValues(string locator)
    {
        var list = new List<string>();

        var row = 1;
        var col = 1;

        while (GenericHelper.IsElementPresent(By.XPath(GetTableXpath(locator, row, col))))
        {
            while (GenericHelper.IsElementPresent(By.XPath(GetTableXpath(locator, row, col))))
            {
                list.Add(ObjectRepository.Driver.FindElement(By.XPath(GetTableXpath(locator, row, col))).Text);
                col++;
            }

            row++;
            col = 1;
        }

        return list;
    }

    public static IList<string> GetValues(string locator, int column)
    {
        var list = new List<string>();

        var row = 1;

        while (GenericHelper.IsElementPresent(By.XPath(GetTableXpath(locator, row, column))))
        {
            list.Add(ObjectRepository.Driver.FindElement(By.XPath(GetTableXpath(locator, row, column))).Text);
            row++;
        }

        return list;
    }

    public static void ClickButtonInGrid(string locator, int row, int col)
    {
        GetGridElement(locator, row, col).Click();
    }
}