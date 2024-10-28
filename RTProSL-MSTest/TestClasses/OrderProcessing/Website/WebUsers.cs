// Developed By Mohammad Keshavarz

namespace RTProSL_MSTest.TestClasses.OrderProcessing.Website;


[TestCategory("OrderProcessing")]
[TestClass, TestCategory("OrderProcessing___Website")]
public class WebUsers : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageWebUsers()
    {
        TestInitialize(nameof(OpenPageWebUsers));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMWebUsers");
                testPassed = true;
            }
            catch (Exception ex)
            {
                if (!isSubMenuExist) break;
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckWebUsers()
    {
        TestInitialize(nameof(ArrowNextBtnCheckWebUsers));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMWebUsers");
                ShowAllRedord();
                // call method NextBtn
                ArrowNextBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                if (!isSubMenuExist) break;
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowLastBtnCheckWebUsers()
    {
        TestInitialize(nameof(ArrowLastBtnCheckWebUsers));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMWebUsers");
                ShowAllRedord();
                Thread.Sleep(1000);
                //call method arrowlastbtn
                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                if (!isSubMenuExist) break;
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckWebUsers()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckWebUsers));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMWebUsers");

                ShowAllRedord();
                //call method arrowFirstBtn
                ArrowFirstBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                if (!isSubMenuExist) break;
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowPreviousBtnCheckWebUsers()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckWebUsers));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("OrderProcessing", "OPMWebUsers");
                ShowAllRedord();
                //call arrow previous
                ArrowPreviousBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                if (!isSubMenuExist) break;
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
                GoToUrl("OrderProcessing", "OPMWebUsers");
                RefreshRecordDataInGrid("WebUsers-gridId", columnId: "username");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}