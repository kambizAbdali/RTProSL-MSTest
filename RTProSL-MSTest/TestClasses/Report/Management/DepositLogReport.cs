// Developed By Mohammad Keshavarz
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Management;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Management")]
public class DepositLogReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageDepositLogReport()
    {
        TestInitialize(nameof(OpenPageDepositLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DepositLogReport");
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
    public void ValidatePreviewBtnInDepositLogReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInDepositLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DepositLogReport");
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
    public void ValidateListBtnInDepositLogReport()
    {
        TestInitialize(nameof(ValidateListBtnInDepositLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DepositLogReport");
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
    public void ValidateExportPDFBtnInDepositLogReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInDepositLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DepositLogReport");
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
    public void ValidateExportExcelBtnInDepositLogReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInDepositLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DepositLogReport");
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
    public void ValidatePrinterBtnInDepositLogReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInDepositLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DepositLogReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInDepositLogReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInDepositLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DepositLogReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInDepositLogReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInDepositLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "DepositLogReport");
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