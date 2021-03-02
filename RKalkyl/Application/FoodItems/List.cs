using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RKalkyl.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RKalkyl.Persistance;

namespace RKalkyl.Application.FoodItems
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
                // var values = new List<FoodItem>();
                // var dbValues = await _context.FoodItems.ToListAsync();
                // for(int i = 0; i < 20; i++)
                // {
                //     values.Add(dbValues[i]);
                // }
                // return values;
                return await _context.FoodItems.ToListAsync();
            }
        }
    }
}