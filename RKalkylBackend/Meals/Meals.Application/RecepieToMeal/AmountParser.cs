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
                case Units.g:
                case Units.gram:
                    returnvalue = amount;
                    break;
                case Units.dl:
                    returnvalue = foodItem.WeightPerDl * amount;
                    break;
                case Units.l:
                    returnvalue = foodItem.WeightPerDl * amount * 10;
                    break;
                case Units.tsk:
                    returnvalue = foodItem.WeightPerDl * amount * 0.05;
                    break;
                case Units.msk:
                    returnvalue = foodItem.WeightPerDl * amount * 0.15;
                    break;
                case Units.krm:
                    returnvalue = foodItem.WeightPerDl * amount * 0.01;
                    break;
                case Units.förp:
                case Units.st:
                    returnvalue = foodItem.WeightPerItem * amount;
                    break;
            }
            return (int)Math.Round(returnvalue);
        }
    }
}
