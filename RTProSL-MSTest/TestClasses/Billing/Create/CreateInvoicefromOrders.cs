// Developed By Mohammad Keshavarz

using NLog.Filters;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.TestClasses.Administration.Tables;
namespace RTProSL_MSTest.TestClasses.Billing.Create;

[TestCategory("Billing")]
[TestClass, TestCategory("Billing___Create")]
public class CreateInvoicefromOrders : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageCreateInvoiceFromOrders()
    {
        TestInitialize(nameof(OpenPageCreateInvoiceFromOrders));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "CreateInvoicefromOrders");

                RefreshAllRows();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    //[TestMethod, Timeout(MaximumExecutionTime)]
    //public void ArrowNextBtnCheckGLDistribution()
    //{
    //    TestInitialize(nameof(ArrowNextBtnCheckGLDistribution));
    //    while (!testPassed && retryCount < maxRetries)
    //        try
    //        {
    //            // navigate 
    //            GoToGLDistributionFunc();
    //            RefreshAllRows();
    //            //call arrow
    //            ArrowNextBtn();
    //            testPassed = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            HandleTestFailure(ex.Message);
    //        }
    //}

    //[TestMethod, Timeout(MaximumExecutionTime)]
    //public void ArrowPreviousBtnCheckGLDistribution()
    //{
    //    TestInitialize(nameof(ArrowPreviousBtnCheckGLDistribution));
    //    while (!testPassed && retryCount < maxRetries)
    //        try
    //        {
    //            //call Login Method
    //            GoToLogin();

    //            //navigate to Currency List page 
    //            GoToGLDistributionFunc();
    //            RefreshAllRows();
    //            //call arrow
    //            ArrowPreviousBtn();
    //            testPassed = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            HandleTestFailure(ex.Message);
    //        }
    //}

    //[TestMethod, Timeout(MaximumExecutionTime)]
    //public void ArrowFirstBtnCheckArrowNextBtnCheckGLDistribution()
    //{
    //    TestInitialize(nameof(ArrowFirstBtnCheckArrowNextBtnCheckGLDistribution));
    //    while (!testPassed && retryCount < maxRetries)
    //        try
    //        {
    //            //call Login Method
    //            GoToLogin();

    //            //navigate to Currency List page 
    //            GoToGLDistributionFunc();
    //            RefreshAllRows();
    //            //call method arrowFirstBtn
    //            ArrowFirstBtn();
    //            testPassed = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            HandleTestFailure(ex.Message);
    //        }
    //}

    //[TestMethod, Timeout(MaximumExecutionTime)]
    //public void ArrowLastBtnCheckArrowNextBtnCheckGLDistribution()
    //{
    //    TestInitialize(nameof(ArrowLastBtnCheckArrowNextBtnCheckGLDistribution));
    //    while (!testPassed && retryCount < maxRetries)
    //        try
    //        {
    //            //call Login Method
    //            GoToLogin();

    //            //navigate to Currency List page 
    //            GoToGLDistributionFunc();
    //            RefreshAllRows();
    //            //call arrow
    //            ArrowLastBtn();
    //            testPassed = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            HandleTestFailure(ex.Message);
    //        }
    //}

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterCreateInvoiceFromOrdersByProduction()
    {
        TestInitialize(nameof(FilterCreateInvoiceFromOrdersByProduction));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "CreateInvoicefromOrders");

                FilterSearchCreateInvoiceFromOrders("productionId", DataType.Text, "OrdersToBillList-gridId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterCreateInvoiceFromOrdersByEndDate() // Filter As Of Date
    {
        TestInitialize(nameof(FilterCreateInvoiceFromOrdersByEndDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "CreateInvoicefromOrders");

                FilterSearchCreateInvoiceFromOrders("productionId", DataType.Text, "OrdersToBillList-gridId");

                FilterSearch filterSearch = new FilterSearch("InputDate2", "OrdersToBillList-gridId");
                filterSearch.FilterSearchInDateTimeDataType("begDate", "endDate");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterCreateInvoiceFromOrdersByRentalAgent()
    {
        TestInitialize(nameof(FilterCreateInvoiceFromOrdersByRentalAgent));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "CreateInvoicefromOrders");

                FilterSearchCreateInvoiceFromOrders("rentalAgentId", DataType.Text, "OrdersToBillList-gridId", "Rental Agent", "rentalAgent");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    //Billing Charges
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterCreateInvoiceFromOrdersByRentals()
    {
        TestInitialize(nameof(FilterCreateInvoiceFromOrdersByRentals));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "CreateInvoicefromOrders");

                FilterSearchCreateInvoiceFromOrders("BillType.rentals", DataType.CheckBox, "OrdersToBillList-gridId", "Rentals", "rentals");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterCreateInvoiceFromOrdersBySales()
    {
        TestInitialize(nameof(FilterCreateInvoiceFromOrdersBySales));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "CreateInvoicefromOrders");

                FilterSearchCreateInvoiceFromOrders("BillType.sales", DataType.CheckBox, "OrdersToBillList-gridId", "Sales", "sales");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterCreateInvoiceFromOrdersByLoss()
    {
        TestInitialize(nameof(FilterCreateInvoiceFromOrdersByLoss));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "CreateInvoicefromOrders");

                FilterSearchCreateInvoiceFromOrders("BillType.loss", DataType.CheckBox, "OrdersToBillList-gridId", "Loss", "loss");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterCreateInvoiceFromOrdersByLabor()
    {
        TestInitialize(nameof(FilterCreateInvoiceFromOrdersByLabor));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "CreateInvoicefromOrders");

                FilterSearchCreateInvoiceFromOrders("BillType.labor", DataType.CheckBox, "OrdersToBillList-gridId", "Labor", "labor");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterCreateInvoiceFromOrdersByShipping()
    {
        TestInitialize(nameof(FilterCreateInvoiceFromOrdersByShipping));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "CreateInvoicefromOrders");

                FilterSearchCreateInvoiceFromOrders("BillType.shipping", DataType.CheckBox, "OrdersToBillList-gridId", "Shipping", "shipping");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterCreateInvoiceFromOrdersByDamage()
    {
        TestInitialize(nameof(FilterCreateInvoiceFromOrdersByDamage));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "CreateInvoicefromOrders");

                FilterSearchCreateInvoiceFromOrders("BillType.damage", DataType.CheckBox, "OrdersToBillList-gridId", "Damage", "damage");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterCreateInvoiceFromOrdersBySpace()
    {
        TestInitialize(nameof(FilterCreateInvoiceFromOrdersBySpace));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "CreateInvoicefromOrders");

                FilterSearchCreateInvoiceFromOrders("BillType.space", DataType.CheckBox, "OrdersToBillList-gridId", "Space", "space");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterCreateInvoiceFromOrdersByRestocking()
    {
        TestInitialize(nameof(FilterCreateInvoiceFromOrdersByRestocking));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "CreateInvoicefromOrders");

                FilterSearchCreateInvoiceFromOrders("BillType.restocking", DataType.CheckBox, "OrdersToBillList-gridId", "Restocking", "restocking");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
    public void FilterSearchCreateInvoiceFromOrders(string id, DataType dataType, string gridId, string ColumnName = default, string colId = default, string findValueCH = default)
    {
        if (ColumnName != default) FindColumnInMainGrid(ColumnName);
        switch (dataType)
        {
            case DataType.Text:
                //click on btn filter
                if (!webElementAction.GetElementBySpecificAttribute("data-form-name", "OrdersToBillListBodyFilterForm").Displayed)
                    webElementAction.GetElementBySpecificAttribute("data-icon-name", "filter").Click();

                //generate value on input element
                var Context = webElementAction.GetElementBySpecificAttribute("data-form-item-name", id);
                new WebElementDataGenerator(Context);

                if (webElementAction.GetInputElementByDataFormItemNameInDiv(id).GetAttribute("productionId") == null)
                {
                    var ContextProduction = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "productionId");
                    new WebElementDataGenerator(ContextProduction);
                }
                //find in value to input
                string valueInModalFilter =
                    webElementAction.GetInputElementByDataFormItemNameInDiv(id).GetAttribute("value");

                //Refresh filter in grid
                RefreshAllRows();

                //Find value in grid
                var gridLisInput = webElementAction.GetElementById(gridId);
                gridLisInput.FindElements(By.TagName("div"));
                Thread.Sleep(3000);

                if (colId != default)
                    id = colId;

                var colIdsInput =
                    gridLisInput.FindElements(By.TagName("div")).Where(o => o.GetAttribute("col-id") == id).ToList();

                if (colIdsInput.Count() == 2) break; // If no row exists, we have at least two col-ids: one for the column title and the another for the footer.

                for (int i = 1; i < colIdsInput.Count() - 1; i++) // (always first and last colIds are empty)
                {
                    string a = colIdsInput[i].Text;
                    if (colIdsInput[i].Text != valueInModalFilter)
                    {
                        throw new Exception("Doesn't match inserted filter value ('" + valueInModalFilter + "') with showed row in Grid ('" + colIdsInput[i].Text + "')");
                    }
                }
                break;
            case DataType.CheckBox:
                bool checkBoxValInGridRow = default;

                //click in filter page
                if (!webElementAction.GetElementBySpecificAttribute("data-form-name", "OrdersToBillListBodyFilterForm").Displayed)
                    webElementAction.GetElementBySpecificAttribute("data-icon-name", "filter").Click();
                //set and click with check box
                var inActiveElement = webElementAction.GetInputElementByDataFormItemNameInDiv(id);
                if (!inActiveElement.Displayed)
                {
                    inActiveElement.Click();
                }
                bool valueCheckBox = webElementAction.GetInputElementByDataFormItemNameInDiv(id).Selected;

                if (webElementAction.GetInputElementByDataFormItemNameInDiv(id).GetAttribute("productionId") == null)
                {
                    var ContextProduction = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "productionId");
                    new WebElementDataGenerator(ContextProduction);
                }
                //refresh in page
                webElementAction.GetElementById("body-filter-refresh-btn").Click();

                //select and search in grid
                var gridListCheckbox = webElementAction.GetElementById(gridId);
                Thread.Sleep(4000);

                if (colId != default)
                    id = colId;

                var colIdsCheckbox =
                    gridListCheckbox.FindElements(By.TagName("div"))
                        .Where(o => o.GetAttribute("col-id") == id).ToList();

                if (colIdsCheckbox.Count() == 2) break; // If no row exists, we have at least two col-ids: one for the column title and the another for the footer.

                if (colIdsCheckbox.Count() > 2)
                {
                    break;
                }
                else
                {
                    throw new Exception("Doesn't match inserted filter value ('" + id +"') with in Grid");
                }
            default:
                break;
        }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "CreateInvoicefromOrders");
                RefreshRecordDataInGrid("OrdersToBillList-gridId", columnId: "productionId", filterId: "productionId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}