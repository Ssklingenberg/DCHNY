using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DCH.Interfaces;

namespace DCH.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        private IEventRepository catalog;
        [BindProperty]
        public Event Event { get; set; }

        public CreateEventModel(IEventRepository cat) 
        {
            catalog = cat;
        }
        

        public IActionResult OnGet(int id)
        {
            Event = new Event();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Event.Id == 0)
            {
                catalog.AddEvent(Event);
            }
            return RedirectToPage("GetAllEvents");
        }
    }
}
