// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.RentalInventory;



[TestCategory("Report")]
[TestClass, TestCategory("Report___RentalInventory")]
public class InventoryReconciliation : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInventoryReconciliation()
    {
        TestInitialize(nameof(OpenPageInventoryReconciliation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InventoryReconciliation");
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
    public void ValidatePreviewBtnInInventoryReconciliation()
    {
        TestInitialize(nameof(ValidatePreviewBtnInInventoryReconciliation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InventoryReconciliation");
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
    public void ValidateListBtnInInventoryReconciliation()
    {
        TestInitialize(nameof(ValidateListBtnInInventoryReconciliation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InventoryReconciliation");
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
    public void ValidateExportPDFBtnInInventoryReconciliation()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInInventoryReconciliation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InventoryReconciliation");
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
    public void ValidateExportExcelBtnInInventoryReconciliation()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInInventoryReconciliation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InventoryReconciliation");
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
    public void ValidatePrinterBtnInInventoryReconciliation()
    {
        TestInitialize(nameof(ValidatePrinterBtnInInventoryReconciliation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InventoryReconciliation");
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
    public void ValidateExportPDFWithTemplateNamingBtnInInventoryReconciliation()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInInventoryReconciliation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InventoryReconciliation");
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
    public void ValidateExportPDFWithRandomNamingBtnInInventoryReconciliation()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInInventoryReconciliation));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "InventoryReconciliation");
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