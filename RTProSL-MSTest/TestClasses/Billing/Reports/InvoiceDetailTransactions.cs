// Developed By Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.Reports;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Reports")]
public class InvoiceDetailTransactions : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInvoiceDetailTransactions()
    {
        TestInitialize(nameof(OpenPageInvoiceDetailTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceDetailTransactions");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInInvoiceDetailTransactions()
    {
        TestInitialize(nameof(ValidatePreviewBtnInInvoiceDetailTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceDetailTransactions");
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
    public void ValidateListBtnInInvoiceDetailTransactions()
    {
        TestInitialize(nameof(ValidateListBtnInInvoiceDetailTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceDetailTransactions");
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
    public void ValidateExportPDFBtnInInvoiceDetailTransactions()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInInvoiceDetailTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceDetailTransactions");
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
    public void ValidateExportExcelBtnInInvoiceDetailTransactions()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInInvoiceDetailTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceDetailTransactions");
                Thread.Sleep(2000);
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
    public void ValidatePrinterBtnInInvoiceDetailTransactions()
    {
        TestInitialize(nameof(ValidatePrinterBtnInInvoiceDetailTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceDetailTransactions");
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
    public void ValidateExportPDFWithTemplateNamingBtnInInvoiceDetailTransactions()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInInvoiceDetailTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InvoiceDetailTransactions");
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
    public void ValidateExportPDFWithRandomNamingBtnInInvoiceDetailTransactions()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInInvoiceDetailTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InvoiceDetailTransactions");
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