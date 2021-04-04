using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Meals.Application.Dtos;
using Meals.Domain;

namespace Meals.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<FoodItem, FoodItem>();
            CreateMap<Meal, Meal>();
            CreateMap<Ingredient, Ingredient>();

            CreateMap<FoodItem, FoodItemDto>();
            CreateMap<Meal, MealDto>();
            CreateMap<Ingredient, IngredientDto>();

            CreateMap<IngredientDto, Ingredient>();

            // CreateMap<FoodItemDto, FoodItem>();
            // CreateMap<MealDto, Meal>();
            // CreateMap<IngredientDto, Ingredient>()
            //   .ForMember(d => d.FoodItemId, o => o.MapFrom(s => s.foodItem.FoodItemId));
        }
    }
}
