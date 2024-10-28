//develop by Parsa Zakeri

using OpenCvSharp.XImgProc;
using OpenQA.Selenium;

namespace RTProSL_MSTest.TestClasses.MoreItems.Setting
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Setting")]
    public class BarcodePrinterSetup : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageBarcodePrinterSetup()
        {
            TestInitialize(nameof(OpenPageBarcodePrinterSetup));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "BarcodePrinterSetup");

                    Thread.Sleep(1000);

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateBarcodePrinterMode()//feature number 24 release New Features August
        {
            TestInitialize(nameof(ValidateBarcodePrinterMode));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "BarcodePrinterSetup");
                    
                    webElementAction.Click(By.Id("BARCODE_PRINTER_MODE_ROUTE"));

                    // Check if the modal with title 'BARCODE_PRINTER_MODE' is present, and the form named 'barcodePrinterMode' is not present  
                    if (!webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='BARCODE_PRINTER_MODE']")) ||
                        !webElementAction.IsElementPresent(By.CssSelector("[data-form-name='barcodePrinterMode']")))
                        Assert.Fail("Failed to display the 'BARCODE_PRINTER_MODE' modal, or the 'barcodePrinterMode' form is present when it shouldn't be.");

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}