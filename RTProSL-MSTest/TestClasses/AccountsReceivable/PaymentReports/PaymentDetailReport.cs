// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.PaymentReports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___PaymentReportst")]
public class PaymentDetailReport : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPagePaymentDetailReport()
    {
        TestInitialize(nameof(OpenPagePaymentDetailReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentDetailReport");
                Thread.Sleep(2000);

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
    public void ValidatePreviewBtnInPaymentDetailReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInPaymentDetailReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentDetailReport");
                Thread.Sleep(2000);
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
    public void ValidateListBtnInPaymentDetailReport()
    {
        TestInitialize(nameof(ValidateListBtnInPaymentDetailReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentDetailReport");
                Thread.Sleep(2000);
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * 3)]
    public void ValidateExportPDFBtnInPaymentDetailReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInPaymentDetailReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentDetailReport");
                Thread.Sleep(2000);
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
    public void ValidateExportExcelBtnInPaymentDetailReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInPaymentDetailReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentDetailReport");
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
    public void ValidatePrinterBtnInPaymentDetailReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInPaymentDetailReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentDetailReport");
                Thread.Sleep(2000);
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
    public void ValidateExportPDFWithTemplateNamingBtnInPaymentDetailReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInPaymentDetailReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentDetailReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInPaymentDetailReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInPaymentDetailReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentDetailReport");
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