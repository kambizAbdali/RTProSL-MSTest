// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessingScreen
{
    [TestCategory("OrderProcessing")]
    [TestClass, TestCategory("OrderProcessing___Order")]
    public class CheckinSheetByProduction : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidatePreviewBtnInCheckinSheetByProduction()
        {
            TestInitialize(nameof(ValidatePreviewBtnInCheckinSheetByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET_BY_PRODUCTION");
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
        public void ValidateListBtnInCheckinSheetByProduction()
        {
            TestInitialize(nameof(ValidateListBtnInCheckinSheetByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET_BY_PRODUCTION");
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
        public void ValidateExportPDFBtnInCheckinSheetByProduction()
        {
            TestInitialize(nameof(ValidateExportPDFBtnInCheckinSheetByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET_BY_PRODUCTION");
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
        public void ValidateExportExcelBtnInCheckinSheetByProduction()
        {
            TestInitialize(nameof(ValidateExportExcelBtnInCheckinSheetByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET_BY_PRODUCTION");
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
        public void ValidatePrinterBtnInCheckinSheetByProduction()
        {
            TestInitialize(nameof(ValidatePrinterBtnInCheckinSheetByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET_BY_PRODUCTION");
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
        public void ValidateExportPDFWithTemplateNamingBtnInCheckinSheetByProduction()
        {
            TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCheckinSheetByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET_BY_PRODUCTION");
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
        public void ValidateExportPDFWithRandomNamingBtnInCheckinSheetByProduction()
        {
            TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCheckinSheetByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET_BY_PRODUCTION");
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
