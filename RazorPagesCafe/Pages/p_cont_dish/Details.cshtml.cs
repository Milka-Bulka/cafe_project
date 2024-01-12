using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_cont_dish
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public DetailsModel(RazorPagesCafe.CafeContext context)
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
    }
}
