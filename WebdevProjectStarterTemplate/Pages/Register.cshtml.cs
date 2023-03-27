using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages;
[BindProperties]
public class registerModel : PageModel
{
    public CafeUser user { get; set; }
    public string id;
    public IActionResult OnGet()
    {
        id = HttpContext.Session.GetString("userID");
        if(id !=null)
        {
            return Redirect("AccountOverview");
        }
        return Page();
    }
    public IActionResult OnPost()
    {
        StaticUserRepo.AddUser(user);
        user = StaticUserRepo.GetUser(user.UserName, user.Password);
        HttpContext.Session.SetString("userID", user.UniqueGuid.ToString());
        id = HttpContext.Session.GetString("userID");
        if (id != null)
            return Redirect("AccountOverview");
        return Page();
    }
}
