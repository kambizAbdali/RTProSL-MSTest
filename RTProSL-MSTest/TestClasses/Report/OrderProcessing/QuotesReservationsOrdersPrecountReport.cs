// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;

[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class QuotesReservationsOrdersPrecountReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageQuotesReservationsOrdersPrecountReport()
    {
        TestInitialize(nameof(OpenPageQuotesReservationsOrdersPrecountReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotesReservationsOrdersPrecountReport");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                WaitForLoadingSpiner();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInQuotesReservationsOrdersPrecountReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInQuotesReservationsOrdersPrecountReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotesReservationsOrdersPrecountReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInQuotesReservationsOrdersPrecountReport()
    {
        TestInitialize(nameof(ValidateListBtnInQuotesReservationsOrdersPrecountReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotesReservationsOrdersPrecountReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInQuotesReservationsOrdersPrecountReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInQuotesReservationsOrdersPrecountReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotesReservationsOrdersPrecountReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInQuotesReservationsOrdersPrecountReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInQuotesReservationsOrdersPrecountReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotesReservationsOrdersPrecountReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInQuotesReservationsOrdersPrecountReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInQuotesReservationsOrdersPrecountReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotesReservationsOrdersPrecountReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInQuotesReservationsOrdersPrecountReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInQuotesReservationsOrdersPrecountReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotesReservationsOrdersPrecountReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInQuotesReservationsOrdersPrecountReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInQuotesReservationsOrdersPrecountReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotesReservationsOrdersPrecountReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

}
