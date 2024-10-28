// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.OrderProcessing.Reports;

[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___Order")]
public class JobReplacementCostSheet : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInJobReplacementCostSheet()
    {
        TestInitialize(nameof(ValidatePreviewBtnInJobReplacementCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMProductionReplacementCostSheet");
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
    public void ValidateListBtnInJobReplacementCostSheet()
    {
        TestInitialize(nameof(ValidateListBtnInJobReplacementCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMProductionReplacementCostSheet");
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
    public void ValidateExportPDFBtnInJobReplacementCostSheet()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInJobReplacementCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMProductionReplacementCostSheet");
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
    public void ValidateExportExcelBtnInJobReplacementCostSheet()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInJobReplacementCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMProductionReplacementCostSheet");
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
    public void ValidatePrinterBtnInJobReplacementCostSheet()
    {
        TestInitialize(nameof(ValidatePrinterBtnInJobReplacementCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMProductionReplacementCostSheet");
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
    public void ValidateExportPDFWithTemplateNamingBtnInJobReplacementCostSheet()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInJobReplacementCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMProductionReplacementCostSheet");
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
    public void ValidateExportPDFWithRandomNamingBtnInJobReplacementCostSheet()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInJobReplacementCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMProductionReplacementCostSheet");
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