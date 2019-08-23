using Newtonsoft.Json;

namespace Models
{
    public class Weather
    {
        [JsonProperty("time")]
        private long Time;

        [JsonProperty("summary")]
        public string Summary;

        [JsonProperty("icon")]
        private string Icon;

        [JsonProperty("nearestStormDistance")]
        private int NearestStormDistance;

        [JsonProperty("precipIntensity")]
        private float PrecipIntensity;

        [JsonProperty("precipProbability")]
        private float PrecipProbability;

        [JsonProperty("precipType")]
        private string PrecipType;

        [JsonProperty("temperature")]
        public float Temperature;

        [JsonProperty("apparentTemperature")]
        private float ApparentTemperature;

        [JsonProperty("humidity")]
        private float Humidity;

        [JsonProperty("windGust")]
        private float WindGust;
    }    
}