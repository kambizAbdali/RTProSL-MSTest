// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.Reports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___Reports")]
public class AgingDetailByProduction : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageAgingDetailByProduction()
    {
        TestInitialize(nameof(OpenPageAgingDetailByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingDetailbyProduction");
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
    public void ValidatePreviewBtnInAgingDetailByProduction()
    {
        TestInitialize(nameof(ValidatePreviewBtnInAgingDetailByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingDetailbyProduction");
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
    public void ValidateListBtnInAgingDetailByProduction()
    {
        TestInitialize(nameof(ValidateListBtnInAgingDetailByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingDetailbyProduction");
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
    public void ValidateExportPDFBtnInAgingDetailByProduction()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInAgingDetailByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingDetailbyProduction");
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
    public void ValidateExportExcelBtnInAgingDetailByProduction()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInAgingDetailByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingDetailbyProduction");
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
    public void ValidatePrinterBtnInAgingDetailByProduction()
    {
        TestInitialize(nameof(ValidatePrinterBtnInAgingDetailByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "AgingDetailbyProduction");
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
    public void ValidateExportPDFWithTemplateNamingBtnInAgingDetailbyProduction()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInAgingDetailbyProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AgingDetailbyProduction");
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
    public void ValidateExportPDFWithRandomNamingBtnInAgingDetailbyProduction()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInAgingDetailbyProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "AgingDetailbyProduction");
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