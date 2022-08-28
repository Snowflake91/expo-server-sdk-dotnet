using System.Collections.Generic;
using Newtonsoft.Json;

namespace Expo.Server.SDK.Models;

[JsonObject(MemberSerialization.OptIn)]
public class PushReceiptRequest
{
        
    [JsonProperty(PropertyName ="ids")]
    public List<string> PushTicketIds { get; set; }
}