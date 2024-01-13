using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCafe.Pages.p_cont_order
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public CreateModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dish Dish { get; set; }
        [BindProperty]
        public ContentsOfOrder ContentsOfOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            Dish = await _context.Dishes
                .Include(d => d.MenuViewNavigation).FirstOrDefaultAsync(m => m.IdPosition == id);
            if (id == null)
            {
                ViewData["IdPosition"] = new SelectList(_context.Dishes, "IdPosition", "Name");
            }
            else
            {
                ViewData["IdPosition"] = new SelectList(_context.Dishes
                            .Where(o => o.Name == Dish.Name).ToList(),
                         "IdPosition", "Name");
            }
            ViewData["IdOrder"] = new SelectList(_context.Orderrs, "IdOrder", "IdOrder");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            _context.ContentsOfOrders.Add(ContentsOfOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}