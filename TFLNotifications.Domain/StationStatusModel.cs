namespace TFLNotifications.Domain;

public enum SeverityStatus
{
    Minor,
    Major
}

public enum Lines
{
    Bakerloo,
    Central,
    Circle,
    District,
    HammersmithAndCity,
    Jubilee,
    Metropolitan,
    Northern,
    Piccadilly,
    Victoria,
    WaterlooAndCity,
}


public class StationStatusModel(
    string stationName,
    SeverityStatus status,
    string description,
    DateTime fromDate,
    Lines line)
{
    public string StationName { get; init; } = stationName;
    public SeverityStatus Status { get; init; } = status;
    public string Description { get; init; } = description;
    public DateTime FromDate { get; init; } = fromDate;
    public Lines Line { get; init; } = line;
}