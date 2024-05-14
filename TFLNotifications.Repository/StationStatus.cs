using System.ComponentModel.DataAnnotations;
using TFLNotifications.Domain;

namespace TFLNotifications.Repository;

public class StationStatus
{
    [Key]
    public Guid StationId { get; set; }
    public string StationName { get; set; }
    public SeverityStatus Status { get; set; }
    public string Description { get; set; }
    public DateTime FromDate { get; set; }
    public Lines Line { get; set; }
}