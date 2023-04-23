using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages.Rest
{
    public class OverzichtModel : PageModel
    {
        public List<OrderLine> orders = new();
        public int RTableId { get; set; }
        public OrderLine neworder { get; set; } = new();
        string userid;

        public IActionResult OnGet()
        {
            userid = HttpContext.Session.GetString("userID");
            if (userid == null)
            {
                return new RedirectResult("../login");
            }

            RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);

            orders = new OrderRepo().GetOrders(RTableId);
            return Page();


        }
        public IActionResult OnPostIncrement() 
        {
            neworder.Amount = Convert.ToInt32(Request.Form["Amount"]);
            neworder.ProductId = Convert.ToInt32(Request.Form["ProductId"]);

            neworder.RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);
            neworder.Amount++;
            new OrderRepo().UpdateOrder(neworder);
            return new RedirectResult(" Overzicht");
        }
        public IActionResult OnPostDecrement()
        {
            neworder.Amount = Convert.ToInt32(Request.Form["Amount"]);
            if (neworder.Amount > 0)
            {

                neworder.ProductId = Convert.ToInt32(Request.Form["ProductId"]);

                neworder.RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);
                neworder.Amount--;
                new OrderRepo().UpdateOrder(neworder);
            }
            return new RedirectResult("Overzicht");
        }
    }
}
