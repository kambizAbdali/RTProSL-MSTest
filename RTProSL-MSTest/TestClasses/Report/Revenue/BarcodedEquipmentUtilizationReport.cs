// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Revenue;



[TestCategory("Report")]
[TestClass, TestCategory("Report___Revenue")]
public class BarcodedEquipmentUtilizationReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageBarcodedEquipmentUtilizationReport()
    {
        TestInitialize(nameof(OpenPageBarcodedEquipmentUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BarcodedEquipmentUtilizationReport");
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
    public void ValidatePreviewBtnInBarcodedEquipmentUtilizationReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInBarcodedEquipmentUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BarcodedEquipmentUtilizationReport");
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
    public void ValidateListBtnInBarcodedEquipmentUtilizationReport()
    {
        TestInitialize(nameof(ValidateListBtnInBarcodedEquipmentUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BarcodedEquipmentUtilizationReport");
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
    public void ValidateExportPDFBtnInBarcodedEquipmentUtilizationReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInBarcodedEquipmentUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BarcodedEquipmentUtilizationReport");
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
    public void ValidateExportExcelBtnInBarcodedEquipmentUtilizationReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInBarcodedEquipmentUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BarcodedEquipmentUtilizationReport");
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
    public void ValidatePrinterBtnInBarcodedEquipmentUtilizationReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInBarcodedEquipmentUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BarcodedEquipmentUtilizationReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInBarcodedEquipmentUtilizationReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInBarcodedEquipmentUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BarcodedEquipmentUtilizationReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInBarcodedEquipmentUtilizationReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInBarcodedEquipmentUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BarcodedEquipmentUtilizationReport");
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