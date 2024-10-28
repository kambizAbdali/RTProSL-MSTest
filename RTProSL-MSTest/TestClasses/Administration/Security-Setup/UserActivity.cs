//develop by ParsaZakeri



using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataType = RTProSL_MSTest.ComponentHelper.DataType;


namespace RTProSL_MSTest.TestClasses.Administration.Security_Setup
{
    [TestCategory("Administration")]
    [TestClass, TestCategory("Administration___SecuritySetup")]
    public class UserActivity : BaseClass
    {

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterUserActivityByUserCode()
        {
            TestInitialize(nameof(FilterUserActivityByUserCode));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "UserActivity");

                    //Select all value in grid
                    RefreshAllRows();
                    ShowAllRedord();
                    FilterSearch filterSearch = new FilterSearch("userList", "UserActivityList-gridId", "User ID", "userId");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterUserActivityByActivityTypes()
        {
            TestInitialize(nameof(FilterUserActivityByActivityTypes));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "UserActivity");

                    //Select all value in grid
                    RefreshAllRows();
                    ShowAllRedord();
                    string[] ActivityTypeDropDownValues =
                    {
                        //"Checkout","Cancel Checkin","Retired","Restore","In Repair","Out of Repair","Add Inventory","Add Production","Add Order","Create Subrental PO", "Create Inventory PO", "Create Invoice","In Inspection","Out of Inspection"
                        "Checkout","Cancel Checkin","Retired","In Repair","Out of Repair","Add Inventory","Add Production","Add Order","Create Subrental PO", "Create Inventory PO", "Create Invoice","In Inspection","Out of Inspection"
                    };
                    FilterSearch filterSearch = new FilterSearch("ActivityTypes", "UserActivityList-gridId", "Activity", colId: "activity");
                    filterSearch.FilterSearchInDropDownDataType(ActivityTypeDropDownValues);
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        //Activity Date Range
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterUserActivityByFromDateToDate()
        {
            TestInitialize(nameof(FilterUserActivityByFromDateToDate));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "UserActivity");

                    //Select all value in grid
                    RefreshAllRows();
                    ShowAllRedord();
                    FilterSearch filterSearch = new FilterSearch("Date1", "UserActivityList-gridId");
                    filterSearch.FilterSearchInDateTimeDataType("date", "actualDate");
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
                    GoToUrl("Administration", "UserActivity");
                    RefreshAllRows();
                    RefreshRecordDataInGrid("UserActivityList-gridId", columnId: "userId");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
