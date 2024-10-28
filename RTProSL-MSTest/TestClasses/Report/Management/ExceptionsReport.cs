// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Management;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Management")]
public class ExceptionsReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageExceptionsReport()
    {
        TestInitialize(nameof(OpenPageExceptionsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ExceptionsReport");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInExceptionsReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInExceptionsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ExceptionsReport");
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
    public void ValidateListBtnInExceptionsReport()
    {
        TestInitialize(nameof(ValidateListBtnInExceptionsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ExceptionsReport");
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
    public void ValidateExportPDFBtnInExceptionsReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInExceptionsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ExceptionsReport");
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
    public void ValidateExportExcelBtnInExceptionsReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInExceptionsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ExceptionsReport");
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
    public void ValidatePrinterBtnInExceptionsReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInExceptionsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ExceptionsReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInExceptionsReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInExceptionsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ExceptionsReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInExceptionsReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInExceptionsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ExceptionsReport");
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