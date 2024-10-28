// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.SalesInventory;

[TestCategory("Report")]
[TestClass, TestCategory("Report___SalesInventory")]
public class CostofSales : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCostofSales()
    {
        TestInitialize(nameof(OpenPageCostofSales));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales");
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
    public void ValidatePreviewBtnInCostofSales()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCostofSales));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales");
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
    public void ValidateListBtnInCostofSales()
    {
        TestInitialize(nameof(ValidateListBtnInCostofSales));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales");
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
    public void ValidateExportPDFBtnInCostofSales()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCostofSales));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales");
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
    public void ValidateExportExcelBtnInCostofSales()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCostofSales));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales");
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
    public void ValidatePrinterBtnInCostofSales()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCostofSales));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCostofSales()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCostofSales));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales");
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
    public void ValidateExportPDFWithRandomNamingBtnInCostofSales()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCostofSales));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales");
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