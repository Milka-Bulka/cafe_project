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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesCafe.Models.cafeContext _context;

        public DetailsModel(RazorPagesCafe.Models.cafeContext context)
        {
            _context = context;
        }

        public ContentsOfDish ContentsOfDish { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContentsOfDish = await _context.ContentsOfDishes
                .Include(c => c.IdIngredientNavigation)
                .Include(c => c.IdPositionNavigation).FirstOrDefaultAsync(m => m.IdIngredient == id);

            if (ContentsOfDish == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
