// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Report;

[TestCategory("PurchaseOrder")]
[TestClass, TestCategory("PurchaseOrder___Report")]
public class BilledSubrentalReport : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageBilledSubrentalReport()
    {
        TestInitialize(nameof(OpenPageBilledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledSubrentalReport");
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
    public void ValidatePreviewBtnInBilledSubrentalReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInBilledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledSubrentalReport");
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
    public void ValidateListBtnInBilledSubrentalReport()
    {
        TestInitialize(nameof(ValidateListBtnInBilledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledSubrentalReport");
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
    public void ValidateExportPDFBtnInBilledSubrentalReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInBilledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledSubrentalReport");
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
    public void ValidateExportExcelBtnInBilledSubrentalReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInBilledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledSubrentalReport");
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
    public void ValidatePrinterBtnInBilledSubrentalReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInBilledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledSubrentalReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInBilledSubrentalReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInBilledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "BilledSubrentalReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInBilledSubrentalReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInBilledSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "BilledSubrentalReport");
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