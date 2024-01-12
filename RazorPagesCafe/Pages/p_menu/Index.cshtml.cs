using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_menu
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public IndexModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Menu> Menu { get;set; }

        public async Task OnGetAsync()
        {
            Menu = await _context.Menus.ToListAsync();
        }
    }
}
