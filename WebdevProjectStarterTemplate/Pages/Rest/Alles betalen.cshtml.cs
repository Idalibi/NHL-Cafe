using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages.Rest
{
    public class Alles_betalenModel : PageModel
    {
        public int RTableId { get; set; }
        public List<OrderLine> orders = new();
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
        public IActionResult OnPost()
        {
            RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);

            orders = new OrderRepo().GetOrders(RTableId);

            foreach (var order in orders)
            {
                order.RTableId = RTableId;
                order.AmountPaid = order.Amount;
                new OrderRepo().BetaalAlles(order);
            }
            return new RedirectResult("Alles betalen");
        }
    }
}
