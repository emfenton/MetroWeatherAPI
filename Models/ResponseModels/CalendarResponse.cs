using Newtonsoft.Json;
using System.Collections.Generic;

namespace Models.ResponseModels
{

    class CalendarResponse
    {
    
    [JsonProperty("items")]    
    public List<MetroCalendarEvent> Items;



    }
}    