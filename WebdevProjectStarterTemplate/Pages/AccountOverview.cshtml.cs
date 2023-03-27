using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages;
[BindProperties]

public class overviewModel : PageModel
{
    public CafeUser user { get; set; }
    public string id { get; set; }
    public List<Table> tables { get; set; }
    public IActionResult OnGet()
    {
        id = HttpContext.Session.GetString("userID");
        if (id == null )
        {
            return new RedirectResult("login");
        }
        Guid guid = Guid.Parse(id);

        user = StaticUserRepo.GetUser(guid);

        tables = new MiscRepo().GetTables();

        return Page();
    }
    public void TableSelector(int RTableId)
    {
        Response.Cookies.Delete("RTableId");
        Response.Cookies.Append("RTableId", RTableId.ToString());
    }
}
