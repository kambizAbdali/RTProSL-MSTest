// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.Reports;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Reports")]
public class GapsInBilling : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInvoiceDetailTransactions()
    {
        TestInitialize(nameof(OpenPageInvoiceDetailTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "GapsinBilling");
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
    public void ValidatePreviewBtnInGapsInBilling()
    {
        TestInitialize(nameof(ValidatePreviewBtnInGapsInBilling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GapsinBilling");
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
    public void ValidateListBtnInGapsInBilling()
    {
        TestInitialize(nameof(ValidateListBtnInGapsInBilling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GapsinBilling");
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
    public void ValidateExportPDFBtnInGapsInBilling()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInGapsInBilling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GapsinBilling");
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
    public void ValidateExportExcelBtnInGapsInBilling()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInGapsInBilling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GapsinBilling");
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
    public void ValidatePrinterBtnInGapsInBilling()
    {
        TestInitialize(nameof(ValidatePrinterBtnInGapsInBilling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GapsinBilling");
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
    public void ValidateExportPDFWithTemplateNamingBtnInGapsinBilling()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInGapsinBilling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "GapsinBilling");
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
    public void ValidateExportPDFWithRandomNamingBtnInGapsinBilling()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInGapsinBilling));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "GapsinBilling");
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