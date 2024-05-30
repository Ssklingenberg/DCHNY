using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Actors
{
    public class DeleteActorModel : PageModel
    {
        [BindProperty]
        public Actor Actor { get; set; }

        [BindProperty (SupportsGet = true)]
        public string Source { get; set; }

        private IActorRepository catalog;

        public DeleteActorModel(IActorRepository actorRepository)
        {
            catalog = actorRepository;
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

        public IActionResult OnPost(int id)
        {
            catalog.DeleteActor(id);
            HttpContext.Session.Remove("LoggedInActor");
            return RedirectToPage("/Actors/CreateActor");
        }
    }
}
