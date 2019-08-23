using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Models;


namespace AllApis
{

    public class DarkSkyHandler
    {
        private const string API_KEY = "191b24bfcf2d03ffba03a06147a7308e";
        private const string LAT = "38.9479545";
        private const string LONG = "-76.8719393";
        private const string DAILY = "daily";
        private DarkSkyResponse darkSkyResponse;
        
        private async Task GetWeather()
        {
            DarkSkyUrlBuilder builder = new DarkSkyUrlBuilder();
            string url = builder
                .addAPIKey(API_KEY)
                .addLatitude(LAT)
                .addLongitude(LONG)
                .addExclude(DAILY)
                .build();

            string response = await ApiClient.GetAsync(url);
            darkSkyResponse = JsonConvert.DeserializeObject<DarkSkyResponse>(response);
        }

        public async Task<Weather> getCurrentWeather()
        {
            if (darkSkyResponse == null) 
            {
                await GetWeather();
            }
            return darkSkyResponse.Currently;
        }

        public async Task<Weather> getNextHour()
        {
             if (darkSkyResponse == null) 
            {
                await GetWeather();
            }
            return darkSkyResponse.Hourly.Weathers[1];
        }
        public async Task<Weather> getDay(int day)
        {
             if (darkSkyResponse == null) 
            {
                await GetWeather();
            }
            return darkSkyResponse.Daily.Weathers[day];
        }

    }
}