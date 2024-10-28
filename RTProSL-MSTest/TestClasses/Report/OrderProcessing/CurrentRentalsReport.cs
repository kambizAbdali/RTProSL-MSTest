// Developed By Mohammad Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing; 

[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class CurrentRentalsReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCurrentRentalsReport()
    {
        TestInitialize(nameof(OpenPageCurrentRentalsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInCurrentRentalsReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCurrentRentalsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport");
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
    public void ValidateListBtnInCurrentRentalsReport()
    {
        TestInitialize(nameof(ValidateListBtnInCurrentRentalsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport");
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
    public void ValidateExportPDFBtnInCurrentRentalsReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCurrentRentalsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport");
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
    public void ValidateExportExcelBtnInCurrentRentalsReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCurrentRentalsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport");
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
    public void ValidatePrinterBtnInCurrentRentalsReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCurrentRentalsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCurrentRentalsReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCurrentRentalsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInCurrentRentalsReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCurrentRentalsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentRentalsReport");
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