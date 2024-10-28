// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Report;

[TestCategory("PurchaseOrder")]
[TestClass, TestCategory("PurchaseOrder___Report")]
public class SubrentalBalanceDetail : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSubrentalBalanceDetail()
    {
        TestInitialize(nameof(OpenPageSubrentalBalanceDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalBalanceDetail");
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
    public void ValidatePreviewBtnInSubrentalBalanceDetail()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSubrentalBalanceDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalBalanceDetail");
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
    public void ValidateListBtnInSubrentalBalanceDetail()
    {
        TestInitialize(nameof(ValidateListBtnInSubrentalBalanceDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalBalanceDetail");
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
    public void ValidateExportPDFBtnInSubrentalBalanceDetail()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSubrentalBalanceDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalBalanceDetail");
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
    public void ValidateExportExcelBtnInSubrentalBalanceDetail()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSubrentalBalanceDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalBalanceDetail");
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
    public void ValidatePrinterBtnInSubrentalBalanceDetail()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSubrentalBalanceDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalBalanceDetail");
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
    public void ValidateExportPDFWithTemplateNamingBtnInSubrentalBalanceDetail()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSubrentalBalanceDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "SubrentalBalanceDetail");
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
    public void ValidateExportPDFWithRandomNamingBtnInSubrentalBalanceDetail()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSubrentalBalanceDetail));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "SubrentalBalanceDetail");
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