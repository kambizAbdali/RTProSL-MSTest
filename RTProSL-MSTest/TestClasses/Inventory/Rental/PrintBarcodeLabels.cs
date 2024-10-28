// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Inventory.Rental;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Rental")]
public class PrintBarcodeLabels : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPagePrintBarcodeLabels()
    {
        TestInitialize(nameof(OpenPagePrintBarcodeLabels));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "PrintBarcodeLabels");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInPrintBarcodeLabels()
    {
        TestInitialize(nameof(ValidatePreviewBtnInPrintBarcodeLabels));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PrintBarcodeLabels");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * (3 / 2))]
    public void ValidateExportPDFBtnInPrintBarcodeLabels()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInPrintBarcodeLabels));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PrintBarcodeLabels");
                Thread.Sleep(2000);
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
    public void ValidatePrinterBtnInPrintBarcodeLabels()
    {
        TestInitialize(nameof(ValidatePrinterBtnInPrintBarcodeLabels));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PrintBarcodeLabels");
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
    public void ValidateExportPDFWithTemplateNamingBtnInPrintBarcodeLabels()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInPrintBarcodeLabels));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PrintBarcodeLabels");
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
    public void ValidateExportPDFWithRandomNamingBtnInPrintBarcodeLabels()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInPrintBarcodeLabels));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "PrintBarcodeLabels");
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