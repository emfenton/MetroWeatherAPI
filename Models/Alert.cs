using Newtonsoft.Json;

namespace Models
{
    public class Alert
    {
        [JsonProperty("title")]
        private string Title;

        [JsonProperty("time")]
        private long Time;

        [JsonProperty("expires")]
        private long Expires;

        [JsonProperty("description")]
        private string Description;

        [JsonProperty("uri")]
        private string Uri;


    }
    
}
