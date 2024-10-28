// Developed By Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Inventory.Depreciation
{
    [TestCategory("Inventory")]
    [TestClass, TestCategory("Inventory___Depreciation")]
    public class DepreciationExpenseReport : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageDepreciationExpenseReport()
        {
            TestInitialize(nameof(OpenPageDepreciationExpenseReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    Login();
                    //await UpdateSetup.SetUseDeprec("1");
                    GoToUrl("MMInventory", "DepreciationExpenseReport", gotoLogin: false);

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidatePreviewBtnInDepreciationExpenseReport()
        {
            TestInitialize(nameof(ValidatePreviewBtnInDepreciationExpenseReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "DepreciationExpenseReport");
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
        public void ValidateListBtnInDepreciationExpenseReport()
        {
            TestInitialize(nameof(ValidateListBtnInDepreciationExpenseReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "DepreciationExpenseReport");
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
        public void ValidateExportPDFBtnInDepreciationExpenseReport()
        {
            TestInitialize(nameof(ValidateExportPDFBtnInDepreciationExpenseReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "DepreciationExpenseReport");
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
        public void ValidateExportExcelBtnInDepreciationExpenseReport()
        {
            TestInitialize(nameof(ValidateExportExcelBtnInDepreciationExpenseReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "DepreciationExpenseReport");
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
        public void ValidatePrinterBtnInDepreciationExpenseReport()
        {
            TestInitialize(nameof(ValidatePrinterBtnInDepreciationExpenseReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "DepreciationExpenseReport");
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
        public void ValidateExportPDFWithTemplateNamingBtnInDepreciationExpenseReport()
        {
            TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInDepreciationExpenseReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "DepreciationExpenseReport");
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
        public void ValidateExportPDFWithRandomNamingBtnInDepreciationExpenseReport()
        {
            TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInDepreciationExpenseReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "DepreciationExpenseReport");
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
}