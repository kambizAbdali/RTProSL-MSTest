// Developed By Parsa Zakeri

using AventStack.ExtentReports.Model;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.FileMaintenance.Inventory;

namespace RTProSL_MSTest.TestClasses.Report.RentalInventory;



[TestCategory("Report")]
[TestClass, TestCategory("Report___RentalInventory")]
public class AccessoryListReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageAccessoryListReport()
    {
        TestInitialize(nameof(OpenPageAccessoryListReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryListReport");

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
    public void ValidatePreviewBtnInAccessoryListReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInAccessoryListReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryListReport");
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
    public void ValidateListBtnInAccessoryListReport()
    {
        TestInitialize(nameof(ValidateListBtnInAccessoryListReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryListReport");
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
    public void ValidateExportPDFBtnInAccessoryListReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInAccessoryListReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryListReport");
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
    public void ValidateExportExcelBtnInAccessoryListReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInAccessoryListReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryListReport");
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
    public void ValidatePrinterBtnInAccessoryListReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInAccessoryListReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryListReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInAccessoryListReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInAccessoryListReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryListReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInAccessoryListReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInAccessoryListReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AccessoryListReport");
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