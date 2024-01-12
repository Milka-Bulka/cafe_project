using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesCafe;

namespace RazorPagesCafe.Pages.p_dishes
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;

        public CreateModel(RazorPagesCafe.CafeContext context)
        {
            _context = context;
        }

        public Dish Dish { get; set; }
        public ContentsOfOrder ContentsOfOrder { get; set; }

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
            ViewData["IdOrder"] = new SelectList(_context.Orderrs, "IdOrder", "IdOrder");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ContentsOfOrder.IdPositionNavigation = Dish;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ContentsOfOrders.Add(ContentsOfOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
