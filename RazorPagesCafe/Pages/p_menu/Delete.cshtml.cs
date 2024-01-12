using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_menu
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public DeleteModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Menu Menu { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu = await _context.Menus.FirstOrDefaultAsync(m => m.MenuView == id);

            if (Menu == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu = await _context.Menus.FindAsync(id);

            if (Menu != null)
            {
                _context.Menus.Remove(Menu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
