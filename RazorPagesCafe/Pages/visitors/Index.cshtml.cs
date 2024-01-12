using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.visitors
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public IndexModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Visitor> Visitor { get;set; }

        public async Task OnGetAsync()
        {
            Visitor = await _context.Visitors.ToListAsync();
        }
    }
}
