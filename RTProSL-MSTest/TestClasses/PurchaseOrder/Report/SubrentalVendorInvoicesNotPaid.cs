// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Report;

[TestCategory("PurchaseOrder")]
[TestClass, TestCategory("PurchaseOrder___Report")]
public class SubrentalVendorInvoicesNotPaid : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSubrentalVendorInvoicesNotPaid()
    {
        TestInitialize(nameof(OpenPageSubrentalVendorInvoicesNotPaid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalVendorInvoicesNotPaid");
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
    public void ValidatePreviewBtnInSubrentalVendorInvoicesNotPaid()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSubrentalVendorInvoicesNotPaid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalVendorInvoicesNotPaid");
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
    public void ValidateListBtnInSubrentalVendorInvoicesNotPaid()
    {
        TestInitialize(nameof(ValidateListBtnInSubrentalVendorInvoicesNotPaid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalVendorInvoicesNotPaid");
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
    public void ValidateExportPDFBtnInSubrentalVendorInvoicesNotPaid()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSubrentalVendorInvoicesNotPaid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalVendorInvoicesNotPaid");
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
    public void ValidateExportExcelBtnInSubrentalVendorInvoicesNotPaid()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSubrentalVendorInvoicesNotPaid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalVendorInvoicesNotPaid");
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
    public void ValidatePrinterBtnInSubrentalVendorInvoicesNotPaid()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSubrentalVendorInvoicesNotPaid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalVendorInvoicesNotPaid");
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
    public void ValidateExportPDFWithTemplateNamingBtnInSubrentalVendorInvoicesNotPaid()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSubrentalVendorInvoicesNotPaid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "SubrentalVendorInvoicesNotPaid");
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
    public void ValidateExportPDFWithRandomNamingBtnInSubrentalVendorInvoicesNotPaid()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSubrentalVendorInvoicesNotPaid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "SubrentalVendorInvoicesNotPaid");
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