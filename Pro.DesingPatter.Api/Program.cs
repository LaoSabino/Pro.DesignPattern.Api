using Pro.DesingPatter.Api.Endpoint;
using Pro.DesingPatter.Core.Interfaces;
using Pro.DesingPatter.Core.Repository;
using Pro.DesingPatter.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMemoryCache();
builder.Services.AddLogging(config => config.AddConsole());
builder.Services.AddSingleton<IFlightService, FlightService>();
builder.Services.Decorate<IFlightService, LoggedFlightService>();
builder.Services.Decorate<IFlightService, CachedFlightService>();
builder.Services.AddSingleton<IFlightRepository, FlightRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddRoutes();

app.Run();


