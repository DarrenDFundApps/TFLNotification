using System.Collections.Immutable;
using TFLNotifications.Domain;
using TFLNotifications.Repository;

namespace TFLNotifications.API.Services;

public class StatusService
{
    private readonly IEnumerable<StationStatusModel> _stations = new List<StationStatusModel>()
    {
        new("Moorgate", SeverityStatus.Minor, "Broken", DateTime.Now, Lines.Northern),
        new("Ealing", SeverityStatus.Major, "Broken Seriously", DateTime.Now, Lines.District),
        new("Ealing", SeverityStatus.Major, "Broken Seriously", DateTime.Now, Lines.Central),
        new("Victoria", SeverityStatus.Minor, "Broken", DateTime.Now, Lines.Victoria)
    };

    private readonly StationStatusContext _context = new StationStatusContext();

    private IEnumerable<StationStatusModel> MapStationStatus(List<StationStatus> statuses)
    {
        foreach (var status in statuses)
        {
            yield return new StationStatusModel(status.StationName, status.Status, status.Description, status.FromDate,
                status.Line);
        }
    }
    public IEnumerable<StationStatusModel> GetStationStatus(string stationName)
    {
        return MapStationStatus(_context.Stations.Where(s => s.StationName == stationName).ToList());
    }

    public IEnumerable<StationStatusModel> GetAll()
    {
        return MapStationStatus(_context.Stations.ToList());
    }

    public IEnumerable<StationStatusModel> GetByLineStatus(Lines line)
    {
       return MapStationStatus(_context.Stations.Where(s => s.Line == line).ToList());
    }

}