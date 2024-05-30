using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace DCH.Pages.Events
{
    public class ReadOnlyEventsModel : PageModel
    {
        private IEventRepository catalog;
        public int ClickCount { get; set; } = 0;
        public Dictionary<int, Event> FilteredEvents { get; set; }

        public Actor Actor { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Source { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public ReadOnlyEventsModel(IEventRepository cat)
        {
                catalog = cat;
        }
        public Dictionary<int, Event> Events { get; private set; }
        public IActionResult OnGet()
        {
            Events = catalog.AllEvents();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = catalog.FilterEvents(FilterCriteria);
            }
            return Page();
        }

        // ClickCount tæller hver gang der klikkes på tilmeld --> virker men kan klikkes op uendeligt og hænger ikke sammen med et actor ID endnu

        public IActionResult OnPostRegister(int eventId)
        {
            var actorId = GetActorId();

            Events = catalog.AllEvents();
            if (Events.ContainsKey(eventId))
            {
                var eventItem = Events[eventId];
                if (Events[eventId].ClickCount <= Events[eventId].MaxCount - 1 && !eventItem.RegisteredActors.Contains(actorId))
                {
                    Events[eventId].ClickCount++;
                    eventItem.RegisteredActors.Add(actorId);
                    catalog.UpdateEvent(Events[eventId]);
                }                          
            }

            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = catalog.FilterEvents(FilterCriteria);
            }
            return Page();
        }
        public IActionResult OnPostUndoRegister(int eventId)
        {
            var actorId = GetActorId();

            Events = catalog.AllEvents();
            if (Events.ContainsKey(eventId))
            {
                var eventItem = Events[eventId];

                if (Events[eventId].ClickCount <= Events[eventId].MaxCount - 1 && eventItem.RegisteredActors.Contains(actorId))
                {
                    Events[eventId].ClickCount--;
                    eventItem.RegisteredActors.Remove(actorId);
                    catalog.UpdateEvent(Events[eventId]);
                }
            }

            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = catalog.FilterEvents(FilterCriteria);
            }
            return Page();
        }

        private int GetActorId()
        {
            var actorJson = HttpContext.Session.GetString("LoggedInActor");
            if (actorJson != null)
            {
                var loggedInActor = JsonConvert.DeserializeObject<Actor>(actorJson);
                return loggedInActor.Id;
            }
            return -1;
        }
    }
}

