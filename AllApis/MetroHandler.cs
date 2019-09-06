using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace AllApis
{

    public class MetroHandler
    {
        private const string API_KEY = "ad456f3a99c24f8aa1765187d2d7017e";
        private const string DUNN_LORING_CODE = "K07";


        private string response;
        private MetroResponse metroResponse;

        public async Task<MetroResponse> GetTrainArrivals()
        {
            string url = "https://api.wmata.com/StationPrediction.svc/json/GetPrediction/" + DUNN_LORING_CODE;
            List<Tuple<string, string>> headers = new List<Tuple<string, string>>();
            Tuple<string, string> header = Tuple.Create("api_key", API_KEY);
            headers.Add(header);
            string response = await ApiClient.GetAsync(url, headers);
            metroResponse = JsonConvert.DeserializeObject<MetroResponse>(response);
            return metroResponse;
        }
        public void writeAllTrains()
        {
            for (int i = 0; i < metroResponse.TrainArrivals.Count; i++)
            {
                Console.WriteLine(metroResponse.TrainArrivals[i].Line + " to " + metroResponse.TrainArrivals[i].Destination + " arrives at " + metroResponse.TrainArrivals[i].LocationName + " in " + metroResponse.TrainArrivals[i].Min);
            }
        }
    }
}