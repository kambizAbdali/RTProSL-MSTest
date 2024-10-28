// develop by Kambiz Abdali
// share IP:  Z:\RTProFilesWebMBS\Reports
using MSTestProject.ComponentHelper;
using OpenQA.Selenium;
using RTProSL_MSTest.ComponentHelper;
using RTProSL_MSTest.Settings;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;

namespace RTProSL_MSTest.TestClasses.ReportsSchedule;

//[TestCategory("Reports")]
//[TestClass, TestCategory("Reports___NewSchedule")]

public class NewReportingSchedule : BaseClass
{
    List<string> subMenuList = new List<string> {
        //"/accessory-list-report",
        //"/accessory-used-report",
        //"/aging-detail-by-billing-name",
        //"/aging-detail-by-date",
        //"/aging-detail-by-production",
        //"/aging-summary",
        //"/ar-average-days-to-pay",
        //"/ar-customer-balancing",
        //"/barcoded-equipment-utilization-report",
        //"/billed-subrental-report",
        //"/billing-summary",
        //"/cash-receipt",
        //"/cash-receipts-journal-detail",
        //"/cash-receipts-journal-summary",
        //"/checkout-checkin-quantity-report",
        //"/checkout-sheet?batchMode=true&step=1",
        //"/container-label-report",
        //"/cost-sheet-by-production?reportBatchMode=true",
        //"/costof-sales",
        //"/costof-sales-shipped",
        //"/crm-report",
        //"/current-inventory-status",
        //"/current-rentals-report",
        //"/current-rentals-report-format2",
        //"/current-subrental-report",
        //"/currentlyin-repair",
        //"/customers-sales-summary",
        //"/daily-cash-receipts",
        //"/daily-deposits",
        //"/deposit-log-report",
        //"/equipment-inspection-due-report",
        //"/equipment-inspection-report",
        //"/equipment-revenue-report",
        //"/est-rev-report-parent",
        //"/est-rev-report-production",
        //"/est-rev-report-production-type",
        //"/exceptions-report",
        //"/gantt-chart-for-equipment-availability",
        //"/gantt-chart-for-open-orders",
        //"/gaps-in-billing",
        //"/gl-distribution-by-type",
        //"/gl-distribution-detail",
        //"/gl-distribution-grouped-by-gl-code",
        //"/gl-distribution-sorted-by-gl-code",
        //"/gl-distribution-summary",
        //"/insurance-expires-report",
        //"/inventory-po-accruals-report",
        //"/inventory-po-gl-distribution-report",
        //"/inventory-reconciliation",
        //"/invoice-detail-transactions",
        //"/invoice-list-by-production",
        //"/invoice-log-report",
        //"/invoice-register",
        //"/invoiceand-credit-memo-gl-distribution",
        //"/invoices-attached-to-po",
        //"/invoices-to-rebill",
        //"/late-return-report",
        //"/late-shipment-report",
        //"/mbs-acumatica-transaction-log",
        //"/mels-price-change-report",
        //"/no-chargevs-actual-charges-report-shipped",
        //"/order-log-report",
        //"/order-statistics-by-production-report",
        //"/order-statistics-report",
        //"/order-status-report",
        //"/orders-attachedto-po",
        //"/orders-expected-to-return",
        //"/orders-to-bill",
        //"/orders-with-no-po",
        //"/owner-monthly-statement",
        //"/owner-revenue-report",
        //"/owner-revenue-split",
        //"/payment-detail-report",
        //"/payment-received",
        //"/payment-received-report",
        //"/po-balance-report",
        //"/po-subrental-cost-sheet",
        //"/pos-across-Project",
        //"/production-account-inquiry",
        //"/production-log-report",
        //"/production-replacement-cost-sheet",
        //"/projected-cash-flow",
        //"/projected-equipment-utilization-analysis?kitMode=true&step=1",
        //"/projected-rental-revenue",
        //"/pull-list-report?batchMode=true&step=1",
        //"/quote-sheet?batchMode=true&step=1",
        //"/quoted-projected-revenue",
        //"/quotes-reservations-orders-precount-report",
        //"/range-of-invoices",
        //"/refund-adjustment",
        //"/rental-discount-report",
        //"/rental-equipment-pick",
        //"/rental-in-transit-report",
        //"/rental-inventory-balance-report",
        //"/rental-inventory-change-report",
        //"/rental-inventory-out-more-than-owned",
        //"/rental-inventory-out-report",
        //"/rental-inventory-purchases-against-po",
        //"/rental-inventory-report",
        //"/rental-inventory-sold-report",
        //"/rental-inventory-utilization-by-vendor-type-report",
        //"/rental-inventory-utilization-report",
        //"/rental-inventory-value-report",
        //"/rental-inventory-worksheet",
        //"/rental-kit-report",
        //"/rental-sales-rate-breakdown",
        //"/rental-sales-rate-breakdown-format2",
        //"/rental-stat-det-report-statistics-detail",
        //"/rental-stat-det-report-statistics-detail-format2",
        //"/rental-stat-report-by-equipment-orderno-estimated",
        //"/rental-stat-report-by-equipment-production",
        //"/rental-stat-report-by-production",
        //"/rental-substitution-report",
        //"/rental-truck-revenue",
        //"/repair-lossof-revenue-report",
        //"/repair-report",
        //"/retired-inventory-report",
        //"/return-date-past-due-orders",
        //"/return-list-report?batchMode=true&step=1",
        //"/rev-gen-report-custom-field1",
        //"/rev-gen-report-custom-field2",
        //"/rev-gen-report-custom-field3",
        //"/rev-gen-report-customer-contact",
        //"/rev-gen-report-damageand-repair-part",
        //"/rev-gen-report-job-component",
        //"/rev-gen-report-location",
        //"/rev-gen-report-master",
        //"/rev-gen-report-original-inventory-location",
        //"/rev-gen-report-parent",
        //"/rev-gen-report-partner",
        //"/rev-gen-report-production",
        //"/rev-gen-report-production-type",
        //"/rev-gen-report-project",
        "/rev-gen-report-rental-agent",
        "/rev-gen-report-salesperson",
        "/rev-gen-report-selected-production",
        "/rev-gen-report-vendor",
        "/sales-backorder-report",
        "/sales-drop-shipment-report",
        "/sales-in-transit-report",
        "/sales-inventory-balance-report",
        "/sales-inventory-change-report",
        "/sales-inventory-transaction-report",
        "/sales-inventory-value-report",
        "/sales-kit-report",
        "/sales-on-hand-report",
        "/sales-pick",
        "/sales-profit-report",
        "/sales-reorder-report",
        "/sales-stat-report-by-production-shipped",
        "/sales-stat-report-by-stockno-shipped",
        "/sales-statistics-detail",
        "/sales-summary-by-month",
        "/scheduled-subrental-report",
        "/shipping-charges-report",
        "/space-revenue-report",
        "/space-utilization-revenue-report",
        "/statements-by-parent",
        "/statements-by-production",
        "/subrental-balance-detail",
        "/subrental-billed-accruals-report",
        "/subrental-equipment-revenue-report",
        "/subrental-invoice-report",
        "/subrental-limit-report",
        "/subrental-po-gl-distribution-report",
        "/subrental-purchase-order-report",
        "/subrental-return",
        "/subrental-statistics-report",
        "/subrental-vendor-invoices-not-paid",
        "/subrental-vendor-return-receipt",
        "/tax-liability",
        "/unapplied-payments",
        "/unbilled-repair-tickets-report",
        "upload-certificate",
        "/upload-certificate-detail",
        "/upload-fox-report",
        "/upload-report",
        "/upload-sony-report",
        "/user-login-history",
        "/weekly-subrental-po-forecast",
        "/workstation-scanner-license",
        "/orders-to-bill",
        "/rental-inventory-out-report",
        "/shipping-charges-report",
        "/order-status-report",
        "/subrental-limit-report",
    };

    public void AddSchedule()
    {
        //icon-arrow-down
        webElementAction.GetElementById("SCHEDULE_TOOL_DROPDOWN").Click();
        //click on NewSchedule section
        webElementAction.GetElementsByTagName("li").Where(o => o.GetAttribute("role") == "menuitem").First().Click();

        // var scheduleContainer=webElementAction.GetElementBySpecificAttribute("class", "schedule-container");
        var arrowDownElements = ObjectRepository.Driver.FindElements(By.CssSelector(".icon-arrow-down"));
        foreach (var item in arrowDownElements)
        {
            try
            {
                item.Click();
            }
            catch
            {
                //Some arrowDown buttons may be hidden in the background of the screen
                //ignorred
            }
        }

        //-----------------------set file path--------------------------//
        //try
        //{
        //    SetFilePath();
        //}
        //catch
        //{
        //    //open File Setting Tab
        //    webElementAction.GetAllElementBySpecificAttribute("class", "ant-collapse-item")[0].Click();
        //    SetFilePath();
        //}
        //-----------------------set FileName -----------------------//
        try
        {
            var scheduleTypeContext = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "scheduleType");
            webElementAction.GetElementByCssSelector(".switch-area.left-checked", scheduleTypeContext).Click();
        }
        catch
        {
            //open Schedule Tab
            webElementAction.GetElementBySpecificAttribute("class", "ant-collapse-item schedule-collapse").Click();

            var scheduleTypeContext = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "scheduleType");
            webElementAction.GetElementByCssSelector(".switch-area.left-checked", scheduleTypeContext).Click();
        }

        //set scheduleName
        IWebElement scheduleNameElement = webElementAction.GetInputElementByDataFormItemNameInDiv("name");

        string newScheduleName = RandomValueGenerator.GenerateRandomString(8) + "_" + scheduleNameElement.GetAttribute("value");
        scheduleNameElement.Clear();
        scheduleNameElement.SendKeys(newScheduleName);

        //set Date
        //string tomarrowDate = DateTime.Now.AddDays(1).ToString("M/d/yyyy");
        string todayDate = DateTime.Now.ToString("M/d/yyyy");

        //string nextTenMinutes = DateTime.Now.AddMinutes(10).ToString("HH:mm");
        string nextTenMinutes = "16:00";


        var dateElement = webElementAction.GetInputElementByDataFormItemNameInDiv("oneTimeDate");


        dateElement.Clear();
        dateElement.SendKeys(todayDate + " " + nextTenMinutes);

        //set Time
        //var timeElement = webElementAction.GetInputElementByDataFormItemNameInDiv("oneTimeTime");
        //timeElement.Clear();


        //timeElement.SendKeys(nextTenMinutes);
        //timeElement.SendKeys("14:55");
    }


    public void AddSpecificFields()
    {
        // webElementAction.GetElementByCssSelector(".col-01[data-form-item-name='parentId'] .icon-grid").Click();
        var genericReportContext = webElementAction.GetElementBySpecificAttribute("data-form-name", "reportSchedule");

        //fromDate
        if (webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='fromDate']")))
        {
            var dateContext = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "fromDate");
            new WebElementDataGenerator(dateContext);
        }

        WaitForLoadingSpiner();

        //location
        if (webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='locationId']"), genericReportContext))
        {
            var locationInput = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "locationId", genericReportContext);
            var comboAutoCompleteLocation = locationInput.FindElements(By.CssSelector(".combo-auto-complete"));
            new WebElementDataGenerator().ComboAutoCompleteGenerator(comboAutoCompleteLocation, "LOSANGELES");
        }

        //production
        if (webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='productionId']"), genericReportContext))
        {
            var productionContext = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "productionId", genericReportContext);
            new WebElementDataGenerator(productionContext);
        }

        //parent
        if (webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='parentId']"), genericReportContext))
        {
            var parentContext = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "parentId", genericReportContext);
            new WebElementDataGenerator(parentContext);
        }

        //currency
        if (webElementAction.IsElementPresent(By.CssSelector("[data-form-item-name='currencyId']"), genericReportContext))
        {
            var currencyContext = webElementAction.GetElementBySpecificAttribute("data-form-item-name", "currencyId", genericReportContext);
            var comboAutoCompleteCurrency = currencyContext.FindElements(By.CssSelector(".combo-auto-complete"));
            new WebElementDataGenerator().ComboAutoCompleteGenerator(comboAutoCompleteCurrency, "USD");
        }

    }

    private void SetFilePath()
    {
        webElementAction.GetElementById("exportTo-Path").Click();
        var pathInput = webElementAction.GetInputElementByDataFormItemNameInDiv("exportPath");
        pathInput.Clear();
        pathInput.SendKeys(folderPath);
    }

    const string serverURL = "http://foxaus.dev.sl.npgnasr.com"; //"https://wb.sl.rtpro.com/"; //"http://192.168.1.54:8050"; //"http://192.168.1.153:8072"; //"http://rtprosl.npgnasr.com:8023";
    const string password = "hd";

    string folderPath;
    //[TestMethod, Timeout(MaximumExecutionTime * 8)]
    //public void AddNewSchedule()
    //{
    //    List<string> failSubMenuReports = new List<string>();
    //    ChangeScreenPageSize(80);

    //    //string tomorrowDate = DateTime.Now.AddDays(1).ToString("M/d/yyyy");
    //    string currentDate = DateTime.Now.ToString("M/d/yyyy");
    //    //folderPath = CreateAutoReportFolderWithSpecificDate(currentDate);

    //    TestInitialize(nameof(AddNewSchedule) + " in NewSchedule");
    //    this.GoToLogin();

    //    while (!testPassed && retryCount < maxRetries)
    //        try
    //        {
    //            foreach (string subMenu in subMenuList)
    //            {
    //                try
    //                {
    //                    NavigationHelper.NavigateToUrl(serverURL + subMenu);
    //                    AddSchedule();
    //                    SaveAndConfirmCheck();
    //                }
    //                catch
    //                {
    //                    failSubMenuReports.Add(subMenu);
    //                    //An error may be encountered on a sunmenu for reporting.
    //                    //In this case, it switches to the next submenu
    //                }
    //                WaitForLoadingSpiner();
    //            }
    //            testPassed = true;
    //            string failSubMenuReportsConcatenated = string.Join(", ", failSubMenuReports);
    //            // Print the concatenated string to the console
    //            Console.WriteLine(failSubMenuReportsConcatenated);
    //        }
    //        catch (Exception ex)
    //        {
    //            HandleTestFailure(ex.Message);
    //        }
    //}
    [Priority(1)]
    [TestMethod, Timeout(MaximumExecutionTime * 12)]
    public void AddNewScheduleWithSpecificFields()
    {
        TestInitialize(nameof(AddNewScheduleWithSpecificFields) + " in NewSchedule");
        List<string> failSubMenuReports = new List<string>();

        //string tomorrowDate = DateTime.Now.AddDays(1).ToString("M/d/yyyy");
        string currentDate = DateTime.Now.ToString("M/d/yyyy");
        folderPath = "C:\\inetpub\\TemporaryFiles\\RTProSLRentex\\ReportSchedule"; // CreateAutoReportFolderWithSpecificDate(currentDate);//

        Login();
        while (!testPassed && retryCount < maxRetries)
            try
            {
                foreach (string subMenu in subMenuList)
                {
                    try
                    {
                        NavigationHelper.NavigateToUrl(serverURL + subMenu);
                        WaitForLoadingSpiner();
                        AddSchedule();
                        AddSpecificFields();
                        SaveAndConfirmCheck();
                        WaitForLoadingSpiner();
                    }
                    catch (Exception ex)
                    {
                        failSubMenuReports.Add(subMenu + "  : errorMessage:" + ex.Message);
                        //An error may be encountered on a sunmenu for reporting.
                        //In this case, it switches to the next submenu
                    }
                    WaitForLoadingSpiner();
                }
                testPassed = true;
                string failSubMenuReportsConcatenated = string.Join(", ", failSubMenuReports);
                // Print the concatenated string to the console
                Console.WriteLine(failSubMenuReportsConcatenated);
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    public string CreateAutoReportFolderWithSpecificDate(string date)
    {

        string folderName = date.Replace("/", "_");
        string folderPath = "Z:\\RTProFilesWebMBS\\Reports" + folderName;
        if (!Directory.Exists(folderName))
        {
            try
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("Folder " + folderName + " has been created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating folder: {0}", ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Folder " + folderName + " already exists.");
        }
        return folderPath;
    }
}
