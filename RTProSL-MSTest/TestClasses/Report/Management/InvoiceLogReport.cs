// Developed By Mohammad Keshavarz
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Management;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Management")]
public class InvoiceLogReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInvoiceLogReport()
    {
        TestInitialize(nameof(OpenPageInvoiceLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InvoiceLogReport");
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
    public void ValidatePreviewBtnInInvoiceLogReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInInvoiceLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InvoiceLogReport");
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
    public void ValidateListBtnInInvoiceLogReport()
    {
        TestInitialize(nameof(ValidateListBtnInInvoiceLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InvoiceLogReport");
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
    public void ValidateExportPDFBtnInInvoiceLogReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInInvoiceLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InvoiceLogReport");
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
    public void ValidateExportExcelBtnInInvoiceLogReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInInvoiceLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InvoiceLogReport");
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
    public void ValidatePrinterBtnInInvoiceLogReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInInvoiceLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InvoiceLogReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInInvoiceLogReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInInvoiceLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InvoiceLogReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInInvoiceLogReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInInvoiceLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InvoiceLogReport");
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