using RTProSL_MSTest.DataLayer;

namespace RTProSL_MSTest.TestClasses.Inventory.Depreciation
{
    [TestCategory("Inventory")]
    [TestClass, TestCategory("Inventory___Depreciation")]
    public class UnPostDepreciation : BaseClass
    {

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageUnPostDepreciation()
        {
            TestInitialize(nameof(OpenPageUnPostDepreciation));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    Login();
                    //await UpdateSetup.SetUseDeprec("1");
                    GoToUrl("MMInventory", "UnpostDepreciation", gotoLogin:false);
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