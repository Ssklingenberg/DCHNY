using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DCH.Pages.Actors
{
    public class UpdateActorsModel : PageModel
    {
        private IActorRepository catalog;

        [BindProperty]
        public Actor Actor { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Source { get; set; }

        public UpdateActorsModel(IActorRepository cat)
        {
            catalog = cat;
        }
        public IActionResult OnGet(int id)
        {
            Actor = catalog.GetActors(id);
            if (Actor == null)
            {
                // Hvis brugeren ikke findes, omdiriger til en fejlside
                return RedirectToPage("/Error");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.UpdateActor(Actor);
            // Opdater sessionen med de nyeste brugeroplysninger
            HttpContext.Session.SetString("LoggedInActor", JsonConvert.SerializeObject(Actor));

            // Ændring: Omdiriger til profilsiden efter opdatering
            return RedirectToPage("/Actors/Profile");
        }
    }
}
