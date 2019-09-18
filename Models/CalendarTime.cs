using Newtonsoft.Json;
using System;

namespace Models
{
    public class CalendarTime
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }

    }    
}    