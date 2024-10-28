// Developed By Mohammad Keshavarz
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Management;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Management")]
public class InsuranceExpiresReport : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInsuranceExpiresReport()
    {
        TestInitialize(nameof(OpenPageInsuranceExpiresReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InsuranceExpiresReport");
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
    public void ValidatePreviewBtnInInsuranceExpiresReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInInsuranceExpiresReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InsuranceExpiresReport");
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
    public void ValidateListBtnInInsuranceExpiresReport()
    {
        TestInitialize(nameof(ValidateListBtnInInsuranceExpiresReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InsuranceExpiresReport");
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
    public void ValidateExportPDFBtnInInsuranceExpiresReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInInsuranceExpiresReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InsuranceExpiresReport");
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
    public void ValidateExportExcelBtnInInsuranceExpiresReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInInsuranceExpiresReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InsuranceExpiresReport");
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
    public void ValidatePrinterBtnInInsuranceExpiresReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInInsuranceExpiresReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InsuranceExpiresReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInInsuranceExpiresReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInInsuranceExpiresReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InsuranceExpiresReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInInsuranceExpiresReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInInsuranceExpiresReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InsuranceExpiresReport");
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