// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.LaborSpaceScheduling.Report;

[TestCategory("LaborSpaceScheduling")]
[TestClass, TestCategory("LaborSpaceScheduling___Reports")]
public class LaborSpaceConflictReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInLaborSpaceConflictReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInLaborSpaceConflictReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceConflictReport");
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
    public void ValidateListBtnInLaborSpaceConflictReport()
    {
        TestInitialize(nameof(ValidateListBtnInLaborSpaceConflictReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceConflictReport");
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
    public void ValidateExportPDFBtnInLaborSpaceConflictReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInLaborSpaceConflictReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceConflictReport");
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
    public void ValidateExportExcelBtnInLaborSpaceConflictReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInLaborSpaceConflictReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceConflictReport");
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
    public void ValidatePrinterBtnInLaborSpaceConflictReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInLaborSpaceConflictReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceConflictReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInLaborSpaceConflictReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInLaborSpaceConflictReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceConflictReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInLaborSpaceConflictReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInLaborSpaceConflictReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("LaborSpaceScheduling", "LaborSpaceConflictReport");
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

