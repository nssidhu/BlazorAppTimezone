using BlazorAppTimezone.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppTimezone.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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



        [Route("GetTimeZonetime/{*TimeZone}")]
        [HttpGet]
        public IActionResult GetTimeZonetime(string TimeZone)
        {
            var timezoneDetails = new TimezoneDetails();
            try
            {
                              
              
                var _timeZone = Uri.UnescapeDataString(TimeZone);
                //TimeZone = "America/Chicago";
                TimeZoneInfo timezoneID = TimeZoneInfo.FindSystemTimeZoneById(_timeZone);

                DateTimeOffset timeAtLcoation = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezoneID);


                var dtoffsettime = timeAtLcoation;
                Console.WriteLine(dtoffsettime.ToString("yyyy-MM-dd HH:mm:ss tt \"GMT\"zzz"));

                DateTimeOffset val = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, timezoneID.StandardName);
                DateTimeOffset val2 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, timezoneID.Id);

                string Windowstimezone = "";
                TimeZoneInfo.TryConvertIanaIdToWindowsId("America/Chicago", out Windowstimezone);


               
                timezoneDetails.TimeAtTimezone = TimeZone;
                timezoneDetails.TimezoneID = timezoneID.Id;
                timezoneDetails.TimeZoneDisplayName = timezoneID.DisplayName;
                timezoneDetails.TimeAtTimezone = timeAtLcoation.ToString("yyyy-MM-dd HH:mm:ss tt \"GMT\"zzz"); ;
                timezoneDetails.UTCTime = DateTime.UtcNow.ToString();
                timezoneDetails.ConvertedTimezone = Windowstimezone;
                return Ok(timezoneDetails);
            }
            catch (Exception e)
            {
                var er = new CustomError();
                er.Message = e.GetBaseException().Message;

                return BadRequest(er);
            }
          
           

        }


        [Route("GetFixedTimeZonetime")]
        [HttpGet]
        public IActionResult GetFixedTimeZonetime()
        {
            var timezoneDetails = new TimezoneDetails();
            try
            {


                var _timeZone = Uri.UnescapeDataString("America/Chicago");
                //TimeZone = "America/Chicago";
                TimeZoneInfo timezoneID = TimeZoneInfo.FindSystemTimeZoneById(_timeZone);

                DateTimeOffset timeAtLcoation = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezoneID);


                var dtoffsettime = timeAtLcoation;
                Console.WriteLine(dtoffsettime.ToString("yyyy-MM-dd HH:mm:ss tt \"GMT\"zzz"));

                DateTimeOffset val = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, timezoneID.StandardName);
                DateTimeOffset val2 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, timezoneID.Id);

                string Windowstimezone = "";
                TimeZoneInfo.TryConvertIanaIdToWindowsId("America/Chicago", out Windowstimezone);



                timezoneDetails.TimeAtTimezone = _timeZone;
                timezoneDetails.TimezoneID = timezoneID.Id;
                timezoneDetails.TimeZoneDisplayName = timezoneID.DisplayName;
                timezoneDetails.TimeAtTimezone = timeAtLcoation.ToString("yyyy-MM-dd HH:mm:ss tt \"GMT\"zzz"); ;
                timezoneDetails.UTCTime = DateTime.UtcNow.ToString();
                timezoneDetails.ConvertedTimezone = Windowstimezone;
                return Ok(timezoneDetails);
            }
            catch (Exception e)
            {
                var er = new CustomError();
                er.Message = e.GetBaseException().Message;

                return BadRequest(er);
            }



        }
    }
}