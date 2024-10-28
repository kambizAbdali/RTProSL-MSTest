// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.EstimatedRevenue;

[TestCategory("Report")]
[TestClass, TestCategory("Report___EstimatedRevenue")]
public class ProjectedRentalRevenue : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageProjectedRentalRevenue()
    {
        TestInitialize(nameof(OpenPageProjectedRentalRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedRentalRevenue");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInProjectedRentalRevenue()
    {
        TestInitialize(nameof(ValidatePreviewBtnInProjectedRentalRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedRentalRevenue");
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
    public void ValidateListBtnInProjectedRentalRevenue()
    {
        TestInitialize(nameof(ValidateListBtnInProjectedRentalRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedRentalRevenue");
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
    public void ValidateExportPDFBtnInProjectedRentalRevenue()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInProjectedRentalRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedRentalRevenue");
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
    public void ValidateExportExcelBtnInProjectedRentalRevenue()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInProjectedRentalRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedRentalRevenue");
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
    public void ValidatePrinterBtnInProjectedRentalRevenue()
    {
        TestInitialize(nameof(ValidatePrinterBtnInProjectedRentalRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedRentalRevenue");
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
    public void ValidateExportPDFWithTemplateNamingBtnInProjectedRentalRevenue()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInProjectedRentalRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedRentalRevenue");
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
    public void ValidateExportPDFWithRandomNamingBtnInProjectedRentalRevenue()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInProjectedRentalRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedRentalRevenue");
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