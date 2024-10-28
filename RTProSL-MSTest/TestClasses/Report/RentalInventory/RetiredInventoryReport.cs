// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.RentalInventory;

[TestCategory("Report")]
[TestClass, TestCategory("Report___RentalInventory")]
public class RetiredInventoryReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRetiredInventoryReport()
    {
        TestInitialize(nameof(OpenPageRetiredInventoryReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RetiredInventoryReport");
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
    public void ValidatePreviewBtnInRetiredInventoryReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRetiredInventoryReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RetiredInventoryReport");
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
    public void ValidateListBtnInRetiredInventoryReport()
    {
        TestInitialize(nameof(ValidateListBtnInRetiredInventoryReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RetiredInventoryReport");
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
    public void ValidateExportPDFBtnInRetiredInventoryReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRetiredInventoryReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RetiredInventoryReport");
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
    public void ValidateExportExcelBtnInRetiredInventoryReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRetiredInventoryReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RetiredInventoryReport");
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
    public void ValidatePrinterBtnInRetiredInventoryReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRetiredInventoryReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RetiredInventoryReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRetiredInventoryReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRetiredInventoryReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RetiredInventoryReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInRetiredInventoryReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRetiredInventoryReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RetiredInventoryReport");
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