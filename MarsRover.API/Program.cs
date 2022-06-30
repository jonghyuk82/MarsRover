using MarsRover.API.Config;
using MarsRover.API.Models;
using MarsRover.API.Services;
using MarsRover.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddMemoryCache();
    services.Configure<MarsApiOptions>(builder.Configuration.GetSection("MarsApiOptions"));
    services.AddTransient<IMarsRoverService, MarsRoverService>();
    services.AddHttpClient<IMarsRoverService, MarsRoverService>();
}