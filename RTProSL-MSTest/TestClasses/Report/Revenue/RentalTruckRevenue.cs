// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;

namespace RTProSL_MSTest.TestClasses.Report.Revenue;



[TestCategory("Report")]
[TestClass, TestCategory("Report___Revenue")]
public class RentalTruckRevenue : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRentalTruckRevenue()
    {
        TestInitialize(nameof(OpenPageRentalTruckRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Reports", "RentalTruckRevenue");
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
    public void ValidatePreviewBtnInRentalTruckRevenue()
    {
        TestInitialize(nameof(ValidatePreviewBtnInRentalTruckRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalTruckRevenue");
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
    public void ValidateListBtnInRentalTruckRevenue()
    {
        TestInitialize(nameof(ValidateListBtnInRentalTruckRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalTruckRevenue");
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
    public void ValidateExportPDFBtnInRentalTruckRevenue()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInRentalTruckRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalTruckRevenue");
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
    public void ValidateExportExcelBtnInRentalTruckRevenue()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInRentalTruckRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalTruckRevenue");
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
    public void ValidatePrinterBtnInRentalTruckRevenue()
    {
        TestInitialize(nameof(ValidatePrinterBtnInRentalTruckRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalTruckRevenue");
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
    public void ValidateExportPDFWithTemplateNamingBtnInRentalTruckRevenue()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInRentalTruckRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalTruckRevenue");
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
    public void ValidateExportPDFWithRandomNamingBtnInRentalTruckRevenue()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInRentalTruckRevenue));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "RentalTruckRevenue");
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