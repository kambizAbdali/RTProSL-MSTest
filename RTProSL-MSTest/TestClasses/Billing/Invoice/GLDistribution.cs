// Developed By Mohammad Keshavarz

using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.Billing.Invoice;

[TestCategory("Invoice")]
[TestClass, TestCategory("Invoice___Billing")]
public class GLDistribution : BaseClass
{

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageGLDistribution()
    {
        TestInitialize(nameof(OpenPageGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //go to page rental agent
                GoToUrl("Billing", "GLDistribution");
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
    public void ArrowNextBtnCheckGLDistribution()
    {
        TestInitialize(nameof(ArrowNextBtnCheckGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                // navigate 
                GoToUrl("Billing", "GLDistribution");
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
    public void ArrowPreviousBtnCheckGLDistribution()
    {
        TestInitialize(nameof(ArrowPreviousBtnCheckGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Currency List page 
                GoToUrl("Billing", "GLDistribution");
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
    public void ArrowFirstBtnCheckArrowNextBtnCheckGLDistribution()
    {
        TestInitialize(nameof(ArrowFirstBtnCheckArrowNextBtnCheckGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Currency List page 
                GoToUrl("Billing", "GLDistribution");
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
    public void ArrowLastBtnCheckArrowNextBtnCheckGLDistribution()
    {
        TestInitialize(nameof(ArrowLastBtnCheckArrowNextBtnCheckGLDistribution));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                //navigate to Currency List page 
                GoToUrl("Billing", "GLDistribution");
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
    public void FilterGLDistributionByFromToDate()
    {
        TestInitialize(nameof(FilterGLDistributionByFromToDate));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistribution");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("BeginDate", "GLDistribution-gridId", "Creation Date");
                filterSearch.FilterSearchInDateTimeDataType("createDate");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void FilterGLDistributionByGLAccount()
    {
        TestInitialize(nameof(FilterGLDistributionByGLAccount));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("Billing", "GLDistribution");

                //Select all value in grid
                RefreshAllRows();
                FilterSearch filterSearch = new FilterSearch("GLAccountList", "GLDistribution-gridId", "GL Account", colId: "glAccountId");
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
                GoToUrl("Billing", "GLDistribution");
                RefreshRecordDataInGrid("GLDistribution-gridId", columnId: "glAccountId");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

}