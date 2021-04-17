using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meals.Domain;

namespace Meals.Persistence
{
    public class Seed
    {
        public static async Task SeedData(MealsDataContext context)
        {
            // context.Recepies.RemoveRange(context.Recepies);
            // context.Ingredient.RemoveRange(context.Ingredient);
            //  context.FoodItems.RemoveRange(context.FoodItems);
            // await context.SaveChangesAsync();
            await SeedFoodItems(context);
            await SeedRecepies(context);
        }

        private static async Task SeedRecepies(MealsDataContext context)
        {
            if (context.Meals.Any())
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

        private static async Task SeedFoodItems(MealsDataContext context)
        {

            int count = context.FoodItems.Count();
            if (context.FoodItems.Any())
            {
                //return;
                //context.FoodItems = new  
                //await context.SaveChangesAsync();
                context.FoodItems.RemoveRange(context.FoodItems);
                await context.SaveChangesAsync();
            }

            var foodItems = ReadFoodItems();
            await context.FoodItems.AddRangeAsync(foodItems);
            await context.SaveChangesAsync();
        }
        public static List<FoodItem> ReadFoodItems()
        {
            string file = @"C:\Users\sechber7\source\repos\private\RKalkyl\RKalkylBackend\Meals\Meals.Persistence\LivsmedelsDB_202102212044_ordered2.csv";
            //string file = @"C:\Users\sechber7\source\repos\private\RKalkyl\RKalkyl\Persistance\LivsmedelsDB_202102212044_ordered2.csv";
            var foodItems = new List<FoodItem>();
            if (File.Exists(file))
            {
                string[] lines = System.IO.File.ReadAllLines(file, Encoding.GetEncoding("ISO-8859-1"));

                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i].Split(';');
                    var foodItem = new FoodItem()
                    {
                        Name = line[0],
                        WeightPerItem = int.TryParse(line[1], out int weightPerItem) ? weightPerItem : 0,
                        WeightPerDl = int.TryParse(line[2], out int weightPerDl) ? weightPerDl : 0,
                        Carbs = double.TryParse(line[6], out double carb) ? carb : 0,
                        Fat = double.TryParse(line[7], out double fat) ? fat : 0,
                        Protein = double.TryParse(line[8], out double protein) ? protein : 0,
                    };
                    foodItems.Add(foodItem);
                }
            }

            return foodItems;
        }
    }

}
//dotnet ef migrations add Name -p Meals.Persistence -s ..\Main