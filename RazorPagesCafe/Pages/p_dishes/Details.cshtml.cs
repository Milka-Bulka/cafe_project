using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_dishes
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public DetailsModel(RazorPagesCafe.CafeContext context)
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
    }
}
