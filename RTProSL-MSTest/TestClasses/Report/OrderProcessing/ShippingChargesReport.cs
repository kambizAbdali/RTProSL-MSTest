// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;

[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class ShippingChargesReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageShippingChargesReport()
    {
        TestInitialize(nameof(OpenPageShippingChargesReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Reports", "ShippingChargesReport");
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
    public void ValidatePreviewBtnInShippingChargesReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInShippingChargesReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ShippingChargesReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * (3 / 2))]
    public void ValidateListBtnInShippingChargesReport()
    {
        TestInitialize(nameof(ValidateListBtnInShippingChargesReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ShippingChargesReport");
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
    public void ValidateExportPDFBtnInShippingChargesReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInShippingChargesReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ShippingChargesReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * (3 / 2))]
    public void ValidateExportExcelBtnInShippingChargesReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInShippingChargesReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ShippingChargesReport");
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
    public void ValidatePrinterBtnInShippingChargesReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInShippingChargesReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ShippingChargesReport");
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
    public void ValidateExportPDFWithTemplateNamingBtnInShippingChargesReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInShippingChargesReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ShippingChargesReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInShippingChargesReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInShippingChargesReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ShippingChargesReport");
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