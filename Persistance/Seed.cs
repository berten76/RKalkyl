using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistance
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            await SeedFoodItems(context);
            await SeedRecepies(context);
        }

        private static async Task SeedRecepies(DataContext context)
        {
            if(context.Recepies.Any())
            {
                context.Recepies.RemoveRange(context.Recepies);
            }


            var recepies = new List<Recepie>
            {
                new Recepie
                {
                    Name = "Kyckling gryta",
                    Ingredients = new List<Ingredient>
                    { 
                        new Ingredient() 
                        {
                             foodItem = context.FoodItems.First(f => f.Name == "kyckling"),
                             AmountInGram = 100 
                        },
                        new Ingredient()
                        {
                            foodItem = context.FoodItems.First(f => f.Name == "potatis"),
                            AmountInGram = 200
                        }
                    }
                }
            };

            await context.Recepies.AddRangeAsync(recepies);
            await context.SaveChangesAsync();
        }

        private static async Task SeedFoodItems(DataContext context)
        {
            if (context.FoodItems.Any()) return;
            
            var foodItems = new List<FoodItem>
            {
                new FoodItem
                {
                    Name = "potatis",
                    Protein = 0,
                    Carbs = 15,
                    Fat = 0
                },
                new FoodItem
                {
                    Name = "kyckling",
                    Protein = 20,
                    Carbs = 0,
                    Fat = 5
                },
               new FoodItem
                {
                    Name = "banan",
                    Protein = 2,
                    Carbs = 20,
                    Fat = 0
                },
                new FoodItem
                {
                    Name = "olivolja",
                    Protein = 0,
                    Carbs = 0,
                    Fat = 100
                },
                
            };

            await context.FoodItems.AddRangeAsync(foodItems);
            await context.SaveChangesAsync();
        }
    }
}