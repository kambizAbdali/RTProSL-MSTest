// Developed By Parsa Zakeri
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.DataLayer;

namespace RTProSL_MSTest.TestClasses.Inventory.Depreciation
{
    [TestCategory("Inventory")]
    [TestClass, TestCategory("Inventory___Depreciation")]
    public class EquipmentDepreciationReport : BaseClass
    {


        [TestMethod, Timeout(MaximumExecutionTime)]
        public async Task OpenPageEquipmentDepreciationReport()
        {
            TestInitialize(nameof(OpenPageEquipmentDepreciationReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    Login();
                    //await UpdateSetup.SetUseDeprec("1");
                    GoToUrl("MMInventory", "EquipmentDepreciationReport", gotoLogin: false);

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidatePreviewBtnInEquipmentDepreciationReport()
        {
            TestInitialize(nameof(ValidatePreviewBtnInEquipmentDepreciationReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "EquipmentDepreciationReport");
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
        public void ValidateListBtnInEquipmentDepreciationReport()
        {
            TestInitialize(nameof(ValidateListBtnInEquipmentDepreciationReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "EquipmentDepreciationReport");
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
        public void ValidateExportPDFBtnInEquipmentDepreciationReport()
        {
            TestInitialize(nameof(ValidateExportPDFBtnInEquipmentDepreciationReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "EquipmentDepreciationReport");
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
        public void ValidateExportExcelBtnInEquipmentDepreciationReport()
        {
            TestInitialize(nameof(ValidateExportExcelBtnInEquipmentDepreciationReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "EquipmentDepreciationReport");
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
        public void ValidatePrinterBtnInEquipmentDepreciationReport()
        {
            TestInitialize(nameof(ValidatePrinterBtnInEquipmentDepreciationReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "EquipmentDepreciationReport");
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
        public void ValidateExportPDFWithTemplateNamingBtnInEquipmentDepreciationReport()
        {
            TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInEquipmentDepreciationReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "EquipmentDepreciationReport");
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
        public void ValidateExportPDFWithRandomNamingBtnInEquipmentDepreciationReport()
        {
            TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInEquipmentDepreciationReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MMInventory", "EquipmentDepreciationReport");
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
