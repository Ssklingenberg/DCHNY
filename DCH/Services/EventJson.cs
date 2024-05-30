using DCH.Helpers;
using DCH.Interfaces;
using DCH.Models;

namespace DCH.Services
{
    public class EventJson : IEventRepository
    {
        //string JsonFileName = @"C:\Users\papri\OneDrive - Zealand\Skrivebord\Projekt 1. sem\DcH\DCH\Data\JsonEvents.json";
        //string JsonFileName = @"C:\Users\eriki\OneDrive - Zealand\Semester 1\Afleveringer\DCH\DCH\DCH\Data\JsonEvents.json";
        //string JsonFileName = @"C:\Users\mlber\source\repos\DCH\DCH\Data\JsonEvents.json";
        //string JsonFileName = @"C:\Users\sskli\source\repos\DCH\DCH\Data\JsonEvents.json";


        private readonly Dictionary<int, Event> events = new Dictionary<int, Event>();
        private int currentId = 0;

        public EventJson()
        {
            events = AllEvents();

            if (events.Keys.Any())
            {
                currentId = events.Keys.Max() + 1;
            }
            else
            {
                currentId = 0;
            }
        }

        //public void AddEvent(Event Event)
        //{
        //    Dictionary<int, Event> events = AllEvents();
        //    if (Event != null)
        //    {
        //        events[(int)Event.Id] = Event;
        //    }
        //    JsonFileWriter.WriteToJson(events, JsonFileName);
        //}

        public void AddEvent(Event ev)
        {
            if (ev != null)
            {
                ev.Id = currentId++;
            }
            events[ev.Id] = ev;
            JsonFileWriter.WriteToJson(events, JsonFileName);
        }

        public void AddEventIdNo(Event ev)
        {
            ev.Id = currentId++;
        }

        public Dictionary<int, Event> AllEvents()
        {
            return JsonFileReader.ReadJson(JsonFileName);
        }

        public void DeleteEvent(int id)
        {
            Dictionary<int, Event> events = AllEvents();
            events.Remove(id);
            JsonFileWriter.WriteToJson(events, JsonFileName);
        }

        public Dictionary<int, Event> FilterEvents(string criteria)
        {
            Dictionary<int, Event> Event = AllEvents();
            Dictionary<int, Event> myEvents = new Dictionary<int, Event>();
            if (criteria != null)
            {
                foreach (var e in Event.Values)
                {
                    if (e.Name.Contains(criteria, StringComparison.OrdinalIgnoreCase) || e.City.Contains(criteria, StringComparison.OrdinalIgnoreCase))
                    {
                        myEvents.Add(e.Id, e);
                    }
                }
            }
            return myEvents;
        }
    


        public Event GetEvents(int id)
        {
            Dictionary<int, Event> events = AllEvents();
            return events[id];
        }

        //public Event GetEvents(int id)
        //{
        //    Dictionary<int, Event> events = AllEvents();
        //    return events[id];
        //}

        public void UpdateEvent(Event Event)
        {
            Dictionary<int, Event> events = AllEvents();
            if (Event != null)
            {
                events[(int)Event.Id] = Event;
            }
            JsonFileWriter.WriteToJson(events, JsonFileName);
        }
    }
}
