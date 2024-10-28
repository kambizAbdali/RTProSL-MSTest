// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.DataLayer;
namespace RTProSL_MSTest.TestClasses.Report.Management;

[TestCategory("Report")]
//[TestClass, TestCategory("Report___Management")]
public class WorkstationScannerLicense : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public async Task OpenPageWorkstationScannerLicense()
    {
        TestInitialize(nameof(OpenPageWorkstationScannerLicense));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                await UpdateSetup.SetCheckLicensing("0");
                GoToUrl("Reports", "WorkstationScannerLicense");
                Thread.Sleep(2000);

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
    public async Task ValidatePreviewBtnInWorkstationScannerLicense()
    {
        TestInitialize(nameof(ValidatePreviewBtnInWorkstationScannerLicense));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                await UpdateSetup.SetCheckLicensing("0");
                GoToUrl("Reports", "WorkstationScannerLicense");
                Thread.Sleep(2000);
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
    public async Task ValidateListBtnInWorkstationScannerLicense()
    {
        TestInitialize(nameof(ValidateListBtnInWorkstationScannerLicense));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                await UpdateSetup.SetCheckLicensing("0");
                GoToUrl("Reports", "WorkstationScannerLicense");
                Thread.Sleep(2000);
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
    public async Task ValidateExportPDFBtnInWorkstationScannerLicense()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInWorkstationScannerLicense));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                await UpdateSetup.SetCheckLicensing("0");
                GoToUrl("Reports", "WorkstationScannerLicense");
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
    public async Task ValidateExportExcelBtnInWorkstationScannerLicense()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInWorkstationScannerLicense));
        await UpdateSetup.SetCheckLicensing("0");
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "WorkstationScannerLicense");
                Thread.Sleep(2000);
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
    public async Task ValidatePrinterBtnInWorkstationScannerLicense()
    {
        TestInitialize(nameof(ValidatePrinterBtnInWorkstationScannerLicense));
        await UpdateSetup.SetCheckLicensing("0");
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "WorkstationScannerLicense");
                Thread.Sleep(2000);
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
    public void ValidateExportPDFWithTemplateNamingBtnInWorkstationScannerLicense()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInWorkstationScannerLicense));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "WorkstationScannerLicense");
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
    public void ValidateExportPDFWithRandomNamingBtnInWorkstationScannerLicense()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInWorkstationScannerLicense));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "WorkstationScannerLicense");
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