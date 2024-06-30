using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages;

[BindProperties]
public class BestellenModel : PageModel
{
    public OrderLine order = new();
    public IEnumerable<Category> CategoriesWithProduct { get; set; }
    public string categorie;
    string userid;

    public IActionResult OnGet()
    {
        userid = HttpContext.Session.GetString("userID");
        if (userid == null)
        {
            return new RedirectResult("../login");
        }

        order.RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);
        CategoriesWithProduct = new CategoryRepository().GetCategoriesWithProducts();
        return Page();
    }
    public IActionResult OnPost()
    {
        order.RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);
        int iterator = 1;
        var rows = Request.Form;
        foreach (var row in rows)
        {
            if (row.Key.Equals("__RequestVerificationToken"))
            {
                break;
            }
            if (iterator % 2 == 1)
            {
                order.ProductId = Convert.ToInt32(row.Value);
            }

            else
            {
                order.Amount = Convert.ToInt32(row.Value);
                try
                {
                    new OrderRepo().AddOrder(order);
                } catch { continue; } //TODO inplaats van continue, een orderUpdate()
            }
            iterator++;
        }
        //omdat het formulier dynamisch is aangemaakt doorloopt hij de request.form
        //uiteindelijk komt er een request verification of zoiets en die wordt gefilterd
        return Redirect("/Rest/Overzicht");
    }
}
