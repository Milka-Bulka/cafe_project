using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesCafe.Pages.p_dishes
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public CreateModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MenuView"] = new SelectList(_context.Menus, "MenuView", "MenuView");
            return Page();
        }

        [BindProperty]
        public Dish Dish { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Dishes.Add(Dish);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}