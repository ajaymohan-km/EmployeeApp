using Microsoft.AspNetCore.Mvc;
using webapi.Model;
using webapi.Repository;
using webapi.Service;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly EmployeeService _service;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, EmployeeService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("summer")]
    public IActionResult GetSummerData()
    {
        // Your logic to retrieve summer data
        // For simplicity, let's return a static response
        var summerData = "This is summer data";
        return Ok(summerData);
    }

    [HttpPost("saveEmployee")]
    public IActionResult CreateEmployee([FromBody] EmployeeModel employee)
    {

       Response response = _service.InsertEmployee(employee);

        return Ok(response);
    }


}
