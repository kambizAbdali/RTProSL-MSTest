// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.FileMaintenance.OrderProcessing;

namespace RTProSL_MSTest.TestClasses.Report.EstimatedRevenue;

[TestCategory("Report")]
[TestClass, TestCategory("Report___EstimatedRevenue")]
public class ProjectedCashFlow : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageProjectedCashFlow()
    {
        TestInitialize(nameof(OpenPageProjectedCashFlow));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedCashFlow");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                WaitForLoadingSpiner();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private string[] isGenerateReport = { "jobComponentId" };
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInProjectedCashFlow()
    {
        TestInitialize(nameof(ValidatePreviewBtnInProjectedCashFlow));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedCashFlow");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview , isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInProjectedCashFlow()
    {
        TestInitialize(nameof(ValidateListBtnInProjectedCashFlow));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedCashFlow");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInProjectedCashFlow()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInProjectedCashFlow));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedCashFlow");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInProjectedCashFlow()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInProjectedCashFlow));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedCashFlow");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInProjectedCashFlow()
    {
        TestInitialize(nameof(ValidatePrinterBtnInProjectedCashFlow));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedCashFlow");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInProjectedCashFlow()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInProjectedCashFlow));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedCashFlow");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: isGenerateReport);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInProjectedCashFlow()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInProjectedCashFlow));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedCashFlow");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: isGenerateReport);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}