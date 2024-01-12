using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesCafe.Pages.p_order
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
        ViewData["IdVisitor"] = new SelectList(_context.Visitors, "IdVisitor", "Name");
            return Page();
        }

        [BindProperty]
        public Orderr Orderr { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Orderr.IdOrder = 15;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orderrs.Add(Orderr);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
