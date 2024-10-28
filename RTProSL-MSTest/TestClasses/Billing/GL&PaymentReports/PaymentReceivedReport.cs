// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.GL_PaymentReports;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___GL_PaymentReports")]
public class PaymentReceivedReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPagePaymentReceivedReport()
    {
        TestInitialize(nameof(OpenPagePaymentReceivedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "PaymentReceivedReport");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInPaymentReceivedReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInPaymentReceivedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "PaymentReceivedReport");
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
    public void ValidateListBtnInPaymentReceivedReport()
    {
        TestInitialize(nameof(ValidateListBtnInPaymentReceivedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "PaymentReceivedReport");
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
    public void ValidateExportPDFBtnInPaymentReceivedReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInPaymentReceivedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "PaymentReceivedReport");
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
    public void ValidateExportExcelBtnInPaymentReceivedReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInPaymentReceivedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "PaymentReceivedReport");
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
    public void ValidatePrinterBtnInPaymentReceivedReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInPaymentReceivedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "PaymentReceivedReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInPaymentReceivedReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInPaymentReceivedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "PaymentReceivedReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInPaymentReceivedReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInPaymentReceivedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "PaymentReceivedReport");
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