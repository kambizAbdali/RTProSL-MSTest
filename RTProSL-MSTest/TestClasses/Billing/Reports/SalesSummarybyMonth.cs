// Developed By Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.Reports;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Reports")]
public class SalesSummaryByMonth : BaseClass
{


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSalesSummaryByMonth()
    {
        TestInitialize(nameof(OpenPageSalesSummaryByMonth));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "SalesSummarybyMonth");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInSalesSummaryByMonth()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSalesSummaryByMonth));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "SalesSummarybyMonth");
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
    public void ValidateListBtnInSalesSummaryByMonth()
    {
        TestInitialize(nameof(ValidateListBtnInSalesSummaryByMonth));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "SalesSummarybyMonth");
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
    public void ValidateExportPDFBtnInSalesSummaryByMonth()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSalesSummaryByMonth));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "SalesSummarybyMonth");
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
    public void ValidateExportExcelBtnInSalesSummaryByMonth()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSalesSummaryByMonth));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "SalesSummarybyMonth");
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
    public void ValidatePrinterBtnInSalesSummaryByMonth()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSalesSummaryByMonth));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "SalesSummarybyMonth");
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
    public void ValidateExportPDFWithTemplateNamingBtnInSalesSummarybyMonth()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSalesSummarybyMonth));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesSummarybyMonth");
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
    public void ValidateExportPDFWithRandomNamingBtnInSalesSummarybyMonth()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSalesSummarybyMonth));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesSummarybyMonth");
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