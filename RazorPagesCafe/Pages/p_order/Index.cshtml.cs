using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_order
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public IndexModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Orderr> Orderr { get;set; }

        public async Task OnGetAsync()
        {
            Orderr = await _context.Orderrs
                .Include(o => o.IdVisitorNavigation).ToListAsync();
        }
    }
}
