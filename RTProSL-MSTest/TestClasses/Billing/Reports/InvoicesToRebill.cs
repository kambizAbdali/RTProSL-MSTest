// Developed By Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.Reports;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Reports")]
public class InvoicesToRebill : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageBInvoicesToRebill()
    {
        TestInitialize(nameof(OpenPageBInvoicesToRebill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BInvoicesToRebill");
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
    public void ValidatePreviewBtnInInvoicesToRebill()
    {
        TestInitialize(nameof(ValidatePreviewBtnInInvoicesToRebill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BInvoicesToRebill");
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
    public void ValidateListBtnInInvoicesToRebill()
    {
        TestInitialize(nameof(ValidateListBtnInInvoicesToRebill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BInvoicesToRebill");
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
    public void ValidateExportPDFBtnInInvoicesToRebill()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInInvoicesToRebill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BInvoicesToRebill");
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
    public void ValidateExportExcelBtnInInvoicesToRebill()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInInvoicesToRebill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BInvoicesToRebill");
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
    public void ValidatePrinterBtnInInvoicesToRebill()
    {
        TestInitialize(nameof(ValidatePrinterBtnInInvoicesToRebill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BInvoicesToRebill");
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
    public void ValidateExportPDFWithTemplateNamingBtnInBInvoicesToRebill()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInBInvoicesToRebill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BInvoicesToRebill");
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
    public void ValidateExportPDFWithRandomNamingBtnInBInvoicesToRebill()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInBInvoicesToRebill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BInvoicesToRebill");
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