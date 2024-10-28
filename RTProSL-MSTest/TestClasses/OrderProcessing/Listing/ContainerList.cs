// Developed By Mohammad Keshavarz
// Prerequisite: Checking the "Use Container" option in the system setup.
namespace RTProSL_MSTest.TestClasses.OrderProcessing.Listing;

[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___Listing")]
public class ContainerList : BaseClass
{

    // Prerequisite: Checking the "Use Container" option in the system setup.
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageContainerList()
    {
        TestInitialize(nameof(OpenPageContainerList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMContainerList");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenGridFilterContainerList()
    {

        TestInitialize(nameof(OpenGridFilterContainerList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMContainerList");
                RefreshAllRows();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }

    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckContainerList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckContainerList));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMContainerList");
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
    public void ArrowLastBtnCheckContainerList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckContainerList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMContainerList");
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
    public void ArrowNextBtnCheckContainerList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckContainerList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMContainerList");
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
    public void ArrowPreviousBtnCheckContainerList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckContainerList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMContainerList");
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
                GoToUrl("OrderProcessing", "OPMContainerList");
                RefreshRecordDataInGrid("ContainerList-gridId", columnId: "id");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}