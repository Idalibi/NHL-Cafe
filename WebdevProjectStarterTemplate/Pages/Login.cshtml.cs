using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Repositories;
namespace WebdevProjectStarterTemplate.Pages;

public class loginModel : PageModel
{
            public string UserName;
            public string Password;
            public Guid userid;
            public void OnGet()
            {
                StaticUserRepo.GetUser(userid);
            }
}
