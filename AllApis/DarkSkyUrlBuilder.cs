using System;
using System.Collections;

namespace AllApis
{
    public class DarkSkyUrlBuilder
    {
        private const string URL_TEMPLATE = "https://api.darksky.net/forecast/{0}/{1},{2}{3}";

        private string apiKey, latitude, longitude, url;
        ArrayList excludes = new ArrayList();


        public DarkSkyUrlBuilder() 
        {
        }

        public DarkSkyUrlBuilder addAPIKey(string apiKey)
        {
            this.apiKey = apiKey;
            return this;
        }

        public DarkSkyUrlBuilder addLatitude(string latitude)
        {
            this.latitude = latitude;
            return this;
        }

        public DarkSkyUrlBuilder addLongitude(string longitude)
        {
            this.longitude = longitude;
            return this;
        }

        public DarkSkyUrlBuilder addExclude(string exclude)
        {
            excludes.Add(exclude);
            return this;
        }

        public string build()
        {
            return String.Format(URL_TEMPLATE, apiKey, latitude, longitude, buildExcludes());
        }

        private string buildExcludes() 
        {
            if (excludes.Count == 0)
            {
                return "";                
            }
            string urlExcludes = "?excludes=";
            for (int i = 0; i < excludes.Count; i++)
            {
                urlExcludes = urlExcludes + excludes[i];
                if (i < excludes.Count -1)
                {
                    urlExcludes = urlExcludes + ",";
                }
            }
            return urlExcludes; 
        }
    }
}