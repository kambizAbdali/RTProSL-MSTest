// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.PaymentReports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___PaymentReports")]
public class DailyDeposits : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageDailyDeposits()
    {
        TestInitialize(nameof(OpenPageDailyDeposits));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "DailyDeposits");
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
    public void ValidatePreviewBtnInDailyDeposits()
    {
        TestInitialize(nameof(ValidatePreviewBtnInDailyDeposits));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DailyDeposits");
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
    public void ValidateListBtnInDailyDeposits()
    {
        TestInitialize(nameof(ValidateListBtnInDailyDeposits));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DailyDeposits");
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
    public void ValidateExportPDFBtnInDailyDeposits()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInDailyDeposits));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DailyDeposits");
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
    public void ValidateExportExcelBtnInDailyDeposits()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInDailyDeposits));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DailyDeposits");
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
    public void ValidatePrinterBtnInDailyDeposits()
    {
        TestInitialize(nameof(ValidatePrinterBtnInDailyDeposits));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DailyDeposits");
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
    public void ValidateExportPDFWithTemplateNamingBtnInDailyDeposits()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInDailyDeposits));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DailyDeposits");
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
    public void ValidateExportPDFWithRandomNamingBtnInDailyDeposits()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInDailyDeposits));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DailyDeposits");
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