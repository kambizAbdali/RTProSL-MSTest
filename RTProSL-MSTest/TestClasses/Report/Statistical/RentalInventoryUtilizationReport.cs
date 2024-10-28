// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Statistical;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Statistical")]
public class RentalStatReportByEquipmentOrderNoEstimated : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalStatReportByEquipmentOrderNoEstimated()
    {
        TestInitialize(nameof(OpenPageRentalStatReportByEquipmentOrderNoEstimated));


        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentOrderNo-Estimated");
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
    public void ValidatePreviewBtnInRentalStatReportByEquipmentOrderNoEstimatedt()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRentalStatReportByEquipmentOrderNoEstimatedt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentOrderNo-Estimated");
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
    public void ValidateListBtnInRentalStatReportByEquipmentOrderNoEstimatedt()
    {
        TestInitialize(nameof(ValidateListBtnInRentalStatReportByEquipmentOrderNoEstimatedt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentOrderNo-Estimated");
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
    public void ValidateExportPDFBtnInRentalStatReportByEquipmentOrderNoEstimatedt()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRentalStatReportByEquipmentOrderNoEstimatedt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentOrderNo-Estimated");
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
    public void ValidateExportExcelBtnInRentalStatReportByEquipmentOrderNoEstimatedt()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRentalStatReportByEquipmentOrderNoEstimatedt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentOrderNo-Estimated");
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
    public void ValidatePrinterBtnInRentalStatReportByEquipmentOrderNoEstimatedt()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRentalStatReportByEquipmentOrderNoEstimatedt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentOrderNo-Estimated");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRentalStatReportByEquipmentOrderNoEstimatedt()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRentalStatReportByEquipmentOrderNoEstimatedt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentOrderNo-Estimated");
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
    public void ValidateExportPDFWithRandomNamingBtnInRentalStatReportByEquipmentOrderNoEstimatedt()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRentalStatReportByEquipmentOrderNoEstimatedt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentOrderNo-Estimated");
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