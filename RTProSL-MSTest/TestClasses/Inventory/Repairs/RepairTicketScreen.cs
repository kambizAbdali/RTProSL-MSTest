// Developed By Parsa Zakeri

using OpenQA.Selenium;
using RTProSL_MSTest.TestClasses.Inventory.Repairs;

namespace RTProSL_MSTest.TestClasses.Inventory.Repairs;

[TestCategory("Inventory")]
[TestClass, TestCategory("Inventory___Repairs")]

public class RepairTicketScreen : BaseClass
{
    private RepairTicketList repairTicketList;
    [TestMethod, Timeout(MaximumExecutionTime)]
    public void OpenPageRepairTicketScreen()
    {
        TestInitialize(nameof(OpenPageRepairTicketScreen));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                GoToUrl("MMInventory", "RepairTicketScreen");
                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }

    [TestMethod, Timeout(MaximumExecutionTime)]
    public void ValidateEnterRepairTicketInScreenPage()
    {
        TestInitialize(nameof(ValidateEnterRepairTicketInScreenPage));
        while (!testPassed && retryCount < maxRetries)
            try
            {
                repairTicketList = new RepairTicketList();

                string searchCodeInput = repairTicketList.AddOrEditRepairTicketListFunc(RepairTicketList.RepairTicketEnum.Add);
                GoToUrl("MMInventory", "RepairTicketScreen", false);

                webElementAction.GetElementBySpecificAttribute("name", "repir_ticket_input")
                    .SendKeys(searchCodeInput);

                webElementAction.Click(By.CssSelector(".mainButton"));

                repairTicketList.ValidateInsertedRepairTicketFunc();

                testPassed = true;
            }
            catch (Exception ex)
            {
                HandleTestFailure(ex.Message);
            }
    }
}

