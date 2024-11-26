using Pro.DesingPatter.Core.Models;

namespace Pro.DesingPatter.Core.Interfaces;

public interface IFlightService
{
    List<Flight> GetFlights(string origin, string destination);
}
