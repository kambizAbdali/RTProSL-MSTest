// Developed By Mohammad Keshavarz

using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;
using RTProSL_MSTest.Settings;

namespace RTProSL_MSTest.TestClasses.AccountsReceivable.Payment;

[TestCategory("AccountsReceivable")]
[TestClass, TestCategory("AccountsReceivable___Payment")]
public class ARCreditMemoList : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageARCreditMemoList()
    {
        TestInitialize(nameof(OpenPageARCreditMemoList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "ARCreditMemoList");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenARCreditMemoList()
    {

        TestInitialize(nameof(OpenARCreditMemoList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "ARCreditMemoList");
                Thread.Sleep(2000);


                ShowAllRedord();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }


    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowFirstBtnCheckARCreditMemoList()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckARCreditMemoList));

        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "ARCreditMemoList");

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
    public void ArrowLastBtnCheckARCreditMemoList()
    {
        TestInitialize(nameof(ArrowLastBtnCheckARCreditMemoList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "ARCreditMemoList");

                ShowAllRedord();
                Thread.Sleep(1000);

                ArrowLastBtn();
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ArrowNextBtnCheckARCreditMemoList()
    {
        TestInitialize(nameof(ArrowNextBtnCheckARCreditMemoList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "ARCreditMemoList"); ;

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
    public void ArrowPreviousBtnCheckARCreditMemoList()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckARCreditMemoList));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("AccountsReceivable", "ARCreditMemoList");

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
}