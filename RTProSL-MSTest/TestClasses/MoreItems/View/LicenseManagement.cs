//develop by Parsa Zakeri

using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using System.ComponentModel;
using RTProSL_MSTest.ComponentHelper;

namespace RTProSL_MSTest.TestClasses.MoreItems.View
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___View")]
    public class LicenseManagement : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageLicenseManagement()
        {
            TestInitialize(nameof(OpenPageLicenseManagement));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "LicenseManagement");

                    Thread.Sleep(1000);

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
        //ToDo : This will be fixed in the future
        //[TestMethod, Timeout(MaximumExecutionTime)]
        //public void ImportedFileValidateInLicenseManagement()
        //{
        //    TestInitialize(nameof(ImportedFileValidateInLicenseManagement));
        //    while (!testPassed && retryCount < maxRetries)
        //        try
        //        {
        //            GoToUrl("MoreItems", "LicenseManagement");
        //            Thread.Sleep(1000);

        //            ImportFileValidateFunc();
        //            ConfirmBtnCheck();
        //            testPassed = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            HandleTestFailure(ex.Message);
        //        }   
        //}

        //private static void ImportFileValidateFunc()
        //{
        //    { // click "Action" and Click "Import"
        //        webElementAction.Click(By.Id("ACTION_TOOL_DROPDOWN"));
        //        webElementAction.Click(By.CssSelector("[data-menu-id='rc-menu-uuid-24376-3-IMPORT']"));
        //    }
        //    //Find Modal and click btn upload
        //    if (webElementAction.IsElementPresent(By.CssSelector("[data-modal-title='UPLOAD_LICENSE_FILE']")))
        //        webElementAction.Click(By.Id("licenseUploader"));

        //    // Upload file format .lic
        //    GenericHelper.SetFileInWindowUploader("LicenseFile-CompanyName-NPGNasr");
        //}

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateTransferLicenseToAnotherUserLicenseManagement()
        {
            TestInitialize(nameof(ValidateTransferLicenseToAnotherUserLicenseManagement));

            while (!testPassed && retryCount < maxRetries)
            {
                try
                {
                    if (CurrentUrlIsMultiLocation()) continue;

                    GoToUrl("MoreItems", "LicenseManagement");
                    Thread.Sleep(2000);

                    var userCodeElements = GetUserCodeElements();

                    if (userCodeElements.Count == 0) break; // Ensure there are valid elements to click

                    userCodeElements.First().Click();
                    var userCodeNameBefore = userCodeElements.First().GetAttribute("value");

                    var userCodeColumnElement = webElementAction.GetColumnInDefaultGridRow("userCode", "WebLicense-gridId");
                    webElementAction.RighClick(userCodeColumnElement);

                    var transferOption = GetTransferOption();
                    transferOption?.Click();

                    var transferLicenseInput = GetTransferLicenseInput();
                    if (transferLicenseInput != null)
                    {
                        new WebElementDataGenerator(transferLicenseInput);
                    }

                    Thread.Sleep(500);
                    ConfirmBtnCheck(dataSection: "modal");

                    if (webElementAction.IsElementPresent(By.CssSelector("[data-section='errorDialog']")))
                    {
                        HandleErrorDialog();
                        break;
                    }
                    else
                    {
                        ValidateUserCodeChange(userCodeNameBefore, userCodeElements);
                    }
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    // Handle/log exception as needed
                }
            }
        }

        private IList<IWebElement> GetUserCodeElements()
        {
            return webElementAction.GetElementById("WebLicense-gridId")
                .FindElements(By.TagName("div"))
                .Where(element => element.GetAttribute("col-id") == "userCode" &&
                                 element.GetAttribute("innerText") != "User Code")
                .Skip(1) // Skip the first hidden element
                .ToList();
        }

        private IWebElement GetTransferOption()
        {
            return webElementAction.GetElementByCssSelector(".ag-popup")
                .FindElements(By.TagName("span"))
                .FirstOrDefault(span => span.GetAttribute("innerText").Contains("Transfer License to Another User"));
        }

        private IWebElement GetTransferLicenseInput()
        {
            return webElementAction.GetElementBySpecificAttribute("data-modal-title", "TRANSFER_LICENSE_TO_ANOTHER_USER")
                .FindElements(By.TagName("input")).FirstOrDefault();
        }

        private void HandleErrorDialog()
        {
            var errorMessage = webElementAction.GetElementBySpecificAttribute("class", "error-message-dialog")
                .GetAttribute("innerText");
            if (errorMessage.Contains("Error:"))
            {
                ConfirmBtnCheck(dataSection: "errorDialog");
            }
        }

        private void ValidateUserCodeChange(string userCodeNameBefore, IList<IWebElement> userCodeElements)
        {
            var userCodeNameAfter = userCodeElements.First().GetAttribute("value");
            if (userCodeNameBefore == userCodeNameAfter)
            {
                Assert.Fail($"The value of {userCodeNameBefore} is equal to {userCodeNameAfter}.");
            }
        }


        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRefreshRecordDataInGrid()
        {
            TestInitialize(nameof(ValidateRefreshRecordDataInGrid));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "LicenseManagement");
                    RefreshRecordDataInGrid("WebLicense-gridId", columnId: "userCode");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}
