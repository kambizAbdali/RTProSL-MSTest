// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.RevenueGenerated;

[TestCategory("Report")]
[TestClass, TestCategory("Report___RevenueGenerated")]
public class RevGenReportLocation : BaseClass
{
    // go to page Rental agent

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRevGenReportLocation()
    {
        TestInitialize(nameof(OpenPageRevGenReportLocation));

        if (!CurrentUrlIsMultiLocation())
            goto finishTest;
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportLocation");
                Thread.Sleep(2000);

                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                WaitForLoadingSpiner();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
        finishTest: { }
    }
    //[TestMethod, Timeout(MaximumExecutionTime)]
    //public void ValidatePreviewBtnInRevGenReportLocation()
    //{
    //    TestInitialize(nameof(ValidatePreviewBtnInRevGenReportLocation));
    //    while (!testPassed && retryCount < maxRetries)
    //        try
    //        {
    //            GoToUrl("Reports", "RevGenReportLocation");
    //            Thread.Sleep(2000);
    //            report report = new report("report-preview");
    //            report.ValidateReports();
    //            testPassed = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            HandleTestFailure(ex.Message);
    //        }
    //}
    //[TestMethod, Timeout(MaximumExecutionTime)]
    //public void ValidateListBtnInRevGenReportLocation()
    //{
    //    TestInitialize(nameof(ValidateListBtnInRevGenReportLocation));
    //    while (!testPassed && retryCount < maxRetries)
    //        try
    //        {
    //            GoToUrl("Reports", "RevGenReportLocation");
    //            Thread.Sleep(2000);
    //            report report = new report("report-list");
    //            report.ValidateReports();
    //            testPassed = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            HandleTestFailure(ex.Message);
    //        }
    //}
    //[TestMethod, Timeout(MaximumExecutionTime)]
    //public void ValidateExportPDFBtnInRevGenReportLocation()
    //{
    //    TestInitialize(nameof(ValidateExportPDFBtnInRevGenReportLocation));
    //    while (!testPassed && retryCount < maxRetries)
    //        try
    //        {
    //            GoToUrl("Reports", "RevGenReportLocation");
    //            Thread.Sleep(2000);
    //            report report = new report("pdf2");
    //            report.ValidateReports();
    //            testPassed = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            HandleTestFailure(ex.Message);
    //        }
    //}
    //[TestMethod, Timeout(MaximumExecutionTime)]
    //public void ValidateExportExcelBtnInRevGenReportLocation()
    //{
    //    TestInitialize(nameof(ValidateExportExcelBtnInRevGenReportLocation));
    //    while (!testPassed && retryCount < maxRetries)
    //        try
    //        {
    //            GoToUrl("Reports", "RevGenReportLocation");
    //            Thread.Sleep(2000);
    //            report report = new report("exsel");
    //            report.ValidateReports();
    //            testPassed = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            HandleTestFailure(ex.Message);
    //        }
    //}
    //[TestMethod, Timeout(MaximumExecutionTime)]
    //public void ValidatePrinterBtnInRevGenReportLocation()
    //{
    //    TestInitialize(nameof(ValidatePrinterBtnInRevGenReportLocation));
    //    while (!testPassed && retryCount < maxRetries)
    //        try
    //        {
    //            GoToUrl("Reports", "RevGenReportLocation");
    //            Thread.Sleep(2000);
    //            report report = new report("printer");
    //            report.ValidateReports();
    //            testPassed = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            HandleTestFailure(ex.Message);
    //        }
    //}
}