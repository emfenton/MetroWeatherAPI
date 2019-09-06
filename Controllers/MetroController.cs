using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AllApis;
using Newtonsoft.Json;


namespace MetroWeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetroController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            MetroHandler metroHandler = new MetroHandler();
            MetroResponse metroResponse = metroHandler.GetTrainArrivals().Result;
            string json = JsonConvert.SerializeObject(metroResponse);
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