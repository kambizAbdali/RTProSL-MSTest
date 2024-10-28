// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;

[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class BatchPrintQuoteSheet : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageBatchPrintQuoteSheet()
    {
        TestInitialize(nameof(OpenPageBatchPrintQuoteSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintQuoteSheet");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInBatchPrintQuoteSheet()
    {
        TestInitialize(nameof(ValidatePreviewBtnInBatchPrintQuoteSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintQuoteSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInBatchPrintQuoteSheet()
    {
        TestInitialize(nameof(ValidateListBtnInBatchPrintQuoteSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintQuoteSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * 4)]
    public void ValidateExportPDFBtnInBatchPrintQuoteSheet()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInBatchPrintQuoteSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintQuoteSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInBatchPrintQuoteSheet()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInBatchPrintQuoteSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintQuoteSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInBatchPrintQuoteSheet()
    {
        TestInitialize(nameof(ValidatePrinterBtnInBatchPrintQuoteSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintQuoteSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInBatchPrintQuoteSheet()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInBatchPrintQuoteSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintQuoteSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, stepReports: 2);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInBatchPrintQuoteSheet()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInBatchPrintQuoteSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintQuoteSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, stepReports: 2);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}