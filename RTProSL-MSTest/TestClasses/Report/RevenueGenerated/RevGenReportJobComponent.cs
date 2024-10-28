// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.RevenueGenerated;



[TestCategory("Report")]
[TestClass, TestCategory("Report___RevenueGenerated")]
public class RevGenReportJobComponent : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRevGenReportJobComponent()

    {
        TestInitialize(nameof(OpenPageRevGenReportJobComponent));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportJobComponent");
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
    public void ValidatePreviewBtnInRevGenReportJobComponent()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRevGenReportJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportJobComponent");
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
    public void ValidateListBtnInRevGenReportJobComponent()
    {
        TestInitialize(nameof(ValidateListBtnInRevGenReportJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportJobComponent");
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
    public void ValidateExportPDFBtnInRevGenReportJobComponent()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRevGenReportJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportJobComponent");
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
    public void ValidateExportExcelBtnInRevGenReportJobComponent()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRevGenReportJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportJobComponent");
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
    public void ValidatePrinterBtnInRevGenReportJobComponent()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRevGenReportJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportJobComponent");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRevGenReportJobComponent()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRevGenReportJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportJobComponent");
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
    public void ValidateExportPDFWithRandomNamingBtnInRevGenReportJobComponent()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRevGenReportJobComponent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportJobComponent");
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