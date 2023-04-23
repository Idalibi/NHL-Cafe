using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages.Rest
{
    public class Per_persoon_betalenModel : PageModel
    {
        public int RTableId { get; set; }
        public List<OrderLine> orders = new();
        public OrderLine order { get; set; } = new();
        string userid;

        public IActionResult OnGet()
        {
            RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);
            orders = new OrderRepo().GetOrders(RTableId);
            userid = HttpContext.Session.GetString("userID");
            if (userid == null)
            {
                return new RedirectResult("../login");
            }
            return Page();

        }
        public IActionResult OnPost()
        {
            order.RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);
            int iterator = 1;
            var rows = Request.Form;
            foreach(var row in rows)
            {
                if (row.Key.Equals("__RequestVerificationToken"))
                {
                    break;
                }
                if (iterator % 2 == 1)
                {
                    order.AmountPaid= Convert.ToInt32(row.Value);
                }


                if (iterator % 2 == 0)
                {
                    order.ProductId= Convert.ToInt32(row.Value);
                    new OrderRepo().Betaal(order);
                }
                iterator++;
            }
            return new RedirectResult("Alles betalen");
        }
    }
}
