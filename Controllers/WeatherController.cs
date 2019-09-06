using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AllApis;
using Models;
using Models.ResponseModels;
using Newtonsoft.Json;

namespace MetroWeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        // GET api/weather
        [HttpGet]
        public ActionResult<string> Get()
        {
            DarkSkyHandler darkSkyHandler = new DarkSkyHandler();
            Weather current = darkSkyHandler.getCurrentWeather().Result;
            Weather nextHour = darkSkyHandler.getNextHour().Result;
            WeatherResponse response = new WeatherResponse(current, nextHour);
            string json = JsonConvert.SerializeObject(response);
            return json;
        }
    }
}
        // private static async Task runApplicationAsynchronously() {

        //     MetroHandler metroHandler = new MetroHandler();
        //     await metroHandler.GetTrainArrivals();

        //     metroHandler.writeAllTrains();
            
        //     GoogleCalendarHandler googleCalendarHandler = new GoogleCalendarHandler();
        //     googleCalendarHandler.getTodaysEvents();
        