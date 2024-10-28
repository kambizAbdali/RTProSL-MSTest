using Newtonsoft.Json;

namespace RTProSL_ExternalAPI_Test
{
    public class HttpPutAPI : APIHelper
    {
        public HttpPutAPI()
        {
            InitializeApiRequests();
        }

        private void InitializeApiRequests()
        {
            string GenerateRandomString(int length) =>
            new string(Enumerable.Range(0, length).Select(_ => "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[new Random().Next(62)]).ToArray());

            string response = FetchFirstItemFromList(apiName: "PaymentType");
            string peymentId = GetJsonValue(response, "id");
            string peymentRecNo = GetJsonValue(response, "recNo");
            string PaymentTypePayload = JsonConvert.SerializeObject(new { id = peymentId, description = "ApiTest", recNo = peymentRecNo });

            response = FetchFirstItemFromList(apiName: "Department");
            var departmentId = GetJsonValue(response, "id");
            var departmentRecNo = GetJsonValue(response, "recNo");
            var data = new
            {
                id = departmentId,
                description = "redds",
                showOnWebsite = true,
                inactive = false,
                sortOrder = 1,
                recNo = departmentRecNo,
            };

            var departmentTypePayload = JsonConvert.SerializeObject(data);

            //string customerPayload = "{\r\n\t\"parentId\": \"\",  \r\n\t\"id\": \"" + id + "\", \"productionTypeId\": \"715POYV9Z6\",  \r\n\t\"productionTitle\": \"SOME PRODUCTION TITLE\",  \r\n\t\"productionStatus\": \"Open\",  \r\n\t\"quoteOnly\": false,  \r\n\t\"inactive\": true,  \r\n\t\"locationId\": \"\",  \r\n\t\"rentalAgent1Id\": \"01J35N86\",  \r\n\t\"rentalAgent2Id\": \"0VTW9OBREA\",  \r\n\t\"shipMethodId\": \"\",  \r\n\t\"returnMethodId\": \"\",  \r\n\t\"salespersonId\": \"ASUFKA\",  \r\n\t\"subrentalLimitPct\": 75.0000,  \r\n\t\"stagingCount\": 1,  \r\n\t\"spaceColor\": 16777215,  \r\n\t\"alertNotes\": \"SALES ACCOUNT\",  \r\n\t\"signedTerms\": false,  \r\n\t\"customField1Id\": \"\",  \r\n\t\"customField2Id\": null,  \r\n\t\"customField3Id\": \"\",  \r\n\t\"notes\": \"Some Notes\",  \r\n\t\"name\": \"Customer Name\",  \r\n\t\"addressLine1\": \"5323 A.ALAMEDAAVENUE\",  \r\n\t\"addressLine2\": \"0SI RGPDN\",  \r\n\t\"addressLine2B\": \"HOAP 376 WIAIB 866\",  \r\n\t\"addressLine3\": \"GAFPMSF\",  \r\n\t\"state\": \"CA\",  \r\n\t\"zipCode\": \"91505\",  \r\n\t\"addressLine4\": \"WZ\",  \r\n\t\"phone\": \"834 157-5201\",  \r\n\t\"fax\": \"520-110-8106\",  \r\n\t\"shippingName\": \"LET'S MAKE A DEAL\",  \r\n\t\"shippingAddressLine1\": \"shipping address 1\",  \r\n\t\"shippingAddressLine2\": \"shipping address 2\",  \r\n\t\"shippingAddressLine2B\": \"ZNCKW 5\",  \r\n\t\"shippingAddressLine3\": \"shipping address 3\",  \r\n\t\"shipZipCode\": \"70403\",  \r\n\t\"shipState\": \"NY\",  \r\n\t\"shippingAddressLine4\": \"shipping address 4\",  \r\n\t\"email\": \"kp@eskxsfafpqpqes.com\",  \r\n\t\"shippingAcctNo\": null,  \r\n\t\"chargeTypeId\": \"\",  \r\n\t\"taxTypeId\": \"\",  \r\n\t\"dailyWeekly\": \"Daily\",  \r\n\t\"daysPerWeek\": 1.0000,  \r\n\t\"discountPercentage\": null,  \r\n\t\"salesDiscPct\": 18.0000,  \r\n\t\"rentalListPriceMarkupPct\": 26.0000,  \r\n\t\"salesListPriceMarkupPct\": null,  \r\n\t\"rentalPriceListId\": \"\",  \r\n\t\"salesPriceListId\": \"\",  \r\n\t\"restockPct\": 0.0000,  \r\n\t\"contactAcct\": \"BOB SHAPIRO\",  \r\n\t\"billingMethodId\": \"\",  \r\n\t\"revenueGoal\": 3500.00,  \r\n\t\"contactNotes\": \"186 022-9028/ Noqqpr Iceknye<mdneli.qucsxzi@quzeiw.tv\",  \r\n\t\"creditThru\": \"2020-02-13T00:00:00\",  \r\n\t\"creditLimit\": 2500.00,  \r\n\t\"jobComponentId\": \"\",  \r\n\t\"extendedWrapDate\": \"2022-09-12T0:00:00\",  \r\n\t\"termsId\": \"COD\",  \r\n\t\"currentPO\": null,  \r\n\t\"paymentTypeId\": \"4JQSYULEO4\",  \r\n\t\"poRequired\": false,  \r\n\t\"creditApproved\": false,  \r\n\t\"creditHold\": false,  \r\n\t\"uploadInclude\": true,  \r\n\t\"certificateOfIns\": true,  \r\n\t\"insExp\": \"2017-11-06T00:00:00\",  \r\n\t\"insAmount\": 6730000.00,  \r\n\t\"insCo\": \"State Compensation Ins Fund\",  \r\n\t\"insPolicy\": \"EKN1004079-00 - EQUIP\",  \r\n\t\"insNotes\": \"Some Note\",  \r\n\t\"mbsCustomerClassId\": \"\",  \r\n\t\"mbsCustomerGroupId\": \"\",  \r\n\t\"billingType\": \"Regular Bill\",  \r\n\t\"contactTypeId\": null,  \r\n\t\"history\": false,  \r\n\t\"comesFromSphere\": false,  \r\n\t\"confirmed\": false,  \r\n\t\"bsCycle\": 32,  \r\n\t\"closeDate\": \"2022-03-02T08:09:00\",  \r\n\t\"eBizChargeCustomerToken\": null,  \r\n\t\"accountingInterfaceCode\": null,  \r\n\t\"bsAction\": \"Loop\",  \r\n\t\"fattMerchantId\": null  \r\n}";
            //id = FetchFirstItemIdFromEntity(apiName: "Customer");
            //string departmentPayload = "{ \"id\": \"" + id + "\", \"description\": \"redds\", \"showOnWebsite\": true, \"inactive\": false, \"sortOrder\": 1, }";
            //string parentPayload = "{  \r\n\t\"Id\": \"" + id + "\",  \r\n\t\"productionTypeId\": \"DWA2NF4KJ7\",  \r\n\t\"name\": \"20 CENTURY FOX TV\",  \r\n\t\"rentalAgent1Id\": \"PVANDENBRI\",  \r\n\t\"rentalAgent2Id\": \"RZQ0OOLT3F\",  \r\n\t\"locationId\": \"UGATRILITS\",  \r\n\t\"customField1Id\": null,  \r\n\t\"customField2Id\": null,  \r\n\t\"customField3Id\": null,  \r\n\t\"notes\": \"Some Notes\",  \r\n\t\"addressLine1\": \"1208  RQUE PSDG DJMW RU\",  \r\n\t\"addressLine2\": \"Address Line 2\",  \r\n\t\"addressLine2B\": \"Address Line 2B\",  \r\n\t\"addressLine3\": \"TAZZTTV\",  \r\n\t\"state\": \"GA\",  \r\n\t\"zipCode\": \"30336\",  \r\n\t\"addressLine4\": \"PQ\",  \r\n\t\"phone\": \"984 111-0416\",  \r\n\t\"fax\": \"(712) 936-7974\",  \r\n\t\"shippingName\": \"HELLO STRANGER\",  \r\n\t\"shippingAddressLine1\": \"926 IXKOLQ VOXBBX,MLZ NDZAO\",  \r\n\t\"shippingAddressLine2\": \"Address 2\",  \r\n\t\"shippingAddressLine2B\": \"shipping Address Line 2 b\",  \r\n\t\"shippingAddressLine3\": \"HBO YUZX\",  \r\n\t\"shipState\": \"NY\",  \r\n\t\"shipZipCode\": 8902,  \r\n\t\"shippingAddressLine4\": \"WR\",  \r\n\t\"email\": \"llbtqiupc55@zjcre.com\",  \r\n\t\"creditThru\": \"2014-10-30T00:00:00\",  \r\n\t\"creditLimit\": 6000.00,  \r\n\t\"creditApproved\": false,  \r\n\t\"creditHold\": false,  \r\n\t\"poRequired\": false,  \r\n\t\"signedTerms\": false,  \r\n\t\"arCombined\": false,  \r\n\t\"dailyWeekly\": \"Daily\",  \r\n\t\"daysPerWeek\": 1.0000,  \r\n\t\"discountPercentage\": 3.0000,  \r\n\t\"salesDiscPct\": 34.0000,  \r\n\t\"rentalPriceListId\": \"TCS\",  \r\n\t\"salesPriceListId\": \"INTSALES\",  \r\n\t\"paymentTypeId\": \"CHECK\",  \r\n\t\"billingType\": \"Regular Bill\",  \r\n\t\"termsId\": \"NET30\",  \r\n\t\"contactAcct\": \"CANDACE CASON\",  \r\n\t\"billingMethodId\": \"2SJD0S588H\",  \r\n\t\"contactNotes\": \"Some Contact Note\",  \r\n\t\"certificateOfIns\": false,  \r\n\t\"insCo\": \"CHUBB\",  \r\n\t\"insNotes\": \"Some Insurance Note\",  \r\n\t\"insAmount\": 3000000.00,  \r\n\t\"insuranceExpired\": \"2018-11-01T00:00:00\",  \r\n\t\"insPolicy\": \"USUIEN272238716\",  \r\n\t\"mbsCustomerClassId\": \"DEFAULT\",  \r\n\t\"inactive\": false,  \r\n\t\"comesFromSphere\": false,  \r\n\t\"balance\": 0.0000,  \r\n\t\"mtdRev\": 8111853.0100,  \r\n\t\"ytdRev\": 8111853.0100,  \r\n\t\"cumRev\": 8111853.0100  \r\n}";

            //id = GenerateRandomInt(10000, 99999).ToString();
            //string taxPayload = "{ \"glAccount1Id\": \"1631\", \"glAccount1Description\": \"Office - Furniture\", \"glAccount2Id\": \"1631\", \"glAccount2Description\": \"Office - Furniture\", \"id\": " + id + " }";

            apiRequests = new List<(HttpMethod Method, string Url, string paramdata)>
                         {
                                 //(HttpMethod.Put, "extapi/v1/Customer", customerPayload),
                                 (HttpMethod.Put, "extapi/v1/Department/"+departmentRecNo, departmentTypePayload),
                                 //(HttpMethod.Put, "extapi/v1/Parent", parentPayload),
                                 (HttpMethod.Put, "extapi/v1/PaymentType/"+peymentRecNo, PaymentTypePayload),
                                 //(HttpMethod.Put, "extapi/v1/Tax",taxPayload),
                         };
        }

        static int GenerateRandomInt(int alpha, int beta)
        {
            Random random = new Random();
            return random.Next(alpha, beta + 1); // beta + 1 makes the range inclusive  
        }

        public async Task RunAPIs()
        {
            AddExternalApiRequests(Token, apiRequests);
            // Execute API calls
            await ExecuteApiRequests();
        }

        static async Task ExecuteApiRequests()
        {
            foreach (var api in ExternalApiList)
            {
                var response = await CallAPI(api, "application/json-patch+json");
                var statusCode = ExtractStatusCode(response);

                if (statusCode != 200)
                {
                    Console.WriteLine($"\n\n[ERROR]- HttpMethod: {api.httpMethod}- API: {api.subUrl} - Status Code: {statusCode} - Message: Request failed.");
                }
                else
                {
                    Console.WriteLine($"\n\n[SUCCESS]- HttpMethod: {api.httpMethod}- API: {api.subUrl} - Status Code: {statusCode} - Message: Request was successful.");
                    // Uncomment to view response
                }
                Console.WriteLine($"[Response]- {response}");
            }
        }
    }
}