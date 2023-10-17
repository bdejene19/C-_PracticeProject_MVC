using System;
using Microsoft.AspNetCore.Mvc;
namespace TestProject.Players;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        OutField OutFieldStats = new () { First = "", Last = "", ShirtNum = 11, Appearances = 33, Starts = 12 };
        PlayerClass TempPlayer = new PlayerClass(OutFieldStats) { };
        TempPlayer.ChangeName("Bemnet", "Dejene");
        Console.Write(TempPlayer.PlayerDetails.Fullname);
        List<string> Names = new() { "Bemnet", "Bruk", "Betty", "Teddy"};
        List<string> Ages = new() { "25", "32", "30", "Teddy" };
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

