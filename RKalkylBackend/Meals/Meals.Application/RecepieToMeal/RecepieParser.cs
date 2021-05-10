﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meals.Domain;

namespace Meals.Application.RecepieToMeal
{
    public class RecepieParsedData
    {
        public string Unit { get; set; }
        public double Amount { get; set; }

        public string IngredientString { get; set; }
    }

    public class RecepieParser
    {
       public List<RecepieParsedData> Parse(List<string> recepie)
       {
            var parsedDatas = new List<RecepieParsedData>();

            foreach(var recepieLine in recepie)
            {
                parsedDatas.Add(ParseLine(recepieLine));
            }
            return parsedDatas;
       }

        public RecepieParsedData ParseLine(string recepieLine)
        {
            var recepieLineSplit = recepieLine.Split(" ").ToList();

            if(recepieLineSplit.Count == 1)
            {
                return new RecepieParsedData()
                {
                    Amount = 0,
                    Unit = "st",
                    IngredientString = string.Join(" ", recepieLineSplit)
                };
            }

            double amount = 0;
            if (recepieLineSplit[0] != null)
            {
                var str = recepieLineSplit[0].Replace('.', ',');
                if (RKalkylMath.Fractional.IsFractional(str))
                {
                    amount = RKalkylMath.Fractional.ToDecimal(str);
                }
                else if(RKalkylMath.Fractional.IsFractional(recepieLineSplit[1]))
                {
                    var recepieLineSplit2 = new List<string>();
                    recepieLineSplit2.Add(recepieLineSplit[0] + " " + recepieLineSplit[1]);
                    recepieLineSplit.RemoveAt(0);
                    recepieLineSplit.RemoveAt(0);
                    recepieLineSplit2.AddRange(recepieLineSplit);
                    recepieLineSplit = recepieLineSplit2;
                    amount = RKalkylMath.Fractional.ToDecimal(recepieLineSplit[0]);

                }
                else
                {
                    double.TryParse(str, out amount);
                }
            }

            if (amount == 0)
            {
                return new RecepieParsedData()
                {
                    Amount = 0,
                    Unit = "st",
                    IngredientString = string.Join(" ", recepieLineSplit)
                };
            }

            int ingredietIndex = IsUnit(recepieLineSplit[1]) ? 2 : 1;
            string ingredientString = string.Join(" ", recepieLineSplit.GetRange(ingredietIndex, recepieLineSplit.Count - ingredietIndex));

            return new RecepieParsedData()
            {
                Amount = amount,
                Unit = recepieLineSplit.Count > 1 ? GetUnit(recepieLineSplit[1]) : "",
                IngredientString = recepieLineSplit.Count > ingredietIndex ? ingredientString : ""
            };
        }

        private string GetUnit(string unitCanditate)
        {
            if (IsUnit(unitCanditate))
            {
                return unitCanditate;
            }

            return "st";
        }
        private bool IsUnit(string unitCanditate)
        {
            return Units.GetUnits().Contains(unitCanditate);
        }
    }
}
