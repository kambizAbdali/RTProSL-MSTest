
using RTProSL_ExternalAPI_Test;

public class Program
{

    static async Task Main()
    {
        HttpGetAPI httpGetAPI = new HttpGetAPI();
        await httpGetAPI.RunAPIs();

        HttpPostAPI httpPostAPI = new HttpPostAPI();
        await httpPostAPI.RunAPIs();

        HttpPutAPI httpPutAPI = new HttpPutAPI();
        await httpPutAPI.RunAPIs();
    }
}
