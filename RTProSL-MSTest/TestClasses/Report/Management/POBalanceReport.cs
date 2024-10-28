// Developed By Mohammad Keshavarz
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Management;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Management")]
public class POBalanceReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPagePOBalanceReport()
    {
        TestInitialize(nameof(OpenPagePOBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POBalanceReport");
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
    public void ValidatePreviewBtnInPOBalanceReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInPOBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POBalanceReport");
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
    public void ValidateListBtnInPOBalanceReport()
    {
        TestInitialize(nameof(ValidateListBtnInPOBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POBalanceReport");
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
    public void ValidateExportPDFBtnInPOBalanceReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInPOBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POBalanceReport");
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
    public void ValidateExportExcelBtnInPOBalanceReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInPOBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POBalanceReport");
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
    public void ValidatePrinterBtnInPOBalanceReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInPOBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POBalanceReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInPOBalanceReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInPOBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POBalanceReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInPOBalanceReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInPOBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POBalanceReport");
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