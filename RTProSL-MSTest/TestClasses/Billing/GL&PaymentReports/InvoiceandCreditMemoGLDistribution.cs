// Developed By Parsa   Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.MMInventory.GL_PaymentReports;


[TestCategory("MMInventory")]
[TestClass, TestCategory("MMInventory___GL_PaymentReports")]
public class InvoiceandCreditMemoGLDistribution : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInvoiceandCreditMemoGLDistribution()
    {
        TestInitialize(nameof(OpenPageInvoiceandCreditMemoGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceandCreditMemoGLDistribution");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInInvoiceandCreditMemoGLDistribution()
    {
        TestInitialize(nameof(ValidatePreviewBtnInInvoiceandCreditMemoGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceandCreditMemoGLDistribution");
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
    public void ValidateListBtnInInvoiceandCreditMemoGLDistribution()
    {
        TestInitialize(nameof(ValidateListBtnInInvoiceandCreditMemoGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceandCreditMemoGLDistribution");
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
    public void ValidateExportPDFBtnInInvoiceandCreditMemoGLDistribution()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInInvoiceandCreditMemoGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceandCreditMemoGLDistribution");
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
    public void ValidateExportExcelBtnInInvoiceandCreditMemoGLDistribution()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInInvoiceandCreditMemoGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceandCreditMemoGLDistribution");
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
    public void ValidatePrinterBtnInInvoiceandCreditMemoGLDistribution()
    {
        TestInitialize(nameof(ValidatePrinterBtnInInvoiceandCreditMemoGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceandCreditMemoGLDistribution");
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
    public void ValidateExportPDFWithTemplateNamingBtnInInvoiceandCreditMemoGLDistribution()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInInvoiceandCreditMemoGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceandCreditMemoGLDistribution");
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
    public void ValidateExportPDFWithRandomNamingBtnInInvoiceandCreditMemoGLDistribution()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInInvoiceandCreditMemoGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceandCreditMemoGLDistribution");
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