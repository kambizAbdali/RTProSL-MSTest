// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.PaymentReports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___PaymentReports")]
public class PaymentReceived : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPagePaymentReceived()
    {
        TestInitialize(nameof(OpenPagePaymentReceived));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "PaymentReceived");
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
    public void ValidatePreviewBtnInPaymentReceived()
    {
        TestInitialize(nameof(ValidatePreviewBtnInPaymentReceived));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentReceived");
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
    public void ValidateListBtnInPaymentReceived()
    {
        TestInitialize(nameof(ValidateListBtnInPaymentReceived));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentReceived");
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
    public void ValidateExportPDFBtnInPaymentReceived()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInPaymentReceived));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentReceived");
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
    public void ValidateExportExcelBtnInPaymentReceived()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInPaymentReceived));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentReceived");
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
    public void ValidatePrinterBtnInPaymentReceived()
    {
        TestInitialize(nameof(ValidatePrinterBtnInPaymentReceived));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentReceived");
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
    public void ValidateExportPDFWithTemplateNamingBtnInPaymentReceived()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInPaymentReceived));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentReceived");
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
    public void ValidateExportPDFWithRandomNamingBtnInPaymentReceived()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInPaymentReceived));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PaymentReceived");
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