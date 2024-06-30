using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;
namespace WebdevProjectStarterTemplate.Pages;
[BindProperties]
public class loginModel : PageModel
{
    public CafeUser loginuser { get; set; }
    public string sessionID { get; set; }
    public IActionResult OnGet()
    {
        HttpContext.Session.Clear();
        sessionID = HttpContext.Session.GetString("userID");
        if (sessionID != null)
        {
            return Redirect("AccountOverview");
        }
        return Page();
    }
    public IActionResult OnPost()
    {
        loginuser = new UserRepo().GetUser(loginuser);
        if(loginuser != null)
            HttpContext.Session.SetString("userID", loginuser.UniqueGuid.ToString());
        return Redirect("AccountOverview");
    }
}