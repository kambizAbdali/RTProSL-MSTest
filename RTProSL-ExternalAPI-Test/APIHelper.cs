using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace RTProSL_ExternalAPI_Test
{
    public class APIHelper : JsonHelper
    {
        public List<(HttpMethod Method, string Url, string ParamData)> apiRequests;
        public APIHelper()
        {
            InitializeExternalApiList();
            GenerateToken().GetAwaiter().GetResult();
        }
        public void InitializeExternalApiList()
        {
            ExternalApiList = new List<APIData>();
        }


        public struct APIData
        {
            public HttpMethod httpMethod;
            public string subUrl;
            public string token;
            public string paramdata;
        }

        public static async Task<string> CallAPI(APIData apiData, string mediaTypeHeaderValue = "application/json-patch+json")
        {
            try
            {
                var httpClient = new HttpClient();
                var httpRequestMessage = new HttpRequestMessage(apiData.httpMethod, apiUrl + $"{apiData.subUrl}");
                httpRequestMessage.Headers.Add("accept", "*/*");
                if (!string.IsNullOrEmpty(apiData.token))
                    httpRequestMessage.Headers.Add("Authorization", $"Bearer {apiData.token}");
                if (!string.IsNullOrEmpty(apiData.paramdata))
                {
                    //var content = new StringContent(apiData.paramdata, null, mediaTypeHeaderValue);
                    var content = new StringContent(apiData.paramdata, Encoding.UTF8, mediaTypeHeaderValue);

                    httpRequestMessage.Content = content;
                }

                var response = await httpClient.SendAsync(httpRequestMessage);
                //response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return string.Empty;
            }
        }

        public class LoginModel
        {
            public string Token { get; set; }
        }

        const string apiUrl = "http://local.npgnasr.com:8050/";// "http://192.168.1.153:8088/api/";
        const string userName = "Kambiz";
        const string password = "hd";
        public static List<APIData> ExternalApiList;
        public static string Token { get; set; }
        public static void AddExternalApiRequests(string token, List<(HttpMethod Method, string Url, string ParamData)> apiRequests)
        {
            foreach (var (method, url, paramdata) in apiRequests)
            {
                ExternalApiList.Add(new APIData
                {
                    httpMethod = method,
                    subUrl = url,
                    paramdata = paramdata,
                    token = token
                });
            }
        }

        public static async Task<LoginModel> GenerateToken()
        {
            //call API Login 
            var dataLogin = await CallAPI(new APIData
            {
                httpMethod = HttpMethod.Post,
                subUrl = "api/account/login",
                paramdata = JsonConvert.SerializeObject(new
                {
                    userName = userName,
                    password = password
                }),
                token = ""
            });
            var result = JsonConvert.DeserializeObject<LoginModel>(dataLogin);
            Token = result.Token;
            return result;
        }

        public static int? ExtractStatusCode(string jsonString)
        {
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                JsonElement root = doc.RootElement;
                if (root.TryGetProperty("statusCode", out JsonElement statusCodeElement))
                {
                    return statusCodeElement.GetInt32();
                }
            }
            return null; // Return null if statusCode is not found
        }

        public string FetchFirstItemFromList(string apiName)
        {
            string id = default(string);
            APIData data = new APIData
            {
                httpMethod = HttpMethod.Get,
                subUrl = "extapi/v1/" + apiName + "?PageSize=1&PageNumber=1",
                token = Token
            };

            // Fire-and-forget but store the response in a local variable  
            var response = CallAPI(data).GetAwaiter().GetResult(); ; // Capture the result here  
            return response;
        }
    }
}