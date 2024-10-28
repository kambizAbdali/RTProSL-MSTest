// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Revenue;



[TestCategory("Report")]
[TestClass, TestCategory("Report___Revenue")]
public class RepairLossofRevenueReport : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRepairLossofRevenueReport()
    {
        TestInitialize(nameof(OpenPageRepairLossofRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "Repair-LossofRevenueReport");
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
    public void ValidatePreviewBtnInRepairLossofRevenueReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRepairLossofRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "Repair-LossofRevenueReport");
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
    public void ValidateListBtnInRepairLossofRevenueReport()
    {
        TestInitialize(nameof(ValidateListBtnInRepairLossofRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "Repair-LossofRevenueReport");
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
    public void ValidateExportPDFBtnInRepairLossofRevenueReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRepairLossofRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "Repair-LossofRevenueReport");
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
    public void ValidateExportExcelBtnInRepairLossofRevenueReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRepairLossofRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "Repair-LossofRevenueReport");
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
    public void ValidatePrinterBtnInRepairLossofRevenueReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRepairLossofRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "Repair-LossofRevenueReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRepairLossofRevenueReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRepairLossofRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "Repair-LossofRevenueReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInRepairLossofRevenueReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRepairLossofRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "Repair-LossofRevenueReport");
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