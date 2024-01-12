using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_dishes
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public CreateModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dish Dish { get; set; }
        [BindProperty]
        public ContentsOfOrder ContentsOfOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dish = await _context.Dishes
                .Include(d => d.MenuViewNavigation).FirstOrDefaultAsync(m => m.IdPosition == id);
            if (Dish == null)
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

            _context.ContentsOfOrders.Add(ContentsOfOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
