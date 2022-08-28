using System.Collections.Generic;
using Newtonsoft.Json;

namespace Expo.Server.SDK.Models;

[JsonObject(MemberSerialization.OptIn)]
public class PushReceiptResponse
{
    [JsonProperty(PropertyName = "data")]
    public Dictionary<string,PushTicketDeliveryStatus> PushTicketReceipts { get; set; }

    [JsonProperty(PropertyName = "errors")]
    public List<PushReceiptErrorInformation> ErrorInformations { get; set; }
}

[JsonObject(MemberSerialization.OptIn)]
public class PushTicketDeliveryStatus
{
    [JsonProperty(PropertyName = "status")]
    public string DeliveryStatus { get; set; }

    [JsonProperty(PropertyName = "message")]
    public string DeliveryMessage { get; set; }

    [JsonProperty(PropertyName = "details")]
    public object DeliveryDetails { get; set; }
}

[JsonObject(MemberSerialization.OptIn)]
public class PushReceiptErrorInformation
{
    [JsonProperty(PropertyName = "code")]
    public string ErrorCode { get; set; }

    [JsonProperty(PropertyName = "message")]
    public string ErrorMessage { get; set; }
}