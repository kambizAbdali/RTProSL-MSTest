// Developed By Parsa Zakeri

using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;

namespace RTProSL_MSTest.TestClasses.Report.OrderProcessingScreen
{
    [TestCategory("OrderProcessing")]
    [TestClass, TestCategory("OrderProcessing___Order")]
    public class SubrentalPOPullListReport : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidatePreviewBtnInSubrentalPOPullListReport()
        {
            TestInitialize(nameof(ValidatePreviewBtnInSubrentalPOPullListReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "SUBRENTAL_PO_PULL_LIST");
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
        public void ValidateListBtnInSubrentalPOPullListReport()
        {
            TestInitialize(nameof(ValidateListBtnInSubrentalPOPullListReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "SUBRENTAL_PO_PULL_LIST");
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
        public void ValidateExportPDFBtnInSubrentalPOPullListReport()
        {
            TestInitialize(nameof(ValidateExportPDFBtnInSubrentalPOPullListReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "SUBRENTAL_PO_PULL_LIST");
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
        public void ValidateExportExcelBtnInSubrentalPOPullListReport()
        {
            TestInitialize(nameof(ValidateExportExcelBtnInSubrentalPOPullListReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    WaitForLoadingSpiner();
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "SUBRENTAL_PO_PULL_LIST");
                    WaitForLoadingSpiner();
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
        public void ValidatePrinterBtnInSubrentalPOPullListReport()
        {
            TestInitialize(nameof(ValidatePrinterBtnInSubrentalPOPullListReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "SUBRENTAL_PO_PULL_LIST");
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
        public void ValidateExportPDFWithTemplateNamingBtnInSubrentalPOPullListReport()
        {
            TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSubrentalPOPullListReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "SUBRENTAL_PO_PULL_LIST");
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
        public void ValidateExportPDFWithRandomNamingBtnInSubrentalPOPullListReport()
        {
            TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSubrentalPOPullListReport));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("OrderProcessing", "OrderProcessingScreen");
                    GoToSubMenu("PRINT_TOOL_DROPDOWN", "SUBRENTAL_PO_PULL_LIST");
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
