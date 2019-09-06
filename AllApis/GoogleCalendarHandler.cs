using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AllApis
{
    class GoogleCalendarHandler
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/calendar-dotnet-quickstart.json
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Metro Weather App";

        private UserCredential credential;

        private CalendarService service;

        EventsResource.ListRequest request;

        private void getCredential()
        {
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
        }

        private void createApiService()
        {
            // Create Google Calendar API service.
            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,        
            });
        }   
            // Define parameters of request.

        private void defineRequestParameters(int numberOfDays)
        {    
            request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.TimeMax = DateTime.Today.AddDays(numberOfDays).Date;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
        }

            // List events.
        private Events listEvents()
        {
            Events events = request.Execute();
            return events;
        }

        public Events getTodaysEvents()
        {
            getCredential();
            createApiService();
            defineRequestParameters(1);
            return listEvents();
        }
    }
}