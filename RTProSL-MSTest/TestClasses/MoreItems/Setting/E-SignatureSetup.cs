﻿//develop by Mohammad_Keshavarz
namespace RTProSL_MSTest.TestClasses.MoreItems.Setting
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Setting")]
    public class ESignatureSetup : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageESignatureSetup()
        {
            TestInitialize(nameof(OpenPageESignatureSetup));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "E-SignatureSetup");

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