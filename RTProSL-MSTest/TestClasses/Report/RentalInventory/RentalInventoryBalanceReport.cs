// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.RentalInventory;

[TestCategory("Report")]
[TestClass, TestCategory("Report___RentalInventory")]
public class RentalInventoryBalanceReport : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalInventoryBalanceReport()
    {
        TestInitialize(nameof(OpenPageRentalInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Reports", "RentalInventoryBalanceReport");

                //var datepicker1 = webElementAction
                //    .GetElementByCssSelector(".range-component-wrapper > div:nth-of-type(1) .ant-picker-input");
                //datepicker1.Click();

                //Thread.Sleep(1000);

                //var btntodaydate1 =
                //    webElementAction.GetElementByCssSelector("[theme='dark'] > div:nth-of-type(3) .ant-picker-today-btn");

                //btntodaydate1.Click();


                //Thread.Sleep(1000);

                //var datepicker2 = webElementAction
                //    .GetElementByCssSelector(".range-component-wrapper > div:nth-of-type(2) .ant-picker-input");
                //datepicker2.Click();
                //var btntodaydate2 = webElementAction.GetElementByXPath(
                //    "//div[@class='ant-picker-dropdown date-picker-drop-down-common-style main-date-picker-dropdown ant-picker-dropdown-placement-bottomLeft ']//a[.='Today']");
                //btntodaydate2.Click();


                //Thread.Sleep(1000);

                //webElementAction.GetElementByXPath("//li[.='Preview']").Click();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInRentalInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRentalInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryBalanceReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, dataFormItemNameValue: "fromDate");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInRentalInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidateListBtnInRentalInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryBalanceReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, dataFormItemNameValue: "fromDate");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInRentalInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRentalInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryBalanceReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, dataFormItemNameValue: "fromDate");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInRentalInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRentalInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryBalanceReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, dataFormItemNameValue: "fromDate");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInRentalInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRentalInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryBalanceReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, dataFormItemNameValue: "fromDate");
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInRentalInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRentalInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryBalanceReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, dataFormItemNameValue: "fromDate");
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInRentalInventoryBalanceReport()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRentalInventoryBalanceReport));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalInventoryBalanceReport");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, dataFormItemNameValue: "fromDate");
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

}