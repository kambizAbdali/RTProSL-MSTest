//develop by Mohammad_keshvarz

using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Subrental;

[TestCategory("PurchaseOrder")]
[TestClass, TestCategory("PurchaseOrder___Subrental")]
public class SubrentalPODetailList : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInSubrentalPODetailList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInSubrentalPODetailList));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");
                RefreshAllRows();
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
    public void ArrowLastBtnCheckInSubrentalPODetailList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInSubrentalPODetailList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");
                RefreshAllRows();
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
    public void ArrowNextBtnCheckInSubrentalPODetailList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInSubrentalPODetailList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");
                RefreshAllRows();
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
    public void ArrowPreviousBtnCheckInSubrentalPODetailList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInSubrentalPODetailList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");
                RefreshAllRows();
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

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPODetailListByFromToDate()
    {
        TestInitialize(nameof(FilterSubrentalPODetailListByFromToDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("beginDate", "SubrentalPODetailList-gridId");
                filterSearch.FilterSearchInDateTimeDataType("createDate");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPODetailListByProduction
        ()
    {
        TestInitialize(nameof(FilterSubrentalPODetailListByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("productionId", "SubrentalPODetailList-gridId", "Production", colId: "production");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPODetailListByOrder()
    {
        TestInitialize(nameof(FilterSubrentalPODetailListByOrder));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("orderNo", "SubrentalPODetailList-gridId", "Order", colId: "order");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPODetailListByVendor()
    {
        TestInitialize(nameof(FilterSubrentalPODetailListByVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("vendorId", "SubrentalPODetailList-gridId", "Vendor", colId: "vendor");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPODetailListByDescription()
    {
        TestInitialize(nameof(FilterSubrentalPODetailListByDescription));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("description", "SubrentalPODetailList-gridId", "Equipment Description" ,colId: "equipmentDescription");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPODetailListByEquipment()
    {
        TestInitialize(nameof(FilterSubrentalPODetailListByEquipment));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("equipmentList", "SubrentalPODetailList-gridId", "Equipment", colId: "equipment");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPODetailListByApprovedBy()
    {
        TestInitialize(nameof(FilterSubrentalPODetailListByApprovedBy));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("approvedById", "SubrentalPODetailList-gridId", "Approved By", colId: "approvedBy");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPODetailListByVendorType()
    {
        TestInitialize(nameof(FilterSubrentalPODetailListByVendorType));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("vendorTypeId", "SubrentalPODetailList-gridId", "Vendor Type" ,colId: "vendorType");
                filterSearch.FilterSearchInTextDataType();
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
                GoToUrl("PurchaseOrder", "SubrentalPODetailList");
                RefreshRecordDataInGrid("SubrentalPODetailList-gridId", columnId: "po");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}