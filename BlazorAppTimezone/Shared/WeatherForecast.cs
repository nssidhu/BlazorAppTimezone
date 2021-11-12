namespace BlazorAppTimezone.Shared
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public class TimezoneDetails
    {
        public string TimeZoneName { get; set; }
        public string TimezoneID { get; set; }
        public string TimeZoneDisplayName { get; set; }

        public string TimeAtTimezone { get; set; }

        public string UTCTime { get; set; }

        public string ConvertedTimezone { get; set; }
    }
}