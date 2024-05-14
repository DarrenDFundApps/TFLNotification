public class LineStatus
{
    public string type { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string modeName { get; set; }
    public object[] disruptions { get; set; }
    public string created { get; set; }
    public string modified { get; set; }
    public LineStatuses[] lineStatuses { get; set; }
    public RouteSections[] routeSections { get; set; }
    public ServiceTypes[] serviceTypes { get; set; }
    public Crowding crowding { get; set; }
}

public class LineStatuses
{
    public string type { get; set; }
    public int id { get; set; }
    public int statusSeverity { get; set; }
    public string statusSeverityDescription { get; set; }
    public string created { get; set; }
    public ValidityPeriods[] validityPeriods { get; set; }
    public string lineId { get; set; }
    public string reason { get; set; }
    public Disruption disruption { get; set; }
}

public class ValidityPeriods
{
    public string type { get; set; }
    public string fromDate { get; set; }
    public string toDate { get; set; }
    public bool isNow { get; set; }
}

public class Disruption
{
    public string type { get; set; }
    public string category { get; set; }
    public string categoryDescription { get; set; }
    public string description { get; set; }
    public AffectedRoutes[] affectedRoutes { get; set; }
    public AffectedStops[] affectedStops { get; set; }
    public string closureText { get; set; }
}

public class AffectedRoutes
{
    public string type { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string direction { get; set; }
    public string originationName { get; set; }
    public string destinationName { get; set; }
    public Via via { get; set; }
    public bool isEntireRouteSection { get; set; }
    public RouteSectionNaptanEntrySequence[] routeSectionNaptanEntrySequence { get; set; }
}

public class Via
{
    public string type { get; set; }
    public int ordinal { get; set; }
    public StopPoint stopPoint { get; set; }
}

public class StopPoint
{
    public string type { get; set; }
    public string naptanId { get; set; }
    public object[] modes { get; set; }
    public string icsCode { get; set; }
    public string stationNaptan { get; set; }
    public object[] lines { get; set; }
    public object[] lineGroup { get; set; }
    public object[] lineModeGroups { get; set; }
    public bool status { get; set; }
    public string id { get; set; }
    public string commonName { get; set; }
    public string placeType { get; set; }
    public object[] additionalProperties { get; set; }
    public object[] children { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public string hubNaptanCode { get; set; }
}

public class RouteSectionNaptanEntrySequence
{
    public string type { get; set; }
    public int ordinal { get; set; }
    public StopPoint1 stopPoint { get; set; }
}

public class StopPoint1
{
    public string type { get; set; }
    public string naptanId { get; set; }
    public object[] modes { get; set; }
    public string icsCode { get; set; }
    public string stationNaptan { get; set; }
    public object[] lines { get; set; }
    public object[] lineGroup { get; set; }
    public object[] lineModeGroups { get; set; }
    public bool status { get; set; }
    public string id { get; set; }
    public string commonName { get; set; }
    public string placeType { get; set; }
    public object[] additionalProperties { get; set; }
    public object[] children { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public string hubNaptanCode { get; set; }
}

public class AffectedStops
{
    public string type { get; set; }
    public string naptanId { get; set; }
    public string stationNaptan { get; set; }
    public bool status { get; set; }
    public string id { get; set; }
    public string commonName { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
}

public class RouteSections
{
    public string type { get; set; }
    public string name { get; set; }
    public string direction { get; set; }
    public string originationName { get; set; }
    public string destinationName { get; set; }
    public string originator { get; set; }
    public string destination { get; set; }
    public string serviceType { get; set; }
    public string validTo { get; set; }
    public string validFrom { get; set; }
}

public class ServiceTypes
{
    public string type { get; set; }
    public string name { get; set; }
    public string uri { get; set; }
}

public class Crowding
{
    public string type { get; set; }
}

