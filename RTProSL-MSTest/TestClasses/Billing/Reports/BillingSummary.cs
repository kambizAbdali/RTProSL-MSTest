// Developed By Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.Reports;
[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Reports")]
public class BillingSummary : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageBillingSummary()
    {
        TestInitialize(nameof(OpenPageBillingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BillingSummary");
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
    public void ValidatePreviewBtnInBillingSummary()
    {
        TestInitialize(nameof(ValidatePreviewBtnInBillingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BillingSummary");
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
    public void ValidateListBtnInBillingSummary()
    {
        TestInitialize(nameof(ValidateListBtnInBillingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BillingSummary");
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
    public void ValidateExportPDFBtnInBillingSummary()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInBillingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BillingSummary");
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
    public void ValidateExportExcelBtnInBillingSummary()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInBillingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BillingSummary");
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
    public void ValidatePrinterBtnInBillingSummary()
    {
        TestInitialize(nameof(ValidatePrinterBtnInBillingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BillingSummary");
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
    public void ValidateExportPDFWithTemplateNamingBtnInBillingSummary()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInBillingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BillingSummary");
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
    public void ValidateExportPDFWithRandomNamingBtnInBillingSummary()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInBillingSummary));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BillingSummary");
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