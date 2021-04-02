using System;
using System.Collections.Generic;
using System.Text;
using Meals.Domain;
using Microsoft.EntityFrameworkCore;

namespace Meals.Persistence
{
    public class MealsDataContext : DbContext
    {
        public MealsDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<Ingredient> Ingredient { get; set; }

        public DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Ingredient>(x => x.HasKey(aa => new {aa.MealId, aa.FoodItemId}));
            builder.Entity<Ingredient>()
                .HasOne(u => u.foodItem)
                .WithMany(a => a.Ingredients)
                .HasForeignKey(aa => aa.FoodItemId);

            builder.Entity<Ingredient>()
               .HasOne(u => u.Meal)
               .WithMany(a => a.Ingredients)
               .HasForeignKey(aa => aa.MealId);
        }
    }
}
