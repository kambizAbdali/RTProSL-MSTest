// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Management;



[TestCategory("Report")]
[TestClass, TestCategory("Report___Management")]
public class CheckoutCheckinQuantityReport : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCheckoutCheckinQuantityReport()
    {
        TestInitialize(nameof(OpenPageCheckoutCheckinQuantityReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CheckoutCheckinQuantityReport");
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
    public void ValidatePreviewBtnInCheckoutCheckinQuantityReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCheckoutCheckinQuantityReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CheckoutCheckinQuantityReport");
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
    public void ValidateListBtnInCheckoutCheckinQuantityReport()
    {
        TestInitialize(nameof(ValidateListBtnInCheckoutCheckinQuantityReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CheckoutCheckinQuantityReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime *3)]
    public void ValidateExportPDFBtnInCheckoutCheckinQuantityReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCheckoutCheckinQuantityReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CheckoutCheckinQuantityReport");
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
    public void ValidateExportExcelBtnInCheckoutCheckinQuantityReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCheckoutCheckinQuantityReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CheckoutCheckinQuantityReport");
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
    public void ValidatePrinterBtnInCheckoutCheckinQuantityReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCheckoutCheckinQuantityReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CheckoutCheckinQuantityReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCheckoutCheckinQuantityReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCheckoutCheckinQuantityReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CheckoutCheckinQuantityReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInCheckoutCheckinQuantityReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCheckoutCheckinQuantityReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CheckoutCheckinQuantityReport");
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