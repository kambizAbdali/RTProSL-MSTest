// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.EstimatedRevenue;

[TestCategory("Report")]
[TestClass, TestCategory("Report___EstimatedRevenue")]
public class QuotedProjectedRevenue : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageQuotedProjectedRevenue()
    {
        TestInitialize(nameof(OpenPageQuotedProjectedRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotedProjectedRevenue");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private string[] isGenerateReport = { "parentId", "productionId" };

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInQuotedProjectedRevenue()
    {
        TestInitialize(nameof(ValidatePreviewBtnInQuotedProjectedRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotedProjectedRevenue");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, isDateGenerated: true, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInQuotedProjectedRevenue()
    {
        TestInitialize(nameof(ValidateListBtnInQuotedProjectedRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotedProjectedRevenue");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, isDateGenerated: true, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * (3/2))]
    public void ValidateExportPDFBtnInQuotedProjectedRevenue()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInQuotedProjectedRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotedProjectedRevenue");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isDateGenerated: true, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInQuotedProjectedRevenue()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInQuotedProjectedRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotedProjectedRevenue");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, isDateGenerated: true, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInQuotedProjectedRevenue()
    {
        TestInitialize(nameof(ValidatePrinterBtnInQuotedProjectedRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotedProjectedRevenue");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, isDateGenerated: true, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInQuotedProjectedRevenue()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInQuotedProjectedRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotedProjectedRevenue");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isDateGenerated: true, isGenerateReport: isGenerateReport);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInQuotedProjectedRevenue()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInQuotedProjectedRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "QuotedProjectedRevenue");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isDateGenerated: true, isGenerateReport: isGenerateReport);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}