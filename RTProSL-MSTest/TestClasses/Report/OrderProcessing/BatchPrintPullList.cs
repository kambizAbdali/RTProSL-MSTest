// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;

[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class BatchPrintPullList : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageBatchPrintPullList()
    {
        TestInitialize(nameof(OpenPageBatchPrintPullList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Reports", "BatchPrintPullList");
                //webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                //WaiteForLoadingSpiner();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime *4)]
    public void ValidatePreviewBtnInBatchPrintPullList()
    {
        TestInitialize(nameof(ValidatePreviewBtnInBatchPrintPullList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintPullList");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInBatchPrintPullList()
    {
        TestInitialize(nameof(ValidateListBtnInBatchPrintPullList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintPullList");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime *4)]
    public void ValidateExportPDFBtnInBatchPrintPullList()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInBatchPrintPullList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintPullList");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInBatchPrintPullList()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInBatchPrintPullList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintPullList");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInBatchPrintPullList()
    {
        TestInitialize(nameof(ValidatePrinterBtnInBatchPrintPullList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintPullList");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInBatchPrintPullList()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInBatchPrintPullList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintPullList");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, stepReports: 2);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInBatchPrintPullList()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInBatchPrintPullList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchPrintPullList");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, stepReports: 2);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}