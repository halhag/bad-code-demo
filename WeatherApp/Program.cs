var cities = new List<string> { "Tromsø & co", "Bergen", "Oslo", "Trondheim", "Stavanger" };
var report = new WeatherReport();
report.PrintWind(cities);
report.PrintTemperatures(cities);
