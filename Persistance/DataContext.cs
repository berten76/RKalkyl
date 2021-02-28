using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistance
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<Recepie> Recepies {get; set;}
    }
}