//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.Upload
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Upload")]
    public class ImportPayments : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageImportPayments()
        {
            TestInitialize(nameof(OpenPageImportPayments));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "ImportPayments");

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