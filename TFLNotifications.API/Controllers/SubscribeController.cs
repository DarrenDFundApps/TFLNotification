using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TFLNotifications.API.Controllers;

[Route("subscribe")]
[ApiController]
public class SubscribeController : ControllerBase
{
    [HttpGet("/line/{lineName}")]
    public string GetByLineStatus(string lineName)
    {


        return $"Done for {lineName}";
    }

    [HttpGet("/all")]
    public HttpStatusCode GetAll()
    {
        return HttpStatusCode.Accepted;
    }

    [HttpGet("/station/{stationName}")]
    public HttpStatusCode GetByStationName(string stationName)
    {
        return HttpStatusCode.Accepted;
    }
}