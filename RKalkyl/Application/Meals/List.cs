using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RKalkyl.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RKalkyl.Persistance;
using System;
using System.Linq;
using AutoMapper;
using Application.Dtos;

namespace RKalkyl.Application.Meals
{
    public class List
    {
        public class Query : IRequest<List<MealDto>> { }

        public class Handler : IRequestHandler<Query, List<MealDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
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
                catch(Exception ex)
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


