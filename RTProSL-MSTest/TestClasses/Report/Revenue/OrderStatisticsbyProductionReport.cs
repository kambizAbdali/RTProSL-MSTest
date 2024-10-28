// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Revenue;



[TestCategory("Report")]
[TestClass, TestCategory("Report___Revenue")]
public class OrderStatisticsByProductionReport : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageOrderOrderStatisticsByProductionReport()
    {
        TestInitialize(nameof(OpenPageOrderOrderStatisticsByProductionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsbyProductionReport");
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
    public void ValidatePreviewBtnInOrderStatisticsByProductionReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInOrderStatisticsByProductionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsbyProductionReport");
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
    public void ValidateListBtnInOrderStatisticsByProductionReport()
    {
        TestInitialize(nameof(ValidateListBtnInOrderStatisticsByProductionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsbyProductionReport");
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
    public void ValidateExportPDFBtnInOrderStatisticsByProductionReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInOrderStatisticsByProductionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsbyProductionReport");
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
    public void ValidateExportExcelBtnInOrderStatisticsByProductionReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInOrderStatisticsByProductionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsbyProductionReport");
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
    public void ValidatePrinterBtnInOrderStatisticsByProductionReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInOrderStatisticsByProductionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsbyProductionReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInOrderStatisticsbyProductionReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInOrderStatisticsbyProductionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsbyProductionReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInOrderStatisticsbyProductionReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInOrderStatisticsbyProductionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatisticsbyProductionReport");
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