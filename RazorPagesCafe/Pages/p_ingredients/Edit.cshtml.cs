using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_ingredients
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public EditModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ingredient Ingredient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingredient = await _context.Ingredients.FirstOrDefaultAsync(m => m.IdIngredient == id);

            if (Ingredient == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(Ingredient.IdIngredient))
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

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.IdIngredient == id);
        }
    }
}
