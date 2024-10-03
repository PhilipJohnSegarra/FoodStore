using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodStore.Models;

namespace FoodStore.Data
{
    public class FoodStoreContext : DbContext
    {
        public FoodStoreContext (DbContextOptions<FoodStoreContext> options)
            : base(options)
        {
        }

        public DbSet<FoodStore.Models.FoodCategory> FoodCategory { get; set; } = default!;
        public DbSet<FoodStore.Models.Food> Food { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>()
                .HasOne(c => c.Category)
                .WithMany(b => b.Foods)
                .HasForeignKey(a => a.FoodCatId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
