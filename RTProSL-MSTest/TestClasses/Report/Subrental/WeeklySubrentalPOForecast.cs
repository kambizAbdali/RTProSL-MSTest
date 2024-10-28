// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Subrental;



[TestCategory("Report")]
[TestClass, TestCategory("Report___Subrental")]
public class WeeklySubrentalPOForecast : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageWeeklySubrentalPOForecast()
    {
        TestInitialize(nameof(OpenPageWeeklySubrentalPOForecast));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "WeeklySubrentalPOForecast");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInWeeklySubrentalPOForecast()
    {
        TestInitialize(nameof(ValidatePreviewBtnInWeeklySubrentalPOForecast));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "WeeklySubrentalPOForecast");
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
    public void ValidateListBtnInWeeklySubrentalPOForecast()
    {
        TestInitialize(nameof(ValidateListBtnInWeeklySubrentalPOForecast));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "WeeklySubrentalPOForecast");
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
    public void ValidateExportPDFBtnInWeeklySubrentalPOForecast()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInWeeklySubrentalPOForecast));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "WeeklySubrentalPOForecast");
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
    public void ValidateExportExcelBtnInWeeklySubrentalPOForecast()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInWeeklySubrentalPOForecast));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "WeeklySubrentalPOForecast");
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
    public void ValidatePrinterBtnInWeeklySubrentalPOForecast()
    {
        TestInitialize(nameof(ValidatePrinterBtnInWeeklySubrentalPOForecast));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "WeeklySubrentalPOForecast");
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
    public void ValidateExportPDFWithTemplateNamingBtnInWeeklySubrentalPOForecast()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInWeeklySubrentalPOForecast));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "WeeklySubrentalPOForecast");
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
    public void ValidateExportPDFWithRandomNamingBtnInWeeklySubrentalPOForecast()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInWeeklySubrentalPOForecast));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "WeeklySubrentalPOForecast");
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