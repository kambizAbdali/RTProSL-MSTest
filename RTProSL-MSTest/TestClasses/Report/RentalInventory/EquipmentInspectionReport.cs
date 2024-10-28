// Developed By Parsa Zakeri

using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;
using SeleniumWebdriver.Settings;
using static RTProSL_MSTest.TestClasses.Report.RentalInventory.EquipmentInspectionReport;

namespace RTProSL_MSTest.TestClasses.Report.RentalInventory;



[TestCategory("Report")]
[TestClass, TestCategory("Report___RentalInventory")]
public class EquipmentInspectionReport : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageEquipmentInspectionReport()
    {
        TestInitialize(nameof(OpenPageEquipmentInspectionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentInspectionReport");

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
    public void ValidatePreviewBtnInEquipmentInspectionReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInEquipmentInspectionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentInspectionReport");
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
    public void ValidateListBtnInEquipmentInspectionReport()
    {
        TestInitialize(nameof(ValidateListBtnInEquipmentInspectionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentInspectionReport");
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
    public void ValidateExportPDFBtnInEquipmentInspectionReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInEquipmentInspectionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentInspectionReport");
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
    public void ValidateExportExcelBtnInEquipmentInspectionReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInEquipmentInspectionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentInspectionReport");
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
    public void ValidatePrinterBtnInEquipmentInspectionReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInEquipmentInspectionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentInspectionReport");
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
    public void PinNewScheduleInEquipmentInspectionReport()
    {
        TestInitialize(nameof(PinNewScheduleInEquipmentInspectionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentInspectionReport");

                Thread.Sleep(2000);
                
                if (!webElementAction.IsElementPresent(By.CssSelector(".toolsbox-pinned-items-wrapper > div")))
                {
                    webElementAction.Click(By.Id("SCHEDULE_TOOL_DROPDOWN"));

                    webElementAction.MoveMouseToElement(webElementAction.GetElementByCssSelector(".toolsboxLabel .ellipsis-content"));

                    Thread.Sleep(300);

                    webElementAction.Click(By.CssSelector("#SCHEDULE_TOOL_DROPDOWN .ant-dropdown-menu .icon-pin"));

                    webElementAction.Click(By.Id("SCHEDULE_TOOL_DROPDOWN"));
                }

                if (!webElementAction.IsElementPresent(By.CssSelector(".toolsbox-pinned-items-wrapper > div")))
                    Assert.Fail("tools box pinned is not deleted");

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInEquipmentInspectionReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInEquipmentInspectionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentInspectionReport");
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
    public void ValidateExportPDFWithRandomNamingBtnInEquipmentInspectionReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInEquipmentInspectionReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "EquipmentInspectionReport");
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