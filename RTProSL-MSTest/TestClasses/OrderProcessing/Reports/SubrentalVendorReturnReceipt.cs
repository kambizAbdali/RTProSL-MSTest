// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.OrderProcessing.Reports;

[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___Reports")]
public class SubrentalVendorReturnReceipt : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSubrentalVendorReturnReceipt()
    {
        TestInitialize(nameof(OpenPageSubrentalVendorReturnReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMSubrentalVendorReturnReceipt");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInSubrentalVendorReturnReceipt()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSubrentalVendorReturnReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMSubrentalVendorReturnReceipt");
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
    public void ValidateListBtnInSubrentalVendorReturnReceipt()
    {
        TestInitialize(nameof(ValidateListBtnInSubrentalVendorReturnReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMSubrentalVendorReturnReceipt");
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
    public void ValidateExportPDFBtnInSubrentalVendorReturnReceipt()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSubrentalVendorReturnReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMSubrentalVendorReturnReceipt");
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
    public void ValidateExportExcelBtnInSubrentalVendorReturnReceipt()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSubrentalVendorReturnReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMSubrentalVendorReturnReceipt");
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
    public void ValidatePrinterBtnInSubrentalVendorReturnReceipt()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSubrentalVendorReturnReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMSubrentalVendorReturnReceipt");
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
    public void ValidateExportPDFWithTemplateNamingBtnInSubrentalVendorReturnReceipt()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSubrentalVendorReturnReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMSubrentalVendorReturnReceipt");
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
    public void ValidateExportPDFWithRandomNamingBtnInSubrentalVendorReturnReceipt()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSubrentalVendorReturnReceipt));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMSubrentalVendorReturnReceipt");
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