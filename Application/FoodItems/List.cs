using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.FoodItems
{
    public class List
    {
        public class Query : IRequest<List<FoodItem>> { }

        public class Handler : IRequestHandler<Query, List<FoodItem>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<FoodItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.FoodItems.ToListAsync();
            }
        }
    }
}