using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using AutoMapper;
using Meals.Application.Dtos;
using Meals.Persistence;

namespace Meals.Application.Meals
{
    public class List
    {
        public class Query : IRequest<List<MealDto>> { }

        public class Handler : IRequestHandler<Query, List<MealDto>>
        {
            private readonly MealsDataContext _context;
            private readonly IMapper _mapper;
            public Handler(MealsDataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<MealDto>> Handle(Query request, CancellationToken cancellationToken)
            {

                try
                {
                    var meals = await _context.Meals
                                 .Include(r => r.Ingredients)
                                 //.Include(r=> r.Ingredients.Select(i => i.foodItem))
                                 .ThenInclude(r => r.foodItem)
                                 .AsNoTracking()
                                 .ToListAsync();
                     var mealDtos = _mapper.Map<List<MealDto>>(meals);
                     return mealDtos;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("gggtttttttttttttttttttt");
                    Console.WriteLine(ex);
                    //_logger.LogError(ex, "An error occured durig migrations");
                }
                return null;
                //return new List<MealDto>();
            }
        }
    }
}
