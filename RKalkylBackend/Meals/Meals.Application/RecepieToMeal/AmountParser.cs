using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meals.Domain;

namespace Meals.Application.RecepieToMeal
{
    public class AmountParser
    {
        public static int GetAmount(FoodItem foodItem, string unit, double amount)
        {
            double returnvalue = 0;
            switch(unit)
            {
                case "g":
                case "gram":
                    returnvalue = amount;
                    break;
                case "dl":
                    returnvalue = foodItem.WeightPerDl * amount;
                    break;
                case "l":
                    returnvalue = foodItem.WeightPerDl * amount * 10;
                    break;
                case "tsk":
                    returnvalue = foodItem.WeightPerDl * amount * 0.05;
                    break;
                case "msk":
                    returnvalue = foodItem.WeightPerDl * amount * 0.15;
                    break;
                case "st":
                    returnvalue = foodItem.WeightPerItem * amount;
                    break;
            }
            return (int)Math.Round(returnvalue);
        }
    }
}
/*"g",
                "gram",
                "dl",
                "l",
                "tsk",
                "msk",*/