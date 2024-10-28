namespace RTProSL_ExternalAPI_Test
{
    public class HttpGetAPI : APIHelper
    {
        public HttpGetAPI()
        {
            InitializeApiRequests();
        }

        private void InitializeApiRequests()
        {
            apiRequests = new List<(HttpMethod Method, string Url, string ParamData)>
                         {
                             (HttpMethod.Get, "extapi/v1/Customer?PageSize=1&PageNumber=1",string.Empty),
                             (HttpMethod.Get, "extapi/v1/Department?PageSize=1&PageNumber=1",string.Empty),
                             (HttpMethod.Get, "extapi/v1/Invoice/QuantaUploaded?PageSize=1&PageNumber=1",string.Empty),
                             (HttpMethod.Get, "extapi/v1/Location?PageSize=1&PageNumber=1", string.Empty),
                             (HttpMethod.Get, "extapi/v1/Parent?PageSize=1&PageNumber=1", string.Empty),
                             (HttpMethod.Get, "extapi/v1/PaymentType?PageSize=1&PageNumber=1", string.Empty),
                             (HttpMethod.Get, "extapi/v1/Tax?PageSize=1&PageNumber=1", string.Empty),
                         };
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
                var response = await CallAPI(api);
                JsonHelper jsonHelper = new JsonHelper();
                var keys = jsonHelper.FetchOneFieldPerDataType(response);
                var mainApiSubUrl = api.subUrl.Substring(0, api.subUrl.IndexOf('?') + 1);

                foreach (var item in keys)
                {
                    var newUrl = mainApiSubUrl + item.Value.Trim() + "=~eq~" + jsonHelper.GetJsonValue(response, item.Value.Trim());
                    APIData newAPIData = api;
                    newAPIData.subUrl = newUrl;
                    var newResponse = await CallAPI(newAPIData);
                    bool filterValidate = jsonHelper.DoesJsonExist(newResponse, response);
                    if (!filterValidate)
                        Console.WriteLine("---Error: API filter validate does not work correctly");
                }

                var statusCode = ExtractStatusCode(response);

                if (statusCode != 200)
                {
                    Console.WriteLine($"\n\n[ERROR]- HttpMethod: {api.httpMethod}- API: {api.subUrl} - Status Code: {statusCode} - Message: Request failed.");
                }
                else
                {
                    Console.WriteLine($"\n\n[SUCCESS]- HttpMethod: {api.httpMethod}- API: {api.subUrl} - Status Code: {statusCode} - Message: Request was successful.");
                    // Uncomment to view response
                    Console.WriteLine($"[Response]- {response}");
                }
            }
        }
    }
}
