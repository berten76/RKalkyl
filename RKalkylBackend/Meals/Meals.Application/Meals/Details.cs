using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using AutoMapper;
using Meals.Application.Dtos;
using Meals.Persistence;

namespace Meals.Application.Meals
{
    public class Details
    {
        public class Query : IRequest<MealDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, MealDto>
        {
            private readonly MealsDataContext _context;
            private readonly IMapper _mapper;

            public Handler(MealsDataContext context, IMapper mapper)
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
