using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_cont_order
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public EditModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContentsOfOrder ContentsOfOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContentsOfOrder = await _context.ContentsOfOrders
                .Include(c => c.IdOrderNavigation)
                .Include(c => c.IdPositionNavigation).FirstOrDefaultAsync(m => m.IdOrder == id);

            if (ContentsOfOrder == null)
            {
                return NotFound();
            }
           ViewData["IdOrder"] = new SelectList(_context.Orderrs, "IdOrder", "IdOrder");
           ViewData["IdPosition"] = new SelectList(_context.Dishes, "IdPosition", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ContentsOfOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentsOfOrderExists(ContentsOfOrder.IdOrder))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContentsOfOrderExists(int id)
        {
            return _context.ContentsOfOrders.Any(e => e.IdOrder == id);
        }
    }
}
