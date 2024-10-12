using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodStore.Data;
using FoodStore.Models;

namespace FoodStore.Pages.Foods
{
    public class CreateModel : PageModel
    {
        private readonly FoodStore.Data.FoodStoreContext _context;

        public CreateModel(FoodStore.Data.FoodStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FoodCatId"] = new SelectList(_context.FoodCategory, "FoodCatId", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Food Food { get; set; } = default!;

        [BindProperty]
        public IFormFile? imageFile { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageFile.CopyTo(ms);
                    Food.Image = ms.ToArray();

                    
                }
                _context.Food.Add(Food);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch
            {
                return NotFound();
            }

                
        }
    }
}
