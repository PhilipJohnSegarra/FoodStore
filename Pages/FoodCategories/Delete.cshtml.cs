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
    public class DeleteModel : PageModel
    {
        private readonly FoodStore.Data.FoodStoreContext _context;

        public DeleteModel(FoodStore.Data.FoodStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodcategory = await _context.FoodCategory.FindAsync(id);
            if (foodcategory != null)
            {
                FoodCategory = foodcategory;
                _context.FoodCategory.Remove(FoodCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
