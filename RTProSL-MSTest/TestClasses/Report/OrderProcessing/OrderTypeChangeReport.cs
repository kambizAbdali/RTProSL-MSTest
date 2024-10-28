
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;

[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class OrderTypeChangeReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageOrderTypeChangeReport()
    {
        TestInitialize(nameof(OpenPageOrderTypeChangeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderTypeChangeReport");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private string[] IsGenerateReport = { "productionList", "userCodeList", "rentalAgent1List" };

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInOrderTypeChangeReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInOrderTypeChangeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderTypeChangeReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, isGenerateReport: IsGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInOrderTypeChangeReport()
    {
        TestInitialize(nameof(ValidateListBtnInOrderTypeChangeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderTypeChangeReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, isGenerateReport: IsGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInOrderTypeChangeReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInOrderTypeChangeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderTypeChangeReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: IsGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInOrderTypeChangeReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInOrderTypeChangeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderTypeChangeReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, isGenerateReport: IsGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInOrderTypeChangeReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInOrderTypeChangeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderTypeChangeReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, isGenerateReport: IsGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInOrderTypeChangeReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInOrderTypeChangeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderTypeChangeReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: IsGenerateReport);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInOrderTypeChangeReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInOrderTypeChangeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderTypeChangeReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: IsGenerateReport);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}

