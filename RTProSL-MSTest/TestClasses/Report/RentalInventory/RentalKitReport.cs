// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.RentalInventory;

[TestCategory("Report")]
[TestClass, TestCategory("Report___RentalInventory")]
public class RentalKitReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalKitReport()
    {
        TestInitialize(nameof(OpenPageRentalKitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalKitReport");
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
    public void ValidatePreviewBtnInRentalKitReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRentalKitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalKitReport");
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
    public void ValidateListBtnInRentalKitReport()
    {
        TestInitialize(nameof(ValidateListBtnInRentalKitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalKitReport");
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
    public void ValidateExportPDFBtnInRentalKitReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRentalKitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalKitReport");
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
    public void ValidateExportExcelBtnInRentalKitReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRentalKitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalKitReport");
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
    public void ValidatePrinterBtnInRentalKitReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRentalKitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalKitReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRentalKitReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRentalKitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalKitReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInRentalKitReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRentalKitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalKitReport");
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