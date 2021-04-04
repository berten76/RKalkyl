using System;
using System.Threading;
using System.Threading.Tasks;
using Meals.Domain;
using Meals.Persistence;
using MediatR;

namespace Meals.Application.FoodItems
{
    public class Details
    {
        public class Query : IRequest<FoodItem>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, FoodItem>
        {
            private readonly MealsDataContext _context;
            public Handler(MealsDataContext context)
            {
                _context = context;
            }

            public async Task<FoodItem> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.FoodItems.FindAsync(request.Id);
            }
        }
    }
}
