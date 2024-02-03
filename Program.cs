using BattleshipGame.Services;
using DigitTest_BattleshipGame.Models;
using DigitTest_BattleshipGame.Services;
using static BattleshipGame.Controllers.BattleshipController;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddSingleton<ShipPositions>(ServiceProvider => {
    return ShipPositions.loadShipsPositionFromFile();
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
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

app.UseCors("AllowOrigin");

app.MapControllers();


app.Run();
