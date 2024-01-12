using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCafe.Models;

namespace RazorPagesCafe.Pages.visitors
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesCafe.Models.cafeContext _context;

        public DeleteModel(RazorPagesCafe.Models.cafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Visitor Visitor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Visitor = await _context.Visitors.FirstOrDefaultAsync(m => m.IdVisitor == id);

            if (Visitor == null)
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

            Visitor = await _context.Visitors.FindAsync(id);

            if (Visitor != null)
            {
                _context.Visitors.Remove(Visitor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
