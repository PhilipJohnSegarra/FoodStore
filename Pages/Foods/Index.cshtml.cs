using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodStore.Data;
using FoodStore.Models;

namespace FoodStore.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly FoodStore.Data.FoodStoreContext _context;

        public IndexModel(FoodStore.Data.FoodStoreContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Food = await _context.Food
                .Include(f => f.Category).ToListAsync();
        }
    }
}
