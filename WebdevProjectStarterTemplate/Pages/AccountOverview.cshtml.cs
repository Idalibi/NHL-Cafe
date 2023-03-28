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
    public string userid { get; set; }
    public List<Table> tables { get; set; }
    //[BindProperty(RTableId = "tableselect")]

    public string RTableId { get; set; } = "nietveranderd";
    public IActionResult OnGet()
    {
        userid = HttpContext.Session.GetString("userID");
        if (userid == null )
        {
            return new RedirectResult("login");
        }
        //Guid guid = Guid.Parse(id);

        user = new UserRepo().GetUser(Convert.ToInt32(userid));

        tables = new MiscRepo().GetTables();

        return Page();
    }
    public IActionResult OnPost()
    {
        RTableId = Request.Form["tableselect"]; //weet niet waarom, maar anders bind hij niet
        TableSelector(Convert.ToInt32(RTableId));
        OnGet();            //TODO misschien nog iets met [viewdata] om te laten zien dat je daadwerkelijk een tafel selecteert // OnGet omdat hij anders tables kwijtraakt
        return Page();
    }
    public void TableSelector(int RTableId)
    {
        Response.Cookies.Delete("RTableId");
        Response.Cookies.Append("RTableId", RTableId.ToString());
    }
}
