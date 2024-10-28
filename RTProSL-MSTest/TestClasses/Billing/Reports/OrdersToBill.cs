// Developed By Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Billing.Reports;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Reports")]
public class OrdersToBill : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageOrdersToBill()
    {
        TestInitialize(nameof(OpenPageOrdersToBill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BOrdersToBill");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                WaitForLoadingSpiner();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private string[] isGenerator =
    {
        "paymentTypeId","productionId"
    };

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInOrdersToBill()
    {
        TestInitialize(nameof(ValidatePreviewBtnInOrdersToBill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BOrdersToBill");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, isGenerateReport:isGenerator);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInOrdersToBill()
    {
        TestInitialize(nameof(ValidateListBtnInOrdersToBill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BOrdersToBill");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, isGenerateReport: isGenerator);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInOrdersToBill()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInOrdersToBill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BOrdersToBill");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: isGenerator);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInOrdersToBill()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInOrdersToBill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BOrdersToBill");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, isGenerateReport: isGenerator);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInOrdersToBill()
    {
        TestInitialize(nameof(ValidatePrinterBtnInOrdersToBill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "BOrdersToBill");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, isGenerateReport: isGenerator);
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInBOrdersToBill()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInBOrdersToBill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BOrdersToBill");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: isGenerator);
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInBOrdersToBill()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInBOrdersToBill));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "BOrdersToBill");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, isGenerateReport: isGenerator);
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}