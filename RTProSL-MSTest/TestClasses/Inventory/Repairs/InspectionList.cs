// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.Inventory.Repairs;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Repairs")]
public class InspectionList : BaseClass

{
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageInspectionList()
    {
        TestInitialize(nameof(OpenPageInspectionList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "InspectionList");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterInspectionList()
    {

        TestInitialize(nameof(OpenGridFilterInspectionList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "InspectionList");
                RefreshAllRows();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }

    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void CardViewBtnCheckInspectionList()
    {
        TestInitialize(nameof(CardViewBtnCheckInspectionList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "InspectionList");
                RefreshAllRows();
                ShowAllRedord();
                //call method card viewBtn
                CardViewBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ListViewtBtnCheckInspectionListy()
    {
        TestInitialize(nameof(ListViewtBtnCheckInspectionListy));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "InspectionList");
                RefreshAllRows();
                ShowAllRedord();
                //call list view btn 
                ListViewBtnValidate();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckInspectionList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckInspectionList));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "InspectionList");
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
    public void ArrowLastBtnCheckInspectionList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckInspectionList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "InspectionList");
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
    public void ArrowNextBtnCheckInspectionList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckInspectionList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "InspectionList");
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
    public void ArrowPreviousBtnCheckInspectionList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckInspectionList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "InspectionList");
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
    public void ValidateRefreshRecordDataInGrid()
    {
        TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "InspectionList");
                RefreshRecordDataInGrid("InspectionList-gridId", columnId: "ticket");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}