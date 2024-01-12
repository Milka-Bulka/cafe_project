using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCafe.Models;

namespace RazorPagesCafe.Pages.p_cont_order
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesCafe.Models.cafeContext _context;

        public DeleteModel(RazorPagesCafe.Models.cafeContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContentsOfOrder = await _context.ContentsOfOrders.FindAsync(id);

            if (ContentsOfOrder != null)
            {
                _context.ContentsOfOrders.Remove(ContentsOfOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
