namespace RTProSL_MSTest.TestClasses.History
{
    [TestCategory("History")]
    [TestClass, TestCategory("History")]
    public class OpenPage : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageHistory()
        {
            TestInitialize(nameof(OpenPageHistory));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    Login();

                    var History = webElementAction.GetElementBySpecificAttribute("data-menu-name", "History");
                    History.Click();

                    Thread.Sleep(1000);

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}