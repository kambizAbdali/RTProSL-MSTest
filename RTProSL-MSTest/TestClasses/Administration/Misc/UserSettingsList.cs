//Develop by ParsaZakeri


using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.TestClasses.AccountsReceivable.AR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataType = RTProSL_MSTest.ComponentHelper.DataType;

namespace RTProSL_MSTest.TestClasses.Administration.Misc
{
    [TestCategory("Administration")]
    [TestClass, TestCategory("Administration___SecuritySetup")]
    public class UserSettingsList : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterUserSettingsListByUserCode()
        {
            TestInitialize(nameof(FilterUserSettingsListByUserCode));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "UserSettingsList");

                    //Select all value in grid
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch("UserCode", "WorkstationUserSettingsList-gridId", colId:"userId");
                    filterSearch.FilterSearchInTextDataType();
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void FilterUserSettingsListByKeyValue()
        {
            TestInitialize(nameof(FilterUserSettingsListByKeyValue));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("Administration", "UserSettingsList");

                    //Select all value in grid
                    RefreshAllRows();
                    FilterSearch filterSearch = new FilterSearch(filterId:"KeyValue", gridListId:"WorkstationUserSettingsList-gridId",colId: "keyName");//keyValue
                    filterSearch.FilterSearchInTextDataInGridDataType();
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
                    GoToUrl("Administration", "UserSettingsList");
                    RefreshRecordDataInGrid("WorkstationUserSettingsList-gridId", columnId: "keyName");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}