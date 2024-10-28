// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Management;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Management")]
public class OrderswithNoPO : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageOrderswithNoPO()
    {
        TestInitialize(nameof(OpenPageOrderswithNoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderswithNoPO");
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
    public void ValidatePreviewBtnInOrderswithNoPO()
    {
        TestInitialize(nameof(ValidatePreviewBtnInOrderswithNoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderswithNoPO");
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
    public void ValidateListBtnInOrderswithNoPO()
    {
        TestInitialize(nameof(ValidateListBtnInOrderswithNoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderswithNoPO");
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
    public void ValidateExportPDFBtnInOrderswithNoPO()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInOrderswithNoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderswithNoPO");
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
    public void ValidateExportExcelBtnInOrderswithNoPO()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInOrderswithNoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderswithNoPO");
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
    public void ValidatePrinterBtnInOrderswithNoPO()
    {
        TestInitialize(nameof(ValidatePrinterBtnInOrderswithNoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderswithNoPO");
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
    public void ValidateExportPDFWithTemplateNamingBtnInOrderswithNoPO()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInOrderswithNoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderswithNoPO");
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
    public void ValidateExportPDFWithRandomNamingBtnInOrderswithNoPO()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInOrderswithNoPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "OrderswithNoPO");
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