// Developed By Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.Reports;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Reports")]
public class RangeOfInvoices : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageBRangeOfInvoices()
    {
        TestInitialize(nameof(OpenPageBRangeOfInvoices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BRangeofInvoices");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInRangeOfInvoices()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRangeOfInvoices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BRangeofInvoices");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, isDateGenerated:true);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInRangeOfInvoices()
    {
        TestInitialize(nameof(ValidateListBtnInRangeOfInvoices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BRangeofInvoices");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, isDateGenerated: true);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInRangeOfInvoices()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRangeOfInvoices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BRangeofInvoices");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isDateGenerated: true);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInRangeOfInvoices()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRangeOfInvoices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BRangeofInvoices");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, isDateGenerated: true);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInRangeOfInvoices()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRangeOfInvoices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BRangeofInvoices");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, isDateGenerated: true);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInBRangeofInvoices()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInBRangeofInvoices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BRangeofInvoices");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isDateGenerated: true);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInBRangeofInvoices()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInBRangeofInvoices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BRangeofInvoices");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isDateGenerated: true);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}