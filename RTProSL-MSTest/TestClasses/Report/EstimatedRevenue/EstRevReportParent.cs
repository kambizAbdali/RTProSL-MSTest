// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.EstimatedRevenue;

[TestCategory("Report")]
[TestClass, TestCategory("Report___EstimatedRevenue")]
public class EstRevReportParent : BaseClass

{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageEstRevReportParent()
    {
        TestInitialize(nameof(OpenPageEstRevReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportParent");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    string[] GenerateInput = { "parentId","productionId" };

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInEstRevReportParent()
    {
        TestInitialize(nameof(ValidatePreviewBtnInEstRevReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportParent");
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
    public void ValidateListBtnInEstRevReportParent()
    {
        TestInitialize(nameof(ValidateListBtnInEstRevReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportParent");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, isGenerateReport: GenerateInput);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * (3/2))]
    public void ValidateExportPDFBtnInEstRevReportParent()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInEstRevReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportParent");
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
    public void ValidateExportExcelBtnInEstRevReportParent()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInEstRevReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportParent");
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
    public void ValidatePrinterBtnInEstRevReportParent()
    {
        TestInitialize(nameof(ValidatePrinterBtnInEstRevReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportParent");
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
    public void ValidateExportPDFWithTemplateNamingBtnInEstRevReportParent()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInEstRevReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportParent");
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
    public void ValidateExportPDFWithRandomNamingBtnInEstRevReportParent()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInEstRevReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EstRevReportParent");
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