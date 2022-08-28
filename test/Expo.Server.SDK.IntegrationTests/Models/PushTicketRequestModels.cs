using System.Collections.Generic;

namespace Expo.Server.SDK.IntegrationTests.Models;

public class PushTicketRequestModels
{
    public string title { get; set; }
    public string sub_title { get; set; }
    public List<string> tos { get; set; }
}