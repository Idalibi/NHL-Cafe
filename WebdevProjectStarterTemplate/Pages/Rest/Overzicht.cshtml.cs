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

        public void OnGet()
        {
            RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);

            orders = new OrderRepo().GetOrders(RTableId);


        }
    }
}
