// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Management;
[TestCategory("Report")]
[TestClass, TestCategory("Report___Management")]
public class ProductionLogReport : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageProductionLogReport()
    {
        TestInitialize(nameof(OpenPageProductionLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProductionLogReport");

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
    public void ValidatePreviewBtnInProductionLogReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInProductionLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProductionLogReport");
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
    public void ValidateListBtnInProductionLogReport()
    {
        TestInitialize(nameof(ValidateListBtnInProductionLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProductionLogReport");
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
    public void ValidateExportPDFBtnInProductionLogReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInProductionLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProductionLogReport");
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
    public void ValidateExportExcelBtnInProductionLogReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInProductionLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProductionLogReport");
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
    public void ValidatePrinterBtnInProductionLogReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInProductionLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProductionLogReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInProductionLogReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInProductionLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProductionLogReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInProductionLogReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInProductionLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProductionLogReport");
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