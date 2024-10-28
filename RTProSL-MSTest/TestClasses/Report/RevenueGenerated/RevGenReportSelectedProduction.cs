// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.RevenueGenerated;

[TestCategory("Report")]
[TestClass, TestCategory("Report___RevenueGenerated")]
public class RevGenReportSelectedProduction : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRevGenReportSelectedProduction()

    {
        TestInitialize(nameof(OpenPageRevGenReportSelectedProduction));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportSelectedProduction");
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
    public void ValidatePreviewBtnInRevGenReportSelectedProduction()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRevGenReportSelectedProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportSelectedProduction");
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
    public void ValidateListBtnInRevGenReportSelectedProduction()
    {
        TestInitialize(nameof(ValidateListBtnInRevGenReportSelectedProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportSelectedProduction");
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
    public void ValidateExportPDFBtnInRevGenReportSelectedProduction()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRevGenReportSelectedProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportSelectedProduction");
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
    public void ValidateExportExcelBtnInRevGenReportSelectedProduction()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRevGenReportSelectedProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportSelectedProduction");
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
    public void ValidatePrinterBtnInRevGenReportSelectedProduction()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRevGenReportSelectedProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportSelectedProduction");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRevGenReportSelectedProduction()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRevGenReportSelectedProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportSelectedProduction");
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
    public void ValidateExportPDFWithRandomNamingBtnInRevGenReportSelectedProduction()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRevGenReportSelectedProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportSelectedProduction");
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