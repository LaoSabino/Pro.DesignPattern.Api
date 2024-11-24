using Pro.DesingPatter.Core.Interfaces;
using Pro.DesingPatter.Core.Models;

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
    }
}
