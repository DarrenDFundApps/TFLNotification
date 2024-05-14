using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using TFLNotifications.Domain;
using TFLNotifications.Repository;

namespace TFLNotifications.PullDown;

public class TubeInformation
{
    private readonly HttpClient _client = new();
    private StationStatusContext _context = new StationStatusContext();
    private readonly string _url = "https://api.tfl.gov.uk/Line/Mode/tube/Status?detail=true&app_key=21aa7054f2ea47bea3eef2369d559571";
    
    public TubeInformation()
    {
    }

    public async Task GetAsync()
    {
        var response = await _client.GetAsync(_url);
        if (response.IsSuccessStatusCode)
        {
            var lineStatuses = await response.Content.ReadFromJsonAsync<LineStatus[]>();

            if (lineStatuses == null) {
                return;
            }

            var stations = await _context.Stations.ToListAsync();
            foreach (var station in stations) {
                _context.Stations.Remove(station);
            }
            
            await _context.SaveChangesAsync();
            
            var stationStatuses = new List<StationStatus>();
            
            foreach (var lineStatus in lineStatuses)
            {
                var status = lineStatus.lineStatuses.FirstOrDefault();

                if (status == null) {
                    return;
                }

                if (status.statusSeverity != 6 && status.statusSeverity != 9) continue;
                
                Enum.TryParse(lineStatus.name, true, out Lines line);
                var reason = status.reason;
                var fromDate = DateTime.Parse(status.validityPeriods.First().fromDate);

                stationStatuses.AddRange(lineStatus.routeSections.Select(station => new StationStatus()
                {
                    StationId = Guid.NewGuid(),
                    StationName = station.originationName,
                    Status = status.statusSeverity == 6 ? SeverityStatus.Major : SeverityStatus.Minor,
                    Description = status.reason,
                    FromDate = fromDate,
                    Line = line
                }));
            }
            
            await _context.AddRangeAsync(stationStatuses);
            await _context.SaveChangesAsync();
        }
    }
}