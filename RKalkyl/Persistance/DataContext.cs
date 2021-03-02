using System.IO;
using Microsoft.EntityFrameworkCore;
using RKalkyl.Domain;

namespace RKalkyl.Persistance
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<Ingredient> Ingredient {get; set;}

        public DbSet<Recepie> Recepies {get; set;}
    }
}