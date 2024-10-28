// Developed By Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.Reports;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Reports")]
public class InvoicesAttachedtoPO : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInvoicesAttachedtoPO()
    {
        TestInitialize(nameof(OpenPageInvoicesAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoicesAttachedtoPO");
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
    public void ValidatePreviewBtnInInvoicesAttachedtoPO()
    {
        TestInitialize(nameof(ValidatePreviewBtnInInvoicesAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoicesAttachedtoPO");
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
    public void ValidateListBtnInInvoicesAttachedtoPO()
    {
        TestInitialize(nameof(ValidateListBtnInInvoicesAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoicesAttachedtoPO");
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
    public void ValidateExportPDFBtnInInvoicesAttachedtoPO()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInInvoicesAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoicesAttachedtoPO");
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
    public void ValidateExportExcelBtnInInvoicesAttachedtoPO()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInInvoicesAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoicesAttachedtoPO");
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
    public void ValidatePrinterBtnInInvoicesAttachedtoPO()
    {
        TestInitialize(nameof(ValidatePrinterBtnInInvoicesAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoicesAttachedtoPO");
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
    public void ValidateExportPDFWithTemplateNamingBtnInInvoicesAttachedtoPO()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInInvoicesAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InvoicesAttachedtoPO");
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
    public void ValidateExportPDFWithRandomNamingBtnInInvoicesAttachedtoPO()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInInvoicesAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InvoicesAttachedtoPO");
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