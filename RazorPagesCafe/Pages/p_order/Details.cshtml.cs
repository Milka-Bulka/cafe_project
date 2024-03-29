﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCafe.Models;

namespace RazorPagesCafe.Pages.p_order
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesCafe.Models.cafeContext _context;

        public DetailsModel(RazorPagesCafe.Models.cafeContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
