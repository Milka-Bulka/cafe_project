using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.visitors
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public DetailsModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Visitor Visitor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Visitor = await _context.Visitors.FirstOrDefaultAsync(m => m.IdVisitor == id);

            if (Visitor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
