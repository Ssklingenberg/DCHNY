using DCH.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Actors
{
    public class GetAllActorsModel : PageModel
    {
        private IActorRepository catalog;  
        public Dictionary<int, @DCH.Models.Actor> FilteredActors { get; set; }

        //Skal supporte get for at kunne bruges som søgefunktion
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public GetAllActorsModel(IActorRepository cat)
        {
            catalog = cat;
        }

        public Dictionary<int, @DCH.Models.Actor> actors { get; private set; }
        public IActionResult OnGet()
        {
            actors = catalog.AllActors();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                actors = catalog.FilterActors(FilterCriteria);
            }
            return Page();
        }
    }
}
