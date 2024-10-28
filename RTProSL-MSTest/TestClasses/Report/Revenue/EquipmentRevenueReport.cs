// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Revenue;



[TestCategory("Report")]
[TestClass, TestCategory("Report___Revenue")]
public class EquipmentRevenueReport : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageEquipmentRevenueReport()
    {
        TestInitialize(nameof(OpenPageEquipmentRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentRevenueReport");
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
    public void ValidatePreviewBtnInEquipmentRevenueReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInEquipmentRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentRevenueReport");
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
    public void ValidateListBtnInEquipmentRevenueReport()
    {
        TestInitialize(nameof(ValidateListBtnInEquipmentRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentRevenueReport");
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
    public void ValidateExportPDFBtnInEquipmentRevenueReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInEquipmentRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentRevenueReport");
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
    public void ValidateExportExcelBtnInEquipmentRevenueReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInEquipmentRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentRevenueReport");
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
    public void ValidatePrinterBtnInEquipmentRevenueReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInEquipmentRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentRevenueReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInEquipmentRevenueReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInEquipmentRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentRevenueReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInEquipmentRevenueReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInEquipmentRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentRevenueReport");
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