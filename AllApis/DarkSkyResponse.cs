using Newtonsoft.Json;
using System.Collections.Generic;
using Models;

namespace AllApis
{
    public class DarkSkyResponse
    {
        [JsonProperty("currently")]
        public Weather Currently;

        [JsonProperty("minutely")]
        public Forecast Minutely;

        [JsonProperty("hourly")]
        public Forecast Hourly;

        [JsonProperty("daily")]
        public Forecast Daily;

        [JsonProperty("alerts")]
        public List<Alert> Alerts;
    }

}