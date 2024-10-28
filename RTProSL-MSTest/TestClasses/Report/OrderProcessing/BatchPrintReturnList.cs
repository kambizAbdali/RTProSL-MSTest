// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;



[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class BatchPrintReturnList : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageBatchPrintReturnList()
    {
        TestInitialize(nameof(OpenPageBatchPrintReturnList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintReturnList");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInBatchPrintReturnList()
    {
        TestInitialize(nameof(ValidatePreviewBtnInBatchPrintReturnList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintReturnList");
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
    public void ValidateListBtnInBatchPrintReturnList()
    {
        TestInitialize(nameof(ValidateListBtnInBatchPrintReturnList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintReturnList");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInBatchPrintReturnList()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInBatchPrintReturnList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintReturnList");
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
    public void ValidateExportExcelBtnInBatchPrintReturnList()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInBatchPrintReturnList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintReturnList");
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
    public void ValidatePrinterBtnInBatchPrintReturnList()
    {
        TestInitialize(nameof(ValidatePrinterBtnInBatchPrintReturnList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintReturnList");
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
    public void ValidateExportPDFWithTemplateNamingBtnInBatchPrintReturnList()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInBatchPrintReturnList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintReturnList");
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
    public void ValidateExportPDFWithRandomNamingBtnInBatchPrintReturnList()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInBatchPrintReturnList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintReturnList");
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