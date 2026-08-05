using System.Text.Json;
using WebApiLab.API.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
var app = builder.Build();

string jsonFile = File.ReadAllText("./Resources/64KB.json");
var people = JsonSerializer.Deserialize<List<Person>>(jsonFile, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

app.MapGet("/people", () => people)
.WithName("GetPeople")
.Produces<List<Person>>(StatusCodes.Status200OK);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
