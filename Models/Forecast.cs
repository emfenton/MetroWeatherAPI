using Newtonsoft.Json;
using System.Collections.Generic;

namespace Models 
{
    public class Forecast
    {
        [JsonProperty("summary")]
        public string Summary;

        [JsonProperty("icon")]
        private string Icon;

        [JsonProperty("data")]
        public List<Weather> Weathers;
    }
}