// Developed By Mohammad Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.Settings;
//using RTProSL_Test.TestClasses.Administration.Tables;
using SeleniumWebdriver.Settings;

namespace RTProSL_MSTest.TestClasses.Billing.Invoice;

[TestCategory("Invoice")]
[TestClass, TestCategory("Invoice___Billing")]

//*"InvoiceList" page name in parent submenu is "Invoice +"*
public class InvoiceList : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInvoiceList()
    {
        TestInitialize(nameof(OpenPageInvoiceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page Invoice List
                GoToUrl("Billing", "InvoiceList");

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
    public void ArrowNextBtnCheckInvoiceList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInvoiceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // navigate 
                GoToUrl("Billing", "InvoiceList");
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
    public void ArrowPreviousBtnCheckInvoiceList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInvoiceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Currency List page 
                GoToUrl("Billing", "InvoiceList");
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
    public void ArrowFirstBtnCheckArrowNextBtnCheckInvoiceList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckArrowNextBtnCheckInvoiceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Currency List page 
                GoToUrl("Billing", "InvoiceList");
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
    public void ArrowLastBtnCheckArrowNextBtnCheckInvoiceList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckArrowNextBtnCheckInvoiceList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");
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
    public void FilterInvoiceListByProduction()
    {
        TestInitialize(nameof(FilterInvoiceListByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("productionId", "InvoiceList-gridId", "Production", colId: "production");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceListByProject()
    {
        TestInitialize(nameof(FilterInvoiceListByProject));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("projectId", "InvoiceList-gridId", "Project", colId: "project");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceListByRentalAgentId()
    {
        TestInitialize(nameof(FilterInvoiceListByRentalAgentId));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("rentalAgentId", "InvoiceList-gridId", "Rental Agent", colId: "rentalAgent1");
                filterSearch.FilterSearchInTextDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceListByFirstInvoice()
    {
        TestInitialize(nameof(FilterInvoiceListByFirstInvoice));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("firstInvoice", "InvoiceList-gridId", "Production", colId: "production");
                filterSearch.FilterSearchInTextDataInGridDataType(secondColumnName: "Job");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceListByLastInvoice()
    {
        TestInitialize(nameof(FilterInvoiceListByLastInvoice));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("lastInvoice", "InvoiceList-gridId", "Invoice#", colId: "invoiceId");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceListByOrder()
    {
        TestInitialize(nameof(FilterInvoiceListByOrder));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();

                FilterSearch filterSearch = new FilterSearch("orderNo", "InvoiceList-gridId", "Order#");
                filterSearch.FilterSearchInTextDataInGridDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceListByPO()
    {
        TestInitialize(nameof(FilterInvoiceListByPO));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("po", "InvoiceList-gridId", "PO#");
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
    public void FilterInvoiceByExcludeInvoices() //Exclude $0.00 Invoices
    {
        TestInitialize(nameof(FilterInvoiceByExcludeInvoices));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("excludeZeroInvoices", "InvoiceList-gridId", "Total", colId: "total", replacementValue: "$0.00");
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
    public void FilterInvoiceListByInvoice()
    {
        TestInitialize(nameof(FilterInvoiceListByInvoice));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("INVOICE");
                FilterSearch filterSearch = new FilterSearch("status.includeInvoice", "InvoiceList-gridId", "Status", colId: "status");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceListByCredit()
    {
        TestInitialize(nameof(FilterInvoiceListByCredit));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid  
                RefreshAllRows();
                DataLegendNameFilter("CREDIT");
                FilterSearch filterSearch = new FilterSearch("status.includeCredit", "InvoiceList-gridId", "Status", colId: "status");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceListByDraft()
    {
        TestInitialize(nameof(FilterInvoiceListByDraft));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("DRAFT");
                FilterSearch filterSearch = new FilterSearch("status.includeDraft", "InvoiceList-gridId", "Status", colId: "status");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceListByPreview()
    {
        TestInitialize(nameof(FilterInvoiceListByPreview));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("PREVIEW");
                FilterSearch filterSearch = new FilterSearch("status.includePreview", "InvoiceList-gridId", "Status", colId: "status");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceListByVoid()
    {
        TestInitialize(nameof(FilterInvoiceListByVoid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                DataLegendNameFilter("VOID");
                FilterSearch filterSearch = new FilterSearch("status.includeVoid", "InvoiceList-gridId", "Status", colId: "status");
                filterSearch.FilterSearchInCheckBoxDataType();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceListByCreationDate()
    {
        TestInitialize(nameof(FilterInvoiceListByCreationDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("beginDate", "InvoiceList-gridId");
                filterSearch.FilterSearchInDateTimeDataType("beginDate", "endDate");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterInvoiceListByBillingDate()
    {
        TestInitialize(nameof(FilterInvoiceListByBillingDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "InvoiceList");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("billBegDate", "InvoiceList-gridId");
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
                GoToUrl("Billing", "InvoiceList");
                RefreshRecordDataInGrid("InvoiceList-gridId", columnId: "invoiceId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}