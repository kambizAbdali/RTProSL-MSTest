// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Subrental;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Subrental")]
public class SalesOnHandReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCurrentSubrentalReport()
    {
        TestInitialize(nameof(OpenPageCurrentSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentSubrentalReport");
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
    public void ValidatePreviewBtnInCurrentSubrentalReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCurrentSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentSubrentalReport");
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
    public void ValidateListBtnInCurrentSubrentalReport()
    {
        TestInitialize(nameof(ValidateListBtnInCurrentSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentSubrentalReport");
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
    public void ValidateExportPDFBtnInCurrentSubrentalReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCurrentSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentSubrentalReport");
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
    public void ValidateExportExcelBtnInCurrentSubrentalReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCurrentSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentSubrentalReport");
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
    public void ValidatePrinterBtnInCurrentSubrentalReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCurrentSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentSubrentalReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCurrentSubrentalReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCurrentSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentSubrentalReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInCurrentSubrentalReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCurrentSubrentalReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CurrentSubrentalReport");
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