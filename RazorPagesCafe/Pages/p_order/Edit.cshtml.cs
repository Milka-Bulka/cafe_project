﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesCafe.Models;

namespace RazorPagesCafe.Pages.p_order
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesCafe.Models.cafeContext _context;

        public EditModel(RazorPagesCafe.Models.cafeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Orderr Orderr { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Orderr = await _context.Orderrs
                .Include(o => o.IdVisitorNavigation).FirstOrDefaultAsync(m => m.IdOrder == id);

            if (Orderr == null)
            {
                return NotFound();
            }
           ViewData["IdVisitor"] = new SelectList(_context.Visitors, "IdVisitor", "Name");
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

            _context.Attach(Orderr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderrExists(Orderr.IdOrder))
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

        private bool OrderrExists(int id)
        {
            return _context.Orderrs.Any(e => e.IdOrder == id);
        }
    }
}
