//Developd Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Management;
    public class MultipleRate : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageMultipleRate()
    {
        TestInitialize(nameof(OpenPageMultipleRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "TaxLiability");
                Thread.Sleep(2000);

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
    public void ValidatePreviewBtnInMultipleRate()
    {
        TestInitialize(nameof(ValidatePreviewBtnInMultipleRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "TaxLiability");
                Thread.Sleep(2000);
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
    public void ValidateListBtnInMultipleRate()
    {
        TestInitialize(nameof(ValidateListBtnInMultipleRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "TaxLiability");
                Thread.Sleep(2000);
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
    public void ValidateExportPDFBtnInMultipleRate()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInMultipleRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "TaxLiability");
                Thread.Sleep(2000);
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
    public void ValidateExportExcelBtnInMultipleRate()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInMultipleRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "TaxLiability");
                Thread.Sleep(2000);
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
    public void ValidatePrinterBtnInMultipleRate()
    {
        TestInitialize(nameof(ValidatePrinterBtnInMultipleRate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "TaxLiability");
                Thread.Sleep(2000);
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
    public void ValidateExportPDFWithTemplateNamingBtnInTaxLiability()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInTaxLiability));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "TaxLiability");
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
    public void ValidateExportPDFWithRandomNamingBtnInTaxLiability()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInTaxLiability));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "TaxLiability");
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

