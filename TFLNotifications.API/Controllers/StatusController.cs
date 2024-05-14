using Microsoft.AspNetCore.Mvc;
using TFLNotifications.Domain;

namespace TFLNotifications.API.Controllers;

[Route("status")]
[ApiController]
public class StatusController : ControllerBase
{

    private readonly IEnumerable<StationStatusModel> _stations = new List<StationStatusModel>()
    {
        new("Moorgate", SeverityStatus.Minor, "Broken", DateTime.Now, Lines.Northern),
        new("Ealing", SeverityStatus.Major, "Broken Seriously", DateTime.Now, Lines.District),
        new("Victoria", SeverityStatus.Minor, "Broken", DateTime.Now, Lines.Victoria)
    };

    [HttpGet("line/{lineName}")]
    public IEnumerable<StationStatusModel> GetByLineStatus(string lineName)
    {
        var lineEnum = (Lines)Enum.Parse(typeof(Lines), lineName, true);;
        var stations = _stations.Where(s => s.Line == lineEnum);

        return stations;
    }

    [HttpGet("all")]
    public IEnumerable<StationStatusModel> GetAll()
    {
        return _stations;
    }

    [HttpGet("station/{stationName}")]
    public IEnumerable<StationStatusModel> GetByStationName(string stationName)
    {
        var stations = _stations.Where(s => s.StationName == stationName);
        return stations;
    }
}