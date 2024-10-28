// Develop By Mohammad_Keshavarz

using Newtonsoft.Json;

class Program
{
    static async Task Main()
    {

        //call API Login 
        var dataLogin = await ReadData(HttpMethod.Post, "Account/login", "", "{\"userName\": \"kambiz\", \"password\": \"hd\"}");
        var userLogin = JsonConvert.DeserializeObject<LoginModel>(dataLogin);

        //Call API UserCode/GetAll 
        var data = await ReadData(HttpMethod.Post, "UserCode/GetAll", userLogin.Token, "{\"entityFilters\": {\"userId\": \"\"}}");
        var userList = JsonConvert.DeserializeObject<DataList>(data);
        userList.Model = userList.Model.Where(x => !x.Inactive).ToList();

        foreach (var usr in userList.Model)
        {
            var dataLoginusr = await ReadData(HttpMethod.Post, "Account/login", "", "{\"userName\": \"" + usr.Id + "\", \"password\": \"hd\"}");
            if (!string.IsNullOrEmpty(dataLoginusr))
            {
                var loginUsr = JsonConvert.DeserializeObject<LoginModel>(dataLoginusr);

                //Go to Department List
                var DepartmentList = await ReadData(HttpMethod.Get, "Department/GetComboGridList?includeInactive=true", loginUsr.Token, "");
                Console.WriteLine("DepartmentList" + "|" + " " + "UserID:" + usr.Id + "|" + " " + "UserNumber:" + (userList.Model.IndexOf(usr) + 1));

                //Go to Production List
                var ProductionList = await ReadData(HttpMethod.Post, "Customer/GetAll", loginUsr.Token, "{\"entityFilters\": {\"includeClosed\": true,\"includeHistory\": true}}");
                Console.WriteLine("ProductionList" + "|" + " " + "UserID:" + usr.Id + "|" + " " + "UserNumber:" + (userList.Model.IndexOf(usr) + 1));

                //Go to Invoise List
                var InvoiseList = await ReadData(HttpMethod.Post, "Invoice/GetAll", loginUsr.Token, "{\"entityFilters\": {\"orderNo\": true,\"parentId\": true}}");
                Console.WriteLine("InvoiseList" + "   |" + " " + "UserID:" + usr.Id + "|" + " " + "UserNumber:" + (userList.Model.IndexOf(usr) + 1));


                //Go to Equipment List
                var EquipmentList = await ReadData(HttpMethod.Post, "Equipment/GetAll", loginUsr.Token, "{\"entityFilters\":{\"currencyId\":\"USD\",\"currencyDescription\":\"US Dollar\",\"locationId\":\"HOLLYWOOD\",\"locationDescription\":\"Raleigh Studios \"}}");
                Console.WriteLine("EquipmentList" + " |" + " " + "UserID:" + usr.Id + "|" + " " + "UserNumber:" + (userList.Model.IndexOf(usr) + 1));


                //Go to orderList List
                var orderListList = await ReadData(HttpMethod.Get, "Order/GetOrderTransferComboGridList", loginUsr.Token, "");
                Console.WriteLine("OrderListList" + " |" + " " + "UserID:" + usr.Id + "|" + " " + "UserNumber:" + (userList.Model.IndexOf(usr) + 1));

                Console.WriteLine("----------------------------------------------------------------");

            }
        }
    }

    public static async Task<string> ReadData(HttpMethod method, string url, string token, string paramdata)
    {
        try
        {
            var clientGetUser = new HttpClient();
            var request1GetUser = new HttpRequestMessage(method, $"http://192.168.1.153:8088/api/{url}");
            request1GetUser.Headers.Add("accept", "*/*");
            if (!string.IsNullOrEmpty(token))
                request1GetUser.Headers.Add("Authorization", $"Bearer {token}");
            if (!string.IsNullOrEmpty(paramdata))
            {
                var contentGetUser = new StringContent(paramdata, null, "application/json-patch+json");
                request1GetUser.Content = contentGetUser;
            }

            var responseGetUser = await clientGetUser.SendAsync(request1GetUser);
            responseGetUser.EnsureSuccessStatusCode();
            return await responseGetUser.Content.ReadAsStringAsync();
        }
        catch
        {
            return string.Empty;
        }

    }
    class DataList
    {
        public List<User> Model { get; set; }
    }
    class User
    {
        public string Id { get; set; }
        public bool Inactive { get; set; }
    }
    class LoginModel
    {
        public string Token { get; set; }
    }
}