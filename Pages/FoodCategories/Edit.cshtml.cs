using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodStore.Data;
using FoodStore.Models;

namespace FoodStore.Pages.FoodCategories
{
    public class EditModel : PageModel
    {
        private readonly FoodStore.Data.FoodStoreContext _context;

        public EditModel(FoodStore.Data.FoodStoreContext context)
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

            var foodcategory =  await _context.FoodCategory.FirstOrDefaultAsync(m => m.FoodCatId == id);
            if (foodcategory == null)
            {
                return NotFound();
            }
            FoodCategory = foodcategory;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FoodCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodCategoryExists(FoodCategory.FoodCatId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FoodCategoryExists(int id)
        {
            return _context.FoodCategory.Any(e => e.FoodCatId == id);
        }
    }
}
