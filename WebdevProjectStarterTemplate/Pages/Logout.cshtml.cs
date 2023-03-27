using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebdevProjectStarterTemplate.Pages;

public class logoutModel : PageModel
{
    public void OnGet()
    {
        HttpContext.Session.Clear();
    }
}
