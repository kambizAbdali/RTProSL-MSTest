// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.SalesInventory;


[TestCategory("Report")]
[TestClass, TestCategory("Report___SalesInventory")]
public class SalesBackorderReport : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSalesBackorderReport()
    {
        TestInitialize(nameof(OpenPageSalesBackorderReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesBackorderReport");
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
    public void ValidatePreviewBtnInSalesBackorderReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSalesBackorderReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesBackorderReport");
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
    public void ValidateListBtnInSalesBackorderReport()
    {
        TestInitialize(nameof(ValidateListBtnInSalesBackorderReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesBackorderReport");
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
    public void ValidateExportPDFBtnInSalesBackorderReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSalesBackorderReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesBackorderReport");
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
    public void ValidateExportExcelBtnInSalesBackorderReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSalesBackorderReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesBackorderReport");
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
    public void ValidatePrinterBtnInSalesBackorderReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSalesBackorderReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesBackorderReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInSalesBackorderReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSalesBackorderReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesBackorderReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInSalesBackorderReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSalesBackorderReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SalesBackorderReport");
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