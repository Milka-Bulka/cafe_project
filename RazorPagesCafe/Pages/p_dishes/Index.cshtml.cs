using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RazorPagesCafe;

namespace RazorPagesCafe.Pages.p_dishes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCafe.CafeContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(RazorPagesCafe.CafeContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        //public IList<Dish> Dish { get;set; }

        //[BindProperty(SupportsGet = true)]
        //public string? SearchString { get; set; }
        //public SelectList? Names { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string? DishName { get; set; }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Dish> Dishes { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Dish> dishQuery = from m in _context.Dishes
                                            orderby m.Name
                                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                dishQuery = dishQuery.Where(s => s.Name.Contains(searchString));
            }

            //var dishh = from m in _context.Dishes
            //             select m;

            //if (!string.IsNullOrEmpty(DishName))
            //{
            //    dishh = dishh.Where(x => x.Name == DishName);
            //}


            switch (sortOrder)
            {
                case "name_desc":
                    dishQuery = dishQuery.OrderByDescending(s => s.Name);
                    break;
                default:
                    dishQuery = dishQuery.OrderBy(s => s.Name);
                    break;
            }
            //Names = new SelectList(await dishQuery.Distinct().ToListAsync());
            //Dish = await dishQuery.ToListAsync();

            var pageSize = Configuration.GetValue("PageSize", 4);
            Dishes = await PaginatedList<Dish>.CreateAsync(
                dishQuery.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
