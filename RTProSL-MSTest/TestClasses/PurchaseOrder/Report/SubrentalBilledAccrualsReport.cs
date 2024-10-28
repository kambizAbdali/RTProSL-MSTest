// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Report;

[TestCategory("PurchaseOrder")]
[TestClass, TestCategory("PurchaseOrder___Report")]
public class SubrentalBilledAccrualsReport : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSubrentalBilledAccrualsReport()
    {
        TestInitialize(nameof(OpenPageSubrentalBilledAccrualsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalBilledAccrualsReport");
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
    public void ValidatePreviewBtnInSubrentalBilledAccrualsReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSubrentalBilledAccrualsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalBilledAccrualsReport");
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
    public void ValidateListBtnInSubrentalBilledAccrualsReport()
    {
        TestInitialize(nameof(ValidateListBtnInSubrentalBilledAccrualsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalBilledAccrualsReport");
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
    public void ValidateExportPDFBtnInSubrentalBilledAccrualsReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSubrentalBilledAccrualsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalBilledAccrualsReport");
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
    public void ValidateExportExcelBtnInSubrentalBilledAccrualsReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSubrentalBilledAccrualsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalBilledAccrualsReport");
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
    public void ValidatePrinterBtnInSubrentalBilledAccrualsReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSubrentalBilledAccrualsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalBilledAccrualsReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInSubrentalBilledAccrualsReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSubrentalBilledAccrualsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "SubrentalBilledAccrualsReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInSubrentalBilledAccrualsReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSubrentalBilledAccrualsReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "SubrentalBilledAccrualsReport");
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