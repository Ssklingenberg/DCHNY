using DCH.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DCH.Models;

namespace DCH.Pages.AdminLogin
{
    public class AdminLoginModel : PageModel
    {
        //private IAdminLoginRepository catalog;

        //public AdminLoginModel(IAdminLoginRepository cat)
        //{
        //    catalog = cat;
        //}

        ////public Dictionary<int, @DCH.Models.AdminLogin> adminLogin { get; private set; }
        //public IActionResult OnGet()
        //{
        //    return Page();
        //}

        [BindProperty]
        public @DCH.Models.AdminLogin adminLogin {  get; set; }
        public string ErrorMessage { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (adminLogin.UserName == "admin" && adminLogin.Password == "1234")
            {
                return RedirectToPage("/Login/Administration");
            }
            else
            {
                ErrorMessage = "Invalid username or password";
                return Page();
            }
        }
    }
}
