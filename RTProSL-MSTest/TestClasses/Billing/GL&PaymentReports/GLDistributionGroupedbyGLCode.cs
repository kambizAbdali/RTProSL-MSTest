// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.GL_PaymentReports;


[TestCategory("Billing")]
[TestClass, TestCategory("Billing___GL_PaymentReports")]
public class GLDistributionGroupedbyGLCode : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageGLDistributionGroupedbyGLCode()
    {
        TestInitialize(nameof(OpenPageGLDistributionGroupedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "GLDistributionGroupedbyGLCode");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInGLDistributionGroupedbyGLCode()
    {
        TestInitialize(nameof(ValidatePreviewBtnInGLDistributionGroupedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionGroupedbyGLCode");
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
    public void ValidateListBtnInGLDistributionGroupedbyGLCode()
    {
        TestInitialize(nameof(ValidateListBtnInGLDistributionGroupedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionGroupedbyGLCode");
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
    public void ValidateExportPDFBtnInGLDistributionGroupedbyGLCode()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInGLDistributionGroupedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionGroupedbyGLCode");
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
    public void ValidateExportExcelBtnInGLDistributionGroupedbyGLCode()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInGLDistributionGroupedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionGroupedbyGLCode");
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
    public void ValidatePrinterBtnInGLDistributionGroupedbyGLCode()
    {
        TestInitialize(nameof(ValidatePrinterBtnInGLDistributionGroupedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionGroupedbyGLCode");
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
    public void ValidateExportPDFWithTemplateNamingBtnInGLDistributionGroupedbyGLCode()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInGLDistributionGroupedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionGroupedbyGLCode");
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
    public void ValidateExportPDFWithRandomNamingBtnInGLDistributionGroupedbyGLCode()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInGLDistributionGroupedbyGLCode));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionGroupedbyGLCode");
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