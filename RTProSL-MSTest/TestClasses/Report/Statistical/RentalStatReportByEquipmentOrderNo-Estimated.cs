// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Statistical;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Statistical")]
public class RentalInventoryUtilizationReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalInventoryUtilizationReport()
    {
        TestInitialize(nameof(OpenPageRentalInventoryUtilizationReport));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationReport");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInRentalInventoryUtilizationReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRentalInventoryUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, dataFormItemNameValue: "fromDate");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInRentalInventoryUtilizationReport()
    {
        TestInitialize(nameof(ValidateListBtnInRentalInventoryUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, dataFormItemNameValue: "fromDate");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInRentalInventoryUtilizationReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRentalInventoryUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, dataFormItemNameValue: "fromDate");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInRentalInventoryUtilizationReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRentalInventoryUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, dataFormItemNameValue: "fromDate");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInRentalInventoryUtilizationReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRentalInventoryUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, dataFormItemNameValue: "fromDate");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInRentalInventoryUtilizationReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRentalInventoryUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, dataFormItemNameValue: "fromDate");
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInRentalInventoryUtilizationReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRentalInventoryUtilizationReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, dataFormItemNameValue: "fromDate");
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}