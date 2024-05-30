using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Events
{
    public class UpdateEventModel : PageModel
    {
        private IEventRepository catalog;

        [BindProperty]
        public Event Event { get; set; }

        public UpdateEventModel(IEventRepository cat) 
        {
            catalog = cat;
        }

        public void OnGet(int id)
        {
            Event = catalog.GetEvents(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.UpdateEvent(Event);
            return RedirectToPage("GetAllEvents");
        }
    }
}
