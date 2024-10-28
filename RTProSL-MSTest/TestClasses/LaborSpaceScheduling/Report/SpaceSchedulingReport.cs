// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.LaborSpaceScheduling.Report;

[TestCategory("LaborSpaceScheduling")]
[TestClass, TestCategory("LaborSpaceScheduling___Scheduling")]
public class SpaceSchedulingReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInSpaceSchedulingReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSpaceSchedulingReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceSchedulingReport");
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
    public void ValidateListBtnInSpaceSchedulingReport()
    {
        TestInitialize(nameof(ValidateListBtnInSpaceSchedulingReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceSchedulingReport");
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
    public void ValidateExportPDFBtnInSpaceSchedulingReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSpaceSchedulingReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceSchedulingReport");
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
    public void ValidateExportExcelBtnInSpaceSchedulingReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSpaceSchedulingReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceSchedulingReport");
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
    public void ValidatePrinterBtnInSpaceSchedulingReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSpaceSchedulingReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceSchedulingReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInLaborSpaceSchedulingReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInLaborSpaceSchedulingReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceSchedulingReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInLaborSpaceSchedulingReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInLaborSpaceSchedulingReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceSchedulingReport");
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