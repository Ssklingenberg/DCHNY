using Microsoft.AspNetCore.Mvc.RazorPages;
using DCH.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DCH.Pages.Actors
{
    public class ProfileModel : PageModel
    {
        public Actor Actor { get; set; }

        public void OnGet()
        {
            // Hent brugeren fra sessionen
            var actorJson = HttpContext.Session.GetString("LoggedInActor");
            if (!string.IsNullOrEmpty(actorJson))
            {
                Actor = JsonConvert.DeserializeObject<Actor>(actorJson); // Deserialiser JSON-strengen til Actor objekt
            }
        }
    }
}