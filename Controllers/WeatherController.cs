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
        // GET api/values
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
        //     DarkSkyHandler darkSkyHandler = new DarkSkyHandler();
        //     await darkSkyHandler.GetWeather();
        //     Weather current = darkSkyHandler.getCurrentWeather();
        //     Weather nextHour = darkSkyHandler.getNextHour();
        //     Weather tomorrow = darkSkyHandler.getDay(1);
        //     Weather twoDays = darkSkyHandler.getDay(2);
        //     Console.WriteLine("The current temperature is " + current.Temperature + ". Later: " + nextHour.Summary + ". Tomorrow's weather will be: " + tomorrow.Summary +".");
        //     Console.WriteLine("Two days weather: " + twoDays.Summary);

        //     MetroHandler metroHandler = new MetroHandler();
        //     await metroHandler.GetTrainArrivals();

        //     metroHandler.writeAllTrains();
            
        //     GoogleCalendarHandler googleCalendarHandler = new GoogleCalendarHandler();
        //     googleCalendarHandler.getTodaysEvents();
        