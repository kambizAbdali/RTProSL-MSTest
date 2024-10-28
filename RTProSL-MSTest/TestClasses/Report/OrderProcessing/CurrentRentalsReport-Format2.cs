// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;

[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class CurrentRentalsReportFormat2 : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCurrentRentalsReportFormat2()
    {
        TestInitialize(nameof(OpenPageCurrentRentalsReportFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport-Format2");
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
    public void ValidatePreviewBtnInCurrentRentalsReportFormat2()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCurrentRentalsReportFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport-Format2");
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
    public void ValidateListBtnInCurrentRentalsReportFormat2()
    {
        TestInitialize(nameof(ValidateListBtnInCurrentRentalsReportFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport-Format2");
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
    public void ValidateExportPDFBtnInCurrentRentalsReportFormat2()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCurrentRentalsReportFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport-Format2");
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
    public void ValidateExportExcelBtnInCurrentRentalsReportFormat2()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCurrentRentalsReportFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport-Format2");
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
    public void ValidatePrinterBtnInCurrentRentalsReportFormat2()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCurrentRentalsReportFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport-Format2");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCurrentRentalsReportFormat2()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCurrentRentalsReportFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport-Format2");
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
    public void ValidateExportPDFWithRandomNamingBtnInCurrentRentalsReportFormat2()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCurrentRentalsReportFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport-Format2");
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