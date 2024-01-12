using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCafe.Models;

namespace RazorPagesCafe.Pages.p_menu
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesCafe.Models.cafeContext _context;

        public DetailsModel(RazorPagesCafe.Models.cafeContext context)
        {
            _context = context;
        }

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
    }
}
