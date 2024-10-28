// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.SalesInventory;


[TestCategory("Report")]
[TestClass, TestCategory("Report___SalesInventory")]
public class CostofSalesShipped : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCostofSalesShipped()
    {
        TestInitialize(nameof(OpenPageCostofSalesShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales(Shipped)");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInCostofSalesShipped()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCostofSalesShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales(Shipped)");
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
    public void ValidateListBtnInCostofSalesShipped()
    {
        TestInitialize(nameof(ValidateListBtnInCostofSalesShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales(Shipped)");
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
    public void ValidateExportPDFBtnInCostofSalesShipped()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCostofSalesShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales(Shipped)");
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
    public void ValidateExportExcelBtnInCostofSalesShipped()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCostofSalesShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales(Shipped)");
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
    public void ValidatePrinterBtnInCostofSalesShipped()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCostofSalesShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales(Shipped)");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCostofSalesShipped1()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCostofSalesShipped1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales(Shipped)");
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
    public void ValidateExportPDFWithRandomNamingBtnInCostofSalesShipped1()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCostofSalesShipped1));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostofSales(Shipped)");
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