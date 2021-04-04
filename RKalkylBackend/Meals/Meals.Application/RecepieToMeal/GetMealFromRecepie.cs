using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using AutoMapper;
using Meals.Application.RecepieToMeal.Models;
using Meals.Domain;
using Meals.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Meals.Application.RecepieToMeal
{
    public class GetMealFromRecepie
    {
        public class Query : IRequest<Meal> 
        {
            public List<string> Recepie { get; set; }
        }

        public class Handler : IRequestHandler<Query, Meal>
        {
            private readonly MealsDataContext _context;
            //private readonly IMapper _mapper;
            public Handler(MealsDataContext context)//, IMapper mapper)
            {
                //_mapper = mapper;
                _context = context;
            }

            public async Task<Meal> Handle(Query request, CancellationToken cancellationToken)
            {
                var foodItems = await _context.FoodItems.AsNoTracking().ToListAsync();

                var result = GetMealWithCandidates(request.Recepie, foodItems);



                return null;
            }




            //    public async Task<Meal> Handle(Query request, CancellationToken cancellationToken)
            //    {

            //        try
            //        {
            //            //var meals = await _context.Meals
            //            //             .Include(r => r.Ingredients)
            //            //             //.Include(r=> r.Ingredients.Select(i => i.foodItem))
            //            //             .ThenInclude(r => r.foodItem)
            //            //             .AsNoTracking()
            //            //             .ToListAsync();
            //            //var mealDtos = _mapper.Map<List<MealDto>>(meals);
            //            //return mealDtos;
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine("gggtttttttttttttttttttt");
            //            Console.WriteLine(ex);
            //            //_logger.LogError(ex, "An error occured durig migrations");
            //        }
            //        return null;
            //        //return new List<MealDto>();
            //    }
            //}
        }

        public static MealWithFoodItemCandidates GetMealWithCandidates(List<string> recepie, List<FoodItem> foodItems)
        {
            var recepieParser = new RecepieParser();
            var parsedDatas = recepieParser.Parse(recepie);

            var meal = new MealWithFoodItemCandidates();

            var foodItemFinder = new FoodItemFinder();
            foreach (var parsedData in parsedDatas)
            {
                var ingredietCandidates = new IngredientCandidates();
                var footItemInrecepie = foodItemFinder.FindFood(parsedData.IngredientString, foodItems);
                foreach (var foodItem in footItemInrecepie)
                {
                    ingredietCandidates.Candidates.Add(new IngredientCandidate()
                    {
                        foodItem = foodItem,
                        FoodItemId = foodItem.FoodItemId,
                        AmountInGram = AmountParser.GetAmount(foodItem, parsedData.Unit, parsedData.Amount),
                        AmountInUnit = (int)parsedData.Amount,
                        Unit = parsedData.Unit
                    });
                }

                meal.Ingredients.Add(ingredietCandidates);
            }

            return meal;
        }
    }
}
