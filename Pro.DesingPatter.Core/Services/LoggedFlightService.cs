using Microsoft.Extensions.Logging;
using Pro.DesingPatter.Core.Interfaces;
using Pro.DesingPatter.Core.Models;

namespace Pro.DesingPatter.Core.Services;

public class LoggedFlightService(IFlightService inner, ILogger<LoggedFlightService> logger) : IFlightService
{
    public List<Flight> GetFlights(string origin, string destination)
    {
        logger.LogInformation("Searching for flights from {Origin} to {Destination}", origin, destination);
        var flights = inner.GetFlights(origin, destination);
        logger.LogInformation("Found {Count} flights", flights.Count); return flights;
    }
}
