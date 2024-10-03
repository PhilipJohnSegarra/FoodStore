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
        public string ImagePath { get; set; }
        [Required]
        public int FoodCatId { get; set; }

        public FoodCategory? Category { get; set; }
    }
}
