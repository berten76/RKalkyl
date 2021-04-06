using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Meals.Application.Dtos;
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
        public class Query : IRequest<List<IngredientDto>> 
        {
            public string Recepie { get; set; }

            public Guid MealId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<IngredientDto>>
        {
            private readonly MealsDataContext _context;
            //private readonly IMapper _mapper;
            public Handler(MealsDataContext context)//, IMapper mapper)
            {
                //_mapper = mapper;
                _context = context;
            }

            public async Task<List<IngredientDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var foodItems = await _context.FoodItems.AsNoTracking().ToListAsync();

                var ingredients = new List<IngredientDto>();
                await Task.Run(() =>
                {
                    var result = GetMealWithCandidates(request.Recepie.Split(";").ToList(), foodItems);
                    ingredients = MealWithFoodItemCandidatesToIngrediets(request.MealId, result);

                    
                });

                return ingredients;
            }
        }
        private static List<IngredientDto> MealWithFoodItemCandidatesToIngrediets(Guid mealId, MealWithFoodItemCandidates candidates)
        {
            var ingredients = new List<IngredientDto>();
            foreach (var candidate in candidates.Ingredients)
            {
                var selectedCandidate = candidate.Candidates.FirstOrDefault();
                if (selectedCandidate == null) continue;

                ingredients.Add(new IngredientDto()
                {
                    AmountInGram = selectedCandidate.AmountInGram,
                    foodItem = new FoodItemDto()
                    {
                        Carbs = selectedCandidate.foodItem.Carbs,
                        Fat = selectedCandidate.foodItem.Fat,
                        FoodItemId = selectedCandidate.foodItem.FoodItemId,
                        Name = selectedCandidate.foodItem.Name,
                        Protein = selectedCandidate.foodItem.Protein

                    },
                    Id = Guid.NewGuid(),
                    MealId = mealId
                    //foodItem = selectedCandidate.foodItem,
                    //FoodItemId = selectedCandidate.FoodItemId,
                    //Id = Guid.NewGuid()
                });
            }
            return ingredients;
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
                if(ingredietCandidates.Candidates.Any())
                    meal.Ingredients.Add(ingredietCandidates);
            }

            return meal;
        }
    }
}
