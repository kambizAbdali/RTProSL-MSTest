// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Revenue;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Revenue")]
public class CRMReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCRMReport()
    {
        TestInitialize(nameof(OpenPageCRMReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CRMReport");
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
    public void ValidatePreviewBtnInCRMReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCRMReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CRMReport");
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
    public void ValidateListBtnInCRMReport()
    {
        TestInitialize(nameof(ValidateListBtnInCRMReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CRMReport");
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
    public void ValidateExportPDFBtnInCRMReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCRMReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CRMReport");
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
    public void ValidateExportExcelBtnInCRMReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCRMReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CRMReport");
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
    public void ValidatePrinterBtnInCRMReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCRMReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CRMReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCRMReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCRMReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CRMReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInCRMReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCRMReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CRMReport");
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