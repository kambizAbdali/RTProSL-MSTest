// Developed By Mohammad Keshavarz
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.RevenueGenerated;

[TestCategory("Report")]
[TestClass, TestCategory("Report___RevenueGenerated")]
public class RevGenReportCustomField2 : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRevGenReportCustomField2()

    {
        TestInitialize(nameof(OpenPageRevGenReportCustomField2));


        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportCustomField2");
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
    public void ValidatePreviewBtnInRevGenReportCustomField2()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRevGenReportCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportCustomField2");
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
    public void ValidateListBtnInRevGenReportCustomField2()
    {
        TestInitialize(nameof(ValidateListBtnInRevGenReportCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportCustomField2");
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
    public void ValidateExportPDFBtnInRevGenReportCustomField2()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRevGenReportCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportCustomField2");
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
    public void ValidateExportExcelBtnInRevGenReportCustomField2()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRevGenReportCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportCustomField2");
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
    public void ValidatePrinterBtnInRevGenReportCustomField2()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRevGenReportCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportCustomField2");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRevGenReportCustomField2()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRevGenReportCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportCustomField2");
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
    public void ValidateExportPDFWithRandomNamingBtnInRevGenReportCustomField2()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRevGenReportCustomField2));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RevGenReportCustomField2");
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