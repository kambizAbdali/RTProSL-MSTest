//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.Upload
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Upload")]
    public class ImportSubrentalPOVendorInvoices : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageImportSubrentalPOVendorInvoices()
        {
            TestInitialize(nameof(OpenPageImportSubrentalPOVendorInvoices));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "ImportSubrentalPOVendorInvoices");

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