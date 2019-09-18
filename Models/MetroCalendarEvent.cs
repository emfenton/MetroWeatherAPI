using Newtonsoft.Json;

namespace Models
{
    public class MetroCalendarEvent
    {
        [JsonProperty("summary")]
        public string Summary;

        [JsonProperty("start")]
        public CalendarTime Start;
    }    
}    