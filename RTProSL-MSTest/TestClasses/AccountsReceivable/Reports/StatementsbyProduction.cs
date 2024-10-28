// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.Reports;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___Reports")]
public class StatementsByProduction : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageStatementsByProduction()
    {
        TestInitialize(nameof(OpenPageStatementsByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "StatementsbyProduction");
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
    public void ValidatePreviewBtnInStatementsByProduction()
    {
        TestInitialize(nameof(ValidatePreviewBtnInStatementsByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "StatementsbyProduction");
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
    public void ValidateListBtnInStatementsByProduction()
    {
        TestInitialize(nameof(ValidateListBtnInStatementsByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "StatementsbyProduction");
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
    public void ValidateExportPDFBtnInStatementsByProduction()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInStatementsByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "StatementsbyProduction");
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
    public void ValidateExportExcelBtnInStatementsByProduction()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInStatementsByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "StatementsbyProduction");
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
    public void ValidatePrinterBtnInStatementsByProduction()
    {
        TestInitialize(nameof(ValidatePrinterBtnInStatementsByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "StatementsbyProduction");
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
    public void ValidateExportPDFWithTemplateNamingBtnInStatementsbyProduction()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInStatementsbyProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "StatementsbyProduction");
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
    public void ValidateExportPDFWithRandomNamingBtnInStatementsbyProduction()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInStatementsbyProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "StatementsbyProduction");
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