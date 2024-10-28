// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.PaymentReports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___PaymentReports")]
public class RefundAdjustment : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageDailyDepositRefundAdjustment()
    {
        TestInitialize(nameof(OpenPageDailyDepositRefundAdjustment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "RefundAdjustment");
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
    public void ValidatePreviewBtnInRefundAdjustment()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRefundAdjustment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RefundAdjustment");
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
    public void ValidateListBtnInRefundAdjustment()
    {
        TestInitialize(nameof(ValidateListBtnInRefundAdjustment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RefundAdjustment");
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
    public void ValidateExportPDFBtnInRefundAdjustment()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRefundAdjustment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RefundAdjustment");
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
    public void ValidateExportExcelBtnInRefundAdjustment()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRefundAdjustment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RefundAdjustment");
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
    public void ValidatePrinterBtnInRefundAdjustment()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRefundAdjustment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RefundAdjustment");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRefundAdjustment()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRefundAdjustment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RefundAdjustment");
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
    public void ValidateExportPDFWithRandomNamingBtnInRefundAdjustment()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRefundAdjustment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RefundAdjustment");
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