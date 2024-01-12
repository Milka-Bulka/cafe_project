using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_cont_dish
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public EditModel(RazorPagesCafe.CafeContext context)
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
           ViewData["IdIngredient"] = new SelectList(_context.Ingredients, "IdIngredient", "Name");
           ViewData["IdPosition"] = new SelectList(_context.Dishes, "IdPosition", "Description");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ContentsOfDish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentsOfDishExists(ContentsOfDish.IdIngredient))
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

        private bool ContentsOfDishExists(int id)
        {
            return _context.ContentsOfDishes.Any(e => e.IdIngredient == id);
        }
    }
}
