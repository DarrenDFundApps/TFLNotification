using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using TFLNotifications.API.Controllers.Payload;
using TFLNotifications.API.Helpers;

namespace TFLNotifications.API.Controllers;

[Route("subscribe")]
[ApiController]
public class SubscribeController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostSlack()
    {
        var rawRequestBody = await Request.GetRawBodyAsync();
        var payload = SlackCommandHelper.ExtractPayload(rawRequestBody);
        Console.WriteLine($"Raw request:{rawRequestBody}");
        Console.WriteLine($"Payload:{payload}");

        await SlackHelper.PostMessageToSlack(payload.RequestUrl, SlackHelper.GenerateMessage(payload.Action));
        return  Ok();
    }
}