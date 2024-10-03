using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodStore.Data;
using FoodStore.Models;

namespace FoodStore.Pages.FoodCategories
{
    public class IndexModel : PageModel
    {
        private readonly FoodStore.Data.FoodStoreContext _context;

        public IndexModel(FoodStore.Data.FoodStoreContext context)
        {
            _context = context;
        }

        public IList<FoodCategory> FoodCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            FoodCategory = await _context.FoodCategory.ToListAsync();
        }
    }
}
