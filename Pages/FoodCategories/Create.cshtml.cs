using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodStore.Data;
using FoodStore.Models;

namespace FoodStore.Pages.FoodCategories
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
            return Page();
        }

        [BindProperty]
        public FoodCategory FoodCategory { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FoodCategory.Add(FoodCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
