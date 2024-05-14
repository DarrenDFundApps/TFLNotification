using System.Text;
using System.Text.Json;
using TFLNotifications.API.Controllers.Payload;
using TFLNotifications.API.Services;

namespace TFLNotifications.API.Helpers;

public static class SlackHelper
{
    public static async Task PostMessageToSlack(string url, string message)
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(url),
        };

        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                text = message
            }),
            Encoding.UTF8,
            "application/json");

        using var response = await httpClient.PostAsync(
            "",
            jsonContent);

        response.EnsureSuccessStatusCode();
    }

    public static string GenerateMessage(SlackAction action)
    {
        var statusService = new StatusService();
        switch (action.Action)
        {
            case ActionType.StationStatus:
                var stationStatus = statusService.GetStationStatus(action.Parameter);
                if (!stationStatus.Any())
                {
                    return $"{action.Parameter} is fine :large_green_circle:";
                }

                return action.Parameter + " is not fine. :red_circle:" + string.Join("; ",stationStatus.Select(s => $"Line: {s.Line.ToString()}, Severity: {s.Status.ToString()}, Description: {s.Description}"));
        }

        return "Error";
    }
}