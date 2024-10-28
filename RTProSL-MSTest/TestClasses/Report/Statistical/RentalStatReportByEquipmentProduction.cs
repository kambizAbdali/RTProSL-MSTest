// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Statistical;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Statistical")]
public class RentalStatReportByEquipmentProduction : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalStatReportByEquipmentProduction()
    {
        TestInitialize(nameof(OpenPageRentalStatReportByEquipmentProduction));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentProduction");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInRentalStatReportByEquipmentProduction()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRentalStatReportByEquipmentProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentProduction");
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
    public void ValidateListBtnInRentalStatReportByEquipmentProduction()
    {
        TestInitialize(nameof(ValidateListBtnInRentalStatReportByEquipmentProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentProduction");
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
    public void ValidateExportPDFBtnInRentalStatReportByEquipmentProduction()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRentalStatReportByEquipmentProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentProduction");
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
    public void ValidateExportExcelBtnInRentalStatReportByEquipmentProduction()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRentalStatReportByEquipmentProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentProduction");
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
    public void ValidatePrinterBtnInRentalStatReportByEquipmentProduction()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRentalStatReportByEquipmentProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentProduction");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRentalStatReportByEquipmentProduction()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRentalStatReportByEquipmentProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentProduction");
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
    public void ValidateExportPDFWithRandomNamingBtnInRentalStatReportByEquipmentProduction()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRentalStatReportByEquipmentProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalStatReportByEquipmentProduction");
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