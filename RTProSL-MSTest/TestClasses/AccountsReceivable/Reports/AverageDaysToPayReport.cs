// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.Reports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___Reports")]
public class AverageDaysToPayReport : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageAverageDaysToPayReport()
    {
        TestInitialize(nameof(OpenPageAverageDaysToPayReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AverageDaysToPayReport");
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
    public void ValidatePreviewBtnInAverageDaysToPayReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInAverageDaysToPayReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AverageDaysToPayReport");
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
    public void ValidateListBtnInAverageDaysToPayReport()
    {
        TestInitialize(nameof(ValidateListBtnInAverageDaysToPayReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AverageDaysToPayReport");
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
    public void ValidateExportPDFBtnInAverageDaysToPayReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInAverageDaysToPayReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AverageDaysToPayReport");
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
    public void ValidateExportExcelBtnInAverageDaysToPayReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInAverageDaysToPayReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AverageDaysToPayReport");
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
    public void ValidatePrinterBtnInAverageDaysToPayReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInAverageDaysToPayReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AverageDaysToPayReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInAverageDaysToPayReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInAverageDaysToPayReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AverageDaysToPayReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInAverageDaysToPayReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInAverageDaysToPayReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AverageDaysToPayReport");
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