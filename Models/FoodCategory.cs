using System.ComponentModel.DataAnnotations;

namespace FoodStore.Models
{
    public class FoodCategory
    {
        [Key]
        public int FoodCatId { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<Food>? Foods { get; set; }
    }
}
