using Pro.DesingPatter.Core.Commands;
using Pro.DesingPatter.Core.Interfaces;
using Pro.DesingPatter.Core.Models;
using Pro.DesingPatter.Core.Repository;

namespace Pro.DesingPatter.Api.Endpoint;

public static class FlightEndpoint
{
    public static void AddRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/flights", (string origin, string destination, IFlightService flightService) =>
        {
            var flights = flightService.GetFlights(origin, destination);

            return Results.Ok(flights);
        })
       .WithName("Busca")
       .Produces<List<Flight>>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Voos")
       .WithDescription("Serviço de Voos");

        app.MapPost("/flights", (Flight flight, IFlightRepository flightRepository) =>
        {
            var saveCommand = new SaveFlightCommand(flight, flightRepository);
            saveCommand.Execute();
            return Results.Ok();
        })
      .WithName("Salvar Flight")
      .Produces(StatusCodes.Status200OK)
      .ProducesProblem(StatusCodes.Status400BadRequest)
      .WithSummary("Voos")
      .WithDescription("Serviço de Salvar Voos");
    }
}
