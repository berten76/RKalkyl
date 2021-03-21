using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RKalkyl.Domain;

namespace RKalkyl.Persistance
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
           // context.Recepies.RemoveRange(context.Recepies);
           // context.Ingredient.RemoveRange(context.Ingredient);
          //  context.FoodItems.RemoveRange(context.FoodItems);
           // await context.SaveChangesAsync();
            await SeedFoodItems(context);
            await SeedRecepies(context);
        }

        private static async Task SeedRecepies(DataContext context)
        {
            if(context.Meals.Any())
            {
                return;
               // context.Recepies.RemoveRange(context.Recepies);
            }


            var recepies = new List<Meal>
            {
                new Meal
                {
                    Name = "Kyckling gryta",
                    Ingredients = new List<Ingredient>
                    { 
                        new Ingredient() 
                        {
                            //Id = Guid.NewGuid(),
                             foodItem = context.FoodItems.First(f => f.Name == "Gris bacon stekt"),
                             AmountInGram = 100 
                        },
                        new Ingredient()
                        {
                           // Id = Guid.NewGuid(),
                            foodItem = context.FoodItems.First(f => f.Name == "Potatismjöl"),
                            AmountInGram = 200
                        }
                    }
                }
            };

            await context.Meals.AddRangeAsync(recepies);
            await context.SaveChangesAsync();
        }

        private static async Task SeedFoodItems(DataContext context)
        {

            int count = context.FoodItems.Count();
            if (context.FoodItems.Any())
            {
                return;
                //context.FoodItems.RemoveRange(context.FoodItems);
                //await context.SaveChangesAsync();
            }
                        //Livsmedelsnamn;Livsmedelsnummer;Energi (kcal);Energi (kJ);Kolhydrater (g);Fett (g);Protein
            string file = @"C:\Users\sechber7\source\repos\private\RKalkyl\RKalkyl\Persistance\LivsmedelsDB_202102212044.csv";
           var foodItems = new List<FoodItem>();
            if(File.Exists(file))
            {
                string[] lines = System.IO.File.ReadAllLines(file);
              
                for(int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i].Split(';');
                    var foodItem = new FoodItem()
                    {
                          Name = line[0],
                          Carbs = double.TryParse(line[4], out double carb) ? carb : 0,
                          Fat = double.TryParse(line[5], out double fat) ? fat : 0,
                          Protein = double.TryParse(line[6], out double protein) ? protein : 0,
                    };
                    foodItems.Add(foodItem);
                }
            }
            // var foodItems = new List<FoodItem>
            // {
            //     new FoodItem
            //     {
            //         Name = "potatis",
            //         Protein = 0,
            //         Carbs = 15,
            //         Fat = 0
            //     },
            //     new FoodItem
            //     {
            //         Name = "kyckling",
            //         Protein = 20,
            //         Carbs = 0,
            //         Fat = 5
            //     },
            //    new FoodItem
            //     {
            //         Name = "banan",
            //         Protein = 2,
            //         Carbs = 20,
            //         Fat = 0
            //     },
            //     new FoodItem
            //     {
            //         Name = "olivolja",
            //         Protein = 0,
            //         Carbs = 0,
            //         Fat = 100
            //     },
                
            //};

            await context.FoodItems.AddRangeAsync(foodItems);
            await context.SaveChangesAsync();
        }
    }
}