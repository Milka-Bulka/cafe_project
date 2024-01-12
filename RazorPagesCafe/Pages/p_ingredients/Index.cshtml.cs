using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_ingredients
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public IndexModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Ingredient> Ingredient { get;set; }

        public async Task OnGetAsync()
        {
            Ingredient = await _context.Ingredients.ToListAsync();
        }
    }
}
