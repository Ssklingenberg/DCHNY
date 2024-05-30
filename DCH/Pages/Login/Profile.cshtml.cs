using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DCH.Models;
using DCH.Interfaces;
namespace DCH.Pages.Login
{
    public class ProfileModel : PageModel
    {
        public void OnGet()
        {
        }
    }
    private readonly UserService _userService;

    public ProfileModel(UserService userService)
    {
        _userService = userService;
    }

    public User User { get; set; }

    public void OnGet()
    {
        var username = HttpContext.Session.GetString("Username");
        if (username != null)
        {
            User = _userService.GetUser(username);
        }
    }
}
