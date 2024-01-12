using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_cont_order
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public IndexModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<ContentsOfOrder> ContentsOfOrder { get;set; }

        public async Task OnGetAsync()
        {
            ContentsOfOrder = await _context.ContentsOfOrders
                .Include(c => c.IdOrderNavigation)
                .Include(c => c.IdPositionNavigation).AsNoTracking().ToListAsync();
        }
    }
}
