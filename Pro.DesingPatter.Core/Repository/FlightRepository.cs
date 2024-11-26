using Pro.DesingPatter.Core.Interfaces;
using Pro.DesingPatter.Core.Models;

namespace Pro.DesingPatter.Core.Repository;

public class FlightRepository : IFlightRepository
{
    private readonly List<Flight> _flights = [];
    public void Save(Flight flight)
    {
        var existingFlight = _flights.FirstOrDefault(f => f.FlightNumber == flight.FlightNumber);
        if (existingFlight != null)
        {
            // Atualizar voo existente

            existingFlight.Origin = flight.Origin;
            existingFlight.Destination = flight.Destination;
            existingFlight.DepartureTime = flight.DepartureTime;
            existingFlight.ArrivalTime = flight.ArrivalTime;
        }
        else
        { // Adicionar novo voo

            _flights.Add(flight);
        }
    }
    public List<Flight> GetAllFlights() { return _flights; }
}