//develop by Mohammad_keshvarz

using RTProSL_MSTest.ComponentHelper;
using System.Drawing;

namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Subrental;

[TestCategory("PurchaseOrder")]
[TestClass, TestCategory("PurchaseOrder___Subrental")]
public class BilledAccrualsList : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckOrderProcessing()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckOrderProcessing));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "BilledAccrualsList");
                ShowAllRedord();
                //call method arrowFirstBtn
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckOrderProcessing()
    {
        TestInitialize(nameof(ArrowLastBtnCheckOrderProcessing));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "BilledAccrualsList");
                ShowAllRedord();
                Thread.Sleep(1000);
                //call method arrowlastbtn
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckOrderProcessing()
    {
        TestInitialize(nameof(ArrowNextBtnCheckOrderProcessing));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "BilledAccrualsList");
                ShowAllRedord();
                // call method NextBtn
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckOrderProcessing()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckOrderProcessing));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "BilledAccrualsList");
                ShowAllRedord();
                //call arrow previous
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    Dictionary<string, Color> ColorDict =
        new Dictionary<string, Color>()
        {
            {"White", Color.FromArgb(228, 228, 228)},
            {"Turquoise", Color.FromArgb(0, 255, 255)},
            {"Green", Color.FromArgb(0, 255, 0)},
        };

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterBilledAccrualsListByVendorType()
    {
        TestInitialize(nameof(FilterBilledAccrualsListByVendorType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledAccrualsList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("vendorTypeId", "BilledAccruals-gridId", "Vendor Type");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterBilledAccrualsListByVendor()
    {
        TestInitialize(nameof(FilterBilledAccrualsListByVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledAccrualsList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("vendorId", "BilledAccruals-gridId", "Vendor");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterBilledAccrualsListByPO()
    {
        TestInitialize(nameof(FilterBilledAccrualsListByPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledAccrualsList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("poId", "BilledAccruals-gridId", "PO#");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterBilledAccrualsListBySeparateAccrualsPriortoDateRange()
    {
        TestInitialize(nameof(FilterBilledAccrualsListBySeparateAccrualsPriortoDateRange));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledAccrualsList");

                RefreshAllRows();
                DataLegendNameFilter("PRIOR_TO_BEGIN_DATE");
                FilterSearch filterSearch = new FilterSearch("separateAccrualsPriorToDateRange", "BilledAccruals-gridId", "Type", colId:"type",Color: ColorDict["White"]);
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterBilledAccrualsListBySeparateBySubrentalReason()
    {
        TestInitialize(nameof(FilterBilledAccrualsListBySeparateBySubrentalReason));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledAccrualsList");

                RefreshAllRows();
                DataLegendNameFilter("NOT_BILLED_TO_PRODUCTION");
                FilterSearch filterSearch = new FilterSearch("separateNotBilledToProduction", "BilledAccruals-gridId", "Type", colId:"type", Color: ColorDict["Turquoise"]);
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterBilledAccrualsListBySeparateNotBilledtoProduction()
    {
        TestInitialize(nameof(FilterBilledAccrualsListBySeparateNotBilledtoProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledAccrualsList");

                RefreshAllRows();
                DataLegendNameFilter("SUBRENTAL_REASON");
                FilterSearch filterSearch = new FilterSearch("separateAccrualsPriorToDateRange", "BilledAccruals-gridId", "Type", colId: "type", Color: ColorDict["Green"]);
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "BilledAccrualsList");
                RefreshRecordDataInGrid("BilledAccruals-gridId", columnId: "vendorId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}