// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.PaymentReports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___PaymentReports")]
public class UnappliedPayments : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPagePaymentReports()
    {
        TestInitialize(nameof(OpenPagePaymentReports));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "UnappliedPayments");
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
    public void ValidatePreviewBtnInUnappliedPayments()
    {
        TestInitialize(nameof(ValidatePreviewBtnInUnappliedPayments));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UnappliedPayments");
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
    public void ValidateListBtnInUnappliedPayments()
    {
        TestInitialize(nameof(ValidateListBtnInUnappliedPayments));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UnappliedPayments");
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
    public void ValidateExportPDFBtnInUnappliedPayments()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInUnappliedPayments));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UnappliedPayments");
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
    public void ValidateExportExcelBtnInUnappliedPayments()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInUnappliedPayments));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UnappliedPayments");
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
    public void ValidatePrinterBtnInUnappliedPayments()
    {
        TestInitialize(nameof(ValidatePrinterBtnInUnappliedPayments));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UnappliedPayments");
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
    public void ValidateExportPDFWithTemplateNamingBtnInUnappliedPayments()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInUnappliedPayments));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UnappliedPayments");
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
    public void ValidateExportPDFWithRandomNamingBtnInUnappliedPayments()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInUnappliedPayments));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UnappliedPayments");
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