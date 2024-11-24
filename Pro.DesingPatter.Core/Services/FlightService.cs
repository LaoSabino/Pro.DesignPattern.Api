using Pro.DesingPatter.Core.Interfaces;
using Pro.DesingPatter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.DesingPatter.Core.Services;

public class FlightService : IFlightService
{
    public List<Flight> GetFlights(string origin, string destination)
    {
        // Simulação de busca de voos (substitua pela lógica real)

        return [new() { FlightNumber = "FL123", Origin = origin, Destination = destination, DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(2) }];
    }
}