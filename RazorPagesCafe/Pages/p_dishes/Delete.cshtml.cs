using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_dishes
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public DeleteModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dish Dish { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dish = await _context.Dishes.FindAsync(id);

            if (Dish != null)
            {
                try
                {
                    _context.Dishes.Remove(Dish);
                    await _context.SaveChangesAsync();
                }
                catch { }
            }

            return RedirectToPage("./Index");
        }


    }
}
