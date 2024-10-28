// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.FileMaintenance.BillingAR;
using static RTProSL_MSTest.ComponentHelper.Validation.ReportModel;

namespace RTProSL_MSTest.TestClasses.Report.Statistical;

[TestCategory("Report")]
[TestClass, TestCategory("Report___Statistical")]
public class ProjectedEquipmentUtilizationAnalysis : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageProjectedEquipmentUtilizationAnalysis()
    {
        TestInitialize(nameof(OpenPageProjectedEquipmentUtilizationAnalysis));


        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedEquipmentUtilizationAnalysis");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePreviewBtnInProjectedEquipmentUtilizationAnalysis()
    {
        TestInitialize(nameof(ValidatePreviewBtnInProjectedEquipmentUtilizationAnalysis));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedEquipmentUtilizationAnalysis");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Preview, stepReports: 3, reportStruct: new StructReport()
                {
                    InputStep1 = "currencyId",
                    ColId1Step2 = "quantity",
                    ColId2Step2 = "shipDate",
                    ColId3Step2 = "returnDate",
                    GridList = "projectedEquipmentUtilizationAnalysisKit-MiniGrid-gridId"
                });
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateListBtnInProjectedEquipmentUtilizationAnalysis()
    {
        TestInitialize(nameof(ValidateListBtnInProjectedEquipmentUtilizationAnalysis));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedEquipmentUtilizationAnalysis");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.List, stepReports: 3, reportStruct: new StructReport()
                {
                    InputStep1 = "currencyId",
                    ColId1Step2 = "quantity",
                    ColId2Step2 = "shipDate",
                    ColId3Step2 = "returnDate",
                    GridList = "projectedEquipmentUtilizationAnalysisKit-MiniGrid-gridId"
                });
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFBtnInProjectedEquipmentUtilizationAnalysis()
    {
        TestInitialize(nameof(ValidateExportPDFBtnInProjectedEquipmentUtilizationAnalysis));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedEquipmentUtilizationAnalysis");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, stepReports: 3, reportStruct: new StructReport()
                {
                    InputStep1 = "currencyId",
                    ColId1Step2 = "quantity",
                    ColId2Step2 = "shipDate",
                    ColId3Step2 = "returnDate",
                    GridList = "projectedEquipmentUtilizationAnalysisKit-MiniGrid-gridId"
                });
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportExcelBtnInProjectedEquipmentUtilizationAnalysis()
    {
        TestInitialize(nameof(ValidateExportExcelBtnInProjectedEquipmentUtilizationAnalysis));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedEquipmentUtilizationAnalysis");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Excel, stepReports: 3, reportStruct: new StructReport()
                {
                    InputStep1 = "currencyId",
                    ColId1Step2 = "quantity",
                    ColId2Step2 = "shipDate",
                    ColId3Step2 = "returnDate",
                    GridList = "projectedEquipmentUtilizationAnalysisKit-MiniGrid-gridId"
                });
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidatePrinterBtnInProjectedEquipmentUtilizationAnalysis()
    {
        TestInitialize(nameof(ValidatePrinterBtnInProjectedEquipmentUtilizationAnalysis));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedEquipmentUtilizationAnalysis");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.Printer, stepReports: 3, reportStruct: new StructReport()
                {
                    InputStep1 = "currencyId",
                    ColId1Step2 = "quantity",
                    ColId2Step2 = "shipDate",
                    ColId3Step2 = "returnDate",
                    GridList = "projectedEquipmentUtilizationAnalysisKit-MiniGrid-gridId"
                });
                report.ValidateReport();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithTemplateNamingBtnInProjectedEquipmentUtilizationAnalysis()
    {
        TestInitialize(nameof(ValidateExportPDFWithTemplateNamingBtnInProjectedEquipmentUtilizationAnalysis));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedEquipmentUtilizationAnalysis");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, stepReports: 3, reportStruct: new StructReport()
                {
                    InputStep1 = "currencyId",
                    ColId1Step2 = "quantity",
                    ColId2Step2 = "shipDate",
                    ColId3Step2 = "returnDate",
                    GridList = "projectedEquipmentUtilizationAnalysisKit-MiniGrid-gridId"
                });
                report.ValidateReport(ReportModel.ReportTypeEnum.Template);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateExportPDFWithRandomNamingBtnInProjectedEquipmentUtilizationAnalysis()
    {
        TestInitialize(nameof(ValidateExportPDFWithRandomNamingBtnInProjectedEquipmentUtilizationAnalysis));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Reports", "ProjectedEquipmentUtilizationAnalysis");
                ReportModel report = new ReportModel(ReportModel.ReportTypeEnum.PDF, stepReports: 3, reportStruct: new StructReport()
                {
                    InputStep1 = "currencyId",
                    ColId1Step2 = "quantity",
                    ColId2Step2 = "shipDate",
                    ColId3Step2 = "returnDate",
                    GridList = "projectedEquipmentUtilizationAnalysisKit-MiniGrid-gridId"
                });
                report.ValidateReport(ReportModel.ReportTypeEnum.Random);
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}