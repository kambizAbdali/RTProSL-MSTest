// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.PaymentReports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___PaymentReports")]
public class CashReceiptsJournalSummary : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCashReceiptsJournalSummary()
    {
        TestInitialize(nameof(OpenPageCashReceiptsJournalSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "CashReceiptsJournalSummary");
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
    public void ValidatePreviewBtnInCashReceiptsJournalSummary()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCashReceiptsJournalSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalSummary");
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
    public void ValidateListBtnInCashReceiptsJournalSummary()
    {
        TestInitialize(nameof(ValidateListBtnInCashReceiptsJournalSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalSummary");
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
    public void ValidateExportPDFBtnInCashReceiptsJournalSummary()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCashReceiptsJournalSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalSummary");
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
    public void ValidateExportExcelBtnInCashReceiptsJournalSummary()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCashReceiptsJournalSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalSummary");
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
    public void ValidatePrinterBtnInCashReceiptsJournalSummary()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCashReceiptsJournalSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalSummary");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCashReceiptsJournalSummary()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCashReceiptsJournalSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalSummary");
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
    public void ValidateExportPDFWithRandomNamingBtnInCashReceiptsJournalSummary()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCashReceiptsJournalSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalSummary");
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