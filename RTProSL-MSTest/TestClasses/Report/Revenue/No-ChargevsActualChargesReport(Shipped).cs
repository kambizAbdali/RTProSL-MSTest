// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Revenue;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Revenue")]
public class NoChargeVsActualChargesReportShipped : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageNoChargeVsActualChargesReportShipped()
    {
        TestInitialize(nameof(OpenPageNoChargeVsActualChargesReportShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "No-ChargevsActualChargesReport(Shipped)");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                WaitForLoadingSpiner();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    string[] isGenerateReport = { "productionId" };

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInNoChargeVsActualChargesReportShipped()
    {
        TestInitialize(nameof(ValidatePreviewBtnInNoChargeVsActualChargesReportShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "No-ChargevsActualChargesReport(Shipped)");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInNoChargeVsActualChargesReportShipped()

    {
        TestInitialize(nameof(ValidateListBtnInNoChargeVsActualChargesReportShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "No-ChargevsActualChargesReport(Shipped)");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInNoChargeVsActualChargesReportShipped()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInNoChargeVsActualChargesReportShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "No-ChargevsActualChargesReport(Shipped)");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInNoChargeVsActualChargesReportShipped()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInNoChargeVsActualChargesReportShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "No-ChargevsActualChargesReport(Shipped)");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInNoChargeVsActualChargesReportShipped()
    {
        TestInitialize(nameof(ValidatePrinterBtnInNoChargeVsActualChargesReportShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "No-ChargevsActualChargesReport(Shipped)");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, isGenerateReport: isGenerateReport);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInNoChargeVsActualChargesReportShipped()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInNoChargeVsActualChargesReportShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "No-ChargevsActualChargesReport(Shipped)");
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
    public void ValidateExportPDFWithRandomNamingBtnInNoChargeVsActualChargesReportShipped()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInNoChargeVsActualChargesReportShipped));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "No-ChargevsActualChargesReport(Shipped)");
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