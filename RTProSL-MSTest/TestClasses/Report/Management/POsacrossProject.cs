// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Management;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Management")]
public class POsacrossProject : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPagePOsacrossProject()
    {
        TestInitialize(nameof(OpenPagePOsacrossProject));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POsacrossProject");
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
    public void ValidatePreviewBtnInPOsacrossProject()
    {
        TestInitialize(nameof(ValidatePreviewBtnInPOsacrossProject));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POsacrossProject");
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
    public void ValidateListBtnInPOsacrossProject()
    {
        TestInitialize(nameof(ValidateListBtnInPOsacrossProject));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POsacrossProject");
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
    public void ValidateExportPDFBtnInPOsacrossProject()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInPOsacrossProject));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POsacrossProject");
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
    public void ValidateExportExcelBtnInPOsacrossProject()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInPOsacrossProject));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POsacrossProject");
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
    public void ValidatePrinterBtnInPOsacrossProject()
    {
        TestInitialize(nameof(ValidatePrinterBtnInPOsacrossProject));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POsacrossProject");
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
    public void ValidateExportPDFWithTemplateNamingBtnInPOsacrossProject()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInPOsacrossProject));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POsacrossProject");
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
    public void ValidateExportPDFWithRandomNamingBtnInPOsacrossProject()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInPOsacrossProject));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "POsacrossProject");
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