// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.Reports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___Reports")]
public class AgingDetailByDate : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageAgingDetailByDate()
    {
        TestInitialize(nameof(OpenPageAgingDetailByDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingDetailbyDate");
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
    public void ValidatePreviewBtnInAgingDetailByDate()
    {
        TestInitialize(nameof(ValidatePreviewBtnInAgingDetailByDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingDetailbyDate");
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
    public void ValidateListBtnInAgingDetailByDate()
    {
        TestInitialize(nameof(ValidateListBtnInAgingDetailByDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingDetailbyDate");
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
    public void ValidateExportPDFBtnInAgingDetailByDate()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInAgingDetailByDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingDetailbyDate");
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
    public void ValidateExportExcelBtnInAgingDetailByDate()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInAgingDetailByDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingDetailbyDate");
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
    public void ValidatePrinterBtnInAgingDetailByDate()
    {
        TestInitialize(nameof(ValidatePrinterBtnInAgingDetailByDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingDetailbyDate");
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
    public void ValidateExportPDFWithTemplateNamingBtnInAgingDetailbyDate()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInAgingDetailbyDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AgingDetailbyDate");
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
    public void ValidateExportPDFWithRandomNamingBtnInAgingDetailbyDate()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInAgingDetailbyDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AgingDetailbyDate");
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