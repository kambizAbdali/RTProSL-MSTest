// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Revenue;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Revenue")]
public class SpaceRevenueReport : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSpaceRevenueReport()
    {
        TestInitialize(nameof(OpenPageSpaceRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SpaceRevenueReport");
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
    public void ValidatePreviewBtnInSpaceRevenueReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSpaceRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SpaceRevenueReport");
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
    public void ValidateListBtnInSpaceRevenueReport()
    {
        TestInitialize(nameof(ValidateListBtnInSpaceRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SpaceRevenueReport");
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
    public void ValidateExportPDFBtnInSpaceRevenueReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSpaceRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SpaceRevenueReport");
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
    public void ValidateExportExcelBtnInSpaceRevenueReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSpaceRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SpaceRevenueReport");
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
    public void ValidatePrinterBtnInSpaceRevenueReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSpaceRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SpaceRevenueReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInSpaceRevenueReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSpaceRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SpaceRevenueReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInSpaceRevenueReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSpaceRevenueReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SpaceRevenueReport");
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