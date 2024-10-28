// Developed By Mohammad Keshavarz

using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.ComponentHelper.Validation;
using RTProSL_MSTest.TestClasses.Administration.Tables;
using WindowsInput;
using static RTProSL_MSTest.TestClasses.PurchaseOrder.Inventory.InventoryPO;

namespace RTProSL_MSTest.TestClasses.Inventory.Sales;

public enum OperationType
{
    Add,
    Edit
}

public class SalesInventoryTransactionsEntity
{
    [ValidationColID("stockNoId")]
    public string StockNumber { get; set; }

    [ValidationIgnore(true, BaseClass.IgnoreType.AddAndValidation)]
    [ValidationColID("description")]
    public string Description { get; set; }

    [ValidationColID("transactionType")]
    public string TransactionType { get; set; }

    [ValidationColID("transactionDate")]
    public string TransactionDate { get; set; }

    [ValidationColID("quantity")]
    public string Quantity { get; set; }

    [ValidationColID("ownerId")]
    public string Owner { get; set; }

    [ValidationColID("po")]
    public string PONumber { get; set; }

    [ValidationColID("cost")]
    public string Cost { get; set; }

    [ValidationColID("creationDate")]
    public string CreationDate { get; set; }

    [ValidationColID("createBy")]
    public string CreateBy { get; set; }

    [ValidationColID("avgCost")]
    public string AverageCost { get; set; }

    [ValidationColID("price")]
    public string Price { get; set; }

    [ValidationColID("serialNo")]
    public string SerialNumber { get; set; }

    [ValidationColID("warrantyNo")]
    public string WarrantyNumber { get; set; }

    [ValidationColID("warrantyDate")]
    public string WarrantyDate { get; set; }

    [ValidationColID("manufacturer")]
    public string Manufacturer { get; set; }

    [ValidationColID("notes")]
    public string Notes { get; set; }
}

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Sales")]
public class SalesInventoryTransactions : BaseClass
{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageSalesInventoryTransactions()
    {
        TestInitialize(nameof(OpenPageSalesInventoryTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesInventoryTransactions");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private static SalesInventoryTransactionsEntity _SalesInventoryTransactionsEntity;
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void AddSalesInventoryTransactions()
    {
        TestInitialize(nameof(AddSalesInventoryTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOrEditSalesInventoryTransactionsFunc(OperationType.Add);

                ValidateInsertedSalesInventoryTransactionsInGridList();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void EditSalesInventoryTransactions()
    {
        TestInitialize(nameof(EditSalesInventoryTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOrEditSalesInventoryTransactionsFunc(OperationType.Add);

                Thread.Sleep(2000);

                AddOrEditSalesInventoryTransactionsFunc(OperationType.Edit);

                Thread.Sleep(2000);

                ValidateInsertedSalesInventoryTransactionsInGridList();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void DeleteSalesInventoryTransactions()
    {
        TestInitialize(nameof(DeleteSalesInventoryTransactions));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                AddOrEditSalesInventoryTransactionsFunc(OperationType.Add);

                Thread.Sleep(2000);

                webElementAction.Click(By.Id("TOOL_BOX_DELETE_BUTTON_ID"));

                Thread.Sleep(2000);

                ConfirmBtnCheck();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    private void AddOrEditSalesInventoryTransactionsFunc(OperationType operationType)
    {
        if (operationType == OperationType.Edit)
            if (webElementAction.IsElementPresent(By.CssSelector(".cursor-pointer")))
                webElementAction.GetElementBySpecificAttribute("data-icon-id", "inlineEdit").Click();

        _SalesInventoryTransactionsEntity = new SalesInventoryTransactionsEntity();
        var rowType = ".ag-center-cols-container > .ag-row-even"; // with find row edit
        if (operationType == OperationType.Add)
        {
            GoToUrl("MMInventory", "SalesInventoryTransactions");
            webElementAction.Click(By.Id("TOOL_BOX_ADD_BUTTON_ID"));
            Thread.Sleep(2000);
            rowType = ".ag-center-cols-container .new-added-row"; // with find row add
        }
        var salesInventoryTransactionGrid = webElementAction.GetElementById("SalesInventoryTransaction-gridId");

        var newRowColsContextShipping = webElementAction.GetElementByCssSelector(rowType, salesInventoryTransactionGrid);
        new WebElementDataGenerator(newRowColsContextShipping, true);

        GenerateSalesInventoryTransactionsToGrid("SalesInventoryTransaction-gridId");

        var salesInventoryTransactionColIds = salesInventoryTransactionGrid.FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));

        CreateAddInGrid(_SalesInventoryTransactionsEntity, salesInventoryTransactionColIds);

        webElementAction.ClickOnPostBtnInMinGrid("SalesInventoryTransaction-gridId");
        ConfirmBtnCheck(dataSection: "errorDialog");
    }

    private void ValidateInsertedSalesInventoryTransactionsInGridList()
    {
        Thread.Sleep(2000);
        if (webElementAction.IsElementPresent(By.CssSelector(".cursor-pointer")))
            webElementAction.GetElementBySpecificAttribute("data-icon-id", "inlineEdit").Click();
        Thread.Sleep(2000);

        var salesInventoryTransactionGrid = webElementAction.GetElementById("SalesInventoryTransaction-gridId");
        var salesInventoryTransactionColIds = salesInventoryTransactionGrid.FindElements(By.CssSelector(".ag-row.ag-row-focus [col-id]"));

        CreateValidationInGrid(salesInventoryTransactionColIds, _SalesInventoryTransactionsEntity);
    }
    private static void GenerateSalesInventoryTransactionsToGrid(string GridId)
    {
        IWebElement poInput = default;
        IWebElement serialNoInput = default;
        IWebElement quantityInput = default;

        poInput = webElementAction.GetElementByCssSelector("#" + GridId + " .ag-body-viewport .ag-row-focus [col-id='po'] input");
        serialNoInput = webElementAction.GetElementByCssSelector("#" + GridId + " .ag-body-viewport .ag-row-focus [col-id='serialNo'] input");
        quantityInput = webElementAction.GetElementByCssSelector("#" + GridId + " .ag-body-viewport .ag-row-focus [col-id='quantity'] input");

        webElementAction.DoubleClick(quantityInput);
        (new InputSimulator()).Keyboard.TextEntry("0");

        quantityInput.Clear();
        quantityInput.SendKeys("1");

        webElementAction.DoubleClick(poInput);
        (new InputSimulator()).Keyboard.TextEntry(" ");

        poInput.Clear();


        webElementAction.DoubleClick(serialNoInput);
        (new InputSimulator()).Keyboard.TextEntry("0");

        serialNoInput.Clear();
        serialNoInput.SendKeys("10");
        //serialNoInput.SendKeys(RandomValueGenerator.GenerateRandomInt(1));
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "SalesInventoryTransactions");
                RefreshRecordDataInGrid("SalesInventoryTransaction-gridId", columnId: "stockNoId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}