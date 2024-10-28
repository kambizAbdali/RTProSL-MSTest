// Developed By Mohammad Keshavarz
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;

[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class LateReturnReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageLateReturnReport()
    {
        TestInitialize(nameof(OpenPageLateReturnReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateReturnReport");

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
    public void ValidatePreviewBtnInLateReturnReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInLateReturnReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateReturnReport");
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
    public void ValidateListBtnInLateReturnReport()
    {
        TestInitialize(nameof(ValidateListBtnInLateReturnReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateReturnReport");
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
    public void ValidateExportPDFBtnInLateReturnReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInLateReturnReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateReturnReport");
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
    public void ValidateExportExcelBtnInLateReturnReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInLateReturnReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateReturnReport");
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
    public void ValidatePrinterBtnInLateReturnReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInLateReturnReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateReturnReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInLateReturnReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInLateReturnReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateReturnReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInLateReturnReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInLateReturnReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "LateReturnReport");
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