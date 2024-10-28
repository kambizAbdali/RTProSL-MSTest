// Developed By Mohammad Keshavarz
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.RentalInventory;

[TestCategory("Report")]
[TestClass, TestCategory("Report___RentalInventory")]
public class CurrentInventoryStatus : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCurrentInventoryStatus()
    {
        TestInitialize(nameof(OpenPageCurrentInventoryStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentInventoryStatus");
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
    public void ValidatePreviewBtnInCurrentInventoryStatus()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCurrentInventoryStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentInventoryStatus");
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
    public void ValidateListBtnInCurrentInventoryStatus()
    {
        TestInitialize(nameof(ValidateListBtnInCurrentInventoryStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentInventoryStatus");
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
    public void ValidateExportPDFBtnInCurrentInventoryStatus()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCurrentInventoryStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentInventoryStatus");
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
    public void ValidateExportExcelBtnInCurrentInventoryStatus()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCurrentInventoryStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentInventoryStatus");
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
    public void ValidatePrinterBtnInCurrentInventoryStatus()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCurrentInventoryStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentInventoryStatus");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCurrentInventoryStatus()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCurrentInventoryStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentInventoryStatus");
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
    public void ValidateExportPDFWithRandomNamingBtnInCurrentInventoryStatus()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCurrentInventoryStatus));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentInventoryStatus");
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