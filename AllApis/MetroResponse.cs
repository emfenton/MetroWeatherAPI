using Newtonsoft.Json;
using System.Collections.Generic;
using Models;

namespace AllApis
{
    public class MetroResponse
    {
        [JsonProperty("Trains")]
        public List<TrainArrival> TrainArrivals;
    }
}