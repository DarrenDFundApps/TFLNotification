using Microsoft.AspNetCore.Mvc;
using TFLNotifications.API.Services;
using TFLNotifications.Domain;

namespace TFLNotifications.API.Controllers;

[Route("status")]
[ApiController]
public class StatusController : ControllerBase
{
    private StatusService _statusService = new StatusService();
    [HttpGet("line/{lineName}")]
    public IEnumerable<StationStatusModel> GetByLineStatus(string lineName)
    {
        var lineEnum = (Lines)Enum.Parse(typeof(Lines), lineName, true);

        return _statusService.GetByLineStatus(lineEnum);
    }

    [HttpGet("all")]
    public IEnumerable<StationStatusModel> GetAll()
    {
        return _statusService.GetAll();
    }

    [HttpGet("station/{stationName}")]
    public IEnumerable<StationStatusModel> GetByStationName(string stationName)
    {
        return _statusService.GetStationStatus(stationName);
    }
}