using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Events
{
    public class GetAllEventsModel : PageModel
    {
        private IEventRepository catalog;
        public Dictionary<int, Event> FilteredEvents { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public GetAllEventsModel(IEventRepository cat)
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
    }
}
