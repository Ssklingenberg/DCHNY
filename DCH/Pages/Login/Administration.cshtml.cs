using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Login
{
    public class AdminOptionsModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostAdministerEvents()
        {
            return RedirectToPage("/Events/GetAllEvents");
        }

        public IActionResult OnPostAdministerActors()
        {
            return RedirectToPage("/Actors/GetAllActors");
        }
    }
}
