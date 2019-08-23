namespace Models.ResponseModels
{
    class WeatherResponse
    {
        public Weather Current;
        public Weather NextHour;

        public WeatherResponse(Weather current, Weather nextHour)
        {
            Current = current;
            NextHour = nextHour;
        }
    }
}