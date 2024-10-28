// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessingScreen
{
    [TestCategory("OrderProcessing")]
    [TestClass, TestCategory("OrderProcessing___Order")]
    public class CheckinSheet : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidatePreviewBtnInCheckinSheet()
        {
            TestInitialize(nameof(ValidatePreviewBtnInCheckinSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET");
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
        public void ValidateListBtnInCheckinSheet()
        {
            TestInitialize(nameof(ValidateListBtnInCheckinSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET");
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
        public void ValidateExportPDFBtnInCheckinSheet()
        {
            TestInitialize(nameof(ValidateExportPDFBtnInCheckinSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET");
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
        public void ValidateExportExcelBtnInCheckinSheet()
        {
            TestInitialize(nameof(ValidateExportExcelBtnInCheckinSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET");
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
        public void ValidatePrinterBtnInCheckinSheet()
        {
            TestInitialize(nameof(ValidatePrinterBtnInCheckinSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET");
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
        public void ValidateExportPDFWithTemplateNamingBtnInCheckinSheet()
        {
            TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCheckinSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET");
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
        public void ValidateExportPDFWithRandomNamingBtnInCheckinSheet()
        {
            TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCheckinSheet));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "CHECKIN_SHEET");
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
