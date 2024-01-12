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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCafe.Models.cafeContext _context;

        public IndexModel(RazorPagesCafe.Models.cafeContext context)
        {
            _context = context;
        }

        public IList<Menu> Menu { get;set; }

        public async Task OnGetAsync()
        {
            Menu = await _context.Menus.ToListAsync();
        }
    }
}
