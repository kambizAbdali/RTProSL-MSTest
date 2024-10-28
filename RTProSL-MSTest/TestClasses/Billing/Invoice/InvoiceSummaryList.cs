// Developed By Mohammad Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Billing.Invoice;

[TestCategory("Invoice")]
[TestClass, TestCategory("Invoice___Billing")]

//*"InvoiceSummaryList" page name in parent submenu is "Invoice"*
public class InvoiceSummaryList : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInvoiceScreen()
    {
        TestInitialize(nameof(OpenPageInvoiceScreen));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "InvoiceSummaryList");

                Thread.Sleep(2000);

                RefreshAllRows();
                WaitForLoadingSpiner();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckInvoiceSummaryList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInvoiceSummaryList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // navigate 
                GoToUrl("Billing", "InvoiceSummaryList");
                RefreshAllRows();
                //call arrow
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckInvoiceSummaryList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInvoiceSummaryList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Currency List page 
                GoToUrl("Billing", "InvoiceSummaryList");
                RefreshAllRows();
                //call arrow
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInvoiceSummaryList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInvoiceSummaryList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Currency List page 
                GoToUrl("Billing", "InvoiceSummaryList");
                RefreshAllRows();
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
    public void ArrowLastBtnCheckInvoiceSummaryList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInvoiceSummaryList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to InvoiceSummaryList page 
                GoToUrl("Billing", "InvoiceSummaryList");
                RefreshAllRows();
                //call arrow
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByProduction()
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("productionId", "InvoiceListSummary-gridId", "Production", colId: "production");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByFirstInvoice()
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByFirstInvoice));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("firstInvoice", "InvoiceListSummary-gridId", "Production", colId: "production");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByLastInvoice()
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByLastInvoice));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("lastInvoice", "InvoiceListSummary-gridId", "Invoice#", colId: "invoiceId");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByOrder()
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByOrder));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("orderNo", "InvoiceListSummary-gridId", "Order#");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByPO()
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("po", "InvoiceListSummary-gridId", "PO#");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    //*-When this test method fails, it means that the method has been executed correctly and the specified value in the records has not been found.-*
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByExcludeInvoices() //Exclude $0.00 Invoices
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByExcludeInvoices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("excludeZeroInvoices", "InvoiceListSummary-gridId", "Total", colId: "total", replacementValue: "$0.00");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    //Status
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByInvoice()
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByInvoice));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("INVOICE");
                FilterSearch filterSearch = new FilterSearch("status.includeInvoice", "InvoiceListSummary-gridId", "Status", colId: "status");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByCredit()
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByCredit));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid  
                RefreshAllRows();
                DataLegendNameFilter("CREDIT");
                FilterSearch filterSearch = new FilterSearch("status.includeCredit", "InvoiceListSummary-gridId", "Status", colId: "status");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByDraft()
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByDraft));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("DRAFT");
                FilterSearch filterSearch = new FilterSearch("status.includeDraft", "InvoiceListSummary-gridId", "Status", colId: "status");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByPreview()
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByPreview));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("PREVIEW");
                FilterSearch filterSearch = new FilterSearch("status.includePreview", "InvoiceListSummary-gridId", "Status", colId: "status");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByVoid()
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByVoid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("VOID");
                FilterSearch filterSearch = new FilterSearch("status.includeVoid", "InvoiceListSummary-gridId", "Status", colId: "status");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByCreationDate()
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByCreationDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("beginDate", "InvoiceListSummary-gridId");
                filterSearch.FilterSearchInDateTimeDataType("beginDate", "endDate");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceSummaryListByBillingDate()
    {
        TestInitialize(nameof(FilterInvoiceSummaryListByBillingDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceSummaryList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("billBegDate", "InvoiceListSummary-gridId");
                filterSearch.FilterSearchInDateTimeDataType("beginDate", "endDate");
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
                GoToUrl("Billing", "InvoiceSummaryList");
                RefreshRecordDataInGrid("InvoiceListSummary-gridId", columnId: "invoiceId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}