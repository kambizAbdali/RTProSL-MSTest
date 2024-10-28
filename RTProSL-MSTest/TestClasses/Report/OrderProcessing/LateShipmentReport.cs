// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;

[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class LateShipmentReport : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageLateShipmentReport()
    {
        TestInitialize(nameof(OpenPageLateShipmentReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateShipmentReport");
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
    public void ValidatePreviewBtnInLateShipmentReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInLateShipmentReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateShipmentReport");
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
    public void ValidateListBtnInLateShipmentReport()
    {
        TestInitialize(nameof(ValidateListBtnInLateShipmentReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateShipmentReport");
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
    public void ValidateExportPDFBtnInLateShipmentReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInLateShipmentReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateShipmentReport");
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
    public void ValidateExportExcelBtnInLateShipmentReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInLateShipmentReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateShipmentReport");
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
    public void ValidatePrinterBtnInLateShipmentReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInLateShipmentReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateShipmentReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInLateShipmentReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInLateShipmentReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateShipmentReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInLateShipmentReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInLateShipmentReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateShipmentReport");
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