using RTProSL_MSTest.DataLayer;

namespace RTProSL_MSTest.TestClasses.Inventory.Depreciation
{
    [TestCategory("Inventory")]
    [TestClass, TestCategory("Inventory___Depreciation")]
    public class PostDepreciation : BaseClass
    {

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPagePostDepreciation()
        {
            TestInitialize(nameof(OpenPagePostDepreciation));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    Login();
                    //await UpdateSetup.SetUseDeprec("1");
                    GoToUrl("MMInventory", "PostDepreciation", gotoLogin: false);
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
