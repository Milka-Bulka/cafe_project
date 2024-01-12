using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesCafe.Models;

namespace RazorPagesCafe.Pages.p_cont_order
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesCafe.Models.cafeContext _context;

        public CreateModel(RazorPagesCafe.Models.cafeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdOrder"] = new SelectList(_context.Orderrs, "IdOrder", "IdOrder");
        ViewData["IdPosition"] = new SelectList(_context.Dishes, "IdPosition", "Name");
            return Page();
        }

        [BindProperty]
        public ContentsOfOrder ContentsOfOrder { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
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
