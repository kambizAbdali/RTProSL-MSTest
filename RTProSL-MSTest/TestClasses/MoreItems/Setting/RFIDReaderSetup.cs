//develop by Mohammad_Keshavarz
using RTProSL_MSTest.ComponentHelper.ErrorMessageValidating;

namespace RTProSL_MSTest.TestClasses.MoreItems.Setting
{
    [TestCategory("MoreItems")]
    [TestClass, TestCategory("MoreItems___Setting")]
    public class RFIDReaderSetup : BaseClass
    {
        [TestMethod, Timeout(MaximumExecutionTime)]
        public void OpenPageRFIDReaderSetup()
        {
            TestInitialize(nameof(OpenPageRFIDReaderSetup));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    GoToUrl("MoreItems", "RFIDReaderSetup");

                    Thread.Sleep(1000);

                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }

        [TestMethod, Timeout(MaximumExecutionTime)]
        public void ValidateRequiredFieldsMessageBoxInRFIDReaderSetup()
        {
            TestInitialize(nameof(ValidateRequiredFieldsMessageBoxInRFIDReaderSetup));
            while (!testPassed && retryCount < maxRetries)
                try
                {
                    ValidateRequiredFieldsMessage validateRequiredFields;
                    validateRequiredFields = new ValidateRequiredFieldsMessage(menu: "MoreItems", subMenu: "RFIDReaderSetup", filed: "readerPort");
                    validateRequiredFields.Run();
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
                    GoToUrl("MoreItems", "RFIDReaderSetup");
                    RefreshRecordDataInGrid("RFIDReaderProfileList-gridId", columnId: "readerName");
                    testPassed = true;
                }
                catch (Exception ex)
                {
                    HandleTestFailure(ex.Message);
                }
        }
    }
}