// Developed By Mohammad Keshavarz

using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.FileMaintenance.Dispatch;
using static RTProSL_MSTest.BussinessTestClasses.OrderProcessing.OrderProcessingScreen.EquipmentCheckOutInAndBilling;

namespace RTProSL_MSTest.TestClasses.Report.Subrental;



[TestCategory("Report")]
//[TestClass, TestCategory("Report___Subrental")] // This report (CostSheetbyProduction) removed beacuse equals with SalesCostSheetbyProduction.
public class CostSheetbyProduction : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCostSheetbyProduction()
    {
        TestInitialize(nameof(OpenPageCostSheetbyProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostSheetbyProduction");
                webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInCostSheetbyProduction()
    {
        TestInitialize(nameof(ValidatePreviewBtnInCostSheetbyProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostSheetbyProduction");
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
    public void ValidateListBtnInCostSheetbyProduction()
    {
        TestInitialize(nameof(ValidateListBtnInCostSheetbyProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostSheetbyProduction");
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
    public void ValidateExportPDFBtnInCostSheetbyProduction()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInCostSheetbyProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostSheetbyProduction");
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
    public void ValidateExportExcelBtnInCostSheetbyProduction()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInCostSheetbyProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostSheetbyProduction");
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
    public void ValidatePrinterBtnInCostSheetbyProduction()
    {
        TestInitialize(nameof(ValidatePrinterBtnInCostSheetbyProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostSheetbyProduction");
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
    public void ValidateExportPDFWithTemplateNamingBtnInCostSheetbyProduction()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInCostSheetbyProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostSheetbyProduction");
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
    public void ValidateExportPDFWithRandomNamingBtnInCostSheetbyProduction()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInCostSheetbyProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "CostSheetbyProduction");
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