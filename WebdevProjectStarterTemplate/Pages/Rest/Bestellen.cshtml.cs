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

    public void OnGet()
    {
        order.RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);
        CategoriesWithProduct = new CategoryRepository().GetCategoriesWithProducts();
    }
    public IActionResult OnPost()
    {
        order.RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);
        int iterator = 1;
        var rows = Request.Form;
        foreach (var row in rows)
        {
            if (iterator % 2 == 1)
            {
                Console.WriteLine(row.Value.ToString());
                order.ProductId = Convert.ToInt32(row.Value);
            }

            else
            {
                order.Amount = Convert.ToInt32(row.Value);
                new OrderRepo().AddOrder(order);
            }
            iterator++;
        }
        //omdat het formulier dynamisch is aangemaakt doorloop hij de request.form
        return Redirect("/Rest/Overzicht");
    }
}
