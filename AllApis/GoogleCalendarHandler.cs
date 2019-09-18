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
using Models;

namespace AllApis
{
    public class GoogleCalendarHandler
    {
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
        private List<MetroCalendarEvent> listEvents()
        {
            List<MetroCalendarEvent> eventsList = new List<MetroCalendarEvent>();
            Events events = request.Execute();
            foreach (Event Event in events.Items)
            {
                CalendarTime time = new CalendarTime();
                time.Date = Event.Start.Date;
                time.DateTime = Event.Start.DateTime.Value;
                time.TimeZone = Event.Start.TimeZone;
                MetroCalendarEvent metroEvent = new MetroCalendarEvent();
                metroEvent.Start = time;
                metroEvent.Summary = Event.Summary;
                eventsList.Add(metroEvent);
            }
            return eventsList;
        }

        public List<MetroCalendarEvent> getTodaysEvents()
        {
            getCredential();
            createApiService();
            defineRequestParameters(1);
            return listEvents();
        }
    }
}