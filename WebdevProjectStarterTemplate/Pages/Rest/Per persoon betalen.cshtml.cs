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

        public void OnGet()
        {
            RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);
            orders = new OrderRepo().GetOrders(RTableId);
        }
    }
}
