﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodStore.Data;
using FoodStore.Models;

namespace FoodStore.Pages.Foods
{
    public class EditModel : PageModel
    {
        private readonly FoodStore.Data.FoodStoreContext _context;

        public EditModel(FoodStore.Data.FoodStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Food Food { get; set; } = default!;

        [BindProperty]
        public byte[]? PrevImage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food =  await _context.Food.FirstOrDefaultAsync(m => m.foodId == id);
            if (food == null)
            {
                return NotFound();
            }
            Food = food;
            PrevImage = food.Image;
           ViewData["FoodCatId"] = new SelectList(_context.FoodCategory, "FoodCatId", "CategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile? imageEditFile)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            

            try
            {
                if (imageEditFile != null)
                {
                    // If a new file is uploaded, replace the image
                    using (MemoryStream ms = new MemoryStream())
                    {
                        imageEditFile.CopyTo(ms);
                        Food.Image = ms.ToArray();
                    }
                }
                else
                {
                    // If no new file is uploaded, retain the previous image
                    Food.Image = PrevImage;
                }
                _context.Attach(Food).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(Food.foodId))
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

        private bool FoodExists(int id)
        {
            return _context.Food.Any(e => e.foodId == id);
        }
    }
}
