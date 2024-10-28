// Developed By Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.Reports;


[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Reports")]
public class SubrentalInvoiceReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSubrentalInvoiceReport()
    {
        TestInitialize(nameof(OpenPageSubrentalInvoiceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "SubrentalInvoiceReport");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInSubrentalInvoiceReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSubrentalInvoiceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "SubrentalInvoiceReport");
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
    public void ValidateListBtnInSubrentalInvoiceReport()
    {
        TestInitialize(nameof(ValidateListBtnInSubrentalInvoiceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "SubrentalInvoiceReport");
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
    public void ValidateExportPDFBtnInSubrentalInvoiceReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSubrentalInvoiceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "SubrentalInvoiceReport");
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
    public void ValidateExportExcelBtnInSubrentalInvoiceReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSubrentalInvoiceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "SubrentalInvoiceReport");
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
    public void ValidatePrinterBtnInSubrentalInvoiceReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSubrentalInvoiceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "SubrentalInvoiceReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInSubrentalInvoiceReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSubrentalInvoiceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SubrentalInvoiceReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInSubrentalInvoiceReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSubrentalInvoiceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SubrentalInvoiceReport");
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