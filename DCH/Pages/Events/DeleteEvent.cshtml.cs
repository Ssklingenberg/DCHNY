using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Events
{
    public class DeleteEventModel : PageModel
    {
        [BindProperty]
        public Event Event { get; set; }

        private IEventRepository catalog;

        public DeleteEventModel(IEventRepository eventRepository)
        {
            catalog = eventRepository;
        }

        public IActionResult OnGet(int id)
            {
                Event = catalog.GetEvents(id);
                return Page();
            }

            public IActionResult OnPost(int id)
            {
                catalog.DeleteEvent(id);
                return RedirectToPage("GetAllEvents");
            }
    }

}
    

