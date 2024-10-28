// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Subrental;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Subrental")]
public class ScheduledSubrentalReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageScheduledSubrentalReport()
    {
        TestInitialize(nameof(OpenPageScheduledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ScheduledSubrentalReport");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInScheduledSubrentalReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInScheduledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ScheduledSubrentalReport");
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
    public void ValidateListBtnInScheduledSubrentalReport()
    {
        TestInitialize(nameof(ValidateListBtnInScheduledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ScheduledSubrentalReport");
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
    public void ValidateExportPDFBtnInScheduledSubrentalReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInScheduledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ScheduledSubrentalReport");
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
    public void ValidateExportExcelBtnInScheduledSubrentalReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInScheduledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ScheduledSubrentalReport");
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
    public void ValidatePrinterBtnInScheduledSubrentalReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInScheduledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ScheduledSubrentalReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInScheduledSubrentalReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInScheduledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ScheduledSubrentalReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInScheduledSubrentalReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInScheduledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ScheduledSubrentalReport");
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