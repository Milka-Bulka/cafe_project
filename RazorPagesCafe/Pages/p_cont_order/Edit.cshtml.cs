using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesCafe.Models;

namespace RazorPagesCafe.Pages.p_cont_order
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesCafe.Models.cafeContext _context;

        public EditModel(RazorPagesCafe.Models.cafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContentsOfOrder ContentsOfOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContentsOfOrder = await _context.ContentsOfOrders
                .Include(c => c.IdOrderNavigation)
                .Include(c => c.IdPositionNavigation).FirstOrDefaultAsync(m => m.IdOrder == id);

            if (ContentsOfOrder == null)
            {
                return NotFound();
            }
           ViewData["IdOrder"] = new SelectList(_context.Orderrs, "IdOrder", "IdOrder");
           ViewData["IdPosition"] = new SelectList(_context.Dishes, "IdPosition", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ContentsOfOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentsOfOrderExists(ContentsOfOrder.IdOrder))
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

        private bool ContentsOfOrderExists(int id)
        {
            return _context.ContentsOfOrders.Any(e => e.IdOrder == id);
        }
    }
}
