// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Statistical;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Statistical")]
public class RentalStatDetReportStatisticsDetailFormat2 : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalStatDetReportStatisticsDetailFormat2()
    {
        TestInitialize(nameof(OpenPageRentalStatDetReportStatisticsDetailFormat2));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatDetReportStatisticsDetail-Format2");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInRentalStatDetReportStatisticsDetailFormat2()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRentalStatDetReportStatisticsDetailFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatDetReportStatisticsDetail-Format2");
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
    public void ValidateListBtnInRentalStatDetReportStatisticsDetailFormat2()
    {
        TestInitialize(nameof(ValidateListBtnInRentalStatDetReportStatisticsDetailFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatDetReportStatisticsDetail-Format2");
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
    public void ValidateExportPDFBtnInRentalStatDetReportStatisticsDetailFormat2()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRentalStatDetReportStatisticsDetailFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatDetReportStatisticsDetail-Format2");
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
    public void ValidateExportExcelBtnInRentalStatDetReportStatisticsDetailFormat2()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRentalStatDetReportStatisticsDetailFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatDetReportStatisticsDetail-Format2");
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
    public void ValidatePrinterBtnInRentalStatDetReportStatisticsDetailFormat2()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRentalStatDetReportStatisticsDetailFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatDetReportStatisticsDetail-Format2");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRentalStatDetReportStatisticsDetailFormat2()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRentalStatDetReportStatisticsDetailFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatDetReportStatisticsDetail-Format2");
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
    public void ValidateExportPDFWithRandomNamingBtnInRentalStatDetReportStatisticsDetailFormat2()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRentalStatDetReportStatisticsDetailFormat2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatDetReportStatisticsDetail-Format2");
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