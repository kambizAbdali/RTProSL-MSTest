// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.SalesInventory;


[TestCategory("Report")]
[TestClass, TestCategory("Report___SalesInventory")]
public class SalesInventoryBalanceReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSalesInventoryBalanceReport()
    {
        TestInitialize(nameof(OpenPageSalesInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesInventoryBalanceReport");
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
    public void ValidatePreviewBtnInSalesInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSalesInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesInventoryBalanceReport");
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
    public void ValidateListBtnInSalesInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidateListBtnInSalesInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesInventoryBalanceReport");
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
    public void ValidateExportPDFBtnInSalesInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSalesInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesInventoryBalanceReport");
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
    public void ValidateExportExcelBtnInSalesInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSalesInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesInventoryBalanceReport");
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
    public void ValidatePrinterBtnInSalesInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSalesInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesInventoryBalanceReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInSalesInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSalesInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesInventoryBalanceReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInSalesInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSalesInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesInventoryBalanceReport");
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