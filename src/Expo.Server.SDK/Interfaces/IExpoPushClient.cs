using System.Threading.Tasks;
using Expo.Server.SDK.Models;

namespace Expo.Server.SDK.Interfaces;

public interface IExpoPushClient
{
    Task<PushTicketResponse> PushSendAsync(PushTicketRequest pushTicketRequest);
    Task<PushReceiptResponse> PushGetReceiptsAsync(PushReceiptRequest pushReceiptRequest);
}