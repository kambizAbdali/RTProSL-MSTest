// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Statistical;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Statistical")]
public class SalesStatReportByStockShipped : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSalesStatReportByStockShipped()
    {
        TestInitialize(nameof(OpenPageSalesStatReportByStockShipped));


        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesStatReportByStock-Shipped");
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
    public void ValidatePreviewBtnInSalesStatReportByStockShipped()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSalesStatReportByStockShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesStatReportByStock-Shipped");
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
    public void ValidateListBtnInSalesStatReportByStockShipped()
    {
        TestInitialize(nameof(ValidateListBtnInSalesStatReportByStockShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesStatReportByStock-Shipped");
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
    public void ValidateExportPDFBtnInSalesStatReportByStockShipped()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSalesStatReportByStockShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesStatReportByStock-Shipped");
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
    public void ValidateExportExcelBtnInSalesStatReportByStockShipped()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSalesStatReportByStockShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesStatReportByStock-Shipped");
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
    public void ValidatePrinterBtnInSalesStatReportByStockShipped()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSalesStatReportByStockShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesStatReportByStock-Shipped");
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
    public void ValidateExportPDFWithTemplateNamingBtnInSalesStatReportByStockShipped()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSalesStatReportByStockShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesStatReportByStock-Shipped");
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
    public void ValidateExportPDFWithRandomNamingBtnInSalesStatReportByStockShipped()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSalesStatReportByStockShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesStatReportByStock-Shipped");
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