using System.Net.Http;
using System.Threading.Tasks;
using Expo.Server.SDK.Helpers;
using Expo.Server.SDK.Interfaces;
using Expo.Server.SDK.Models;

namespace Expo.Server.SDK;

public class ExpoPushClient : IExpoPushClient
{
    private readonly HttpClient _httpClient;
    private readonly string _pushSendPath;
    private readonly string _pushGetReceiptsPath;

    public ExpoPushClient(IHttpClientFactory httpClientFactory, string httpClientName, string pushSendPath, string pushGetReceiptsPath)
    {
        _httpClient = httpClientFactory.CreateClient(httpClientName);
        _pushSendPath = pushSendPath;
        _pushGetReceiptsPath = pushGetReceiptsPath;
    }

    public async Task<PushTicketResponse> PushSendAsync(PushTicketRequest pushTicketRequest)
    {
        var ticketResponse =
            await _httpClient.SendPostAsync<PushTicketRequest, PushTicketResponse>(pushTicketRequest, _pushSendPath);
        
        return ticketResponse; 
    }

    public async Task<PushReceiptResponse> PushGetReceiptsAsync(PushReceiptRequest pushReceiptRequest)
    {
        var receiptResponse =
            await _httpClient.SendPostAsync<PushReceiptRequest, PushReceiptResponse>(pushReceiptRequest, _pushGetReceiptsPath);
        
        return receiptResponse;
    }
}