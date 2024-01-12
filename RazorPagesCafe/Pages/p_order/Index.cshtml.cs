using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCafe.Models;

namespace RazorPagesCafe.Pages.p_order
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCafe.Models.cafeContext _context;

        public IndexModel(RazorPagesCafe.Models.cafeContext context)
        {
            _context = context;
        }

        public IList<Orderr> Orderr { get;set; }

        public async Task OnGetAsync()
        {
            Orderr = await _context.Orderrs
                .Include(o => o.IdVisitorNavigation).ToListAsync();
        }
    }
}
