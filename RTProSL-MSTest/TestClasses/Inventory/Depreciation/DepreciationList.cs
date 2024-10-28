using MongoDB.Driver.Core.Configuration;
using RTProSL_MSTest.DataLayer;
using System.Data.SqlClient;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using static RTProSL_MSTest.DataLayer.RTProConnectionString;

namespace RTProSL_MSTest.TestClasses.Inventory.Depreciation
{
    [TestCategory("Inventory")]
    [TestClass, TestCategory("Inventory___Depreciation")]
    public class DepreciationList : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageDepreciationList()
        {

            TestInitialize(nameof(OpenPageDepreciationList));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    Login();
                    //await UpdateSetup.SetUseDeprec("1");
                    GoToUrl("MMInventory", "DepreciationList", gotoLogin:false);
                    Thread.Sleep(1000);

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGrid()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "DepreciationList");
                    RefreshRecordDataInGrid("DeprecationList-gridId", columnId: "equipment");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }

}