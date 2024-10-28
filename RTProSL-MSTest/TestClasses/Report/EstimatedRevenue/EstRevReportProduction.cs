// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.EstimatedRevenue;

[TestCategory("Report")]
[TestClass, TestCategory("Report___EstimatedRevenue")]
public class EstRevReportProduction : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageEstRevReportProduction()
    {
        TestInitialize(nameof(OpenPageEstRevReportProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportProduction");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();
                WaitForLoadingSpiner();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    string[] GenerateInput = { "parentId", "productionId" };

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInEstRevReportProduction()
    {
        TestInitialize(nameof(ValidatePreviewBtnInEstRevReportProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportProduction");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, isGenerateReport: GenerateInput);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInEstRevReportProduction()
    {
        TestInitialize(nameof(ValidateListBtnInEstRevReportProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportProduction");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, isGenerateReport: GenerateInput);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInEstRevReportProduction()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInEstRevReportProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportProduction");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: GenerateInput);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInEstRevReportProduction()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInEstRevReportProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportProduction");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, isGenerateReport: GenerateInput);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInEstRevReportProduction()
    {
        TestInitialize(nameof(ValidatePrinterBtnInEstRevReportProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportProduction");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, isGenerateReport: GenerateInput);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInEstRevReportProduction()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInEstRevReportProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportProduction");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: GenerateInput);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInEstRevReportProduction()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInEstRevReportProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportProduction");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: GenerateInput);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}