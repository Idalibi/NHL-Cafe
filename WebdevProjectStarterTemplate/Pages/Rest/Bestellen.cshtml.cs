using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages;

[BindProperties]
public class BestellenModel : PageModel
{
    public int RTableId { get; set; }
    public IEnumerable<Category> CategoriesWithProduct { get; set; }

    public void OnGet()
    {
        RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);
        CategoriesWithProduct = new CategoryRepository().GetCategoriesWithProducts();
    }
    public IActionResult OnPost()
    {
        // TODO Request.Form doorlopen vanwege dynamisch gemaakte input
        // waarschijnlijk met meerdere queries, want ik heb geen flauw idee hoe je een lijst doorstuurt met dapper :/
        return Redirect("/Rest/Overzicht");
    }
}
