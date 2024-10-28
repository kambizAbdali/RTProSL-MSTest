// Developed By Mohammad Keshavarz
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Subrental;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Subrental")]
public class SubrentalLimitReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSubrentalLimitReport()
    {
        TestInitialize(nameof(OpenPageSubrentalLimitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SubrentalLimitReport");

                Thread.Sleep(2000);

                webElementAction.GetElementByXPath("//li[.='Preview']").Click();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInSubrentalLimitReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSubrentalLimitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SubrentalLimitReport");
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
    public void ValidateListBtnInSubrentalLimitReport()
    {
        TestInitialize(nameof(ValidateListBtnInSubrentalLimitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SubrentalLimitReport");
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
    public void ValidateExportPDFBtnInSubrentalLimitReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSubrentalLimitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SubrentalLimitReport");
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
    public void ValidateExportExcelBtnInSubrentalLimitReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSubrentalLimitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SubrentalLimitReport");
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
    public void ValidatePrinterBtnInSubrentalLimitReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSubrentalLimitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SubrentalLimitReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInSubrentalLimitReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSubrentalLimitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SubrentalLimitReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInSubrentalLimitReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSubrentalLimitReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "SubrentalLimitReport");
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