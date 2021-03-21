using Application.Dtos;
using AutoMapper;
using RKalkyl.Domain;

namespace RKalkyl.Application.Core
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

           // CreateMap<FoodItemDto, FoodItem>();
           // CreateMap<MealDto, Meal>();
           // CreateMap<IngredientDto, Ingredient>()
             //   .ForMember(d => d.FoodItemId, o => o.MapFrom(s => s.foodItem.FoodItemId));
        }
    }
}