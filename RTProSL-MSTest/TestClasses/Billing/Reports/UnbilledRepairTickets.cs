// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.Reports;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Reports")]
public class UnBilledRepairTickets : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageUnbilledRepairTickets()
    {
        TestInitialize(nameof(OpenPageUnbilledRepairTickets));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "UnbilledRepairTickets");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInUnbilledRepairTickets()
    {
        TestInitialize(nameof(ValidatePreviewBtnInUnbilledRepairTickets));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "UnbilledRepairTickets");
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
    public void ValidateListBtnInUnbilledRepairTickets()
    {
        TestInitialize(nameof(ValidateListBtnInUnbilledRepairTickets));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "UnbilledRepairTickets");
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
    public void ValidateExportPDFBtnInUnbilledRepairTickets()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInUnbilledRepairTickets));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "UnbilledRepairTickets");
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
    public void ValidateExportExcelBtnInUnbilledRepairTickets()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInUnbilledRepairTickets));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "UnbilledRepairTickets");
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
    public void ValidatePrinterBtnInUnbilledRepairTickets()
    {
        TestInitialize(nameof(ValidatePrinterBtnInUnbilledRepairTickets));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "UnbilledRepairTickets");
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
    public void ValidateExportPDFWithTemplateNamingBtnInUnbilledRepairTickets()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInUnbilledRepairTickets));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UnbilledRepairTickets");
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
    public void ValidateExportPDFWithRandomNamingBtnInUnbilledRepairTickets()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInUnbilledRepairTickets));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "UnbilledRepairTickets");
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