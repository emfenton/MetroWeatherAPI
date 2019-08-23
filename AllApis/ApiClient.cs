using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AllApis
{
    class ApiClient
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetAsync(string URL, List<Tuple<string, string>> headers = null)
        {
            try
            {
                if (headers != null) {
                    for (int i=0; i<headers.Count; i++)
                    {
                        Tuple<string, string> item = headers[i];
                        client.DefaultRequestHeaders.Add(item.Item1, item.Item2);
                    }
                }
                HttpResponseMessage response = await client.GetAsync(URL);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ",e.Message);
                return "error";
            }
        }
    }
}