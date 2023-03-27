using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebdevProjectStarterTemplate.Pages.Rest
{
    public class BestellenModel : PageModel
    {
        public int RTableId { get; set; }
        public void OnGet()
        {
            RTableId = Convert.ToInt32(Request.Cookies["RTableId"]);
        }
    }
}
