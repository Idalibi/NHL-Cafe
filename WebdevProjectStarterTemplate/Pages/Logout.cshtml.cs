using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;
namespace WebdevProjectStarterTemplate.Pages;
[BindProperties]
public class logoutModel : PageModel
{
    public IActionResult OnGet() {
        return Page();
    }
    public IActionResult OnPost() { 
        return Redirect("Login");
    }
}


//HttpContext.Session.Clear();
