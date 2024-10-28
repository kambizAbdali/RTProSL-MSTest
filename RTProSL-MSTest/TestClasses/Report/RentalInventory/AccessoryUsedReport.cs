// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.RentalInventory;

[TestCategory("Report")]
[TestClass, TestCategory("Report___RentalInventory")]
public class AccessoryUsedReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageAccessoryUsedReport()
    {
        TestInitialize(nameof(OpenPageAccessoryUsedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryUsedReport");
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
    public void ValidatePreviewBtnInAccessoryUsedReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInAccessoryUsedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryUsedReport");
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
    public void ValidateListBtnInAccessoryUsedReport()
    {
        TestInitialize(nameof(ValidateListBtnInAccessoryUsedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryUsedReport");
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
    public void ValidateExportPDFBtnInAccessoryUsedReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInAccessoryUsedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryUsedReport");
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
    public void ValidateExportExcelBtnInAccessoryUsedReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInAccessoryUsedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryUsedReport");
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
    public void ValidatePrinterBtnInAccessoryUsedReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInAccessoryUsedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryUsedReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInAccessoryUsedReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInAccessoryUsedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryUsedReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInAccessoryUsedReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInAccessoryUsedReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryUsedReport");
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