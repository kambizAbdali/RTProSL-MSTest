// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.RentalInventory;

[TestCategory("Report")]
[TestClass, TestCategory("Report___RentalInventory")]
public class CurrentlyinRepair : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCurrentlyinRepair()
    {
        TestInitialize(nameof(OpenPageCurrentlyinRepair));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentlyinRepair");
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
    public void ValidatePreviewBtnInCurrentlyinRepair()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCurrentlyinRepair));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentlyinRepair");
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
    public void ValidateListBtnInCurrentlyinRepair()
    {
        TestInitialize(nameof(ValidateListBtnInCurrentlyinRepair));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentlyinRepair");
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
    public void ValidateExportPDFBtnInCurrentlyinRepair()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCurrentlyinRepair));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentlyinRepair");
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
    public void ValidateExportExcelBtnInCurrentlyinRepair()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCurrentlyinRepair));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentlyinRepair");
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
    public void ValidatePrinterBtnInCurrentlyinRepair()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCurrentlyinRepair));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentlyinRepair");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCurrentlyinRepair()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCurrentlyinRepair));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentlyinRepair");
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
    public void ValidateExportPDFWithRandomNamingBtnInCurrentlyinRepair()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCurrentlyinRepair));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentlyinRepair");
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