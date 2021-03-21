using System;
using System.Threading;
using System.Threading.Tasks;
using RKalkyl.Domain;
using MediatR;
using RKalkyl.Persistance;
using Application.Dtos;
using AutoMapper;

namespace RKalkyl.Application.Meals
{
    public class Details
    {
         public class Query : IRequest<MealDto> 
         { 
             public Guid Id { get; set; }
         }

        public class Handler : IRequestHandler<Query, MealDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<MealDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var meal = await _context.Meals.FindAsync(request.Id);
                var mealDto = _mapper.Map<MealDto>(meal);
                return mealDto;
            }
        } 
    }
}