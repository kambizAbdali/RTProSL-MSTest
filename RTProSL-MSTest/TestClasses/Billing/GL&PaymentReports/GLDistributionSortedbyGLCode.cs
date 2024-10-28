// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.GL_PaymentReports;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___GL_PaymentReports")]
public class GLDistributionSortedbyGLCode : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageGLDistributionSortedbyGLCode()
    {
        TestInitialize(nameof(OpenPageGLDistributionSortedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSortedbyGLCode");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInGLDistributionSortedbyGLCode()
    {
        TestInitialize(nameof(ValidatePreviewBtnInGLDistributionSortedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSortedbyGLCode");
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
    public void ValidateListBtnInGLDistributionSortedbyGLCode()
    {
        TestInitialize(nameof(ValidateListBtnInGLDistributionSortedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSortedbyGLCode");
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
    public void ValidateExportPDFBtnInGLDistributionSortedbyGLCode()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInGLDistributionSortedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSortedbyGLCode");
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
    public void ValidateExportExcelBtnInGLDistributionSortedbyGLCode()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInGLDistributionSortedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSortedbyGLCode");
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
    public void ValidatePrinterBtnInGLDistributionSortedbyGLCode()
    {
        TestInitialize(nameof(ValidatePrinterBtnInGLDistributionSortedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSortedbyGLCode");
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
    public void ValidateExportPDFWithTemplateNamingBtnInGLDistributionSortedbyGLCode()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInGLDistributionSortedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSortedbyGLCode");
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
    public void ValidateExportPDFWithRandomNamingBtnInGLDistributionSortedbyGLCode()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInGLDistributionSortedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionSortedbyGLCode");
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