// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.PaymentReports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___PaymentReports")]
public class CashReceiptsJournalDetail : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCashReceiptsJournalDetail()
    {
        TestInitialize(nameof(OpenPageCashReceiptsJournalDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "CashReceiptsJournalDetail");
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
    public void ValidatePreviewBtnInCashReceiptsJournalDetail()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCashReceiptsJournalDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalDetail");
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
    public void ValidateListBtnInCashReceiptsJournalDetail()
    {
        TestInitialize(nameof(ValidateListBtnInCashReceiptsJournalDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalDetail");
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
    public void ValidateExportPDFBtnInCashReceiptsJournalDetail()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCashReceiptsJournalDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalDetail");
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
    public void ValidateExportExcelBtnInCashReceiptsJournalDetail()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCashReceiptsJournalDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalDetail");
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
    public void ValidatePrinterBtnInCashReceiptsJournalDetail()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCashReceiptsJournalDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalDetail");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCashReceiptsJournalDetail()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCashReceiptsJournalDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalDetail");
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
    public void ValidateExportPDFWithRandomNamingBtnInCashReceiptsJournalDetail()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCashReceiptsJournalDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceiptsJournalDetail");
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