var cities = new Dictionary<string, (double Temperature, double WindSpeed)>
{
    ["Bergen"] = (9.5, 7.2),
    ["Oslo"] = (12.1, 3.4),
    ["Trondheim"] = (7.8, 5.0),
    ["Stavanger"] = (10.3, 8.9),
    ["Røros"] = (-2.4, 4.1),
    ["Ålesund"] = (8.6, 10.5),
};
const string ValidToken = "wk_live_4f9a2c7e1b8d6a3f";

var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/v1/current", (string? city, string? token) =>
{
    if (token != ValidToken) return Results.Unauthorized();
    if (city is null || !cities.TryGetValue(city, out var w)) return Results.NotFound();
    return Results.Ok(new { city, temperature = w.Temperature, windSpeed = w.WindSpeed });
});

app.Run("http://localhost:5000");
