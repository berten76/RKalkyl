using AutoMapper;
using RKalkyl.Domain;

namespace RKalkyl.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<FoodItem, FoodItem>();
            CreateMap<Recepie, Recepie>();
        }
    }
}