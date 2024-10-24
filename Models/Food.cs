using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FoodStore.Models
{
    public class Food
    {
        [Key]
        public int foodId { get; set; }
        [Required (ErrorMessage = "Invalid")]
        [StringLength(50)]
        public string FoodName { get; set; } = string.Empty;
        public string FoodDescription { get; set; } = String.Empty;
        
        [AllowNull]
        public byte[]? Image { get; set; }
        [Required]
        public int FoodCatId { get; set; }
        [AllowNull]
        public double Price { get; set; }
        [AllowNull]
        public string Ingredients { get; set; } = string.Empty;

        public FoodCategory? Category { get; set; }
    }
}
