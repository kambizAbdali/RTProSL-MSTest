// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.GL_PaymentReports;



[TestCategory("Billing")]
[TestClass, TestCategory("Billing___GL_PaymentReports")]
public class GLDistributionDetail : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageGLDistributionDetail()
    {
        TestInitialize(nameof(OpenPageGLDistributionDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionDetail");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInGLDistributionDetail()
    {
        TestInitialize(nameof(ValidatePreviewBtnInGLDistributionDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionDetail");
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
    public void ValidateListBtnInGLDistributionDetail()
    {
        TestInitialize(nameof(ValidateListBtnInGLDistributionDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionDetail");
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
    public void ValidateExportPDFBtnInGLDistributionDetail()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInGLDistributionDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionDetail");
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
    public void ValidateExportExcelBtnInGLDistributionDetail()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInGLDistributionDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionDetail");
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
    public void ValidatePrinterBtnInGLDistributionDetail()
    {
        TestInitialize(nameof(ValidatePrinterBtnInGLDistributionDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionDetail");
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
    public void ValidateExportPDFWithTemplateNamingBtnInGLDistributionDetail()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInGLDistributionDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionDetail");
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
    public void ValidateExportPDFWithRandomNamingBtnInGLDistributionDetail()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInGLDistributionDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionDetail");
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