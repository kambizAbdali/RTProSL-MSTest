// Developed By Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.Reports;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Reports")]
public class UploadReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageUploadReport()
    {
        TestInitialize(nameof(OpenPageUploadReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "UploadReport");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInUploadReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInUploadReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "UploadReport");
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
    public void ValidateListBtnInUploadReport()
    {
        TestInitialize(nameof(ValidateListBtnInUploadReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "UploadReport");
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
    public void ValidateExportPDFBtnInUploadReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInUploadReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "UploadReport");
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
    public void ValidateExportExcelBtnInUploadReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInUploadReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "UploadReport");
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
    public void ValidatePrinterBtnInUploadReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInUploadReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "UploadReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInUploadReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInUploadReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UploadReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInUploadReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInUploadReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UploadReport");
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