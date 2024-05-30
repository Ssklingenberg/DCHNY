using System.Collections.Generic;
using DCH.Models;
namespace DCH.Interfaces

{
    public interface IEventRepository
    {
        Dictionary<int, Event> AllEvents();
        Dictionary<int, Event> FilterEvents(string criteria);
        void DeleteEvent(int id);
        void AddEvent(Event Event);
        void UpdateEvent(Event Event);
        Event GetEvents(int id);
    }
}
