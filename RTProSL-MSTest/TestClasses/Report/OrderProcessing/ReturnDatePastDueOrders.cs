// Developed By Mohammad Keshavarz
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;
[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class ReturnDatePastDueOrders : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageReturnDatePastDueOrders()
    {
        TestInitialize(nameof(OpenPageReturnDatePastDueOrders));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ReturnDatePastDueOrders");
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
    public void ValidatePreviewBtnInReturnDatePastDueOrders()
    {
        TestInitialize(nameof(ValidatePreviewBtnInReturnDatePastDueOrders));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ReturnDatePastDueOrders");
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
    public void ValidateListBtnInReturnDatePastDueOrders()
    {
        TestInitialize(nameof(ValidateListBtnInReturnDatePastDueOrders));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ReturnDatePastDueOrders");
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
    public void ValidateExportPDFBtnInReturnDatePastDueOrders()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInReturnDatePastDueOrders));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ReturnDatePastDueOrders");
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
    public void ValidateExportExcelBtnInReturnDatePastDueOrders()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInReturnDatePastDueOrders));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ReturnDatePastDueOrders");
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
    public void ValidatePrinterBtnInReturnDatePastDueOrders()
    {
        TestInitialize(nameof(ValidatePrinterBtnInReturnDatePastDueOrders));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ReturnDatePastDueOrders");
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
    public void ValidateExportPDFWithTemplateNamingBtnInReturnDatePastDueOrders()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInReturnDatePastDueOrders));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ReturnDatePastDueOrders");
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
    public void ValidateExportPDFWithRandomNamingBtnInReturnDatePastDueOrders()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInReturnDatePastDueOrders));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ReturnDatePastDueOrders");
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