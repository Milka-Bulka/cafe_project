using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_cont_dish
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public DeleteModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContentsOfDish ContentsOfDish { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContentsOfDish = await _context.ContentsOfDishes
                .Include(c => c.IdIngredientNavigation)
                .Include(c => c.IdPositionNavigation).FirstOrDefaultAsync(m => m.IdIngredient == id);

            if (ContentsOfDish == null)
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

            ContentsOfDish = await _context.ContentsOfDishes.FindAsync(id);

            if (ContentsOfDish != null)
            {
                _context.ContentsOfDishes.Remove(ContentsOfDish);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
