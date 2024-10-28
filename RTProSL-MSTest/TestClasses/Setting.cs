// Developed By Parsa Zakeri

using MSTestProject.ComponentHelper;
using OpenQA.Selenium;

namespace RTProSL_MSTest.TestClasses;

[TestClass]
public class Setting : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateCurrentChangeLocation()//document "New Features August" number 13
    {
        TestInitialize(nameof(ValidateCurrentChangeLocation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // Check if the current URL allows for multi-location selection  
                if (CurrentUrlIsMultiLocation())
                {
                    Login();

                    // Get the current location element from the header  
                    var location = webElementAction.GetElementByCssSelector(".primaryHeader-location");

                    // Store the old location name for comparison later  
                    string oldNameLocation = location.GetAttribute("innerText");

                    // Click on the location element to open the location selection menu  
                    location.Click();

                    // Retrieve all available locations in the selection menu  
                    var allLocations = webElementAction.GetElementByCssSelector(".custom-search-input-items")
                        .FindElements(By.TagName("div")).ToList();

                    // Introduce a short delay to ensure the elements are loaded  
                    Thread.Sleep(500);

                    // Generate a random index to select a location from the list  
                    int locationNumber = int.Parse(RandomValueGenerator.GenerateRandomInt(1, allLocations.Count));

                    // Click on the randomly selected location  
                    allLocations[locationNumber].Click();

                    // Get the new location name after selection  
                    string nameLocation = location.GetAttribute("innerText");

                    // Check if the location name has changed; if not, the test fails  
                    if (oldNameLocation == nameLocation)
                        Assert.Fail($"Error:___Location did not change. Old location: '{oldNameLocation}', New location: '{nameLocation}'");
                }
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}
