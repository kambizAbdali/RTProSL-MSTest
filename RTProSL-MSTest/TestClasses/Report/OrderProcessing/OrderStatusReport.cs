// Developed By Mohammad Keshavarz
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;

[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class OrderStatusReport : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageOrderStatusReport()
    {
        TestInitialize(nameof(OpenPageOrderStatusReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatusReport");
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
    public void ValidatePreviewBtnInOrderStatusReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInOrderStatusReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatusReport");
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
    public void ValidateListBtnInOrderStatusReport()
    {
        TestInitialize(nameof(ValidateListBtnInOrderStatusReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatusReport");
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
    public void ValidateExportPDFBtnInOrderStatusReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInOrderStatusReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatusReport");
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
    public void ValidateExportExcelBtnInOrderStatusReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInOrderStatusReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatusReport");
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
    public void ValidatePrinterBtnInOrderStatusReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInOrderStatusReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatusReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInOrderStatusReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInOrderStatusReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatusReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInOrderStatusReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInOrderStatusReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderStatusReport");
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