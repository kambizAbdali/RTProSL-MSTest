// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Statistical;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Statistical")]
public class RentalInventoryUtilizationByVendorTypeReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalInventoryUtilizationByVendorTypeReport()


    {
        TestInitialize(nameof(OpenPageRentalInventoryUtilizationByVendorTypeReport));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationByVendorTypeReport");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInRentalInventoryUtilizationByVendorTypeReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRentalInventoryUtilizationByVendorTypeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationByVendorTypeReport");
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
    public void ValidateListBtnInRentalInventoryUtilizationByVendorTypeReport()
    {
        TestInitialize(nameof(ValidateListBtnInRentalInventoryUtilizationByVendorTypeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationByVendorTypeReport");
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
    public void ValidateExportPDFBtnInRentalInventoryUtilizationByVendorTypeReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRentalInventoryUtilizationByVendorTypeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationByVendorTypeReport");
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
    public void ValidateExportExcelBtnInRentalInventoryUtilizationByVendorTypeReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRentalInventoryUtilizationByVendorTypeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationByVendorTypeReport");
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
    public void ValidatePrinterBtnInRentalInventoryUtilizationByVendorTypeReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRentalInventoryUtilizationByVendorTypeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationByVendorTypeReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRentalInventoryUtilizationByVendorTypeReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRentalInventoryUtilizationByVendorTypeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationByVendorTypeReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInRentalInventoryUtilizationByVendorTypeReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRentalInventoryUtilizationByVendorTypeReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryUtilizationByVendorTypeReport");
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