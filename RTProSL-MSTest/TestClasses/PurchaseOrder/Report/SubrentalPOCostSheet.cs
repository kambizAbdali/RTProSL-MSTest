// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Report;

[TestCategory("PurchaseOrder")]
[TestClass, TestCategory("PurchaseOrder___Report")]
public class SubrentalPOCostSheet : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSubrentalPOCostSheet()
    {
        TestInitialize(nameof(OpenPageSubrentalPOCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPOCostSheet");
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
    public void ValidatePreviewBtnInSubrentalPOCostSheet()
    {
        TestInitialize(nameof(ValidatePreviewBtnInSubrentalPOCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPOCostSheet");
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
    public void ValidateListBtnInSubrentalPOCostSheet()
    {
        TestInitialize(nameof(ValidateListBtnInSubrentalPOCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPOCostSheet");
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
    public void ValidateExportPDFBtnInSubrentalPOCostSheet()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInSubrentalPOCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPOCostSheet");
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
    public void ValidateExportExcelBtnInSubrentalPOCostSheet()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInSubrentalPOCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPOCostSheet");
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
    public void ValidatePrinterBtnInSubrentalPOCostSheet()
    {
        TestInitialize(nameof(ValidatePrinterBtnInSubrentalPOCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPOCostSheet");
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
    public void ValidateExportPDFWithTemplateNamingBtnInSubrentalPOCostSheet()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSubrentalPOCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "SubrentalPOCostSheet");
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
    public void ValidateExportPDFWithRandomNamingBtnInSubrentalPOCostSheet()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSubrentalPOCostSheet));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "SubrentalPOCostSheet");
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