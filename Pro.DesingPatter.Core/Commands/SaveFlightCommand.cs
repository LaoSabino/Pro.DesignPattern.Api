using Pro.DesingPatter.Core.Interfaces;
using Pro.DesingPatter.Core.Models;

namespace Pro.DesingPatter.Core.Commands;
public class SaveFlightCommand(Flight flight, IFlightRepository flightRepository) : ICommand
{
    public void Execute()
    {
        flightRepository.Save(flight);
    }
}

