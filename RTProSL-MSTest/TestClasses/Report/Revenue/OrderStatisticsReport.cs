// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Revenue;



[TestCategory("Report")]
[TestClass, TestCategory("Report___Revenue")]
public class OrderStatisticsReport : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageOrderStatisticsReport()
    {
        TestInitialize(nameof(OpenPageOrderStatisticsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsReport");
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
    public void ValidatePreviewBtnInOrderStatisticsReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInOrderStatisticsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, isDateGenerated: true);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInOrderStatisticsReport()
    {
        TestInitialize(nameof(ValidateListBtnInOrderStatisticsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, isDateGenerated: true);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInOrderStatisticsReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInOrderStatisticsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isDateGenerated: true);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInOrderStatisticsReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInOrderStatisticsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, isDateGenerated: true);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInOrderStatisticsReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInOrderStatisticsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, isDateGenerated: true);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInOrderStatisticsReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInOrderStatisticsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isDateGenerated: true);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInOrderStatisticsReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInOrderStatisticsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isDateGenerated: true);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}