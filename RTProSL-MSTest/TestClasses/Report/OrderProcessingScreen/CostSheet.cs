// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessingScreen
{
    [TestCategory("OrderProcessing")]
    [TestClass, TestCategory("OrderProcessing___Order")]
    public class CostSheet : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidatePreviewBtnInCostSheet()
        {
            TestInitialize(nameof(ValidatePreviewBtnInCostSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "COST_SHEET");
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
        public void ValidateListBtnInCostSheet()
        {
            TestInitialize(nameof(ValidateListBtnInCostSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "COST_SHEET");
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
        public void ValidateExportPDFBtnInCostSheet()
        {
            TestInitialize(nameof(ValidateExportPDFBtnInCostSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "COST_SHEET");
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
        public void ValidateExportExcelBtnInCostSheet()
        {
            TestInitialize(nameof(ValidateExportExcelBtnInCostSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "COST_SHEET");
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
        public void ValidatePrinterBtnInCostSheet()
        {
            TestInitialize(nameof(ValidatePrinterBtnInCostSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "COST_SHEET");
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
        public void ValidateExportPDFWithTemplateNamingBtnInCostSheet()
        {
            TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCostSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "COST_SHEET");
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
        public void ValidateExportPDFWithRandomNamingBtnInCostSheet()
        {
            TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCostSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "COST_SHEET");
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
