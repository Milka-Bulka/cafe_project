using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCafe.Models;

namespace RazorPagesCafe.Pages.p_cont_dish
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCafe.Models.cafeContext _context;

        public IndexModel(RazorPagesCafe.Models.cafeContext context)
        {
            _context = context;
        }

        public IList<ContentsOfDish> ContentsOfDish { get;set; }

        public async Task OnGetAsync()
        {
            ContentsOfDish = await _context.ContentsOfDishes
                .Include(c => c.IdIngredientNavigation)
                .Include(c => c.IdPositionNavigation).ToListAsync();
        }
    }
}
