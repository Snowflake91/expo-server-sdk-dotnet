using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Expo.Server.SDK.Helpers;

internal static class HttpClientExtensions
{
    public static async Task<U> SendPostAsync<T, U>(this HttpClient httpClient, T requestObj, string path) where T : new()
    {

        var serializedRequestObj = JsonConvert.SerializeObject(requestObj, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        });
        
        var requestBody = new StringContent(serializedRequestObj, System.Text.Encoding.UTF8, "application/json");
        U responseBody;
        
        try
        {
            using var response = await httpClient.PostAsync(path, requestBody);
            var rawResponseBody = await response.Content.ReadAsStringAsync();
            responseBody = JsonConvert.DeserializeObject<U>(rawResponseBody);
        }
        catch
        {
            return default;
        }
        
        return responseBody;
    }
}