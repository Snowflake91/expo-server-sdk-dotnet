using System.Collections.Generic;
using Newtonsoft.Json;

namespace Expo.Server.SDK.Models;

[JsonObject (MemberSerialization.OptIn)]
public class PushTicketResponse {
    [JsonProperty (PropertyName = "data")]
    public List<PushTicketStatus> PushTicketStatuses { get; set; }

    [JsonProperty (PropertyName = "errors")]
    public List<PushTicketErrors> PushTicketErrors { get; set; }

}

[JsonObject (MemberSerialization.OptIn)]
public class PushTicketStatus {

    [JsonProperty (PropertyName = "status")]
    public string TicketStatus { get; set; }

    [JsonProperty (PropertyName = "id")]
    public string TicketId { get; set; }

    [JsonProperty (PropertyName = "message")]
    public string TicketMessage { get; set; }

    [JsonProperty (PropertyName = "details")]
    public object TicketDetails { get; set; }
}

[JsonObject (MemberSerialization.OptIn)]
public class PushTicketErrors {
    [JsonProperty (PropertyName = "code")]
    public string ErrorCode { get; set; }

    [JsonProperty (PropertyName = "message")]
    public string ErrorMessage { get; set; }
    
    [JsonProperty (PropertyName = "details")]
    public Dictionary<string, object> ErrorDetails { get; set; }
    
    [JsonProperty (PropertyName = "isTransient")]
    public bool? IsTransientError { get; set; }
}