// Developed By Mohammad Keshavarz
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.RevenueGenerated;

[TestCategory("Report")]
[TestClass, TestCategory("Report___RevenueGenerated")]
public class RevGenReportParent : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRevGenReportMaster()
    {
        TestInitialize(nameof(OpenPageRevGenReportMaster));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportParent");
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
    public void ValidatePreviewBtnInRevGenReportParent()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRevGenReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportParent");
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
    public void ValidateListBtnInRevGenReportParent()
    {
        TestInitialize(nameof(ValidateListBtnInRevGenReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportParent");
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
    public void ValidateExportPDFBtnInRevGenReportParent()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRevGenReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportParent");
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
    public void ValidateExportExcelBtnInRevGenReportParent()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRevGenReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportParent");
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
    public void ValidatePrinterBtnInRevGenReportParent()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRevGenReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportParent");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRevGenReportParent()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRevGenReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportParent");
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
    public void ValidateExportPDFWithRandomNamingBtnInRevGenReportParent()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRevGenReportParent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportParent");
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