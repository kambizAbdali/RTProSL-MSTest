// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessing;

[TestCategory("Report")]
[TestClass, TestCategory("Report___OrderProcessing")]
public class OrdersExpectedtoReturn : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageOrdersExpectedtoReturn()
    {
        TestInitialize(nameof(OpenPageOrdersExpectedtoReturn));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersExpectedtoReturn");
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
    public void ValidatePreviewBtnInOrdersExpectedtoReturn()
    {
        TestInitialize(nameof(ValidatePreviewBtnInOrdersExpectedtoReturn));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersExpectedtoReturn");
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
    public void ValidateListBtnInOrdersExpectedtoReturn()
    {
        TestInitialize(nameof(ValidateListBtnInOrdersExpectedtoReturn));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersExpectedtoReturn");
                Thread.Sleep(2000);
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
    public void ValidateExportPDFBtnInOrdersExpectedtoReturn()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInOrdersExpectedtoReturn));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersExpectedtoReturn");
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
    public void ValidateExportExcelBtnInOrdersExpectedtoReturn()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInOrdersExpectedtoReturn));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersExpectedtoReturn");
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
    public void ValidatePrinterBtnInOrdersExpectedtoReturn()
    {
        TestInitialize(nameof(ValidatePrinterBtnInOrdersExpectedtoReturn));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersExpectedtoReturn");
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
    public void ValidateExportPDFWithTemplateNamingBtnInOrdersExpectedtoReturn()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInOrdersExpectedtoReturn));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersExpectedtoReturn");
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
    public void ValidateExportPDFWithRandomNamingBtnInOrdersExpectedtoReturn()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInOrdersExpectedtoReturn));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersExpectedtoReturn");
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