// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Management;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Management")]
public class UserLoginHistory : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageUserLoginHistory()
    {
        TestInitialize(nameof(OpenPageUserLoginHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UserLoginHistory");
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
    public void ValidatePreviewBtnInUserLoginHistory()
    {
        TestInitialize(nameof(ValidatePreviewBtnInUserLoginHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UserLoginHistory");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * (3 / 2))]
    public void ValidateListBtnInUserLoginHistory()
    {
        TestInitialize(nameof(ValidateListBtnInUserLoginHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UserLoginHistory");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime * (3 / 2))]
    public void ValidateExportPDFBtnInUserLoginHistory()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInUserLoginHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UserLoginHistory");
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
    public void ValidateExportExcelBtnInUserLoginHistory()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInUserLoginHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UserLoginHistory");
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
    public void ValidatePrinterBtnInUserLoginHistory()
    {
        TestInitialize(nameof(ValidatePrinterBtnInUserLoginHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UserLoginHistory");
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
    public void ValidateExportPDFWithTemplateNamingBtnInUserLoginHistory()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInUserLoginHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UserLoginHistory");
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
    public void ValidateExportPDFWithRandomNamingBtnInUserLoginHistory()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInUserLoginHistory));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UserLoginHistory");
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