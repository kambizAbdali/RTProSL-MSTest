//develop by KambizAbdali

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Administration.Security_Setup
{
    [TestCategory("Administration")]
    [TestClass, TestCategory("Administration___SecuritySetup")]
    public class SecuritySetup : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void CollapseAllValidate()
        {
            TestInitialize(nameof(CollapseAllValidate));

            while (!testPassed && retryCount < maxRetries)
            {
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");

                    // Expand all nodes if there's only one polygon icon  
                    if (ExpandAllNodesIfNeeded())
                    {
                        Assert.IsTrue(ValidateExpansion(), "Error:__ Expand polygon icon doesn't work correctly.");
                    }

                    var iconPolygonRightCountBeforeCollaps = webElementAction.GetAllElementsByCssSelector(".icon-polygon-right").Count;
                    CollapseAllNodes();

                    Assert.IsTrue(ValidateCollapse(iconPolygonRightCountBeforeCollaps), "Error:__ Collapse icon doesn't work correctly.");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
            }
        }

        private bool ExpandAllNodesIfNeeded()
        {
            var iconPolygonRightElements = webElementAction.GetAllElementsByCssSelector(".icon-polygon-right");
            if (iconPolygonRightElements.Count() > 0)
            {
                iconPolygonRightElements[0].Click(); // Expand all  
                return true;
            }
            return false;
        }

        private bool ValidateExpansion()
        {
            var iconPolygonRightElements = webElementAction.GetAllElementsByCssSelector(".icon-polygon-right");
            return iconPolygonRightElements.Count() > 1; // Should be greater than one after expansion  
        }

        private void CollapseAllNodes()
        {
            var collapseIconElement = webElementAction.GetElementByCssSelector(".icon-collapse");
            collapseIconElement.Click(); // Collapse all expanded nodes of the tree  
        }

        private bool ValidateCollapse(int iconPolygonRightCountBeforeCollaps)
        {
            var iconPolygonRightElements = webElementAction.GetAllElementsByCssSelector(".icon-polygon-right");
            return iconPolygonRightElements.Count() <= iconPolygonRightCountBeforeCollaps; // Should be less after collapse  
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateSecuritySetupTableReport()
        {
            TestInitialize(nameof(ValidateSecuritySetupTableReport));
            while (!testPassed && retryCount < maxRetries)
            {
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview);
                    report.ValidateReportSubMenu(menu: "SECURITY_SETUP_PRINT", subMenu: "SECURITY_REPORT");

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
            }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidatePreviewBtnInSecuritySetupTableNewSecurityOptions()
        {
            TestInitialize(nameof(ValidatePreviewBtnInSecuritySetupTableNewSecurityOptions));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "NEW_SECURITY_OPTIONS");
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
        public void ValidateListBtnInSecuritySetupTableNewSecurityOptions()
        {
            TestInitialize(nameof(ValidateListBtnInSecuritySetupTableNewSecurityOptions));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "NEW_SECURITY_OPTIONS");
                    ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List);
                    report.ValidateReport();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        [TestMethod, Timeout(MaximumExecutionTime * 3)]
        public void ValidateExportPDFBtnInSecuritySetupTableNewSecurityOptions()
        {
            TestInitialize(nameof(ValidateExportPDFBtnInSecuritySetupTableNewSecurityOptions));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "NEW_SECURITY_OPTIONS");
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
        public void ValidateExportExcelBtnInSecuritySetupTableNewSecurityOptions()
        {
            TestInitialize(nameof(ValidateExportExcelBtnInSecuritySetupTableNewSecurityOptions));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "NEW_SECURITY_OPTIONS");
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
        public void ValidatePrinterBtnInSecuritySetupTableNewSecurityOptions()
        {
            TestInitialize(nameof(ValidatePrinterBtnInSecuritySetupTableNewSecurityOptions));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "NEW_SECURITY_OPTIONS");
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
        public void ValidateExportPDFWithTemplateNamingBtnInSecuritySetupTableNewSecurityOptions()
        {
            TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSecuritySetupTableNewSecurityOptions));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "NEW_SECURITY_OPTIONS");
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
        public void ValidateExportPDFWithRandomNamingBtnInSecuritySetupTableNewSecurityOptions()
        {
            TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSecuritySetupTableNewSecurityOptions));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "NEW_SECURITY_OPTIONS");
                    ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF);
                    report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        //------------------------------------------------------------------------------------------------


        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidatePreviewBtnInSecuritySetupTableSecurityReportUserColumns()
        {
            TestInitialize(nameof(ValidatePreviewBtnInSecuritySetupTableSecurityReportUserColumns));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "SECURITY_REPORT_USER_COLUMNS");
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
        public void ValidateListBtnInSecuritySetupTableSecurityReportUserColumns()
        {
            TestInitialize(nameof(ValidateListBtnInSecuritySetupTableSecurityReportUserColumns));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "SECURITY_REPORT_USER_COLUMNS");
                    ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List);
                    report.ValidateReport();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        [TestMethod, Timeout(MaximumExecutionTime * 3)]
        public void ValidateExportPDFBtnInSecuritySetupTableSecurityReportUserColumns()
        {
            TestInitialize(nameof(ValidateExportPDFBtnInSecuritySetupTableSecurityReportUserColumns));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "SECURITY_REPORT_USER_COLUMNS");
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
        public void ValidateExportExcelBtnInSecuritySetupTableSecurityReportUserColumns()
        {
            TestInitialize(nameof(ValidateExportExcelBtnInSecuritySetupTableSecurityReportUserColumns));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "SECURITY_REPORT_USER_COLUMNS");
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
        public void ValidatePrinterBtnInSecuritySetupTableSecurityReportUserColumns()
        {
            TestInitialize(nameof(ValidatePrinterBtnInSecuritySetupTableSecurityReportUserColumns));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "SECURITY_REPORT_USER_COLUMNS");
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
        public void ValidateExportPDFWithTemplateNamingBtnInSecuritySetupTableSecurityReportUserColumns()
        {
            TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInSecuritySetupTableSecurityReportUserColumns));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "SECURITY_REPORT_USER_COLUMNS");
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
        public void ValidateExportPDFWithRandomNamingBtnInSecuritySetupTableSecurityReportUserColumns()
        {
            TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInSecuritySetupTableSecurityReportUserColumns));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "SecuritySetupTable");
                    GoToSubMenu("SECURITY_SETUP_PRINT", "SECURITY_REPORT_USER_COLUMNS");
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