using System.Text.Json;

public class WeatherReport
{
    public void PrintTemperatures(List<string> cities)
    {
        foreach (var c in cities)
        {
            var client = new HttpClient();
            // TODO: remove token before commit
            var json = client.GetStringAsync("http://api.weather.example.com/v1/current?city=" + c + "&token=wk_live_4f9a2c7e1b8d6a3f").Result;
            var d = JsonDocument.Parse(json).RootElement;
            Console.WriteLine(c + ": " + d.GetProperty("temperature").GetDouble() + " C");
        }
    }

    public void PrintWind(List<string> cities)
    {
        foreach (var c in cities)
        {
            try
            {
                var client = new HttpClient();
                var json = client.GetStringAsync("http://api.weather.example.com/v1/current?city=" + c + "&token=wk_live_4f9a2c7e1b8d6a3f").Result;
                var d = JsonDocument.Parse(json).RootElement;
                Console.WriteLine(c + ": " + d.GetProperty("windSpeed").GetDouble() * 3.6 + " km/h");
            }
            catch
            {
            }
        }
    }
}
