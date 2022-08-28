using System.Collections.Generic;
using System.Threading.Tasks;
using Expo.Server.SDK.IntegrationTests.Models;
using Expo.Server.SDK.Interfaces;
using Expo.Server.SDK.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expo.Server.SDK.IntegrationTests.Controllers;

public class TestExpoClientController : Controller
{
    private readonly IExpoPushClient _expoPushClient;

    public TestExpoClientController(IExpoPushClient expoPushClient)
    {
        _expoPushClient = expoPushClient;
    }

    [HttpPost]
    [Route("expo/push_ticket")]
    public async Task<IActionResult> PushExpoTicket([FromBody]PushTicketRequestModels model)
    {
        var tickets = await _expoPushClient.PushSendAsync(new PushTicketRequest()
        {
            PushTo = model.tos,
            PushTitle = model.title,
            PushSubTitle = model.sub_title
        });
        
        return Ok(tickets);
    }
    
    [HttpGet]
    [Route("expo/get_receipt")]
    public async Task<IActionResult> GetExpoReceipt(List<string> ids)
    {
        var receipts = await _expoPushClient.PushGetReceiptsAsync(new PushReceiptRequest()
        {
            PushTicketIds = ids
        });
        
        return Ok(receipts);
    }
}