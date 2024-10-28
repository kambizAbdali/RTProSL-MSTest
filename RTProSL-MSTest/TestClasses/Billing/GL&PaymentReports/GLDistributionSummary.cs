// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.GL_PaymentReports;


[TestCategory("Billing")]
[TestClass, TestCategory("Billing___GL_PaymentReports")]
public class GLDistributionSummary : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageGLDistributionSummary()
    {
        TestInitialize(nameof(OpenPageGLDistributionSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSummary");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInGLDistributionSummary()
    {
        TestInitialize(nameof(ValidatePreviewBtnInGLDistributionSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSummary");
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
    public void ValidateListBtnInGLDistributionSummary()
    {
        TestInitialize(nameof(ValidateListBtnInGLDistributionSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSummary");
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
    public void ValidateExportPDFBtnInGLDistributionSummary()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInGLDistributionSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSummary");
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
    public void ValidateExportExcelBtnInGLDistributionSummary()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInGLDistributionSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSummary");
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
    public void ValidatePrinterBtnInGLDistributionSummary()
    {
        TestInitialize(nameof(ValidatePrinterBtnInGLDistributionSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSummary");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}