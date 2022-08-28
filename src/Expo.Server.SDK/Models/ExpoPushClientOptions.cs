namespace Expo.Server.SDK.Models;

public class ExpoPushClientOptions
{
    public ExpoPushClientOptions()
    {
        ExpoBackendHost = "https://exp.host";
        PushSendPath = "/--/api/v2/push/send";
        PushGetReceiptsPath = "/--/api/v2/push/getReceipts";
        MaxConnectionsPerServer = 6;
    }

    public string ExpoBackendHost { get; set; }
    public string PushSendPath { get; set; }
    public string PushGetReceiptsPath { get; set; }
    public string HttpClientName { get; set; }
    public int MaxConnectionsPerServer { get; set; }
    
    public const string DefaultHttpClientName = "ExpoClient";
}