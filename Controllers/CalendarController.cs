using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AllApis;
using Google.Apis.Calendar.v3.Data;

namespace MetroWeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            GoogleCalendarHandler googleCalendarHandler = new GoogleCalendarHandler();
            Events events = googleCalendarHandler.getTodaysEvents();

        }

        
        }
    }
}
