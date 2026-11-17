var cities = new List<string> { "Bergen", "Oslo", "Trondheim", "Stavanger" };
var report = new WeatherReport();
report.PrintWind(cities);
report.PrintTemperatures(cities);
