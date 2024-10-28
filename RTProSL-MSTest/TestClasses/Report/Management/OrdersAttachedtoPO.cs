// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Management;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Management")]
public class OrdersAttachedtoPO : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageOrdersAttachedtoPO()
    {
        TestInitialize(nameof(OpenPageOrdersAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersAttachedtoPO");
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
    public void ValidatePreviewBtnInOrdersAttachedtoPO()
    {
        TestInitialize(nameof(ValidatePreviewBtnInOrdersAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersAttachedtoPO");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, dataFormItemNameValue: "productionId");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInOrdersAttachedtoPO()
    {
        TestInitialize(nameof(ValidateListBtnInOrdersAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersAttachedtoPO");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, dataFormItemNameValue: "productionId");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInOrdersAttachedtoPO()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInOrdersAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersAttachedtoPO");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, dataFormItemNameValue: "productionId");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInOrdersAttachedtoPO()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInOrdersAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersAttachedtoPO");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel , dataFormItemNameValue: "productionId");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInOrdersAttachedtoPO()
    {
        TestInitialize(nameof(ValidatePrinterBtnInOrdersAttachedtoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrdersAttachedtoPO");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, dataFormItemNameValue: "productionId");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInOrderLogReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInOrderLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderLogReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, dataFormItemNameValue: "productionId");
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInOrderLogReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInOrderLogReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderLogReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, dataFormItemNameValue: "productionId");
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}