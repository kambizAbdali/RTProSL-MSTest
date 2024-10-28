// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.PaymentReports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___PaymentReports")]
public class CashReceipt : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCashReceipt()
    {
        TestInitialize(nameof(OpenPageCashReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "CashReceipt");
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
    public void ValidatePreviewBtnInCashReceipt()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCashReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceipt");
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
    public void ValidateListBtnInCashReceipt()
    {
        TestInitialize(nameof(ValidateListBtnInCashReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceipt");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * 3)]
    public void ValidateExportPDFBtnInCashReceipt()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCashReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceipt");
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
    public void ValidateExportExcelBtnInCashReceipt()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCashReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceipt");
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
    public void ValidatePrinterBtnInCashReceipt()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCashReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceipt");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCashReceipt()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCashReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceipt");
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
    public void ValidateExportPDFWithRandomNamingBtnInCashReceipt()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCashReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CashReceipt");
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