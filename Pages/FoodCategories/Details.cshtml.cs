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
    public class DetailsModel : PageModel
    {
        private readonly FoodStore.Data.FoodStoreContext _context;

        public DetailsModel(FoodStore.Data.FoodStoreContext context)
        {
            _context = context;
        }

        public FoodCategory FoodCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodcategory = await _context.FoodCategory.FirstOrDefaultAsync(m => m.FoodCatId == id);
            if (foodcategory == null)
            {
                return NotFound();
            }
            else
            {
                FoodCategory = foodcategory;
            }
            return Page();
        }
    }
}
