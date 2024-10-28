// Developed By Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.Reports;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Reports")]
public class InvoiceRegister : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageBInvoiceRegister()
    {
        TestInitialize(nameof(OpenPageBInvoiceRegister));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "BInvoiceRegister");
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
    public void ValidatePreviewBtnInInvoiceRegister()
    {
        TestInitialize(nameof(ValidatePreviewBtnInInvoiceRegister));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BInvoiceRegister");
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
    public void ValidateListBtnInInvoiceRegister()
    {
        TestInitialize(nameof(ValidateListBtnInInvoiceRegister));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BInvoiceRegister");
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
    public void ValidateExportPDFBtnInInvoiceRegister()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInInvoiceRegister));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BInvoiceRegister");
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
    public void ValidateExportExcelBtnInInvoiceRegister()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInInvoiceRegister));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BInvoiceRegister");
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
    public void ValidatePrinterBtnInInvoiceRegister()
    {
        TestInitialize(nameof(ValidatePrinterBtnInInvoiceRegister));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BInvoiceRegister");
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
    public void ValidateExportPDFWithTemplateNamingBtnInBInvoiceRegister()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInBInvoiceRegister));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BInvoiceRegister");
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
    public void ValidateExportPDFWithRandomNamingBtnInBInvoiceRegister()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInBInvoiceRegister));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BInvoiceRegister");
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