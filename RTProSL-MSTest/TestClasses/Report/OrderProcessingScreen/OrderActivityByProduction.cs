// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessingScreen
{
    [TestCategory("OrderProcessing")]
    [TestClass, TestCategory("OrderProcessing___Order")]
    public class OrderActivityByProduction : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidatePreviewBtnInOrderActivityByProduction()
        {
            TestInitialize(nameof(ValidatePreviewBtnInOrderActivityByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "ORDER_ACTIVITY_BY_PRODUCTION");
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
        public void ValidateListBtnInOrderActivityByProduction()
        {
            TestInitialize(nameof(ValidateListBtnInOrderActivityByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "ORDER_ACTIVITY_BY_PRODUCTION");
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
        public void ValidateExportPDFBtnInOrderActivityByProduction()
        {
            TestInitialize(nameof(ValidateExportPDFBtnInOrderActivityByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "ORDER_ACTIVITY_BY_PRODUCTION");
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
        public void ValidateExportExcelBtnInOrderActivityByProduction()
        {
            TestInitialize(nameof(ValidateExportExcelBtnInOrderActivityByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "ORDER_ACTIVITY_BY_PRODUCTION");
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
        public void ValidatePrinterBtnInOrderActivityByProduction()
        {
            TestInitialize(nameof(ValidatePrinterBtnInOrderActivityByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "ORDER_ACTIVITY_BY_PRODUCTION");
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
        public void ValidateExportPDFWithTemplateNamingBtnInOrderActivityByProduction()
        {
            TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInOrderActivityByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "ORDER_ACTIVITY_BY_PRODUCTION");
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
        public void ValidateExportPDFWithRandomNamingBtnInOrderActivityByProduction()
        {
            TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInOrderActivityByProduction));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "ORDER_ACTIVITY_BY_PRODUCTION");
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
