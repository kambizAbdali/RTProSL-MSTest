//develop by Mohammad_keshvarz

using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.PurchaseOrder.Subrental;

[TestCategory("PurchaseOrder")]
[TestClass, TestCategory("PurchaseOrder___Subrental")]
public class SubrentalPOInvoiceList : BaseClass
{


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckOrderProcessing()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckOrderProcessing));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "SubrentalPOInvoiceList");
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
    public void ArrowLastBtnCheckOrderProcessing()
    {
        TestInitialize(nameof(ArrowLastBtnCheckOrderProcessing));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "SubrentalPOInvoiceList");
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
    public void ArrowNextBtnCheckOrderProcessing()
    {
        TestInitialize(nameof(ArrowNextBtnCheckOrderProcessing));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "SubrentalPOInvoiceList");
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
    public void ArrowPreviousBtnCheckOrderProcessing()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckOrderProcessing));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("PurchaseOrder", "SubrentalPOInvoiceList");
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
    public void FilterSubrentalPOInvoiceByFromToDate()
    {
        TestInitialize(nameof(FilterSubrentalPOInvoiceByFromToDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPOInvoiceList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("beginDate", "SubrentalPOInvoiceList-gridId");
                filterSearch.FilterSearchInDateTimeDataType("beginDate" , "endDate");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOInvoiceByPO()
    {
        TestInitialize(nameof(FilterSubrentalPOInvoiceByPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPOInvoiceList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("poId", "SubrentalPOInvoiceList-gridId", "PO");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterSubrentalPOInvoiceByVendor()
    {
        TestInitialize(nameof(FilterSubrentalPOInvoiceByVendor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("PurchaseOrder", "SubrentalPOInvoiceList");

                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("vendorId", "SubrentalPOInvoiceList-gridId", "Vendor Code");
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
                GoToUrl("PurchaseOrder", "SubrentalPOInvoiceList");
                RefreshRecordDataInGrid("SubrentalPOInvoiceList-gridId", columnId: "vendorId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}