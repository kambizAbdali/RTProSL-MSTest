// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.Reports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___Reports")]
public class AgingSummary : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageAgingSummary()
    {
        TestInitialize(nameof(OpenPageAgingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingSummary");
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
    public void ValidatePreviewBtnInAgingSummary()
    {
        TestInitialize(nameof(ValidatePreviewBtnInAgingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingSummary");
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
    public void ValidateListBtnInAgingSummary()
    {
        TestInitialize(nameof(ValidateListBtnInAgingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingSummary");
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
    public void ValidateExportPDFBtnInAgingSummary()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInAgingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingSummary");
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
    public void ValidateExportExcelBtnInAgingSummary()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInAgingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingSummary");
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
    public void ValidatePrinterBtnInAgingSummary()
    {
        TestInitialize(nameof(ValidatePrinterBtnInAgingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingSummary");
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
    public void ValidateExportPDFWithTemplateNamingBtnInAgingSummary()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInAgingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AgingSummary");
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
    public void ValidateExportPDFWithRandomNamingBtnInAgingSummary()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInAgingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AgingSummary");
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