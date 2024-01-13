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
             ContentsOfOrder = await _context.ContentsOfOrders
                .Include(c => c.IdOrderNavigation)
                .Include(c => c.IdPositionNavigation).FirstOrDefaultAsync(m => m.IdOrder == id);

             ViewData["IdOrder"] = new SelectList(_context.Dishes.Where(o => o.IdPosition == ContentsOfOrder.IdPosition).ToList(),
                         "IdPosition", "Name");
             ViewData["IdPosition"] = new SelectList(_context.Dishes.Where(o => o.IdPosition == ContentsOfOrder.IdPosition).ToList(),
                         "IdPosition", "IdPosition");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await Console.Out.WriteLineAsync(ContentsOfOrder.IdOrder.ToString());
            await Console.Out.WriteLineAsync(ContentsOfOrder.IdPosition.ToString());
            await Console.Out.WriteLineAsync(ContentsOfOrder.Comment.ToString());
            _context.Attach(ContentsOfOrder).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
