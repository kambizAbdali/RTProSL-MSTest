// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.GL_PaymentReports;



[TestCategory("Billing")]
[TestClass, TestCategory("Billing___GL_PaymentReports")]
public class GLDistributionbyType : BaseClass
{


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageGLDistributionbyType()
    {
        TestInitialize(nameof(OpenPageGLDistributionbyType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "GLDistributionbyType");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInGLDistributionbyType()
    {
        TestInitialize(nameof(ValidatePreviewBtnInGLDistributionbyType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionbyType");
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
    public void ValidateListBtnInGLDistributionbyType()
    {
        TestInitialize(nameof(ValidateListBtnInGLDistributionbyType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionbyType");
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
    public void ValidateExportPDFBtnInGLDistributionbyType()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInGLDistributionbyType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionbyType");
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
    public void ValidateExportExcelBtnInGLDistributionbyType()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInGLDistributionbyType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionbyType");
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
    public void ValidatePrinterBtnInGLDistributionbyType()
    {
        TestInitialize(nameof(ValidatePrinterBtnInGLDistributionbyType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionbyType");
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
    public void ValidateExportPDFWithTemplateNamingBtnInGLDistributionbyType()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInGLDistributionbyType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionbyType");
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
    public void ValidateExportPDFWithRandomNamingBtnInGLDistributionbyType()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInGLDistributionbyType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistributionbyType");
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