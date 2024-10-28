// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;
[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class BatchCheckoutSheet : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageBatchCheckoutSheet()
    {
        TestInitialize(nameof(OpenPageBatchCheckoutSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchCheckoutSheet");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInBatchCheckoutSheet()
    {
        TestInitialize(nameof(ValidatePreviewBtnInBatchCheckoutSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchCheckoutSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, dataFormItemNameValue: "fromDate", stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInBatchCheckoutSheet()
    {
        TestInitialize(nameof(ValidateListBtnInBatchCheckoutSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchCheckoutSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, dataFormItemNameValue: "fromDate", stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInBatchCheckoutSheet()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInBatchCheckoutSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchCheckoutSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, dataFormItemNameValue: "fromDate" , stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInBatchCheckoutSheet()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInBatchCheckoutSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchCheckoutSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, dataFormItemNameValue: "fromDate", stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInBatchCheckoutSheet()
    {
        TestInitialize(nameof(ValidatePrinterBtnInBatchCheckoutSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchCheckoutSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, dataFormItemNameValue: "fromDate", stepReports: 2);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInBatchCheckoutSheet()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInBatchCheckoutSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchCheckoutSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, dataFormItemNameValue: "fromDate", stepReports: 2);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInBatchCheckoutSheet()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInBatchCheckoutSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BatchCheckoutSheet");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, dataFormItemNameValue: "fromDate", stepReports: 2);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}