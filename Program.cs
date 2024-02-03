using BattleshipGame.Services;
using DigitTest_BattleshipGame.Models;
using DigitTest_BattleshipGame.Services;
using static BattleshipGame.Controllers.BattleshipController;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddSingleton<ShipPositions>(ServiceProvider => {
    string shipsJsonPath = "ships.json";
    string jsonString = System.IO.File.ReadAllText(shipsJsonPath);
    var shipPositions = JsonSerializer.Deserialize<ShipPositions>(jsonString);
    return shipPositions;
});
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
