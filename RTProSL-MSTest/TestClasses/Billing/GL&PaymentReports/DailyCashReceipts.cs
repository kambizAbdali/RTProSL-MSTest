// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.GL_PaymentBilling;



[TestCategory("Billing")]
[TestClass, TestCategory("Billing___GL_PaymentBilling")]
public class DailyCashReceipts : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageDailyCashReceipts()
    {
        TestInitialize(nameof(OpenPageDailyCashReceipts));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "DailyCashReceipts");
                testPassed = true;
            }
            catch (Exception ex)
            {
               HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInDailyCashReceipts()
    {
        TestInitialize(nameof(ValidatePreviewBtnInDailyCashReceipts));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "DailyCashReceipts");
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
    public void ValidateListBtnInDailyCashReceipts()
    {
        TestInitialize(nameof(ValidateListBtnInDailyCashReceipts));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "DailyCashReceipts");
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
    public void ValidateExportPDFBtnInDailyCashReceipts()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInDailyCashReceipts));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "DailyCashReceipts");
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
    public void ValidateExportExcelBtnInDailyCashReceipts()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInDailyCashReceipts));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "DailyCashReceipts");
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
    public void ValidatePrinterBtnInDailyCashReceipts()
    {
        TestInitialize(nameof(ValidatePrinterBtnInDailyCashReceipts));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "DailyCashReceipts");
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