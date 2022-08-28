using Expo.Server.SDK.Models;
using Newtonsoft.Json;
using Xunit;

namespace Expo.Server.SDK.UnitTests;

public class DeserializeObjectTest
{
    [Fact]
    public void DeserializeObjectError_Test()
    {
        var rawRsp =
            "{\"errors\":[{\"code\":\"PUSH_TOO_MANY_EXPERIENCE_IDS\",\"message\":\"All push notification messages in the same request must be for the same project; check the details field to investigate conflicting tokens.\",\"details\":{\"@A/b\":[\"ExponentPushToken[xJN-562gdcassdsada]\"],\"@B/C\":[\"ExponentPushToken[321321321321dsadsa-w8]\",\"ExponentPushToken[L6ZL-dsa13221dsad]\"]},\"isTransient\":false}]}";

        var rsp = JsonConvert.DeserializeObject(rawRsp);

        var rspObj = JsonConvert.DeserializeObject<PushTicketResponse>(rawRsp);
        
        Assert.NotNull(rsp);
        Assert.NotNull(rspObj);
    }
}