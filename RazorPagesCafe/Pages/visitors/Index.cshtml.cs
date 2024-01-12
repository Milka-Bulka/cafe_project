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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCafe.Models.cafeContext _context;

        public IndexModel(RazorPagesCafe.Models.cafeContext context)
        {
            _context = context;
        }

        public IList<Visitor> Visitor { get;set; }

        public async Task OnGetAsync()
        {
            Visitor = await _context.Visitors.ToListAsync();
        }
    }
}
