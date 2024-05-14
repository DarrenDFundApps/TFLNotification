using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TFLNotifications.Repository;

public class StationStatusContext : DbContext
{
    public DbSet<StationStatus> Stations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=127.0.0.1,1433;Database=StationStatus;TrustServerCertificate=True;ConnectRetryCount=0;User=sa;Password=YourStrong!Passw0rd;");
    }
}